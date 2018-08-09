using System;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Util.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;
using System.Diagnostics;
using System.Collections;

namespace Leden.Net
{
    public partial class frmIncassoInhoud2 : frmBasis
    {
        RekeningenLijst localRekeningen = new RekeningenLijst();
        public frmIncassoInhoud2(DataAdapters da)
        {
            #region Initialize
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\IncassoInhoud");

            RekeningenLijst r = da.VulRekeningRecords();
            param = new tblParameters();

            var reks = from rek in r where !rek.Verstuurd && rek.Lid.IsIncasso orderby rek.AanmaakDatum select rek;
            // het gebruik van rekeningen geeft een cast error! Daarom maar reks
            //  weer een mooie Linq. Alleen de OrderBy heeft waarschijnlijk ruzie met grouping van OLV

            InitializeDataListView(olvVCard);

            #endregion

            #region Create Columns
            OLVColumn colNaam = new OLVColumn("Naam", "Naam");
            OLVColumn colDatum  = new OLVColumn("Datum","Datum");
            OLVColumn dlvc03  = new OLVColumn("Omschrijving", "Omschrijving");
            OLVColumn colBedrag  = new OLVColumn("Bedrag","TotaalBedrag");
            OLVColumn colSeq  = new OLVColumn("IncSeq", "Inc Seq");
            OLVColumn colType = new OLVColumn("Type", "TypeRekening");
            
            colNaam.Width = 170;
            colBedrag.Width = 70;
            dlvc03.Width = 210;
            colDatum.Width = 90;
            colSeq.Width = 50;
            colType.Width = 90;

            colNaam.UseInitialLetterForGroup = true;
            colBedrag.UseInitialLetterForGroup = true;
            colBedrag.AspectToStringFormat = "{0:C}";
            colBedrag.TextAlign = HorizontalAlignment.Right;
           // dlvc03.UseInitialLetterForGroup = true;
            colDatum.Sortable = true;
            colDatum.TextAlign = HorizontalAlignment.Right;
            colDatum.UseInitialLetterForGroup = true;
            colSeq.UseInitialLetterForGroup = true;
            colType.UseInitialLetterForGroup = true;

            olvVCard.Columns.Add(colType);
            olvVCard.Columns.Add(colNaam);
            olvVCard.Columns.Add(colSeq);
            olvVCard.Columns.Add(dlvc03);
            olvVCard.Columns.Add(colBedrag);
            olvVCard.Columns.Add(colDatum);

            colType.AspectGetter = delegate(object row)
            {
                if (((tblRekening)row).TypeRekening == 0)
                    return "Contributie";
                return "Overig";
            };

            colNaam.AspectGetter = delegate(object row)
            {
                tblLid lid = ((tblRekening)row).Lid;
                if (lid != null)
                    return lid.VolledigeNaam;
                return string.Empty;
            };


            colSeq.AspectGetter = delegate(object row)
            {
                tblLid lid = ((tblRekening)row).Lid;
                if (lid != null)
                    if (lid.Geincasseerd)
                        return "RCUR";
                    else
                        return "FRST";
                return string.Empty;
            };

            colDatum.AspectGetter = delegate(object row)
            {
                return ((tblRekening)row).AanmaakDatum.ToShortDateString();
            };

            #endregion
            olvVCard.SecondarySortColumn = colDatum;
            olvVCard.SetObjects(reks);
        }

        #region InitializeDataListView
        private void InitializeDataListView(FastObjectListView olv)
        {
            olv.UseAlternatingBackColors = true;
            olv.AlternateRowBackColor = Color.Bisque;
            olv.ShowItemCountOnGroups = true;
            olv.OwnerDraw = true;  // Zonder dit attribuut werden de checkboxes niet getekend maar kwam er True/False te staan.
            olv.FullRowSelect = true;
         //   olv.CheckBoxes = true;
            olv.CellEditActivation = FastObjectListView.CellEditActivateMode.None;
            olv.UseFiltering = true;
            olv.UseFilterIndicator = true;
            olv.GroupWithItemCountFormat = "{0} ({1} rekeningen)";
            olv.GroupWithItemCountSingularFormat = "{0} ({1} rekening)";
            olv.HeaderWordWrap = true;
            olv.View = System.Windows.Forms.View.Details;
            olv.ShowGroups = true;
            olv.EmptyListMsg = "This list is empty.";
            olv.UseSubItemCheckBoxes = true;  // moet aan staan om checkboxes op de print te laten zien!
        }
        #endregion

        private void frmVCard_SizeChanged(object sender, EventArgs e)
        {
            pnlLeft.Width = this.Width - 150;
        }

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

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmPrintObjectListView(olvVCard, "Incasso Inhoud").ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
    }
}
