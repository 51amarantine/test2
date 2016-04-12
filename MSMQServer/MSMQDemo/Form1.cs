using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSMQDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open queue
            MessageQueue queue = new System.Messaging.MessageQueue(".\\Private$\\MSMQDemo");

            // Create message
            System.Messaging.Message message = new System.Messaging.Message();
            message.Body = txtMessage.Text.Trim();
            message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });

            // Put message into queue
            queue.Send(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open queue
            MessageQueue queue = new System.Messaging.MessageQueue(".\\Private$\\MSMQDemo");

            // Receive message, 同步的Receive方法阻塞当前执行线程，直到一个message可以得到
            System.Messaging.Message message = queue.Receive();
            message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(string) });
            txtReceiveMessage.Text = message.Body.ToString();
        }
    }
}
