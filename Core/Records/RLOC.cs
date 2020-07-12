using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RLOC : BaseRecord
	{
		public byte Version { get; set; }
		public byte Size { get; set; }
		public byte HPreference { get; set; }
		public byte VPreference { get; set; }
		public uint Latitude { get; set; }
		public uint Longitude { get; set; }
		public uint Altitude { get; set; }

		public RLOC(PersistedReader reader)
		{
			Version = reader.ReadByte(); // must be 0!
			Size = reader.ReadByte();
			HPreference = reader.ReadByte();
			VPreference = reader.ReadByte();
			Latitude = reader.ReadUInt16();
			Longitude = reader.ReadUInt16();
			Altitude = reader.ReadUInt16();
		}
	}
}
