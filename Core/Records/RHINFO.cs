using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RHINFO : BaseRecord
	{
		public string Cpu { get; set; }
		public string OS { get; set; }

		public RHINFO(PersistedReader reader)
		{
			Cpu = reader.ReadString();
			OS = reader.ReadString();
		}
	}
}
