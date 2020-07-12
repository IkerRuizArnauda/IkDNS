using System.Net;
using IkDNS.Core.Reader;

namespace IkDNS.Core
{
    public class RAAAA : BaseRecord
    {
        public IPAddress Address { get; set; }

        public RAAAA(PersistedReader reader)
        {
            if (IPAddress.TryParse(string.Format("{0:x}:{1:x}:{2:x}:{3:x}:{4:x}:{5:x}:{6:x}:{7:x}",
                reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16(),
                reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16()),
                out IPAddress address))
            {
                this.Address = address;
            }
            else
                Address = IPAddress.Any;
        }

        public override string ToString()
        {
            return Address.ToString();
        }
    }
}
