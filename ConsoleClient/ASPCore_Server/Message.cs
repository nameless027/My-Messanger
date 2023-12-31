﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace My_Messanger
{
    [Serializable]
    public class Message

    {
        public string UserName { get; set; }
        public string MessageText { get; set; }
        public DateTime TimeStamp { get; set; }
     
        public Message(DateTime timeStamp, string userName, string messageText)
        {
            UserName = userName;
            MessageText = messageText;
            TimeStamp = timeStamp;
        }

        public Message()
        {
            UserName = "System";
            MessageText = "Servis is running...";
            TimeStamp = DateTime.Now;
        }

        public override string ToString()
        {
            string output = String.Format("<{2}> {0} : {1}", UserName, MessageText, TimeStamp);
            return output;
        }
    }
}
