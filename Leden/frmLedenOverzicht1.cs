using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Util.Forms;

namespace Leden.Net
{
    public partial class frmLedenOverzicht1 : frmBasis
    {
        private DataAdapters dataAdaptor;
        private LedenLijst leden;
        public frmLedenOverzicht1(DataAdapters da, tblParameters.LedenLijstType lijstType)
        {
            InitializeComponent();
            leden = da.VulLedenLijst();
            dataAdaptor = da;
            param = new tblParameters();

            InitializeDataListView(olvVrijwilligers);

            #region Create Columns

            OLVColumn dlvc01 = new OLVColumn("Naam", "VolledigeNaam");
            // vrijwilligers
            OLVColumn dlvc02 = new OLVColumn("Regeling Toepassen", "VrijwillgersRegelingIsVanToepassing");
            OLVColumn dlvc03 = new OLVColumn("Afgekocht", "VrijwillgersAfgekocht");
            OLVColumn dlvc04 = new OLVColumn("Vaste Vrijwilliger", "VrijwillgersVasteTaak");
            //OLVColumn dlvc05 = new OLVColumn("Uitgevoerd", "VrijwillgersTaakUitgevoerd");
            OLVColumn dlvc06 = new OLVColumn("Toelichting", "VrijwillgersToelichting");

            // Toernooien
            OLVColumn dlvc12 = new OLVColumn("Ranglijst", "IsRanglijstSpeler");
            OLVColumn dlvc13 = new OLVColumn("Toernooi", "IsToernooiSpeler");
            OLVColumn dlvc14 = new OLVColumn("LB", "LidBond");
            OLVColumn dlvc15 = new OLVColumn("CG", "CompGerechtigd");

            dlvc01.Width = 180;
            dlvc02.Width = 60;
            dlvc03.Width = 60;
            dlvc04.Width = 60;
            //dlvc05.Width = 60;
            dlvc06.Width = 180;

            dlvc12.Width = 60;
            dlvc13.Width = 60;
            dlvc14.Width = 60;
            dlvc15.Width = 60;

            //dlvc01.UseInitialLetterForGroup = true;
            //dlvc02.UseInitialLetterForGroup = true;
            //dlvc03.UseInitialLetterForGroup = true;
            //dlvc04.UseInitialLetterForGroup = true;
            //dlvc05.UseInitialLetterForGroup = true;
            //dlvc06.UseInitialLetterForGroup = true;

            dlvc02.CheckBoxes = true;
            dlvc03.CheckBoxes = true;
            dlvc04.CheckBoxes = true;
            //dlvc05.CheckBoxes = true;

            dlvc12.CheckBoxes = true;
            dlvc13.CheckBoxes = true;
            dlvc14.CheckBoxes = true;
            dlvc15.CheckBoxes = true;


            dlvc02.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc03.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc04.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc05.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc05.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            dlvc12.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc13.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc14.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc15.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            //dlvc16.CheckBoxes = true;
            //dlvc16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            //dlvc16.ToolTipText = "Is dit contact toegevoegd via Leden administratie?";
            //dlvc16.TriStateCheckBoxes = true;
            //dlvc16.HeaderCheckBox = true;

            if (lijstType ==  tblParameters.LedenLijstType.Vrijwilligers)    
            {
                olvVrijwilligers.Columns.Add(dlvc01);
                olvVrijwilligers.Columns.Add(dlvc02);
                olvVrijwilligers.Columns.Add(dlvc03);
                olvVrijwilligers.Columns.Add(dlvc04);
                //olvVrijwilligers.Columns.Add(dlvc05);
                olvVrijwilligers.Columns.Add(dlvc06);
                pnlGrid.Width = 561;
                this.Text = "Vrijwilligers Overzicht";
            }
            else if (lijstType ==  tblParameters.LedenLijstType.Toernooien)    
            {
                olvVrijwilligers.Columns.Add(dlvc01);
                olvVrijwilligers.Columns.Add(dlvc12);
                olvVrijwilligers.Columns.Add(dlvc13);
                olvVrijwilligers.Columns.Add(dlvc14);
                olvVrijwilligers.Columns.Add(dlvc15);
                this.Text = "Toernooi Overzicht";
                pnlGrid.Width = 441;
            }
            else if (lijstType == tblParameters.LedenLijstType.Selected)
            {
                dlvc01.Width = 600;
                olvVrijwilligers.Columns.Add(dlvc01);
                this.Text = "Leden Overzicht";
                pnlGrid.Width = 621;
            }
            else return;

            #endregion
            olvVrijwilligers.SetObjects(leden);
            olvVrijwilligers.ModelFilter = new FilterSelectSenOrJun(rbuSenioren.Checked);
            _windowState = new PersistWindowState(this, @"Leden\LedenOverzicht");

        }
        #region InitializeDataListView
        private void InitializeDataListView(FastObjectListView olv)
        {
            olv.UseAlternatingBackColors = true;
            olv.AlternateRowBackColor = Color.Bisque;
            olv.ShowItemCountOnGroups = true;
            olv.OwnerDraw = true;  // Zonder dit attribuut werden de checkboxes niet getekend maar kwam er True/False te staan.
            olv.FullRowSelect = true;
            //olv.CheckBoxes = true;
            olv.CellEditActivation = FastObjectListView.CellEditActivateMode.DoubleClick;
            olv.UseFiltering = true;
            olv.UseFilterIndicator = true;
            olv.GroupWithItemCountFormat = "{0} ({1} Leden)";
            olv.GroupWithItemCountSingularFormat = "{0} ({1} Lid)";
            olv.HeaderWordWrap = true;
            olv.View = System.Windows.Forms.View.Details;
            olv.ShowGroups = false;
            olv.EmptyListMsg = "This list is empty.";
            olv.AddDecoration(new EditingCellBorderDecoration(true));
            olv.UseSubItemCheckBoxes = true;
            // Make the tooltips look somewhat different
            //olv.CellToolTip.BackColor = Color.Black;
            //olv.CellToolTip.ForeColor = Color.AntiqueWhite;
            //olv.HeaderToolTip.BackColor = Color.AntiqueWhite;
            //olv.HeaderToolTip.ForeColor = Color.Black;
            //olv.HeaderToolTip.IsBalloon = true;
        }
        #endregion

