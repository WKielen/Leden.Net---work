using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Util.Text;
using Util.Forms;
using Util.Extensions;
using System.Text;
using Newtonsoft.Json;
using Util.MySQL;
namespace Leden.Net
{
    [Serializable]
    [XmlRoot("BetalingenLijst")]
    public class BetalingenLijst : List<tblBetaling>
    {
        public BetalingenLijst() { }
    }

    /// <summary>Class holding tblLid fields</summary>
    [Serializable]
    [XmlType("Betaling")]
    public class tblBetaling
    {
        public static string[] BetalingTypeDescriptions = {  "Overig" };
        // Een parameterloze contructor is nodig om te kunnen "serializen"
        public tblBetaling() { }

        public tblBetaling(BetalingenLijst Betalingen)
        {
            try
            {
                for (int i = 0; i < Betalingen.Count; i++)
                {
                    if (Betalingen[i].BetalingsSeqNr > _BetalingsSeqNr)
                        _BetalingsSeqNr = Betalingen[i].BetalingsSeqNr;
                }
                _BetalingsSeqNr++;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }

            _IBAN_Creditor = string.Empty;
            _BIC_Creditor = string.Empty;
            _Omschrijving = string.Empty;
            _EndToEndId = string.Empty;
            _TotaalBedrag = 0;
            _TypeBetaling = 0;
            _AanmaakDatum = DateTime.Now;
            _Verstuurd = false;
            _VerstuurdDatum = DateTime.Now;
            _GewensteVerwerkingsDatum = DateTime.Now;
            _Extra1 = 0;
            _Extra2 = 0;
            _Extra3 = 0;
            _Crediteur = string.Empty;
            _ExtraB = string.Empty;
            _ExtraC = string.Empty;

            _isDirty = true;
            Betalingen.Add(this);
        }

        /// <summary>Get or Set the Dirty flag</summary>
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        private bool _isDirty;

        /// <summary>Get BetalingSeqNr</summary>
        public int BetalingsSeqNr
        {
            get { return _BetalingsSeqNr; }
            set { _BetalingsSeqNr = value; Dirty = true; }
        }
        private int _BetalingsSeqNr;


		/// <summary>Get or Set IBAN value</summary>
        public string IBAN_Creditor 
		{
            get { return _IBAN_Creditor; }
            set { _IBAN_Creditor = value; Dirty = true; }
		}
		private string _IBAN_Creditor;

		/// <summary>Get or Set BIC value</summary>
		public string BIC_Creditor
		{
            get { return _BIC_Creditor; }
            set { _BIC_Creditor = value; Dirty = true; }
		}
        private string _BIC_Creditor;

        /// <summary>Get or Set Totaalbedragvalue</summary>
        public decimal TotaalBedrag
        {
            get { return _TotaalBedrag; }
            set { _TotaalBedrag = value; Dirty = true; }
        }
        private decimal _TotaalBedrag;

        /// <summary>Get or Set TypeBetalingvalue
        /// (0 = Overig)
        /// </summary>
        public int TypeBetaling
        {
            get { return _TypeBetaling; }
            set { _TypeBetaling = value; Dirty = true; }
        }
        private int _TypeBetaling;
  
        /// <summary>
        /// Is het een Betaling voor Overig
        /// </summary>
        public bool IsOverig
        {
            get { return _TypeBetaling == 0; }
            set { _TypeBetaling = 0; Dirty = true; }
        }

        /// <summary>Get or Set Omschrijvingvalue</summary>
        public string Omschrijving
        {
            get { return _Omschrijving; }
            set { _Omschrijving = value; Dirty = true; }
        }
        private string _Omschrijving;

        /// <summary>Get or Set End to End Id</summary>
        public string EndToEndId
        {
            get { return _EndToEndId; }
            set { _EndToEndId = value; Dirty = true; }
        }
        private string _EndToEndId;

