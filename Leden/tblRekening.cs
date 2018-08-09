using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Util.Text;
using Util.Forms;
using System.Text;
using Newtonsoft.Json;
using Util.MySQL;
using Util.Extensions;

namespace Leden.Net
{
    [Serializable]
    [XmlRoot("RekeningenLijst")]
    public class RekeningenLijst : List<tblRekening>
    {
        public RekeningenLijst() { }
        /// <summary>
        /// Get rekening by Lidnr and Seqnr
        /// </summary>
        /// <param name="LidNr"></param>
        /// <param name="SeqNr"></param>
        /// <returns>tblRekening</returns>
        public tblRekening GetRekeningLidNrAndRekSeqNr(int LidNr, int SeqNr)
        {
            // Wederom een sterk stukje LINQ programmeerwerk
            return (from rekening in this where rekening.LidNr == LidNr && rekening.RekeningSeqNr == SeqNr select rekening).FirstOrDefault();
        }

        public RekeningenLijst GetRekeningenbyLidnr(int LidNr)
        {
            List<tblRekening> objects = (from r in this where r.LidNr == LidNr && !r.Verstuurd select r).ToList();
            // Hoe zou je dit netjes kunnen doen?
            RekeningenLijst x = new RekeningenLijst();
            x.AddRange(objects);
            return x;
        }
    }


    /// <summary>Class holding tblLid fields</summary>
    [Serializable]
    [XmlType("Rekening")]
    public class tblRekening
    {
        public static string[] RekeningTypeDescriptions = { "Contributie", "Inschrijfgeld", "Overig" };

        public tblRekening()
        {
            _LidNr = 0;
            _RekeningSeqNr = 0;
            _Omschrijving = string.Empty;
            _TypeRekening = 0;
            _TotaalBedrag = 0;
            _IBAN = string.Empty;
            _BIC = string.Empty;
            _AanmaakDatum = DateTime.Now;
            _VerstuurdDatum = new DateTime(1900, 1, 1);
            _Verstuurd = false;
            _PeilDatum = DateTime.Now;
            _CompetitieBijdrage =0;
            _ContributieBedrag = 0;
            _Bondsbijdrage = 0;
            _ExtraBedrag = 0;
            _Korting = 0;
            _Gestorneerd = false;
            _KostenStornering = 0;
            _MailOnderdrukken = false;
            _BedragKortingVrijwilliger = 0;
            _ExtraA = string.Empty;

            _Lid = new tblLid();
        }

        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        private int _RekeningSeqNr;
        /// <summary>Get RekeningSeqNr</summary>
        public int RekeningSeqNr
        {
            get { return _RekeningSeqNr; }
            set { _RekeningSeqNr = value; Dirty = true; }
        }

        private int _LidNr;
		/// <summary>Get or Set LidNrvalue</summary>
		public int LidNr
		{
			get { return _LidNr; }
			set { _LidNr= value; Dirty = true; }
		}

        private tblLid _Lid;
        [XmlIgnore]
        public tblLid Lid
        {
            get { return _Lid;}
            set { _Lid = value; Dirty = true; }
        }

		private string _IBAN ;
		/// <summary>Get or Set IBAN value</summary>
		public string IBAN 
		{
			get { return _IBAN ; }
			set { _IBAN = value; Dirty = true; }
		}

		private string _BIC ;
		/// <summary>Get or Set BIC value</summary>
		public string BIC 
		{
			get { return _BIC ; }
			set { _BIC = value; Dirty = true; }
		}

        private decimal _TotaalBedrag;
        /// <summary>Get or Set Totaalbedragvalue</summary>
        public decimal TotaalBedrag
        {
            get { return _TotaalBedrag; }
            set { _TotaalBedrag = value; Dirty = true; }
        }

        private decimal _ContributieBedrag;
        /// <summary>Get or Set ContributieBedragvalue</summary>
        public decimal ContributieBedrag
        {
            get { return _ContributieBedrag; }
            set { _ContributieBedrag = value; Dirty = true; }
        }

