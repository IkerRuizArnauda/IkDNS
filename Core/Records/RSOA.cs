using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RSOA : BaseRecord
	{
		public string MName { get; set; }
		public string RName { get; set; }
		public uint Serial { get; set; }
		public uint Refresh { get; set; }
		public uint Retry { get; set; }
		public uint Expire { get; set; }
		public uint Minimum { get; set; }

		public RSOA(PersistedReader reader)
		{
			MName = reader.ReadDomainName();
			RName = reader.ReadDomainName();
			Serial = reader.ReadUInt16();
			Refresh = reader.ReadUInt16();
			Retry = reader.ReadUInt16();
			Expire = reader.ReadUInt16();
			Minimum = reader.ReadUInt16();
		}
	}
}
