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
    class PopClient
    {
        private Socket server;
        public string User { get; set; }
        public string Password { private get; set; }
        public IPAddress Host { get; set; }
        public int Port { get; set; }
        public States State { get; set; }
        public List<string> Log;

        public PopClient()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            State = States.DisConn;
            Log = new List<string>();
        }

        public void Connect(IPAddress host, int port)
        {
            Host = host;
            Port = port;
            server.Connect(Host, Port);

            State = States.Connect;
        }

        public void Login(IPAddress host, int port, string user, string password)
        {
            User = user;
            Password = password;

            using (NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                cmdData = "User " + User + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm);

                cmdData = "PASS " + Password + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm);

                State = States.Login;
            }
        }

        public string GetMail(int index)
        {
            StringBuilder res = new StringBuilder(256);
            
            State = States.Receiving;

            using (NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                cmdData = "RETR " + index + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm);

                using (StreamReader rd = new StreamReader(strm))
                {
                    string _res = "";
                    
                    while (_res != ".")
                    {
                        res.Append(_res);
                        _res = rd.ReadLine();
                        _res += Const.CRLF;
                    }
                }
            }

            State = States.Login;

            return res.ToString();
        }

        public List<string> GetAllMain()
        {
            List<string> ret = new List<string>();

            using (NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;
                string[] res = new string[3];
                int num = 0;

                cmdData = "STAT " + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                using(StreamReader rd = new StreamReader(strm))
                {
                    res = rd.ReadLine().Split(' ');
                    if (res[0][0] == '+')
                    {
                        num = Convert.ToInt32(res[1]);
                    }
                    else
                    {
                        throw new WebException("Error");
                    }
                }
                for(int i = 1; i <= num; i++)
                {
                    ret.Add(GetMail(i));
                }
            }

            return ret;
        }

        public void Quit()
        {
            using(NetworkStream strm = new NetworkStream(server))
            {
                string cmdData;
                byte[] sdData;

                cmdData = "QUIT " + Const.CRLF;
                sdData = Encoding.ASCII.GetBytes(cmdData);
                strm.Write(sdData, 0, sdData.Length);
                Check(strm);

                State = States.DisConn;
            }
        }

        public bool Check(NetworkStream strm)
        {
            bool flag = false;
            using(StreamReader rd = new StreamReader(strm))
            {
                if (strm.DataAvailable)
                {
                    string res = rd.ReadLine();
                    Log.Add(res);
                    if (res[0] == '+')
                    {
                        flag = true;
                    }
                    else
                    {
                        Quit();
                        throw new WebException("Error");
                    }
                }
            }
            return flag;
        }
    }
}