       private void frmLedenOverzicht1_Activated(object sender, EventArgs e)
        {
            // In Activated omdat deze komt na de onload waar PersistWindowState gebruik van maakt.
            this.Size = new Size(pnlGrid.Width + 150, _windowState.Parent.Height);
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            dataAdaptor.UpdateLeden(leden);
            dataAdaptor.CommitTransaction(true);
            toolStripStatusLabel1.Text = "Bewaard";
        }

        private void rbu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuSenioren.Checked)
                olvVrijwilligers.ModelFilter = new FilterSelectSenOrJun(true);
            if (rbuJunioren.Checked)
                olvVrijwilligers.ModelFilter = new FilterSelectSenOrJun(false);
            if (rbuGemerkt.Checked)
                olvVrijwilligers.ModelFilter = new FilterSelected();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmPrintObjectListView(olvVrijwilligers, this.Text).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
     }

    /// <summary>
    /// Dit Filter selecteer alle rekeningen met een bepaald Lidnr
    /// </summary>
    public class FilterSelectSenOrJun : IModelFilter
    {
        bool senior = true;
        public FilterSelectSenOrJun(bool senioren)
        {
            senior = senioren;
        }

        public bool Filter(object modelObject)
        {
            return ((tblLid)modelObject).Is_SEN1_65_SEN == senior;
        }
    }

    public class FilterSelected : IModelFilter
    {
       public bool Filter(object modelObject)
        {
            return ((tblLid)modelObject).Gemerkt;
        }
    }



}