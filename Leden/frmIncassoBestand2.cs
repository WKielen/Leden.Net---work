#define debug
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using Util.Extensions;
using Util.Forms;

// incasso naar  testbestanden.sepa@rn.rabobank.nl. 

namespace Leden.Net
{
    public partial class frmIncassoBestand2 : frmBasis
    {
        LedenLijst leden;
        RekeningenLijst rekeningen;
        RekeningenLijst selectedInc = new RekeningenLijst();
        RekeningenLijst selectedRek = new RekeningenLijst();
        RekeningenLijst selectedUPas = new RekeningenLijst();
        int nbrTxtInc = 0;
        decimal sumTotaalInc = 0;
        int nbrTxtRek = 0;
        decimal sumTotaalRek = 0;
        int nbrTxtUPas = 0;
        decimal sumTotaalUPas = 0;
        string outputverslag;
        DataAdapters dataAdaptor;
        string verstuurdeRekeningenReport = string.Empty;
        private string EmailLogFile;

        public frmIncassoBestand2(DataAdapters da, tblParameters xParam)
        {
            InitializeComponent();
            param = xParam;
            verstuurdeRekeningenReport = param.LocationLogFiles + @"\" + param.ClubNameShort + @"_Verstuurde rekeningen.csv";
            EmailLogFile = param.LocationLogFiles + @"\" + param.ClubNameShort + "_Mail_Logfile.txt";
            if (!File.Exists(EmailLogFile))
                File.Create(EmailLogFile);
            rekeningen = da.VulRekeningRecords();
            leden = da.VulLedenLijst();
            dataAdaptor = da;

            _windowState = new PersistWindowState(this, @"Leden\IncassoBestand");

            chkLogEmail.Checked = param.LogEmail;
            ckbDoNotSendEmail.Checked = param.DoNotSendEmail;

            /*
            PersistControlValue.ReadControlValue(txtFilePrefix);
            PersistControlValue.ReadControlValue(txtFileSeqnr);
            PersistControlValue.ReadControlValue(txtMsgID);
            PersistControlValue.ReadControlValue(txtOutputLocationInc);

            PersistControlValue.ReadControlValue(txtOutputLocationRek);
            PersistControlValue.ReadControlValue(txtFilePrefixRek);
            PersistControlValue.ReadControlValue(txtFileSeqnrRek);

            PersistControlValue.ReadControlValue(txtOutputLocationUPas);
            PersistControlValue.ReadControlValue(txtFilePrefixUPas);
            PersistControlValue.ReadControlValue(txtFileSeqnrUPas);
            PersistControlValue.ReadControlValue(chkPrintVerslag);
            */

            txtFilePrefix.Text = param.itxtFilePrefix;
            txtFileSeqnr.Text = param.itxtFileSeqnr.ToString();
            txtMsgID.Text = param.itxtMsgID;
            txtOutputLocationInc.Text = param.itxtOutputLocationInc;
            txtOutputLocationRek.Text = param.itxtOutputLocationRek;
            txtFilePrefixRek.Text = param.itxtFilePrefixRek;
            txtFileSeqnrRek.Text = param.itxtFileSeqnrRek.ToString();
            txtOutputLocationUPas.Text = param.itxtOutputLocationUPas;
            txtFilePrefixUPas.Text = param.itxtFilePrefixUPas;
            txtFileSeqnrUPas.Text = param.itxtFileSeqnrUPas.ToString();
            chkPrintVerslag.Checked = param.ichkPrintVerslag;





            foreach (Leden.Net.tblRekening rekening in rekeningen)
            {
                if (rekening.Verstuurd) continue;
                if (rekening.Lid.IsIncasso)
                {
                    selectedInc.Add(rekening);
                    sumTotaalInc += rekening.TotaalBedrag;
                    nbrTxtInc++;
                }
                if (rekening.Lid.IsRekening)
                {
                    selectedRek.Add(rekening);
                    sumTotaalRek += rekening.TotaalBedrag;
                    nbrTxtRek++;
                }
                if (rekening.Lid.IsUPas)
                {
                    selectedUPas.Add(rekening);
                    sumTotaalUPas += rekening.TotaalBedrag;
                    nbrTxtUPas++;
                }
            }
            dtpIncassoDatum.Value = DateTime.Now.AddDays(10);
            lblMessage.Text = "Aantal: " + nbrTxtInc.ToString() + " - Bedrag: " + sumTotaalInc.ToEuroString();
            lblMessageRek.Text = "Aantal: " + nbrTxtRek.ToString() + " - Bedrag: " + sumTotaalRek.ToEuroString();
            lblMessageUPas.Text = "Aantal: " + nbrTxtUPas.ToString() + " - Bedrag: " + sumTotaalUPas.ToEuroString();
        }

