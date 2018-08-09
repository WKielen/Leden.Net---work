using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Util.Extensions;
using Util.Forms;
using Util.HtmlParser;

namespace Leden.Net
{
    public partial class frmCompResult2 : frmBasis
    {
        DataAdapters dataAdaptor;
        LedenLijst leden;
        ResultatenLijst resultaten = null;

        string bondsNummer;
        bool initialisation = true;
        public frmCompResult2(DataAdapters da)
        {
            InitializeComponent();
            param = new tblParameters();
            leden = da.VulLedenLijst();
            resultaten = da.VulCompResultRecords();
            dataAdaptor = da;

            _windowState = new PersistWindowState(this, @"Leden\CompResult");

            cboJaar.Items.Add(DateTime.Today.Year - 1);
            cboJaar.Items.Add(DateTime.Today.Year);
            cboSeizoen.Items.AddRange(tblCompResult.CompSeizoen);


            DateTime now_date = DateTime.Now;
            DateTime july_1_thisYear = new DateTime(DateTime.Now.Year, 7, 1, 0, 0, 0);
            if (now_date < july_1_thisYear)
            {
                cboJaar.SelectedIndex = 1;
                cboSeizoen.SelectedIndex = 0;
            }
            else
            {
                cboJaar.SelectedIndex = 0;
                cboSeizoen.SelectedIndex = 1;
            }

            InitializeDataGridView(dgView);
            #region Create Columns
            DataGridViewTextBoxColumn dgvc0 = new DataGridViewTextBoxColumn();
            dgvc0.Name = "LidNr";
            dgvc0.Width = 180;
            dgvc0.Visible = false;

            DataGridViewTextBoxColumn dgvc1 = new DataGridViewTextBoxColumn();
            dgvc1.Name = "Naam";
            dgvc1.Width = 180;
            dgvc1.ReadOnly = true;
            dgvc1.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewTextBoxColumn dgvc2 = new DataGridViewTextBoxColumn();
            dgvc2.Name = "Bondsnummer";
            dgvc2.Width = 60;
            dgvc2.ReadOnly = true;
            dgvc2.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewComboBoxColumn dgvc3 = new DataGridViewComboBoxColumn();
            dgvc3.Name = "Klasse";
            dgvc3.Width = 120;
            dgvc3.ReadOnly = false;
            dgvc3.SortMode = DataGridViewColumnSortMode.Automatic;
            dgvc3.Items.AddRange(tblCompResult.CompKlasses);

            DataGridViewTextBoxColumn dgvc4 = new DataGridViewTextBoxColumn();
            dgvc4.Name = "Percentage";
            dgvc4.Width = 80;
            dgvc4.ReadOnly = false;
            dgvc4.SortMode = DataGridViewColumnSortMode.Automatic;

            dgView.Columns.AddRange(new DataGridViewColumn[] { dgvc0, dgvc1, dgvc2, dgvc3, dgvc4 });
            dgView.ReadOnly = false;

            dgView.Width = 460;
            #endregion
            CreateRows();
            FillColumns();
        }


        private void CreateRows()
        {
            #region Create Rows
            initialisation = true;
            dgView.Rows.Clear();
            foreach (tblLid lid in leden)
            {
                if ((!ckbInclSen.Checked && lid.Is_SEN1_65_SEN) || lid.BondsNr == string.Empty)
                    continue;
                dgView.Rows.Add();
                int RowIndex = dgView.RowCount - 1;
                DataGridViewRow R = dgView.Rows[RowIndex];
                R.Height = 18;
                R.Cells["LidNr"].Value = lid.LidNr;
                R.Cells["Naam"].Value = lid.VolledigeNaam;
                R.Cells["Bondsnummer"].Value = lid.BondsNr;
                R.ReadOnly = false;
            }
            initialisation = false;
            #endregion
        }

        private void FillColumns()
        {
            foreach (DataGridViewRow r in dgView.Rows)
            {
                r.Cells["Klasse"].Value = string.Empty;
                r.Cells["Percentage"].Value = string.Empty;
 
                int lidnr = int.Parse(r.Cells["LidNr"].Value.ToString());
                foreach (tblCompResult cr in resultaten)
                {
                    if (cr.LidNr == lidnr && cr.Jaar.ToString() == cboJaar.Text.ToString() && cr.SeizoenCombo == cboSeizoen.Text)
                    {
                        r.Cells["Klasse"].Value = cr.KlasseCombo;
                        r.Cells["Percentage"].Value = cr.Percentage;
                        continue;
                    }
                }
            }
        }


        private void ckbInclSen_CheckedChanged(object sender, EventArgs e)
        {
            CreateRows();
            FillColumns();
        }

        private void cboSeizoen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillColumns();
        }

