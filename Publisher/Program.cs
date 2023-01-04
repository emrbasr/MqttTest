using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MqttClient mqttClient = new MqttClient("localhost");
            string clientId = Guid.NewGuid().ToString();
            mqttClient.MqttMsgPublishReceived += client_recievedMessage;
            mqttClient.Connect(clientId);
            Console.WriteLine("Abone Olundu: test/deneme");


            while (true)
            {
                Console.WriteLine("Mesajı girin: ");

                string message = Console.ReadLine();
                string Topic = "test/deneme";

                mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);
                recievedMessage(mqttClient);
            }
        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            var message1 = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Cliend Mesaj: " + message1);
        }
        static void recievedMessage(MqttClient mqttClient)
        {
            string Topic = "test/deneme";
            mqttClient.Subscribe(new String[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }
    }
}
