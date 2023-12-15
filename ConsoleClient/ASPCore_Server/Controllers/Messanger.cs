using Microsoft.AspNetCore.Mvc;
using My_Messanger;
using System.Net.Http.Json;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCore_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class Messanger : ControllerBase
    {
        // Создание нового текстового сообщения (списковой массива текста)
        static readonly List<Message> ListOfMessages = new List<Message> (); 
       

        // GET api/<Messanger>/5
        // Серверная часть, Запрос (GET) у севера отправленных сообщений.
        // Postman.co использовать для отправки (POST) сообщений и запросов (GET) на севере.
        // В GET: //http:/localhost:<номер каторый выдаст консольная строка>/api/Messanger/<Номер запроса начиная с 0>
        // В консоли будут отбражатся все запросы
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // Если не будет сообщения, то выдаст no found:
            string outputString = "Not found";   

            // вывод сообщения и номер его отправки (id):
            if (( id < ListOfMessages.Count) && (id >= 0))
            {
                outputString = JsonConvert.SerializeObject(ListOfMessages[id]);  // сриализация объекта передачи
            }
            Console.WriteLine (String.Format("Запрошено сообщение N {0} : {1}", id, outputString));
            return outputString;
        }

        // POST api/<Messanger>
        // Отправка сообщения (SEND) 
        // В postman.co выбрать (POST)  и ввести //http:/localhost:<номер каторый выдаст консольная строка>/api/Messanger.
        // Выбрать body, далее row и JSON
        // Далее ввести в текстовом редакторе следующее:
        // "UserName": "Ввести имя отправителя", "MessageText": "Ввети текст сообщения"
        // И отправить сообщение
        // В консоли будут отбражаться все сообщения (имя, текст, время отправки) 

        [HttpPost]
        public IActionResult SendMessage([FromBody] Message msg)
        {
            if (msg == null)
            {
                return BadRequest();
            }
            ListOfMessages.Add(msg);
            Console.WriteLine (String.Format("Всего сообщений: {0} Посланное сообщение: {1}", ListOfMessages.Count, msg));
            return new OkResult(); 
        }

        
        
    }
}
