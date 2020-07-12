using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RAFSDB : BaseRecord
	{
		public ushort SubType { get; set; }
		public string HostName { get; set; }

		public RAFSDB(PersistedReader reader)
		{
			SubType = reader.ReadUInt16();
			HostName = reader.ReadDomainName();
		}
	}
}
