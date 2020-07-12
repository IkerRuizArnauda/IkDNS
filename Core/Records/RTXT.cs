using IkDNS.Core.Reader;
using System.Collections.Generic;

namespace IkDNS.Core
{
	public class RTXT : BaseRecord
	{
		public List<string> Txt { get; set; } = new List<string>();

		public RTXT(PersistedReader reader, int len)
		{
			long pos = reader.BaseStream.Position;

			while ((reader.BaseStream.Position - pos) < len)
				Txt.Add(reader.ReadString());
		}
	}
}
