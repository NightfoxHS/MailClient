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

        public void Connect(string host,int port)
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

            string cmdData;
            byte[] sdData;

            //Login
            cmdData = "HELO " + host.ToString() + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("250");
            Console.WriteLine("HELO");

            cmdData = "AUTH LOGIN" + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("334");

            cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(User)) + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("334");

            cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)) + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("235");

            State = States.Login;

        }

        public void Send(string from, string subject, string message = "", params string[] to)
        {

            string cmdData;
            byte[] sdData;

            State = States.Sending;

            cmdData = "MAIL FROM: <" + from + '>' + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check("250", "251");

            foreach (string t in to)
            {
                cmdData = "RCPT TO: <" + t + '>' + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check("250", "251");
            }

            cmdData = "DATA" + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
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
            Send(mail.From, mail.Subject, mail.Message, mail.To.ToArray());
        }

        public void Quit()
        {
            string cmdData;
            byte[] sdData;

            cmdData = "QUIT" + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);

            server.Close();
            strm.Dispose();
            rd.Dispose();

            State = States.DisConn;
        }

        public bool Check(params string[] expected)
        {
            bool flag = false;

            string res = rd.ReadLine();
            Log.Add(res);
            foreach (string e in expected)
            {
                if (res.Contains(e))
                    flag = true;
                break;
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
        
    }
}
