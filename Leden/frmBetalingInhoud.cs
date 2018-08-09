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
    public partial class frmBetalingInhoud : frmBasis
    {
        BetalingenLijst localRekeningen = new BetalingenLijst();


        public frmBetalingInhoud(DataAdapters da)
        {
            #region Initialize
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\BetalingInhoud");
            localRekeningen = da.VulBetalingRecords();

            param = new tblParameters();

            var reks = from rek in localRekeningen where !rek.Verstuurd orderby rek.AanmaakDatum select rek;
            // het gebruik van rekeningen geeft een cast error! Daarom maar reks
            //  weer een mooie Linq. Alleen de OrderBy heeft waarschijnlijk ruzie met grouping van OLV

            InitializeDataListView(olvVCard);

            #endregion

            #region Create Columns
            OLVColumn colNaam = new OLVColumn("Naam", "IBAN_Creditor");
            OLVColumn colDatum = new OLVColumn("Datum", "AanmaakDatum");
            OLVColumn dlvc03 = new OLVColumn("Omschrijving", "Omschrijving");
            OLVColumn dlvc04 = new OLVColumn("End To End Id", "EndToEndId");
            OLVColumn colBedrag  = new OLVColumn("Bedrag","TotaalBedrag");
            OLVColumn colType = new OLVColumn("Type", "TypeBetaling");
            OLVColumn colVerwerkingsDatum = new OLVColumn("Verw, Datun", "GewensteVerwerkingsDatum");
            
            colNaam.Width = 170;
            colDatum.Width = 90;
            dlvc03.Width = 210;
            dlvc04.Width = 150;
            colBedrag.Width = 70;
            colType.Width = 90;
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

            olvVCard.Columns.Add(colType);
            olvVCard.Columns.Add(colNaam);
            olvVCard.Columns.Add(dlvc03);
            olvVCard.Columns.Add(dlvc04);
            olvVCard.Columns.Add(colBedrag);
            olvVCard.Columns.Add(colDatum);
            olvVCard.Columns.Add(colVerwerkingsDatum);

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

            #endregion
            olvVCard.SecondarySortColumn = colDatum;
            olvVCard.SetObjects(reks);
        }
        #region Elfproef
        //1 *  5 =  5	1 * 16384 =  16384	1 * 1<<14 =  16384
//2 *  8 = 16	2 *  8192 =  16384	2 * 1<<13 =  16384
//3 *  4 = 12	3 *  4096 =  12288	3 * 1<<12 =  12288
//4 *  2 =  8	4 *  2048 =   8192	4 * 1<<11 =   8192
//5 *  1 =  5	5 *  1024 =   5120	5 * 1<<10 =   5120
//6 *  6 = 36	6 *   512 =   3072	6 * 1<<9  =   3072
//7 *  3 = 21	7 *   256 =   1792	7 * 1<<8  =   1792
//8 *  7 = 56	8 *   128 =   1024	8 * 1<<7  =   1024
//9 *  9 = 81	9 *    64 =    576	9 * 1<<6  =    576
//1 * 10 = 10	1 *    32 =     32	1 * 1<<5  =     32
//2 *  5 = 10	2 *    16 =     32	2 * 1<<4  =     32
//3 *  8 = 24	3 *     8 =     24	3 * 1<<3  =     24
//4 *  4 = 16	4 *     4 =     16	4 * 1<<2  =     16
//5 *  2 = 10	5 *     2 =     10	5 * 1<<1  =     10
//-----------+    ------------------+
//        310                  64946

//Controlecijfer van "012345678912345 ": 11 - ( 310 % 11) = 9 --> 9 
//Controlecijfer van "012345678912345 ": 11 - ( 64946 % 11) = 9 --> 9

        //public static bool ValidateBetalingsKenmerk(string value)
        //{
        //    if (value.Length < 7) return false;
        //    if (value.Length == 7) return true;

        //    int[] weights = { 12, 4, 8, 5, 10, 9, 7, 3, 6, 12, 4, 8, 5 };




        //    return true;
        //}

        //public static bool ValidateElfProef(long value)
        //{ long divisor =  2, 4, 8, 5, 10, 9, 7, 3, 6, 12, 4, 8, 5,
        //    long total = 0;
        //    long result = value;
        //    for (int i = 9; i > 1; i--)
        //        total += i * Math.DivRem(result, divisor /= 10, out result); 
        //    long rest;
        //    Math.DivRem(total, 11, out rest); 
        //    return result == rest;
        //}
        
        //public static bool ValidateElfProef(string value)
        //{
        //    return ValidateElfProef(Convert.ToInt64(value));
        //}
#endregion

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
            new frmPrintObjectListView(olvVCard, "Openstaande betalingen").ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }

      
    }

}
