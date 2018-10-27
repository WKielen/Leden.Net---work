using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Util.Email;
using Util.Forms;
using Util.MySQL;
using Newtonsoft.Json;
using System.Net;

namespace Leden.Net
{
    public partial class frmLeden : frmBasis , IMruUser
    {
        private MosaicMru mostRecentlyUsed;
        private DataAdapters da = null;
        tblLid _isNewLid = null;
        bool _scrollen = true;
        string fileNameConfig = "../Leden.Parameters.Json.config";
        LedenLijst leden;

        public frmLeden()
        {
            try
			{
				SplashForm sf = new SplashForm("Leden.Net", "Leden administratie", 2);
				sf.Show();
				sf.Refresh();
				//
				// Required for Windows Form Designer support
				//
                InitializeComponent();
 
               this.SuspendLayout();	
                // Window persistance
				mostRecentlyUsed = new MosaicMru(this, "Leden.Net");
                _windowState = new PersistWindowState(this, @"Leden\Leden");
                try
                {
                    StreamReader sr = new StreamReader(fileNameConfig);
                    string x = sr.ReadLine();
                    if (x != string.Empty)
                        param = JsonConvert.DeserializeObject<tblParameters>(x);
                    else
                        param = new tblParameters();   // nodig voor intialisatie
                }
                catch
                {
                    param = new tblParameters();
                }

                // Het most recent used lijstje onder het file menu
				mostRecentlyUsed.ItemsSaveLimit = 10;
				mostRecentlyUsed.ItemsAreFiles = true;
				mostRecentlyUsed.BuildMenu(mnuFileFiles);

				GuiRoutines.SetFlatStyle(this.Controls);				
 
                // We vangen het Event op als er van team wordt gewijzigd.
                cboLeden.Changed += new ChangedEventHandler(Position_Changed);
                
                // vullen de combo boxen
                cboLidType.Items.AddRange(tblLid.LidTypeDescriptions);
                cboBetaalwijze.Items.AddRange(tblLid.BetaalWijzeDescriptions);

                LockPanel(true);

                this.ResumeLayout(true);
				sf.Dispose();

			}
			catch (Exception ex)
			{
				GuiRoutines.ShowMessage(ex);
			}
		}

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new frmLeden());
        }

        #region MRU...

        // er is een mru gekozen. Open nu deze file
        void IMruUser.ItemSelected(object obj)
        {
            OpenFile(obj as string);
        }
        #endregion

        string fileName = string.Empty;
        private void frmLeden_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            fileName = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "DatabaseFileName");
            // als het programma voor het eerst start laat dat het open file menu zien
            if (fileName == string.Empty)
            {
                mnuFileOpen.PerformClick();
            }
            else
            {
                OpenFile(fileName);
                mostRecentlyUsed.Add(fileName);
                mostRecentlyUsed.MoveToTop(fileName);
                mostRecentlyUsed.SaveList();
                mostRecentlyUsed.BuildMenu(mnuFileFiles);
            }
            this.Text = "Leden " + param.ClubNameLong;
            this.Cursor = Cursors.Arrow;
        }
        #region postiotion changed
        /// <summary>
        /// Er is een nieuw lid geselecteerd vanuit de combobox. Laat dit nieuwe lid zien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Position_Changed(object sender, System.EventArgs e)
        {
            tblLid lid = leden[cboLeden.SelectedIndex];
            sbpRecordNr.Text = String.Concat(cboLeden.SelectedIndex + 1, "/", leden.Count);
            txtLidNr.Text = lid.LidNr.ToString();
            txtVoornaam.Text = lid.Voornaam;
            txtAchternaam.Text = lid.Achternaam;
            txtTussenvoegsel.Text = lid.Tussenvoegsel;
            txtAdres.Text = lid.Adres;
            txtWoonplaats.Text = lid.Woonplaats;
            txtPostcode.Text = lid.Postcode;
            txtMobiel.Text = lid.Mobiel;
            txtTelefoon.Text = lid.Telefoon;
            txtBondsNr.Text = lid.BondsNr;
            if (lid.Geslacht == "M") rbuM.Checked = true; else rbuV.Checked = true;
            dtpGeboorteDatum.Value = lid.GeboorteDatum;
            txtEmail1.Text = lid.Email1;
            txtEmail2.Text = lid.Email2;
            txtIBAN.Text = lid.IBAN;
            txtBIC.Text = lid.BIC;
            cboBetaalwijze.SelectedIndex = lid.ItemNr_From_To_BetaalWijze;
            ckbLidBond.Checked = lid.LidBond;
            ckbCompGerechtigd.Checked = lid.CompGerechtigd;
            cboLidType.SelectedIndex = lid.ItemNr_From_To_LidType;
            dtpLidVanaf.Value = lid.LidVanaf;
            ckbOpgezegd.Checked = lid.Opgezegd;
            dtpLidTot.Value = lid.LidTot;
            txtU_PasNr.Text = lid.U_PasNr;
            dtpPakketTot.Value = lid.PakketTot;
            txtVastBedrag.ToFromDecimal = lid.VastBedrag;
            txtKorting.ToFromDecimal = lid.Korting;
            ckbVrijwKorting.Checked = lid.VrijwillgersRegelingIsVanToepassing;
            ckbVrijwAfgekocht.Checked = lid.VrijwillgersAfgekocht;
            ckbVrijwVasteTaak.Checked = lid.VrijwillgersVasteTaak;

            rtbMemo.Text = lid.Medisch;
            ckbGemerkt.Checked = lid.Gemerkt;
            ckbGeincasseerd.Checked = lid.Geincasseerd;
            txtOuder1_Naam.Text = lid.Ouder1_Naam;
            txtOuder1_Email1.Text = lid.Ouder1_Email1;
            txtOuder1_Email2.Text = lid.Ouder1_Email2;
            txtOuder1_Mobiel.Text = lid.Ouder1_Mobiel;
            txtOuder1_Telefoon.Text = lid.Ouder1_Telefoon;
            txtOuder2_Naam.Text = lid.Ouder2_Naam;
            txtOuder2_Email1.Text = lid.Ouder2_Email1;
            txtOuder2_Email2.Text = lid.Ouder2_Email2;
            txtOuder2_Mobiel.Text = lid.Ouder2_Mobiel;
            txtOuder2_Telefoon.Text = lid.Ouder2_Telefoon;
            
            grpOuder2.Visible = (lid.Ouder2_Naam != string.Empty || lid.Ouder2_Email1 != string.Empty || lid.Ouder2_Mobiel != string.Empty || lid.Ouder2_Telefoon != string.Empty);

            txtLicJun.Text = lid.LicentieJun;
            txtLicSen.Text = lid.LicentieSen;

            // Vul het type toernooi speler goed
            if (lid.IsRanglijstSpeler)
            {
                ckbToernooi.Checked = true;
                ckbRanglijst.Checked = true;
            }
            else
                if (lid.IsToernooiSpeler)
                {
                    ckbToernooi.Checked = true;
                    ckbRanglijst.Checked = false;
                }
                else
                {
                    ckbToernooi.Checked = false;
                    ckbRanglijst.Checked = false;
                }

            sbpStatusMessage.Text = string.Empty;

            // Controleer of het tijd wordt een pakket lid om te zetten naar een gewoon lid.
            if (lid.IsLidPakket && lid.PakketTot < DateTime.Now)
                cboLidType.ForeColor = Color.Red;
            else
                cboLidType.ForeColor = Color.Black;
        }
        #endregion

        #region Miscellaneous
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            GuiRoutines.ShowMessage(e.Exception);
        }

        Semi_TransparentPanel cusPanel = new Semi_TransparentPanel();

        private void LockPanel(bool activate)
        {
            if (activate)
            {
                cusPanel.Dock = DockStyle.Fill;
                pnlDetails.Controls.Add(cusPanel);
                cusPanel.BringToFront();
            }
            else
            {
                pnlDetails.Controls.Remove(cusPanel);
            }
        }

        /// <summary>
        /// Met de mousewheel kunnen we ook door de leden scrollen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseWheel_Event(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (_scrollen)
            {
                if (e.Delta > 0)
                    cboLeden.Previous();
                else
                    cboLeden.Next();
            }
        }

        #endregion

        #region Menu item handling
        /// <summary>
        /// Menu item om database te openen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            string newName = Util.Forms.GuiRoutines.GetOpenFileName(openFileDialog1, "mdb");
            if (newName != string.Empty)
            {
                OpenFile(newName);
                mostRecentlyUsed.Add(newName);
                mostRecentlyUsed.MoveToTop(newName);
                mostRecentlyUsed.SaveList();
                mostRecentlyUsed.BuildMenu(mnuFileFiles);
            }

            fileName = newName;
        }

        /// <summary>
        /// Open een nieuwe database
        /// </summary>
        /// <param name="fileNameLocal"></param>
        private void OpenFile(string fileNameLocal)
        {
            try
            {
                sbpFileName.Text = fileNameLocal;
                if (cnLeden.State != System.Data.ConnectionState.Closed)
                    cnLeden.Close();
            
                cnLeden.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;"
                    //							+ @"Password=;User ID=Admin;"
                    + @"Data Source=" + fileNameLocal;
               #region Database connection
            //							+ @";Mode=Share Deny None;Extended Properties=;Jet OLEDB:System database=;"
            //							+ @"Jet OLEDB:Registry Path=;Jet OLEDB:Database Password=;Jet OLEDB:Engine Type=5;"
            //							+ @"Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;"
            //							+ @"Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password=;"
            //							+ @"Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;"
            //							+ @"Jet OLEDB:Don't Copy Locale on Compact=False;"
            //							+ @"Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
            #endregion
                ;
                da = new DataAdapters();
                da.Connection = cnLeden;

                // Vul ledenlijst en sorteer op naam
                leden = da.VulLedenLijst();
                // vul main combobox
                cboLeden.Load(leden);
                // vul de resultaten en rekeningen
                fileName = fileNameLocal;

                this.Cursor = Cursors.Arrow;
			}
			catch (Exception ex)
			{
				GuiRoutines.ShowMessage(ex);
			}
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void overzichtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmRekeningOverzicht2(da, leden).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void aanmakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmContributieAanmaken(da, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
        private void versturenAankondigingenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmAankondiging(da, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
        private void handmatigAanmakenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmEenmaligeRekening(da, leden).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void incassoKandidatenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmIncassoInhoud2(da).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
         }

        private void versturenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmIncassoBestand2(da, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void verstuurdeVerwijderenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Verzonden rekeningen Verwijderen?", "Verwijderen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            int nbr = 0;
            if (dr == DialogResult.Yes)
            {
                RekeningenLijst rekeningen = da.VulRekeningRecords();
                for (int i=rekeningen.Count-1; i >= 0; i--)
                {
                    if (rekeningen[i].Verstuurd)
                    {
                        da.DeleteRekening(rekeningen[i]);
                        rekeningen.RemoveAt(i);
                        nbr++;
                    }
                }
                da.CommitTransaction(true);
                MessageBox.Show(nbr.ToString() + " rekeningen verwijderd", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void aanmakenToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new frmEenmaligeBetaling(da).ShowDialog();
        }

        private void aanmakenBetalingenBestandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBetalingenBestand(da).ShowDialog();
        }

        private void debiteutenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmCrediteuren(da).ShowDialog();
        }
        
        private void overzichtTeBetalenRekeningenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmBetalingInhoud(da).ShowDialog();
        }
        
        private void aanmaakVCARDBestandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmVCard(da).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void exportNaarCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmExportLijsten(da, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
        
        private void aanmaakOutputForMailProgrammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmExportForMail(da, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
        
        private void mailVersturenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmMultiMail(leden, param, null, string.Empty).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void versturenUPasMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LedenLijst upasLeden = new LedenLijst();
            foreach (tblLid lid in leden)
            {
                if (lid.BetaalWijze == tblLid.constBetwUPas)
                {
                    lid.Gemerkt = true;
                    upasLeden.Add(lid);
                }
            }

            try
            {
                new frmMultiMail(upasLeden, param, "UPasVraag", @"U-Pasnummer en 'pincode' i.v.m. contributie " + param.ClubNameShort).ShowDialog();
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            
            this.Cursor = Cursors.Arrow; ;
        }

        private void configuratieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmParameters(param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void compResulatenJeugdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmCompResult2(da).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void vergelijkMetNASToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmCompareNAS(da).ShowDialog();
            leden = da.VulLedenLijst();
            cboLeden.RefreshCurrent();
            this.Cursor = Cursors.Arrow; ;
        }

        private void toernooienBondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmLedenOverzicht1(da, tblParameters.LedenLijstType.Toernooien).ShowDialog();
            leden = da.VulLedenLijst();
            cboLeden.RefreshCurrent();
            this.Cursor = Cursors.Arrow; ;
        }

        private void vrijwilligersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmLedenOverzicht1(da, tblParameters.LedenLijstType.Vrijwilligers).ShowDialog();
            leden = da.VulLedenLijst();
            cboLeden.RefreshCurrent();
            this.Cursor = Cursors.Arrow; ;
        }
        private void legeLijstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmLedenOverzicht1(da, tblParameters.LedenLijstType.Selected).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LedenLijst localLeden = da.VulLedenLijst(true);
            ResultatenLijst resultaten = da.VulCompResultRecords();
            RekeningenLijst rekeningen = da.VulRekeningRecords();
            CrediteurenLijst crediteuren = da.VulCrediteurenRecords();
            BetalingenLijst betalingen = da.VulBetalingRecords();

            string filename = param.LocationLogFiles + @"\Backup_Leden_" + DateTime.Now.ToString("yyyyMMdd") + ".xml";
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(LedenLijst));
                s.Serialize(fs, localLeden);
            }
            string filename2 = filename + "1";
            using (FileStream fs = new FileStream(filename2, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(RekeningenLijst));
                s.Serialize(fs, rekeningen);
            }
            filename2 = filename + "2";
            using (FileStream fs = new FileStream(filename2, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(ResultatenLijst));
                s.Serialize(fs, resultaten);
            }
            filename2 = filename + "3";
            using (FileStream fs = new FileStream(filename2, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(CrediteurenLijst));
                s.Serialize(fs, crediteuren);
            }
            filename2 = filename + "4";
            using (FileStream fs = new FileStream(filename2, FileMode.Create))
            {
                XmlSerializer s = new XmlSerializer(typeof(BetalingenLijst));
                s.Serialize(fs, betalingen);
            }
            MessageBox.Show("Backup aangemaakt. \n" + filename);
        }

        private void inlezenBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bij inlezen backup gaan huidige gegevens verloren! \nMaak eerst een copy van de database (*.mdb) voordat je verder gaat! \nDoorgaan?", "Backup Inlezen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                return;
            }
            // Lees de drie XML files en vul de List's
            ResultatenLijst resultaten = new ResultatenLijst();
            RekeningenLijst rekeningen = new RekeningenLijst();
            CrediteurenLijst crediteuren = new CrediteurenLijst();
            BetalingenLijst betalingen = new BetalingenLijst();

            string filename = Util.Forms.GuiRoutines.GetOpenFileName(openFileDialog1, "xml");

            if (filename == string.Empty) return;

            using (StreamReader sr = File.OpenText(filename))
            {
                leden = new LedenLijst();
                using (TextReader tr = new StringReader(sr.ReadToEnd()))
                {
                    XmlSerializer s = new XmlSerializer(typeof(LedenLijst));
                    leden = (LedenLijst)s.Deserialize(tr);
                }
            }
            foreach (tblLid lid in leden)
            {
                lid.Dirty = true;
            }

            string filename2 = filename + "1";
            using (StreamReader sr = File.OpenText(filename2))
            {
                rekeningen = new RekeningenLijst();
                using (TextReader tr = new StringReader(sr.ReadToEnd()))
                {
                    XmlSerializer s = new XmlSerializer(typeof(RekeningenLijst));
                    rekeningen = (RekeningenLijst)s.Deserialize(tr);
                    foreach (tblRekening rekening in rekeningen)
                    {
                        rekening.Lid = leden.GetLidByLidNr(rekening.LidNr);
                    }
                }
            }

            filename2 = filename + "2";
            using (StreamReader sr = File.OpenText(filename2))
            {
                resultaten = new ResultatenLijst();
                using (TextReader tr = new StringReader(sr.ReadToEnd()))
                {
                    XmlSerializer s = new XmlSerializer(typeof(ResultatenLijst));
                    resultaten = (ResultatenLijst)s.Deserialize(tr);
                }
                foreach (tblCompResult resultaat in resultaten)
                {
                    resultaat.Lid = leden.GetLidByLidNr(resultaat.LidNr);
                }
            }

            filename2 = filename + "3";
            using (StreamReader sr = File.OpenText(filename2))
            {
                crediteuren = new CrediteurenLijst();
                using (TextReader tr = new StringReader(sr.ReadToEnd()))
                {
                    XmlSerializer s = new XmlSerializer(typeof(CrediteurenLijst));
                    crediteuren = (CrediteurenLijst)s.Deserialize(tr);
                }
                foreach (tblCrediteur crediteur in crediteuren)
                {
                    crediteur.Dirty = true;
                }
            }

            filename2 = filename + "4";
            using (StreamReader sr = File.OpenText(filename2))
            {
                betalingen = new BetalingenLijst();
                using (TextReader tr = new StringReader(sr.ReadToEnd()))
                {
                    XmlSerializer s = new XmlSerializer(typeof(BetalingenLijst));
                    betalingen = (BetalingenLijst)s.Deserialize(tr);
                }
                foreach (tblBetaling betaling in betalingen)
                {
                    betaling.Dirty = true;
                }
            }

            // Leeg de Database
            da.DeleteAlleCompResults();
            da.DeleteAlleRekeningen();
            da.DeleteAlleLeden();
            da.DeleteAlleCrediteurs();
            da.DeleteAlleBetalingen();

            // Vul de Database (alle records zijn al Dirty gemaakt bij het inlezen)
            da.UpdateLeden(leden);
            da.UpdateRekeningen(rekeningen);
            da.UpdateCompResulten(resultaten);
            da.UpdateCrediteuren(crediteuren);
            da.UpdateBetalingen(betalingen);
            da.CommitTransaction(true);
            
            cboLeden.Load(leden);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new AboutBox(this).ShowDialog(this);
            this.Cursor = Cursors.Arrow; ;
        }
        
        private void toonOuder2BlokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpOuder2.Visible = true;
        }

        #endregion

        #region Button commands
        private void cmdSelectForm_Click(object sender, EventArgs e)
        {
            frmSelectLeden frm = new frmSelectLeden(leden);
            frm.ShowDialog();
            da.UpdateLeden(leden);
            da.CommitTransaction(true);

            cboLeden.RefreshCurrent();
        }

        private void cmdSendEmail_Click(object sender, EventArgs e)
        {
            new frmMultiMail(leden[cboLeden.SelectedIndex], param, null, string.Empty).ShowDialog();
        }
        
        private void btnFirst_Click(object sender, EventArgs e)
        {
            cboLeden.First();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            cboLeden.Previous();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            cboLeden.Next();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            cboLeden.Last();
        }

        private void lblLidNr_Click(object sender, EventArgs e)
        {
            new PropertyGridForm(leden[cboLeden.SelectedIndex]).Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (txtSearch.Focused && ((keyData == Keys.Enter) || (keyData == Keys.Return)))
            {
                if (txtSearch.Text == string.Empty) return false;
                bool found = false;
                tblLid lid = null;
                int j = cboLeden.SelectedIndex + 1;
                for (int i = j; i < leden.Count; i++)
                {
                    lid = leden[i];
                    if (lid.VolledigeNaam.ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    for (int i = 0; i < j; i++)
                    {
                        lid = leden[i];
                        if (lid.VolledigeNaam.ToLower().Contains(txtSearch.Text.ToLower()))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    cboLeden.SelectRecord(lid.VolledigeNaam);
                }
                return true;
            }
            
            switch (keyData)
            {
                case (Keys.Control | Keys.Z): testroutine();
                    return true;
                case (Keys.Control | Keys.H): new frmHelp(this).ShowDialog();
                    return true;
                case (Keys.Control | Keys.A): new frmNotes().ShowDialog();
                    return true;
                case (Keys.Control | Keys.F): txtSearch.Focus();
                    return true;
                case (Keys.PageDown):
                    if (_scrollen)
                        cboLeden.Next();
                    return true;
                case (Keys.PageUp):
                    if (_scrollen)
                        cboLeden.Previous();
                    return true;
                case (Keys.Control | Keys.Space): new frmBetalingenBestand(da).ShowDialog();
                    return true;
                case (Keys.Control | Keys.Shift | Keys.Space): new frmEenmaligeBetaling(da).ShowDialog();
                    return true;
                case (Keys.Control | Keys.L): Process.Start("explorer.exe", param.LocationLogFiles);
                    return true;
                
                case (Keys.Control | Keys.B):
                    sbpStatusMessage.Text = "Bondsnr: " + ToClipBoard(txtBondsNr) + " gekopieerd naar klipbord";
                    return true;
                case (Keys.Control | Keys.T): 
                    sbpStatusMessage.Text = "Telefoonnr : " + ToClipBoard(txtTelefoon) + " gekopieerd naar klipbord";
                    return true;
                case (Keys.Control | Keys.M): 
                    sbpStatusMessage.Text = "Telefoonnr : " + ToClipBoard(txtMobiel) + " gekopieerd naar klipbord";
                    return true;
                case (Keys.Control | Keys.E): 
                    sbpStatusMessage.Text = "Email : " + ToClipBoard(txtEmail1) + " gekopieerd naar klipbord";
                    return true;

                case (Keys.Control | Keys.Shift | Keys.T):
                    sbpStatusMessage.Text = "Telefoonnr : " + ToClipBoard(txtOuder1_Telefoon) + " gekopieerd naar klipbord";
                    return true;
                case (Keys.Control | Keys.Shift | Keys.M): 
                    sbpStatusMessage.Text = "Telefoonnr : " + ToClipBoard(txtOuder1_Mobiel) + " gekopieerd naar klipbord";
                    return true;
                case (Keys.Control | Keys.Shift | Keys.E): 
                    sbpStatusMessage.Text = "Email : " + ToClipBoard(txtOuder1_Email1) + " gekopieerd naar klipbord";
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public string ToClipBoard(TextBox box)
        {
            if (box != null && box.Text != null && box.Text != string.Empty)
            {
                Clipboard.SetText(box.Text.Trim());
                return box.Text.Trim();
            }
            return "Niets";
        }

        private void cmdRekeningen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmRekeningOverzicht2(da, leden[cboLeden.SelectedIndex]).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            string x = JsonConvert.SerializeObject(param);
            StreamWriter sr = new StreamWriter(fileNameConfig);
            sr.WriteLine(x);
            sr.Close();
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Shift) != Keys.Shift)
            {

                tblLid lid = da.CreateLidRecord();
                leden.Add(lid);
                cboLeden.AddRecord(lid);
                cboLeden.SelectRecord(lid.VolledigeNaam);
                _isNewLid = lid;
                sbpStatusMessage.Text = "Nieuw Lid";
                cmdChange.PerformClick();
            }
            else
            {
                // Onderstaande code is dubbel. Dit moet worden verbeterd.
                tblLid lid = leden[cboLeden.SelectedIndex];
                List<string> attach = new List<string>();
                attach.Add(param.BijlageInfoFolder);
                attach.Add(param.BijlageReglement);
                attach.Add(param.BijlageStatuten);

                frmMultiMail frm = new frmMultiMail(lid, param, "NieuwLid", "Inschrijving " + param.ClubNameShort, attach);

                frm.ShowDialog();
                _isNewLid = null;
            }
        }

        private void SetChangeMode(bool changemode)
        {
            cmdSave.Visible = changemode;
            cmdCancel2.Visible = changemode;
            cmdNew.Visible = !changemode;
            cmdChange.Visible = !changemode;
            LockPanel(!changemode);
            _scrollen = !changemode;
            pnlButtons.Enabled = !changemode;
            cmdSelectForm.Enabled = !changemode;
            cmdTTKaart.Enabled = !changemode;
            cmdRekeningen.Enabled = !changemode;
            cmdSendEmail.Enabled = !changemode;
            Exit.Enabled = !changemode;
        }

        private void cmdChange_Click(object sender, EventArgs e)
        {
            SetChangeMode(true); 
        }
        /// <summary>
        /// Saves the field on the form to the lid instance
        /// </summary>
        /// <param name="sender">The parent form</param>
        /// <param name="e">EventArgs</param>
        /// <returns>
        /// <i>count</i> characters from the left of <i>str</i> if available. If the length of <i>str</i> is
        /// smaller than <i>count</i>, str will be returned. If <i>str</i> is <c>null</c>, the length of <i>str</i> is 0,
        /// or <i>count</i> is 0, than <c>String.Empty</c> is returned.
        /// </returns>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SetChangeMode(false);

            tblLid lid = leden[cboLeden.SelectedIndex];
            lid.LidNr = Convert.ToInt32(txtLidNr.Text);
            lid.Voornaam = txtVoornaam.Text;
            lid.Achternaam = txtAchternaam.Text;
            lid.Tussenvoegsel = txtTussenvoegsel.Text;
            lid.Adres = txtAdres.Text;
            lid.Woonplaats = txtWoonplaats.Text;
            lid.Postcode = txtPostcode.Text;
            lid.Mobiel = txtMobiel.Text;
            lid.Telefoon = txtTelefoon.Text;
            lid.BondsNr = txtBondsNr.Text;
            lid.Geslacht = rbuM.Checked ? "M" : "V";
            lid.GeboorteDatum = dtpGeboorteDatum.Value;
            lid.Email1 = txtEmail1.Text;
            lid.Email2 = txtEmail2.Text;
            lid.IBAN = txtIBAN.Text;
            lid.BIC = txtBIC.Text;
            lid.ItemNr_From_To_BetaalWijze = cboBetaalwijze.SelectedIndex;
            lid.LidBond = ckbLidBond.Checked;
            lid.CompGerechtigd = ckbCompGerechtigd.Checked;
            lid.ItemNr_From_To_LidType = cboLidType.SelectedIndex;
            lid.LidVanaf = dtpLidVanaf.Value;
            lid.Opgezegd = ckbOpgezegd.Checked;
            lid.LidTot = dtpLidTot.Value;
            lid.U_PasNr = txtU_PasNr.Text;
            lid.PakketTot = dtpPakketTot.Value;
            lid.VastBedrag = txtVastBedrag.ToFromDecimal;
            lid.Korting = txtKorting.ToFromDecimal;
            lid.VrijwillgersRegelingIsVanToepassing = ckbVrijwKorting.Checked;
            lid.VrijwillgersAfgekocht = ckbVrijwAfgekocht.Checked;
            lid.VrijwillgersVasteTaak = ckbVrijwVasteTaak.Checked;
            lid.Medisch = rtbMemo.Text;
            lid.Gemerkt = ckbGemerkt.Checked;
            lid.Geincasseerd = ckbGeincasseerd.Checked;
            lid.Ouder1_Naam = txtOuder1_Naam.Text;
            lid.Ouder1_Email1 = txtOuder1_Email1.Text;
            lid.Ouder1_Email2 = txtOuder1_Email2.Text;
            lid.Ouder1_Mobiel = txtOuder1_Mobiel.Text;
            lid.Ouder1_Telefoon = txtOuder1_Telefoon.Text;
            lid.Ouder2_Naam = txtOuder2_Naam.Text;
            lid.Ouder2_Email1 = txtOuder2_Email1.Text;
            lid.Ouder2_Email2 = txtOuder2_Email2.Text;
            lid.Ouder2_Mobiel = txtOuder2_Mobiel.Text;
            lid.Ouder2_Telefoon = txtOuder2_Telefoon.Text;
            lid.LicentieJun = txtLicJun.Text.Trim().ToUpper();
            lid.LicentieSen = txtLicSen.Text.Trim().ToUpper();

            if (ckbRanglijst.Checked)
                lid.IsRanglijstSpeler = true;
            else
                if (ckbToernooi.Checked)
                    lid.IsToernooiSpeler = true;
                else
                    lid.ToernooiSpeler = 0;

            cboLeden.Items[cboLeden.SelectedIndex] = lid.VolledigeNaam;

            // we passen de naam in de comboxbox aan.
            sbpStatusMessage.Text = "Wijziging opgeslagen";

            if (_isNewLid != null)
            {
                List<string> attach = new List<string>();
                attach.Add(param.BijlageInfoFolder);
                attach.Add(param.BijlageReglement);
                attach.Add(param.BijlageStatuten);

                frmMultiMail frm = new frmMultiMail(lid, param, "NieuwLid", "Inschrijving " + param.ClubNameShort, attach);

                frm.ShowDialog();
                _isNewLid = null;
            }

            if (ckbOpgezegd.Checked)
            {
                frmMultiMail frm = new frmMultiMail(lid, param, "Opzegging" ,"Opzegging lidmaatschap " + param.ClubNameShort, null);
                frm.ShowDialog();
            }

            da.UpdateLeden(leden);
            da.CommitTransaction(true);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetChangeMode(false);
            if (_isNewLid != null)
            {
                leden.Remove(_isNewLid);
                cboLeden.DeleteRecord(_isNewLid.VolledigeNaam);
                cboLeden.First();
                _isNewLid = null;
            }
            else
            {
                cboLeden.RefreshCurrent();
                cboLeden.Focus();
            }
        }
        private void cmdTTKaart_Click(object sender, EventArgs e)
        {
            if (txtBondsNr.Text != string.Empty)
                System.Diagnostics.Process.Start(@"http://ttkaart.nl/player_details.asp?text=" + txtBondsNr.Text);
        }


        #endregion
        
        #region Textbox Validating Methods

        private void txtBondsNr_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Control && e.KeyCode == Keys.V) { return; }
            if (e.Control && e.KeyCode == Keys.X) { return; }
            if (e.Control && e.KeyCode == Keys.C) { return; }

            if (e.Control || e.Alt || e.Shift) { e.SuppressKeyPress = true; return; }
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) return;
            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) return;
            if (e.KeyCode == Keys.Back) return;
            e.SuppressKeyPress = true;
        }

        private string RegExBondsNr  = "[0-9][0-9][0-9][0-9][0-9][0-9][0-9]";
        private string RegExPostcode = "^[1-9]{1}[0-9]{3}?[A-Z]{2}$";

        private void txtBondsNr_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(tb.Text, RegExBondsNr))
            {
                tb.Focus();
                MessageBox.Show("Invalid Bondsnr","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPostcode_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(tb.Text, RegExPostcode))
            {
                tb.Focus();
                MessageBox.Show("Invalid Postcode","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMobiel_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, true);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtTelefoon_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, false);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder1_Telefoon_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, false);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder1_Mobiel_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, true);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder2_Mobiel_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, true);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder2_Telefoon_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.TelephoneNumber.CheckPhoneNumber(tb.Text, false);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtIBAN_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.Iban.CheckIban(tb.Text, false);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtBIC.Text = Util.Bic.GetBicFromIban(tb.Text);
            }
        }

        private void txtEmail1_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtEmail2_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtBIC_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(tb.Text, RegExBic))
            {
                tb.Focus();
                MessageBox.Show("Invalid BIC","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtOuder1_Email1_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = Util.Email.CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder1_Email2_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder2_Email1_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtOuder2_Email2_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.Email.StatusData statusData = CheckEmail.CheckEmailAddress(tb.Text);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboLidType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            tblLid lid = leden[cboLeden.SelectedIndex];
            dtpPakketTot.Enabled = (cb.SelectedIndex == 3);
        }
        private void cboBetaalwijze_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            txtIBAN.Enabled = (cb.SelectedIndex != 1 && cb.SelectedIndex != 2);
            txtBIC.Enabled = (cb.SelectedIndex != 1 && cb.SelectedIndex != 2);
            ckbGeincasseerd.Enabled = (cb.SelectedIndex == 0);
            txtU_PasNr.Enabled = (cb.SelectedIndex == 2);
        }

        private void dtpGeboorteDatum_ValueChanged(object sender, EventArgs e)
        {
            tblLid lid = leden[cboLeden.SelectedIndex];
            lblLeeftijd.Text = DateRoutines.Age(dtpGeboorteDatum.Value).ToString();
            lblLeeftijdCategorie.Text = DateRoutines.LeeftijdCategorieBond(dtpGeboorteDatum.Value, true);
        }
        #endregion

        #region CheckBox Changed
        private void ckbSortLidNbr_CheckedChanged(object sender, EventArgs e)
        {
            string naam = cboLeden.Text;
            da.SortLedenOnNameWhenLoading = !ckbSortLidNbr.Checked;

            if (ckbSortLidNbr.Checked)
                leden.Sort(new LedenComparer("LidNr"));
            else
                leden.Sort(new LedenComparer());
            cboLeden.Load(leden);
            cboLeden.SelectRecord(naam);
        }

        private void ckbLidBond_CheckedChanged(object sender, EventArgs e)
        {
            tblLid lid = leden[cboLeden.SelectedIndex];

            if (ckbLidBond.Checked)
            {
 //               grpToernooiInfo.Visible = lid.Is_WLP_PUP_CAD_JUN_SEN1;

            }
            else
            {
                ckbCompGerechtigd.Checked = false;
            }
        }

        private void ckbToernooi_CheckedChanged(object sender, EventArgs e)
        {
            ckbRanglijst.Enabled = ckbToernooi.Checked;
            if (!ckbToernooi.Checked) ckbRanglijst.Checked = false;
        }

        private void cbkInclOpgezegd_CheckedChanged(object sender, EventArgs e)
        {
            if (cbkInclOpgezegd.Checked)
                leden = da.VulLedenLijst(true);
            else
                leden = da.VulLedenLijst(false);
            cboLeden.Load(leden);
        }

        private void ckbOpgezegd_CheckedChanged(object sender, EventArgs e)
        {
            tblLid lid = leden[cboLeden.SelectedIndex];
            RekeningenLijst rekeningen = da.VulRekeningRecords();
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked && rekeningen != null)
            {
                dtpLidTot.Value = DateTime.Now;
                RekeningenLijst rl = rekeningen.GetRekeningenbyLidnr(lid.LidNr);
                if (rl.Count > 0)
                {
                    MessageBox.Show("Er zijn nog openstaande rekeningen voor dit lid", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            dtpLidTot.Enabled = cb.Checked;
        }
        #endregion

        private void frmLeden_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Backup aanmaken in " + param.LocationLogFiles + " ?", "Backup aanmaken?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                backupToolStripMenuItem_Click(sender, e);
            }
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "DatabaseFileName", fileName);
        }
   
        #region search
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.ForeColor = Color.Black;
            txtSearch.Text = string.Empty;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                txtSearch.Text = "Search ...";
                txtSearch.ForeColor = Color.Gray;
            }
        }
        #endregion

        private void uploadNaarWebserverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
