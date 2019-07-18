using EventStore.ClientAPI;
using System;
using System.Text;

namespace EventStore
{
    class Program
    {
        static void Main(string[] args)
        {

            var conn = EventStoreConnection.Create(new Uri("tcp://admin:changeit@localhost:2113"));
            conn.Connected += Conn_Connected;
            conn.AuthenticationFailed += Conn_AuthenticationFailed;
            conn.Disconnected += Conn_Disconnected;
            conn.ErrorOccurred += Conn_ErrorOccurred;
            conn.Closed += Conn_Closed;
            conn.ConnectAsync().Wait();

            while (true)
            {
                var msg = Console.ReadLine();
                var data = new EventData(Guid.NewGuid(), "logs", false, Encoding.UTF8.GetBytes(msg), null);    
                conn.AppendToStreamAsync("logs", ExpectedVersion.Any, data).Wait();
            }
        }

        private static void Conn_Closed(object sender, ClientClosedEventArgs e)
        {
            //
        }

        private static void Conn_ErrorOccurred(object sender, ClientErrorEventArgs e)
        {
            //
        }

        private static void Conn_Disconnected(object sender, ClientConnectionEventArgs e)
        {
            //
        }

        private static void Conn_AuthenticationFailed(object sender, ClientAuthenticationFailedEventArgs e)
        {
            //
        }

        private static void Conn_Connected(object sender, ClientConnectionEventArgs e)
        {
            //
        }
    }
}
