using System;
using System.IO;
using System.Windows.Forms;
using Util;
using Util.Forms;
using Util.Text;
using Util.Extensions;

namespace Leden.Net
{
    public partial class frmContributieAanmaken : frmBasis
    {
        RekeningenLijst localRekeningen = null;
        DataAdapters dataAdaptor;
        RekeningenLijst rekeningen;
        decimal decContributieBedrag = 0;
        string reportFileName = string.Empty;
        LedenLijst leden;

        public frmContributieAanmaken(DataAdapters da, tblParameters Param)
        {
            InitializeComponent();
            leden = da.VulLedenLijst();
            rekeningen = da.VulRekeningRecords();
            dataAdaptor = da;

//            param = new tblParameters();
            param = Param;
            _windowState = new PersistWindowState(this, @"Leden\ContributieAanmaken");
            reportFileName = param.LocationLogFiles + @"\" + param.ClubNameShort + "_Aangemaakte rekeningen.csv";

            dtpPeilDatum.Value = param.ContributiePeilDatum;
            cboSelectieType.SelectedIndex = 0;
            clbLidTypes.Items.AddRange(tblLid.LidTypeDescriptions);
            clbLidTypes.Items.RemoveAt(2);


            txtCompBijdrageSen.Text=       param.cCompBijdrageSen.ToEuroString()      ;  
            txtCompBijdrageJun.Text=       param.cCompBijdrageJun.ToEuroString(); 
            txtBondsBijdrage.Text=         param.cBondsBijdrage.ToEuroString(); 
            txtSen.Text=                   param.cSen.ToEuroString(); 
            txt65.Text=                    param.c65.ToEuroString(); 
            txtWlpPup.Text=                param.cWlpPup.ToEuroString(); 
            txtCadJun.Text=                param.cCadJun.ToEuroString(); 
            txtKostenRekening.Text=        param.cKostenRekening.ToEuroString(); 
            txtPercZwerf.Text=             param.cPercZwerf.ToString(); 
            txtPakketBedrag.Text=          param.cPakketBedrag.ToEuroString(); 
            txtOmschrijving.Text=          param.cOmschrijving; 
            txtKortingVrijwilliger.Text=   param.cKortingVrijwilliger.ToEuroString();


            //PersistControlValue.ReadControlValue(txtOmschrijving);
            //PersistControlValue.ReadControlValue(txtCompBijdrageSen);
            //PersistControlValue.ReadControlValue(txtCompBijdrageJun);
            //PersistControlValue.ReadControlValue(txtBondsBijdrage);
            //PersistControlValue.ReadControlValue(txtSen);
            //PersistControlValue.ReadControlValue(txt65);
            //PersistControlValue.ReadControlValue(txtWlpPup);
            //PersistControlValue.ReadControlValue(txtCadJun);
            //PersistControlValue.ReadControlValue(txtKostenRekening);
            //PersistControlValue.ReadControlValue(txtPercZwerf);
            //PersistControlValue.ReadControlValue(txtPakketBedrag);
            //PersistControlValue.ReadControlValue(txtKortingVrijwilliger);
        }
        
 
        private void cboSelectieType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            clbLidTypes.Enabled = (box.SelectedIndex != 1);
        }

