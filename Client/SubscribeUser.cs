﻿using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Client
{

    public class SubscribeUser
    {
        private MqttClient mqttClient = new MqttClient("broker.hivemq.com");
        public SubscribeUser()
        {
            mqttClient.MqttMsgPublishReceived += client_recievedMessage;
            string clientId = Guid.NewGuid().ToString();
            mqttClient.Connect(clientId);

        }

        public void Start()
        {
            string Topic = "";

            Console.WriteLine("Subscribe Screen");


        back:
            Console.WriteLine("1- NodeServer");
            Console.WriteLine("2- NodeCliend");
            Console.WriteLine("3 - Exit");
            Console.WriteLine("** - Main Page");

            do
            {


                Topic = Console.ReadLine();


                if (Topic == "1")
                {
                    mqttClient.Subscribe(new String[] { Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

                }

                else if (Topic == "2")
                {
                    while (Topic != "**")
                    {
                        Console.WriteLine("Send Message: ");

                        string message = Console.ReadLine();

                        if (message == "**")
                        {
                            goto back;
                        }

                        mqttClient.Publish(Topic, Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);


                    }

                }

                else if (Topic == "**")
                {
                    goto back;
                }

            } while (Topic != "3");
        }

        static void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            var message1 = System.Text.Encoding.Default.GetString(e.Message);
            System.Console.WriteLine("Publish Message:  " + message1);
        }
    }

}
