using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Util.Forms;
using BrightIdeasSoftware;
using System.Linq;
using Leden.Net.Properties;
using Util.Extensions;

namespace Leden.Net
{
    public partial class frmEenmaligeBetaling : frmBasis
    {
        DataAdapters dataAdaptor;
        BetalingenLijst betalingen;

        public frmEenmaligeBetaling(DataAdapters da)
        {
            InitializeComponent();
            param = new tblParameters();
            dataAdaptor = da;
            betalingen = da.VulBetalingRecords();

            _windowState = new PersistWindowState(this, @"Leden\EenmaligeBetaling");
            PersistControlValue.ReadControlValue(chkFilter);
            SetChangeMode(false);


            cboTypeRekening.Items.AddRange(tblBetaling.BetalingTypeDescriptions);

            InitializeDataListView(olvBetalingen);

            #region Create Columns
            OLVColumn colNaam = new OLVColumn("Naam", "Crediteur");
            OLVColumn colDatum = new OLVColumn("Datum", "AanmaakDatum");
            OLVColumn dlvc03 = new OLVColumn("Omschrijving", "Omschrijving");
            OLVColumn dlvc04 = new OLVColumn("End To End Id", "EndToEndId");
            OLVColumn colBedrag = new OLVColumn("Bedrag", "TotaalBedrag");
            OLVColumn colType = new OLVColumn("Type", "TypeBetaling");
            OLVColumn colVerwerkingsDatum = new OLVColumn("Verw, Datun", "GewensteVerwerkingsDatum");

            colNaam.Width = 140;
            colDatum.Width = 90;
            dlvc03.Width = 200;
            dlvc04.Width = 130;
            colBedrag.Width = 70;
            colType.Width = 70;
            colVerwerkingsDatum.Width = 90;

            colNaam.UseInitialLetterForGroup = true;
            colBedrag.UseInitialLetterForGroup = true;
            colBedrag.AspectToStringFormat = "{0:C}";
            colBedrag.TextAlign = HorizontalAlignment.Right;
            // dlvc03.UseInitialLetterForGroup = true;
            colDatum.Sortable = true;
            colDatum.TextAlign = HorizontalAlignment.Right;
            colDatum.UseInitialLetterForGroup = true;
            colVerwerkingsDatum.Sortable = true;
            colVerwerkingsDatum.TextAlign = HorizontalAlignment.Right;
            colVerwerkingsDatum.UseInitialLetterForGroup = true;
            colType.UseInitialLetterForGroup = true;

            olvBetalingen.Columns.Add(colType);
            olvBetalingen.Columns.Add(colNaam);
            olvBetalingen.Columns.Add(dlvc03);
            olvBetalingen.Columns.Add(dlvc04);
            olvBetalingen.Columns.Add(colBedrag);
            olvBetalingen.Columns.Add(colDatum);
            olvBetalingen.Columns.Add(colVerwerkingsDatum);

            colType.AspectGetter = delegate(object row)
            {
                if (((tblBetaling)row).TypeBetaling == 0)
                    return "Overig";
                return "Overig";  // Voor het geval er nog meer komen :o)
            };

            colDatum.AspectGetter = delegate(object row)
            {
                return ((tblBetaling)row).AanmaakDatum.ToShortDateString();
            };

            colVerwerkingsDatum.AspectGetter = delegate(object row)
            {
                return ((tblBetaling)row).GewensteVerwerkingsDatum.ToShortDateString();
            };

            dlvc04.AspectGetter = delegate(object row)
            {
                return ((tblBetaling)row).FormattedEndToEndId;
            };
            #endregion

            olvBetalingen.SetObjects(betalingen);

            #region Vul Crediteuren
            LedenLijst leden = da.VulLedenLijst();

            CrediteurenLijst crediteuren = da.VulCrediteurenRecords();

            foreach (tblCrediteur cred in crediteuren)
                cboCrediteur.AddRecord(cred.Naam, cred);
            foreach (tblLid lid in leden)
            {
                if (lid.IsIncasso)
                    cboCrediteur.AddRecord(lid.VolledigeNaam, lid);
            }
            cboCrediteur.First();

            #endregion

            // Show the first
            //if (betalingen.Count > 0)
            //    olvBetalingen.Items[0].Selected = true;
            //else
            //    CmdNew_Click(this, null);  // Waarom werkt dit niet:  CmdNew.PerformClick();
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
            olv.CellEditActivation = ObjectListView.CellEditActivateMode.None;
            olv.UseFiltering = true;
            olv.UseFilterIndicator = true;
            olv.GroupWithItemCountFormat = "{0} ({1} betalingen)";
            olv.GroupWithItemCountSingularFormat = "{0} ({1} betaling)";
            olv.HeaderWordWrap = true;
            olv.View = System.Windows.Forms.View.Details;
            olv.ShowGroups = false;
            olv.EmptyListMsg = "This list is empty.";
            olv.MultiSelect = false;
            olv.ModelFilter = new VerstuurdFilter(chkFilter.Checked);

        }
        #endregion

