using System.Text;
using System.Text.Json;
using K123ShopApp.Entities.SharedModels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

ConnectionFactory factory = new ConnectionFactory();
factory.Uri = new Uri("amqp://guest:guest@localhost");

using (IConnection connection = factory.CreateConnection())
using (IModel channel = connection.CreateModel())
{
    channel.QueueDeclare("register-user-command", false, false, true);
    EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
    channel.BasicConsume("register-user-command", false, consumer);
    consumer.Received += (sender, e) =>
    {
        var message = JsonSerializer.Deserialize<SendEmailCommand>(Encoding.UTF8.GetString(e.Body.ToArray()));

        Data(message);

    };
}



Console.WriteLine("Salam");

void Data(SendEmailCommand message) {


    Console.WriteLine(message.Email);
    Console.WriteLine(message.FirstName);
    Console.WriteLine(message.LastName);
    Console.WriteLine(message.Token);
}
Console.Read();