        public string FormattedEndToEndId
        {
            get
            {
                if (String.IsNullOrEmpty(_EndToEndId)) return _EndToEndId;
                int chunkLength = 4;
                string myS = string.Empty;
                for (int i = 0; i < _EndToEndId.Length; i += chunkLength)
                {
                    if (chunkLength + i > _EndToEndId.Length)
                        chunkLength = _EndToEndId.Length - i;
                    myS += _EndToEndId.Substring(i, chunkLength) + ".";
                }
                return myS.Remove(myS.Length - 1);
            }
        }
        
        /// <summary>Get or Set AanmaakDatumvalue</summary>
        public DateTime AanmaakDatum
        {
            get { return _AanmaakDatum; }
            set { _AanmaakDatum = value; Dirty = true; }
        }
        private DateTime _AanmaakDatum;

        /// <summary>Get or Set VerstuurdDatevalue</summary>
        public DateTime VerstuurdDatum
        {
            get { return _VerstuurdDatum; }
            set { _VerstuurdDatum = value; Dirty = true; }
        }
        private DateTime _VerstuurdDatum;

        /// <summary>Get or Set GewensteVerwerkingsDatum</summary>
        public DateTime GewensteVerwerkingsDatum
        {
            get { return _GewensteVerwerkingsDatum; }
            set { _GewensteVerwerkingsDatum = value; Dirty = true; }
        }
        private DateTime _GewensteVerwerkingsDatum;
        
        /// <summary>Get or Set Verstuurdvalue</summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Verstuurd
        {
            get { return _Verstuurd; }
            set { _Verstuurd = value; Dirty = true; }
        }
        private bool _Verstuurd;

        /// <summary>Get or Set Crediteur</summary>
        public string Crediteur
        {
            get { return _Crediteur; }
            set { _Crediteur = value; Dirty = true; }
        }
        private string _Crediteur;

        /// <summary>Get or Set _ExtraC</summary>
        public string ExtraC
        {
            get { return _ExtraC; }
            set { _ExtraC = value; Dirty = true; }
        }
        private string _ExtraC;

        /// <summary>Get or Set _ExtraB</summary>
        public string ExtraB
        {
            get { return _ExtraB; }
            set { _ExtraB = value; Dirty = true; }
        }
        private string _ExtraB;

        /// <summary>Get or Set _ExtraA</summary>
        public string ExtraA
        {
            get { return _ExtraA; }
            set { _ExtraA = value; Dirty = true; }
        }
        private string _ExtraA;

        
        /// <summary>Get or Set _Extra1</summary>
        public int Extra1
        {
            get { return _Extra1; }
            set { _Extra1 = value; Dirty = true; }
        }
        private int _Extra1;

        /// <summary>Get or Set _Extra2</summary>
        public int Extra2
        {
            get { return _Extra2; }
            set { _Extra2 = value; Dirty = true; }
        }
        private int _Extra2;

        /// <summary>Get or Set _Extra3</summary>
        public int Extra3
        {
            get { return _Extra3; }
            set { _Extra3 = value; Dirty = true; }
        }
        private int _Extra3;


