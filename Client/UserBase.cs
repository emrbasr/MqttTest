using uPLibrary.Networking.M2Mqtt;
namespace Client
{
    public class UserBase
    {

        MqttClient qwe = new MqttClient("localhost");


        //MqttClient mqttClient = new MqttClient("localhost");
        //mqttClient.MqttMsgPublishReceived += client_recievedMessage;


        //    string clientId = Guid.NewGuid().ToString();
        //mqttClient.Connect(clientId);

        //void client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        //{
        //    var message1 = System.Text.Encoding.Default.GetString(e.Message);
        //    System.Console.WriteLine("Publish Mesaj:  " + message1);
        //}

    }


}
