#define debug
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using Util.Extensions;
using Util.Forms;

// incasso naar  testbestanden.sepa@rn.rabobank.nl. 

namespace Leden.Net
{
    public partial class frmAankondiging : frmBasis
    {
        LedenLijst leden;
        RekeningenLijst rekeningen;
        RekeningenLijst selectedInc = new RekeningenLijst();
        RekeningenLijst selectedRek = new RekeningenLijst();
        RekeningenLijst selectedUPas = new RekeningenLijst();
        int nbrTxtInc = 0;
        decimal sumTotaalInc = 0;
        int nbrTxtRek = 0;
        decimal sumTotaalRek = 0;
        DataAdapters dataAdaptor;
        string verstuurdeRekeningenReport = string.Empty;
        private string EmailLogFile;

        public frmAankondiging(DataAdapters da, tblParameters xParam)
        {
            InitializeComponent();
            param = xParam;
            verstuurdeRekeningenReport = param.LocationLogFiles + @"\" + param.ClubNameShort + @"_Verstuurde rekeningen.csv";
            EmailLogFile = param.LocationLogFiles + @"\" + param.ClubNameShort + "_Mail_Logfile.txt";
            if (!File.Exists(EmailLogFile))
                File.Create(EmailLogFile);
            rekeningen = da.VulRekeningRecords();
            leden = da.VulLedenLijst();
            dataAdaptor = da;

            _windowState = new PersistWindowState(this, @"Leden\Aankondiging");

            chkLogEmail.Checked = param.LogEmail;
            ckbDoNotSendEmail.Checked = param.DoNotSendEmail;


            foreach (Leden.Net.tblRekening rekening in rekeningen)
            {
                if (rekening.Verstuurd) continue;
                if (rekening.Lid.IsIncasso)
                {
                    selectedInc.Add(rekening);
                    sumTotaalInc += rekening.TotaalBedrag;
                    nbrTxtInc++;
                }
                if (rekening.Lid.IsRekening)
                {
                    selectedRek.Add(rekening);
                    sumTotaalRek += rekening.TotaalBedrag;
                    nbrTxtRek++;
                }
            }
            dtpIncassoDatum.Value = DateTime.Now.AddDays(10);
            lblMessage.Text = "Aantal: " + nbrTxtInc.ToString() + " - Bedrag: " + sumTotaalInc.ToEuroString();
            lblMessageRek.Text = "Aantal: " + nbrTxtRek.ToString() + " - Bedrag: " + sumTotaalRek.ToEuroString();
        }


        #region Verstuur contributie aankondiging
        StringBuilder errorList = new StringBuilder();
        bool errorMail = false;
        ProgressWindow progress;
        IProgressCallback callback;

        private void cmdMail_Click(object sender, EventArgs e)
        {
            progress = new ProgressWindow();
            progress.Text = "Emailing";
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(DoSomeWork), progress);
            progress.ShowDialog();
            if (errorMail)
                ShowText.Show(errorList.ToString(), "Failed Email");
        }

        private void DoSomeWork(object status)
        {
            errorList = new StringBuilder();
            errorMail = false;
            errorList.AppendLine("Email not sent to:");
            callback = status as IProgressCallback;
            try
            {
                callback.Begin(0, nbrTxtInc);
                SendContributieIncassoAankondiging();
                SendInschrijfIncassoAankondiging();
                callback.WaitOK();
            }
            catch (System.Threading.ThreadAbortException)
            {
                // We want to exit gracefully here (if we're lucky)
            }
            catch (System.Threading.ThreadInterruptedException)
            {
                // And here, if we can
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            finally
            {
                if (callback != null)
                {
                    callback.End();
                }
            }
        }

        private void SendContributieIncassoAankondiging()
        {
            string fileName = param.LocationTemplates + @"\Template_ContributieIncasso.htm"; ;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor incasso mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                                            EmailLogFile, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, callback.SetText);


            //SmtpEmailer emailer = new SmtpEmailer();
            //emailer.Host = param.STMPserver;
            //emailer.From = param.EmailReturnAdress;
            //emailer.AuthenticationMode = AuthenticationType.Base64;
            //emailer.User = param.EmailUserId;
            //emailer.Password = param.EmailPassword;
            //emailer.SendAsHtml = true;
            //emailer.LogFile = EmailLogFile;
            //emailer.DoNotSendMail = ckbDoNotSendEmail.Checked;
            //emailer.LogMail = chkLogEmail.Checked;


            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();


            foreach (Leden.Net.tblRekening rekening in selectedInc)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.EmailReturnAdress);
                //emailer.ClearMessage();
                if (rekening.TypeRekening != 0 || rekening.MailOnderdrukken) continue;                  // Alleen contributie incasso's

                string sbr = template;
                // vervangen keywords
                sbr = MailRoutines.ReplaceKeyWords(sbr, rekening.Lid, param);
                sbr = ReplaceRekeningItems(sbr, rekening);