        #region cmdMaakbestand_Click Incasso
        /// <summary>
        /// Het aanmaken van het incasso bestand. 
        /// De list selectedInc moet gesorteed zijn op 'geincasseerd' omdat we hierop batchen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdMaakbestand_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedInc.Count == 0)
                {
                    MessageBox.Show("Geen rekeningen", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int seqnr = txtFileSeqnr.Text.IsNumeric() ? Convert.ToInt32(txtFileSeqnr.Text) : 0;

                //Ik maak hier eerst de template voor de Debit's. Dan verdeel ik ze in twee lijstjes. 
                //Eentje voor leden die voor het eerst worden geincasseerd en een voor leden die al eerder zijn geincaseerd.

                StringBuilder firstIncasso = new StringBuilder();
                StringBuilder recurringIncasso = new StringBuilder();

                StringBuilder myTemplateIncasso = new StringBuilder();
                myTemplateIncasso.AppendLine("      <DrctDbtTxInf>");
                myTemplateIncasso.AppendLine("        <PmtId>");
                myTemplateIncasso.AppendLine("          <EndToEndId>***EndToEndId***</EndToEndId>");
                myTemplateIncasso.AppendLine("        </PmtId>");
                myTemplateIncasso.AppendLine(@"        <InstdAmt Ccy=""EUR"">***InstdAmt***</InstdAmt>");
                myTemplateIncasso.AppendLine("        <DrctDbtTx>");
                myTemplateIncasso.AppendLine("          <MndtRltdInf>");
                myTemplateIncasso.AppendLine("            <MndtId>***MndtId***</MndtId>");
                myTemplateIncasso.AppendLine("            <DtOfSgntr>***DtOfSgntr***</DtOfSgntr>");
                myTemplateIncasso.AppendLine("          </MndtRltdInf>");
                myTemplateIncasso.AppendLine("        </DrctDbtTx>");
                myTemplateIncasso.AppendLine("        <DbtrAgt>");
                myTemplateIncasso.AppendLine("          <FinInstnId>");
                myTemplateIncasso.AppendLine("            <BIC>***BIC***</BIC>");
                myTemplateIncasso.AppendLine("          </FinInstnId>");
                myTemplateIncasso.AppendLine("        </DbtrAgt>");
                myTemplateIncasso.AppendLine("        <Dbtr>");
                myTemplateIncasso.AppendLine("          <Nm>***Nm***</Nm>");
                myTemplateIncasso.AppendLine("        </Dbtr>");
                myTemplateIncasso.AppendLine("        <DbtrAcct>");
                myTemplateIncasso.AppendLine("          <Id>");
                myTemplateIncasso.AppendLine("            <IBAN>***IBAN***</IBAN>");
                myTemplateIncasso.AppendLine("          </Id>");
                myTemplateIncasso.AppendLine("        </DbtrAcct>");
                myTemplateIncasso.AppendLine("        <RmtInf>");
                myTemplateIncasso.AppendLine("          <Ustrd>***Ustrd***</Ustrd>");
                myTemplateIncasso.AppendLine("        </RmtInf>");
                myTemplateIncasso.AppendLine("      </DrctDbtTxInf>");

                // Maak de Debit kant van alle incasso's en verdeel ze over FRST en RCUR

                decimal amtFRST = 0M;
                decimal amtRCUR = 0M;
                int nbrFRST = 0;
                int nbrRCUR = 0;
                StringBuilder sbrIncFRST = new StringBuilder();
                StringBuilder sbrIncRCUR = new StringBuilder();

                // We vervangen de variabelen door de echte waardes en tellen ze bij het juiste lijstje
                foreach (Leden.Net.tblRekening rekening in selectedInc)
                {
                    StringBuilder sbr = new StringBuilder(myTemplateIncasso.ToString());

                    sbr.Replace("***EndToEndId***", "Ref: " + rekening.LidNr.ToString());
                    sbr.Replace("***InstdAmt***", rekening.TotaalBedrag.ToXMLString());
                    sbr.Replace("***MndtId***", rekening.LidNr.ToString());
                    DateTime dtOfSgntr = rekening.Lid.LidVanaf < DateTime.Parse("2009-11-01") ? DateTime.Parse("2009-11-01") : rekening.Lid.LidVanaf;
                    sbr.Replace("***DtOfSgntr***", dtOfSgntr.ToString("s").Substring(0, 10));
                    sbr.Replace("***BIC***", rekening.Lid.BIC);
                    sbr.Replace("***Nm***", rekening.Lid.VolledigeNaam);
                    sbr.Replace("***IBAN***", rekening.Lid.IBAN);
                    sbr.Replace("***Ustrd***", rekening.Omschrijving);

                    if (leden.GetLidByLidNr(rekening.LidNr).Geincasseerd)
                    {
                        recurringIncasso.Append(sbr.ToString());
                        nbrRCUR++;
                        amtRCUR += rekening.TotaalBedrag;

                        sbrIncRCUR.Append(rekening.Lid.LidNr.ToString().PadRight(5));
                        sbrIncRCUR.Append(rekening.Lid.VolledigeNaam.PadRight(30));
                        sbrIncRCUR.Append(rekening.TotaalBedrag.ToEuroString().PadRight(12));
                        sbrIncRCUR.Append(rekening.Omschrijving.PadRight(30));
                        sbrIncRCUR.AppendLine();
                    }
                    else
                    {
                        firstIncasso.Append(sbr.ToString());
                        nbrFRST++;
                        amtFRST += rekening.TotaalBedrag;
                        leden.GetLidByLidNr(rekening.LidNr).Geincasseerd = true;

                        sbrIncFRST.Append(rekening.Lid.LidNr.ToString().PadRight(5));
                        sbrIncFRST.Append(rekening.Lid.VolledigeNaam.PadRight(30));
                        sbrIncFRST.Append(rekening.TotaalBedrag.ToEuroString().PadRight(12));
                        sbrIncFRST.Append(rekening.Omschrijving.PadRight(30));
                        sbrIncFRST.AppendLine();
                    }
                    rekening.Verstuurd = true;
                    rekening.VerstuurdDatum = dtpIncassoDatum.Value;
                    rekening.ExtraA = txtFilePrefix.Text + seqnr.ToString("000");
                }

                // Ik maak hier de template voor de beide batches. 
                StringBuilder myTemplateCreditor = new StringBuilder();

                myTemplateCreditor.AppendLine("    <PmtInf>");
                myTemplateCreditor.AppendLine("      <PmtInfId>***PmtInfId***</PmtInfId> ");
                myTemplateCreditor.AppendLine("      <PmtMtd>DD</PmtMtd>");
                myTemplateCreditor.AppendLine("      <BtchBookg>true</BtchBookg>");
                myTemplateCreditor.AppendLine("      <NbOfTxs>***NbOfTxs***</NbOfTxs>");
                myTemplateCreditor.AppendLine("      <CtrlSum>***InstdAmt***</CtrlSum>");
                myTemplateCreditor.AppendLine("      <PmtTpInf>");
                myTemplateCreditor.AppendLine("        <SvcLvl>");
                myTemplateCreditor.AppendLine("          <Cd>SEPA</Cd>");
                myTemplateCreditor.AppendLine("        </SvcLvl>");
                myTemplateCreditor.AppendLine("        <LclInstrm>");
                myTemplateCreditor.AppendLine("          <Cd>CORE</Cd>");
                myTemplateCreditor.AppendLine("        </LclInstrm>");
                myTemplateCreditor.AppendLine("        <SeqTp>***SeqTp***</SeqTp>");
                myTemplateCreditor.AppendLine("      </PmtTpInf>");
                myTemplateCreditor.AppendLine("      <ReqdColltnDt>***ReqdColltnDt***</ReqdColltnDt>");
                myTemplateCreditor.AppendLine("      <Cdtr>");
                myTemplateCreditor.AppendLine("        <Nm>***Nm***</Nm>");
                myTemplateCreditor.AppendLine("      </Cdtr>");
                myTemplateCreditor.AppendLine("      <CdtrAcct>");
                myTemplateCreditor.AppendLine("        <Id>");
                myTemplateCreditor.AppendLine("          <IBAN>***IBAN***</IBAN>");
                myTemplateCreditor.AppendLine("        </Id>");
                myTemplateCreditor.AppendLine("        <Ccy>EUR</Ccy>");
                myTemplateCreditor.AppendLine("      </CdtrAcct>");
                myTemplateCreditor.AppendLine("      <CdtrAgt>");
                myTemplateCreditor.AppendLine("        <FinInstnId>");
                myTemplateCreditor.AppendLine("          <BIC>***BIC***</BIC>");
                myTemplateCreditor.AppendLine("        </FinInstnId>");
                myTemplateCreditor.AppendLine("      </CdtrAgt>");
                myTemplateCreditor.AppendLine("      <ChrgBr>SLEV</ChrgBr>");
                myTemplateCreditor.AppendLine("      <CdtrSchmeId>");
                myTemplateCreditor.AppendLine("        <Id>");
                myTemplateCreditor.AppendLine("          <PrvtId>");
                myTemplateCreditor.AppendLine("            <Othr>");
                myTemplateCreditor.AppendLine("              <Id>***PrvtId***</Id>");
                myTemplateCreditor.AppendLine("              <SchmeNm>");
                myTemplateCreditor.AppendLine("                <Prtry>SEPA</Prtry>");
                myTemplateCreditor.AppendLine("              </SchmeNm>");
                myTemplateCreditor.AppendLine("            </Othr>");
                myTemplateCreditor.AppendLine("          </PrvtId>");
                myTemplateCreditor.AppendLine("        </Id>");
                myTemplateCreditor.AppendLine("      </CdtrSchmeId>");
                myTemplateCreditor.Append("***insertDeb****");
                myTemplateCreditor.AppendLine("    </PmtInf>");

                // We gaan de FRST in een SDD zetten dus creditor toevoegen.
                StringBuilder batchFRST = new StringBuilder(myTemplateCreditor.ToString());
                string batchnameFRST = "Batch FRST " + DateTime.Now.ToString();
                batchFRST.Replace("***PmtInfId***", batchnameFRST);
                batchFRST.Replace("***NbOfTxs***", nbrFRST.ToString());
                batchFRST.Replace("***InstdAmt***", amtFRST.ToXMLString());
                batchFRST.Replace("***SeqTp***", "FRST");
                batchFRST.Replace("***ReqdColltnDt***", dtpIncassoDatum.Value.ToString("s").Substring(0, 10));
                batchFRST.Replace("***Nm***", param.ClubNameLong);
                batchFRST.Replace("***IBAN***", param.IBAN);
                batchFRST.Replace("***BIC***", param.BIC);
                batchFRST.Replace("***PrvtId***", Util.Iban.KvKIban(param.KvK));
                batchFRST.Replace("***insertDeb****", firstIncasso.ToString());

                // We gaan de RCUR in een SDD zetten dus creditor toevoegen.
                StringBuilder batchRCUR = new StringBuilder(myTemplateCreditor.ToString());
                string batchnameRCUR = "Batch RCUR " + DateTime.Now.ToString();
                batchRCUR.Replace("***PmtInfId***", batchnameRCUR);
                batchRCUR.Replace("***NbOfTxs***", nbrRCUR.ToString());
                batchRCUR.Replace("***InstdAmt***", amtRCUR.ToXMLString());
                batchRCUR.Replace("***SeqTp***", "RCUR");
                batchRCUR.Replace("***ReqdColltnDt***", dtpIncassoDatum.Value.ToString("s").Substring(0, 10));
                batchRCUR.Replace("***Nm***", param.ClubNameLong);
                batchRCUR.Replace("***IBAN***", param.IBAN);
                batchRCUR.Replace("***BIC***", param.BIC);
                batchRCUR.Replace("***PrvtId***", Util.Iban.KvKIban(param.KvK));
                batchRCUR.Replace("***insertDeb****", recurringIncasso.ToString());

                // Nu rest ons alleen nog de body eromheen te zetten.

                StringBuilder myTemplateBody = new StringBuilder();

                myTemplateBody.AppendLine(@"<Document xmlns=""urn:iso:std:iso:20022:tech:xsd:pain.008.001.02"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">");
                myTemplateBody.AppendLine("  <CstmrDrctDbtInitn>");
                myTemplateBody.AppendLine("    <GrpHdr>");
                myTemplateBody.AppendLine("      <MsgId>***MsgId***</MsgId>");
                myTemplateBody.AppendLine("      <CreDtTm>***CreDtTm***</CreDtTm>");
                myTemplateBody.AppendLine("      <NbOfTxs>***NbOfTxs***</NbOfTxs>");
                myTemplateBody.AppendLine("      <InitgPty>");
                myTemplateBody.AppendLine("        <Nm>***InitgPtyNm***</Nm>");
                myTemplateBody.AppendLine("        <Id>");
                myTemplateBody.AppendLine("          <OrgId>");
                myTemplateBody.AppendLine("            <Othr>");
                myTemplateBody.AppendLine("              <Id>***InitgPtyId***</Id>");
                myTemplateBody.AppendLine("            </Othr>");
                myTemplateBody.AppendLine("          </OrgId>");
                myTemplateBody.AppendLine("        </Id>");
                myTemplateBody.AppendLine("      </InitgPty>");
                myTemplateBody.AppendLine("    </GrpHdr>");
                myTemplateBody.Append("***insertFRST***");
                myTemplateBody.Append("***insertRCUR***");
                myTemplateBody.AppendLine("  </CstmrDrctDbtInitn>");
                myTemplateBody.AppendLine("</Document>");

                // Beide batches (mits gevuld) worden hier in de body geplaatst
                myTemplateBody.Replace("***MsgId***", param.ClubNameShort + " incasso " + seqnr.ToString("000"));
                myTemplateBody.Replace("***CreDtTm***", DateTime.Now.ToString("s"));
                myTemplateBody.Replace("***NbOfTxs***", selectedInc.Count.ToString());
                myTemplateBody.Replace("***InitgPtyNm***", param.ClubNameLong);
                myTemplateBody.Replace("***InitgPtyId***", param.KvK);
                if (nbrFRST > 0)
                    myTemplateBody.Replace("***insertFRST***", batchFRST.ToString());
                else
                    myTemplateBody.Replace("***insertFRST***", string.Empty);
                if (nbrRCUR > 0)
                    myTemplateBody.Replace("***insertRCUR***", batchRCUR.ToString());
                else
                    myTemplateBody.Replace("***insertRCUR***", string.Empty);

                #region replace unwanted characters
                // We vervangen niet toegestane tekens.
                // Wie weet een mooiere methode?
                myTemplateBody.Replace("À", "A");
                myTemplateBody.Replace("Á", "A");
                myTemplateBody.Replace("Â", "A");
                myTemplateBody.Replace("Ã", "A");
                myTemplateBody.Replace("Ä", "A");
                myTemplateBody.Replace("Å", "A");
                myTemplateBody.Replace("Æ", "AE");
                myTemplateBody.Replace("Ç", "C");
                myTemplateBody.Replace("È", "E");
                myTemplateBody.Replace("É", "E");
                myTemplateBody.Replace("Ê", "E");
                myTemplateBody.Replace("Ë", "E");
                myTemplateBody.Replace("Ì", "I");
                myTemplateBody.Replace("Í", "I");
                myTemplateBody.Replace("Î", "I");
                myTemplateBody.Replace("Ï", "I");
                myTemplateBody.Replace("Ð", "D");
                myTemplateBody.Replace("Ñ", "N");
                myTemplateBody.Replace("Ò", "O");
                myTemplateBody.Replace("Ó", "O");
                myTemplateBody.Replace("Ô", "O");
                myTemplateBody.Replace("Õ", "O");
                myTemplateBody.Replace("Ö", "O");
                myTemplateBody.Replace("Ø", "O");
                myTemplateBody.Replace("Ù", "U");
                myTemplateBody.Replace("Ú", "U");
                myTemplateBody.Replace("Û", "U");
                myTemplateBody.Replace("Ü", "U");
                myTemplateBody.Replace("ß", "ss");
                myTemplateBody.Replace("à", "a");
                myTemplateBody.Replace("á", "a");
                myTemplateBody.Replace("â", "a");
                myTemplateBody.Replace("ã", "a");
                myTemplateBody.Replace("ä", "a");
                myTemplateBody.Replace("å", "a");
                myTemplateBody.Replace("æ", "ae");
                myTemplateBody.Replace("ç", "c");
                myTemplateBody.Replace("è", "e");
                myTemplateBody.Replace("é", "e");
                myTemplateBody.Replace("ê", "e");
                myTemplateBody.Replace("ë", "e");
                myTemplateBody.Replace("ì", "i");
                myTemplateBody.Replace("í", "i");
                myTemplateBody.Replace("î", "i");
                myTemplateBody.Replace("ï", "i");
                myTemplateBody.Replace("ð", "o");
                myTemplateBody.Replace("ñ", "n");
                myTemplateBody.Replace("ò", "o");
                myTemplateBody.Replace("ó", "o");
                myTemplateBody.Replace("ô", "o");
                myTemplateBody.Replace("õ", "o");
                myTemplateBody.Replace("ö", "o");
                myTemplateBody.Replace("ø", "o");
                myTemplateBody.Replace("ù", "u");
                myTemplateBody.Replace("ú", "u");
                myTemplateBody.Replace("û", "u");
                myTemplateBody.Replace("ü", "u");
                myTemplateBody.Replace("ý", "u");
                myTemplateBody.Replace("ÿ", "y");
                myTemplateBody.Replace("ÿ", "y");
                myTemplateBody.Replace("€", "E");
                #endregion

                // En klaar is kees. Nu het bestand inschrijven.
                string outputfile = txtOutputLocationInc.Text + @"\" + txtFilePrefix.Text + seqnr.ToString("000") + ".xml";
                StreamWriter swOutput = new StreamWriter(outputfile);

                swOutput.WriteLine(myTemplateBody.ToString());
                swOutput.Flush();
                swOutput.Close();
                swOutput.Dispose();

                 // Hier ga ik het incasso verslag maken
                #region IncassoVerslag
                outputverslag = txtOutputLocationInc.Text + @"\" + txtFilePrefix.Text + seqnr.ToString("000") + "_OutputVerslag.txt";
                StringBuilder incassoVerslag = new StringBuilder();
                incassoVerslag.AppendLine("Incassoverslag: " + outputfile);
                incassoVerslag.AppendLine();
                incassoVerslag.AppendLine("Batch Naam: " + batchnameFRST);
                incassoVerslag.AppendLine("Aantal: " + nbrFRST.ToString() + "  Bedrag: " + amtFRST.ToEuroString());
                incassoVerslag.AppendLine();
                incassoVerslag.AppendLine(sbrIncFRST.ToString());

                incassoVerslag.AppendLine();
                incassoVerslag.AppendLine("Batch Naam: " + batchnameRCUR);
                incassoVerslag.AppendLine("Aantal: " + nbrRCUR.ToString() + "  Bedrag: " + amtRCUR.ToEuroString());
                incassoVerslag.AppendLine();
                incassoVerslag.AppendLine(sbrIncRCUR.ToString());

                StreamWriter swVerslag = new StreamWriter(outputverslag);
                swVerslag.WriteLine(incassoVerslag.ToString());
                swVerslag.Flush();
                swVerslag.Close();
                swVerslag.Dispose();

                if (chkPrintVerslag.Checked)
                {
                    fileToPrint = new System.IO.StreamReader(outputverslag);
                    printFont = new System.Drawing.Font("Courier New", 8);
                    printDocument1.DocumentName = "Incasso Verslag";
                    printDocument1.Print();
                    fileToPrint.Close();
                }
                #endregion

                // We controleren nog even of het bestand aan het schema voldoet.
                CheckPain(outputfile);

                seqnr++;
                txtFileSeqnr.Text = seqnr.ToString();
                CreateGeneralLedgerInfo(selectedInc);

                // Bewaar incasso's ter controle
                ReportRoutines.CreateRekeningingenReport("Incassobestand", selectedInc, verstuurdeRekeningenReport, true);
                dataAdaptor.UpdateRekeningen(rekeningen);
                dataAdaptor.UpdateLeden(leden);
                dataAdaptor.CommitTransaction(true);
                MessageBox.Show("Bestand aangemaakt: " + outputfile + "\nAantal incasso's: " + selectedInc.Count, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
#if (Laptop)
                ShowText.Show(myTemplateBody.ToString());
#endif
                cmdMaakbestand.Enabled = false;
            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
        }
        #endregion

        #region Validate XML

        public void CheckPain(string outputfile)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("urn:iso:std:iso:20022:tech:xsd:pain.008.001.02", param.LocationTemplates + @"\pain.008.001.02.xsd");

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

        #region cmdMaakBestandRek_Click
        private void cmdMaakBestandRek_Click(object sender, EventArgs e)
        {
            if (selectedRek.Count == 0)
            {
                MessageBox.Show("Geen rekeningen", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (Leden.Net.tblRekening rekening in selectedRek)
            {
                rekening.Verstuurd = true;
                rekening.VerstuurdDatum = dtpIncassoDatum.Value;
            }

            // Maak Papieren rekeningen
            int seqnr = txtFileSeqnrRek.Text.IsNumeric() ? Convert.ToInt32(txtFileSeqnrRek.Text) : 0;
            string outputfile = txtOutputLocationRek.Text + @"\" + txtFilePrefixRek.Text + seqnr.ToString("000") + ".csv";
            ReportRoutines.CreateRekeningingenReport("Rekeningenbestand", selectedRek, outputfile, false);
            seqnr++;
            txtFileSeqnrRek.Text = seqnr.ToString();
            ReportRoutines.CreateRekeningingenReport("Rekeningenbestand", selectedRek, verstuurdeRekeningenReport, true);

            CreateGeneralLedgerInfo(selectedRek);
            MessageBox.Show("Bestand aangemaakt: " + outputfile + "\nAantal rekeningen: " + selectedRek.Count, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmdMaakBestandRek.Enabled = false;
        }
        #endregion

        #region cmdMaakBestandUPas_Click
        private void cmdMaakBestandUPas_Click(object sender, EventArgs e)
        {
            if (selectedUPas.Count == 0)
            {
                MessageBox.Show("Geen rekeningen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Leden.Net.tblRekening rekening in selectedUPas)
            {
                rekening.Verstuurd = true;
                rekening.VerstuurdDatum = dtpIncassoDatum.Value;
            }

            // Maak U-Pas rekeningen
            int seqnr = txtFileSeqnrUPas.Text.IsNumeric() ? Convert.ToInt32(txtFileSeqnrUPas.Text) : 0;
            string outputfile = txtOutputLocationUPas.Text + @"\" + txtFilePrefixUPas.Text + seqnr.ToString("000") + ".csv";
            ReportRoutines.CreateRekeningingenReport("U-Pasbestand", selectedUPas, outputfile, false);
            seqnr++;
            txtFileSeqnrRek.Text = seqnr.ToString();

            ReportRoutines.CreateRekeningingenReport("U-Pasbestand", selectedUPas, verstuurdeRekeningenReport, true);
            CreateGeneralLedgerInfo(selectedUPas);
            MessageBox.Show("Bestand aangemaakt: " + outputfile + "\nAantal U-Pas's: " + selectedUPas.Count, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cmdMaakBestandUPas.Enabled = false;
        }

        #endregion

        #region Verstuur contributie aankondiging
        StringBuilder errorList = new StringBuilder();
        bool errorMail = false;
        ProgressWindow progress;
        IProgressCallback callback;

        private void cmdMail_Click(object sender, EventArgs e)
        {
            progress = new ProgressWindow();
            progress.Text = "Emailing";
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(DoSomeWork), progress);
            progress.ShowDialog();
            if (errorMail)
                ShowText.Show(errorList.ToString(), "Failed Email");
        }

        private void DoSomeWork(object status)
        {
            errorList = new StringBuilder();
            errorMail = false;
            errorList.AppendLine("Email not sent to:");
            callback = status as IProgressCallback;
            try
            {
                callback.Begin(0, nbrTxtInc);
                SendContributieIncassoAankondiging();
                SendInschrijfIncassoAankondiging();
                callback.WaitOK();
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
                GuiRoutines.ExceptionMessageBox(this, ex);
            }
            finally
            {
                if (callback != null)
                {
                    callback.End();
                }
            }
        }

        private void SendContributieIncassoAankondiging()
        {
            string fileName = param.LocationTemplates + @"\Template_ContributieIncasso.htm"; ;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor incasso mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                                            EmailLogFile, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, callback.SetText);


            //SmtpEmailer emailer = new SmtpEmailer();
            //emailer.Host = param.STMPserver;
            //emailer.From = param.EmailReturnAdress;
            //emailer.AuthenticationMode = AuthenticationType.Base64;
            //emailer.User = param.EmailUserId;
            //emailer.Password = param.EmailPassword;
            //emailer.SendAsHtml = true;
            //emailer.LogFile = EmailLogFile;
            //emailer.DoNotSendMail = ckbDoNotSendEmail.Checked;
            //emailer.LogMail = chkLogEmail.Checked;


            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();


            foreach (Leden.Net.tblRekening rekening in selectedInc)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.EmailReturnAdress);
                //emailer.ClearMessage();
                if (rekening.TypeRekening != 0 || rekening.MailOnderdrukken) continue;                  // Alleen contributie incasso's

                string sbr = template;
                // vervangen keywords
                sbr = MailRoutines.ReplaceKeyWords(sbr, rekening.Lid, param);
                sbr = ReplaceRekeningItems(sbr, rekening);

                message.IsBodyHtml = true;
                message.Body = sbr;
                //emailer.Body = sbr;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    message.Subject = "Aankondiging contributie incasso TTVN";
                    //emailer.Subject = "Aankondiging contributie incasso TTVN";
                    message.To.Add(rekening.Lid.MainEmailAdress);
                    //emailer.To.Add(rekening.Lid.MainEmailAdress);
                }
                else
                {
                    message.Subject = "Geen email adres bij Aankondiging contributie incasso TTVN";
                    //emailer.Subject = "Geen email adres bij Aankondiging contributie incasso TTVN";
                    //emailer.To.Add(param.EmailReturnAdress);
                    message.To.Add(param.EmailReturnAdress);
                }
                try
                {
                    client.Send(message);
                    //emailer.SendMessage();
                }
                catch
                {
                    errorMail = true;
                    errorList.AppendLine(rekening.Lid.MainEmailAdress);
                }
                callback.Increment(1);
                callback.SetText(rekening.Lid.MainEmailAdress);
                System.Threading.Thread.Sleep(50);
                if (callback.IsAborting) return;
            }
        }

        private void SendInschrijfIncassoAankondiging()
        {
            string fileName = param.LocationTemplates + @"\Template_InschrijfIncasso.htm";

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor inschrijfgeldincasso mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SmtpClientExt client = new SmtpClientExt(param.STMPserver, param.STMPport, param.EmailUserId, param.EmailPassword,
                                            EmailLogFile, chkLogEmail.Checked, ckbDoNotSendEmail.Checked, callback.SetText);

            //SmtpEmailer emailer = new SmtpEmailer();
            //emailer.Host = param.STMPserver;
            //emailer.From = param.EmailReturnAdress;
            //emailer.AuthenticationMode = AuthenticationType.Base64;
            //emailer.User = param.EmailUserId;
            //emailer.Password = param.EmailPassword;
            //emailer.LogFile = EmailLogFile;
            //emailer.DoNotSendMail = ckbDoNotSendEmail.Checked;
            //emailer.LogMail = chkLogEmail.Checked;

            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();
            foreach (Leden.Net.tblRekening rekening in selectedInc)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(param.EmailReturnAdress);

                //emailer.ClearMessage();
                if (rekening.TypeRekening == 0) continue;  // Geen Contributie incasso's
                string sbr = template;
                //vervangen
                sbr = MailRoutines.ReplaceKeyWords(sbr, rekening.Lid, param);
                sbr = ReplaceRekeningItems(sbr, rekening);

                message.Body = sbr;
                //emailer.Body = sbr;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    message.Subject = "Aankondiging incasso TTVN";
                    //emailer.Subject = "Aankondiging incasso TTVN";
                    message.To.Add(rekening.Lid.MainEmailAdress);
                    //emailer.To.Add(rekening.Lid.MainEmailAdress);
                }
                else
                {
                    message.Subject = "Geen email adres bij Aankondiging  incasso TTVN";
                    //emailer.Subject = "Geen email adres bij Aankondiging  incasso TTVN";
                    message.To.Add(param.EmailReturnAdress);
                    //emailer.To.Add(param.EmailReturnAdress);
                }

                message.IsBodyHtml = true;
                //emailer.SendAsHtml = true;
                try
                {
                    client.Send(message);
                    //emailer.SendMessage();
                }
                catch
                {
                    errorMail = true;
                    errorList.AppendLine(rekening.Lid.MainEmailAdress);
                }
                callback.Increment(1);
                callback.SetText(rekening.Lid.MainEmailAdress);
                System.Threading.Thread.Sleep(50);
                if (callback.IsAborting) return;
            }
        }
        static void VulTextBox(string status)
        { }
        #endregion

        private void frmRekeningVersturen_FormClosing(object sender, FormClosingEventArgs e)
        {
            param.itxtFilePrefix = txtFilePrefix.Text;
            param.itxtFileSeqnr = Convert.ToInt32(txtFileSeqnr.Text);
            param.itxtMsgID = txtMsgID.Text;
            param.itxtOutputLocationInc = txtOutputLocationInc.Text;
            param.itxtOutputLocationRek = txtOutputLocationRek.Text;
            param.itxtFilePrefixRek = txtFilePrefixRek.Text;
            param.itxtFileSeqnrRek = Convert.ToInt32(txtFileSeqnrRek.Text);
            param.itxtOutputLocationUPas = txtOutputLocationUPas.Text;
            param.itxtFilePrefixUPas = txtFilePrefixUPas.Text;
            param.itxtFileSeqnrUPas = Convert.ToInt32(txtFileSeqnrUPas.Text);
            param.ichkPrintVerslag = chkPrintVerslag.Checked;

/*
            PersistControlValue.StoreControlValue(txtFilePrefix);
            PersistControlValue.StoreControlValue(txtFileSeqnr);
            PersistControlValue.StoreControlValue(txtMsgID);
            PersistControlValue.StoreControlValue(txtOutputLocationInc);

            PersistControlValue.StoreControlValue(txtOutputLocationRek);
            PersistControlValue.StoreControlValue(txtFilePrefixRek);
            PersistControlValue.StoreControlValue(txtFileSeqnrRek);

            PersistControlValue.StoreControlValue(txtOutputLocationUPas);
            PersistControlValue.StoreControlValue(txtFilePrefixUPas);
            PersistControlValue.StoreControlValue(txtFileSeqnrUPas);
            PersistControlValue.StoreControlValue(chkPrintVerslag);
 */
        }

        #region CreateGeneralLedgerInfo
        private void CreateGeneralLedgerInfo(RekeningenLijst rekeningen)
        {
            string outputfile = txtOutputLocationInc.Text  + @"\" + param.ClubNameShort + @"_JP.csv";
            StreamWriter sw = new StreamWriter(outputfile, true);
            sw.WriteLine(@"*** " + DateTime.Today.ToShortDateString() + " ***");
            decimal amtSenTotal = 0;
            decimal amtSenCompetitieBijdrage = 0;
            decimal amtSenContributieBedrag = 0;
            decimal amtSenBondsbijdrage = 0;
            decimal amtSenExtraBedrag = 0;
            decimal amtJunTotal = 0;
            decimal amtJunCompetitieBijdrage = 0;
            decimal amtJunContributieBedrag = 0;
            decimal amtJunBondsbijdrage = 0;
            decimal amtJunExtraBedrag = 0;
            List<string> columns = new List<string>();

            foreach (tblRekening rekening in rekeningen)
            {
                columns.Clear();
                columns.Add("");
                columns.Add("");
                columns.Add("");
                if (rekening.IsContributie)
                {
                    if (rekening.Lid.Is_SEN1_65_SEN)
                    {
                        columns.Add("Sen. XX - Te ontv. Contributie");
                        amtSenTotal += rekening.TotaalBedrag;
                        amtSenContributieBedrag += rekening.ContributieBedrag - rekening.Korting;
                        amtSenCompetitieBijdrage += rekening.CompetitieBijdrage;
                        amtSenBondsbijdrage += rekening.Bondsbijdrage;
                        amtSenExtraBedrag += rekening.ExtraBedrag;
                    }
                    else
                    {
                        columns.Add("Jun. XX - Te ontv. Contributie");
                        amtJunTotal += rekening.TotaalBedrag;
                        amtJunContributieBedrag += rekening.ContributieBedrag - rekening.Korting;
                        amtJunCompetitieBijdrage += rekening.CompetitieBijdrage;
                        amtJunBondsbijdrage += rekening.Bondsbijdrage;
                        amtJunExtraBedrag += rekening.ExtraBedrag;
                    }
                }
                if (rekening.IsInschrijfgeld)
                {
                    if (rekening.Lid.Is_SEN1_65_SEN)
                        columns.Add("Sen. Toernooikosten");
                    else
                        columns.Add("Jun. Toernooikosten");
                }
                if (rekening.IsOverig)
                {
                    if (rekening.Lid.Is_SEN1_65_SEN)
                        columns.Add("Sen. Diverse Kosten");
                    else
                        columns.Add("Jun. Diverse Kosten");
                }
                columns.Add("");
                columns.Add(rekening.TotaalBedrag.ToCSVString());
                columns.Add(rekening.Lid.LidNr.ToString());
                columns.Add(rekening.Lid.VolledigeNaam);
                columns.Add(rekening.Omschrijving);
                sw.WriteLine(String.Join(";", columns.ToArray()));
            }

            sw.WriteLine(@"*** " + DateTime.Today.ToShortDateString() + " ***");

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Sen. XX - Te ontv. Contributie");
            columns.Add(amtSenTotal.ToCSVString());
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Sen. XX - Contributie-inkomsten");
            columns.Add("");
            columns.Add(amtSenContributieBedrag.ToCSVString());
            columns.Add("Normale Contributie");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Sen. XX - Bondcontributie");
            columns.Add("");
            columns.Add(amtSenBondsbijdrage.ToCSVString());
            columns.Add("Bondsbijdrage");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Sen. XX - Competitiebijdrage");
            columns.Add("");
            columns.Add(amtSenCompetitieBijdrage.ToCSVString());
            columns.Add("Competitiebijdrage");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Sen. XX - Contributie-inkomsten");
            columns.Add("");
            columns.Add(amtSenExtraBedrag.ToCSVString());
            columns.Add("Kosten Rekening");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Jun. XX - Te ontv. Contributie");
            columns.Add(amtJunTotal.ToCSVString());
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Jun. XX - Contributie-inkomsten");
            columns.Add("");
            columns.Add(amtJunContributieBedrag.ToCSVString());
            columns.Add("Normale Contributie");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Jun. XX - Bondcontributie");
            columns.Add("");
            columns.Add(amtJunBondsbijdrage.ToCSVString());
            columns.Add("Bondsbijdrage");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Jun. XX - Competitiebijdrage");
            columns.Add("");
            columns.Add(amtJunCompetitieBijdrage.ToCSVString());
            columns.Add("Competitiebijdrage");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            columns.Clear();
            columns.Add("");
            columns.Add("");
            columns.Add("");
            columns.Add("Jun. XX - Contributie-inkomsten");
            columns.Add("");
            columns.Add(amtJunExtraBedrag.ToCSVString());
            columns.Add("Kosten Rekening");
            sw.WriteLine(String.Join(";", columns.ToArray()));

            sw.Close();

        }
        #endregion

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            fdiBrowseTemplate.ShowDialog();
            if (fdiBrowseTemplate.SelectedPath != string.Empty)
                txtOutputLocationInc.Text = fdiBrowseTemplate.SelectedPath;
        }

