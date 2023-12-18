
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;





namespace My_Messanger
{
    class Program
    {
        private static int MessageID;
        private static string UserName;
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static void GetNewMessage()
        {
            Message msg = API.GetMessage(MessageID);
            while (msg != null)
            {
                Console.WriteLine(msg);
                MessageID++;
                msg = API.GetMessage(MessageID);
            }
        }
        static void Main(string[] agrs)
        {

            /*Message msg = new Message("Nameless027", "Privet", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);
            { "UserName":"Nameless027","MessageText":"Privet","TimeStamp":"2023-12-15T12:12:46.4395632+03:00"}
            */

            MessageID = 1;
            Console.WriteLine("ВВедите Ваше имя :");
            UserName = Console.ReadLine();
            string MessageText = "";
            while (MessageText != "exit")
            {
                GetNewMessage();
                MessageText = Console.ReadLine();
                if (MessageText.Length > 1)
                {
                    Message Sendmsg = new Message(DateTime.Now, UserName, MessageText);
                    API.SendMessage(Sendmsg);
                }
            }




        }
    }
}                                                                                                                              