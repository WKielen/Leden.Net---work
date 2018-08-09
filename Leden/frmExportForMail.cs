using System;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Util.Forms;
using Util.Email;

namespace Leden.Net
{
    public partial class frmExportForMail : frmBasis, IMruUser
    {
        //private MosaicMru extraMailAdresses;
        private string fileName = string.Empty;
        LedenLijst leden;

        public frmExportForMail(DataAdapters da, tblParameters Param)
        {
            InitializeComponent();
            param = Param;

            leden = da.VulLedenLijst();
            //extraMailAdresses = new MosaicMru(this, "ExportMail");
            //extraMailAdresses.ItemsSaveLimit = 10;
            //extraMailAdresses.ItemsAreFiles = false;
            //extraMailAdresses.BuildMenu(clbExtraEmail);

            _windowState = new PersistWindowState(this, @"Leden\ExportMail");

            txtOutputMailLocation.Text = param.mtxtOutputMailLocation;
            try
            {
                foreach (string s in param.mtxtExtraEmail)
                    clbExtraEmail.Items.Add(s);
            }
            catch { }
            //PersistControlValue.ReadControlValue(txtOutputMailLocation);
            fileName = txtOutputMailLocation.Text + @"\" + param.ClubNameShort + "_Ledenlijst_voor_Mail.xml";
        }

        private void cmdExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (tblLid lid in leden)
                {
                    lid.Gemerkt = false;
                    // we verwijderen zaken die niet nodig zijn voor de email functie.
                    lid.IBAN = string.Empty;
                    lid.BIC = string.Empty;
                    lid.VastBedrag = 0;
                    lid.Korting = 0;
                    lid.BetaalWijze = string.Empty;
                    lid.U_PasNr = string.Empty;
                    lid.BetaalWijze = string.Empty;
                }

                fileName = txtOutputMailLocation.Text + @"\" + param.ClubNameShort + "_Ledenlijst_voor_Mail.xml";
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    XmlSerializer s = new XmlSerializer(typeof(LedenLijst));
                    s.Serialize(fs, leden);
                }
                MessageBox.Show(" Bestand met email adressen aangemaakt.\nZie " + fileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
        }

        private void cmdVerstuurMail_Click(object sender, EventArgs e)
        {
            try
            {
                List<EmailAdresLid> emailList = new List<EmailAdresLid>();

                for (int i = 0; i < clbExtraEmail.Items.Count; i++)
                {
                    if (!clbExtraEmail.GetItemChecked(i)) continue;
                    EmailAdresLid email = new EmailAdresLid(clbExtraEmail.Items[i].ToString());
                    emailList.Add(email);
                }
                BodyString body = @"<P>Hierbij een nieuw bestand voor het mailprogramma. Lees het bestand in via 'File' --&gt; 'Open'.</P> <P>M.v.g.<BR>Ledenadministratie</P>";
                List<string> attachment = new List<string>();
                attachment.Add(fileName);
                new frmMultiMail(emailList,param, body, "Nieuw bestand voor " + param.ClubNameShort + " Mail programma", attachment).ShowDialog();
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
        }
     
        private void frmExportLijsten_FormClosing(object sender, FormClosingEventArgs e)
        {
            param.mtxtOutputMailLocation = txtOutputMailLocation.Text;

            param.mtxtExtraEmail = new List<string>();
            foreach (string s in clbExtraEmail.Items)
                param.mtxtExtraEmail.Add(s);

            //PersistControlValue.StoreControlValue(txtOutputMailLocation);
        }

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtOutputMailLocation.Text = folderBrowserDialog1.SelectedPath;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (txtExtraEmail.ContainsFocus)
            {
                if (keyData == (Keys.Enter))
                {
                    //extraMailAdresses.Add(txtExtraEmail.Text);
                    //extraMailAdresses.MoveToTop(txtExtraEmail.Text);
                    //extraMailAdresses.SaveList();
                    //extraMailAdresses.BuildMenu(clbExtraEmail);
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
                            //extraMailAdresses.Remove(s);
                        }
                    }
                    //extraMailAdresses.SaveList();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Nodig om mru interface te implementeren.    
        void IMruUser.ItemSelected(object obj)
        {
        }
    }
}
