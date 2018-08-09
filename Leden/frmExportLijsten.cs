using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util.Extensions;
using Util.Forms;
using Util.Text;
using Util.Comms;
using Word = Microsoft.Office.Interop.Word;
using System.Net;

namespace Leden.Net
{
    public partial class frmExportLijsten : frmBasis
    {
        string ledenNaamFileName, ledenLeeftijdFileName;
        string jeugdNaamFileName, jeugdLeeftijdFileName;
        string ledenNaamFileNameDoc, jeugdNaamFileNameDoc;
        string ledenMailFileNameDoc, jeugdMailFileNameDoc;
        string verjaardagsFileName;
        string inschrijfToernooiLijst, penningmeesterLijst;
        DataAdapters dataAdapter;

        ResultatenLijst resultaten = new ResultatenLijst();
        LedenLijst leden;
        // create MS-Word application  
        Word.Application msWord;
        Document doc;

        // Create misssing value object 
        object objMiss = System.Reflection.Missing.Value;
        // Create end of document object
        object endofdoc = "\\endofdoc";

        public frmExportLijsten(object l, tblParameters Param)
        {
            InitializeComponent();
            param = Param;
            if (l is DataAdapters)
            {
                leden = ((DataAdapters)l).VulLedenLijst();
                dataAdapter = (DataAdapters)l;  //nodig voor de exportformail
                resultaten = ((DataAdapters)l).VulCompResultRecords();
            }
            if (l is LedenLijst)
                leden = (LedenLijst)l;

            _windowState = new PersistWindowState(this, @"Leden\ExportLijsten");

            txtOutputLocation.Text = param.ltxtOutputLocation;
            txtEmailLeden.Text = param.ltxtEmailLeden;
            txtEmailJeugd.Text = param.ltxtEmailJeugd;
            
            /*
            PersistControlValue.ReadControlValue(txtOutputLocation);
            PersistControlValue.ReadControlValue(txtEmailLeden);
            PersistControlValue.ReadControlValue(txtEmailJeugd);
            */
        }

        #region Bestandsnamen
        private void determineFileLocations()
        {
            ledenNaamFileName = txtOutputLocation.Text +       @"\" + param.ClubNameShort + "_Ledenlijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_naam.csv";
            ledenLeeftijdFileName = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_LedenLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_leeftijd.csv";
            jeugdNaamFileName = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_JeugdLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_naam.csv";
            jeugdLeeftijdFileName = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_JeugdLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_leeftijd.csv";
            ledenNaamFileNameDoc = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_LedenLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_naam.doc";
            jeugdNaamFileNameDoc = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_JeugdLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + "_op_naam.doc";
            ledenMailFileNameDoc = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_Maillijst_per_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            jeugdMailFileNameDoc = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_MaillijstJeugd_per_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            inschrijfToernooiLijst = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_ToernooiInschrijfLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            penningmeesterLijst = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_PenningmeesterLijst_per_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";
            verjaardagsFileName = txtOutputLocation.Text + @"\" + param.ClubNameShort + "_Verjaardagslijst_per_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        }
        #endregion

        private void cmdExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                #region Create CSV op Naam
                Cursor = Cursors.WaitCursor;
                determineFileLocations();
                // Sorteer op Naam
                leden.Sort(new LedenComparer());

                StreamWriter ledenWriter = new StreamWriter(ledenNaamFileName);
                StreamWriter jeugdWriter = new StreamWriter(jeugdNaamFileName);
                StreamWriter penningmeesterWriter = new StreamWriter(penningmeesterLijst);
                ledenWriter.WriteLine(WriteHeader());
                jeugdWriter.WriteLine(WriteHeader());
                penningmeesterWriter.WriteLine(WritePenningmeesterHeader());

                foreach (tblLid lid in leden)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    ledenWriter.WriteLine(WriteLid(lid));
                    penningmeesterWriter.WriteLine(WritePenningmeester(lid));
                    if (lid.Is_WLP_PUP_CAD_JUN_SEN1)
                    {
                        jeugdWriter.WriteLine(WriteLid(lid));

                    }
                }
                ledenWriter.Flush();
                ledenWriter.Close();
                jeugdWriter.Flush();
                jeugdWriter.Close();
                penningmeesterWriter.Flush();
                penningmeesterWriter.Close();
                
                #endregion
                toolStripStatusLabel1.Text = "CSV op naam gemaakt";

                #region Create CSV op Leefdtijd
                leden.Sort(new LedenComparer("GeboorteDatum"));
                StreamWriter toernooiWriter = new StreamWriter(inschrijfToernooiLijst);
                ledenWriter = new StreamWriter(ledenLeeftijdFileName);
                jeugdWriter = new StreamWriter(jeugdLeeftijdFileName);
                ledenWriter.WriteLine(WriteHeader());
                jeugdWriter.WriteLine(WriteHeader());

