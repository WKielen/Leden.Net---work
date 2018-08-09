using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

using Util.Email;

namespace Leden.Net
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="regel"></param>
    public delegate void CallBackStatus(string regel);
    
    /// <summary>
    /// 
    /// </summary>
    public class SmtpClientExt : SmtpClient
    {
        CallBackStatus GiveBackStatusToCaller;

        /// <summary>
        /// 
        /// Aanroepen met :
        /// SmtpClientExt client = new SmtpClientExt("server72.hosting2go.nl", 2525, "penningmeester@ttvn.nl", "password",
        ///                                          string.Empty, false, false, new CallBackStatus(PrintRegel));
        /// Je moet in de calling class de volgende method hebben :
        ///  static void PrintRegel(string regel)
        ///{
        ///    Console.WriteLine(regel);
        ///}
        ///
        /// </summary>
        /// <param name="Host"></param>
        /// <param name="Port"></param>
        /// <param name="Userid"></param>
        /// <param name="Password"></param>
        /// <param name="Logfile"></param>
        /// <param name="LogMessages"></param>
        /// <param name="DoNotSend"></param>
        /// <param name="callBackStatus"></param>
        public SmtpClientExt(string Host, int Port, string Userid, string Password, string Logfile, bool LogMessages, bool DoNotSend, CallBackStatus callBackStatus)
            : base(Host, Port)
        {
            smtphost = Host;
            UseDefaultCredentials = false;
            userid = Userid;
            password = Password;
            logFile = Logfile;
            logMessages = LogMessages;
            doNotSendEmail = DoNotSend;

            Credentials = new NetworkCredential(userid, password);

            GiveBackStatusToCaller = callBackStatus;

            Initialize();
        }

        private bool doNotSendEmail;
        private bool logMessages;
        private string logFile;
        private string userid;
        private string password;

        private string smtphost;
        private DateTime syncTime;

        public void Send(MailMessage message)
        {
            if ((DateTime.Now - syncTime).Minutes > 20)
            {
                Initialize();
            }

            if (logMessages)
                LogMessage(message);

            if (!doNotSendEmail)
                base.Send(message);
        }

        private void LogMessage(MailMessage message)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Empty);
                foreach (object o in message.To)
                {
                    sb.AppendLine("To: " + o.ToString());
                }
                sb.AppendLine(string.Empty);
                sb.AppendLine("Subject: " + message.Subject);
                sb.AppendLine(string.Empty);
                sb.AppendLine(message.Body);
                sb.AppendLine(string.Empty);
                sb.AppendLine(StripHTML(message.Body));
                sb.AppendLine("===============================================================================");
                Util.Email.PrependFile.PrependAllText(logFile, sb.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Loggen van de mail is mislukt. " + ex.Message);
            }

        }

        #region striphtml
        /// <summary>
        /// haal de html tags uit de string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private static string StripHTML(string source)
        {
            try
            {
                string result;

                // Remove HTML Development formatting
                // Replace line breaks with space
                // because browsers inserts space
                result = source.Replace("\r", " ");
                // Replace line breaks with space
                // because browsers inserts space
                result = result.Replace("\n", " ");
                // Remove step-formatting
                result = result.Replace("\t", string.Empty);
                // Remove repeating spaces because browsers ignore them
                result = System.Text.RegularExpressions.Regex.Replace(result,
                                                                      @"( )+", " ");

                // Remove the header (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*head([^>])*>", "<head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*head( )*>)", "</head>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<head>).*(</head>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all scripts (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*script([^>])*>", "<script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*script( )*>)", "</script>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                //result = System.Text.RegularExpressions.Regex.Replace(result,
                //         @"(<script>)([^(<script>\.</script>)])*(</script>)",
                //         string.Empty,
                //         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<script>).*(</script>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // remove all styles (prepare first by clearing attributes)
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*style([^>])*>", "<style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"(<( )*(/)( )*style( )*>)", "</style>",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(<style>).*(</style>)", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert tabs in spaces of <td> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*td([^>])*>", "\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line breaks in places of <BR> and <LI> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*br( )*>", "\n",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*li( )*>", "\n",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // insert line paragraphs (double line breaks) in place
                // if <P>, <DIV> and <TR> tags
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*div([^>])*>", "\n\n",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*tr([^>])*>", "\n\n",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<( )*p([^>])*>", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // Remove remaining tags like <a>, links, images,
                // comments etc - anything that's enclosed inside < >
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<[^>]*>", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // replace special characters:
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @" ", " ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"•", " * ",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"‹", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"›", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"™", "(tm)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"⁄", "/",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"<", "<",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @">", ">",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"©", "(c)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"®", "(r)",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove all others. More can be added, see
                // http://hotwired.lycos.com/webmonkey/reference/special_characters/
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         @"&(.{2,6});", string.Empty,
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // for testing
                //System.Text.RegularExpressions.Regex.Replace(result,
                //       this.txtRegex.Text,string.Empty,
                //       System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                // make line breaking consistent
                result = result.Replace("\n", "\r");

                // Remove extra line breaks and tabs:
                // replace over 2 breaks with 2 and over 4 tabs with 4.
                // Prepare first to remove any whitespaces in between
                // the escaped characters and remove redundant tabs in between line breaks
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\t)", "\t\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\t)( )+(\r)", "\t\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)( )+(\t)", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove redundant tabs
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+(\r)", "\r\r",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Remove multiple tabs following a line break with just one tab
                result = System.Text.RegularExpressions.Regex.Replace(result,
                         "(\r)(\t)+", "\r\t",
                         System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                // Initial replacement target string for line breaks
                string breaks = "\r\r\r";
                // Initial replacement target string for tabs
                string tabs = "\t\t\t\t\t";
                for (int index = 0; index < result.Length; index++)
                {
                    result = result.Replace(breaks, "\r\r");
                    result = result.Replace(tabs, "\t\t\t\t");
                    breaks = breaks + "\r";
                    tabs = tabs + "\t";
                }

                // That's it.
                return result;
            }
            catch
            {
                //               MessageBox.Show("Error");
                return source;
            }
        }
        #endregion

        private void Initialize()
        {
            TcpClient server = new TcpClient(smtphost, 110);
            NetworkStream networkStream = server.GetStream();
            StreamReader streamreader = new StreamReader(server.GetStream());
            string CRLF = "\r\n";

            //========================================================================
            string data = "USER " + userid + CRLF;
            byte[] szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray());
            networkStream.Write(szData, 0, szData.Length);

            string sr = streamreader.ReadLine();
            if (!sr.StartsWith("+OK"))
                throw new Exception("Userid not correct");
            GiveBackStatusToCaller("Logging on to mailserver : "+ smtphost + " on port: 110");

            sr = streamreader.ReadLine();
            if (!sr.StartsWith("+OK"))
                throw new Exception("Userid not correct");
            System.Threading.Thread.Sleep(2000);

            //========================================================================
            data = "PASS " + password + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray());
            networkStream.Write(szData, 0, szData.Length);

            sr = streamreader.ReadLine();
            if (!sr.StartsWith("+OK"))
                throw new Exception("Password not correct");
            GiveBackStatusToCaller("Logged on; Ready to send mail");
            System.Threading.Thread.Sleep(2000);

            //========================================================================
            data = "STAT" + CRLF;
            szData = System.Text.Encoding.ASCII.GetBytes(data.ToCharArray());
            networkStream.Write(szData, 0, szData.Length);
            
            sr = streamreader.ReadLine();
            
            // if values returned ...
            if (Regex.Match(sr,
                @"^.*\+OK[ |	]+([0-9]+)[ |	]+.*$").Success)
            {
                // get number of emails ...
                long count = long.Parse(Regex
                .Replace(sr.Replace("\r\n", "")
                , @"^.*\+OK[ |	]+([0-9]+)[ |	]+.*$", "$1"));
                GiveBackStatusToCaller("Nbr mails in mailbox: " + count.ToString());
            }
            //========================================================================

            syncTime = DateTime.Now;
            System.Threading.Thread.Sleep(2000);
        }
    }
}
