namespace IkDNS.Core.Resources
{
    public enum OPCode
    {
        Query =                 0x00, // Normal query
        IQUERY =                0x01, // Reverse query
        Status =                0x02, // Status request
        Reserved3 =             0x03,
        Notify =                0x04,
        Update =                0x05,
        Reserved6 =             0x06,
        Reserved7 =             0x07,
        Reserved8 =             0x08,
        Reserved9 =             0x09,
        Reserved10 =            0x0A,
        Reserved11 =            0x0B,
        Reserved12 =            0x0C,
        Reserved13 =            0x0D,
        Reserved14 =            0x0E,
        Reserved15 =            0x0F,
    }

    public enum Type : ushort
    {
        A                       = 0x01,  // IPV4
        NS                      = 0x02,  // Authoritative NS
        MD                      = 0x03,  // Mail
        MF                      = 0x04,  // Mail fwd
        CNAME                   = 0x05,  // Canonical name
        SOA                     = 0x06,  // ZOA
        MB                      = 0x07,  // Mail domain
        MG                      = 0x08,  // Mail group
        MR                      = 0x09,  // Mail rename
        NULL                    = 0x0A,  //
        WKS                     = 0x0B,  // Well known service
        PTR                     = 0x0C,  // Domain points
        HINFO                   = 0x0D,  // Host info
        MINFO                   = 0x0E,  // Mail info
        MX                      = 0x0F,  // Mail exchange
        TXT                     = 0x10,  // String
        RP                      = 0x11,  // Responsible Person
        AFSDB                   = 0x12,  // AFS Data Base
        X25                     = 0x13,  // X25 address
        ISDN                    = 0x14,  // ISDN address
        RT                      = 0x15,  // Route Through
        NSAP                    = 0x16,  // Network access point
        NSAPPTR                 = 0x17,  // Network Access point reverse
        SIG                     = 0x18,  // Signature record
        KEY                     = 0x19,  // DNSSEC
        PX                      = 0x1A,  // Pointer for X400
        GPOS                    = 0x1B,  // Geographical position record
        AAAA                    = 0x1C,  // IPv6 address record
        LOC                     = 0x1D,  // Location resource record
        NXT                     = 0x1E,  // Next domain
        EID                     = 0x1F,  // Endpoint
        NIMLOC                  = 0x20,  // Nimrod locator
        SRV                     = 0x21,  // Service record
        ATMA                    = 0x22,  // Async transfer
        NAPTR                   = 0x23,  // String translation
        KX                      = 0x24,  // Key exchange record
        CERT                    = 0x25,  // CERT record
        A6                      = 0x26,  // IPv6 address or portion
        DNAME                   = 0x27,  // Alias domain
        SINK                    = 0x28,  //
        OPT                     = 0x29,  // Additional
        APL                     = 0x2A,  // Address prefix record
        DS                      = 0x2B,  // Delegation signer
        SSHFP                   = 0x2C,  // SSH fingerprint
        IPSECKEY                = 0x2D,  // Key for given dns
        RRSIG                   = 0x2E,  //
        NSEC                    = 0x2F,  // Next secure record
        DNSKEY                  = 0x30,  // DNSSEC
        DHCID                   = 0x31,  // Client id dns dhcp
        NSEC3                   = 0x32,  //
        NSEC3PARAM              = 0x33,  //
        SMIMEA                  = 0x35,  // S/MIME cert
        HIP                     = 0x37,  // Host Identity protocol
        OPENPGPKEY              = 0x3D,  // OpenPGP public key
        CSYNC                   = 0x3E,  // Child to parent
        ZONEMD                  = 0x3F,  // Pending rfc
        SPF                     = 0x63,  // Sender policy framework
        UINFO                   = 0x64,  // Reserved
        UID                     = 0x65,  // Reserved
        GID                     = 0x66,  // Reserved
        UNSPEC                  = 0x67,  // Reserved
        TKEY                    = 0xF9,  // Transaction key record
        TSIG                    = 0xFA,  // Transaction signature
        CAA                     = 0x101, // Certification authority authorization
        TA                      = 0x8000,// DNSSEC 
        DLV                     = 0x8001,// DNSSEC
    }

    public enum Class : ushort
    {
        IN                      = 0x01, // INTERNET
        CS                      = 0x02, // CSNET
        CH                      = 0x03, // CHAOS
        HS                      = 0x04, // HESIOD
        Unknown                 = 0xFF,
    }

    public enum RCode
    {
        NoError                 = 0x00, // No error
        FormErr                 = 0x01, // Format error
        ServFail                = 0x02, // Server failure
        NXDomain                = 0x03, // Nonexistent domain
        NotImp                  = 0x04, // Not implemented
        Refused                 = 0x05, // Query refused
        YXDomain                = 0x06, // YXDomain
        YXRRSet                 = 0x07, // YXRRSet
        NXRRSet                 = 0x08, // NXRRSet
        NotAuth                 = 0x09, // NotAuth
        NotZone                 = 0x0A, // Uknown to zone
        Reserved11              = 0x0B, // Reserved
        Reserved12              = 0x0C, // Reserved
        Reserved13              = 0x0D, // Reserved
        Reserved14              = 0x0E, // Reserved
        Reserved15              = 0x0F, // Reserved
        BadVerSig               = 0x10, // Bad version
        BadKey                  = 0x11, // Key not recognized
        BadTime                 = 0x12, // Signature out of time window
        BadMode                 = 0x13, // Bad mode
        BadName                 = 0x14, // Duplicate name
        BadAlg                  = 0x15, // Bad algorithm
        BadTrunc                = 0x16, // Bad truncation
    }
}