                foreach (tblLid lid in leden)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    ledenWriter.WriteLine(WriteLid(lid));
                    if (lid.Is_WLP_PUP_CAD_JUN_SEN1)
                    {
                        jeugdWriter.WriteLine(WriteLid(lid));
                        tblCompResult cr = resultaten.GetLatestResult(lid.LidNr);
                        if (cr == null)
                            cr = new tblCompResult(lid);
                        toernooiWriter.WriteLine(WriteToernooiregel(cr));
                    }
                }
                ledenWriter.Flush();
                ledenWriter.Close();
                jeugdWriter.Flush();
                jeugdWriter.Close();
                toernooiWriter.Flush();
                toernooiWriter.Close();
                #endregion
                toolStripStatusLabel1.Text = "CSV op leeftijd gemaakt";

                #region Create Maillijsten
                // Sorteer op Naam
                leden.Sort(new LedenComparer());

                ledenWriter = new StreamWriter(ledenMailFileNameDoc);
                jeugdWriter = new StreamWriter(jeugdMailFileNameDoc);

                foreach (tblLid lid in leden)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    foreach (EmailAdresLid s in lid.EmailAdresses)
                    {
                        ledenWriter.WriteLine(s.EmailWithDisplayName);
                        if (lid.Is_WLP_PUP_CAD_JUN_SEN1)
                            jeugdWriter.WriteLine(s.EmailWithDisplayName);
                    }
                }

                ledenWriter.Flush();
                ledenWriter.Close();
                jeugdWriter.Flush();
                jeugdWriter.Close();
                #endregion
                toolStripStatusLabel1.Text = "Maillijsten gemaakt";

                #region Create Maillijsten
                // Sorteer op Naam
                leden.Sort(new LedenComparer("Verjaardag"));

                ledenWriter = new StreamWriter(verjaardagsFileName);

                foreach (tblLid lid in leden)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    ledenWriter.WriteLine("{0}-{1} {2}", lid.GeboorteDatum.Day.ToString("00"), lid.GeboorteDatum.Month.ToString("00"), lid.NetteNaam);
                }

                ledenWriter.Flush();
                ledenWriter.Close();
                #endregion
                toolStripStatusLabel1.Text = "Verjaardagslijst gemaakt";
                
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }

            try
            {
                msWord = new Word.Application();
            }
            catch (Exception ex)
            {
                ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            try
            {
                #region Create Doc op Naam
                // show ms-word application
                msWord.Visible = false;
                // add blank documnet in word application
                doc = msWord.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);
                CreateTextStyleType(doc, 9);
                
                doc.Sections.PageSetup.DifferentFirstPageHeaderFooter = -1;//true = -1
                doc.Sections.PageSetup.TopMargin = msWord.CentimetersToPoints(1f);
                doc.Sections.PageSetup.BottomMargin = msWord.CentimetersToPoints(1f);
                doc.Sections.PageSetup.LeftMargin = msWord.CentimetersToPoints(1.5f);
                doc.Sections.PageSetup.RightMargin = msWord.CentimetersToPoints(1f);
                msWord.Selection.set_Style("LedenText");
                AddTabsToLedenParagraph(msWord.Selection.Paragraphs);
                
                AddWordHeaderAlleLeden(doc);
//                AddWordFooter(doc);

                leden.Sort(new LedenComparer());

                Paragraph para;

                foreach (tblLid lid in leden)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    para = doc.Sections[1].Range.Paragraphs.Add(objMiss);
                    para.set_Style("LedenText");
                    para.Range.Text = CreateLidRegel(lid);
                    para.Format.SpaceAfter = 5;
                    para.Range.InsertParagraphAfter();
                }

                List<string> stats = CreateStats();
                foreach (string s in stats)
                {
                    para = doc.Sections[1].Range.Paragraphs.Add(objMiss);
                    para.set_Style("LedenText");
                    para.Range.Text = s;
                    para.Format.SpaceAfter = 5;
                    para.Range.InsertParagraphAfter();
                }
                doc.SaveAs(ledenNaamFileNameDoc);
                System.Threading.Thread.Sleep(200);
                ((Microsoft.Office.Interop.Word._Document)doc).Close();
                System.Threading.Thread.Sleep(200);

                #endregion

                #region Create Doc Jeugdlijst

                doc= msWord.Documents.Add(ref objMiss, ref objMiss, ref objMiss, ref objMiss);
                System.Threading.Thread.Sleep(200);
                CreateTextStyleType(doc, 8);

                doc.Sections.PageSetup.DifferentFirstPageHeaderFooter = -1;//true = -1
                doc.Sections.PageSetup.Orientation = WdOrientation.wdOrientLandscape;
                doc.Sections.PageSetup.TopMargin = msWord.CentimetersToPoints(1f);
                doc.Sections.PageSetup.BottomMargin = msWord.CentimetersToPoints(1f);
                doc.Sections.PageSetup.LeftMargin = msWord.CentimetersToPoints(1.5f);
                doc.Sections.PageSetup.RightMargin = msWord.CentimetersToPoints(0.5f);

                AddTabsToJeugdParagraph(msWord.Selection.Paragraphs);
                AddWordHeaderJeugdLeden(doc);
//                AddWordFooter(doc);

