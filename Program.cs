using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailClient.Service;
using MailClient.TransformContent;

namespace MailClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
            
            //调试打印
            /*
            string test = "+OK644 "+ Const.CRLF+
                           "\"From:\"=?gb18030?B?ewx3?=\" <1418132361@qq.com> "+Const.CRLF+
                           "To: nightfoxhs@qq.com"+Const.CRLF+
                            "Subject: =?gbk?B?19S2r7vYuLQ61tC5 + rWxtPrOxNGnx7DR2M7KzOI=?= "+Const.CRLF+"=?gbk?B?vbLX+S3XydGv?=" + Const.CRLF +
                            "Mime-Version: 1.0  "  +Const.CRLF+
                            "Content-Type: text/html; " +Const.CRLF+
                            "charset=\"gbk\"" + Const.CRLF +
                            "Content-Transfer-Encoding: base64"  +Const.CRLF+
                            "Date: wed，30 Jun 2021 15:03:28 +0800 "  +Const.CRLF+Const.CRLF+Const.CRLF+

                            "1eLkx8C019RRUdPKz+S1xLzZxtrX1Lavu9i4tNPKvP6hozxiciAgLzl8YnIgIC8+xPq6w60s"+Const.CRLF+"08q8/tLRytW1vaOsztK74b6hv+y4+MT6u9i4tKOs0LvQu6GjPGRpdj7StsGizsQ8L2Rpdj4=" + Const.CRLF 
                            ;
            Transform atest = new Transform();
            atest.transform(test);
            Console.WriteLine(atest.Content);
            Console.WriteLine(atest.ContentType);
            Console.WriteLine(atest.Date);
            Console.WriteLine(atest.MailFrom);
            Console.WriteLine(atest.MailTo);
            Console.WriteLine(atest.Subject);
            Console.ReadLine();
            */
        }
    }
}
