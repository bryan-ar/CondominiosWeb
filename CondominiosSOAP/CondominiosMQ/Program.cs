using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CondominiosMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "beaver.rmq.cloudamqp.com",
                UserName = "ccabwqfw",
                Password = "c8swW-nBj4k4mpyGj8mhy0ZLrsvXfnnT",
                VirtualHost = "ccabwqfw"    
            };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "jrodriguezupc", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var data = channel.BasicGet("jrodriguezupc", false);

                if(data != null)
                {
                    var mensaje = Encoding.UTF8.GetString(data.Body.ToArray());

                    Reserva reserva = JsonSerializer.Deserialize<Reserva>(mensaje);
                    RegistrarReserva(reserva);
                }

                channel.BasicAck(data.DeliveryTag, false);
                Console.WriteLine("Presione [ENTER] para salir");
                Console.ReadLine();
            }
        }

        static void RegistrarReserva(Reserva reserva)
        {
            var condominiosDAO = new CondominiosDAO();
            condominiosDAO.RegistrarReserva(reserva);
        }
    }
}
