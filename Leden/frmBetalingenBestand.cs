#define debug
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using Util.Email;
using Util.Extensions;
using Util.Forms;

// betaling naar  testbestanden.sepa@rn.rabobank.nl. 

namespace Leden.Net
{
    public partial class frmBetalingenBestand : frmBasis
    {
        BetalingenLijst betalingen;
        string outputverslag;
        StringBuilder betalingVerslag = new StringBuilder();
        StringBuilder regelVerslag = new StringBuilder();
        int fileSeqnr = 0;
        DataAdapters dataAdaptor;

        public frmBetalingenBestand(DataAdapters da)
        {
            InitializeComponent();
            param = new tblParameters();
            betalingen = da.VulBetalingRecords();
            dataAdaptor = da;

            _windowState = new PersistWindowState(this, @"Leden\BetalingenBestand");

            PersistControlValue.ReadControlValue(txtFilePrefixB);
            PersistControlValue.ReadControlValue(txtFileSeqnrB);
            PersistControlValue.ReadControlValue(txtMsgIDB);
            PersistControlValue.ReadControlValue(txtOutputLocationIncB);
            PersistControlValue.ReadControlValue(chkPrintVerslagB);

            int nbrBetalingen = 0;
            decimal sumBetalingen = 0;
            foreach (tblBetaling betaling in betalingen)
            {
                if (betaling.Verstuurd) continue;
                sumBetalingen += betaling.TotaalBedrag;
                nbrBetalingen++;
            }
            lblMessage.Text = "Aantal: " + nbrBetalingen.ToString() + " - Bedrag: " + sumBetalingen.ToEuroString();
        }

