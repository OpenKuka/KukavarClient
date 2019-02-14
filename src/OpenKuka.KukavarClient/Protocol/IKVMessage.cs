namespace OpenKuka.KukavarClient.Protocol
{
    public enum RWMode
    {
        READ = 0,
        WRITE = 1,
        UNDEF = -1,
    }

    /// <summary>
    /// Interface for the id-length-prefixe message protocol with the KukaVar Proxy.
    /// </summary>
    /// A Message is composded of a 4 bytes Header plus a Content :
    /// - Id                : ushort / 2 bytes (from 0 to 65535)
    /// - ContentLength     : ushort / 2 bytes (from 0 to 65535)
    /// - Content           : n bytes / where n = MessageLength
    /// 
    /// Thus, the whole message is coded over (4 + n) bytes.
    /// <remarks>
    public interface IKVMessage
    {
        /// <summary>
        /// Gets the message Id. Must be in the form of a ushort (from 0 to 65535).
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets number of bytes of the whole message packet. Must be in the form of a ushort (from 0 to 65535).
        /// </summary>
        int MessageLength { get; }

        /// <summary>
        /// Converts the whole message in to a bytes packet.
        /// </summary>
        byte[] Message { get; }

        /// <summary>
        /// Gets the number of bytes of the content. Must be in the form of a ushort (from 0 to 65535).
        /// </summary>
        int ContentLength { get; }

        /// <summary>
        /// Converts the content in to a bytes packet.
        /// A message cannot exceed 65535 (2^16 - 1) bytes, that is 65.5kB.
        /// </summary>
        byte[] Content { get; }

        /// <summary>
        /// Gets the message read/write mode.
        /// </summary>
        RWMode Mode { get; }



    }
}
