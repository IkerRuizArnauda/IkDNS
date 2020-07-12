using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RNS : BaseRecord
	{
		public string NsdName { get; set; }

		public RNS(PersistedReader reader)
		{
			NsdName = reader.ReadDomainName();
		}
	}
}
