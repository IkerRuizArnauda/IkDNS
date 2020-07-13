using System;
using System.Linq;
using System.Collections.Generic;

using IkDNS.Core.Reader;

namespace IkDNS.Core.Resources
{
	public class Request : IDisposable
	{
		public Header Header { get; private set; }
		public List<Question> Questions { get; private set; } = new List<Question>();

		public Request(byte[] data)
		{
			Header = new Header(data);

			using (PersistedReader reader = new PersistedReader(Header.Buffer, Header.Payload))
			{
				for (int i = 0; i < Header.QuestionCount; i++)
					Questions.Add(new Question(reader));
			}
		}

		public byte[] ByteArray => Header.Buffer.Concat(Header.Payload).ToArray();

		public void Dispose()
		{
				Questions.Clear();
				Questions = null;
				Header?.Dispose();
		}
    	}
}
