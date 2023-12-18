using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;


// Хранение сообщений
namespace My_Messanger
{
    [Serializable] // Подключение сриализации для преобразовании объекта в поток байтов для передачи. Необходим публичый класс
    public class Message

    { 
        // Три поля Сообщения (имя, текс, время отправки):
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }
     


        // Конструктор
        public Message(DateTime timeStamp, string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStamp = timeStamp;
        }


        //Конструктор
        public Message()
        {
            UserName = "System";
            MessageText = "Servis is running...";
            TimeStamp = DateTime.Now;
        }

        // Переопределение выходного текста
        public override string ToString()
        {
            string output = String.Format("{0} <{2}>: {1}", UserName, MessageText, TimeStamp);
            return output;
        }
    }
}
