using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Model
{
    class Mail
    {
        public int ID { get; set; }
        public string From { get; set; }
        public List<string> To { get; }
        public List<string> Cc { get; }
        public List<string> Bcc { get; }
        public string Subject { get; set; }
        public bool IsHtml { get; set; } = false; // 暂时不用
        public string Message { get; set; }
        //bool HasAttach { get; set; } // 暂时不用

        public Mail(int id, string from, string subject, string message = "", params string[] to)
        {
            To = new List<string>();
            Cc = new List<string>();
            Bcc = new List<string>();

            ID = id;
            From = from;
            Subject = subject;
            Message = message;
            foreach(string t in to)
            {
                To.Add(t);
            }
        }

        public void AddCc(string to)
        {
            Cc.Add(to);
            To.Add(to);
        }

        public void AddBcc(string to)
        {
            Bcc.Add(to);
            To.Add(to);
        }
    }
}
