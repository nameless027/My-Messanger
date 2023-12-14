using System;
using Newtonsoft.Json;





namespace My_Messanger
{
    class Program
    {
        static void Main()
        {
            Message msg = new Message("Nameless027", "Privet", DateTime.UtcNow);
            string output = JsonConvert.SerializeObject(msg); 
            Console.WriteLine(output);
            
            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);


            //{ "UserName":"Nameless027","MessageText":"Privet","TimeStamp":"2023-12-13T13:33:56.503903Z"}
            //Nameless027 < 13.12.2023 13:33:56 >: Privet

        }
    }
}                                                                                                                              