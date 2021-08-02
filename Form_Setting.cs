using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailClient.Model;
using System.Net;

namespace MailClient
{
    
    public partial class Form_Setting : Form
    {
        User usr;
        public Form_Setting(User usr)
        {
            InitializeComponent();
            this.usr = usr;
            if (this.usr.HasValue)
            {
                TextBox_Smtp.Text = usr.SmtpHost.ToString();
                TextBox_Smtp_Port.Text = usr.SmtpPort.ToString();
                TextBox_Pop.Text = usr.PopHost.ToString();
                TextBox_Pop_Port.Text = usr.PopPort.ToString();
                TextBox_UserName.Text = usr.UserName;
                TextBox_Password.Text = usr.Password;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if(TextBox_Smtp.TextLength > 0 && TextBox_Smtp_Port.TextLength > 0
                && TextBox_Pop.TextLength > 0 && TextBox_Pop_Port.TextLength > 0
                && TextBox_UserName.TextLength>0 && TextBox_Password.TextLength > 0)
            {
                usr.SmtpHost = TextBox_Smtp.Text;
                usr.SmtpPort = Convert.ToInt32(TextBox_Smtp_Port);
                usr.PopHost = TextBox_Pop.Text;
                usr.PopPort = Convert.ToInt32(TextBox_Pop_Port);
                usr.UserName = TextBox_UserName.Text;
                usr.Password = TextBox_Password.Text;
                usr.HasValue = true;
            }
            this.Close();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
