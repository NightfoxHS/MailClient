using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MailClient.Model;

namespace MailClient.Service
{
    public class SmtpClient
    {
        private Socket server;
        public string User { get; set; }
        public string Password { private get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public States State { get; set; }
        public List<string> Log;
        private NetworkStream strm;
        private StreamReader rd;

        public SmtpClient()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            State = States.DisConn;
            Log = new List<string>();
        }

        private void Connect(string host,int port)
        {
            Host = host;
            Port = port;
            server.Connect(Host, Port);
            strm = new NetworkStream(server);
            rd = new StreamReader(strm);
            Check("220");
            State = States.Connect;
        }

        public void Login(string host, int port, string user, string password)
        {
            User = user;
            Password = password;

            Connect(host, port);

            //Login
            SendCommandToServer("HELO ");
            Check("250");

            SendCommandToServer("AUTH LOGIN");
            Check("334");

            SendCommandToServer(Convert.ToBase64String(Encoding.ASCII.GetBytes(User)));
            Check("334");

            SendCommandToServer(Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)));
            Check("235");

            State = States.Login;

        }

        public void SendMail(string from, string subject, string message = "", params string[] to)
        {

            string cmdData;
            byte[] sdData;

            State = States.Sending;

            SendCommandToServer("MAIL FROM: <" + from + '>');
            Check("250", "251");

            foreach (string t in to)
            {
                SendCommandToServer("RCPT TO: <" + t + '>');
                Check("250", "251");
            }

            SendCommandToServer("DATA");
            Check("354");

            cmdData = "from: " + from + Const.CRLF;
            cmdData += "to: " + String.Join(",", to) + Const.CRLF;
            cmdData += "subject: " + subject + Const.CRLF;
            cmdData += Const.CRLF;
            cmdData += (message + Const.CRLF + '.' + Const.CRLF);
            sdData = Encoding.UTF8.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("250");

            State = States.Login;

        }

        public void Send(Mail mail)
        {
            SendMail(mail.From, mail.Subject, mail.Message, mail.To.ToArray());
        }

        public void Quit()
        {
            SendCommandToServer("QUIT");

            server.Close();
            strm.Dispose();
            rd.Dispose();

            State = States.DisConn;
        }

        public bool Check(params string[] expected)
        {
            bool flag = false;
            string res = "";

            if (expected.Contains("250"))
            {
                do
                {
                    res = rd.ReadLine();
                    Log.Add(res);
                } while (!res.Contains("OK"));
            }
            else
            {
                res = rd.ReadLine();
                Log.Add(res);
            }
            
            foreach (string e in expected)
            {
                if (res.Contains(e))
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                if (Const.SmtpError.TryGetValue(res.Substring(0, 3), out string err))
                {
                    throw new WebException(err);
                }
                else
                {
                    throw new WebException("Unknown Error");
                }
            }

            return flag;

        }

        private void SendCommandToServer(String cmdBody)
        {
            string cmdData;
            byte[] sdData;

            cmdData = cmdBody + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
        }
        
    }
}
