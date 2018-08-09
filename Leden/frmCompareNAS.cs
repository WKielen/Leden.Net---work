using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Util.Forms;
using Util.Extensions;

namespace Leden.Net
{
    /// <summary>
    /// Zou je niet wat foutafhandeling toevoegen????????????????
    /// </summary>
    public partial class frmCompareNAS : frmBasis
    {
        DataAdapters dataAdaptor;
        LedenLijst leden;
        //Na het toevoegen van een row ging het event af voor de Cell Update. Hierdoor kreeg ik een null reference exception.
        //Niet de mooiste oplossing maar wel de eenvoudigste
        Boolean disableEventCellUpdate = false;

        public frmCompareNAS(DataAdapters da)
        {
            InitializeComponent();
            dataAdaptor = da;
            param = new tblParameters();
            leden = da.VulLedenLijst();
            _windowState = new PersistWindowState(this, @"Leden\CompareNAS");
            PersistControlValue.ReadControlValue(txtNASteamindeling);
            PersistControlValue.ReadControlValue(txtNASLeden);

            #region Create Columns

            DataGridViewColumn dgvc0 = new DataGridViewTextBoxColumn();
            dgvc0.Name = "Bondsnummer";
            dgvc0.Width = 70;
            dgvc0.ReadOnly = true;
            dgvc0.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc1 = new DataGridViewTextBoxColumn();
            dgvc1.Name = "Naam";
            dgvc1.Width = 180;
            dgvc1.ReadOnly = true;
            dgvc1.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc2 = new DataGridViewCheckBoxColumn();
            dgvc2.Name = "CG NAS";
            dgvc2.Width = 60;
            dgvc2.ReadOnly = true;
            dgvc2.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc3 = new DataGridViewCheckBoxColumn();
            dgvc3.Name = "CG Admin";
            dgvc3.Width = 60;
            dgvc3.ReadOnly = false;
            dgvc3.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc4 = new DataGridViewCheckBoxColumn();
            dgvc4.Name = "Team NAS";
            dgvc4.Width = 60;
            dgvc4.ReadOnly = true;
            dgvc4.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc5 = new DataGridViewCheckBoxColumn();
            dgvc5.Name = "LB Admin";
            dgvc5.Width = 60;
            dgvc5.ReadOnly = false;
            dgvc5.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc6 = new DataGridViewCheckBoxColumn();
            dgvc6.Name = "LB NAS";
            dgvc6.Width = 60;
            dgvc6.ReadOnly = true;
            dgvc6.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc7 = new DataGridViewCheckBoxColumn();
            dgvc7.Name = "Niet in Admin";
            dgvc7.Width = 60;
            dgvc7.ReadOnly = true;
            dgvc7.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc8 = new DataGridViewTextBoxColumn();
            dgvc8.Name = "Lic Admin";
            dgvc8.Width = 60;
            dgvc8.ReadOnly = false;
            dgvc8.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc9 = new DataGridViewTextBoxColumn();
            dgvc9.Name = "Lic NAS";
            dgvc9.Width = 60;
            dgvc9.ReadOnly = true;
            dgvc9.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn dgvc10 = new DataGridViewTextBoxColumn();
            dgvc10.Name = "Email NAS";
            dgvc10.Width = 180;
            dgvc10.ReadOnly = true;
            dgvc10.SortMode = DataGridViewColumnSortMode.Automatic;


            dgView.Columns.AddRange(new DataGridViewColumn[] { dgvc0, dgvc1, dgvc2, dgvc3, dgvc4, dgvc5, dgvc6, dgvc7, dgvc8, dgvc9, dgvc10 });
            dgView.ReadOnly = false;

            pnlGrid.Width = 930;

            #endregion

            InitializeDataGridView(dgView);
            CreateRows();

            //trigger the updates vanuit de tekstvelden om de eerste vergelijking te maken
            txtNASLeden_TextChanged(this, new EventArgs());
            txtNASteamindeling_TextChanged(this, new EventArgs());

            // activeer de eventhandlers
            dgView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(dgView_CellValueChanged);
            txtNASLeden.TextChanged += new System.EventHandler(txtNASLeden_TextChanged);
            txtNASteamindeling.TextChanged += new System.EventHandler(txtNASteamindeling_TextChanged);
            dgView.CurrentCellDirtyStateChanged += new System.EventHandler(dgView_CurrentCellDirtyStateChanged);
        }

