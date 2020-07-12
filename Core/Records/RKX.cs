using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RKX : BaseRecord
	{
		public ushort Preference { get; set; }
		public string Exchanger { get; set; }

		public RKX(PersistedReader reader)
		{
			Preference = reader.ReadUInt16();
			Exchanger = reader.ReadDomainName();
		}
	}
}
