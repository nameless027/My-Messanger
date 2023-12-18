using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using My_Messanger;
using Terminal.Gui;


namespace ConsoleMessangerWihtGUI
{
    internal class Program
    {


        private static List<Message> messages = new List<Message>();
        private static MessangerClientAPI API = new MessangerClientAPI();

        private static MenuBar menu;
        private static Window winMain;
        private static Window WinMessages;
        private static Label labelUser;
        private static TextField fieldUserName;
        private static Label LebelMessage;
        private static TextField fieldMessage;
        private static Button btnSend;

        static void Main()
        {

        }
    }
}
