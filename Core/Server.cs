using System;
using System.Net;
using System.Net.Sockets;

using IniParser;
using IkDNS.Core.Helpers;
using IkDNS.Core.Resources;

namespace IkDNS.Core
{
    public class Server : IDisposable
    {
        /// <summary>
        /// This socket will listen to the client dns requests on udp 53
        /// </summary>
        Socket LocalListener = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        /// <summary>
        /// The socket will send the actual request to the real dns server
        /// </summary>
        Socket RemoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        /// <summary>
        /// Usually 12 bytes for header, 500 for payload. (On 1 question scenarios)
        /// </summary>
        byte[] LocalBuffer = new byte[512];

        /// <summary>
        /// Stop flag
        /// </summary>
        private static volatile bool Stop = false;

        public void StartServer()
        {
            try
            {
                var _endPointReference = (EndPoint)new IPEndPoint(IPAddress.Any, 53);             
                LocalListener.Bind(_endPointReference);

                var parser = new FileIniDataParser();
                var initData = parser.ReadFile($"{AppDomain.CurrentDomain.BaseDirectory}{@"\Configuration.ini"}");
                var realDns = IPAddress.Parse(initData["IKDNS"]["DNSIP"]);
                
                RemoteSocket.Connect(realDns, 53);
                LocalListener.BeginReceiveMessageFrom(LocalBuffer, 0, LocalBuffer.Length, 0, ref _endPointReference, Receive, LocalListener);
            }
            catch (Exception ex)
            {
                NonBlockingConsole.WriteLine(ex.Message);
            }
        }

        
        private void Receive(IAsyncResult ar)
        {
            if(ar.AsyncState is Socket socket)
            {
                var _endPointReference = (EndPoint)new IPEndPoint(IPAddress.Any, 53);
                try
                {
                    SocketFlags flags = SocketFlags.None;
                    var rec = socket.EndReceiveMessageFrom(ar, ref flags, ref _endPointReference, out IPPacketInformation packetInfo);

                    byte[] clientToUsBuffer = new byte[512];
                    Array.Copy(LocalBuffer, clientToUsBuffer, rec);

                    //If you wish to inject the request, do so inside Questions parsing.
                    using (Request req = new Request(clientToUsBuffer))
                    {
                       foreach (var question in req.Questions)
                            NonBlockingConsole.WriteLine($"Request: Type {question.QType} Class {question.QClass} Name {question.QName}");

                        RemoteSocket.Send(req.ByteArray);
                    }

                    byte[] remoteToUsBuffer = new byte[512];
                    RemoteSocket.Receive(remoteToUsBuffer);

                    //If you wish to inject the response, do so inside Resource parsing.
                    using (Response resp = new Response(remoteToUsBuffer))
                    {
                        foreach (var answer in resp.Answers)
                            NonBlockingConsole.WriteLine($"Answer Response: Type {answer.Type} Class {answer.Class} Record {answer.RECORD} Name {answer.Name}");

                        foreach (var att in resp.Authorities)
                            NonBlockingConsole.WriteLine($"Authorities Response: Type {att.Type} Class {att.Class} Record {att.RECORD} Name {att.Name}");

                        foreach (var att in resp.Additionals)
                            NonBlockingConsole.WriteLine($"Additionals Response: Type {att.Type} Class {att.Class} Record {att.RECORD} Name {att.Name}");

                        using (Socket c = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
                        {
                            c.Connect(_endPointReference);
                            c.Send(resp.ByteArray);
                        }
                    }
                }
                catch (Exception ex)
                {
                    NonBlockingConsole.WriteLine(ex.Message);
                }

                if(!Stop)
                    socket.BeginReceiveMessageFrom(LocalBuffer, 0, LocalBuffer.Length, 0, ref _endPointReference, Receive, socket);
            }       
        }

        public void Dispose()
        {
            Stop = true;
            try { LocalListener.Shutdown(SocketShutdown.Both); } catch { }
            try { LocalListener?.Dispose(); } catch { }
            try { RemoteSocket.Shutdown(SocketShutdown.Both); } catch { }
            try { RemoteSocket?.Dispose(); } catch { }
        }
    }
}
