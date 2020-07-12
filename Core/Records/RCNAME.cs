using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RCNAME : BaseRecord
	{
		public string CName { get; set; }

		public RCNAME(PersistedReader reader)
		{
			CName = reader.ReadDomainName();
		}
	}
}
