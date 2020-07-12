using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RMINFO : BaseRecord
	{
		public string MailBox { get; set; }
		public string MailBx { get; set; }

		public RMINFO(PersistedReader reader)
		{
			MailBox = reader.ReadDomainName();
			MailBx = reader.ReadDomainName();
		}
	}
}
