using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace MailClient.Model
{
    public class User
    {
        public IPAddress SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public IPAddress PopHost { get; set; }
        public int PopPort { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool HasValue { get; set; } = false;
    }
}
