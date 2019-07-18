using RabbitMQ.Client;
using System.Text;

namespace ConsoleApp1
{
    public class RabbitMQRSender
    {

        public void Send(string message)
        {

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message ?? string.Empty);

                channel.ExchangeDeclare(exchange: "logs", type: "fanout");
                channel.QueueBind(queue: "hello", exchange: "logs", routingKey: "route");

                channel.BasicPublish(exchange: "logs",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body);
            }

        }
    }
}