        #region cmdMaakbestand_Click Betaling
        /// <summary>
        /// Het aanmaken van het betaling bestand. 
        /// De list selectedInc moet gesorteed zijn op 'geincasseerd' omdat we hierop batchen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMaakbestand_Click(object sender, EventArgs e)
        {
            try
            {
                if (betalingen.Count == 0)
                {
                    MessageBox.Show("Geen betalingen", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //dit fileSeqnr gebruiken we om in de db terug te schrijven zodat we weten in welk bestand een betaling zit
                // dit verder niet gebruikt maar miscchien later handig voor het nazoeken.
                fileSeqnr = txtFileSeqnrB.Text.IsNumeric() ? Convert.ToInt32(txtFileSeqnrB.Text) : 0;
                string outputfile = txtOutputLocationIncB.Text + @"\" + txtFilePrefixB.Text + fileSeqnr.ToString("000") + ".xml";

                #region BetalingVerslag init
                outputverslag = txtOutputLocationIncB.Text + @"\" + txtFilePrefixB.Text + fileSeqnr.ToString("000") + "_OutputVerslag.txt";
                betalingVerslag.AppendLine("Betalingverslag: " + outputfile);
                betalingVerslag.AppendLine();
                #endregion

                #region Template voor betaling
                //Ik maak hier eerst de template voor de credit's. 
                StringBuilder templateBetaling = new StringBuilder();
                templateBetaling.AppendLine("      <CdtTrfTxInf>");
                templateBetaling.AppendLine("        <PmtId>");
                templateBetaling.AppendLine("          <EndToEndId>***EndToEndId***</EndToEndId>");
                templateBetaling.AppendLine("        </PmtId>");
                templateBetaling.AppendLine("        <Amt>");
                templateBetaling.AppendLine(@"        <InstdAmt Ccy=""EUR"">***InstdAmt***</InstdAmt>");
                templateBetaling.AppendLine("        </Amt>");
                templateBetaling.AppendLine("        <CdtrAgt>");
                templateBetaling.AppendLine("          <FinInstnId>");
                templateBetaling.AppendLine("            <BIC>***BIC***</BIC>");
                templateBetaling.AppendLine("          </FinInstnId>");
                templateBetaling.AppendLine("        </CdtrAgt>");
                templateBetaling.AppendLine("        <Cdtr>");
                templateBetaling.AppendLine("          <Nm>***Nm***</Nm>");
                templateBetaling.AppendLine("        </Cdtr>");
                templateBetaling.AppendLine("        <CdtrAcct>");
                templateBetaling.AppendLine("          <Id>");
                templateBetaling.AppendLine("            <IBAN>***IBAN***</IBAN>");
                templateBetaling.AppendLine("          </Id>");
                templateBetaling.AppendLine("        </CdtrAcct>");
                templateBetaling.AppendLine("        <RmtInf>");
                templateBetaling.Append    ("           ***RmtInf***");
                templateBetaling.AppendLine("        </RmtInf>");
                templateBetaling.AppendLine("      </CdtTrfTxInf>");
                #endregion

                #region Template on batchlevel for Payment Info
                // Ik maak hier de template voor de  batches. 
                StringBuilder templateBatch = new StringBuilder();

                templateBatch.AppendLine("    <PmtInf>");
                templateBatch.AppendLine("      <PmtInfId>***PmtInfId***</PmtInfId> ");
                templateBatch.AppendLine("      <PmtMtd>TRF</PmtMtd>");
                templateBatch.AppendLine("      <BtchBookg>true</BtchBookg>");
                templateBatch.AppendLine("      <NbOfTxs>***NbOfTxs***</NbOfTxs>");
                templateBatch.AppendLine("      <CtrlSum>***InstdAmt***</CtrlSum>");
                templateBatch.AppendLine("      <PmtTpInf>");
                templateBatch.AppendLine("        <SvcLvl>");
                templateBatch.AppendLine("          <Cd>SEPA</Cd>");
                templateBatch.AppendLine("        </SvcLvl>");
                templateBatch.AppendLine("       <CtgyPurp>");
                templateBatch.AppendLine("          <Cd>OTHR</Cd>");
                templateBatch.AppendLine("       </CtgyPurp>");
                templateBatch.AppendLine("      </PmtTpInf>");
                templateBatch.AppendLine("      <ReqdExctnDt>***ReqdExctnDt***</ReqdExctnDt>");
                templateBatch.AppendLine("      <Dbtr>");
                templateBatch.AppendLine("        <Nm>***Nm***</Nm>");
                templateBatch.AppendLine("      </Dbtr>");
                templateBatch.AppendLine("      <DbtrAcct>");
                templateBatch.AppendLine("        <Id>");
                templateBatch.AppendLine("          <IBAN>***IBAN***</IBAN>");
                templateBatch.AppendLine("        </Id>");
                templateBatch.AppendLine("        <Ccy>EUR</Ccy>");
                templateBatch.AppendLine("      </DbtrAcct>");
                templateBatch.AppendLine("      <DbtrAgt>");
                templateBatch.AppendLine("        <FinInstnId>");
                templateBatch.AppendLine("          <BIC>***BIC***</BIC>");
                templateBatch.AppendLine("        </FinInstnId>");
                templateBatch.AppendLine("      </DbtrAgt>");
                templateBatch.AppendLine("      <ChrgBr>SLEV</ChrgBr>");
                templateBatch.Append("***insertCred****");
                templateBatch.AppendLine("    </PmtInf>");
                #endregion

                #region Template on file level
                StringBuilder templateFile = new StringBuilder();

                templateFile.AppendLine(@"<Document xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.001.001.03"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">");
                templateFile.AppendLine("  <CstmrCdtTrfInitn>");
                templateFile.AppendLine("    <GrpHdr>");
                templateFile.AppendLine("      <MsgId>***MsgId***</MsgId>");
                templateFile.AppendLine("      <CreDtTm>***CreDtTm***</CreDtTm>");
                templateFile.AppendLine("      <NbOfTxs>***NbOfTxs***</NbOfTxs>");
                templateFile.AppendLine("      <InitgPty>");
                templateFile.AppendLine("        <Nm>***InitgPtyNm***</Nm>");
                templateFile.AppendLine("        <Id>");
                templateFile.AppendLine("          <OrgId>");
                templateFile.AppendLine("            <Othr>");
                templateFile.AppendLine("              <Id>***InitgPtyId***</Id>");
                templateFile.AppendLine("            </Othr>");
                templateFile.AppendLine("          </OrgId>");
                templateFile.AppendLine("        </Id>");
                templateFile.AppendLine("      </InitgPty>");
                templateFile.AppendLine("    </GrpHdr>");
                templateFile.Append("***insertBET***");
                templateFile.AppendLine("  </CstmrCdtTrfInitn>");
                templateFile.AppendLine("</Document>");
                #endregion

                decimal amtBetalingenInBatch = 0M;
                int nbrBetalingenInBatch = 0;
                int nbrBetalingenInFile = 0;
                string batchName = string.Empty;
                DateTime batchDatum = new DateTime().Date; 

                //Sorteren op gewenste uitvoer datum en selecteerd alleen niet verstuurde
                IEnumerable<tblBetaling> OnverstuurdeBetalingen = from betaling in betalingen where !betaling.Verstuurd orderby betaling.GewensteVerwerkingsDatum select betaling;

                //Sorteren op gewenste uitvoer datum
                //betalingen.Sort(new BetalingenComparer("GewensteDatum"));

                BetalingenLijst betalingenPerDatum = new BetalingenLijst();
                List<BetalingenLijst> betalingPerDatumLijst = new List<BetalingenLijst>();
                foreach (tblBetaling bet in OnverstuurdeBetalingen)
                {
                    if (bet.GewensteVerwerkingsDatum.Date == batchDatum.Date)
                    {
                        betalingenPerDatum.Add(bet);
                    }
                    else
                    {
                        if (betalingenPerDatum.Count > 0)
                            betalingPerDatumLijst.Add(betalingenPerDatum);
                        betalingenPerDatum = new BetalingenLijst();
                        betalingenPerDatum.Add(bet);
                        batchDatum = bet.GewensteVerwerkingsDatum.Date;
                    }
                }
                betalingPerDatumLijst.Add(betalingenPerDatum);

                StringBuilder sbrBatches = new StringBuilder();

                foreach (BetalingenLijst bl in betalingPerDatumLijst)
                {
                    StringBuilder sbrBetalingenInABatch = new StringBuilder();

                    foreach (tblBetaling betaling in bl)
                    {
                        #region Create betaling from template replacing placeholders
                        StringBuilder sbrBetaling = new StringBuilder(templateBetaling.ToString());

                        sbrBetaling.Replace("***EndToEndId***", "Ref: " + betaling.EndToEndId);
                        sbrBetaling.Replace("***InstdAmt***", betaling.TotaalBedrag.ToXMLString());
                        sbrBetaling.Replace("***BIC***", betaling.BIC_Creditor);
                        sbrBetaling.Replace("***Nm***", betaling.Crediteur);
                        sbrBetaling.Replace("***IBAN***", betaling.IBAN_Creditor);
                        StringBuilder RmtInf = new StringBuilder();
                        if (betaling.Omschrijving == string.Empty)
                        {
                            RmtInf.AppendLine("<Strd>");
                            RmtInf.AppendLine("                <CdtrRefInf>");
                            RmtInf.AppendLine("                  <Tp>");
                            RmtInf.AppendLine("                    <CdOrPrtry>");
                            RmtInf.AppendLine("                      <Cd>SCOR</Cd>");
                            RmtInf.AppendLine("                    </CdOrPrtry>");
                            RmtInf.AppendLine("                  </Tp>");
                            RmtInf.AppendLine("                  <Ref>" + betaling.EndToEndId + "</Ref>");
                            RmtInf.AppendLine("                </CdtrRefInf>");
                            RmtInf.AppendLine("              </Strd>");
                        }
                        else
                        {
                            RmtInf.AppendLine("<Ustrd>" + betaling.Omschrijving + "</Ustrd>");
                        }
                        sbrBetaling.Replace("***RmtInf***", RmtInf.ToString());
                        #endregion

                        sbrBetalingenInABatch.Append(sbrBetaling.ToString());
                        nbrBetalingenInBatch++;
                        nbrBetalingenInFile++;
                        amtBetalingenInBatch += betaling.TotaalBedrag;

                        regelVerslag.Append(betaling.Crediteur.PadRight(30));
                        regelVerslag.Append(betaling.GewensteVerwerkingsDatum.ToShortDateString().PadRight(15));
                        regelVerslag.Append(betaling.TotaalBedrag.ToEuroString().PadRight(12));
                        if (betaling.Omschrijving == string.Empty)
                            regelVerslag.Append(betaling.FormattedEndToEndId.PadRight(30));
                        else
                            regelVerslag.Append(betaling.Omschrijving.PadRight(30));
                        regelVerslag.AppendLine();

                        betaling.Verstuurd = true;
                        betaling.VerstuurdDatum = DateTime.Now;
                        betaling.ExtraB = txtFilePrefixB.Text + fileSeqnr.ToString("000");
                    }
                    StringBuilder B = CreateBatchHeader(templateBatch, sbrBetalingenInABatch, nbrBetalingenInBatch, amtBetalingenInBatch, batchDatum);
                    sbrBatches.Append(B.ToString());
                }

                // batch (mits gevuld) worden hier in de body geplaatst
                templateFile.Replace("***MsgId***", param.ClubNameShort + " betaling " + fileSeqnr.ToString("000"));
                templateFile.Replace("***CreDtTm***", DateTime.Now.ToString("s"));
                templateFile.Replace("***NbOfTxs***", nbrBetalingenInFile.ToString());
                templateFile.Replace("***InitgPtyNm***", param.ClubNameLong);
                templateFile.Replace("***InitgPtyId***", param.KvK);
                templateFile.Replace("***insertBET***", sbrBatches.ToString());

                #region replace unwanted characters
                // We vervangen niet toegestane tekens.
                // Wie weet een mooiere methode?
                templateFile.Replace("À", "A");
                templateFile.Replace("Á", "A");
                templateFile.Replace("Â", "A");
                templateFile.Replace("Ã", "A");
                templateFile.Replace("Ä", "A");
                templateFile.Replace("Å", "A");
                templateFile.Replace("Æ", "AE");
                templateFile.Replace("Ç", "C");
                templateFile.Replace("È", "E");
                templateFile.Replace("É", "E");
                templateFile.Replace("Ê", "E");
                templateFile.Replace("Ë", "E");
                templateFile.Replace("Ì", "I");
                templateFile.Replace("Í", "I");
                templateFile.Replace("Î", "I");
                templateFile.Replace("Ï", "I");
                templateFile.Replace("Ð", "D");
                templateFile.Replace("Ñ", "N");
                templateFile.Replace("Ò", "O");
                templateFile.Replace("Ó", "O");
                templateFile.Replace("Ô", "O");
                templateFile.Replace("Õ", "O");
                templateFile.Replace("Ö", "O");
                templateFile.Replace("Ø", "O");
                templateFile.Replace("Ù", "U");
                templateFile.Replace("Ú", "U");
                templateFile.Replace("Û", "U");
                templateFile.Replace("Ü", "U");
                templateFile.Replace("ß", "ss");
                templateFile.Replace("à", "a");
                templateFile.Replace("á", "a");
                templateFile.Replace("â", "a");
                templateFile.Replace("ã", "a");
                templateFile.Replace("ä", "a");
                templateFile.Replace("å", "a");
                templateFile.Replace("æ", "ae");
                templateFile.Replace("ç", "c");
                templateFile.Replace("è", "e");
                templateFile.Replace("é", "e");
                templateFile.Replace("ê", "e");
                templateFile.Replace("ë", "e");
                templateFile.Replace("ì", "i");
                templateFile.Replace("í", "i");
                templateFile.Replace("î", "i");
                templateFile.Replace("ï", "i");
                templateFile.Replace("ð", "o");
                templateFile.Replace("ñ", "n");
                templateFile.Replace("ò", "o");
                templateFile.Replace("ó", "o");
                templateFile.Replace("ô", "o");
                templateFile.Replace("õ", "o");
                templateFile.Replace("ö", "o");
                templateFile.Replace("ø", "o");
                templateFile.Replace("ù", "u");
                templateFile.Replace("ú", "u");
                templateFile.Replace("û", "u");
                templateFile.Replace("ü", "u");
                templateFile.Replace("ý", "u");
                templateFile.Replace("ÿ", "y");
                templateFile.Replace("ÿ", "y");
                templateFile.Replace("€", "E");
                #endregion

                // En klaar is kees. Nu het bestand inschrijven.
                StreamWriter swOutput = new StreamWriter(outputfile);

                swOutput.WriteLine(templateFile.ToString());
                swOutput.Flush();
                swOutput.Close();
                swOutput.Dispose();


                StreamWriter swVerslag = new StreamWriter(outputverslag);
                swVerslag.WriteLine(betalingVerslag.ToString());
                swVerslag.Flush();
                swVerslag.Close();
                swVerslag.Dispose();

                if (chkPrintVerslagB.Checked)
                {
                    fileToPrint = new System.IO.StreamReader(outputverslag);
                    printFont = new System.Drawing.Font("Courier New", 8);
                    printDocument1.DocumentName = "Betaling Verslag";
                    printDocument1.Print();
                    fileToPrint.Close();
                }
                #endregion

                // We controleren nog even of het bestand aan het schema voldoet.
                CheckPain(outputfile);

                fileSeqnr++;
                txtFileSeqnrB.Text = fileSeqnr.ToString();

                dataAdaptor.UpdateBetalingen(betalingen);
                dataAdaptor.CommitTransaction(true);
                MessageBox.Show("Bestand aangemaakt: " + outputfile + "\nAantal betaling's: " + nbrBetalingenInFile.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmdMaakbestand.Enabled = false;
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
        }
        private StringBuilder CreateBatchHeader(StringBuilder template, StringBuilder betalingen, int nbr, decimal amt, DateTime verwerkingsDatum)
        {
            #region Maak BatchHeader
            string batchName = "Payments " + fileSeqnr.ToString() + " " + verwerkingsDatum.ToShortDateString();

            StringBuilder strBatchHeader = new StringBuilder(template.ToString());
            strBatchHeader.Replace("***PmtInfId***", batchName);
            strBatchHeader.Replace("***NbOfTxs***", nbr.ToString());
            strBatchHeader.Replace("***InstdAmt***", amt.ToXMLString());
            strBatchHeader.Replace("***ReqdExctnDt***", verwerkingsDatum.ToString("s").Substring(0, 10));
            strBatchHeader.Replace("***Nm***", param.ClubNameLong);
            strBatchHeader.Replace("***IBAN***", param.IBAN);
            strBatchHeader.Replace("***BIC***", param.BIC);
            strBatchHeader.Replace("***PrvtId***", Util.Iban.KvKIban(param.KvK));
            strBatchHeader.Replace("***insertCred****", betalingen.ToString());

            // Hier ga ik het betaling verslag maken
            betalingVerslag.AppendLine("Batch Naam: " + batchName);
            betalingVerslag.AppendLine("Aantal: " + nbr.ToString() + "  Bedrag: " + amt.ToEuroString());
            betalingVerslag.AppendLine();
            betalingVerslag.AppendLine(regelVerslag.ToString());
            betalingVerslag.AppendLine();
            regelVerslag.Clear();

            return strBatchHeader;
            #endregion
        }


        #region Validate XML

        public void CheckPain(string outputfile)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", param.LocationTemplates + @"\pain.001.001.03.xsd");

            XmlSchema compiledSchema = null;

            foreach (XmlSchema schema in schemaSet.Schemas())
                compiledSchema = schema;

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(compiledSchema);
            settings.ValidationType = ValidationType.Schema;

            //Create the schema validating reader.
            XmlReader vreader = XmlReader.Create(outputfile, settings);

            while (vreader.Read()) { }

            //Close the reader.
            vreader.Close();
        }
        #endregion

        private void frmRekeningVersturen_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(txtFilePrefixB);
            PersistControlValue.StoreControlValue(txtFileSeqnrB);
            PersistControlValue.StoreControlValue(txtMsgIDB);
            PersistControlValue.StoreControlValue(txtOutputLocationIncB);
            PersistControlValue.StoreControlValue(chkPrintVerslagB);
        }

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            fdiBrowseTemplate.ShowDialog();
            if (fdiBrowseTemplate.SelectedPath != string.Empty)
                txtOutputLocationIncB.Text = fdiBrowseTemplate.SelectedPath;
        }

        #region Printen
        System.IO.StreamReader fileToPrint;
        System.Drawing.Font printFont;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            while (count < linesPerPage)
            {
                line = fileToPrint.ReadLine();
                    if (line == null)
                {
                    break;
                }
                yPos = topMargin + count * printFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
        }
        #endregion
    }
}
