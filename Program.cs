using System;
using IkDNS.Core;

namespace IkDNS
{
    class Program
    {
        public static void Main(string[] args)
        {
            using (Server server = new Server())
            {
                server.StartServer();
                Console.ReadLine();
            }
        }
    }
}
