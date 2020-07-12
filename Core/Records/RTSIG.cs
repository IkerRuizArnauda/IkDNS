using IkDNS.Core.Reader;

namespace IkDNS.Core
{
    public class RTSIG : BaseRecord
    {
        public string AlgoName { get; set; }
        public long TimeSIgned { get; set; }
        public ushort Fudge { get; set; }
        public ushort MacSize { get; set; }
        public byte[] Mac { get; set; }
        public ushort OriginalID { get; set; }
        public ushort EResourceRecordOR { get; set; }
        public ushort PayloadLength { get; set; }
        public byte[] PayloadData { get; set; }

        public RTSIG(PersistedReader reader)
        {
            AlgoName = reader.ReadDomainName();
            TimeSIgned = reader.ReadUInt16() << 32 | reader.ReadUInt16();
            Fudge = reader.ReadUInt16();
            MacSize = reader.ReadUInt16();
            Mac = reader.ReadBytes(MacSize);
            OriginalID = reader.ReadUInt16();
            EResourceRecordOR = reader.ReadUInt16();
            PayloadLength = reader.ReadUInt16();
            PayloadData = reader.ReadBytes(PayloadLength);
        }
    }
}
