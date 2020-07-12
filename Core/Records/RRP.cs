using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RRP : BaseRecord
	{
		public string MboxdName { get; set; }
		public string TxtdName { get; set; }

		public RRP(PersistedReader reader)
		{
			MboxdName = reader.ReadDomainName();
			TxtdName = reader.ReadDomainName();
		}
	}
}
