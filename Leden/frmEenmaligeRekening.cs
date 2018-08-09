using System;
using System.Windows.Forms;
using System.IO;
using Util.Forms;


namespace Leden.Net
{
    public partial class frmEenmaligeRekening : frmBasis
    {
        private RekeningenLijst localRekeningen = new RekeningenLijst();
        private RekeningenLijst rekeningen = new RekeningenLijst();
        private LedenLijst localLeden = new LedenLijst();

        DataAdapters dataAdaptor;
        string reportFileName = string.Empty;

        public frmEenmaligeRekening(DataAdapters da, LedenLijst l)
        {
            LedenLijst leden;
            Common(da);

            rekeningen = da.VulRekeningRecords();
            leden = l;

            foreach (tblLid lid in leden)
            {
                if (!lid.Gemerkt) continue;
                clbLeden.Items.Add(lid.VolledigeNaam);
                localLeden.Add(lid);
            }
        }

        public frmEenmaligeRekening(DataAdapters da, tblLid lid)
        {
            Common(da);

            rekeningen = da.VulRekeningRecords();
            clbLeden.Items.Add(lid.VolledigeNaam,true);
            localLeden.Add(lid);
        }

        private void Common(DataAdapters da)
        {
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\EenmaligeRekening");
            cboTypeRekening.Items.AddRange(tblRekening.RekeningTypeDescriptions);
            cboTypeRekening.SelectedIndex = 1;
            param = new tblParameters();
            dataAdaptor = da;
            reportFileName = param.LocationLogFiles + @"\" + param.ClubNameShort + "_Aangemaakte rekeningen.csv";
        }
        

        private void cmdCreate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbLeden.Items.Count; i++)
            {
                if (clbLeden.GetItemChecked(i) == false) continue;
                tblRekening rekening = tblRekening.CreateRekeningRecord(localLeden[i],rekeningen);
                rekening.AanmaakDatum = dtpAanmaakDatum.Value;
                rekening.BIC = param.BIC;
                rekening.IBAN = param.IBAN;
                rekening.Omschrijving = txtOmschrijving.Text;
                rekening.TotaalBedrag = txtTotaalbedrag.ToFromDecimal;
                rekening.TypeRekening = cboTypeRekening.SelectedIndex;
                rekeningen.Add(rekening);
                localRekeningen.Add(rekening);
            }
            ReportRoutines.CreateRekeningingenReport("Aangemaakte eenmalige rekeningen", localRekeningen, reportFileName, true);
            toolStripStatusLabel1.Text = localRekeningen.Count.ToString() + " rekeningen aangemaakt.";
        }

        private void cmdOutput_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(reportFileName);
                GuiRoutines.ShowMessage(sr.ReadToEnd(),reportFileName);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEenmaligeRekening_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Aangemaakte rekeningen (" + localRekeningen.Count.ToString() + ") bewaren?", "Bewaren?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dataAdaptor.UpdateRekeningen(rekeningen);
                dataAdaptor.CommitTransaction(true);
            }
            else
            {
                foreach (tblRekening rek in localRekeningen)
                    rekeningen.Remove(rek);
                dataAdaptor.CancelTransaction(true);
            }
        }


    }
}
