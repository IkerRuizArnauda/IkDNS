using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RUnknown : BaseRecord
	{
		public byte[] Data { get; set; }
		public RUnknown(PersistedReader reader)
		{
			reader.BaseStream.Position -= 2;
			Data = reader.ReadBytes(reader.ReadUInt16());
		}
	}
}
