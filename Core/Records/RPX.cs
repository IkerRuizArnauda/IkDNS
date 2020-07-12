using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RPX : BaseRecord
	{
		public ushort Preference { get; set; }
		public string Map822 { get; set; }
		public string MapX400 { get; set; }

		public RPX(PersistedReader reader)
		{
			Preference = reader.ReadUInt16();
			Map822 = reader.ReadDomainName();
			MapX400 = reader.ReadDomainName();
		}
	}
}