        private void lblLocatieOutputCSV_Click(object sender, EventArgs e)
        {
            fdiBrowseTemplate.ShowDialog();
            if (fdiBrowseTemplate.SelectedPath != string.Empty)
                txtOutputLocationRek.Text = fdiBrowseTemplate.SelectedPath;
        }

        private void lblLocatieOutputUPas_Click(object sender, EventArgs e)
        {
            fdiBrowseTemplate.ShowDialog();
            if (fdiBrowseTemplate.SelectedPath != string.Empty)
                txtOutputLocationUPas.Text = fdiBrowseTemplate.SelectedPath;
        }

        private void cmdMailRek_Click(object sender, EventArgs e)
        {
            string fileName = param.LocationTemplates + @"\Template_ContributieRekening.htm"; ;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Template voor rekening mail " + fileName + " bestaat niet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            StreamReader sr = File.OpenText(fileName);
            StringReader str = new StringReader(sr.ReadToEnd());
            string template = str.ReadToEnd();

            foreach (Leden.Net.tblRekening rekening in selectedRek)
            {
                if (rekening.TypeRekening != 0) continue;                  // Alleen contributie rekening
  
                BodyString body = ReplaceRekeningItems(template, rekening);   
                    
                string subject;
                if (rekening.Lid.MainEmailAdress != string.Empty)
                {
                    subject = "Aankondiging contributie rekening TTVN";
                }
                else
                {
                    subject = "Geen email adres bij Aankondiging contributie rekening TTVN";
                }

                try
                {
                    frmMultiMail frm = new frmMultiMail(rekening, param, body, subject, new List<string>());
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    GuiRoutines.ExceptionMessageBox(this, ex);
                }
            }
        }


