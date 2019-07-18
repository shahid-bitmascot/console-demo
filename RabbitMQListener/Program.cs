using System;

namespace RabbitMQListener
{
    class Program
    {
        static void Main(string[] args)
        {
            new RabbitMQReceiver().Listen();
        }
    }
}
