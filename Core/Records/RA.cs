using System.Net;
using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RA : BaseRecord
	{
		public IPAddress Address { get; set; }

		public RA(PersistedReader reader)
		{
			Address = new IPAddress(reader.ReadBytes(4));
		}
	}
}
