using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

using BrightIdeasSoftware;
// In geval van gebruik ObjectListView:
// De OLV Printer geeft geen checkboxes weer op op de printerview. Geen idee waarom niet. Het werkt met een paar aanpassingen.
// Voeg een FastObjectView aan het Form toe en plaats onderstaande regels in de designer.cs
//            fastObjectListView1.CheckBoxes = true;
//            fastObjectListView1.SmallImageList = this.imageList1;
//            fastObjectListView1.Visible = false;
// Dus gebruik FastObjectView

namespace Leden.Net
{
    public partial class frmPrintObjectListView : frmBasis
    {
        FastObjectListView objListView;
        public frmPrintObjectListView(FastObjectListView olv, string header)
        {
            InitializeComponent();
            param = new tblParameters();
            objListView = olv;
            listViewPrinter1.ListView = olv;
            tbHeader.Text = @"\t" + header;
            tbFooter.Text = @"{1:f}\t" + param.ClubNameShort + @"\tPagina #{0}";
            tbWatermark.Text = string.Empty;
        }

        #region Zoom radiobuttons
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 2.0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1.0;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 0.5;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.printPreviewControl1.Zoom = 1.0;
            this.printPreviewControl1.AutoZoom = true;
        }
#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PageSetup();
            this.UpdatePrintPreview(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PrintPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.listViewPrinter1.PrintWithDialog();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int pages = (int)this.numericUpDown1.Value;

            switch (pages)
            {
                case 1:
                case 2:
                case 3:
                    this.printPreviewControl1.Rows = 1;
                    this.printPreviewControl1.Columns = pages;
                    break;
                default:
                    this.printPreviewControl1.Rows = 2;
                    this.printPreviewControl1.Columns = ((pages - 1) / 2) + 1;
                    break;
            }
        }

        private void UpdatePrintPreview(object sender, EventArgs e)
        {
            this.listViewPrinter1.Header = this.tbHeader.Text.Replace("\\t", "\t");
            this.listViewPrinter1.Footer = this.tbFooter.Text.Replace("\\t", "\t");
            this.listViewPrinter1.Watermark = this.tbWatermark.Text;

            this.listViewPrinter1.IsShrinkToFit = this.cbShrinkToFit.Checked;
            this.listViewPrinter1.IsListHeaderOnEachPage = this.cbListHeaderOnEveryPage.Checked;
            this.listViewPrinter1.IsPrintSelectionOnly = this.cbPrintSelection.Checked;

            if (this.rbStyleMinimal.Checked == true)
                this.ApplyMinimalFormatting();
            else if (this.rbStyleModern.Checked == true)
                this.ApplyModernFormatting();

            if (this.cbUseGridLines.Checked == false)
                this.listViewPrinter1.ListGridPen = null;

            this.printPreviewControl1.InvalidatePreview();
        }

        /// <summary>
        /// Give the report a minimal set of default formatting values.
        /// </summary>
        public void ApplyMinimalFormatting()
        {
            this.listViewPrinter1.CellFormat = null;
            this.listViewPrinter1.ListFont = new Font("Verdana", 9);
            this.listViewPrinter1.ListGridPen = new Pen(Color.LightGray, 0.5f);

            this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 24, FontStyle.Bold));
            this.listViewPrinter1.HeaderFormat.TextBrush = Brushes.Black;
            this.listViewPrinter1.HeaderFormat.BackgroundBrush = null;
            this.listViewPrinter1.HeaderFormat.SetBorderPen(Sides.Bottom, new Pen(Color.Black, 0.5f));

            this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
            this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            this.listViewPrinter1.GroupHeaderFormat.SetBorder(Sides.Bottom, 2, new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.LightGray, Color.White, LinearGradientMode.Horizontal));

            this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader();
            this.listViewPrinter1.ListHeaderFormat.BackgroundBrush = null;

            this.listViewPrinter1.WatermarkFont = null;
            this.listViewPrinter1.WatermarkColor = Color.Empty;
        }

        /// <summary>
        /// Give the report a minimal set of default formatting values.
        /// </summary>
        public void ApplyModernFormatting()
        {
            this.listViewPrinter1.CellFormat = null;
            this.listViewPrinter1.ListFont = new Font("Verdana", 9);
            this.listViewPrinter1.ListGridPen = new Pen(Color.DarkGray, 0.5f);

            this.listViewPrinter1.HeaderFormat = BlockFormat.Header(new Font("Verdana", 24, FontStyle.Bold));
            this.listViewPrinter1.HeaderFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.DarkBlue, Color.White, LinearGradientMode.Horizontal);

            this.listViewPrinter1.FooterFormat = BlockFormat.Footer();
            this.listViewPrinter1.FooterFormat.BackgroundBrush = new LinearGradientBrush(new Rectangle(0, 0, 1, 1), Color.White, Color.DarkBlue, LinearGradientMode.Horizontal);

            this.listViewPrinter1.GroupHeaderFormat = BlockFormat.GroupHeader();
            this.listViewPrinter1.ListHeaderFormat = BlockFormat.ListHeader(new Font("Verdana", 12));

            this.listViewPrinter1.WatermarkFont = null;
            this.listViewPrinter1.WatermarkColor = Color.Empty;
        }



        private void ApplyPenData(BlockFormat blockFormat)
        {
            blockFormat.BackgroundBrushData = blockFormat.BackgroundBrushData;
            blockFormat.BottomBorderPenData = blockFormat.BottomBorderPenData;
            blockFormat.LeftBorderPenData = blockFormat.LeftBorderPenData;
            blockFormat.RightBorderPenData = blockFormat.RightBorderPenData;
            blockFormat.TextBrushData = blockFormat.TextBrushData;
            blockFormat.TopBorderPenData = blockFormat.TopBorderPenData;
        }


    }
 
}