#if DEBUG
            string db = "ttest";
#else
            string db = "ttvn";
#endif
            LedenLijst localLeden = da.VulLedenLijst(true);
            ResultatenLijst resultaten = da.VulCompResultRecords();
            RekeningenLijst rekeningen = da.VulRekeningRecords();
            //CrediteurenLijst crediteuren = da.VulCrediteurenRecords();
            //BetalingenLijst betalingen = da.VulBetalingRecords();
            
            MySqlDB mySqlDB = new MySqlDB(db, "3198048", "TTVN4all");

            foreach (tblLid x in localLeden) x.Dirty = true;
            foreach (tblRekening x in rekeningen) x.Dirty = true;
            foreach (tblCompResult x in resultaten) x.Dirty = true;
            //foreach (tblBetaling x in betalingen) x.Dirty = true;
            //foreach (tblCrediteur x in crediteuren) x.Dirty = true;

            mySqlDB.Update(localLeden);
            mySqlDB.Update(rekeningen);
            mySqlDB.Update(resultaten);
            //mySqlDB.Update(betalingen);
            //mySqlDB.Update(crediteuren);
            this.Cursor = Cursors.Default;

            MessageBox.Show("Alle tabellen geupload naar " + db, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void testroutine()
        {

#if DEBUG
            string db = "ttest";
#else
            string db = "ttvn";
#endif
            MySqlDB mySqlDB = new MySqlDB(db, "3198048", "_ToegangsCode");
            mySqlDB.SelectAll();
        }

        private void leesRatingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyWebClient client = new MyWebClient();
            // Set user agent and also accept-encoding headers.
            client.Headers["User-Agent"] =
                "Googlebot/2.1 (+http://www.googlebot.com/bot.html)";
            client.Headers["Accept-Encoding"] = "gzip";
            string s = client.DownloadString("http://www.nttb-ranglijsten.nl/ranking.php?Heren=M&Dames=V&Jongens=J&Meisjes=G&club=1520");
            //string s;
            //using (StreamReader sr = new StreamReader(@"d:\temp\ratings.txt"))
            //{
            //    // Read the stream to a string, and write the string to the console.
            //    s = sr.ReadToEnd();
            //}
            foreach (tblLid lid in leden)
            {
                if (!string.IsNullOrEmpty(lid.BondsNr))
                {
                    int loc = s.IndexOf(lid.BondsNr)-250;
                    if (loc > 0)
                    {
                        string tempResult = s.Substring(loc, 250);
                        string[] tempResultArray = tempResult.Split(new string[] { "tdr" }, StringSplitOptions.None);
                        int nbrResults = tempResultArray.Length;
                        tempResult = tempResultArray[nbrResults - 2];
                        tempResultArray = tempResult.Split(new string[] { "<", ">" }, StringSplitOptions.None);
                        int rating = 0; 
                        int.TryParse(tempResultArray[1], out rating);
                        lid.Rating = rating;
                    }
                }
            }
            da.UpdateLeden(leden);
            da.CommitTransaction(true);
            MessageBox.Show("Ratings bijgewerkt", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }

}
