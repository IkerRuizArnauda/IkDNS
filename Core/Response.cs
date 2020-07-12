using System;
using System.Linq;
using System.Collections.Generic;

using IkDNS.Core.Reader;

namespace IkDNS.Core
{
	public class Response : IDisposable
	{
		public List<Question> Questions { get; set; } = new List<Question>();
		public List<Resource> Answers { get; set; } = new List<Resource>();
		public List<Resource> Authorities { get; set; } = new List<Resource>();
		public List<Resource> Additionals { get; set; } = new List<Resource>();

		public Header Header;
		public string Error;
		public DateTime TimeStamp;

		public Response(byte[] data)
		{
			Error = "";
			TimeStamp = DateTime.Now;

			Header = new Header(data);

			using (PersistedReader reader = new PersistedReader(Header.Buffer, Header.Payload))
			{
				for (int intI = 0; intI < Header.QuestionCount; intI++)
					Questions.Add(new Question(reader));

				for (int intI = 0; intI < Header.AnswersCount; intI++)
					Answers.Add(new Resource(reader));

				for (int intI = 0; intI < Header.AuthorityCount; intI++)
					Authorities.Add(new Resource(reader));

				for (int intI = 0; intI < Header.AdditionalCount; intI++)
					Additionals.Add(new Resource(reader));
			}
		}

		public byte[] ByteArray => Header.Buffer.Concat(Header.Payload).ToArray();

		public void Dispose()
		{
				Questions.Clear();
				Answers.Clear();
				Authorities.Clear();
				Additionals.Clear();

				Questions = null;
				Answers = null;
				Authorities = null;
				Additionals = null;

				Header?.Dispose();
				Error = null;
		}
    	}
}
