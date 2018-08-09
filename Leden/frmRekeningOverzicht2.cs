using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Util.Forms;
using BrightIdeasSoftware;
using Leden.Net.Properties;

namespace Leden.Net
{
    public partial class frmRekeningOverzicht2 : frmBasis
    {
        DataAdapters dataAdaptor;
        RekeningenLijst rekeningen;
        LedenLijst leden;

        public frmRekeningOverzicht2(DataAdapters da, object l)
        {
            InitializeComponent();
            param = new tblParameters();
            dataAdaptor = da;
            _windowState = new PersistWindowState(this, @"Leden\RekeningOverzicht");
            PersistControlValue.ReadControlValue(txtStornoKosten);
            rduStornoBrief.Checked = true;
            SetChangeMode(false);


            cboTypeRekening.Items.AddRange(tblRekening.RekeningTypeDescriptions);

            InitializeDataListView(olvRekeningen);

            #region Create Columns
            OLVColumn dlvc00 = new OLVColumn("Nr", "RekeningSeqNr");
            OLVColumn dlvc01 = new OLVColumn("Datum", "AanmaakDatum");
            OLVColumn dlvc02 = new OLVColumn("Verstuurd", "Verstuurd");
            OLVColumn dlvc03 = new OLVColumn("Storno", "Gestorneerd");
            OLVColumn dlvc04 = new OLVColumn("Omschrijving", "Omschrijving");
            OLVColumn dlvc05 = new OLVColumn("Bedrag", "TotaalBedrag");

            dlvc00.Width = 30;
            dlvc01.Width = 70;
            dlvc02.Width = 30;
            dlvc03.Width = 30;
            dlvc04.Width = 300;
            dlvc05.Width = 60;

            dlvc00.UseInitialLetterForGroup = true;
            dlvc00.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc00.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
          //
            dlvc01.UseInitialLetterForGroup = true;
            dlvc01.AspectGetter = delegate(object row)
            {
                return ((tblRekening)row).AanmaakDatum.ToShortDateString();
            };
          //  
            dlvc02.UseInitialLetterForGroup = true;
            dlvc02.CheckBoxes = false;
            dlvc02.IsEditable = false;
            dlvc02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc02.AspectGetter = delegate(object row)
            {
                if (((tblRekening)row).Verstuurd)
                    return "Verstuurd";
                return "";
            };
            dlvc02.Renderer = new MappedImageRenderer(new Object[] { "Verstuurd", Resources.tick16});
            //
            dlvc03.UseInitialLetterForGroup = true;
            dlvc03.CheckBoxes = true;
            dlvc03.IsEditable = false;
            dlvc03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc03.AspectGetter = delegate(object row)
            {
                if (((tblRekening)row).Gestorneerd)
                    return "Gestorneerd";
                return "";
            };
            dlvc03.Renderer = new MappedImageRenderer(new Object[] { "Gestorneerd", Resources.star16});
            //
            dlvc04.UseInitialLetterForGroup = true;
            dlvc05.UseInitialLetterForGroup = true;
            dlvc05.AspectToStringFormat = "{0:C}";
            dlvc05.TextAlign = HorizontalAlignment.Right;

            //dlvc16.CheckBoxes = true;
            //dlvc16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc16.ToolTipText = "Is dit contact toegevoegd via Leden administratie?";

            olvRekeningen.Columns.Add(dlvc00);
            olvRekeningen.Columns.Add(dlvc01);
            olvRekeningen.Columns.Add(dlvc02);
            olvRekeningen.Columns.Add(dlvc03);
            olvRekeningen.Columns.Add(dlvc04);
            olvRekeningen.Columns.Add(dlvc05);

            #endregion

            rekeningen = da.VulRekeningRecords();

            ReportRoutines.CreateRekeningingenReport("Aangemaakte contributie rekeningen", rekeningen, @"D:\temp\zz.csv", true);


            if (l is tblLid)
            {
                leden = new LedenLijst();
                tblLid lid = (tblLid)l;
                leden.Add(lid);
                lboLeden.Items.Add(lid.VolledigeNaam);
            }
            if (l is LedenLijst)
            {
                leden = (LedenLijst)l;
                
                foreach (tblLid lid in leden)
                    lboLeden.Items.Add(lid.VolledigeNaam);

            }
            lboLeden.SelectedIndex = 0;
            olvRekeningen.SetObjects(rekeningen);
            lboLeden_SelectedIndexChanged(this, null);
            lboLeden.Focus();
        }

