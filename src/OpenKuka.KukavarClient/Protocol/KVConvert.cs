using System;

namespace OpenKuka.KukavarClient.Protocol
{

    public static class KVPConvert
    {
        public static byte[] UShortToByte(int uint16)
        {
            // converts a 16 bits id to a 2 bytes array
            // help : https://github.com/ahmad-saeed/kukavarproxy-msg-format/blob/master/c%2B%2B/main.cpp
            var hByteMsg = (uint16 & 0xff00) >> 8;
            var lByteMsg = (uint16 & 0x00ff);
            return new byte[2] { (byte)lByteMsg, (byte)hByteMsg };
        }
        public static int UByteToShort(byte[] uint16)
        {
            // converts a 2 bytes uint16 to an int
            return BitConverter.ToUInt16(uint16, 0);
        }
        public static RWMode ByteToMode(byte b)
        {
            switch (b)
            {
                case 0x0:
                    return RWMode.READ;
                case 0x1:
                    return RWMode.WRITE;
                default:
                    return RWMode.UNDEF;
            }
        }
        public static string ModeToString(RWMode mode)
        {
            switch (mode)
            {
                case RWMode.READ:
                    return "READ";
                case RWMode.WRITE:
                    return "READ";
                default:
                    return "UNDEF";
            }
        }
        public static byte ModeToByte(RWMode mode)
        {
            switch (mode)
            {
                case RWMode.READ:
                    return 0x0;
                case RWMode.WRITE:
                    return 0x1;
                default:
                    return 0x2;
            }
        }
        
       
    }
}
