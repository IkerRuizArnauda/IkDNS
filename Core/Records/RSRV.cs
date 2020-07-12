using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RSRV : BaseRecord
	{
		public ushort Priority { get; set; }
		public ushort Weigth { get; set; }
		public ushort Port { get; set; }
		public string Target { get; set; }

		public RSRV(PersistedReader reader)
		{
			Priority = reader.ReadUInt16();
			Weigth = reader.ReadUInt16();
			Port = reader.ReadUInt16();
			Target = reader.ReadDomainName();
		}
	}
}
