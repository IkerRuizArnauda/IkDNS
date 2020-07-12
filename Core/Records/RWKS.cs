using IkDNS.Core.Reader;

namespace IkDNS.Core
{
    public class RWKS : BaseRecord
    {
        public string Address { get; set; }
        public int Protocol { get; set; }
        public byte[] Bitmap { get; set; }

        public RWKS(PersistedReader reader)
        {
            reader.BaseStream.Position -= 2;
            ushort length = reader.ReadUInt16();
            Address = string.Format("{0}.{1}.{2}.{3}",
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte());
            Protocol = (int)reader.ReadByte();
            length -= 5;
            Bitmap = new byte[length];
            Bitmap = reader.ReadBytes(length);
        }
    }
}