//                leden.Sort(new LedenComparer("GeboorteDatum"));

                // We maken gebruik van Linq. Gewoon omdat het kan.
                var jeugdQuery = from lid in leden where lid.Is_WLP_PUP_CAD_JUN_SEN1 orderby lid.GeboorteDatum select lid;
                                  
                foreach (var lid in jeugdQuery)
                {
                    if (chkOnlyMarked.Checked && !lid.Gemerkt) continue;
                    para = doc.Sections[1].Range.Paragraphs.Add(objMiss);
                    para.set_Style("LedenText");
                    para.Range.Text = CreateJeugdRegel(lid,resultaten.GetLatestResult(lid.LidNr));
                    para.Format.SpaceAfter = 1;
                    para.Range.InsertParagraphAfter();
                }
                doc.SaveAs(jeugdNaamFileNameDoc);
                #endregion
                toolStripStatusLabel1.Text = "Word jeugdlijst gemaakt";

                ((Microsoft.Office.Interop.Word._Document)doc).Close();

                ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
                cmdMail.Enabled = true;
                cmdUploadLijstenWebsite.Enabled = true;
                Cursor = Cursors.Arrow;
                MessageBox.Show("Lijsten aangemaakt in " + txtOutputLocation.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (System.Threading.ThreadAbortException)
            {
                // We want to exit gracefully here (if we're lucky)
            }
            catch (System.Threading.ThreadInterruptedException)
            {
                // And here, if we can
            }
            catch (Exception ex)
            {
                ((Microsoft.Office.Interop.Word._Document)doc).Close();
                ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            finally
            {
            }
        }

        private List<string> CreateStats()
        {
            List<string> stats = new List<string>();
            int sen= 0, sen1=0, jun=0, cad=0, pup=0, wlp=0;

            foreach (tblLid lid in leden)
            {
                if (lid.Is_SEN1_65_SEN) sen++;
                if (lid.IsSEN1) sen1++;
                if (lid.IsJUN) jun++;
                if (lid.IsCAD) cad++;
                if (lid.IsPUP) pup++;
                if (lid.IsWLP) wlp++;
            }

            int jgd = jun + cad + pup + wlp;
            stats.Add("Aantal Leden:\t" + leden.Count.ToString());
            stats.Add("Senioren    :\t" + sen.ToString() + " (Sen1: " + sen1.ToString() + ")");
            stats.Add("Jeugd       :\t" + jgd.ToString() + " (Jun: " + jun.ToString() + " / Cad: " + cad.ToString() + " / Pup: " + pup.ToString() + " / Wlp: " + wlp.ToString() + ")");
            return stats;                 
        }

        #region Add tabs
        //     Moreno Abrahams 3932183 M 7/23/2002 wlp2 10 06-48387098 yuri@yuri.pro jootje@jootje.com

        private void AddTabsToLedenParagraph(Paragraphs param)
        {
            param.TabStops.ClearAll();
            param.TabStops.Add(120f);
            param.TabStops.Add(270f);
            param.TabStops.Add(360f);
            param.TabStops.Add(450f);
        }

        private void AddTabsToLedenParagraph(Paragraph param)
        {
            param.TabStops.ClearAll();
            param.TabStops.Add(120f);
            param.TabStops.Add(270f);
            param.TabStops.Add(360f);
            param.TabStops.Add(450f); 
        }

        private void AddTabsToJeugdParagraph(Paragraphs param)
        {
            int i = 95;
            param.TabStops.ClearAll();
            param.TabStops.Add(i);          // Bondsnummer
            param.TabStops.Add(i += 35);    // LidBond
            param.TabStops.Add(i += 15);    // CompGerecht
            param.TabStops.Add(i += 15);    // Licentie
            param.TabStops.Add(i += 15);    // percentage
            param.TabStops.Add(i += 30);    // Gebdat
            param.TabStops.Add(i += 60);    // Geslacht
            param.TabStops.Add(i += 15);    // Leefdtijdcat
            param.TabStops.Add(i += 30);    // Leeftijd
            param.TabStops.Add(i += 20);    // Telnr
            param.TabStops.Add(i += 60);   // mobiel
            param.TabStops.Add(i += 60);   // email
            param.TabStops.Add(i += 140);   // email
            param.TabStops.Add(i += 130);   
        }
        
        #endregion

        #region Trash
        /// <summary>
        /// This Method create table in ms-word document
        /// </summary>
        public void CreateTable(int Row, int column)
        {
            // create table in word documnet in word application with table reference name tbl1
            Microsoft.Office.Interop.Word.Table tbl1;
            // calculate the range of endofdocu
            Microsoft.Office.Interop.Word.Range wordRange = doc.Bookmarks.get_Item(ref endofdoc).Range;
            // add table with document with number of row and column
            tbl1 = doc.Content.Tables.Add(wordRange, 3, 3, ref objMiss, ref objMiss);
            // set border visibility true by input 1 and false by input 0
            tbl1.Borders.Enable = 1;
            // set text in each cell of table 
            for (int r = 1; r <= 3; r++)
            {
                for (int c = 1; c <= 3; c++)
                {
                    tbl1.Cell(r, c).Range.Text = "r" + r + "c" + c;
                }
            }
        }
#endregion
  
        #region Utility functions
        //object missing = System.Reflection.Missing.Value;
        //object endOfDoc = "\\endofdoc"; /* \endofdoc is a predefined bookmark */


        //private void CreateTableStyleType(Document document, float fontSize)
        //{
        //    CreateTableStyleType(document, fontSize, WdColor.wdColorGray25, WdColor.wdColorGray15);
        //}
        //private void CreateTableStyleType(Document document, float fontSize, WdColor headerColor, WdColor rowColor)
        //{
        //    object styleType = WdStyleType.wdStyleTypeTable;
        //    Style style = document.Styles.Add("StandTable", ref styleType);
        //    TableStyle ts = style.Table;
        //    style.Font.Size = fontSize;
        //    style.Font.Name = "Arial";
        //    ts.RowStripe = 1;
        //    ConditionalStyle cs = ts.Condition(WdConditionCode.wdFirstRow);
        //    cs.Shading.BackgroundPatternColor = headerColor;
        //    cs.Font.Bold = 1;
        //    cs = ts.Condition(WdConditionCode.wdEvenRowBanding);
        //    cs.Shading.BackgroundPatternColor = rowColor;
        //}

        private void CreateTextStyleType(Document document, float fontSize)
        {
            object styleType = WdStyleType.wdStyleTypeParagraph;
            Style style = document.Styles.Add("LedenText", ref styleType);
            style.Font.Size = fontSize;
            style.Font.Name = "Arial";
            style = document.Styles.Add("LedenHeader", ref styleType);
            style.Font.Size = fontSize + 8;
            style.Font.Name = "Arial";
            style.Font.Bold = 1; //true
        }
        //private void AddEmptyLine(Document document)
        //{
        //    document.Content.Paragraphs.Add(ref missing);
        //}

        //private void AlignCellsOfTable(Table table, float topBottom, float leftRight)
        //{
        //    // De method altijd uitvoeren nadat de cellen zijn gevuld. Anders lijkt het
        //    // of deze setting verloren gaat tijdens het vullen. (Don't ask me why)
        //    table.LeftPadding = leftRight;
        //    table.RightPadding = leftRight;
        //    table.TopPadding = topBottom;
        //    table.BottomPadding = topBottom;
        //    // Geef het Word proces de tijd om het uit te voeren
        //    Thread.Sleep(2000);
        //}

        //private Table CreateTable(Document document, int nbrRows, float[] columnWidth, float preferredWidthPercent, bool tableStyle)
        //{
        //    Range wrdRng = document.Bookmarks.get_Item(ref endOfDoc).Range;

        //    Table table = document.Tables.Add(wrdRng, nbrRows, columnWidth.Length, ref missing, ref missing);
        //    table.PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
        //    table.PreferredWidth = preferredWidthPercent;
        //    // Geef het Word proces de tijd om het uit te voeren
        //    Thread.Sleep(2000);

        //    for (int i = 0; i < columnWidth.Length; i++)
        //    {
        //        table.Columns[i + 1].PreferredWidthType = WdPreferredWidthType.wdPreferredWidthPercent;
        //        table.Columns[i + 1].PreferredWidth = columnWidth[i];
        //        table.Columns[i + 1].Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
        //        // Geef het Word proces de tijd om het uit te voeren
        //        Thread.Sleep(500);
        //    }
        //    if (tableStyle)
        //    {
        //        object styleName = "StandTable";
        //        table.set_Style(ref styleName);
        //    }
        //    return table;
        //}
        //private void InsertPageBreak(Document document)
        //{
        //    Range wrdRng = document.Bookmarks.get_Item(ref endOfDoc).Range;
        //    object collapseEnd = WdCollapseDirection.wdCollapseEnd;
        //    object pageBreak = WdBreakType.wdPageBreak;
        //    wrdRng.Collapse(ref collapseEnd);
        //    wrdRng.InsertBreak(ref pageBreak);
        //    wrdRng.Collapse(ref collapseEnd);
        //}
        #endregion

        #region Word Header Alle leden
        private void AddWordHeaderAlleLeden(Document doc)
        {
            string line1 = "Ledenlijst " + param.ClubNameLong + ", " + DateTime.Now.ToString("dd MMM yyyy");
            StringBuilder lidregel = new StringBuilder();

            lidregel.Append("\t");
            lidregel.Append("Adres");
            lidregel.Append("\t");
            lidregel.Append("Geb.Datum");
            lidregel.Append("\t");
            lidregel.Append("LidVanaf");
            lidregel.Append("\t");
            lidregel.Append("M/V");
            lidregel.Append("\v");

            lidregel.Append("\t");
            lidregel.Append("Postcode Woonplaats");
            lidregel.Append("\t");
            lidregel.Append("Mobiel");
            lidregel.Append("\t");
            lidregel.Append("Telefoon");
            lidregel.Append("\t");
            lidregel.Append("BondsNr");
            lidregel.Append("\v");

            lidregel.Append("\t");
            lidregel.Append("E-mail");
            lidregel.Append("\t");
            lidregel.Append("LidType");
            lidregel.Append("\t");
            lidregel.Append("Lid Bond");
            lidregel.Append("\t");
            lidregel.Append("Comp");

            HeaderFooter header = doc.Sections.First.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage];

            Paragraph head1 = header.Range.Paragraphs.Add(objMiss);
            head1.set_Style("LedenHeader");
            head1.Range.Text = line1;
            head1.Range.Font.Bold = -1;
            head1.Format.SpaceAfter = 1;
            head1.Range.InsertParagraphAfter();
            
            Paragraph head2 = header.Range.Paragraphs.Add(head1.Range);
            head2.set_Style("LedenText");
            head2.Range.Text = lidregel.ToString();
            head2.Format.SpaceAfter = 5;

            AddTabsToLedenParagraph(head2);
        }
