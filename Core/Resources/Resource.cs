using IkDNS.Core.Reader;

namespace IkDNS.Core.Resources
{
    public class Resource
    {
		public string Name { get; set; }
    	public Type Type { get; set; }
		public Class Class { get; set; }
		public uint TTL { get; set; }
		public ushort Length { get; set; }
		public BaseRecord RECORD { get; set; }
		public int TimeLived { get; set; }

		public Resource(PersistedReader reader)
        {
            Name = reader.ReadDomainName();
            Type = (Type)reader.ReadUInt16();
            Class = (Class)reader.ReadUInt16();
            TTL = reader.ReadUInt32();
            Length = reader.ReadUInt16();
            RECORD = ReadRecord(reader, Type, Length);
        }

		public BaseRecord ReadRecord(PersistedReader pReader, Type type, int len)
		{
			switch (type)
			{
				case Type.A:
					return new RA(pReader);
				case Type.NS:
					return new RNS(pReader);
				case Type.CNAME:
					return new RCNAME(pReader);
				case Type.SOA:
					return new RSOA(pReader);
				case Type.MB:
					return new RMB(pReader);
				case Type.MG:
					return new RMG(pReader);
				case Type.MR:
					return new RMR(pReader);
				case Type.NULL:
					return new RNULL(pReader);
				case Type.WKS:
					return new RWKS(pReader);
				case Type.PTR:
					return new RPTR(pReader);
				case Type.HINFO:
					return new RHINFO(pReader);
				case Type.MINFO:
					return new RMINFO(pReader);
				case Type.MX:
					return new RMX(pReader);
				case Type.TXT:
					return new RTXT(pReader, len);
				case Type.RP:
					return new RRP(pReader);
				case Type.AFSDB:
					return new RAFSDB(pReader);
				case Type.X25:
					return new RX25(pReader);
				case Type.ISDN:
					return new RISDN(pReader);
				case Type.RT:
					return new RRT(pReader);
				case Type.NSAP:
					return new RNSAP(pReader);
				case Type.SIG:
					return new RSIG(pReader);
				case Type.KEY:
					return new RKEY(pReader);
				case Type.PX:
					return new RPX(pReader);
				case Type.AAAA:
					return new RAAAA(pReader);
				case Type.LOC:
					return new RLOC(pReader);
				case Type.SRV:
					return new RSRV(pReader);
				case Type.NAPTR:
					return new RNAPTR(pReader);
				case Type.KX:
					return new RKX(pReader);
				case Type.DNAME:
					return new RDNAME(pReader);
				case Type.DS:
					return new RDS(pReader);
				case Type.TKEY:
					return new RTKEY(pReader);
				case Type.TSIG:
					return new RTSIG(pReader);
				default:
					return new RUnknown(pReader);
			}
		}
	}
}