        #region InitializeDataListView

        private void InitializeDataListView(ObjectListView olv)
        {
            olv.UseAlternatingBackColors = true;
            olv.AlternateRowBackColor = Color.Bisque;
            olv.ShowItemCountOnGroups = true;
            olv.OwnerDraw = true;  // Zonder dit attribuut werden de checkboxes niet getekend maar kwam er True/False te staan.
            olv.FullRowSelect = true;
            olv.CheckBoxes = false;
 //           olv.CellEditActivation = ObjectListView.CellEditActivateMode.DoubleClick;
            olv.UseFiltering = true;
            olv.UseFilterIndicator = true;
            olv.GroupWithItemCountFormat = "{0} ({1} contacten)";
            olv.GroupWithItemCountSingularFormat = "{0} ({1} contact)";
            olv.HeaderWordWrap = true;
            olv.View = System.Windows.Forms.View.Details;
            olv.ShowGroups = false;
            olv.EmptyListMsg = "This list is empty.";
            olv.MultiSelect = false;
        }
        #endregion

        private void lboLeden_SelectedIndexChanged(object sender, EventArgs e)
        {
            olvRekeningen.ModelFilter = new RekeningByLidnrFilter(leden[lboLeden.SelectedIndex].LidNr);
            
            //todo laatste regel highlighten
            if (olvRekeningen.Items.Count != 0)
            {
                olvRekeningen.Items[olvRekeningen.Items.Count - 1].Selected = true;
                olvRekeningen.Items[olvRekeningen.Items.Count - 1].EnsureVisible();
            }
            olvRekeningen_SelectedIndexChanged(olvRekeningen, null);
            toolStripStatusLabel1.Text = string.Empty;
        }

        private void lblOmschrijving_Click(object sender, EventArgs e)
        {
            tblRekening rekening = (tblRekening)olvRekeningen.SelectedObject;
            if (rekening == null) return;
            new PropertyGridForm(rekening).Show();
            new PropertyGridForm(rekening.Lid).Show();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            SetChangeMode(false);

            tblRekening rekening = (tblRekening)olvRekeningen.SelectedObject;
            if (rekening == null) return;
            rekening.Omschrijving = txtOmschrijving.Text;
            rekening.TypeRekening = cboTypeRekening.SelectedIndex;
            rekening.TotaalBedrag = txtTotaalbedrag.ToFromDecimal;
            rekening.IBAN = txtCreditIBAN.Text;
            rekening.BIC = txtCreditBIC.Text;
            rekening.AanmaakDatum = dtpAanmaakDatum.Value;
            rekening.VerstuurdDatum = dtpDatumVerstuurd.Value;
            rekening.Verstuurd = ckbVerstuurd.Checked;
            rekening.CompetitieBijdrage = txtCompetitieBijdrage.ToFromDecimal;
            rekening.ContributieBedrag = txtContributieBedrag.ToFromDecimal;
            rekening.Bondsbijdrage = txtBondsbijdrage.ToFromDecimal;
            rekening.ExtraBedrag = txtExtraBedrag.ToFromDecimal;
            rekening.Korting = txtKorting.ToFromDecimal;
            rekening.BedragKortingVrijwilliger = txtKortingVrijwilliger.ToFromDecimal;
            rekening.MailOnderdrukken = ckbMailOnderdrukken.Checked;
            rekening.Gestorneerd = ckbGestorneerd.Checked;
            dataAdaptor.UpdateRekeningen(rekeningen);
            dataAdaptor.CommitTransaction(true);
            olvRekeningen.RefreshObject(olvRekeningen.SelectedObject);
            toolStripStatusLabel1.Text = "Wijziging bewaard";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            tblRekening rekening = (tblRekening)olvRekeningen.SelectedObject;
            if (rekening == null) return;
            
            rekeningen.Remove(rekening);

            // verwijderen uit de dataset.
            dataAdaptor.DeleteRekening(rekening);
            dataAdaptor.CommitTransaction(true);

            olvRekeningen.RemoveObject(rekening);
 //           olvRekeningen.SetObjects(rekeningen);

            lboLeden_SelectedIndexChanged(sender, e);
            toolStripStatusLabel1.Text = "Rekening verwijderd: " + rekening.Omschrijving;

        }


