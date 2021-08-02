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
using MailClient.TransformContent;

namespace MailClient
{
    public partial class Form_Main : Form
    {
        public SmtpClient smtp = new SmtpClient();
        public PopClient pop = new PopClient();
        public User user = new User();
        public List<Mail> mails;

        public Form_Main()
        {
            InitializeComponent();
            tableLayoutPanel_Mail.Visible = false;
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
                    mails = pop.GetAllMail();
                    ResetListBox();
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

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (smtp.State != States.DisConn)
            {
                smtp.Quit();
            }
            if (pop.State != States.DisConn)
            {
                pop.Quit();
            }
        }

        private void Button_Write_Click(object sender, EventArgs e)
        {
            Form_WriteMail wrt = new Form_WriteMail(smtp);
            wrt.Show();
        }

        private void ToolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (pop.State == States.Login)
                {
                    mails = pop.GetAllMail();
                    ResetListBox();
                }
                else
                {
                    throw new ApplicationException("错误发生，请重启客户端或稍后重试");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mail selectMail = listBox1.SelectedItem as Mail;

            Label_From_V.Text = selectMail.From;
            Label_To_V.Text = String.Join(",", selectMail.To);
            Label_Subject_V.Text = selectMail.Subject;
            WebBrowser_Message.DocumentText = selectMail.Message;
        }

        private void ResetListBox()
        {
            listBox1.DataSource = mails;
            listBox1.DisplayMember = "Subject";
            listBox1.SelectedIndex = 0;

            Mail selectMail = listBox1.SelectedItem as Mail;
            Label_From_V.Text = selectMail.From;
            Label_To_V.Text = String.Join(",", selectMail.To);
            Label_Subject_V.Text = selectMail.Subject;
            WebBrowser_Message.DocumentText = selectMail.Message;
        }
    }
}
