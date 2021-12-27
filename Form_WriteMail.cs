using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailClient.Service;
using MailClient.Model;

namespace MailClient
{
    public partial class Form_WriteMail : Form
    {
        private SmtpClient smtp;
        public Form_WriteMail(SmtpClient smtp)
        {
            InitializeComponent();
            this.smtp = smtp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] to;
            Mail mail;
            if (textBox3.Text.Contains(",") || textBox3.Text.Contains("，"))
            {
               to = textBox3.Text.Split(',', '，');
               mail = new Mail(textBox2.Text, textBox1.Text, richTextBox1.Text,DateTime.Now.ToString() ,to);
            }
            else
            {
                mail = new Mail(textBox2.Text, textBox1.Text, richTextBox1.Text, DateTime.Now.ToString(), textBox3.Text);
            }
            smtp.Send(mail);
        }
    }
}