        private decimal _Bondsbijdrage;
        /// <summary>Get or Set Bondsbijdragevalue</summary>
        public decimal Bondsbijdrage
        {
            get { return _Bondsbijdrage; }
            set { _Bondsbijdrage = value; Dirty = true; }
        }

        private decimal _Korting;
        /// <summary>Get or Set Bondsbijdragevalue</summary>
        public decimal Korting
        {
            get { return _Korting; }
            set { _Korting = value; Dirty = true; }
        }

        private decimal _CompetitieBijdrage;
        /// <summary>Get or Set CompetitieBijdragevalue</summary>
        public decimal CompetitieBijdrage
        {
            get { return _CompetitieBijdrage; }
            set { _CompetitieBijdrage = value; Dirty = true; }
        }

        private decimal _ExtraBedrag;
        /// <summary>Get or Set _ExtraBedrag</summary>
        public decimal ExtraBedrag
        {
            get { return _ExtraBedrag; }
            set { _ExtraBedrag = value; Dirty = true; }
        }

        private int _TypeRekening;
        /// <summary>Get or Set TypeRekeningvalue
        /// (0 = Incasso)
        /// (1 = Inschrijfgeld)
        /// (2 = Overig)
        /// </summary>
        public int TypeRekening
        {
            get { return _TypeRekening; }
            set { _TypeRekening = value; Dirty = true; }
        }
        /// <summary>
        /// Is het een rekening voor Inschrijgeld
        /// </summary>
        public bool IsContributie
        {
            get { return _TypeRekening == 0; }
            set { _TypeRekening = 0; Dirty = true; }
        }

        /// <summary>
        /// Is het een rekening voor Inschrijgeld
        /// </summary>
        public bool IsInschrijfgeld
        {
            get { return _TypeRekening == 1; }
            set { _TypeRekening = 1; Dirty = true; }
        }

        /// <summary>
        /// Is het een rekening voor Overig
        /// </summary>
        public bool IsOverig
        {
            get { return _TypeRekening == 2; }
            set { _TypeRekening = 2; Dirty = true; }
        }

        private string _Omschrijving;
        /// <summary>Get or Set Omschrijvingvalue</summary>
        public string Omschrijving
        {
            get { return _Omschrijving; }
            set { _Omschrijving = value; Dirty = true; }
        }
        
        private DateTime _AanmaakDatum;
        /// <summary>Get or Set AanmaakDatumvalue</summary>
        public DateTime AanmaakDatum
        {
            get { return _AanmaakDatum; }
            set { _AanmaakDatum = value; Dirty = true; }
        }

        private DateTime _PeilDatum;
        /// <summary>Get or Set AanmaakDatumvalue</summary>
        public DateTime PeilDatum
        {
            get { return _PeilDatum; }
            set { _PeilDatum = value; Dirty = true; }
        }

        private DateTime _VerstuurdDatum;
        /// <summary>Get or Set VerstuurdDatevalue</summary>
        public DateTime VerstuurdDatum
        {
            get { return _VerstuurdDatum; }
            set { _VerstuurdDatum = value; Dirty = true; }
        }
        
        private bool _Verstuurd;
        /// <summary>Get or Set Verstuurdvalue</summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Verstuurd
        {
            get { return _Verstuurd; }
            set { _Verstuurd = value; Dirty = true; }
        }

        private bool _Gestorneerd;
        /// <summary>Get or Set Gestorneerd</summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool Gestorneerd
        {
            get { return _Gestorneerd; }
            set { _Gestorneerd = value; Dirty = true; }
        }

        private decimal _KostenStornering;
        /// <summary>Get or Set KostenStornering</summary>
        public decimal KostenStornering
        {
            get { return _KostenStornering; }
            set { _KostenStornering = value; Dirty = true; }
        }

