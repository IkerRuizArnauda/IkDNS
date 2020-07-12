using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RMG : BaseRecord
	{
		public string MgmName { get; set; }

		public RMG(PersistedReader reader)
		{
			MgmName = reader.ReadDomainName();
		}
	}
}
