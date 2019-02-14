using System;
using System.Text;

namespace OpenKuka.KukavarClient.Protocol
{
    /// <summary>
    /// kukavarproxy <see cref="KVReadQuery"/> format is (from lower to higher bytes) :
    /// 
    /// msg ID in HEX                       2 bytes
    /// msg length in HEX                   2 bytes
    /// read(0) or write(1)                 1 byte
    /// variable name length in HEX         2 bytes
    /// variable name in ASCII              # bytes
    /// 
    /// </summary>
    /// <remarks>
    /// {00 0F 00 0A 00 00 07 24 4F 56 5F 50 52 4F}
    /// <see cref="KVReadQuery"/> packet structure example :
    ///  
    ///             | Msg ID  | Msg Len | R/W | VarName Len  | VarName Chars       
    /// bytes       | 0  1    | 2  3    | 4   | 5  6         | #                   
    /// value (hex) | 00 05   | 00 0A   | 00  | 00 07        | 24 4F 56 5F 50 52 4F
    /// value       |     5   |    10   |  0  |     7        |  $  O  V  _  P  R  O
    /// 
    /// <see cref="KVAnswer"/> packet structure example for proxy answer :
    ///  
    ///             | Msg ID  | Msg Len | R/W | VarValue Len | VarValue Chars       | Trail 
    /// bytes       | 0  1    | 2  3    | 4   | 5  6         | #                    | Pad | Status 
    /// value (hex) | 00 05   | 00 09   | 01  | 00 03        | 31 30 30             | 00  | 01 01
    /// value       |     5   |     9   |  1  |     3        |  1  0  0             |
    /// 
    /// </remarks>
    public struct KVReadQuery : IKVMessage
    {
        public int Id { get; set; }
        public int MessageLength => 4 + ContentLength;
        public byte[] Message => ToBytes(withHeader: true);
        public int ContentLength => 3 + VarName.Length;
        public byte[] Content => ToBytes(withHeader: false);
        public RWMode Mode => RWMode.READ;
        public string VarName { get; private set; }

        public static KVReadQuery Ping => Build(0, "PING");
        public static KVReadQuery Build(int id, string varName)
        {
            return new KVReadQuery()
            {
                Id = id,
                VarName = varName,
            };
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
                return string.Format("Msg[{0}|{1}|{2}bytes] : {3}", Id, Mode, MessageLength, VarName);
            }
        }

        private byte[] ToBytes(bool withHeader = true)
        {
            var encoding = new ASCIIEncoding();
            byte pktReadMode = 0x0;

            var pktMessageId = KVPConvert.UShortToByte(Id);
            var pktVarName = encoding.GetBytes(VarName);
            var pktVarNameLength = KVPConvert.UShortToByte((short)VarName.Length);
            var pktContentLength = KVPConvert.UShortToByte((short)(VarName.Length + 3));

            if (withHeader)
            {
                var pkt = new byte[MessageLength];
                pkt[0] = pktMessageId[1];
                pkt[1] = pktMessageId[0];
                pkt[2] = pktContentLength[1];
                pkt[3] = pktContentLength[0];
                pkt[4] = pktReadMode;
                pkt[5] = pktVarNameLength[1];
                pkt[6] = pktVarNameLength[0];
                pktVarName.CopyTo(pkt, 7);
                return pkt;
            }
            else
            {
                var pkt = new byte[MessageLength - 4];
                pkt[0] = pktReadMode;
                pkt[1] = pktVarNameLength[1];
                pkt[2] = pktVarNameLength[0];
                pktVarName.CopyTo(pkt, 3);
                return pkt;
            }
        }
    }

}