        private void cboJaar_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillColumns();
        }

        private void dgView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (initialisation) return;
            bondsNummer = dgView["Bondsnummer", e.RowIndex].Value.ToString();
            Clipboard.SetText(bondsNummer);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgView.Rows)
            {
                if (r.Cells["Klasse"].Value == null) continue;
                string k = r.Cells["Klasse"].Value.ToString().Trim();
                if (k == string.Empty) continue;
                if (r.Cells["Percentage"].Value == null) continue;
                string p = r.Cells["Percentage"].Value.ToString();
                if (!p.IsNumeric()) continue;
                    
                tblCompResult cr = new tblCompResult(leden.GetLidByLidNr(int.Parse(r.Cells["LidNr"].Value.ToString())));
                cr.LidNr = cr.Lid.LidNr;
                cr.Jaar = int.Parse(cboJaar.Text);
                cr.SeizoenCombo = cboSeizoen.Text;
                cr.KlasseCombo = r.Cells["Klasse"].Value.ToString();
                cr.Percentage = int.Parse(r.Cells["Percentage"].Value.ToString());

                resultaten.InsertOrUpdate(cr);
            }
            dataAdaptor.UpdateCompResulten(resultaten);
            dataAdaptor.CommitTransaction(true);
            toolStripStatusLabel1.Text = "Bewaard";
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                button1.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        private void cmdTTKaart_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow r in dgView.Rows)
            {
                string bn = r.Cells["Bondsnummer"].Value.ToString();
                if (bn == string.Empty) continue;
                tblCompResult cr = ScrapeTTKaart(bn, int.Parse(cboJaar.Text), cboSeizoen.Text.ToUpper().Substring(0, 1));
                if (cr != null)
                {
                    r.Cells["Klasse"].Value = cr.KlasseCombo;
                    r.Cells["Percentage"].Value = cr.Percentage;
                }
            }
            this.Cursor = Cursors.Arrow; ;

        }

        private tblCompResult ScrapeTTKaart(string bondsnummer, int jaar, string seizoen)
        {
            try
            {
                // Scrape the website
                WebClient client = new WebClient();
                //this is the important bit...
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4");
                client.Headers.Add("Accept-Language", "en-us,en;q=0.5");
                //end of the important bit...


                client.UseDefaultCredentials = true;
                IWebProxy theProxy = client.Proxy;
                if (theProxy != null)
                {
                    theProxy.Credentials = CredentialCache.DefaultCredentials;
                }
                client.Proxy = WebRequest.DefaultWebProxy;
                byte[] data = null;
                try
                {
                    string url = @"http://ttkaart.nl/spelers/" + bondsnummer + @"/";
                    data = client.DownloadData(url);
                }
                catch
                {
                    //GuiRoutines.ShowMessage("Bondsnummer niet gevonden: " + bondsnummer);
                    return null;
                }



                // Zet de byte-array om in een string   
                StringReader sr = new StringReader(Encoding.UTF8.GetString(data, 0, data.Length));

                tblCompResult cr = null;
                int j = 0;
                string seiz = string.Empty;
                string klasse = string.Empty;
                string type = string.Empty;
                int perc = 0;

                HtmlTag tag;
                HtmlParser parse = new HtmlParser(sr.ReadToEnd());
                parse.ParseNext("tbody", out tag);
                if (parse.ParseNext("tbody", out tag))
                {
                    parse.ParseNext("td", out tag);
                    if (parse.ParseNext("td", out tag))
                    {
                        string s = parse.ParseTagValue();
                        j = int.Parse(s.Substring(0, 4));
                        seiz = s.Substring(6, 1).ToUpper();
                    }
                    parse.ParseNext("td", out tag);  //Jeugd
                    type = parse.ParseTagValue();
                    parse.ParseNext("td", out tag);  // Midden
                    if (parse.ParseNext("td", out tag))
                    {
                        if (parse.ParseNext("a", out tag))
                        {
                            klasse = parse.ParseTagValue().Substring(0,11);
                            switch (klasse)
                            {
                                case "Kampioensgr": klasse = "K"; break;
                                case "Landelijk A": klasse = "A"; break;
                                case "Landelijk B": klasse = "B"; break;
                                case "Landelijk C": klasse = "C"; break;
                                case "Starterskla": klasse = "S"; break;
                                case "1e Divisie ": klasse = "1D"; break;
                                case "2e Divisie ": klasse = "2D"; break;
                                case "3e Divisie ": klasse = "3D"; break;
                                case "Duo 1e Klas": klasse = "D1"; break;
                                case "Duo 2e Klas": klasse = "D2"; break;
                                case "Duo 3e Klas": klasse = "D3"; break;
                                case "Duo 4e Klas": klasse = "D4"; break;
                                case "Duo 5e Klas": klasse = "D5"; break;
                                case "Duo 6e Klas": klasse = "D6"; break;


                                default:
                                    if (klasse.Substring(0, 1).IsNumeric())
                                        klasse = klasse.Substring(0, 1);
                                    break;
                            };
                        }
                    }
                    parse.ParseNext("td", out tag);  // Aantal wedstrijden
                    parse.ParseNext("td", out tag);  // gewonnen

                    if (parse.ParseNext("td", out tag))
                    {
                         perc = int.Parse(parse.ParseTagValue());
                    }
                    if (j == jaar && seiz == seizoen)
                    {
                        cr = new tblCompResult();
                        cr.Klasse = klasse;
                        cr.Percentage = perc;
                        cr.CompetitieType = type;
                    }
                }


                return cr;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://ttkaart.nl/player_details.asp?text=" + bondsNummer);
        }    
    }
}
