using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_Messanger;
using Newtonsoft.Json;
using Message = My_Messanger.Message;

namespace WindowsFormsClient
{
    public partial class Form1 : Form
    {

        private static int MessageID;
        private static string UserName;
        private static My_Messanger.MessangerClientAPI API = new My_Messanger.MessangerClientAPI();
        public Form1()
        {
            InitializeComponent();
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            string UserName = UserNameTB.Text;
            string Message = MessageTB.Text;
            if ((UserName.Length > 1) && (UserName.Length > 1))
            {
                Message msg = new Message(DateTime.Now, UserName, Message);
                API.SendMessage(msg);
               // MessageLB.Items.Add(msg);

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            var getMessage = new Func<Task>(async () =>
            {
                Message msg = await API.GetMessageHTTPAsync(MessageID);
                while (msg != null)
                {
                    MessageID++;
                    msg = await API.GetMessageHTTPAsync(MessageID);
                    MessageLB.Items.Add(msg);
                }
                
                
            });
            getMessage.Invoke();

        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageID = 0;
        }

        

       
    }



    
}
