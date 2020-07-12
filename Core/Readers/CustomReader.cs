using System;
using System.IO;
using System.Linq;
using System.Text;

namespace IkDNS.Core.Reader
{
    public class CustomReader : BinaryReader
    {
        public CustomReader(byte[] data) : base(new MemoryStream(data)) { }
        public override byte ReadByte()
        {
            return base.ReadByte();
        }

        public override char ReadChar()
        {
            return (char)ReadByte();
        }

        public override string ReadString()
        {
            return ReadChars(ReadByte()).ToString();
        }

        public override uint ReadUInt32()
		{
            //Flush first 16 bits and apply AND upon second 16 bits.
            return (uint)(ReadUInt16() << 16 | ReadUInt16());
        }

        public override ushort ReadUInt16()
        {
            //Flush first 8 bits and apply AND upon second 8 bits.
            return (ushort)(ReadByte() << 8 | ReadByte());
        }

        public string ReadDomainName()
        {
            StringBuilder Sb = new StringBuilder();
            for (int strLength; (strLength = ReadByte()) != 0;)
            {
                //TODO: Compression needs a revamp.
                if ((strLength & 192) == 192)
                {
                    var offset = (strLength & 63) << 8 | ReadByte();

                    try
                    {
                        var mergedBuffers = (this as PersistedReader).HeaderBuffer.Concat((this as PersistedReader).Buffer).ToArray();
                        var buffer = new byte[mergedBuffers.Length];
                        Array.Copy(mergedBuffers, offset, buffer, 0, buffer.Length - offset);

                        using (PersistedReader reader = new PersistedReader((this as PersistedReader).HeaderBuffer, buffer))
                            Sb.Append(reader.ReadDomainName());
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        try
                        {
                            var buffer = new byte[(this as PersistedReader).Buffer.Length - offset];
                            Array.Copy((this as PersistedReader).Buffer, 0, buffer, 0, buffer.Length);

                            using (CustomReader reader = new CustomReader(buffer))
                                Sb.Append(reader.ReadDomainName());
                        }
                        catch (Exception ex2)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(ex2.Message);
                            Console.ResetColor();
                        }
                    }
                    break;
                }

                //No compressions
                while (strLength > 0)
                {
                    Sb.Append(ReadChar());
                    strLength--;
                }

                Sb.Append('.');
            }
            if (Sb.Length == 0)
                return ".";

            var domainName = Sb.ToString();

            if (!domainName.EndsWith("."))
                domainName += ".";

            return Sb.ToString();
        }
    }
}
