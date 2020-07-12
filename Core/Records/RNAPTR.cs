using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RNAPTR : BaseRecord
	{
		public ushort Order { get; set; }
		public ushort Preference { get; set; }
		public string Flags { get; set; }
		public string Services { get; set; }
		public string RegeXp { get; set; }
		public string Replacement { get; set; }

		public RNAPTR(PersistedReader reader)
		{
			Order = reader.ReadUInt16();
			Preference = reader.ReadUInt16();
			Flags = reader.ReadString();
			Services = reader.ReadString();
			RegeXp = reader.ReadString();
			Replacement = reader.ReadDomainName();
		}
	}
}
