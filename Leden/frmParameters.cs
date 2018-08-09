using System;
using System.ComponentModel;
using System.Windows.Forms;

using Util.Forms;

namespace Leden.Net
{
    public partial class frmParameters : frmBasis
    {
        public frmParameters()
        {
            InitializeComponent();
        }
        public frmParameters(tblParameters p)
        {
            InitializeComponent();
            param = p;
            _windowState = new PersistWindowState(this, @"Leden\Parameters");
            txtIBAN.Text = param.IBAN;
            txtBIC.Text =  param.BIC;
            txtTemplateLoc.Text = param.LocationTemplates;
            txtLocatieLogFiles.Text = param.LocationLogFiles;
            txtNameLong.Text = param.ClubNameLong;
            txtNameShort.Text =  param.ClubNameShort;
            txtKvK.Text = param.KvK;
            txtSMTPServer.Text = param.STMPserver;
            txtPort.Text = param.STMPport.ToString();
            txtReturnAddress.Text = param.EmailReturnAdress;
            txtStatuten.Text = param.BijlageStatuten;
            txtReglement.Text = param.BijlageReglement;
            txtInfoFolder.Text = param.BijlageInfoFolder;
            txtUserID.Text = param.EmailUserId;
            txtPassword.Text = param.EmailPassword;
            ckbDoNotSendEmail.Checked = param.DoNotSendEmail;
            chkLogEmail.Checked = param.LogEmail;
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
                    MessageBox.Show(statusData.Message);
                }
                txtBIC.Text = Util.Bic.GetBicFromIban(tb.Text);
            }
        }

        private void txtBIC_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "[a-zA-Z]{4}[a-zA-Z]{2}[a-zA-Z0-9]{2}([a-zA-Z0-9]{3})?"))
            {
                tb.Focus();
                MessageBox.Show("Invalid BIC");
            }
        }

        private void frmParameters_FormClosing(object sender, FormClosingEventArgs e)
        {
            param.IBAN = txtIBAN.Text;
            param.BIC = txtBIC.Text;
            param.LocationTemplates = txtTemplateLoc.Text;
            param.LocationLogFiles = txtLocatieLogFiles.Text;
            param.ClubNameLong = txtNameLong.Text;
            param.ClubNameShort = txtNameShort.Text;
            param.KvK = txtKvK.Text;
            if (txtSMTPServer.Text.Trim() != string.Empty)
            {
                param.STMPserver = txtSMTPServer.Text;
                int tmp;
                int.TryParse(txtPort.Text, out tmp);
                param.STMPport = tmp;
            }
            else
            {
                param.STMPserver = "server72.hosting2go.nl";
                param.STMPport = 2525;
            }
            param.EmailReturnAdress = txtReturnAddress.Text;
            param.BijlageStatuten = txtStatuten.Text;
            param.BijlageReglement = txtReglement.Text;
            param.BijlageInfoFolder = txtInfoFolder.Text;
            param.EmailUserId = txtUserID.Text;
            param.EmailPassword = txtPassword.Text;
            param.LogEmail = chkLogEmail.Checked;
            param.DoNotSendEmail = ckbDoNotSendEmail.Checked;

            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "IBAN", param.IBAN);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "BIC", param.BIC);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "LocationTemplates", param.LocationTemplates);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "LocationLogfiles", param.LocationLogFiles);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "ClubNameLong", param.ClubNameLong);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "ClubNameShort", param.ClubNameShort);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "KvK", param.KvK);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "STMPserver", param.STMPserver);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "STMPport", param.STMPport.ToString());
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "EmailReturnAdress", param.EmailReturnAdress);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "BijlageStatuten", param.BijlageStatuten);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "BijlageReglement", param.BijlageReglement);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "BijlageInfoFolder", param.BijlageInfoFolder);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "UserId", param.EmailUserId);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "x", param.EmailPassword);
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "LogEmail", param.LogEmail ? "true" : "false");
            PersistControlValue.SaveLocalAppSetting(@"Leden.Net", "DoNotSendEmail", param.DoNotSendEmail ? "true" : "false");
        }

        private void lblLocatieTemplates_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtTemplateLoc.Text = folderBrowserDialog1.SelectedPath;
        }

        private void lblStatuten_Click(object sender, EventArgs e)
        {
            txtStatuten.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        private void lblReglement_Click(object sender, EventArgs e)
        {
            txtReglement.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        private void lblInformatieFolder_Click(object sender, EventArgs e)
        {
            txtInfoFolder.Text = GuiRoutines.GetOpenFileName(openFileDialog1, "*");
        }

        private void lblLocatieLogfiles_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtLocatieLogFiles.Text = folderBrowserDialog1.SelectedPath;
        }

        private void txtPort_KeyDown(object sender, KeyEventArgs e)
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

        private void cmdCheckServer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                string.Empty, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, new CallBackStatus(PrintRegel));
            this.Cursor = Cursors.Arrow;

        }
        private void PrintRegel(string status)
        {
            lblStatus.Text = status;
        }
    }
}
