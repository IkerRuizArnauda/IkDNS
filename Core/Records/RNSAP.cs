using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class RNSAP : BaseRecord
	{
		public ushort Length { get; set; }
		public byte[] NsapAddress { get; set; }

		public RNSAP(PersistedReader reader)
		{
			Length = reader.ReadUInt16();
			NsapAddress = reader.ReadBytes(Length);
		}
	}
}
