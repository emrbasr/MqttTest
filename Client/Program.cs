using System;
using System.Text;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SubscribeUser cliend = new SubscribeUser();
            cliend.Start();

        }
    }
}
