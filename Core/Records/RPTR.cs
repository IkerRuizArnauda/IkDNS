using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RPTR : BaseRecord
	{
		public string PtrdName { get; set; }

		public RPTR(PersistedReader reader)
		{
			PtrdName = reader.ReadDomainName();
		}
	}
}