#endregion
        
        #region Word Header Jeugd leden
        private void AddWordHeaderJeugdLeden(Document doc)
        {
            HeaderFooter header = doc.Sections.First.Headers[WdHeaderFooterIndex.wdHeaderFooterFirstPage];

            Paragraph head1 = header.Range.Paragraphs.Add(objMiss);
            head1.set_Style("LedenHeader");
            head1.Range.Text = "Jeugdlijst " + param.ClubNameLong + ", " + DateTime.Now.ToString("dd MMM yyyy");
            head1.Range.Font.Bold = -1;
            head1.Format.SpaceAfter = 8;
        }
        #endregion
                
        #region Word AddFooter Paginanummer
        private void AddWordFooter(Document doc)
        {
            //Doesn't work :o(
            HeaderFooter footer = doc.Sections.First.Footers[WdHeaderFooterIndex.wdHeaderFooterFirstPage];

            Paragraph foot1 = footer.Range.Paragraphs.Add(objMiss);
            foot1.set_Style("LedenText");
            Object CurrentPage = Word.WdFieldType.wdFieldPage;
            foot1.Range.Text = "Pagnr: ";
            foot1.Range.Fields.Add(msWord.Selection.Range, ref CurrentPage,ref objMiss, ref objMiss);
        }
        #endregion

        #region Word Create LidRegel
        private string CreateLidRegel(tblLid lid)
        {
            try
            {
                #region
                StringBuilder lidregel = new StringBuilder();
                lidregel.Append(lid.VolledigeNaam);
                lidregel.Append("\t");
                lidregel.Append(lid.Adres);
                lidregel.Append("\t");
                lidregel.Append(lid.GeboorteDatum.ToString("yyyy-MM-dd"));
                lidregel.Append("\t");
                lidregel.Append(lid.LidVanaf.ToString("yyyy-MM-dd"));
                lidregel.Append("\t");
                lidregel.Append(lid.Geslacht);
                lidregel.Append("\v");

                lidregel.Append("\t");
                lidregel.Append(lid.Postcode + " " + lid.Woonplaats);
                lidregel.Append("\t");
                lidregel.Append(lid.Mobiel);
                lidregel.Append("\t");
                lidregel.Append(lid.Telefoon);
                lidregel.Append("\t");
                lidregel.Append(lid.BondsNr);
                lidregel.Append("\v");

                lidregel.Append("\t");
                lidregel.Append(lid.Email1);
                lidregel.Append("\t");

                switch (lid.LidType)
                {
                    case tblLid.constLidNormaal: lidregel.Append("Standaard"); break;
                    case tblLid.constLidContributieVrij: lidregel.Append("Contr.Vrij"); break;
                    case tblLid.constLidZwerflid: lidregel.Append("Zwerflid"); break;
                    case tblLid.constLidPakket: lidregel.Append("Pakket - ");
                        lidregel.Append(lid.PakketTot.ToString("yyMMdd")); break;
                    default: lidregel.Append("?"); break;
                }


                lidregel.Append("\t");
                lidregel.Append(lid.LidBond ? "J" : "N");
                lidregel.Append("\t");
                lidregel.Append(lid.CompGerechtigd ? "J" : "N");

                if (lid.Email2 != string.Empty)
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append("Email2");
                }

                if (lid.Ouder1_Email1 != "" || lid.Ouder1_Mobiel != "" || lid.Ouder1_Telefoon != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Email1);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Mobiel);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Telefoon);
                }

                if (lid.Ouder1_Email2 != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Email2);
                }

                if (lid.Ouder2_Email1 != "" || lid.Ouder2_Mobiel != "" || lid.Ouder2_Telefoon != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Email1);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Mobiel);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Telefoon);
                }

                if (lid.Ouder2_Email2 != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Email2);
                }
