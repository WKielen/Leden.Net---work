using System;

using Util.Forms;

namespace Leden.Net
{
    public partial class frmSelectLeden : frmBasis
    {
        private static string[] strFilterLeeftijd = { "Alle Leden", "Jeugd + Sen1", "Jeugd", "Senioren", "Junioren", "Cadetten", "Pupillen", "Welpen" };
        private static string[] strFilterBond = { "Alle Leden", "Lid Bond", "Geen lid" };
        private static string[] strFilterCompetitie = { "Alle Leden", "Wel Competitie", "Geen Competitie" };
        private static string[] strFilterLidTypeDescriptions = { "Alle Leden", "Normaal", "Zwerflid", "ContributieVrij", "Pakket" };
        private static string[] strFilterBetaalWijzeDescriptions = { "Alle Leden", "Incasso", "Rekening" };
        LedenLijst leden;

        public frmSelectLeden(LedenLijst l)
        {
            InitializeComponent();
            leden = l;
            _windowState = new PersistWindowState(this, @"Leden\LedenSelect");
            foreach (tblLid lid in leden)
            {
                clbLeden.Items.Add(lid.VolledigeNaam, true ); //lid.Gemerkt);
            }
            clbLeden.MultiColumn = true;

            cboFilterLeeftijd.Items.AddRange(strFilterLeeftijd);
            cboFilterLeeftijd.SelectedIndex = 0;
            cboFilterLidBond.Items.AddRange(strFilterBond);
            cboFilterLidBond.SelectedIndex = 0;
            cboFilterCompetitie.Items.AddRange(strFilterCompetitie);
            cboFilterCompetitie.SelectedIndex = 0;
            cboFilterLidType.Items.AddRange(strFilterLidTypeDescriptions);
            cboFilterLidType.SelectedIndex = 0;
            cboFilterBetaalWijze.Items.AddRange(strFilterBetaalWijzeDescriptions);
            cboFilterBetaalWijze.SelectedIndex = 0;

            cboFilterLeeftijd.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            cboFilterLidBond.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            cboFilterCompetitie.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            cboFilterLidType.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
            cboFilterBetaalWijze.SelectedIndexChanged += new System.EventHandler(this.cboFilter_SelectedIndexChanged);
        }



        private bool filter(tblLid lid)
        {
            bool check = true;
            switch (cboFilterLeeftijd.SelectedIndex)
            {
                case 1:
                    if (!lid.Is_WLP_PUP_CAD_JUN_SEN1)
                        check = false;
                    break;
                case 2:
                    if (lid.Is_SEN1_65_SEN)
                        check = false;
                    break;
                case 3:
                    if (!lid.Is_SEN1_65_SEN)
                        check = false;
                    break;
                case 4:
                    if (!lid.IsJUN)
                        check = false;
                    break;
                case 5:
                    if (!lid.IsCAD)
                        check = false;
                    break;
                case 6:
                    if (!lid.IsPUP)
                        check = false;
                    break;
                case 7:
                    if (!lid.IsWLP)
                        check = false;
                    break;
            }

            switch (cboFilterLidBond.SelectedIndex)
            {
                case 1:
                    if (!lid.LidBond)
                        check = false;
                    break;
                case 2:
                    if (lid.LidBond)
                        check = false;
                    break;
            }

            switch (cboFilterCompetitie.SelectedIndex)
            {
                case 1:
                    if (!lid.CompGerechtigd)
                        check = false;
                    break;
                case 2:
                    if (lid.CompGerechtigd)
                        check = false;
                    break;
            }

            if (cboFilterLidType.SelectedIndex != 0 && lid.LidType != tblLid.LidTypes[cboFilterLidType.SelectedIndex - 1]) check = false;
            if (cboFilterBetaalWijze.SelectedIndex != 0 && lid.BetaalWijze != tblLid.BetaalWijzes[cboFilterBetaalWijze.SelectedIndex - 1]) check = false;

            return check;
        }

        private void cmdClearSelectie_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < leden.Count; i++)
                clbLeden.SetItemChecked(i,false);
        }

        private void cboFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < leden.Count; i++)
            {
                bool b = filter(leden[i]);
                string n = leden[i].VolledigeNaam;
                clbLeden.SetItemChecked(i, filter(leden[i]));
            }
        }

        private void frmSelectLeden_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            for (int i = 0; i < leden.Count; i++)
            {
                (leden[i]).Gemerkt = clbLeden.GetItemChecked(i);
            }
        }
    }
}
