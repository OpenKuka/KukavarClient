using System;
using System.Text;

namespace OpenKuka.KukavarClient.Protocol
{
    /// <summary>
    /// kukavarproxy <see cref="KVPWriteQuery"/> format is (from lower to higher bytes) :
    /// 
    /// msg ID in HEX                       2 bytes
    /// msg length in HEX                   2 bytes
    /// read(0) or write(1)                 1 byte
    /// variable name length in HEX         2 bytes
    /// variable name in ASCII              # bytes
    /// variable value length in HEX        2 bytes
    /// variable value in ASCII             # bytes
    /// 
    /// </summary>
    /// <remarks>
    /// {00 0F 00 0E 01 00 07 24 4F 56 5F 50 52 4F 00 02 35 30}
    /// {00 0F 00 08 01 00 02 35 30 01 01 00}
    /// <see cref="KVPWriteQuery"/> packet structure example :
    ///  
    ///             | Msg ID  | Msg Len | R/W | VarName Len  | VarName Chars        | VarValue Len | VarValue Chars  
    /// bytes       | 0  1    | 2  3    | 4   | 5  6         | #                    |              |
    /// value (hex) | 00 0F   | 00 0E   | 01  | 00 07        | 24 4F 56 5F 50 52 4F | 00 02        | 35 30
    /// value       |    15   |    14   |  1  |     7        |  $  O  V  _  P  R  O |     2        |  5  0
    /// 
    /// <see cref="KVAnswer"/> packet structure example for proxy answer :
    ///  
    ///             | Msg ID  | Msg Len | R/W | VarValue Len | VarValue Chars       | Trail 
    /// bytes       | 0  1    | 2  3    | 4   | 5  6         | #                    | Pad | Status 
    /// value (hex) | 00 0F   | 00 09   | 01  | 00 02        | 35 30                | 00  | 00 00
    /// value       |    15   |     9   |  1  |     2        |  5  0                |
    /// 
    /// </remarks>
    public struct KVPWriteQuery : IKVMessage
    {
        public int Id { get; set; }
        public int MessageLength => 4 + ContentLength;
        public byte[] Message => ToBytes(withHeader: true);
        public int ContentLength => 1 + (2 + VarName.Length) + (2 + VarValue.Length);
        public byte[] Content => ToBytes(withHeader: false);
        public RWMode Mode => RWMode.WRITE;
        public string VarName { get; private set; }
        public string VarValue { get; private set; }
             
        public static KVPWriteQuery Build(int id, string varName, string varValue)
        {
            return new KVPWriteQuery()
            {
                Id = id,
                VarName = varName,
                VarValue = varValue,
            };
        }

        private byte[] ToBytes(bool withHeader = true)
        {
            var encoding = new ASCIIEncoding();
            byte pktWriteMode = 0x1;

            var pktMessageId = KVPConvert.UShortToByte(Id);

            var pktVarName = encoding.GetBytes(VarName);
            var pktVarNameLength = KVPConvert.UShortToByte((short)VarName.Length);

            var pktVarValue = encoding.GetBytes(VarValue);
            var pktVarValueLength = KVPConvert.UShortToByte((short)VarValue.Length);

            var pktContentLength = KVPConvert.UShortToByte((short)(1 + 2 + pktVarName.Length + 2 + pktVarValue.Length));

            if (withHeader)
            {
                var pkt = new byte[MessageLength];
                pkt[0] = pktMessageId[1];
                pkt[1] = pktMessageId[0];
                pkt[2] = pktContentLength[1];
                pkt[3] = pktContentLength[0];
                pkt[4] = pktWriteMode;
                pkt[5] = pktVarNameLength[1];
                pkt[6] = pktVarNameLength[0];
                pktVarName.CopyTo(pkt, 7);
                pkt[7 + pktVarName.Length] = pktVarValueLength[1];
                pkt[7 + pktVarName.Length + 1] = pktVarValueLength[0];
                pktVarValue.CopyTo(pkt, 7 + pktVarName.Length + pktVarValueLength.Length);
                return pkt;
            }
            else
            {
                var pkt = new byte[MessageLength - 4];
                pkt[0] = pktWriteMode;
                pkt[1] = pktVarNameLength[1];
                pkt[2] = pktVarNameLength[0];
                pktVarName.CopyTo(pkt, 3);
                pkt[3 + pktVarName.Length] = pktVarValueLength[1];
                pkt[3 + pktVarName.Length + 1] = pktVarValueLength[0];
                pktVarValue.CopyTo(pkt, 3 + pktVarName.Length + pktVarValueLength.Length);
                return pkt;
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
                return string.Format("Msg[{0}|{1}|{2}bytes] : {3} = {4}", Id, Mode, MessageLength, VarName, VarValue);
            }
        }
    }
}
