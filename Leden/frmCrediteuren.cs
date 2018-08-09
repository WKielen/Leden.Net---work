using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Util.Forms;

namespace Leden.Net
{
    public partial class frmCrediteuren : frmBasis
    {
        DataAdapters dataAdaptor;
        CrediteurenLijst crediteuren = null;

        public frmCrediteuren(DataAdapters da)
        {
            #region Initialize
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\Crediteuren");

            dataAdaptor = da;
            param = new tblParameters();
            crediteuren = da.VulCrediteurenRecords();

            InitializeDataListView(olvVCard);

            PersistControlValue.ReadControlValue(txtOutputLocation);

            #endregion

            #region Create Columns
//            OLVColumn dlvc01 = new OLVColumn("Crediteuren ID", "Crediteur");
            OLVColumn dlvc02  = new OLVColumn("Naam","Naam");
            OLVColumn dlvc03  = new OLVColumn("IBAN", "IBAN");
            OLVColumn dlvc04  = new OLVColumn("BIC","BIC");
            OLVColumn colOmschrijving  = new OLVColumn("Omschrijving", "Omschrijving");

//            dlvc01.Width = 90;
            dlvc02.Width = 150;
            dlvc03.Width = 140;
            dlvc04.Width = 100;
            colOmschrijving.Width = 200;
            
//            dlvc01.UseInitialLetterForGroup = true;
            dlvc02.UseInitialLetterForGroup = true;
            dlvc03.UseInitialLetterForGroup = true;
            dlvc04.UseInitialLetterForGroup = true;
            colOmschrijving.UseInitialLetterForGroup = false;
            dlvc04.IsEditable = false;

//            olvVCard.Columns.Add(dlvc01);
            olvVCard.Columns.Add(dlvc02);
            olvVCard.Columns.Add(dlvc03);
            olvVCard.Columns.Add(dlvc04);
            olvVCard.Columns.Add(colOmschrijving);

            dlvc02.AspectPutter = delegate(object row, object newValue)
            {
                ((tblCrediteur)row).Naam = (string)newValue;
            };
            dlvc03.AspectPutter = delegate(object row, object newValue)
            {
                ((tblCrediteur)row).IBAN = (string)newValue;
            };
            colOmschrijving.AspectPutter = delegate(object row, object newValue)
            {
                ((tblCrediteur)row).Omschrijving = (string)newValue;
            };

    
            //dlvc02.AspectGetter = delegate(object row)
            //{
            //    VCard2 vc = (VCard2)row;
            //    return vc.Voornaam + " " + (vc.Tussen != string.Empty ? vc.Tussen + " " : string.Empty) + vc.Achternaam + "\n" + "twee";
            //};
            #endregion

            olvVCard.SetObjects(crediteuren);
        }

        #region InitializeDataListView
        private void InitializeDataListView(FastObjectListView olv)
        {
            olv.UseSubItemCheckBoxes = true;  //zonder dit attribuut komen de checkboxes niet op de lijst te staan
            olv.AddDecoration(new EditingCellBorderDecoration(true));
            olv.CellEditFinishing += new BrightIdeasSoftware.CellEditEventHandler(this.olv_CellEditFinishing);
        }

        void olv_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Column.Text == "IBAN")
            {
                Util.StatusData statusData = Util.Iban.CheckIban((string)e.NewValue, false);
                if (!statusData.IsValid)
                {
                    MessageBox.Show(statusData.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    tblCrediteur d = (tblCrediteur)e.RowObject;
                    d.IBAN = (string)e.NewValue;
                    d.BIC = Util.Bic.GetBicFromIban(d.IBAN);
                }
                e.Cancel = true;
            }
            else
                e.Cancel = false;
            

            // Any updating will have been down in the SelectedIndexChanged event handler
            // Here we simply make the list redraw the involved ListViewItem
            ((ObjectListView)sender).RefreshItem(e.ListViewItem);

        }

        #endregion


        #region Filter
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter(olvVCard, txtFilter.Text, 0);
        }
        void Filter(FastObjectListView olv, string txt, int matchKind)
        {
            olv.OwnerDraw = true;
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
            {
                switch (matchKind)
                {
                    case 0:
                    default:
                        filter = TextMatchFilter.Contains(olv, txt);
                        break;
                    case 1:
                        filter = TextMatchFilter.Prefix(olv, txt);
                        break;
                    case 2:
                        filter = TextMatchFilter.Regex(olv, txt);
                        break;
                }
            }
            // Setup a default renderer to draw the filter matches
            if (filter == null)
            {
                olv.DefaultRenderer = null;
                olv.ModelFilter = null;
            }
            else
            {
                olv.DefaultRenderer = new HighlightTextRenderer(filter);
                olv.ModelFilter = filter;
                // Uncomment this line to see how the GDI+ rendering looks
                //olv.DefaultRenderer = new HighlightTextRenderer { Filter = filter, UseGdiTextRendering = false };
            }

            // Some lists have renderers already installed
            HighlightTextRenderer highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            IList objects = olv.Objects as IList;
            if ((objects == null) || (objects.Count == olv.Items.Count))
                this.toolStripStatusLabel1.Text = string.Empty;
            else
                this.toolStripStatusLabel1.Text =
                    String.Format("Filtered {0} items down to {1} items",
                                  objects.Count,
                                  olv.Items.Count);
        }
        #endregion


        private void frmVCard_SizeChanged(object sender, EventArgs e)
        {
            pnlLeft.Width = this.Width - 150;
        }

        private void frmVCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(txtOutputLocation);
            bool changed = false;
            foreach (tblCrediteur d in crediteuren)
            {
                if (d.Dirty)
                {
                    changed = true;
                    break;
                }
            }
            if (changed)
            {
                DialogResult dr = MessageBox.Show("Save changes?", "Save changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    cmdSave.PerformClick();
                }
                else
                {
                    dataAdaptor.CancelTransaction(true);
                }


            }
 //           e.Cancel = false;
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            tblCrediteur vc2 = new tblCrediteur(crediteuren);
            olvVCard.AddObject(vc2);
            olvVCard.EnsureModelVisible(vc2);
            toolStripStatusLabel1.Text = "Nieuwe Crediteur toegevoegd";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            tblCrediteur crediteur = (tblCrediteur)olvVCard.SelectedObject;
            if (crediteur == null) return;

            olvVCard.RemoveObject(crediteur);

            // verwijderen uit de dataset.
            dataAdaptor.DeleteCrediteur(crediteur);
            dataAdaptor.CommitTransaction(true);
            toolStripStatusLabel1.Text = "Crediteur verwijderd";
        }

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtOutputLocation.Text = folderBrowserDialog1.SelectedPath;
        }
 
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmPrintObjectListView(olvVCard, "Crediteuren").ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdaptor.UpdateCrediteuren(crediteuren);
                dataAdaptor.CommitTransaction(true);
                toolStripStatusLabel1.Text = "Bewaard";
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
//                MessageBox.Show("Er zijn nog openstaande rekeningen voor dit lid", "Waarschuwing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
