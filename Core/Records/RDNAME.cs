using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RDNAME : BaseRecord
	{
		public string Target { get; set; }

		public RDNAME(PersistedReader reader)
		{
			Target = reader.ReadDomainName();
		}
	}
}