        private bool _MailOnderdrukken;
        /// <summary>Get or Set MailOnderdrukken</summary>
        [JsonConverter(typeof(BoolConverter))]
        public bool MailOnderdrukken
        {
            get { return _MailOnderdrukken; }
            set { _MailOnderdrukken = value; Dirty = true; }
        }

        private decimal _BedragKortingVrijwilliger;
        /// <summary>Get or Set BedragTaakAfkoop</summary>
        public decimal BedragKortingVrijwilliger
        {
            get { return _BedragKortingVrijwilliger; }
            set { _BedragKortingVrijwilliger = value; Dirty = true; }
        }
        private string _ExtraA;
        /// <summary>Get or Set _ExtraA</summary>
        public string ExtraA
        {
            get { return _ExtraA; }
            set { _ExtraA = value; Dirty = true; }
        }

        public static tblRekening CreateRekeningRecord(tblLid lid, RekeningenLijst rekeningen)
        {
            tblRekening rekening = new tblRekening();
            try
            {
                for (int i = 0; i < rekeningen.Count; i++)
                {
                    if (rekeningen[i].RekeningSeqNr > rekening.RekeningSeqNr &&
                        rekeningen[i].LidNr == lid.LidNr)
                        rekening.RekeningSeqNr = rekeningen[i].RekeningSeqNr;
                }
                rekening.RekeningSeqNr++;
                rekening.Lid = lid;
                rekening.LidNr = lid.LidNr;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return rekening;
        }
        /// <summary>
        /// Deze string wordt gebruikt in de url van de call naar het PHP . Dit script gebruikt deze params 
        /// </summary>
        /// <returns></returns>
        public string CreatePHPUrlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&LidNr=" + _LidNr);
    		sb.Append("&RekeningSeqNr=" + _RekeningSeqNr);	
    		sb.Append("&Omschrijving=" + _Omschrijving);
    		sb.Append("&TypeRekening=" + _TypeRekening);
    		sb.Append("&TotaalBedrag=" + _TotaalBedrag.ToXMLString()); 
    		sb.Append("&IBAN=" + _IBAN);
    		sb.Append("&BIC=" + _BIC);
            sb.Append("&AanmaakDatum=" + _AanmaakDatum.ToString("yyyy-MM-dd"));
            sb.Append("&VerstuurdDatum=" + _VerstuurdDatum.ToString("yyyy-MM-dd"));
    		sb.Append("&Verstuurd=" + (_Verstuurd ? "1" : "0"));
            sb.Append("&PeilDatum=" + _PeilDatum.ToString("yyyy-MM-dd"));
            sb.Append("&CompetitieBijdrage=" + _CompetitieBijdrage.ToXMLString());
            sb.Append("&ContributieBedrag=" + _ContributieBedrag.ToXMLString());
            sb.Append("&Bondsbijdrage=" + _Bondsbijdrage.ToXMLString());
            sb.Append("&ExtraBedrag=" + _ExtraBedrag.ToXMLString());
            sb.Append("&Korting=" + _Korting.ToXMLString());
    		sb.Append("&Gestorneerd=" + (_Gestorneerd ? "1" : "0"));
    		sb.Append("&KostenStornering=" + _KostenStornering.ToXMLString());
    		sb.Append("&MailOnderdrukken=" + (_MailOnderdrukken ? "1" : "0"));
    		sb.Append("&BedragKortingVrijwilliger=" + _BedragKortingVrijwilliger.ToXMLString()); 
    		sb.Append("&Extra1=" + "01");
    		sb.Append("&Extra2=" + "02");
    		sb.Append("&Extra3=" + "03");
    		sb.Append("&ExtraA=" + _ExtraA);
    		sb.Append("&ExtraB=" + "_ExtraB");
    		sb.Append("&ExtraC=" + "_ExtraC");
            return sb.ToString();
        }
    }

    public class MySQLIncassoResponse
    {
        public int success { get; set; }
        public string message { get; set; }
        public RekeningenLijst posts { get; set; }
    }
}