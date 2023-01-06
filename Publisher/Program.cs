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
            Console.WriteLine("Publisher Ekrani");

            string Topic = "";



        Don:
            Console.WriteLine("1- NodeServer");
            Console.WriteLine("2- NodeCliend");
            Console.WriteLine("3 - Cikis");
            Console.WriteLine("** - Anasayfa");

            do
            {

                Topic = Console.ReadLine();
                if (Topic == "1")
                {
                    while (Topic != "**")
                    {
                        Console.WriteLine("Mesajı girin: ");

                        string message = Console.ReadLine();

                        if (message == "**")
                        {
                            goto Don;
                        }

                        mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);


                    }

                }


                else if (Topic == "2")
                {
                    mqttClient.Subscribe(new String[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                }


                else if (Topic == "**")
                {
                    goto Don;
                }



            } while (Topic != "3");




        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            var message1 = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Cliend Mesaj: " + message1);
        }

    }
}
