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
    public partial class frmVCard : frmBasis
    {
        string contactFileNameXML;
        tblVCard vCardLijst;
        List<VCard2> objVCardList;
        LedenLijst leden;

        public frmVCard(object l)
        {
            #region Initialize
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\ExportVCard");

            param = new tblParameters();

            if (l is DataAdapters)
                leden = ((DataAdapters)l).VulLedenLijst();
            if (l is LedenLijst)
                leden = (LedenLijst)l;

            objVCardList = new List<VCard2>();

            InitializeDataListView(olvVCard);

            PersistControlValue.ReadControlValue(txtOutputLocation);

            #endregion

            #region Create Columns

            int lTel = 85;
            int lMail = 180;

            OLVColumn dlvc01 = new OLVColumn("Achternaam", "Achternaam");
            OLVColumn dlvc02  = new OLVColumn("Voornaam","Voornaam");
            OLVColumn dlvc03  = new OLVColumn("Tussen", "Tussen");
            OLVColumn dlvc04  = new OLVColumn("Titel","Titel");
            OLVColumn ColumnOrganisatie  = new OLVColumn("Organisatie", "Organisatie");
            OLVColumn dlvc06  = new OLVColumn("TelThuis", "TelThuis");
            OLVColumn dlvc07  = new OLVColumn("Mobiel1", "Mobiel1");
            OLVColumn dlvc08  = new OLVColumn("Mobiel2", "Mobiel2");
            OLVColumn dlvc09  = new OLVColumn("TelWerk", "TelWerk");
            OLVColumn dlvc10 = new OLVColumn("Email1", "Email1");
            OLVColumn dlvc11 = new OLVColumn("Email2", "Email2");
            OLVColumn dlvc12 = new OLVColumn("Adres", "Adres");
            OLVColumn dlvc13 = new OLVColumn("Postcode", "Postcode");
            OLVColumn dlvc14 = new OLVColumn("Woonplaats", "Woonplaats");
            OLVColumn dlvc15 = new OLVColumn("Notitie", "Notitie");
            OLVColumn dlvc16 = new OLVColumn("Lid", "Lid");

            dlvc01.Width = 90;
            dlvc02.Width = 120;
            dlvc03.Width = 30;
            dlvc04.Width = 60;
            ColumnOrganisatie.Width = 60;
            dlvc06.Width = dlvc07.Width = dlvc08.Width = dlvc09.Width = lTel;
            dlvc10.Width = dlvc11.Width = lMail;
            dlvc12.Width = 60;
            dlvc13.Width = 60;
            dlvc14.Width = 60;
            dlvc15.Width = 180;
            dlvc16.Width = 60;
            
            dlvc01.UseInitialLetterForGroup = true;
            dlvc02.UseInitialLetterForGroup = true;
            dlvc03.UseInitialLetterForGroup = true;
            dlvc04.UseInitialLetterForGroup = true;
            ColumnOrganisatie.UseInitialLetterForGroup = false;
            dlvc06.UseInitialLetterForGroup = true;
            dlvc07.UseInitialLetterForGroup = true;
            dlvc08.UseInitialLetterForGroup = true;
            dlvc09.UseInitialLetterForGroup = true;
            dlvc10.UseInitialLetterForGroup = true;
            dlvc11.UseInitialLetterForGroup = true;
            dlvc12.UseInitialLetterForGroup = true;
            dlvc13.UseInitialLetterForGroup = true;
            dlvc14.UseInitialLetterForGroup = true;
            dlvc15.UseInitialLetterForGroup = true;

            //dlvc16.CheckBoxes = true;
            dlvc16.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            dlvc16.ToolTipText = "Is dit contact toegevoegd via Leden administratie?";
            dlvc16.TriStateCheckBoxes = true;
            //dlvc16.HeaderCheckBox = true;

            olvVCard.Columns.Add(dlvc01);
            olvVCard.Columns.Add(dlvc02);
            olvVCard.Columns.Add(dlvc03);
            olvVCard.Columns.Add(dlvc04);
            olvVCard.Columns.Add(ColumnOrganisatie);
            olvVCard.Columns.Add(dlvc06);
            olvVCard.Columns.Add(dlvc07);
            olvVCard.Columns.Add(dlvc08);
            olvVCard.Columns.Add(dlvc09);
            olvVCard.Columns.Add(dlvc10);
            olvVCard.Columns.Add(dlvc11);
            olvVCard.Columns.Add(dlvc12);
            olvVCard.Columns.Add(dlvc13);
            olvVCard.Columns.Add(dlvc14);
            olvVCard.Columns.Add(dlvc15);
            olvVCard.Columns.Add(dlvc16);

            //dlvc02.AspectGetter = delegate(object row)
            //{
            //    VCard2 vc = (VCard2)row;
            //    return vc.Voornaam + " " + (vc.Tussen != string.Empty ? vc.Tussen + " " : string.Empty) + vc.Achternaam + "\n" + "twee";
            //};



            #endregion

            #region Inlezen XML met contactpersonen
            contactFileNameXML = param.LocationTemplates + @"\ContactPersonen.xml";
            if (contactFileNameXML != string.Empty)
            {
                try
                {
                    using (StreamReader sr = File.OpenText(contactFileNameXML))
                    {
                        using (TextReader tr = new StringReader(sr.ReadToEnd()))
                        {
                            XmlSerializer s = new XmlSerializer(typeof(tblVCard));
                            vCardLijst = (tblVCard)s.Deserialize(tr);
                        }
                    }
                    foreach (VCard vCard in vCardLijst)
                    {
                        vCard.Dirty = true;
                    }
                }
                catch { }
                if (vCardLijst == null)
                    vCardLijst = new tblVCard();


            }

            #endregion

            OntdubbelvCardLijst();
            CopyVCardListToLocal();
            olvVCard.SetObjects(objVCardList);
        }

        #region InitializeDataListView
        private void InitializeDataListView(FastObjectListView olv)
        {
            olv.UseSubItemCheckBoxes = true;  //zonder dit attribuut komen de checkboxes niet op de lijst te staan
            olv.AddDecoration(new EditingCellBorderDecoration(true));
        }
        #endregion

        #region Ontdubbel vCardLijst
        private void OntdubbelvCardLijst()
        {
            // verwijderern van dubbele entries. We gooien de eerste weg door hem dirty te maken
            foreach (VCard vCard in vCardLijst)
                vCard.Dirty = false;

            for (int i = 0; i <= vCardLijst.Count -2; i++)
            {
                for (int j = i + 1; j <= vCardLijst.Count - 1; j++)
                {
                    if (vCardLijst[i].NetteNaam.Trim() == vCardLijst[j].NetteNaam.Trim())
                    {
                        vCardLijst[i].Dirty = true;
                        vCardLijst[j].adresLijst.AddRange(vCardLijst[i].adresLijst);
                        vCardLijst[j].emailLijst.AddRange(vCardLijst[i].emailLijst);
                        vCardLijst[j].telefoonNummerLijst.AddRange(vCardLijst[i].telefoonNummerLijst);
                    }
                }
            }

            for (int i = vCardLijst.Count - 1; i >= 0; i--)
            {
                //Console.WriteLine("{0}  {1}   {2}", i, vCardLijst[i].Dirty, vCardLijst[i].NetteNaam.Trim());
                if (vCardLijst[i].Dirty) vCardLijst.RemoveAt(i);
            }
            // nu de dubbele telnr, email en adressen verwijderen
            // ik weet niet echt een snelle methode. Ik zet nu alle records in de lijsten op Dirty = false;
            // bij een dubble zet ik dirty op true
            // tenslotte verwijder ik alle dirty's.


            foreach (VCard vCard in vCardLijst)
            {
                foreach (AddressClass adres in vCard.adresLijst)
                    adres.Dirty = false;
                foreach (TelephoneNumberClass telefoon in vCard.telefoonNummerLijst)
                    telefoon.Dirty = false;
                foreach (EmailAddressClass email in vCard.emailLijst)
                    email.Dirty = false;

                for (int i = 0; i <= vCard.adresLijst.Count - 2; i++)
                {
                    for (int j = i + 1; j <= vCard.adresLijst.Count - 1; j++)
                    {
                        if ((vCard.adresLijst[i].Adres.Trim() == vCard.adresLijst[j].Adres.Trim()) ||
                            (vCard.adresLijst[i].Adres.Trim() == string.Empty))
                            vCard.adresLijst[i].Dirty = true;
                    }
                }

                for (int i = 0; i <= vCard.emailLijst.Count - 2; i++)
                {
                    for (int j = i + 1; j <= vCard.emailLijst.Count - 1; j++)
                    {
                        if ((vCard.emailLijst[i].EmailAddress.Trim() == vCard.emailLijst[j].EmailAddress.Trim()) ||
                            (vCard.emailLijst[i].EmailAddress.Trim() == string.Empty))
                            vCard.emailLijst[i].Dirty = true;
                    }
                }

                for (int i = 0; i <= vCard.telefoonNummerLijst.Count - 2; i++)
                {
                    for (int j = i + 1; j <= vCard.telefoonNummerLijst.Count - 1; j++)
                    {
                        int l1 = vCard.telefoonNummerLijst[i].TelephoneNumber.Trim().Length - 7;
                        int l2 = vCard.telefoonNummerLijst[j].TelephoneNumber.Trim().Length - 7;
                        if (l1 <= 2)
                        {
                            l1 = 0;
                            vCard.telefoonNummerLijst[i].TelephoneNumber = string.Empty;
                        }
                        if (l2 <= 2)
                        {
                            l2 = 0;
                            vCard.telefoonNummerLijst[j].TelephoneNumber = string.Empty;
                        }

                        
                        if ((vCard.telefoonNummerLijst[i].TelephoneNumber.Trim().Substring(l1) == vCard.telefoonNummerLijst[j].TelephoneNumber.Trim().Substring(l2)) ||
                            (vCard.telefoonNummerLijst[i].TelephoneNumber.Trim() == string.Empty))
                            vCard.telefoonNummerLijst[i].Dirty = true;
                    }
                }


                for (int i = vCard.adresLijst.Count - 1; i >= 0; i--)
                    if (vCard.adresLijst[i].Dirty)
                        vCard.adresLijst.RemoveAt(i);
                for (int i = vCard.emailLijst.Count - 1; i >= 0; i--)
                    if (vCard.emailLijst[i].Dirty)
                        vCard.emailLijst.RemoveAt(i);
                for (int i = vCard.telefoonNummerLijst.Count - 1; i >= 0; i--)
                    if (vCard.telefoonNummerLijst[i].Dirty)
                        vCard.telefoonNummerLijst.RemoveAt(i);

            }

            vCardLijst.Sort(new vCardComparer());

        }
        #endregion

        #region CopyVCardListToLocal
        private void CopyVCardListToLocal()
        {
            foreach (VCard vCard in vCardLijst)
            {
                objVCardList.Add(CopyVCard(vCard));
            }
        }

        private VCard2 CopyVCard(VCard vCard)
        {
            VCard2 vc2 = new VCard2();

            vc2.Achternaam = vCard.Achternaam;
            vc2.Voornaam = vCard.Voornaam;
            vc2.Tussen = vCard.Tussenvoegsel;
            vc2.Titel = vCard.Title;
            vc2.Organisatie = vCard.Organisatie;
            vc2.Lid = vCard.Leden;

            if (vCard.adresLijst.Count > 0)
            {
                vc2.Adres = vCard.adresLijst[0].Adres;
                vc2.Woonplaats = vCard.adresLijst[0].Woonplaats;
                vc2.Postcode = vCard.adresLijst[0].Postcode;
            }
            else
            {
                vc2.Adres = string.Empty;
                vc2.Woonplaats = string.Empty;
                vc2.Postcode = string.Empty;
            }

            vc2.Notitie = vCard.Note;


            bool[] bezet = new bool[4];
            for (int i = 0; i <= 3; i++)
                bezet[i] = false;

            foreach (TelephoneNumberClass telefoon in vCard.telefoonNummerLijst)
            {
                if (telefoon.Type == "HOME" && bezet[0] == false)
                {
                    vc2.TelThuis = telefoon.TelephoneNumber;
                    bezet[0] = true;
                    continue;
                }
                if (telefoon.Type == "CELL")
                    if (bezet[1] == false)
                    {
                        vc2.Mobiel1 = telefoon.TelephoneNumber;
                        bezet[1] = true;
                        continue;
                    }
                    else
                        if (bezet[2] == false)
                        {
                            vc2.Mobiel2 = telefoon.TelephoneNumber;
                            bezet[2] = true;
                            continue;
                        }
                        else
                            if (bezet[3] == false)
                            {
                                vc2.TelWerk = telefoon.TelephoneNumber;
                                bezet[3] = true;
                                continue;
                            }
                if (telefoon.Type == "WORK" && bezet[3] == false)
                {
                    vc2.TelWerk = telefoon.TelephoneNumber;
                    bezet[3] = true;
                    continue;
                }

                if (bezet[0] == false)
                {
                    vc2.TelThuis = telefoon.TelephoneNumber;
                    bezet[0] = true;
                    continue;
                }
                else
                {
                    if (bezet[1] == false)
                    {
                        vc2.Mobiel1 = telefoon.TelephoneNumber;
                        bezet[1] = true;
                        continue;
                    }
                    else
                    {
                        if (bezet[2] == false)
                        {
                            vc2.Mobiel2 = telefoon.TelephoneNumber;
                            bezet[2] = true;
                            continue;
                        }
                        else
                        {
                            if (bezet[3] == false)
                            {
                                vc2.TelWerk = telefoon.TelephoneNumber;
                                bezet[3] = true;
                                continue;
                            }
                        }
                    }

                }

            }

            for (int i = 0; i <= 3; i++)
                bezet[i] = false;

            foreach (EmailAddressClass email in vCard.emailLijst)
            {
                if (bezet[0] == false)
                {
                    vc2.Email1 = email.EmailAddress;
                    bezet[0] = true;
                    continue;
                }
                if (bezet[1] == false)
                {
                    vc2.Email2 = email.EmailAddress;
                    bezet[1] = true;
                    continue;
                }
            }
            vc2.Tag = vCard;
            return vc2;
        }
        #endregion

        private void frmVCard_SizeChanged(object sender, EventArgs e)
        {
            pnlLeft.Width = this.Width - 150;
        }

        private void frmVCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(txtOutputLocation);
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            VCard2 vc2 = new VCard2();
            olvVCard.AddObject(vc2);
            olvVCard.EnsureModelVisible(vc2);
            toolStripStatusLabel1.Text = "Nieuw contact toegevoegd";
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            olvVCard.RemoveObjects(olvVCard.SelectedObjects);
            toolStripStatusLabel1.Text = "Contact(en) verwijderd";
        }

        private void lblLocatieOutput_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != string.Empty)
                txtOutputLocation.Text = folderBrowserDialog1.SelectedPath;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {

            vCardLijst = new tblVCard();
            CopyLocalToVCardList();

            // Create a XmlWriter to write with.
            XmlSerializer serializer = new XmlSerializer(typeof(tblVCard));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = System.Text.Encoding.UTF8;
            XmlWriter writer = XmlWriter.Create(contactFileNameXML, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            serializer.Serialize(writer, vCardLijst, namespaces);
            writer.Close();
            toolStripStatusLabel1.Text = "Contacten bewaard";
        }

        #region CopyVCardListToLocal
        private void CopyLocalToVCardList()
        {
            foreach (VCard2 vc2 in objVCardList)
            {
                vCardLijst.Add(CopyVCard2(vc2));
            }
        }
        public VCard CopyVCard2(VCard2 vc2)
        {
            VCard contact = (VCard)vc2.Tag;
            contact.Voornaam = vc2.Voornaam;
            contact.Achternaam = vc2.Achternaam;
            contact.Tussenvoegsel = vc2.Tussen;

            contact.emailLijst = new List<EmailAddressClass>();
            contact.telefoonNummerLijst = new List<TelephoneNumberClass>();
            contact.adresLijst = new List<AddressClass>();

            if (contact.adresLijst.Count == 0)
                contact.adresLijst.Add(new AddressClass());

            contact.adresLijst[0].Adres = vc2.Adres;
            contact.adresLijst[0].Woonplaats = vc2.Woonplaats;
            contact.adresLijst[0].Postcode = vc2.Postcode;

            if (vc2.TelThuis != string.Empty)
                contact.telefoonNummerLijst.Add(new TelephoneNumberClass("HOME", vc2.TelThuis.Trim(), true));
            if (vc2.Mobiel1 != string.Empty)
                contact.telefoonNummerLijst.Add(new TelephoneNumberClass("CELL", vc2.Mobiel1.Trim(), true));
            if (vc2.Mobiel2 != string.Empty)
                contact.telefoonNummerLijst.Add(new TelephoneNumberClass("CELL", vc2.Mobiel2.Trim(), false));
            if (vc2.TelWerk != string.Empty)
                contact.telefoonNummerLijst.Add(new TelephoneNumberClass("WORK", vc2.TelWerk.Trim(), false));

            if (vc2.Email1 != string.Empty)
                contact.emailLijst.Add(new EmailAddressClass(vc2.Email1.Trim()));
            if (vc2.Email2 != string.Empty)
                contact.emailLijst.Add(new EmailAddressClass(vc2.Email2.Trim()));

            contact.Note = vc2.Notitie;
            contact.Organisatie = vc2.Organisatie;
            contact.Title = vc2.Titel;
            contact.Leden = vc2.Lid;
            return contact;
        }
        #endregion
        
        #region ImportVCard
        private void cmdImportVCard_Click(object sender, EventArgs e)
        {
            tblVCard temp = Import();
            if (temp == null) return;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                vCardLijst = temp;
            }
            else
            {
                vCardLijst.AddRange(temp);
            }
            OntdubbelvCardLijst();
            objVCardList.Clear();
            CopyVCardListToLocal();
            olvVCard.SetObjects(objVCardList);
        }
        #endregion

        #region export Vcards
        private void cmdExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                #region Create CSV op Naam
                vCardLijst = new tblVCard();
                CopyLocalToVCardList();

                StreamWriter vcardWriter = new StreamWriter(txtOutputLocation.Text + @"\" + param.ClubNameShort + "_VCard_" + DateTime.Now.ToString("yyyyMMdd") + ".vcf");

                foreach (VCard vCard in vCardLijst)
                    vcardWriter.WriteLine(WriteLid(vCard));

                vcardWriter.Flush();
                vcardWriter.Close();

                #endregion

            }
            catch (Exception ex)
            {
                GuiRoutines.ExceptionMessageBox(this, ex);
            }

            Cursor = Cursors.Arrow;
            //            MessageBox.Show("VCards (" + aantal.ToString() + ") aangemaakt in " + txtOutputLocation.Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripStatusLabel1.Text = "VCards aangemaakt in " + txtOutputLocation.Text;
        }


        #region Write vCardLid

        private string WriteLid(VCard vCard)
        {
            StringBuilder lidregel = new StringBuilder();

            lidregel.AppendLine("BEGIN:VCARD");
            lidregel.AppendLine("VERSION:2.1");
            lidregel.AppendLine("N:" + vCard.Achternaam + ";" + vCard.Voornaam + ";" + vCard.Tussenvoegsel + ";;");
            lidregel.AppendLine("FN:" + vCard.NetteNaam);

            foreach (AddressClass adres in vCard.adresLijst)
            {
                if (adres.Adres.Trim() == string.Empty) continue;
                lidregel.AppendLine("ADR;HOME:;;" + adres.Adres + ";" + adres.Woonplaats + ";;" + adres.Postcode + ";");
            }
            foreach (TelephoneNumberClass telefoon in vCard.telefoonNummerLijst)
            {
                if (telefoon.TelephoneNumber.Trim() == string.Empty) continue;
                lidregel.Append("TEL");
                if (telefoon.Type.Trim() != string.Empty)
                    lidregel.Append(";" + telefoon.Type);
                if (telefoon.Preference)
                    lidregel.Append(";PREF");
                lidregel.AppendLine(":" + telefoon.TelephoneNumber.Replace("-", ""));
            }

            foreach (EmailAddressClass email in vCard.emailLijst)
            {
                if (email.EmailAddress.Trim() == string.Empty) continue;
                lidregel.Append("EMAIL");
                if (email.Type.Trim() != string.Empty)
                    lidregel.Append(";" + email.Type);
                if (email.Preference)
                    lidregel.Append(";PREF");
                lidregel.AppendLine(":" + email.EmailAddress);
            }

            if (vCard.GeboorteDatum.Trim() != string.Empty)
                lidregel.AppendLine("BDAY:" + vCard.GeboorteDatum);
            if (vCard.Organisatie.Trim() != string.Empty)
                lidregel.AppendLine("ORG: " + vCard.Organisatie);
            if (vCard.Note.Trim() != string.Empty)
                lidregel.AppendLine("NOTE: " + vCard.Note);
            if (vCard.Title.Trim() != string.Empty)
                lidregel.AppendLine("TITLE: " + vCard.Title);
            lidregel.Append("END:VCARD");

            return lidregel.ToString();
        }


        #endregion

        private void frmExportLijsten_FormClosing(object sender, FormClosingEventArgs e)
        {

            // Create a XmlWriter to write with.
            XmlSerializer serializer = new XmlSerializer(typeof(tblVCard));
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = System.Text.Encoding.UTF8;
            XmlWriter writer = XmlWriter.Create(contactFileNameXML, settings);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");
            serializer.Serialize(writer, vCardLijst, namespaces);
            writer.Close();

            PersistControlValue.StoreControlValue(txtOutputLocation);
        }
        #endregion

        #region Import Leden
        private void cmdImportLeden_Click(object sender, EventArgs e)
        {
            bool onlyMarked = false;
            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                onlyMarked = true;
            }

            int aantal = 0;
            foreach (tblLid lid in leden)
            {
                if (lid.Opgezegd) continue;
                if (onlyMarked && !lid.Gemerkt) continue;
                VCard contact = new VCard();
                vCardLijst.Add(contact);
                aantal++;
                contact.Achternaam = lid.Achternaam;
                contact.Voornaam = lid.Voornaam;
                contact.Tussenvoegsel = lid.Tussenvoegsel;
                contact.Leden = true;

                if (lid.Telefoon.Trim() != string.Empty)
                    contact.telefoonNummerLijst.Add(new TelephoneNumberClass("HOME", lid.Telefoon, false));
                if (lid.Mobiel.Trim() != string.Empty)
                    contact.telefoonNummerLijst.Add(new TelephoneNumberClass("CELL", lid.Mobiel, true));

                if (lid.Email1.Trim() != string.Empty)
                    contact.emailLijst.Add(new EmailAddressClass(lid.Email1));
                if (lid.Email2.Trim() != string.Empty)
                    contact.emailLijst.Add(new EmailAddressClass(lid.Email2));

                contact.adresLijst.Add(new AddressClass(lid.Adres, lid.Postcode, lid.Woonplaats));

                contact.GeboorteDatum = lid.GeboorteDatum.ToString("yyyyMMdd");

                contact.Organisatie = "TTVN";
                if (lid.BondsNr.Trim() != string.Empty)
                    contact.Note = "Bondsnummer: " + lid.BondsNr;

                if (lid.Ouder1_Naam.Trim() != string.Empty || lid.Ouder1_Telefoon.Trim() != string.Empty ||
                    lid.Ouder1_Mobiel.Trim() != string.Empty || lid.Ouder1_Email1.Trim() != string.Empty)
                {
                    contact = new VCard();
                    vCardLijst.Add(contact);
                    aantal++;

                    contact.Achternaam = "- Ouder " + lid.Ouder1_Naam;
                    contact.Voornaam = lid.NetteNaam;

                    if (lid.Ouder1_Telefoon.Trim() != string.Empty)
                        contact.telefoonNummerLijst.Add(new TelephoneNumberClass("HOME", lid.Ouder1_Telefoon, false));
                    if (lid.Ouder1_Mobiel.Trim() != string.Empty)
                        contact.telefoonNummerLijst.Add(new TelephoneNumberClass("CELL", lid.Ouder1_Mobiel, true));
                    if (lid.Ouder1_Email1.Trim() != string.Empty)
                        contact.emailLijst.Add(new EmailAddressClass(lid.Ouder1_Email1));
                    if (lid.Ouder1_Email2.Trim() != string.Empty)
                        contact.emailLijst.Add(new EmailAddressClass(lid.Ouder1_Email2));
                    contact.Organisatie = "TTVN";
                    contact.Note = contact.NetteNaam;
                    contact.Leden = true;
                }

                if (lid.Ouder2_Naam.Trim() != string.Empty || lid.Ouder2_Telefoon.Trim() != string.Empty ||
                    lid.Ouder2_Mobiel.Trim() != string.Empty || lid.Ouder2_Email1.Trim() != string.Empty)
                {
                    contact = new VCard();
                    vCardLijst.Add(contact);
                    aantal++;

                    contact.Achternaam = "- Ouder " + lid.Ouder2_Naam;
                    contact.Voornaam = lid.NetteNaam;

                    if (lid.Ouder2_Telefoon.Trim() != string.Empty)
                        contact.telefoonNummerLijst.Add(new TelephoneNumberClass("HOME", lid.Ouder2_Telefoon, false));
                    if (lid.Ouder2_Mobiel.Trim() != string.Empty)
                        contact.telefoonNummerLijst.Add(new TelephoneNumberClass("CELL", lid.Ouder2_Mobiel, true));
                    if (lid.Ouder2_Email1.Trim() != string.Empty)
                        contact.emailLijst.Add(new EmailAddressClass(lid.Ouder2_Email1));
                    if (lid.Ouder2_Email2.Trim() != string.Empty)
                        contact.emailLijst.Add(new EmailAddressClass(lid.Ouder2_Email2));
                    contact.Organisatie = "TTVN";
                }

            }
            OntdubbelvCardLijst();
            objVCardList.Clear();
            CopyVCardListToLocal();
            olvVCard.SetObjects(objVCardList);

            toolStripStatusLabel1.Text = "Ledencontacten toegevoegd (" + aantal.ToString() + ")";
        }



        private tblVCard Import()
        {
            tblVCard newVCardLijst = new tblVCard();
            int aantal = 0;
            string filename = Util.Forms.GuiRoutines.GetOpenFileName(openFileDialog1, "vcf");

            if (filename == string.Empty) return null;
            try
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string line = string.Empty;
                    string prefix = string.Empty;
                    VCard vCard = null;
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();

                        prefix = "BEGIN:VCARD";
                        if (line.StartsWith(prefix))
                        {
                            vCard = new VCard();
                            newVCardLijst.Add(vCard);
                            aantal++;
                        }
                        prefix = "N:";
                        if (line.StartsWith(prefix))
                        {
                            line = line.Replace(prefix, string.Empty);
                            string[] naamdelen = line.Split(new char[] { ';' });
                            if (naamdelen[0] != null) { vCard.Achternaam = naamdelen[0]; }
                            if (naamdelen[1] != null) { vCard.Voornaam = naamdelen[1]; }
                            if (naamdelen[2] != null) { vCard.Tussenvoegsel = naamdelen[2]; }
                        }
                        prefix = "N;";
                        if (line.StartsWith(prefix))
                            vCard.Achternaam = "Onbekend";

                        //prefix = "FN:";
                        //if (line.StartsWith(prefix))
                        //{
                        //    vCard.NetteNaam = line.Replace(prefix, string.Empty);
                        //}

                        prefix = "ORG:";
                        if (line.StartsWith(prefix))
                        {
                            vCard.Organisatie = line.Replace(prefix, string.Empty);
                        }

                        prefix = "BDAY:";
                        if (line.StartsWith(prefix))
                        {
                            vCard.GeboorteDatum = line.Replace(prefix, string.Empty);
                        }

                        prefix = "NOTE:";
                        if (line.StartsWith(prefix))
                        {
                            vCard.Note = line.Replace(prefix, string.Empty);
                        }

                        prefix = "TITLE:";
                        if (line.StartsWith(prefix))
                        {
                            vCard.Title = line.Replace(prefix, string.Empty);
                        }

                        prefix = "ADR";
                        if (line.StartsWith(prefix))
                        {
                            line = line.Replace(prefix, string.Empty);

                            if (line.StartsWith(";HOME"))
                                vCard.adresLijst.Add(ExtractAddress("HOME", line));
                            if (line.StartsWith(";WORK"))
                                vCard.adresLijst.Add(ExtractAddress("WORK", line));
                            if (line.StartsWith(";PREF"))
                                vCard.adresLijst.Add(ExtractAddress("", line));
                            if (line.StartsWith(":"))
                                vCard.adresLijst.Add(ExtractAddress("", line));
                        }

                        prefix = "TEL";
                        if (line.StartsWith(prefix))
                        {
                            //Console.WriteLine(line);
                            line = line.Replace(prefix, string.Empty);

                            if (line.StartsWith(";HOME"))
                                vCard.telefoonNummerLijst.Add(ExtractTelephoneNumber("HOME", line));
                            if (line.StartsWith(";WORK"))
                                vCard.telefoonNummerLijst.Add(ExtractTelephoneNumber("WORK", line));
                            if (line.StartsWith(";CELL"))
                                vCard.telefoonNummerLijst.Add(ExtractTelephoneNumber("CELL", line));
                            if (line.StartsWith(";PREF"))
                                vCard.telefoonNummerLijst.Add(ExtractTelephoneNumber("", line));
                            if (line.StartsWith(":"))
                                vCard.telefoonNummerLijst.Add(ExtractTelephoneNumber("", line));
                        }

                        prefix = "EMAIL";
                        if (line.StartsWith(prefix))
                        {
                            line = line.Replace(prefix, string.Empty);

                            if (line.StartsWith(";HOME"))
                                vCard.emailLijst.Add(ExtractEmailAddress("HOME", line));
                            if (line.StartsWith(";WORK"))
                                vCard.emailLijst.Add(ExtractEmailAddress("WORK", line));
                            if (line.StartsWith(":"))
                                vCard.emailLijst.Add(ExtractEmailAddress("", line));
                            if (line.StartsWith(";PREF"))
                                vCard.emailLijst.Add(ExtractEmailAddress("", line));
                        }
                    }
                }
                toolStripStatusLabel1.Text = "VCards ingelezen (" + aantal.ToString() + ")";
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return newVCardLijst;
        }
        #endregion

        #region Extract paragrafen
        private AddressClass ExtractAddress(string p, string line)
        {
            AddressClass tc = new AddressClass();
            try
            {
                tc.Type = p;
                string[] delen = line.Split(new char[] { ';' });
                if (delen.Length >= 7)
                {
                    if (delen[3] != null) { tc.Adres = delen[3]; }
                    if (delen[4] != null) { tc.Woonplaats = delen[4]; }
                    if (delen[6] != null) { tc.Postcode = delen[6]; }
                }
            }
            catch { }
            return tc;
        }

        private TelephoneNumberClass ExtractTelephoneNumber(string p, string line)
        {
            TelephoneNumberClass tc = new TelephoneNumberClass();
            tc.TelephoneNumber = line.Substring(line.IndexOf(':') + 1);
            tc.AddCountryCode();

            if (p.Trim() != string.Empty)
                tc.Type = p;
            else
                if (tc.TelephoneNumber.StartsWith("+316"))
                    tc.Type = "CELL";
                else
                    tc.Type = "HOME";


            if (line.Contains("PREF"))
                tc.Preference = true;
            return tc;
        }


        private EmailAddressClass ExtractEmailAddress(string p, string line)
        {
            EmailAddressClass tc = new EmailAddressClass();
            tc.Type = p;
            tc.EmailAddress = line.Substring(line.IndexOf(':') + 1);
            if (line.Contains("PREF"))
                tc.Preference = true;
            return tc;
        }
        #endregion

        #region Filter
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            this.Filter(olvVCard, txtFilter.Text, 0);
        }
        void Filter(FastObjectListView olv, string txt, int matchKind)
        {
            //olv.OwnerDraw = true;
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
            new frmPrintObjectListView(olvVCard, "Telefoon Contacten").ShowDialog();
            this.Cursor = Cursors.Arrow; ;
        }
    }

    #region VCard2
    public class VCard2
    {
        public VCard2()
        {
            _Achternaam = "Nieuw Contact";
            _Tussen = string.Empty;
            _Titel = string.Empty;
            _Organisatie = string.Empty;
            _TelThuis = string.Empty;
            _Mobiel1 = string.Empty;
            _Mobiel2 = string.Empty;
            _TelWerk = string.Empty;
            _Email1 = string.Empty;
            _Email2 = string.Empty;
            _Adres = string.Empty;
            _Postcode = string.Empty;
            _Woonplaats = string.Empty;
            _Notitie = string.Empty;
            _Lid = false;
            _Tag = new VCard();
        }


        #region NAW gegevens

        private string _Achternaam;
        /// <summary>Get or Set Achternaam value</summary>
        public string Achternaam
        {
            get { return _Achternaam; }
            set { _Achternaam = value; }
        }

        private string _Voornaam;
	    public string Voornaam
	    {
		    get { return _Voornaam;}
		    set { _Voornaam = value;}
	    }

        private string _Tussen;
	    public string Tussen
	    {
		    get { return _Tussen;}
		    set { _Tussen = value;}
	    }

        private string _Titel;
	    public string Titel
	    {
		    get { return _Titel;}
		    set { _Titel = value;}
	    }
        private string _Organisatie;
	    public string Organisatie
	    {
		    get { return _Organisatie;}
		    set { _Organisatie = value;}
	    }
        private string _TelThuis;
	    public string TelThuis
	    {
		    get { return _TelThuis;}
		    set { _TelThuis = value;}
	    }
        private string _Mobiel1;
	    public string Mobiel1
	    {
		    get { return _Mobiel1;}
		    set { _Mobiel1 = value;}
	    }

        private string _Mobiel2;
	    public string Mobiel2
	    {
		    get { return _Mobiel2;}
		    set { _Mobiel2 = value;}
	    }
        private string _TelWerk;
	    public string TelWerk
	    {
		    get { return _TelWerk;}
		    set { _TelWerk = value;}
	    }
        private string _Email1;
	    public string Email1
	    {
		    get { return _Email1;}
		    set { _Email1 = value;}
	    }
        private string _Email2;
	    public string Email2
	    {
		    get { return _Email2;}
		    set { _Email2 = value;}
	    }

        private string _Adres;
	    public string Adres
	    {
		    get { return _Adres;}
		    set { _Adres = value;}
	    }
        private string _Postcode;
	    public string Postcode
	    {
		    get { return _Postcode;}
		    set { _Postcode = value;}
	    }
        private string _Woonplaats;
	    public string Woonplaats
	    {
		    get { return _Woonplaats;}
		    set { _Woonplaats = value;}
	    }

        private string _Notitie;
	    public string Notitie
	    {
		    get { return _Notitie;}
		    set { _Notitie = value;}
	    }
        private bool _Lid;
	    public bool Lid
	    {
		    get { return _Lid;}
		    set { _Lid = (bool)value;}
	    }
        private object _Tag;
        public object Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }




        //        Voornaam
        //Tussen
        //Titel
        //Organisatie
        //TelThuis
        //Mobiel1
        //Mobiel2
        //TelWerk
        //Email1
        //Email2
        //Adres
        //Postcode
        //Woonplaats
        //Notitie
        //Lid


        #endregion
    }
    #endregion
}
