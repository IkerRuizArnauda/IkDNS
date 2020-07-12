using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RNULL : BaseRecord
	{
		public byte[] Buffer { get; set; }

		public RNULL(PersistedReader reader)
		{
			reader.BaseStream.Position -= 2;
			ushort length = reader.ReadUInt16();
			Buffer = new byte[length];
			Buffer = reader.ReadBytes(Buffer.Length);
		}
	}
}
