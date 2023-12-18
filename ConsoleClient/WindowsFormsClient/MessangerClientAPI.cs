using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using My_Messanger;
using System.IO;
using System.Net.Http;
using RestSharp;

namespace My_Messanger
{
    internal class MessangerClientAPI
    {
        private static readonly HttpClient client = new HttpClient();

         public void TestNewtonsoftJson()
        {
            // тест Json SerializeObject NewtonSoft
            Message msg = new Message(DateTime.UtcNow, "Nameless027", "Privet");
            string output = JsonConvert.SerializeObject(msg);
            Console.WriteLine(output);

            Message deserializedMsg = JsonConvert.DeserializeObject<Message>(output);
            Console.WriteLine(deserializedMsg);


            /*string path = @"d:\tmp\ser.txt";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default)) 
            {
                sw.WriteLine(output);
            }
            */
        }
        public Message GetMessage(int MessageId) // запрос сообщения
        {
            WebRequest request = WebRequest.Create("http://localHost:5063/api/Messanger/" + MessageId.ToString()); // отправляет запрос, ередает значение на сервер
            request.Method = "Get"; // тип запроса
            WebResponse respones = request.GetResponse(); // выполнение запроса, запись ответа в respones
            string status = ((HttpWebResponse)respones).StatusDescription; // считывание статуса
            //Console.WriteLine(status);
            Stream dataStream = respones.GetResponseStream(); // открытие потока
            StreamReader reader = new StreamReader(dataStream); // открытие потока
            string responseFromServer = reader.ReadToEnd(); // хранение то что считало до конца потока
            //Console.WriteLine(reesponseFromServer);
            reader.Close(); // закрытие всех потоков
            dataStream.Close();
            respones.Close();
            if ((status.ToLower() == "ok") && (responseFromServer != "Not found")) // провека статуса
            {
                Message deserializedMsg = JsonConvert.DeserializeObject<Message>(responseFromServer); //десериализация объекта, который пришел
                //Console.WriteLine(deserializeddMsg);
                return deserializedMsg; // возвращение объкта
            }
            return null;

        }





       
        public async Task <Message> GetMessageAsync (int MessageId)
        {
            var responseString = await client.GetStringAsync("http://localhost:5063/api/Messanger");
            if(responseString != null)
            {
                Message deserializedMSG = JsonConvert.DeserializeObject<Message>(responseString);
                return deserializedMSG;
            }
            return null;
        }

        public bool SendMessage(Message msg) // отправка сообщения 
        {
            WebRequest request = WebRequest.Create("http://localhost:5063/api/Messanger"); //запрос
            request.Method= "POST";  //тип запроса
            //Message msg = new Message ("Name", "Privet", DateTime.Now);   
            string postData = JsonConvert.SerializeObject(msg); // записываем свое сообщение в postData
            byte[] byteArray = Encoding.UTF8.GetBytes(postData); // перекодировка сообщения в байты
            request.ContentType = "application/json"; // взапросе указываем application/json формат
            request.ContentLength = byteArray.Length; // длина тела запроса который будет отправляться
            Stream dataStream = request.GetRequestStream(); // запись всего в request
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse(); // отлавливается ответ
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd(); // чтение ответа
            //Console.WriteLine(responseFromServer);
            reader.Close(); // закрытие всех потоков
            dataStream.Close();
            response.Close();
            return true;
        }

        internal Task<Message> GetNessageHTTPAsync(int messageID)
        {
            throw new NotImplementedException();
        }

        internal Task<Message> GetMessageHTTPAsync(int messageID)
        {
            throw new NotImplementedException();
        }
    }
}
