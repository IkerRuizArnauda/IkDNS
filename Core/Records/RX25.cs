using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RX25 : BaseRecord
	{
		public string PsdnAddress { get; private set; }

		public RX25(PersistedReader reader)
		{
			PsdnAddress = reader.ReadString();
		}
	}
}
