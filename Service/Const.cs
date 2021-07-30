using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Service
{
    enum States
    {
        DisConn,
        Connect,
        Login,
        Sending,
        Receiving
    }
    class Const
    {
        public static string CRLF = "\r\n";
        public static Dictionary<string, string> SmtpError = new Dictionary<string, string>
        {
            //BASIC
            {"450","Requested mail action not taken: mailbox unavailable" },
            {"500","Syntax error, command unrecognized" },
            {"502","Command not implemented" },
            {"552","Requested mail action aborted: exceeded storage allocation" },
            {"553","Requested action not taken: mailbox name not allowed" },
            {"554","Transaction failed Or No SMTP service here" },
            //AUTH
            {"432", "A password transition is needed" }
        };
    }
}
