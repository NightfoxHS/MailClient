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
        public SmtpClient smtp = new SmtpClient();
        public PopClient pop = new PopClient();
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

        private void ToolStripButton_Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (user.HasValue)
                {
                    smtp.Login(user.SmtpHost, user.SmtpPort, user.UserName, user.Password);
                    pop.Login(user.PopHost, user.PopPort, user.UserName, user.Password);
                }
                else
                {
                    throw new ApplicationException("无用户信息，请到设置中设置");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
