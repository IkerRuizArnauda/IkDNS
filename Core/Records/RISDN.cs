using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RISDN : BaseRecord
	{
		public string IsdnAddress { get; set; }
		public string SA { get; set; }

		public RISDN(PersistedReader reader)
		{
			IsdnAddress = reader.ReadString();
			SA = reader.ReadString();
		}
	}
}