        public string ReplaceRekeningItems(string template, tblRekening rekening)
        {
            //vervangen
            template = template.Replace("***incdat***", dtpIncassoDatum.Value.ToString("s").Substring(0, 10));

            template = template.Replace("***incamt***", rekening.TotaalBedrag.ToXMLEuroString());
            template = template.Replace("***b1***", "Contributie");
            template = template.Replace("***w1***", rekening.ContributieBedrag.ToXMLEuroString());

            template = template.Replace("***IBAN***", rekening.IBAN);
            template = template.Replace("***BIC***", rekening.BIC);

            int j = 2;
            string x = "***b" + j.ToString() + "***";
            if (rekening.Bondsbijdrage != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Bondsbijdrage");
                template = template.Replace("***w" + j.ToString() + "***", rekening.Bondsbijdrage.ToXMLEuroString());
                j++;
            }
            if (rekening.CompetitieBijdrage != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "CompetitieBijdrage");
                template = template.Replace("***w" + j.ToString() + "***", rekening.CompetitieBijdrage.ToXMLEuroString());
                j++;
            }
            if (rekening.Korting != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Korting");
                template = template.Replace("***w" + j.ToString() + "***", rekening.Korting.ToXMLEuroString());
                j++;
            }
            if (rekening.ExtraBedrag != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Kosten rekening");
                template = template.Replace("***w" + j.ToString() + "***", rekening.ExtraBedrag.ToXMLEuroString());
                j++;
            }
            if (rekening.BedragKortingVrijwilliger != 0)
            {
                template = template.Replace("***b" + j.ToString() + "***", "Korting Vrijwilliger");
                template = template.Replace("***w" + j.ToString() + "***", rekening.BedragKortingVrijwilliger.ToXMLEuroString());
                j++;
            }

            for (int i = j; i <= 5; i++)
            {
                template = template.Replace("***b" + i.ToString() + "***", string.Empty);
                template = template.Replace("***w" + i.ToString() + "***", string.Empty);
            }


            template = template.Replace("***omschrijving***", rekening.Omschrijving);

            return template;
        }
                 

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

        private void cmdOutput_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(verstuurdeRekeningenReport);
                GuiRoutines.ShowMessage(sr.ReadToEnd(), verstuurdeRekeningenReport);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmdShowLogfileMail_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader sr = new StreamReader(EmailLogFile);
                GuiRoutines.ShowMessage(sr.ReadToEnd(), EmailLogFile);
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
