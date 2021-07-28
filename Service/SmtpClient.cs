using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

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

        public SmtpClient()
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            State = States.DisConn;
        }

        public void Connect(IPAddress host,int port)
        {
            Host = host;
            Port = port;
            server.Connect(Host, Port);
            State = States.Connect;
        }
        
        public void Login(IPAddress host, int port, string user, string auth)
        {
            User = user;
            Password = auth;

            Connect(host, port);
            NetworkStream strm = new NetworkStream(server);
            string cmdData;
            byte[] sdData;

            //Login
            cmdData = "HELO" + host.ToString() + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);

            cmdData = "AUTH LOGIN" + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);
            
            cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(User)) + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);

            cmdData = Convert.ToBase64String(Encoding.ASCII.GetBytes(Password)) + Const.CRLF;
            sdData = Encoding.ASCII.GetBytes(cmdData);
            strm.Write(sdData, 0, sdData.Length);

            State = States.Login;
        }

        public void Send(string from, string[] to, string message)
        {

        }

        
    }
}
