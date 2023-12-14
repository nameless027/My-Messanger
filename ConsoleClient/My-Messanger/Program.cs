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


           

        }
    }
}                                                                                                                              