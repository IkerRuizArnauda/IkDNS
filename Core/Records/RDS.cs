using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RDS : BaseRecord
	{
		public ushort KeyTag { get; set; }
		public byte Algo { get; set; }
		public byte DigestType { get; set; }
		public byte[] Digest { get; set; }

		public RDS(PersistedReader reader)
		{
			reader.BaseStream.Position -= 2;
			ushort length = reader.ReadUInt16();
			KeyTag = reader.ReadUInt16();
			Algo = reader.ReadByte();
			DigestType = reader.ReadByte();
			length -= 4;
			Digest = new byte[length];
			Digest = reader.ReadBytes(Digest.Length);
		}
	}
}
