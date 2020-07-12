using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RMR : BaseRecord
	{
		public string NewName { get; set; }

		public RMR(PersistedReader reader)
		{
			NewName = reader.ReadDomainName();
		}
	}
}
