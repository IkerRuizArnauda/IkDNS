using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RTKEY : BaseRecord
	{
		public string Algo { get; set; }
		public uint Inception { get; set; }
		public uint Expiration { get; set; }
		public ushort Mode { get; set; }
		public ushort EResourceRecordOR { get; set; }
		public ushort KeySize { get; set; }
		public byte[] KeyData { get; set; }
		public ushort PayloadLength { get; set; }
		public byte[] PayloadData { get; set; }

		public RTKEY(PersistedReader reader)
		{
			Algo = reader.ReadDomainName();
			Inception = reader.ReadUInt16();
			Expiration = reader.ReadUInt16();
			Mode = reader.ReadUInt16();
			EResourceRecordOR = reader.ReadUInt16();
			KeySize = reader.ReadUInt16();
			KeyData = reader.ReadBytes(KeySize);
			PayloadLength = reader.ReadUInt16();
			PayloadData = reader.ReadBytes(PayloadLength);
		}
	}
}
