namespace IkDNS.Core.Reader
{
    public class Question
    {
        public Type QType { get; set; }
        public Class QClass { get; set; }
        public string QName { get; set; }

        public Question(PersistedReader reader)
        {
            QName = reader.ReadDomainName();
            QType = (Type)reader.ReadUInt16();
            QClass = (Class)reader.ReadUInt16();
        }
    }
}
