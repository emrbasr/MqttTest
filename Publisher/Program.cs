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
            PublishUser user = new PublishUser();
            user.Start();
        }

       
    }
}
