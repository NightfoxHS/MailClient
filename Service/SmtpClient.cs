using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace MailClient.Service
{
    class SmtpClient
    {
        private Socket server;
        public string User { get; set; }
        public string Password { private get; set; }
        public IPAddress Host { get; set; }
        public int Port { get; set; }
        public States State { get; set; }
        public List<string> Log;

        public SmtpClient()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            State = States.DisConn;
            Log = new List<string>();
        }

        public void Connect(IPAddress host,int port)
        {
            Host = host;
            Port = port;
            using(NetworkStream strm = new NetworkStream(server))
            {
                server.Connect(Host, Port);
                Check(strm, "220");
            }
            State = States.Connect;
        }
        
        public void Login(IPAddress host, int port, string user, string password)
        {
            User = user;
            Password = password;

            Connect(host, port);
            using (NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                //Login
                cmdData = "HELO" + host.ToString() + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "250");

                cmdData = "AUTH LOGIN" + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "334");

                cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(User)) + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "334");

                cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)) + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "235");

                State = States.Login;
            }
        }

        public void Send(string from, string subject, string message = "", params string[] to)
        {
            using(NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                State = States.Sending;

                cmdData = "MAIL FROM: <" + from + '>' + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "250", "251");

                foreach (string t in to)
                {
                    cmdData = "RCPT TO: <" + t + '>' + Const.CRLF;
                    sdData = Encoding.ASCII.GetBytes(cmdData);
                    strm.Write(sdData, 0, sdData.Length);
                    Check(strm, "250", "251");
                }

                cmdData = "DATA" + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "354");

                cmdData = "from: " + from + Const.CRLF;
                cmdData += "to: " + String.Join(",", to) + Const.CRLF;
                cmdData += "subject: " + subject + Const.CRLF;
                cmdData += Const.CRLF;
                cmdData += (message + Const.CRLF + '.' + Const.CRLF);
                sdData = Encoding.UTF8.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm, "250");

                State = States.Login;
            }
        }

        public void Quit()
        {
            using(NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                cmdData = "QUIT" + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);

                server.Close();

                State = States.DisConn;
            }
        }

        public bool Check(NetworkStream strm, params string[] expected)
        {
            bool flag = false;

            using (StreamReader rd = new StreamReader(strm))
            {
                if (strm.DataAvailable)
                {
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
                        Quit();
                        if (Const.SmtpError.TryGetValue(res.Substring(0, 3), out string err))
                        {
                            throw new WebException(err);
                        }
                        else
                        {
                            throw new WebException("Unknown Error");
                        }
                    }
                }
                else
                {
                    throw new WebException("No data to read");
                }
            }
            return flag;
        }
        
    }
}