        private void olvBetalingen_SelectedIndexChanged(object sender, EventArgs e)
        {
            tblBetaling betaling = (tblBetaling)olvBetalingen.SelectedObject;
            if (betaling == null) return;
            txtOmschrijving.Text = betaling.Omschrijving;

            if (betaling.EndToEndId.Trim() == string.Empty && betaling.Omschrijving.Trim() == string.Empty)
            {
                txtOmschrijving.Enabled = true;
                txtEndToEndid.Enabled = true;
            }
            else
                if (betaling.EndToEndId.Trim() == string.Empty)
                {
                    txtOmschrijving.Enabled = true;
                    txtEndToEndid.Enabled = false;
                }
                else
                {
                    txtOmschrijving.Enabled = false;
                    txtEndToEndid.Enabled = true;
                }

            cboCrediteur.Text = betaling.Crediteur;
            cboTypeRekening.SelectedIndex = betaling.TypeBetaling;
            txtTotaalbedrag.ToFromDecimal = betaling.TotaalBedrag;
            dtpAanmaakDatum.Value = betaling.AanmaakDatum;
            dtpDatumVerstuurd.Value = betaling.VerstuurdDatum;
            dtpDatumVerstuurd.Enabled = ckbVerstuurd.Checked = betaling.Verstuurd;
            dtpGewensteDatum.Value = betaling.GewensteVerwerkingsDatum;
            txtEndToEndid.Text = betaling.EndToEndId;
        }
 


        #region New, Save buttons ....
        private void CmdNew_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SetChangeMode(true);

            tblBetaling betaling = new tblBetaling(betalingen);
            olvBetalingen.SetObjects(betalingen);
            olvBetalingen.SelectObject(betaling, true);

