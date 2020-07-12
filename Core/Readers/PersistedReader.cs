using System;

namespace IkDNS.Core.Reader
{
    /// <summary>
    /// Allow us to recover a given data packet in its raw byte[] form before parsing or manipulation.
    /// </summary>
    public class PersistedReader : CustomReader, IDisposable
    {
        /// <summary>
        /// Byte[] representation of this Reader data.
        /// </summary>
        public byte[] Buffer { get; private set; }

        public byte[] HeaderBuffer { get; private set; }

        public PersistedReader(byte[] headerBuff, byte[] data) : base(data)
        {
            HeaderBuffer = headerBuff;
            Buffer = new byte[data.Length];
            Array.Copy(data, 0, Buffer, 0, data.Length);
        }

        public override void Close()
        {
            HeaderBuffer = null;
            Buffer = null;
            base.Close();
        }
    }
}
