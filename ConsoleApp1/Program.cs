using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new RabbitMQRSender();
            while (true)
            {
                var message = Console.ReadLine();
                sender.Send(Thread.CurrentThread.ManagedThreadId + " Send Data: " + message);
            }

        }
    }
}