            // refresh de rekeningenlijst
            toolStripStatusLabel1.Text = "Rekening aangemaakt: " + txtOmschrijving.Text;
            this.Cursor = Cursors.Arrow; ;
        }


        
        private void cmdSave_Click(object sender, EventArgs e)
        {
            tblBetaling betaling = (tblBetaling)olvBetalingen.SelectedObject;
            if (betaling == null) return;
            SetChangeMode(false);

            object myCrediteur = cboCrediteur.SelectedObject;
            if (myCrediteur is tblCrediteur)
            {
                tblCrediteur c = (tblCrediteur)myCrediteur;
                betaling.BIC_Creditor = c.BIC;
                betaling.IBAN_Creditor = c.IBAN;
            }
            if (myCrediteur is tblLid)
            {
                tblLid l = (tblLid)myCrediteur;
                betaling.BIC_Creditor = l.BIC;
                betaling.IBAN_Creditor = l.IBAN;
            }

            betaling.AanmaakDatum = dtpAanmaakDatum.Value;
            betaling.EndToEndId = txtEndToEndid.Text.RemoveNonNumeric().Trim();
            betaling.GewensteVerwerkingsDatum = dtpGewensteDatum.Value;
            betaling.Omschrijving = txtOmschrijving.Text;
            betaling.TotaalBedrag = txtTotaalbedrag.ToFromDecimal;
            betaling.TypeBetaling = cboTypeRekening.SelectedIndex;
            betaling.Verstuurd = ckbVerstuurd.Checked;
            betaling.VerstuurdDatum = dtpDatumVerstuurd.Value;
            betaling.Crediteur = cboCrediteur.Text;

            dataAdaptor.UpdateBetalingen(betalingen);
            dataAdaptor.CommitTransaction(true);
            olvBetalingen.RefreshObject(olvBetalingen.SelectedObject);
            toolStripStatusLabel1.Text = "Wijziging bewaard";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            tblBetaling betaling = (tblBetaling)olvBetalingen.SelectedObject;
            if (betaling == null) return;

            // verwijderen uit de dataset.
            dataAdaptor.DeleteBetaling(betaling);
            dataAdaptor.CommitTransaction(true);

            olvBetalingen.RemoveObject(betaling);

            toolStripStatusLabel1.Text = "Rekening verwijderd: " + betaling.Omschrijving;

        }

        private void SetChangeMode(bool changemode)
        {
            LockPanel(!changemode);
            cmdSave.Visible = changemode;
            cmdCancel.Visible = changemode;

            cmdChange.Visible = !changemode;
            CmdNew.Enabled = !changemode;
            cmdDelete.Enabled = !changemode;
            olvBetalingen.Enabled = !changemode;
            cmdExit.Enabled = !changemode;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SetChangeMode(false);
            olvBetalingen_SelectedIndexChanged(sender, e);
            toolStripStatusLabel1.Text = "Wijziging niet doorgevoerd";
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
                pnlBottom.Controls.Add(cusPanel);
                cusPanel.BringToFront();
                this.pnlButtons.BringToFront();
            }
            else
                pnlBottom.Controls.Remove(cusPanel);
        }
        #endregion

        private void olvRekeningen_FormatRow(object sender, FormatRowEventArgs e)
        {
            tblBetaling rek = (tblBetaling)e.Model;
            if (!rek.Verstuurd) //groen
                e.Item.ForeColor = Color.Green;
        }

        private void frmRekeningOverzicht2_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(chkFilter);
        }

        private void txtEndToEndid_TextChanged(object sender, EventArgs e)
        {
            if (txtEndToEndid.Text.RemoveNonNumeric().Trim() == string.Empty)
                txtOmschrijving.Enabled = true;
            else
                txtOmschrijving.Enabled = false;
        }

        private void txtOmschrijving_TextChanged(object sender, EventArgs e)
        {
            if (txtOmschrijving.Text.Trim() == string.Empty)
                txtEndToEndid.Enabled = true;
            else
                txtEndToEndid.Enabled = false;
        }

        private void ckbVerstuurd_CheckedChanged(object sender, EventArgs e)
        {
            dtpDatumVerstuurd.Enabled = ckbVerstuurd.Checked;
        }

        private void chkFilter_CheckedChanged(object sender, EventArgs e)
        {
            olvBetalingen.ModelFilter = new VerstuurdFilter(chkFilter.Checked);
            olvBetalingen.SelectObject(betalingen[0]);
            olvBetalingen_SelectedIndexChanged(sender, e);
        }
    }

    /// <summary>
    /// Dit Filter selecteer alle rekeningen met een bepaald Lidnr
    /// </summary>
    public class VerstuurdFilter : IModelFilter
    {
        bool verstuurd = false;
        public VerstuurdFilter(bool Verstuurd)
        {
            verstuurd = Verstuurd;
        }

        public bool Filter(object modelObject)
        {
            if (!((tblBetaling)modelObject).Verstuurd) return true;
            return ((tblBetaling)modelObject).Verstuurd == verstuurd;
        }
    }
}