        private void cboTypeRekening_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;

        }
        private void cmdMaakRekeningen_Click(object sender, EventArgs e)
        {
            localRekeningen = new RekeningenLijst();
            foreach (tblLid lid in leden)
            {
                bool berekenen = false;
                decContributieBedrag = 0;
                if (lid.Opgezegd) continue;
                if (lid.IsLidContVrij) continue;
                //fout//
                tblRekening rekening = tblRekening.CreateRekeningRecord(lid, rekeningen);
                switch (cboSelectieType.SelectedIndex)
                {
                    case 0: // Alle leden
                        if ((clbLidTypes.CheckedItems.Contains(clbLidTypes.Items[0]) && lid.IsLidNormaal) ||
                            (clbLidTypes.CheckedItems.Contains(clbLidTypes.Items[1]) && lid.IsLidZwerf) ||
                            (clbLidTypes.CheckedItems.Contains(clbLidTypes.Items[2]) && lid.IsLidPakket))
                            berekenen = true; ;
                        break;
                    case 1: //Gemerkte leden
                        if (lid.Gemerkt)
                            berekenen = true; ;
                        break;
                    default: break;
                }

                if (berekenen)
                {
                    rekening.ContributieBedrag = CalculateTotaalBedrag(lid);
                    
            // als een lid halverwege het seizoen lid wordt dan berekenen we de contributie per maand.
            // we doen dit niet voor pakket leden.

                    if (ckbRelatief.Checked && lid.LidType != tblLid.constLidPakket)
                    {
                        // bereken eerst het aantal maanden tussen peildatum en inschrijfdatum. 
                        var dateSpan = DateTimeSpan.CompareDates(lid.LidVanaf, dtpPeilDatum.Value);

                        // stel berekende maanden is 4 dan krijgt het lid 4 maanden korting.
                        int aantalMaanden = dateSpan.Months + 1; // +1 omdat we vanaf de eerst volgende maand berekenen. 
                        decimal korting = decimal.Round((decContributieBedrag * aantalMaanden) /6,2);
                        rekening.Korting += korting;
                        rekening.TotaalBedrag -= korting;

                    }
                    
                    if (!lid.IsLidPakket && lid.VastBedrag == 0)
                    {
                        rekening.Korting += lid.Korting;
                        rekening.TotaalBedrag -= lid.Korting;

                        if (lid.CompGerechtigd)
                        {
                            string cat = DateRoutines.LeeftijdCategorieContributie(lid.GeboorteDatum, dtpPeilDatum.Value);
                            if (cat == tblLid.constPupil || cat == tblLid.constJunior)
                                rekening.CompetitieBijdrage = txtCompBijdrageJun.ToFromDecimal;
                            else
                                rekening.CompetitieBijdrage = txtCompBijdrageSen.ToFromDecimal;
                            rekening.TotaalBedrag += rekening.CompetitieBijdrage;
                        }

                        if (lid.LidBond)
                        {
                            rekening.Bondsbijdrage = decimal.Round((txtBondsBijdrage.ToFromDecimal / 2), 2);
                            rekening.TotaalBedrag += rekening.Bondsbijdrage;
                        }

                        if (lid.IsRekening || lid.IsZelfBetaler)
                        {
                            rekening.ExtraBedrag = txtKostenRekening.ToFromDecimal;
                            rekening.TotaalBedrag += rekening.ExtraBedrag;
                        }
                        // Ik ga hier de bijdrage voor taak uitrekenen
                        // regeling toepassen && geen vaste taak && taak niet uitgevoerd  of
                        // regeling toepassen && afkopen

                        if (rekening.Lid.Is_SEN1_65_SEN)
                        {
                            if (rekening.Lid.VrijwillgersRegelingIsVanToepassing)
                            {
                                rekening.BedragKortingVrijwilliger = 0;
                                if (rekening.Lid.VrijwillgersVasteTaak)
                                {
                                    rekening.BedragKortingVrijwilliger = txtKortingVrijwilliger.ToFromDecimal;
                                    if (lid.LidType == tblLid.constLidZwerflid)
                                    {
                                        rekening.BedragKortingVrijwilliger = (rekening.BedragKortingVrijwilliger * Convert.ToInt32(txtPercZwerf.Text)) / 100;
                                    }
                                }
                            }
                            else
                                rekening.BedragKortingVrijwilliger = txtKortingVrijwilliger.ToFromDecimal;

                        }
                        else
                            rekening.BedragKortingVrijwilliger = 0;

                    }
                    rekening.TotaalBedrag -= rekening.BedragKortingVrijwilliger;
                    rekening.TotaalBedrag += rekening.ContributieBedrag;
                    rekening.Omschrijving = txtOmschrijving.Text + " " + lid.NetteNaam;
                    rekening.IBAN = param.IBAN;
                    rekening.BIC = param.BIC;
                    rekening.AanmaakDatum = DateTime.Now;
                    rekening.PeilDatum = dtpPeilDatum.Value;
                    rekening.TypeRekening = 0;
                    rekening.Verstuurd = false;
                    rekening.VerstuurdDatum = DateTime.Now;

                    if (rekening.TotaalBedrag != 0)
                        localRekeningen.Add(rekening);
                }
            }
            ReportRoutines.CreateRekeningingenReport("Aangemaakte contributie rekeningen", localRekeningen, reportFileName, true);
            MessageBox.Show(localRekeningen.Count.ToString() + " rekeningen aangemaakt.\nZie " + reportFileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private decimal CalculateTotaalBedrag (tblLid lid)
        {
            if (lid.VastBedrag != 0)
                // Vast bedrag
                decContributieBedrag = lid.VastBedrag;
            else
            {
                // Normaal of Zwerf
                if (lid.LidType == tblLid.constLidNormaal || lid.LidType == tblLid.constLidZwerflid) 
                {
                    string cat = DateRoutines.LeeftijdCategorieContributie(lid.GeboorteDatum, dtpPeilDatum.Value);
                    if (cat == tblLid.constPupil) decContributieBedrag = txtWlpPup.ToFromDecimal;
                    if (cat == tblLid.constJunior) decContributieBedrag = txtCadJun.ToFromDecimal;
                    if (cat == tblLid.constSenior) decContributieBedrag = txtSen.ToFromDecimal;
                    if (cat == tblLid.const65Plus) decContributieBedrag = txt65.ToFromDecimal;
                }
                // Als zwerf 
                if (lid.LidType == tblLid.constLidZwerflid)
                {
                    decContributieBedrag = (decContributieBedrag * Convert.ToInt32(txtPercZwerf.Text)) / 100;
                }
                if (lid.LidType == tblLid.constLidPakket)
                    decContributieBedrag = txtPakketBedrag.ToFromDecimal;
            }
            return decContributieBedrag;
        }

        private void cmdOutput_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(reportFileName);
                GuiRoutines.ShowMessage(sr.ReadToEnd(), reportFileName);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdToelichting_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string filename = PersistControlValue.ReadLocalAppSetting("HelpFile", "FileName");
            if (filename == string.Empty || !File.Exists(filename))
            {
                filename = Util.Forms.GuiRoutines.GetOpenFileName(openFileDialog1, "htm");
                PersistControlValue.SaveLocalAppSetting("HelpFile", "FileName", filename);
            }
            if (filename != string.Empty)
                // Opstarten browser
                System.Diagnostics.Process.Start(filename);
            this.Cursor = Cursors.Arrow;
        }

        private void frmContributieAanmaken_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Aangemaakte rekeningen bewaren?", "Bewaren?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                rekeningen.AddRange(localRekeningen);
                dataAdaptor.UpdateRekeningen(rekeningen);
                dataAdaptor.CommitTransaction(true);
            }

            param.cCompBijdrageSen = txtCompBijdrageSen.ToFromDecimal;
            param.cCompBijdrageJun = txtCompBijdrageJun.ToFromDecimal;
            param.cBondsBijdrage = txtBondsBijdrage.ToFromDecimal;
            param.cSen = txtSen.ToFromDecimal;
            param.c65 = txt65.ToFromDecimal;
            param.cWlpPup = txtWlpPup.ToFromDecimal;
            param.cCadJun = txtCadJun.ToFromDecimal;
            param.cKostenRekening = txtKostenRekening.ToFromDecimal;
            param.cPercZwerf = Convert.ToInt32( txtPercZwerf.Text);
            param.cPakketBedrag = txtPakketBedrag.ToFromDecimal;
            param.cOmschrijving = txtOmschrijving.Text;
            param.cKortingVrijwilliger = txtKortingVrijwilliger.ToFromDecimal;



            //PersistControlValue.StoreControlValue(txtCompBijdrageSen);
            //PersistControlValue.StoreControlValue(txtCompBijdrageJun);
            //PersistControlValue.StoreControlValue(txtBondsBijdrage);
            //PersistControlValue.StoreControlValue(txtSen);
            //PersistControlValue.StoreControlValue(txt65);
            //PersistControlValue.StoreControlValue(txtWlpPup);
            //PersistControlValue.StoreControlValue(txtCadJun);
            //PersistControlValue.StoreControlValue(txtKostenRekening);
            //PersistControlValue.StoreControlValue(txtPercZwerf);
            //PersistControlValue.StoreControlValue(txtPakketBedrag);
            //PersistControlValue.StoreControlValue(txtOmschrijving);
            //PersistControlValue.StoreControlValue(txtKortingVrijwilliger);
        }
    }
}


