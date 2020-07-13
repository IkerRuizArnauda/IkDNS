using System;
using IkDNS.Core.Reader;
using IkDNS.Core.Helpers;

namespace IkDNS.Core.Resources
{
    public class Header : CustomReader, IDisposable
    {
        public ushort UUID { get; set; }
        private ushort Flags { get; set; } //16 bits
        public ushort QuestionCount { get; set; }
        public ushort AnswersCount { get; set; }
        public ushort AuthorityCount { get; set; }
        public ushort AdditionalCount { get; set; }
        public OPCode OPCODE => (OPCode)Flags.GetBits(11, 4); //4 bits
        public bool QR => Flags.GetBits(15, 1) == 1; //1 bit
        public bool AA => Flags.GetBits(10, 1) == 1; //1 bit 
        public bool TC => Flags.GetBits(9, 1) == 1; //1 bit
        public bool RD => Flags.GetBits(8, 1) == 1; //1 bit
        public bool RA => Flags.GetBits(7, 1) == 1; //1 bit
        public ushort Z => Flags.GetBits(4, 3); //3 bits
        public RCode RCODE => (RCode)Flags.GetBits(0, 4); //4 bits

        /// <summary>
        /// Byte[] representation of this header.
        /// </summary>
        public byte[] Buffer { get; private set; }

        /// <summary>
        /// Byte[] representation of this header payload.
        /// </summary>
        public byte[] Payload { get; private set; }

        public Header(byte[] data) : base(data)
        {
            UUID = ReadUInt16();
            Flags = ReadUInt16();
            QuestionCount = ReadUInt16();
            AnswersCount = ReadUInt16();
            AuthorityCount = ReadUInt16();
            AdditionalCount = ReadUInt16();

            Buffer = new byte[BaseStream.Position];
            Payload = new byte[data.Length - BaseStream.Position];

            Array.Copy(data, 0, Buffer, 0, Buffer.Length);
            Array.Copy(data, BaseStream.Position, Payload, 0, Payload.Length);
        }

        public override void Close()
        {
            Buffer = null;
            Payload = null;
            base.Close();
        }
    }
}