//                lidregel.AppendLine();
                #endregion

                return lidregel.ToString();
            }
            catch (Exception ex)
            {
                ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
                GuiRoutines.ExceptionMessageBox(this, ex);
                return string.Empty;
            }
        }

        //private void AddWordLid(Document doc, tblLid lid)
        //{
        //    try
        //    {
        //        #region
        //        StringBuilder lidregel = new StringBuilder();
        //        lidregel.Append(lid.VolledigeNaam);
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Adres);
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.GeboorteDatum.ToString("yyyy-MM-dd"));
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.LidVanaf.ToString("yyyy-MM-dd"));
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Geslacht);
        //        lidregel.Append("\v");

        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Postcode + " " + lid.Woonplaats);
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Mobiel);
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Telefoon);
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.BondsNr);
        //        lidregel.Append("\v");

        //        lidregel.Append("\t");
        //        lidregel.Append(lid.Email1);
        //        lidregel.Append("\t");

        //        switch (lid.LidType)
        //        {
        //            case tblLid.constLidNormaal: lidregel.Append("Standaard"); break;
        //            case tblLid.constLidContributieVrij: lidregel.Append("Contr.Vrij"); break;
        //            case tblLid.constLidZwerflid: lidregel.Append("Zwerflid"); break;
        //            case tblLid.constLidPakket: lidregel.Append("Pakket - ");
        //                lidregel.Append(lid.PakketTot.ToString("yyMMdd")); break;
        //            default: lidregel.Append("?"); break;
        //        }


        //        lidregel.Append("\t");
        //        lidregel.Append(lid.LidBond ? "J" : "N");
        //        lidregel.Append("\t");
        //        lidregel.Append(lid.CompGerechtigd ? "J" : "N");
        //        lidregel.Append("\v");

        //        if (lid.Email2 != string.Empty)
        //        {
        //            lidregel.Append("\t");
        //            lidregel.Append("Email2");
        //            lidregel.Append("\v");
        //        }

        //        if (lid.Ouder1_Email1 != "" || lid.Ouder1_Mobiel != "" || lid.Ouder1_Telefoon != "")
        //        {
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder1_Email1);
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder1_Mobiel);
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder1_Telefoon);
        //            lidregel.Append("\v");
        //        }

        //        if (lid.Ouder1_Email2 != "")
        //        {
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder1_Email2);
        //            lidregel.Append("\v");
        //        }

        //        if (lid.Ouder2_Email1 != "" || lid.Ouder2_Mobiel != "" || lid.Ouder2_Telefoon != "")
        //        {
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder2_Email1);
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder2_Mobiel);
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder2_Telefoon);
        //            lidregel.Append("\v");
        //        }

        //        if (lid.Ouder2_Email2 != "")
        //        {
        //            lidregel.Append("\t");
        //            lidregel.Append(lid.Ouder2_Email2);
        //            lidregel.Append("\v");
        //        }
        //        lidregel.AppendLine();
        //        #endregion
        //        Paragraph para = doc.Content.Paragraphs.Add(ref objMiss);

        //        para.Range.set_Style("LedenText");
        //        para.Range.Text = lidregel.ToString();
        //        AddTabsToLedenParagraph(doc.Content.Paragraphs);
        //    }
        //    catch (Exception ex)
        //    {
        //        ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
        //        GuiRoutines.ExceptionMessageBox(this, ex);
        //    }
        //}
        #endregion

        #region Word Create Lid Jeugd Leden
        private string CreateJeugdRegel(tblLid lid, tblCompResult cr)
        {
            //     Moreno Abrahams 3932183 M 7/23/2002 wlp2 10 06-48387098 yuri@yuri.pro jootje@jootje.com
            try
            {
                #region
                StringBuilder lidregel = new StringBuilder();
                lidregel.Append(lid.NetteNaam);
                lidregel.Append("\t");
                lidregel.Append(lid.BondsNr != string.Empty ? lid.BondsNr : "-");
                lidregel.Append("\t");
                lidregel.Append(lid.LidBond ? "LB" : "-");
                lidregel.Append("\t");
                lidregel.Append(lid.CompGerechtigd ? "CG" : "-");
                lidregel.Append("\t");
                lidregel.Append(lid.LicentieSen.Trim() + lid.LicentieJun.Trim());
                lidregel.Append("\t");
                if (cr != null)
                    lidregel.Append(cr.Klasse + "-" + cr.Percentage.ToString());
                else
                    lidregel.Append("-");
                lidregel.Append("\t");
                lidregel.Append(lid.GeboorteDatum.ToString("dd-MM-yyyy"));
                lidregel.Append("\t");
                lidregel.Append(lid.Geslacht);
                lidregel.Append("\t");
                lidregel.Append(lid.LeeftijdCategorieLong.Replace(" ", ""));
                lidregel.Append("\t");
                lidregel.Append(lid.Leeftijd);
                lidregel.Append("\t");
                lidregel.Append(lid.Telefoon);
                lidregel.Append("\t");
                string mobiel = lid.Mobiel;
                bool mobieloudergebruikt = false;
                if (mobiel == string.Empty)
                {
                    mobiel = lid.Ouder1_Mobiel;
                    mobieloudergebruikt = true;
                }

                lidregel.Append(mobiel);
                lidregel.Append("\t");
                lidregel.Append(lid.Email1);
                lidregel.Append("\t");
                string mail2 = lid.Email2;
                bool mailoudergebruikt = false;
                if (mail2 == string.Empty)
                {
                    mail2 = lid.Ouder1_Email1;
                    mailoudergebruikt = true;
                }
                lidregel.Append(mail2);


                //List<string> emails = new List<String>();
                //int x = 0;

                //if (lid.Email1 != string.Empty)
                //    emails[x++] = lid.Email1;
                //if (lid.Email2 != string.Empty)
                //    emails[x++] = lid.Email2;
                //if (lid.Ouder1_Email1 != string.Empty)
                //    emails[x++] = "O1:" + lid.Ouder1_Email1;
                //if (lid.Ouder2_Email1 != string.Empty)
                //    emails[x++] = "O2:" + lid.Ouder1_Email2;

                //if (emails.Count > 0)
                //{
                //    lidregel.Append("\t");
                //    lidregel.Append(emails[0]);
                //    if (emails.Count > 1)
                //    {
                //        lidregel.Append("\t");
                //        lidregel.Append(emails[1]);
                //    }
                //}

                if (!(lid.Ouder1_Email1 == "" || mailoudergebruikt) || !(lid.Ouder1_Mobiel == "" || mobieloudergebruikt) || lid.Ouder1_Telefoon != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Mobiel);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder1_Telefoon);
                    lidregel.Append("\t");
                    if (mailoudergebruikt)
                        lidregel.Append(lid.Ouder1_Email2);
                    else
                        lidregel.Append(lid.Ouder1_Email1);
                }

                if (lid.Ouder2_Email1 != "" || lid.Ouder2_Mobiel != "" || lid.Ouder2_Telefoon != "")
                {
                    lidregel.Append("\v");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Mobiel);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Telefoon);
                    lidregel.Append("\t");
                    lidregel.Append(lid.Ouder2_Email1);
                }

                #endregion
                return lidregel.ToString();
            }
            catch (Exception ex)
            {
                ((Microsoft.Office.Interop.Word._Application)msWord).Quit();
                GuiRoutines.ExceptionMessageBox(this, ex);
                return string.Empty;
            }
        }
        #endregion
 
        #region CSV WriteHeader
        private string WriteHeader()
        {

            StringBuilder lidregel = new StringBuilder();

            lidregel.Append("LidNr");
            lidregel.Append(";");
            lidregel.Append("Naam");
            lidregel.Append(";");
            lidregel.Append("Voornaam");
            lidregel.Append(";");
            lidregel.Append("Achternaam");
            lidregel.Append(";");
            lidregel.Append("Tussenvoegsel");
            lidregel.Append(";");
            lidregel.Append("Adres");
            lidregel.Append(";");
            lidregel.Append("Woonplaats");
            lidregel.Append(";");
            lidregel.Append("Postcode");
            lidregel.Append(";");
            lidregel.Append("Mobiel");
            lidregel.Append(";");
            lidregel.Append("Telefoon");
            lidregel.Append(";");
            lidregel.Append("BondsNr");
            lidregel.Append(";");
            lidregel.Append("Geslacht");
            lidregel.Append(";");
            lidregel.Append("GeboorteDatum");
            lidregel.Append(";");
            lidregel.Append("Leeftijd");
            lidregel.Append(";");
            lidregel.Append("Email1");
            lidregel.Append(";");
            lidregel.Append("Email2");
            lidregel.Append(";");
            lidregel.Append("LidType");
            lidregel.Append(";");
            lidregel.Append("LidBond");
            lidregel.Append(";");
            lidregel.Append("CompGerechtigd");
            lidregel.Append(";");
            lidregel.Append("LeeftijdCat");
            lidregel.Append(";");
            lidregel.Append("BetaalWijze");
            lidregel.Append(";");
            lidregel.Append("LidVanaf");
            lidregel.Append(";");
            lidregel.Append("Opgezegd");
            lidregel.Append(";");
            lidregel.Append("LidTot");
            lidregel.Append(";");
            lidregel.Append("PakketTot");
            lidregel.Append(";");
            lidregel.Append("Medisch");
            lidregel.Append(";");
            lidregel.Append("Ouder1_Naam");
            lidregel.Append(";");
            lidregel.Append("Ouder1_Email1");
            lidregel.Append(";");
            lidregel.Append("Ouder1_Email2");
            lidregel.Append(";");
            lidregel.Append("Ouder1_Mobiel");
            lidregel.Append(";");
            lidregel.Append("Ouder1_Telefoon");
            lidregel.Append(";");
            lidregel.Append("Ouder2_Naam");
            lidregel.Append(";");
            lidregel.Append("Ouder2_Email1");
            lidregel.Append(";");
            lidregel.Append("Ouder2_Email2");
            lidregel.Append(";");
            lidregel.Append("Ouder2_Mobiel");
            lidregel.Append(";");
            lidregel.Append("Ouder2_Telefoon");

            return lidregel.ToString();
        }
        #endregion
        
        #region CSV Write Lid
        private string WriteToernooiregel(tblCompResult cr)
        {
            List<string> columns = new List<string>();
            columns.Add(cr.Lid.Geslacht);
            columns.Add(cr.Lid.VolledigeNaam);
            columns.Add(cr.Lid.Achternaam + ", " + cr.Lid.Tussenvoegsel);
            columns.Add(cr.Lid.Voornaam);
            columns.Add(cr.Lid.GeboorteDatum.ToShortDateString());
            foreach (char c in cr.Lid.GeboorteDatum.ToString("yyMMdd"))
                columns.Add(c.ToString());
            columns.Add(cr.Lid.Leeftijd.ToString());
            columns.Add(cr.Lid.LeeftijdCategorie);
            columns.Add(cr.Klasse);
            if (cr.Percentage != 0)
                columns.Add(cr.Percentage.ToString());
            else
                columns.Add(string.Empty);
            columns.Add(cr.Lid.BondsNr);
            foreach (char c in cr.Lid.BondsNr)
                columns.Add(c.ToString());
            return String.Join(";", columns.ToArray());
        }
        private string WriteLid(tblLid lid)
        {
            StringBuilder lidregel = new StringBuilder();

            lidregel.Append(@"""");
            lidregel.Append(lid.LidNr.ToString());
            lidregel.Append(@""";""");
            lidregel.Append(lid.VolledigeNaam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Voornaam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Achternaam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Tussenvoegsel);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Adres);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Woonplaats);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Postcode);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Mobiel);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Telefoon);
            lidregel.Append(@""";""");
            lidregel.Append(lid.BondsNr);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Geslacht);
            lidregel.Append(@""";""");
            lidregel.Append(lid.GeboorteDatum.ToString("yyyyMMdd"));
            lidregel.Append(@""";""");
            lidregel.Append(lid.Leeftijd.ToString());
            lidregel.Append(@""";""");
            lidregel.Append(lid.Email1);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Email2);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidType);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidBond ? "J" : "N");
            lidregel.Append(@""";""");
            lidregel.Append(lid.CompGerechtigd ? "J" : "N");
            lidregel.Append(@""";""");
            lidregel.Append(lid.LeeftijdCategorieLong);
            lidregel.Append(@""";""");
            lidregel.Append(lid.BetaalWijze);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidVanaf.ToString("yyyyMMdd"));
            lidregel.Append(@""";""");
            lidregel.Append(lid.Opgezegd ? "J" : "N");
            lidregel.Append(@""";""");
            lidregel.Append(lid.Opgezegd ? lid.LidTot.ToString("yyyyMMdd") : "");
            lidregel.Append(@""";""");
            lidregel.Append(lid.IsLidPakket ? lid.PakketTot.ToString("yyyyMMdd") : "") ;
            lidregel.Append(@""";""");
            lidregel.Append(lid.Medisch);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder1_Naam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder1_Email1);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder1_Email2);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder1_Mobiel);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder1_Telefoon);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder2_Naam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder2_Email1);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder2_Email2);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder2_Mobiel);
            lidregel.Append(@""";""");
            lidregel.Append(lid.Ouder2_Telefoon);
            lidregel.Append(@"""");

            return lidregel.ToString();
        }
        #endregion

        #region CSV WriteHeader Penningmeester
        private string WritePenningmeesterHeader()
        {
            StringBuilder lidregel = new StringBuilder();

            lidregel.Append("Naam");
            lidregel.Append(";");
            lidregel.Append("LidType");
            lidregel.Append(";");
            lidregel.Append("LidBond");
            lidregel.Append(";");
            lidregel.Append("CompGerechtigd");
            lidregel.Append(";");
            lidregel.Append("BetaalWijze");
            lidregel.Append(";");
            lidregel.Append("LidNr");
            lidregel.Append(";");
            lidregel.Append("Categorie");
            lidregel.Append(";");
            lidregel.Append("VastBedrag");
            lidregel.Append(";");
            lidregel.Append("Korting");
            lidregel.Append(";");
            lidregel.Append("PakketTot");

            return lidregel.ToString();
        }
        #endregion

        #region Upload ledenlijsten naar site
        void printLine (string s)
        {
            toolStripStatusLabel1.Text = s;

            //Console.WriteLine(s);
        }

        private void cmdUploadLijstenWebsite_Click(object sender, EventArgs e)
        {
            try
            {
                FtpClient client = new FtpClient("server72.hosting2go.nl", "wkielen", "ebac5308", printLine);
                client.RemotePath = "/httpdocs/_temp/lijsten";
                client.Login();

                DoUpload(client, ledenNaamFileName, "ledenlijst.csv");
                DoUpload(client, jeugdNaamFileName, "ledenlijstjeugd.csv");
                DoUpload(client, ledenNaamFileNameDoc, "ledenlijst.doc");
                DoUpload(client, ledenMailFileNameDoc, "ledenlijstjeugd.doc");
                DoUpload(client, verjaardagsFileName, "verjaardagslijst.csv");

                client.Close();
                MessageBox.Show("Lijsten uploaded naar " + client.RemotePath, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                printLine(ex.Message);
            }
        }
        private void DoUpload (FtpClient client, string inFileName, string localFileName)
        {
            string fileName = Path.GetFileName(inFileName);
            client.Upload(inFileName);
            client.RenameFile(fileName, localFileName, true);
        }


        #endregion

        #region CSV Write Lid
        private string WritePenningmeester(tblLid lid)
        {
            StringBuilder lidregel = new StringBuilder();

            lidregel.Append(@"""");
            lidregel.Append(lid.VolledigeNaam);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidType);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidBond ? "J" : "N");
            lidregel.Append(@""";""");
            lidregel.Append(lid.CompGerechtigd ? "J" : "N");
            lidregel.Append(@""";""");
            lidregel.Append(lid.BetaalWijze);
            lidregel.Append(@""";""");
            lidregel.Append(lid.LidNr.ToString());
            lidregel.Append(@""";""");
            lidregel.Append(DateRoutines.LeeftijdCategorieContributie(lid.GeboorteDatum, param.ContributiePeilDatum));
            lidregel.Append(@""";""");
            lidregel.Append(lid.VastBedrag.ToCSVString());
            lidregel.Append(@""";""");
            lidregel.Append(lid.Korting.ToCSVString());
            lidregel.Append(@""";""");
            lidregel.Append(lid.IsLidPakket ? lid.PakketTot.ToString("yyyyMMdd") : "");
            lidregel.Append(@"""");

            return lidregel.ToString();
        }
        #endregion

        private void frmExportLijsten_FormClosing(object sender, FormClosingEventArgs e)
        {
            param.ltxtOutputLocation = txtEmailLeden.Text;
            param.ltxtEmailLeden = txtEmailLeden.Text;
            param.ltxtEmailJeugd = txtEmailJeugd.Text;

            /*
            PersistControlValue.StoreControlValue(txtOutputLocation);
            PersistControlValue.StoreControlValue(txtEmailLeden);
            PersistControlValue.StoreControlValue(txtEmailJeugd);
            */
        }

        #region CMD mail versturen
        private void cmdMail_Click(object sender, EventArgs e)
        {
            List<string> attachments = new List<string>();
            attachments.Add(ledenNaamFileNameDoc);
            attachments.Add(ledenNaamFileName);
            attachments.Add(ledenMailFileNameDoc);
            attachments.Add(verjaardagsFileName);
            
            List<EmailAdresLid> emailList = new List<EmailAdresLid>();
            EmailAdresLid email;
            List<string> emailadresses = StringUtil.Split(txtEmailLeden.Text, ';');
            foreach (string emailadress in emailadresses)
            {
                email = new EmailAdresLid(emailadress);
                emailList.Add(email);
            }
            

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("M.v.g.<br>");
            sb.AppendLine(param.ClubNameShort);
            BodyString body = sb.ToString();

            try
            {
                new frmMultiMail(emailList, param, body, "Ledenlijst " + param.ClubNameShort, attachments).ShowDialog();
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            toolStripStatusLabel1.Text = "Ledenlijsten verstuurd";

            attachments.Clear();
            attachments.Add(jeugdLeeftijdFileName);
            attachments.Add(jeugdNaamFileNameDoc);
            attachments.Add(jeugdMailFileNameDoc);
                        
            emailList.Clear();
            emailadresses = StringUtil.Split(txtEmailJeugd.Text,';');
            foreach (string emailadress in emailadresses)
            {
                email = new EmailAdresLid(emailadress);
                emailList.Add(email);
            }

            try
            {
                new frmMultiMail(emailList, param, body, "Jeugdlijst " + param.ClubNameShort, attachments).ShowDialog();
            }
            catch (Exception ex)
            { 
                GuiRoutines.ExceptionMessageBox(this,ex);
            }
            toolStripStatusLabel1.Text = "Jeugdlijsten verstuurd";
        }
        #endregion

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtOutputLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void cmdCreateMailOutput_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmExportForMail(dataAdapter, param).ShowDialog();
            this.Cursor = Cursors.Arrow; ;
            toolStripStatusLabel1.Text = "Input mailprogramma gemaakt";
        }
    }
}
