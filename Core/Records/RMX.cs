using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RMX : BaseRecord
	{
		public ushort Preference { get; set; }
		public string Exchange { get; set; }

		public RMX(PersistedReader reader)
		{
			Preference = reader.ReadUInt16();
			Exchange = reader.ReadDomainName();
		}
	}
}
