using OpenKuka.KRL.DataParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenKuka.KukavarClient.Protocol
{
    public enum KVParsingStatus
    {
        // succcess when data len > 0
        Valid,

        // success but data len == 0
        Empty,

        // failure
        NotEnoughBytes,
        InvalidRWStatus,
        InvalidTail,
    }
    /// <summary>
    /// kukavarproxy <see cref="KVAnswer"/> format is (from lower to higher bytes) :
    /// 
    /// msg ID in HEX                       2 bytes
    /// msg length in HEX                   2 bytes
    /// read(0) or write(1)                 1 byte
    /// variable value length in HEX        2 bytes
    /// variable value in ASCII             # bytes
    /// Padding value                       1 bytes 
    /// Status (01 01 = OK)                 2 bytes
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// <see cref="KVAnswer"/> packet structure example :
    ///  
    ///             | Msg ID  | Msg Len | R/W | VarValue Len | VarValue Chars       | Trail 
    /// bytes       | 0  1    | 2  3    | 4   | 5  6         | #                    | Pad | Status 
    /// value (hex) | 00 05   | 00 09   | 00  | 00 03        | 31 30 30             | 00  | 01 01
    /// value       |     5   |     9   |  0  |     3        |  1  0  0             |
    /// 
    /// </remarks>
    public struct KVAnswer : IKVMessage
    {
        public int Id { get; set; }
        public int MessageLength => 4 + ContentLength;
        public byte[] Message => ToBytes(withHeader: true);
        public int ContentLength => 3 + VarValue.Length + 3;
        public byte[] Content => ToBytes(withHeader: false);
        public RWMode Mode { get; private set; }
        public bool Successful { get; private set; }

        public string VarValue { get; private set; }
        public static KVAnswer Pong => new KVAnswer() { Id = 0, VarValue = "PONG", Mode = RWMode.READ, Successful = true };
        public static KVAnswer Empty => new KVAnswer() { Id = 0, VarValue = "", Mode = RWMode.UNDEF, Successful = false };

        /// <summary>
        /// Tries to build an answer form the avavilable bytes.
        /// </summary>
        /// <param name="bytes">The available bytes as an IEnumerable.</param>
        /// <param name="bytesCount">The number of bytes in the IEnumerable. Avoid unecessary enumerations.</param>
        /// <param name="answer">The answer on success. An empty answer on failure.</param>
        /// <returns>The status of the parsing process.</returns>
        public static KVParsingStatus TryParse(IEnumerable<byte> bytes, int bytesCount, out KVAnswer answer)
        {
            answer = new KVAnswer();
            
            if (bytes == null)
                return KVParsingStatus.NotEnoughBytes;

            if (bytesCount < 4) return KVParsingStatus.NotEnoughBytes;

            // get the enumerator to iterate byte by byte
            // the using statement ensure that the enumerator is properly disposed so the lock is released ...
            using (var enumerator = bytes.GetEnumerator())
            {

                // get the id
                byte b0, b1;

                enumerator.MoveNext();
                b0 = enumerator.Current;
                enumerator.MoveNext();
                b1 = enumerator.Current;

                answer.Id = KVPConvert.UByteToShort(new byte[2] { b1, b0 });

                // get the msg length
                byte b2, b3;

                enumerator.MoveNext();
                b2 = enumerator.Current;
                enumerator.MoveNext();
                b3 = enumerator.Current;

                var msgLength = KVPConvert.UByteToShort(new byte[2] { b3, b2 });

                if (bytesCount < msgLength + 4) return KVParsingStatus.NotEnoughBytes;

                // get the msg bytes
                var bmsg = new byte[msgLength];
                for (int i = 0; i < msgLength; i++)
                {
                    enumerator.MoveNext();
                    bmsg[i] = enumerator.Current;
                }

                answer.Mode = KVPConvert.ByteToMode(bmsg[0]);
                if (answer.Mode == RWMode.UNDEF)
                    return KVParsingStatus.InvalidRWStatus;

                var varValueLength = KVPConvert.UByteToShort(new byte[2] { bmsg[2], bmsg[1] });
                answer.VarValue = Encoding.ASCII.GetString(bmsg, 3, varValueLength);

                var tail_0 = bmsg[msgLength - 1];
                var tail_1 = bmsg[msgLength - 2];
                var tail_2 = bmsg[msgLength - 3];

                if (tail_0 != 0 && tail_1 != 1)
                    return KVParsingStatus.InvalidTail;
                if (tail_1 != 0 && tail_1 != 1)
                    return KVParsingStatus.InvalidTail;
                if (tail_2 != 0)
                    return KVParsingStatus.InvalidTail;

                if (tail_0 == 1 && tail_1 == 1) answer.Successful = true;
                else if (tail_0 == 0 && tail_1 == 0) answer.Successful = false;

                return KVParsingStatus.Valid;
            }
        }

        public override string ToString() => ToString(bytes: false);
        public string ToString(bool bytes = false)
        {
            if (bytes)
            {
                return BitConverter.ToString(Message).Replace("-", " ");
            }
            else
            {
                return string.Format("MsgAnswer[{0}|{1}|{2}bytes] : {3}", Id, Mode, MessageLength, VarValue);
            }
        }

        private byte[] ToBytes(bool withHeader = true)
        {
            var encoding = new ASCIIEncoding();

            var pktMessageId = KVPConvert.UShortToByte(Id);
            var pktVarValue = encoding.GetBytes(VarValue);
            var pktVarValueLength = KVPConvert.UShortToByte((short)VarValue.Length);
            var pktContentLength = KVPConvert.UShortToByte((short)ContentLength);

            if (withHeader)
            {

                var pkt = new byte[MessageLength];
                pkt[0] = pktMessageId[1];
                pkt[1] = pktMessageId[0];
                pkt[2] = pktContentLength[1];
                pkt[3] = pktContentLength[0];
                pkt[4] = KVPConvert.ModeToByte(Mode);
                pkt[5] = pktVarValueLength[1];
                pkt[6] = pktVarValueLength[0];
                pktVarValue.CopyTo(pkt, 7);
                pkt[7 + pktVarValue.Length] = 0x0;
                pkt[7 + pktVarValue.Length + 1] = Convert.ToByte(Successful);
                pkt[7 + pktVarValue.Length + 2] = Convert.ToByte(Successful);
                return pkt;
            }
            else
            {
                var pkt = new byte[MessageLength - 4];
                pkt[0] = KVPConvert.ModeToByte(Mode);
                pkt[1] = pktVarValueLength[1];
                pkt[2] = pktVarValueLength[0];
                pktVarValue.CopyTo(pkt, 3);
                pkt[3 + pktVarValue.Length] = 0x0;
                pkt[3 + pktVarValue.Length + 1] = Convert.ToByte(Successful);
                pkt[3 + pktVarValue.Length + 2] = Convert.ToByte(Successful);
                return pkt;
            }
        }

        public Data GetAST()
        {
            if (VarValue == "")
            {
                return new StringData("", @"""""");
            }
            else
            {
                return KrlDataParser.TryParse(VarValue).Value.First();
            }
        }
    }
}