        private void IBAN_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty)
            {
                Util.StatusData statusData = Util.Iban.CheckIban(tb.Text, false);
                if (!statusData.IsValid)
                {
                    tb.Focus();
                    MessageBox.Show(statusData.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BIC_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != string.Empty && !System.Text.RegularExpressions.Regex.IsMatch(tb.Text, RegExBic))
            {
                tb.Focus();
                MessageBox.Show("Invalid BIC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdStorneren_Click(object sender, EventArgs e)
        {
            tblRekening rekening = (tblRekening)olvRekeningen.SelectedObject;

            if (rekening == null) return;
            if (rekening.Gestorneerd)
            {
                MessageBox.Show("Incasso is al gestorneerd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Incasso is al gestorneerd: " + rekening.Omschrijving;

                return;
            }
            if (!rekening.Verstuurd)
            {
                MessageBox.Show("Rekening is nog niet verstuurd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Rekening is nog niet verstuurd: " + rekening.Omschrijving;
                return;
            }
            tblRekening rekeningNew = tblRekening.CreateRekeningRecord(rekening.Lid, rekeningen);
            rekeningNew.Omschrijving = rekening.Omschrijving;
            rekeningNew.TypeRekening = rekening.TypeRekening;
            rekeningNew.TotaalBedrag = rekening.TotaalBedrag + txtStornoKosten.ToFromDecimal;
            rekeningNew.IBAN = rekening.IBAN;
            rekeningNew.BIC = rekening.BIC;
            rekeningNew.AanmaakDatum = DateTime.Now;
            rekeningNew.VerstuurdDatum = DateTime.Now;
            rekeningNew.Verstuurd = false;
            rekeningNew.CompetitieBijdrage = rekening.CompetitieBijdrage;
            rekeningNew.ContributieBedrag = rekening.ContributieBedrag;
            rekeningNew.Bondsbijdrage = rekening.Bondsbijdrage;
            rekeningNew.ExtraBedrag += txtStornoKosten.ToFromDecimal;
            rekeningNew.Korting = rekening.Korting;
            rekeningNew.BedragKortingVrijwilliger = rekeningNew.BedragKortingVrijwilliger;
            rekeningNew.MailOnderdrukken = false;
            rekeningNew.Gestorneerd = false;
            rekeningen.Add(rekeningNew);

            rekening.Gestorneerd = true;
            olvRekeningen.AddObject(rekeningNew);
            lboLeden_SelectedIndexChanged(this, new EventArgs());
            cmdStorneren.Enabled = false;
            toolStripStatusLabel1.Text = "Rekening gestorneerd: " + rekening.Omschrijving;


            string template = (rduStornoBrief.Checked ? "Storno" : "ZelfBetalenStorno");
            frmMultiMail frm = new frmMultiMail(rekening, param, template, "Storno rekening " + param.ClubNameShort, null, C.OnlyFinanicalMailAddresses);
            frm.ShowDialog();
        }

        private void CmdNew_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
    
            // dit Form doet ook de commit op de database.
            new frmEenmaligeRekening(dataAdaptor, leden[lboLeden.SelectedIndex]).ShowDialog();


            // refresh de rekeningenlijst
            olvRekeningen.SetObjects(rekeningen);

            lboLeden_SelectedIndexChanged(sender, e);
            toolStripStatusLabel1.Text = "Rekening aangemaakt: " + txtOmschrijving.Text;

            this.Cursor = Cursors.Arrow; ;

        }


        private void SetChangeMode(bool changemode)
        {
            LockPanel(!changemode);
            cmdSave.Visible = changemode;
            cmdCancel.Visible = changemode;

            cmdChange.Visible = !changemode;
            CmdNew.Enabled = !changemode;
            cmdDelete.Enabled = !changemode;
            cmdStorneren.Enabled = changemode;
            lboLeden.Enabled = !changemode;
            olvRekeningen.Enabled = !changemode;
            cmdExit.Enabled = !changemode;
        }



        private void cmdChange_Click(object sender, EventArgs e)
        {
            SetChangeMode(true);
        }

        Semi_TransparentPanel cusPanel = new Semi_TransparentPanel();
        private void LockPanel(bool activate)
        {
            if (activate)
            {
                cusPanel.Dock = DockStyle.Fill;
                pnlDetails.Controls.Add(cusPanel);
                cusPanel.BringToFront();
                this.pnlButtons.BringToFront();
            }
            else
                pnlDetails.Controls.Remove(cusPanel);
        }

        private void olvRekeningen_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblRekening rekening = (tblRekening)olvRekeningen.SelectedObject;
            if (rekening == null) return;
            txtOmschrijving.Text = rekening.Omschrijving;
            cboTypeRekening.SelectedIndex = rekening.TypeRekening;
            txtTotaalbedrag.ToFromDecimal = rekening.TotaalBedrag;
            txtDebitIBAN.Text = rekening.Lid.IBAN;
            txtCreditIBAN.Text = rekening.IBAN;
            txtDebitBIC.Text = rekening.Lid.BIC;
            txtCreditBIC.Text = rekening.BIC;
            dtpAanmaakDatum.Value = rekening.AanmaakDatum;
            dtpDatumVerstuurd.Value = rekening.VerstuurdDatum;
            ckbVerstuurd.Checked = rekening.Verstuurd;
            txtCompetitieBijdrage.ToFromDecimal = rekening.CompetitieBijdrage;
            txtContributieBedrag.ToFromDecimal = rekening.ContributieBedrag;
            txtBondsbijdrage.ToFromDecimal = rekening.Bondsbijdrage;
            txtExtraBedrag.ToFromDecimal = rekening.ExtraBedrag;
            txtKorting.ToFromDecimal = rekening.Korting;
            txtKortingVrijwilliger.ToFromDecimal = rekening.BedragKortingVrijwilliger;
            ckbGestorneerd.Checked = rekening.Gestorneerd;
            ckbMailOnderdrukken.Checked = rekening.MailOnderdrukken;
            cmdStorneren.Enabled = (cmdSave.Visible && !rekening.Gestorneerd && rekening.Verstuurd); 
        }

        private void olvRekeningen_FormatRow(object sender, FormatRowEventArgs e)
        {
            tblRekening rek = (tblRekening)e.Model;
            if (!rek.Verstuurd) //groen
                e.Item.ForeColor = Color.Green;
            if (rek.Gestorneerd)//rood
                e.Item.ForeColor = Color.Red;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetChangeMode(false);
            olvRekeningen_SelectedIndexChanged(sender, e);
            toolStripStatusLabel1.Text = "Wijziging niet doorgevoerd";
        }

        private void frmRekeningOverzicht2_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(txtStornoKosten);
        }
    }

    /// <summary>
    /// Dit Filter selecteer alle rekeningen met een bepaald Lidnr
    /// </summary>
    public class RekeningByLidnrFilter : IModelFilter
    {
        int globalLidnr = 0;
        public RekeningByLidnrFilter(int LidNr)
        {
            globalLidnr = LidNr;
        }

        public bool Filter(object modelObject)
        {
            return ((tblRekening)modelObject).LidNr == globalLidnr;
        }
    }
}