        /// <summary>
        /// Deze string wordt gebruikt in de url van de call naar het PHP . Dit script gebruikt deze params in een SQL statement
        /// </summary>
        /// <returns></returns>
        public string CreatePHPUrlString()
        {
            StringBuilder sb = new StringBuilder();

            //_BetalingsSeqNr             = _BetalingsSeqNr
            //_IBAN_Creditor              = _IBAN_Creditor
            //_BIC_Creditor               = 
            //_Omschrijving               = 
            //_EndToEndId                 = 
            //_TotaalBedrag               = 
            //_TypeBetaling               = 
            //_AanmaakDatum               = 
            //_Verstuurd                  = 
            //_VerstuurdDatum             = 
            //_GewensteVerwerkingsDatum   = 
            //_Crediteur                  = 
            //_Extra1                     = 
            //_Extra2                     = 
            //_Extra3                     = 
            //_ExtraA                     = 
            //_ExtraB                     = 
            //_ExtraC                     = 
            //_BetalingsSeqNr             = _BetalingsSeqNr
            //_IBAN_Creditor              = _IBAN_Creditor
            //_BIC_Creditor               = _BIC_Creditor
            //_Omschrijving               = _Omschrijving
            //_EndToEndId                 = _EndToEndId
            //_TotaalBedrag               = _TotaalBedrag
            //_TypeBetaling               = _TypeBetaling
            //_AanmaakDatum               = _AanmaakDatum
            //_Verstuurd                  = _Verstuurd
            //_VerstuurdDatum             = _VerstuurdDatum
            //_GewensteVerwerkingsDatum   = _GewensteVerwerkingsDatum
            //_Crediteur                  = _Crediteur




            sb.Append("&BetalingsSeqNr="              + _BetalingsSeqNr);
            sb.Append("&IBAN_Creditor="              + _IBAN_Creditor);
            sb.Append("&BIC_Creditor="               + _BIC_Creditor);
            sb.Append("&Omschrijving="               + _Omschrijving);
            sb.Append("&EndToEndId="                 + _EndToEndId);
            sb.Append("&TotaalBedrag="               + _TotaalBedrag.ToXMLString());
            sb.Append("&TypeBetaling="               + _TypeBetaling);
            sb.Append("&AanmaakDatum="               + _AanmaakDatum.ToString("yyyy-MM-dd"));
            sb.Append("&Verstuurd="                  + (_Verstuurd ? "1" : "0"));
            sb.Append("&VerstuurdDatum="             + _VerstuurdDatum.ToString("yyyy-MM-dd"));
            sb.Append("&GewensteVerwerkingsDatum="   + _GewensteVerwerkingsDatum.ToString("yyyy-MM-dd"));
            sb.Append("&Crediteur="                  + _Crediteur);
            sb.Append("&Extra1=" + "1");
            sb.Append("&Extra2=" + "2");
            sb.Append("&Extra3=" + "3");
            sb.Append("&ExtraA=" + "=_ExtraA");
            sb.Append("&ExtraB=" + "=_ExtraB");
            sb.Append("&ExtraC=" + "=_ExtraC");
            return sb.ToString();
        }






    //    public static tblBetaling CreateBetalingRecord(BetalingenLijst Betalingen)
    //    {
    //        tblBetaling Betaling = new tblBetaling();
    //        try
    //        {
    //            for (int i = 0; i < Betalingen.Count; i++)
    //            {
    //                if (Betalingen[i].BetalingsSeqNr > Betaling.BetalingsSeqNr)
    //                    Betaling.BetalingsSeqNr = Betalingen[i].BetalingsSeqNr;
    //            }
    //            Betaling.BetalingsSeqNr++;
    //        }
    //        catch (Exception ex)
    //        {
    //            GuiRoutines.ShowMessage(ex);
    //        }
    //        return Betaling;
    //    }
    }
    public class MySQLBetalingResponse
    {
        public int success { get; set; }
        public string message { get; set; }
        public BetalingenLijst posts { get; set; }
    }


    #region Sorteren BetalingenLijst
    //public class BetalingenComparer : IComparer<tblBetaling>
    //{
    //    private string _sortItem;

    //    public BetalingenComparer(string sortItem) { _sortItem = sortItem; }
    //    public BetalingenComparer() { }
    //    public int Compare(tblBetaling x, tblBetaling y)
    //    {
    //        try
    //        {
    //            if (x == null && y == null) return 0;
    //            if (x == null) return -1;
    //            if (y == null) return 1;

    //            switch (_sortItem)
    //            {
    //                case "GewensteDatum": return (x.GewensteVerwerkingsDatum > y.GewensteVerwerkingsDatum) ? 1 : -1;
    //                default: //Console.WriteLine(x.VolledigeNaam + " > " + y.VolledigeNaam);
    //                    return (x.AanmaakDatum > y.AanmaakDatum) ? 1 : -1;
    //            }
    //        }
    //        catch
    //        {
    //            return 0;
    //        }
    //    }
    //}
    #endregion
}