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
using MailClient.Transform;

namespace MailClient
{
    public partial class Form_Main : Form
    {
        public SmtpClient smtp;
        public PopClient pop;
        public User user = new User();
        public List<Mail> mails = new List<Mail>();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void ToolStripButton_Login_MouseEnter(object sender, EventArgs e)
        {
            ToolTip_Login.Show("登录", (Button)sender);
        }

        private void ToolStripButton_Setting_Click(object sender, EventArgs e)
        {
            Form_Setting setting = new Form_Setting(user);
            setting.Show();
        }
    }
}
