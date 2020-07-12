using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RMB : BaseRecord
	{
		public string MadName { get; set; }

		public RMB(PersistedReader reader)
		{
			MadName = reader.ReadDomainName();
		}
	}
}