        #region Create Rows
        private void CreateRows()
        {
            try
            {

                dgView.Rows.Clear();
                dgView.AllowUserToResizeRows = false;

                foreach (tblLid lid in leden)
                {
                    DataGridViewRow r = CreateRow(dgView);
                    r.Cells["Bondsnummer"].Value = lid.BondsNr;
                    r.Cells["Naam"].Value = lid.VolledigeNaam;

                    r.Cells["CG Admin"].Value = lid.CompGerechtigd;
                    r.Cells["LB Admin"].Value = lid.LidBond;

                    r.Cells["Lic Admin"].Value = lid.LicentieJun.Trim() + lid.LicentieSen.Trim();

                    r.Tag = lid;
                    r.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        private DataGridViewRow CreateRow(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Add();
                DataGridViewRow r = dgv.Rows[dgv.RowCount - 1];
                r.Cells["Bondsnummer"].Value = "Onbekend";
                r.Cells["Naam"].Value = "Onbekend";

                r.Cells["CG Admin"].Value = false;
                r.Cells["LB Admin"].Value = false;
                r.Cells["Lic Admin"].Value = string.Empty;

                r.Cells["Team NAS"].Value = false;
                r.Cells["CG NAS"].Value = false;
                r.Cells["LB NAS"].Value = false;
                r.Cells["Lic NAS"].Value = string.Empty;
                r.Cells["Email NAS"].Value = string.Empty;
                r.Cells["Niet in Admin"].Value = false;

                r.Height = 18;
                return r;

            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
                return null;
            }
        }

        #endregion

        private void dgView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (disableEventCellUpdate) return;
            DataGridViewRow row = ((DataGridView)sender).CurrentRow;
            if (row.Tag != null)
            {
                try
                {
                    tblLid lid = (tblLid)row.Tag;
                    lid.CompGerechtigd = (bool)row.Cells["CG Admin"].Value;
                    lid.LidBond = (bool)row.Cells["LB Admin"].Value;
                    lid.LicentieJun = lid.LicentieSen = string.Empty;
                    string l = (string)row.Cells["Lic Admin"].Value;
                    if (l != null)
                    {
                        l = l.Trim().ToUpper();
                        if (l.Length == 2)
                        {
                            if (!lid.Is_SEN1_65_SEN) // Alleen jun kunnen een dubbele licentie hebben
                            {
                                lid.LicentieJun = l.Substring(0, 1);
                                lid.LicentieSen = l.Substring(1, 1);
                            }
                            else
                            {
                                lid.LicentieJun = string.Empty;
                                lid.LicentieSen = l.Substring(1, 1);
                            }
                        }
                        else
                            if (lid.Is_SEN1_65_SEN)
                                lid.LicentieSen = l.Trim();
                            else
                                lid.LicentieJun = l.Trim();
                    }
                    Compare();
                }
                catch (Exception ex)
                {
                    GuiRoutines.ShowMessage(ex);
                }
            }
        }

        #region Compare
        private void Compare()
        {
            try
            {
                foreach (DataGridViewRow r in dgView.Rows)
                {
                    bool CGAdmin = (bool)r.Cells["CG Admin"].Value;
                    bool LBAdmin = (bool)r.Cells["LB Admin"].Value;
                    bool inTeam = (bool)r.Cells["Team NAS"].Value;
                    bool CGNas = (bool)r.Cells["CG NAS"].Value;
                    bool LBNas = (bool)r.Cells["LB NAS"].Value;
                    bool NietInAdmin = (bool)r.Cells["Niet in Admin"].Value;
                    string LicAdmin = (string)r.Cells["Lic Admin"].Value;
                    string LicNAS = (string)r.Cells["Lic NAS"].Value;
                    string EmailNas = (string)r.Cells["Email NAS"].Value;

                    if ((CGAdmin != CGNas) || (CGAdmin != inTeam) || (CGNas != inTeam))
                    {
                        r.Cells["CG Admin"].Style.BackColor = System.Drawing.Color.Red;
                        r.Cells["Team NAS"].Style.BackColor = System.Drawing.Color.Red;
                        r.Cells["CG NAS"].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        r.Cells["CG Admin"].Style.BackColor = System.Drawing.Color.White;
                        r.Cells["Team NAS"].Style.BackColor = System.Drawing.Color.White;
                        r.Cells["CG NAS"].Style.BackColor = System.Drawing.Color.White;
                    }

                    if (LBNas != LBAdmin)
                    {
                        r.Cells["LB Admin"].Style.BackColor = System.Drawing.Color.Red;
                        r.Cells["LB NAS"].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        r.Cells["LB Admin"].Style.BackColor = System.Drawing.Color.White;
                        r.Cells["LB NAS"].Style.BackColor = System.Drawing.Color.White;
                    }

                    if (NietInAdmin)
                    {
                        r.Cells["Niet in Admin"].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        r.Cells["Niet in Admin"].Style.BackColor = System.Drawing.Color.White;
                    }

                    if (LicAdmin != LicNAS)
                    {
                        r.Cells["Lic Admin"].Style.BackColor = System.Drawing.Color.Red;
                        r.Cells["Lic NAS"].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        r.Cells["Lic Admin"].Style.BackColor = System.Drawing.Color.White;
                        r.Cells["Lic NAS"].Style.BackColor = System.Drawing.Color.White;
                    }

                    if ((r.Tag != null) && ((tblLid)r.Tag).MainEmailAdress != EmailNas)
                    {
                        r.Cells["Email NAS"].Style.BackColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        r.Cells["Email NAS"].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }
        #endregion

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdaptor.UpdateLeden(leden);
                dataAdaptor.CommitTransaction(true);
                toolStripStatusLabel1.Text = "Bewaard";
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        #region Text changed afhandeling
        private void txtNASteamindeling_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // We zetten alle cellen op false. nodig omdat er anders kans is een true op true blijft staan bij een wijziging
                disableEventCellUpdate = true;
                foreach (DataGridViewRow r in dgView.Rows)
                {
                    r.Cells["Team NAS"].Value = false;
                    r.Cells["Niet in Admin"].Value = false;
                }
                disableEventCellUpdate = false;

                foreach (string s in txtNASteamindeling.Lines)
                {
                    string line = s.Replace("\t", " ");
                    bool found = false;
                    if (line.Length < 8) continue;
                    line = line.Substring(0, 8);
                    line = line.Trim();
                    if (line.IsNumeric())
                    {
                        foreach (DataGridViewRow r in dgView.Rows)
                        {

                            if (r.Cells["Bondsnummer"].Value.ToString() == line)
                            {
                                r.Cells["Team NAS"].Value = found = true;
                            }
                        }

                        // je hebt een bondsnr in de teamindeling gevonden die niet in je admin staat. 
                        if (!found)
                        {
                            disableEventCellUpdate = true;
                            DataGridViewRow r = CreateRow(dgView);
                            r.Cells["Bondsnummer"].Value = line;
                            r.Cells["Team NAS"].Value = true;
                            r.Cells["Niet in Admin"].Value = true;

                            r.ReadOnly = true;
                            disableEventCellUpdate = false;
                        }

                    }
                }
                Compare();
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        private void txtNASLeden_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // We zetten alle cellen op false. nodig omdat er anders kans is een true op true blijft staan bij een wijziging
                disableEventCellUpdate = true;
                foreach (DataGridViewRow r in dgView.Rows)
                {
                    r.Cells["LB NAS"].Value = false;
                    r.Cells["CG NAS"].Value = false;
                }
                disableEventCellUpdate = false;

                foreach (string s in txtNASLeden.Lines)
                {
                    bool found = false;
                    string line = s.Replace("\t", " ");
                    string[] values = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length < 10) continue;

                    string lic = string.Empty;
                    string email = string.Empty;
                    int zoeknaam = 0;
                    for (int i = 2; i < values.Length; i++)
                    {
                        string l = values[i];
                        if ((l == "A" || l == "B" || l == "C" || l == "D" || l == "E" || l == "F" || l == "G" || l == "H") && l.Length == 1)
                        {
                            lic += l;
                        }
                        if (values[i].Contains("@"))
                            email = values[i];

                        // Als er NAS een bondsnummer staat die niet in onze admin staat dan moeten we iets in de naam invullen
                        // De best guess is dat de naam diect na het geslacht komt
                        if (zoeknaam == 0 && (values[i] == "M" || values[i] == "V") && values[i].Length == 1)
                        {
                            zoeknaam = i + 1;
                        }
                    }

                    foreach (DataGridViewRow r in dgView.Rows)
                    {
                        if (r.Cells["Bondsnummer"].Value.ToString() == values[1])
                        {
                            r.Cells["LB NAS"].Value = found = true;
                            r.Cells["CG NAS"].Value = (values[2] == "J");
                            r.Cells["Lic NAS"].Value = lic;
                            r.Cells["Email NAS"].Value = email;
                        }
                    }
                    if (!found)
                    {
                        disableEventCellUpdate = true;
                        DataGridViewRow r = CreateRow(dgView);
                        r.Cells["Bondsnummer"].Value = values[1];

                        r.Cells["Naam"].Value = values[zoeknaam] + values[zoeknaam + 1];

                        r.Cells["Lic NAS"].Value = lic;
                        r.Cells["CG NAS"].Value = (values[2] == "J");
                        r.Cells["LB NAS"].Value = true;
                        r.Cells["Niet in Admin"].Value = true;
                        r.Cells["Niet in Admin"].Style.BackColor = System.Drawing.Color.Red;

                        r.Cells["LB NAS"].ReadOnly = true;
                        r.Cells["LB Admin"].ReadOnly = true;

                        r.Cells["Email NAS"].ReadOnly = true;
                        r.Cells["Email NAS"].Value = string.Empty;

                        r.ReadOnly = true;
                        disableEventCellUpdate = false;
                    }
                }
                Compare();
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }

        }
        #endregion

        #region  dgView_CurrentCellDirtyStateChanged
        /// <summary>
        /// Dit event zorg ervoor dat de checkbox in de datagridview direct een event krijgt als de waarde wisselt.
        /// De CellValueChanged gaat normaal pas af als de cell focus verliest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dgView_CurrentCellDirtyStateChanged(object sender,
            EventArgs e)
        {
            if (dgView.IsCurrentCellDirty)
            {
                dgView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        #endregion


        private void frmCompareNAS_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(txtNASteamindeling);
            PersistControlValue.StoreControlValue(txtNASLeden);
        }

    }
}