                message.IsBodyHtml = true;
                message.Body = sbr;
                //emailer.Body = sbr;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    message.Subject = "Aankondiging contributie incasso TTVN";
                    //emailer.Subject = "Aankondiging contributie incasso TTVN";
                    message.To.Add(rekening.Lid.MainEmailAdress);
                    //emailer.To.Add(rekening.Lid.MainEmailAdress);
                }
                else
                {
                    message.Subject = "Geen email adres bij Aankondiging contributie incasso TTVN";
                    //emailer.Subject = "Geen email adres bij Aankondiging contributie incasso TTVN";
                    //emailer.To.Add(param.EmailReturnAdress);
                    message.To.Add(param.EmailReturnAdress);
                }
                try
                {
                    client.Send(message);
                    //emailer.SendMessage();
                }
                catch
                {
                    errorMail = true;
                    errorList.AppendLine(rekening.Lid.MainEmailAdress);
                }
                callback.Increment(1);
                callback.SetText(rekening.Lid.MainEmailAdress);
                System.Threading.Thread.Sleep(50);
                if (callback.IsAborting) return;
            }
        }

        private void SendInschrijfIncassoAankondiging()
        {
            string fileName = param.LocationTemplates + @"\Template_InschrijfIncasso.htm";

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor inschrijfgeldincasso mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                                            EmailLogFile, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, callback.SetText);

            //SmtpEmailer emailer = new SmtpEmailer();
            //emailer.Host = param.STMPserver;
            //emailer.From = param.EmailReturnAdress;
            //emailer.AuthenticationMode = AuthenticationType.Base64;
            //emailer.User = param.EmailUserId;
            //emailer.Password = param.EmailPassword;
            //emailer.LogFile = EmailLogFile;
            //emailer.DoNotSendMail = ckbDoNotSendEmail.Checked;
            //emailer.LogMail = chkLogEmail.Checked;

            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();
            foreach (Leden.Net.tblRekening rekening in selectedInc)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.EmailReturnAdress);

                //emailer.ClearMessage();
                if (rekening.TypeRekening == 0) continue;  // Geen Contributie incasso's
                string sbr = template;
                //vervangen
                sbr = MailRoutines.ReplaceKeyWords(sbr, rekening.Lid, param);
                sbr = ReplaceRekeningItems(sbr, rekening);

                message.Body = sbr;
                //emailer.Body = sbr;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    message.Subject = "Aankondiging incasso TTVN";
                    //emailer.Subject = "Aankondiging incasso TTVN";
                    message.To.Add(rekening.Lid.MainEmailAdress);
                    //emailer.To.Add(rekening.Lid.MainEmailAdress);
                }
                else
                {
                    message.Subject = "Geen email adres bij Aankondiging  incasso TTVN";
                    //emailer.Subject = "Geen email adres bij Aankondiging  incasso TTVN";
                    message.To.Add(param.EmailReturnAdress);
                    //emailer.To.Add(param.EmailReturnAdress);
                }

                message.IsBodyHtml = true;
                //emailer.SendAsHtml = true;
                try
                {
                    client.Send(message);
                    //emailer.SendMessage();
                }
                catch
                {
                    errorMail = true;
                    errorList.AppendLine(rekening.Lid.MainEmailAdress);
                }
                callback.Increment(1);
                callback.SetText(rekening.Lid.MainEmailAdress);
                System.Threading.Thread.Sleep(50);
                if (callback.IsAborting) return;
            }
        }
        static void VulTextBox(string status)
        { }
        #endregion

        private void frmRekeningVersturen_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void cmdMailRek_Click(object sender, EventArgs e)
        {
            string fileName = param.LocationTemplates + @"\Template_ContributieRekening.htm"; ;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor rekening mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();

            foreach (Leden.Net.tblRekening rekening in selectedRek)
            {
                if (rekening.TypeRekening != 0) continue;                  // Alleen contributie rekening
  
                BodyString body = ReplaceRekeningItems(template, rekening);   
                    
                string subject;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    subject = "Aankondiging contributie rekening TTVN";
                }
                else
                {
                    subject = "Geen email adres bij Aankondiging contributie rekening TTVN";
                }

                try
                {
                    frmMultiMail frm = new frmMultiMail(rekening, param, body, subject, new List<string>());
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    GuiRoutines.ExceptionMessageBox(this, ex);
                }
            }
        }


        public string ReplaceRekeningItems(string template, tblRekening rekening)
        {
            //vervangen
            template = template.Replace("***incdat***", dtpIncassoDatum.Value.ToString("s").Substring(0, 10));

            template = template.Replace("***incamt***", rekening.TotaalBedrag.ToXMLEuroString());
            template = template.Replace("***b1***", "Contributie");
            template = template.Replace("***w1***", rekening.ContributieBedrag.ToXMLEuroString());

            template = template.Replace("***IBAN***", rekening.IBAN);
            template = template.Replace("***BIC***", rekening.BIC);

            int j = 2;
            string x = "***b" + j.ToString() + "***";
            if (rekening.Bondsbijdrage != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Bondsbijdrage");
                template = template.Replace("***w" + j.ToString() + "***", rekening.Bondsbijdrage.ToXMLEuroString());
                j++;
            }
            if (rekening.CompetitieBijdrage != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "CompetitieBijdrage");
                template = template.Replace("***w" + j.ToString() + "***", rekening.CompetitieBijdrage.ToXMLEuroString());
                j++;
            }
            if (rekening.Korting != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Korting");
                template = template.Replace("***w" + j.ToString() + "***", rekening.Korting.ToXMLEuroString());
                j++;
            }
            if (rekening.ExtraBedrag != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Kosten rekening");
                template = template.Replace("***w" + j.ToString() + "***", rekening.ExtraBedrag.ToXMLEuroString());
                j++;
            }
            if (rekening.BedragKortingVrijwilliger != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Korting Vrijwilliger");
                template = template.Replace("***w" + j.ToString() + "***", rekening.BedragKortingVrijwilliger.ToXMLEuroString());
                j++;
            }

            for (int i = j; i <= 5; i++)
            {
                template = template.Replace("***b" + i.ToString() + "***", string.Empty);
                template = template.Replace("***w" + i.ToString() + "***", string.Empty);
            }


            template = template.Replace("***omschrijving***", rekening.Omschrijving);

            return template;
        }

        private void cmdShowLogfileMail_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(EmailLogFile);
                GuiRoutines.ShowMessage(sr.ReadToEnd(), EmailLogFile);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
