using IkDNS.Core.Reader;

namespace IkDNS.Core
{
    public class RSIG : BaseRecord
    {
        public ushort TypeCovered { get; set; }
        public byte Algo { get; set; }
        public byte Labels { get; set; }
        public uint TTL { get; set; }
        public uint SigExpiration { get; set; }
        public uint SigInception { get; set; }
        public ushort KeyTag { get; set; }
        public string SigName { get; set; }
        public string Sig { get; set; }

        public RSIG(PersistedReader reader)
        {
            TypeCovered = reader.ReadUInt16();
            Algo = reader.ReadByte();
            Labels = reader.ReadByte();
            TTL = reader.ReadUInt16();
            SigExpiration = reader.ReadUInt16();
            SigInception = reader.ReadUInt16();
            KeyTag = reader.ReadUInt16();
            SigName = reader.ReadDomainName();
            Sig = reader.ReadString();
        }
    }
}
