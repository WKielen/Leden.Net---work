using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using Util.Forms;

namespace Leden.Net
{
    public partial class frmMultiMail : frmBasis, IMruUser
    {
//        private MosaicMru mostRecentlyUsed;
        private LedenLijst ledenSchaduwlijst;
        private LedenLijst leden;
        private string mailFileName;
        private string EmailLogFile;
        StringBuilder errorList;
        bool errorMail;

        /// <summary>
        /// Deze wordt gebruikt om een lijst met alle geselecteerde leden weer te geven. Er kan optioneel gebruik worden gemaakt van een template. 
        /// </summary>
        #region frmMultiMail (Ledenlijst, tblParameters Param)

        public frmMultiMail(object lijst, tblParameters Param)                                                                   : this(lijst, Param, null, string.Empty, null, false) { }
        public frmMultiMail(object lijst, tblParameters Param, object templateName, string subject)                              : this(lijst, Param, templateName, subject, null, false) { }
        public frmMultiMail(object lijst, tblParameters Param, object templateName, string subject, List<string> attachmentList) : this(lijst, Param, templateName, subject, attachmentList, false) { }

        public frmMultiMail(object lijst, tblParameters Param, object templateName, string subject, List<string> attachmentList, bool OnlyFinancialEmail)
        {
            InitializeComponent();

            cmdGetMail.Visible = cmdSaveMail.Visible = false;

            if (lijst == null) return;

            //param = new tblParameters();
            param = Param;
            // De schaduwlijst dient om bij ieder email adres in de checkbox een Lid object te hebben zodat we de keywords kunnen vervangen
            ledenSchaduwlijst = new LedenLijst();

            //mostRecentlyUsed = new MosaicMru(this, "Multimail");
            //mostRecentlyUsed.ItemsSaveLimit = 10;
            //mostRecentlyUsed.ItemsAreFiles = false;
            //mostRecentlyUsed.BuildMenu(clbExtraEmail);
            try
            {
                foreach (string s in param.mmtxtExtraEmail)
                    clbExtraEmail.Items.Add(s);
            }
            catch { }

            _windowState = new PersistWindowState(this, @"Leden\Mail");
            //txtExtraEmail.Text = PersistControlValue.ReadControlValue(txtExtraEmail);
            chkLogEmail.Checked = param.LogEmail;
            ckbDoNotSendEmail.Checked = param.DoNotSendEmail;

            EmailLogFile = param.LocationLogFiles + @"\" + param.ClubNameShort + "_Mail_Logfile.txt";
            if (!File.Exists(EmailLogFile))
                File.Create(EmailLogFile);


            #region Bouw Ledenlijst op 
            if (lijst.GetType() == typeof(LedenLijst))
                leden = (LedenLijst)lijst;

            if (lijst.GetType() == typeof(tblLid))
            {
                tblLid lid = (tblLid)lijst;
                lid.Gemerkt = true;
                leden = new LedenLijst(lid);
            }

            if (lijst.GetType() == typeof(List<EmailAdresLid>))
            {
                leden = new LedenLijst();
                foreach (EmailAdresLid e in (List<EmailAdresLid>)lijst)
                {
                    if (string.IsNullOrEmpty(e.EmailAddress.Trim())) continue;
                    tblLid lid = new tblLid();
                    lid.Gemerkt = true;
                    lid.Email1 = e.EmailAddress;
                    leden.Add(lid);
                }
            }
            if (lijst.GetType() == typeof(tblRekening))
            {
                tblRekening rekening = (tblRekening)lijst;
                tblLid lid = rekening.Lid;
                lid.Gemerkt = true;
                leden = new LedenLijst(lid);
            }

            #endregion

            try
            {
                foreach (tblLid lid in leden)
                {
                    if (lid.Gemerkt) AddEmailToComboAndShadow(lid, OnlyFinancialEmail);
                }

                #region templateName == null dus we gebruiken de laatste opgeslagen default
                string body = string.Empty;
                if (templateName == null)
                {
                    mailFileName = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "LastUsedEmail");

                    cmdGetMail.Visible = cmdSaveMail.Visible = true;

                    if (mailFileName != string.Empty || !File.Exists(mailFileName))
                    {
                        StreamReader sr = File.OpenText(mailFileName);
                        StringReader str = new StringReader(sr.ReadToEnd());
                        body = htmlTextbox1.Text = str.ReadToEnd();
                        sr.Close();
                        sr.Dispose();
                    }
                    else
                        body = htmlTextbox1.Text = mailFileName + " not found";
                    return;
                }
                #endregion

                #region TemplateNaam is ingevuld dus gaan we die gebruiken. igv lege string dan default mailtje
                // Het type is een string dus gaan we uit van een templatenaam
                if (templateName.GetType() == typeof(string))
                {
                    if ((string)templateName == string.Empty)
                    {
                        htmlTextbox1.Text = "Beste " + param.ClubNameShort + "-er,<br><br>Met vriendelijke groet,<br>" + param.ClubNameShort;
                        return;
                    }

                    // we maken gebruik van een template voor de leden. bijv Upas mail

                    //Inlezen van de template
                    string fileNameTemplate = param.LocationTemplates + @"\Template_" + (string)templateName + ".htm"; ;

                    if (!File.Exists(fileNameTemplate))
                    {
                        MessageBox.Show("Template mail " + fileNameTemplate + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    StreamReader sr1 = File.OpenText(fileNameTemplate);
                    StringReader str1 = new StringReader(sr1.ReadToEnd());
                    htmlTextbox1.Text = str1.ReadToEnd();
                }
                #endregion

                if (templateName.GetType() == typeof(BodyString))
                {
                    htmlTextbox1.Text = (BodyString)templateName;
                }

                //Replace keywords
                if (lijst.GetType() == typeof(tblLid))
                {
                    tblLid lid = (tblLid)lijst;
                    htmlTextbox1.Text = MailRoutines.ReplaceKeyWords(htmlTextbox1.Text, lid, param);
                }
                if (lijst.GetType() == typeof(tblRekening))
                {
                    tblRekening rekening = (tblRekening)lijst;
                    htmlTextbox1.Text = MailRoutines.ReplaceKeyWords(htmlTextbox1.Text, rekening, param);
                }

                #region Subject en Attachments
                txtSubject.Text = (subject != null ? subject : string.Empty);

                if (attachmentList != null)
                {
                    for (int i = 0; i < attachmentList.Count && i < 3; i++)
                    {
                        if (i == 0 && attachmentList[i] != string.Empty)
                            txtBijlage1.Text = attachmentList[i];
                        if (i == 1 && attachmentList[i] != string.Empty)
                            txtBijlage2.Text = attachmentList[i];
                        if (i == 2 && attachmentList[i] != string.Empty)
                            txtBijlage3.Text = attachmentList[i];
                    }
                }
                #endregion

            }
            catch { }
        }

        public void VulTextBox(string message)
        {
            txtBijlage3.Text = message;
        }
        #endregion


        /// <summary>
        /// Add all the Email adressen to the checkbox and to the lid shadowlist
        /// </summary>
        /// <param name="lid"></param>
        private void AddEmailToComboAndShadow(tblLid lid, bool OnlyFinancialEmail)
        {
            foreach (EmailAdresLid e in lid.EmailAdresses)
            {
                if (OnlyFinancialEmail && !e.FinancialMail) continue; // we willen alleen de fin.email adressesn en dit is er geen dan niet toevoegen
                if (string.IsNullOrEmpty(e.EmailAddress.Trim())) continue;
                clbLeden.Items.Add(e.EmailWithDisplayName, true); //lid.Gemerkt);
                ledenSchaduwlijst.Add(lid);
            }
        }


        #region versturen van de mail --> DoSomeWork
        private void DoSomeWork(object status)
        {
            errorList = new StringBuilder();
            errorMail = false;
            string sSource =  "MultiMail";
            string sLog = "Application";

            errorList.AppendLine("Email not sent to:");
            IProgressCallback callback = status as IProgressCallback;
            try
            {
                callback.Begin(0, clbLeden.CheckedItems.Count + clbExtraEmail.CheckedItems.Count);

                SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                    EmailLogFile, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, callback.SetText);

                MailMessage message = new MailMessage();
                message.Subject = txtSubject.Text;
                message.From = new MailAddress(param.EmailReturnAdress);
                message.ReplyToList.Add(param.EmailReturnAdress);
                message.IsBodyHtml = ckbHtml.Checked;
                string messid = string.Format("<{0}@{1}>", Guid.NewGuid().ToString(), "wwww.ttvn.nl");
                message.Headers.Add("Message-Id", messid);

                string strBody = string.Empty;
                if (ckbHtml.Checked)
                    strBody = string.Format(@"<html><head><meta http-equiv=Content-Type content=""text/html; charset=us-ascii""></head>{0}</html>", htmlTextbox1.Text);
                else
                    strBody = htmlTextbox1.PlainText;

                if (txtBijlage1.Text != string.Empty)
                {
                    //emailer.Attachments.Add(new SmtpAttachment(txtBijlage1.Text));
                    message.Attachments.Add(new Attachment(txtBijlage1.Text));
                }
                if (txtBijlage2.Text != string.Empty)
                {
                    //emailer.Attachments.Add(new SmtpAttachment(txtBijlage2.Text));
                    message.Attachments.Add(new Attachment(txtBijlage2.Text));

                }
                if (txtBijlage3.Text != string.Empty)
                {
                    //emailer.Attachments.Add(new SmtpAttachment(txtBijlage3.Text));
                    message.Attachments.Add(new Attachment(txtBijlage3.Text));
                }

                for (int i = 0; i < clbLeden.Items.Count; i++)
                {
                    if (!clbLeden.GetItemChecked(i)) continue;

                    message.To.Clear();
                    message.To.Add(clbLeden.Items[i].ToString());
                    message.Body = MailRoutines.ReplaceKeyWords(strBody, ledenSchaduwlijst[i], param);
                    

                    
                    //emailer.To.Clear();
                    //emailer.To.Add(clbLeden.Items[i].ToString());
                    //emailer.Body = MailRoutines.ReplaceKeyWords(strBody, ledenSchaduwlijst[i], param);
                    try
                    {
                        //emailer.SendMessage();
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        try
                        {
                            if (!EventLog.SourceExists("MultiMail"))
                                EventLog.CreateEventSource(sSource, sLog);

                            EventLog.WriteEntry(sSource, ex.Message + @"/n" + message.Body,
                                EventLogEntryType.Warning, 001);
                        }
                        catch(Exception ex2)
                        {
                            GuiRoutines.ExceptionMessageBox(this, ex);
                            Console.WriteLine(ex2.ToString());
                        }
                        errorMail = true;
                        errorList.AppendLine(clbLeden.Items[i].ToString());
                    }
                    callback.Increment(1);
                    callback.SetText(clbLeden.Items[i].ToString());
                    System.Threading.Thread.Sleep(50);
                    if (callback.IsAborting) return;
                }


                for (int i = 0; i < clbExtraEmail.Items.Count; i++)
                {
                    if (!clbExtraEmail.GetItemChecked(i)) continue;

                    message.To.Clear();
                    message.To.Add(clbExtraEmail.Items[i].ToString());
                    message.Body = MailRoutines.ReplaceKeyWords(strBody, new tblLid(), param);

                    try
                    {
                        client.Send(message);
                    }
                    catch(Exception ex)
                    {
                        try
                        {
                            if (!EventLog.SourceExists("MultiMail"))
                                EventLog.CreateEventSource(sSource, sLog);
                            EventLog.WriteEntry(sSource, ex.Message,
                                EventLogEntryType.Warning, 001);
                        }
                        catch { }

                        errorMail = true;
                        errorList.AppendLine(clbExtraEmail.Items[i].ToString());
                    }
                    callback.Increment(1);
                    callback.SetText(clbExtraEmail.Items[i].ToString());
                    System.Threading.Thread.Sleep(50);
                    if (callback.IsAborting) return;
                }

                callback.WaitOK();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                // We want to exit gracefully here (if we're lucky)
                try
                {
                    if (!EventLog.SourceExists("MultiMail"))
                        EventLog.CreateEventSource(sSource, sLog);
                    EventLog.WriteEntry(sSource, ex.Message,
                        EventLogEntryType.Warning, 001);
                }
                catch { }

            }
            catch (System.Threading.ThreadInterruptedException ex)
            {
                // And here, if we can
                try
                {
                    if (!EventLog.SourceExists("MultiMail"))
                        EventLog.CreateEventSource(sSource, sLog);
                    EventLog.WriteEntry(sSource, ex.Message,
                        EventLogEntryType.Warning, 001);
                }
                catch { }

            }
            catch (Exception ex)
            {
                try
                {
                    if (!EventLog.SourceExists("MultiMail"))
                        EventLog.CreateEventSource(sSource, sLog);
                    EventLog.WriteEntry(sSource, ex.Message,
                        EventLogEntryType.Warning, 001);
                }
                catch { }

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


        #endregion

        #region Buttons and Keypress
        ProgressWindow progress;
        private void cmdVerstuurMail_Click(object sender, EventArgs e)
        {
            if (txtSubject.Text == string.Empty)
            {
                MessageBox.Show("Onderwerp is leeg", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (clbLeden.CheckedItems.Count == 0)
            {
                MessageBox.Show("Geen geselecteerde email adressen", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            progress = new ProgressWindow();
            progress.Text = "Emailing";
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(DoSomeWork), progress);
            progress.ShowDialog();
            if (errorMail)
                ShowText.Show(errorList.ToString(), "Failed Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdGetMail_Click(object sender, EventArgs e)
        {
            mailFileName = GuiRoutines.GetOpenFileName(openFileDialog1, "htm*");
            if (mailFileName == string.Empty) return;
            StreamReader sr = File.OpenText(mailFileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            htmlTextbox1.Text = str.ReadToEnd();
            sr.Close();
            sr.Dispose();
        }

        private void cmdSaveMail_Click(object sender, EventArgs e)
        {
            mailFileName = GuiRoutines.GetSaveFileName(saveFileDialog1, "htm", mailFileName);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "LastUsedEmail", mailFileName);
            StreamWriter sw = new StreamWriter(mailFileName);
            sw.Write(htmlTextbox1.Text);
 
            sw.Close();
        }

        private void lblBijlage1_Click(object sender, EventArgs e)
        {
            txtBijlage1.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        private void lblBijlage2_Click(object sender, EventArgs e)
        {
            txtBijlage2.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        private void lblBijlage3_Click(object sender, EventArgs e)
        {
            txtBijlage3.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (clbLeden.ContainsFocus)
            {
// A
                if (keyData == Keys.A)
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// J
                if (keyData == Keys.J)
                {
                    ledenSchaduwlijst = new LedenLijst();
                    clbLeden.Items.Clear();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_WLP_PUP_CAD_JUN_SEN1 && !lid.IsSEN1) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// CONTROL J                
                if (keyData == (Keys.Control | Keys.J))
                {
                    ledenSchaduwlijst = new LedenLijst();
                    clbLeden.Items.Clear();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_WLP_PUP_CAD_JUN_SEN1) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// S                
                if (keyData == Keys.S)
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_SEN1_65_SEN) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// CTRL A
                if (keyData == (Keys.Control | Keys.A))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.IsLicentieA) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// CTRL B
                if (keyData == (Keys.Control | Keys.B))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.IsLicentieB) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// N                
                if (keyData == Keys.N)
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.BondsNr != string.Empty) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// SHIFT N
                if (keyData == (Keys.Shift | Keys.N))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_SEN1_65_SEN && lid.BondsNr != string.Empty) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// CTRL N
                if (keyData == (Keys.Control | Keys.N))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_WLP_PUP_CAD_JUN_SEN1 &&  lid.BondsNr != string.Empty) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// C                
                if (keyData == Keys.C)
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.CompGerechtigd) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// SHIFT C
                if (keyData == (Keys.Shift | Keys.C))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_SEN1_65_SEN && lid.CompGerechtigd) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }
// CTRL C
                if (keyData == (Keys.Control | Keys.C))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.Is_WLP_PUP_CAD_JUN_SEN1 && lid.CompGerechtigd) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }

// CONTROL R
                if (keyData == (Keys.Control | Keys.R))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.IsRanglijstSpeler) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }

