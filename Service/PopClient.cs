using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using MailClient.Model;
using MailClient.TransformContent;

namespace MailClient.Service
{
    public class PopClient
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

        public PopClient()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            State = States.DisConn;
            Log = new List<string>();
        }

        public void Connect(String host, int port)
        {
            Host = host;
            Port = port;
            server.Connect(Host, Port);
            strm = new NetworkStream(server);
            rd = new StreamReader(strm);
            Check();
            State = States.Connect;
        }

        public void Login(string host, int port, string user, string password)
        {
            User = user;
            Password = password;

            Connect(host, port);

            string cmdData;
            byte[] sdData;

            cmdData = "User " + User + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check();

            cmdData = "PASS " + Password + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check();

            State = States.Login;
        }

        public string GetMail(int index)
        {
            StringBuilder res = new StringBuilder(256);

            State = States.Receiving;

            string cmdData;
            byte[] sdData;

            cmdData = "RETR " + index + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check();

            string _res = "";

            while (_res != "." + Const.CRLF)
            {
                res.Append(_res);
                _res = rd.ReadLine();
                _res += Const.CRLF;
            }

            State = States.Login;
            return res.ToString();
        }

        //对原来的函数进行更改
        public List<Mail> GetAllMail()
        {
            List<Mail> ret = new List<Mail>();


            string cmdData;
            byte[] sdData;
            string[] res = new string[3];
            int num = 0;

            cmdData = "STAT " + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);

            res = rd.ReadLine().Split(' ');
            if (res[0][0] == '+')
            {
                num = Convert.ToInt32(res[1]);
            }
            else
            {
                throw new WebException("Error");
            }

            List<Transform> transformList = new List<Transform>();
            for (int i = 1; i <= num; i++)
            {
                Transform NewTransform = new Transform();
                transformList.Add(NewTransform);
                transformList[i-1].transform(GetMail(i));
                Mail NewMail = new Mail(NewTransform.MailFrom,NewTransform.Subject,NewTransform.Content,NewTransform.Date,NewTransform.MailTo);
                ret.Add(NewMail);
            }


            return ret;
        }

        public void Quit()
        {
            string cmdData;
            byte[] sdData;

            cmdData = "QUIT " + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            Check();

            server.Close();
            strm.Dispose();
            rd.Dispose();

            State = States.DisConn;
        }

        public bool Check()
        {
            bool flag = false;
            string res = rd.ReadLine();
            Log.Add(res);
            if (res[0] == '+')
            {
                flag = true;
            }
            else
            {
                throw new WebException("Error");
            }

            return flag;
        }
    }
}
