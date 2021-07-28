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
    }
}
