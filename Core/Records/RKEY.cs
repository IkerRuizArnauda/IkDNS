using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RKEY : BaseRecord
	{
		public ushort Flags { get; set; }
		public byte Protocol { get; set; }
		public byte Algo { get; set; }
		public string PKey { get; set; }

		public RKEY(PersistedReader reader)
		{
			Flags = reader.ReadUInt16();
			Protocol = reader.ReadByte();
			Algo = reader.ReadByte();
			PKey = reader.ReadString();
		}
	}
}
