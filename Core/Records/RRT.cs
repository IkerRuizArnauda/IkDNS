using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RRT : BaseRecord
	{
		public ushort Preference { get; set; }
		public string InterHost { get; set; }

		public RRT(PersistedReader reader)
		{
			Preference = reader.ReadUInt16();
			InterHost = reader.ReadDomainName();
		}
	}
}
