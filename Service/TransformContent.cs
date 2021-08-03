using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;



//对解析过来的邮件内容进行解析
namespace MailClient.TransformContent
{
    public class Transform
    {
        public string Content { get; set; }
        public string[] MailTo { get; set; }
        public string MailFrom { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string[] ContentType { get; set; }
        //一般有text,multipart等类型,返回值为如{"text","html","gbk"}
        public string TransferEncoding { get; set; }

        public Transform() { }

        //原来的函数只包含对于一封邮件进行解析
        public void transform(string oriContent)
        {
            StreamReader stream;
            stream = new StreamReader(GenerateStreamFromString(oriContent));
            string row;
            while (stream.EndOfStream == false)
            {
                row = stream.ReadLine();

                if (row.IndexOf("From:") != -1&& row.IndexOf("<")!=-1)
                {
                    try
                    {
                        int i = row.IndexOf("<");
                        int j = row.IndexOf(">");
                        MailFrom = row.Substring(i + 1, j - i - 1);
                    }
                    catch (Exception e) { throw e.InnerException; }
                    continue;
                }
                if (row.IndexOf("To:") != -1 && row.IndexOf("<") != -1)
                {
                    try
                    {
                        
                        string[] AMailTo;
                        AMailTo = row.Substring(row.IndexOf(":") + 2).Trim().Split(' ');
                        MailTo = new string[3];
                        for(int k = 1; k < AMailTo.Length; k++)
                        {
                            MailTo[k - 1] = AMailTo[k];
                            if (MailTo[k - 1].IndexOf("<") != -1)
                            {
                                int i = MailTo[k-1].IndexOf("<");
                                int j = MailTo[k-1].IndexOf(">");
                                MailTo[k - 1] = MailTo[k - 1].Substring(i + 1, j - i - 1);
                            }
                        }


                    }
                    catch (Exception e) { throw e.InnerException; }
                    continue;
                }
                if (row.IndexOf("Subject:") != -1)
                {
                    try
                    {
                        Subject = SubTransform(row.Substring(row.IndexOf(":") + 2));

                    }
                    catch (Exception e) { throw e.InnerException; }
                    continue;
                }
                if (row.IndexOf("Date:") != -1)
                {
                    try
                    {
                        Date = row.Substring((row.IndexOf(":") + 2));
                    }
                    catch (Exception e) { throw e.InnerException; }
                    continue;
                }
                if (row.IndexOf("This is a multi-part message in MIME format") != -1)
                {
                    while (stream.EndOfStream == false)
                    {
                        row = stream.ReadLine();
                        if (row.IndexOf("Content-Type") != -1)
                        {
                            string[] str, rt, s3;
                            string s = row;
                            rt = new string[3];
                            s += stream.ReadLine(); //把下一行的charset加上
                            s = s.Replace('"', ' ');
                            str = s.Split(';');
                            str[0] = str[0].Trim();//分别处理两段
                            str[1] = str[1].Trim();
                            s3 = str[0].Substring(str[0].IndexOf(" ") + 1).Trim().Split('/');
                            rt[0] = s3[0];
                            rt[1] = s3[1];
                            rt[2] = str[1].Substring(str[1].IndexOf("=") + 1).Trim();
                            try
                            {
                                this.ContentType = rt;
                            }
                            catch (Exception e) { throw e.InnerException; }
                            continue;
                        }
                        if (row.IndexOf("Content-Transfer-Encoding:") != -1)
                        {
                            try
                            {
                                string ecoding= row.Substring((row.IndexOf(":") + 2));                                                               
                                this.TransferEncoding = ecoding;                               
                                //把content内容放在Content-Transfer-Ecodong后面
                                row = stream.ReadLine();
                                
                                if(row == "") { row = stream.ReadLine(); }
                                if (row.IndexOf("==") != -1)
                                {
                                    
                                }
                                else
                                {
                                    while (row.IndexOf("------=_NextPart") == -1)
                                    {
                                        if (ContentType[1] == "html")
                                        {
                                            Content += row;
                                            row = stream.ReadLine();
                                        }
                                        else { row = stream.ReadLine(); }

                                    }
                                }/*
                                if (row == "") { row = stream.ReadLine(); }
                                while(row != "")
                                {
                                    Content += row;
                                    row = stream.ReadLine();
                                }*/
                            }
                            catch (Exception e) { throw e.InnerException; }
                            continue;
                        }

                    }
                }
            }
            //Console.WriteLine(ContentType[0] + ContentType[1] + ContentType[2]);
            //最后对邮件的内容进行解码.适用不同处理方式
            if (ContentType[0] == "text")
            {
                switch (TransferEncoding)
                {
                    case "base64":
                        Content = Encoding.GetEncoding(ContentType[2].ToUpper()).GetString(Convert.FromBase64String(Content));
                        break;
                    case "quoted-printable":
                        Content = QuotedPrintable(GetContent(oriContent), ContentType[2]);
                        break;
                    default:
                        Content = GetContent(oriContent).Trim();
                        break;
                        ;
                }
            }
            //可能不同的内容形式还会对控件的选择造成影响，这里先不做，有问题再说
            //其中由于附件处理复杂，这里就没有处理
            /*
            if (ContentType[1] == "html")
            {
                //切换到html类型的浏览器控件
                webBrower.DucumentText = Content;
            }
            else { richTextBoxContent.Text = Content; } //文本文件
            */
        }


        public static string DecodeBase64(string code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(code_type).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }

        //根据字符串创建一个文件流
        private Stream GenerateStreamFromString(string s)
        {

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;

        }


        //转换主题格式
        private string SubTransform(string subject)
        {
            subject = subject.Trim();
            //标题的正则表达式
            Regex regex = new Regex(@"=\?([\s\S]+)\?=");
            MatchCollection match = regex.Matches(subject);
            if (match.Count <= 0) { }
            else
            {
                for (int i = 0; i < match.Count; i++)
                {
                    subject = subject.Replace(match[i].Value, ConvertStr(match[i].Value));
                }
            }
            return subject;
        }

        private string ConvertStr(string s)
        {
            string[] divString = s.Split('?');
            if (divString[2].ToUpper() == "B")
            {
                s = DecodeBase64("GBK", divString[3]);

            }//进行quoted-printable转换字符
            else { s = QuotedPrintable(divString[3], divString[1]); }
            return s;
        }

        private string QuotedPrintable(string s, string codeType)
        {
            s = s.Replace("=\r\n", "");
            s = s.Replace("=\n", "");
            int length = s.Length;
            string dest = string.Empty;
            int i = 0;
            while (i < length)
            {
                string temp = s.Substring(i, 1);
                if (temp == "=")
                {
                    try
                    {
                        int code = Convert.ToInt32(s.Substring(i + 1, 2), 16);
                        if (Convert.ToInt32(code.ToString(), 10) < 127)
                        {
                            dest += ((char)code).ToString();

                            i = i + 3;
                        }
                        else
                        {
                            try
                            {
                                dest += Encoding.GetEncoding(codeType.ToUpper()).GetString(new byte[] {
                                Convert.ToByte(s.Substring(i + 1, 2), 16),

                                Convert.ToByte(s.Substring(i + 4, 2), 16) });

                            }
                            catch (Exception e) { throw e.InnerException; }
                            i += 6;
                        }
                    }
                    catch { i++; continue; }
                }
                else { dest += temp; i++; }
            }
            return dest;
        }

        //获取邮件的文本内容（w未解码）
        private string GetContent(string oriContent)
        {
            string s = "";
            StreamReader stream;
            stream = new StreamReader(GenerateStreamFromString(oriContent));
            string row = stream.ReadLine();
            while (row != "") { row = stream.ReadLine(); }
            //此时在第一个CRLF的位置 ？采取直接全部读取的方法，可能要改进
            while (stream.EndOfStream == false)
            {
                row = stream.ReadLine();
                s += row;
            }
            return s;
        }

    }
}