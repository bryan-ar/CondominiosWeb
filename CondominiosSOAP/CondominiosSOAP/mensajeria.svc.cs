using CondominiosSOAP.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace CondominiosSOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class mensajeria : IMensajeria
    {
        private const string _hostname = "beaver.rmq.cloudamqp.com";
        private const string _username = "ccabwqfw";
        private const string _password = "c8swW-nBj4k4mpyGj8mhy0ZLrsvXfnnT";
        private const string _queuename = "jrodriguezupc";

        public string RegistrarReserva(Reserva reserva)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password,
                VirtualHost = _username
            };
            

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queuename,durable: false,exclusive: false,autoDelete: false,arguments: null);

                JavaScriptSerializer js = new JavaScriptSerializer();
                string jsonData = js.Serialize(reserva);

                var body = Encoding.UTF8.GetBytes(jsonData);

                channel.BasicPublish(exchange: "",routingKey: _queuename,basicProperties: null,body: body);
            }

            return "Los datos fueron enviados a RabbitMQ correctamente";
        }
    }
}