// CONTROL T
                if (keyData == (Keys.Control | Keys.T))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.IsToernooiSpeler || lid.IsRanglijstSpeler) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }

// V
                if (keyData == (Keys.V))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.VrijwillgersVasteTaak) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }

// SHIFT V
                if (keyData == (Keys.Shift | Keys.V))
                {
                    clbLeden.Items.Clear();
                    ledenSchaduwlijst = new LedenLijst();
                    foreach (tblLid lid in leden)
                    {
                        if (lid.VrijwillgersRegelingIsVanToepassing) AddEmailToComboAndShadow(lid, false);
                    }
                    return true;
                }

            }
            if (txtExtraEmail.ContainsFocus)
            {
                if (keyData == (Keys.Enter))
                {
                    //mostRecentlyUsed.Add(txtExtraEmail.Text);
                    //mostRecentlyUsed.MoveToTop(txtExtraEmail.Text);
                    //mostRecentlyUsed.SaveList();
                    //mostRecentlyUsed.BuildMenu(clbExtraEmail);
                    clbExtraEmail.Items.Add(txtExtraEmail.Text);
                    return true;
                }
            }
            if (clbExtraEmail.ContainsFocus)
            {
                if (keyData == (Keys.Delete))
                {
                    for (int i = 0; i < clbExtraEmail.Items.Count; i++)
                    {
                        if (!clbExtraEmail.GetItemChecked(i))
                        {
                            string s = clbExtraEmail.Items[i].ToString();
                            clbExtraEmail.Items.Remove(s);
//                            mostRecentlyUsed.Remove(s);
                        }
                    }
                    //mostRecentlyUsed.SaveList();
                    return true;
                }
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdToelichting_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string filename = PersistControlValue.ReadLocalAppSetting("HelpMultiMailFile", "FileName");
            if (filename == string.Empty || !File.Exists(filename))
            {
                filename = Util.Forms.GuiRoutines.GetOpenFileName(openFileDialog1, "htm");
                PersistControlValue.SaveLocalAppSetting("HelpMultiMailFile", "FileName", filename);
            }
            if (filename != string.Empty)
                // Opstarten browser
                System.Diagnostics.Process.Start(filename);
            this.Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Added to copy text from clipboard. This method only copies the text without formatting. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            htmlTextbox1.Text = Clipboard.GetText();
        }

        // Nodig om mru interface te implementeren.    
        void IMruUser.ItemSelected(object obj)
        {
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
        #endregion

        private void frmMultiMail_FormClosing(object sender, FormClosingEventArgs e)
        {
//            PersistControlValue.StoreControlValue(txtExtraEmail);
            param.mmtxtExtraEmail = new List<string>();
            foreach (string s in clbExtraEmail.Items)
                param.mmtxtExtraEmail.Add(s);

        }

    }

}
