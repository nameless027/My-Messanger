
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