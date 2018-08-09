using System;
using System.Xml.Serialization;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Util.MySQL;
using Util.Extensions;

namespace Leden.Net
{
    [Serializable]
    [XmlRoot("LedenLijst")]
    public class LedenLijst : List<tblLid>//, ICloneable
    {
        public LedenLijst() { }
        public LedenLijst(tblLid lid) { this.Add(lid); }
        /// <summary>
        /// Get lid by Lidnr
        /// </summary>
        /// <param name="LidNr"></param>
        /// <returns>tblLid</returns>
        public tblLid GetLidByLidNr(int LidNr)
        {
            // Wederom een sterk stukje LINQ programmeerwerk
            return (from lid in this where lid.LidNr == LidNr select lid).FirstOrDefault();
        }
    }

    interface IPHPInterface { string CreatePHPUrlString();}

    /// <summary>Class holding tblLid fields</summary>
    [Serializable]
    [XmlType("Lid")]
    public class tblLid : Attribute, IPHPInterface//, ICloneable
    {
        #region Constants
        protected const string A = "A";
        protected const string Ouder1Gegevens = "Ouder1";
        protected const string Ouder2Gegevens = "Ouder2";
        protected const string LeeftijdGegevens = "Leeftijd";
        protected const string FinancieelGegevens = "Financieel";
        protected const string Overig = "B Overig";
        protected const string Extra = "zExtra";

        public const string constSenior1 = "SEN 1";
        public const string const65Plus = "65+";
        public const string constSenior = "SEN";
        public const string constJunior = "JUN";
        public const string constCadet = "CAD";
        public const string constPupil = "PUP";
        public const string constWelp = "WLP";

        public const string constWelpMin2 = "WLP -2";
        public const string constWelpMin1 = "WLP -1";
        public const string constWelp0 = "WLP 0";
        public const string constWelp1 = "WLP 1";
        public const string constWelp2 = "WLP 2";

        public static string constPupil1 = "PUP 1";
        public static string constPupil2 = "PUP 2";

        public const string constCadet1 = "CAD 1";
        public const string constCadet2 = "CAD 2";

        public const string constJunior1 = "JUN 1";
        public const string constJunior2 = "JUN 2";
        public const string constJunior3 = "JUN 3";

        public const string constLidNormaal = "N";
        public const string constLidZwerflid = "Z";
        public const string constLidContributieVrij = "V";
        public const string constLidPakket = "P";

        public static string[] LidTypeDescriptions = { "Normaal", "Zwerflid", "ContributieVrij", "Pakket" };
        public static string[] LidTypes = { "N", "Z", "V", "P" };

        public const string constBetwIncasso = "I";
        public const string constBetwRekening = "R";
        public const string constBetwUPas = "U";
        public const string constZelfBetaler = "Z";
        public static string[] BetaalWijzeDescriptions = { "Incasso", "Rekening", "U-Pas", "ZelfBetaler" };
        public static string[] BetaalWijzes = { constBetwIncasso, constBetwRekening, constBetwUPas, constZelfBetaler };
        #endregion

        public tblLid()
        {
            _LidNr = 0; 
            _Voornaam = string.Empty;
            _Achternaam = string.Empty;
            _Tussenvoegsel = string.Empty;
            _Adres = string.Empty;
            _Woonplaats = string.Empty;
            _Postcode = string.Empty;
            _Mobiel = string.Empty;
            _Telefoon = string.Empty;
            _BondsNr = string.Empty;
            _Geslacht = "M";
            _GeboorteDatum = new DateTime(1900,1,1);
            _Email1 = string.Empty;
            _Email2 = string.Empty;
            _IBAN = string.Empty;
            _BIC = string.Empty;
            _BetaalWijze = constBetwIncasso;
            _LidBond = false;
            _CompGerechtigd = false;
            _LidType = constLidNormaal;
            _LidVanaf = DateTime.Now;
            _Opgezegd = false;
            _LidTot = new DateTime(1900, 1, 1);
            _U_PasNr = string.Empty;
            _PakketTot = DateTime.Now.AddYears(1);
            _VastBedrag = 0;
            _Korting = 0;
            _Medisch = string.Empty; 
            _Gemerkt = false;
            _Ouder1_Naam = string.Empty;
            _Ouder1_Email1 = string.Empty;
            _Ouder1_Email2 = string.Empty;
            _Ouder1_Mobiel = string.Empty;
            _Ouder1_Telefoon = string.Empty;
            _Ouder2_Naam = string.Empty;
            _Ouder2_Email1 = string.Empty;
            _Ouder2_Email2 = string.Empty;
            _Ouder2_Mobiel = string.Empty;
            _Ouder2_Telefoon = string.Empty;
            _Geincasseerd = false;
            _ToernooiSpeler = 0;
            _VrijwillgersRegelingIsVanToepassing = false;
            _Rating = 0;
            _VrijwillgersVasteTaak = false;
            _VrijwillgersAfgekocht = false;
            _LicentieJun = string.Empty;
            _VrijwillgersToelichting = string.Empty;
            _LicentieSen = string.Empty;
            _ExtraD = string.Empty;
            _ExtraE = string.Empty;
            _Image = new byte[0];
        }

        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        private int _LidNr;
		/// <summary>Get or Set LidNrvalue</summary>
        [Category(A)]
        public int LidNr
		{
			get { return _LidNr; }
			set { _LidNr= value; Dirty = true; }
		}

        #region NAW gegevens
        private string _Voornaam;
		/// <summary>Get or Set Voornaamvalue</summary>
        [Category(A)]
        public string Voornaam
		{
		    get { return _Voornaam; }
            set { _Voornaam = value; Dirty = true; }
		}

        private string _Achternaam ;
		/// <summary>Get or Set Achternaam value</summary>
        [Category(A)]
        public string Achternaam 
		{
			get { return _Achternaam ; }
			set { _Achternaam = value; Dirty = true; }
		}
		
        private string _Tussenvoegsel ;
		/// <summary>Get or Set Tussenvoegsel value</summary>
        [Category(A)]
        public string Tussenvoegsel 
		{
			get { return _Tussenvoegsel ; }
			set { _Tussenvoegsel = value; Dirty = true; }
		}

        /// <summary>
        /// De naam in de vorm "lid.Achternaam, lid.Voornaam lid.Tussenvoegsel"  (GET ONLY)
        /// </summary>
        [Category(A)]
        [XmlIgnore]
        public string VolledigeNaam
        {
            get
            {
                string naam = _Achternaam.Trim() + ", " + _Voornaam.Trim();
                if (_Tussenvoegsel.Trim() != string.Empty)
                   naam +=  " " + _Tussenvoegsel.Trim();
                return naam;
            }
        }

        /// <summary>
        /// De naam in de vorm "lid.Voornaam lid.Tussenvoegsel lid.Achternaam  (GET ONLY)
        /// </summary>
        [Category(A)]
        [XmlIgnore]
        public string NetteNaam
        {
            get
            {
                string s = _Voornaam.Trim() + " ";
                if (_Tussenvoegsel.Trim() != string.Empty)
                {
                    s += _Tussenvoegsel.Trim();
                    s += " ";
                }
                return s + _Achternaam.Trim();
            }
        }

        private string _Adres;
		/// <summary>Get or Set Adres value</summary>
        [Category(A)]
        public string Adres 
		{
			get { return _Adres ; }
			set { _Adres = value; Dirty = true; }
		}

        private string _Woonplaats;
		/// <summary>Get or Set Woonplaats value</summary>
        [Category(A)]
        public string Woonplaats 
		{
			get { return _Woonplaats ; }
			set { _Woonplaats = value; Dirty = true; }
		}

        [Category(A)]
        private string _Postcode;
		/// <summary>Get or Set Postcode value</summary>
		public string Postcode 
		{
			get { return _Postcode ; }
			set { _Postcode = value; Dirty = true; }
		}
        #endregion

        private string _Mobiel ;
		/// <summary>Get or Set Mobiel value</summary>
        [Category(A)]
        public string Mobiel 
		{
			get { return _Mobiel ; }
			set { _Mobiel = value; Dirty = true; }
		}
		
        private string _Telefoon ;
		/// <summary>Get or Set Telefoon value</summary>
        [Category(A)]
        public string Telefoon 
		{
			get { return _Telefoon ; }
			set { _Telefoon = value; Dirty = true; }
		}

        [Category(A)]
        private string _Geslacht;
		/// <summary>Get or Set Geslacht value</summary>
		public string Geslacht 
		{
			get { return _Geslacht ; }
			set { _Geslacht = value; Dirty = true; }
		}

        #region Leeftijd
        private DateTime _GeboorteDatum;
        /// <summary>Get or Set GeboorteDatum value</summary>
        [Category(LeeftijdGegevens)]
        public DateTime GeboorteDatum
        {
            get { return _GeboorteDatum; }
            set { _GeboorteDatum = value; Dirty = true; }
        }

        [Category(LeeftijdGegevens)]
        [XmlIgnore]
        /// <summary>De leeftijd op huidige datum  (GET ONLY)</summary>
        public int Leeftijd
        {
            get { return DateRoutines.Age(_GeboorteDatum); }
        }

        /// <summary>
        /// Get extended age category value e.g. WLP -1, 0, 1, 2 --- JUN3, SEN 1, SEN, 65+  space included    (GET ONLY)
        /// </summary>
        /// <returns>65+ or SEN or SEN 1 or JUN 1,2,3 or CAD 1,2 or PUP 1,2 or WLP 2,1,0,-1,-2</returns>
        [Category(LeeftijdGegevens)]
        [XmlIgnore]
        public string LeeftijdCategorieLong
        {
            get { return DateRoutines.LeeftijdCategorieBond(_GeboorteDatum, true); }
        }

        /// <summary>
        /// Get age category value e.g. WLP, PUP, CAD, JUN, SEN
        /// </summary>
        /// <returns>SEN or JUN or CAD or PUP or WLP</returns>
        [Category(LeeftijdGegevens)]
        [XmlIgnore]
        public string LeeftijdCategorie
        {
            get { return DateRoutines.LeeftijdCategorieBond(_GeboorteDatum, false); }
        }

        /// <summary>Is lid WLP    (GET ONLY)</summary>
        [XmlIgnore]
        public bool IsWLP
        {
            get { return LeeftijdCategorie == constWelp; }
        }
        /// <summary>Is lid PUP    (GET ONLY)</summary>
        [XmlIgnore]
        public bool IsPUP
        {
            get { return LeeftijdCategorie  == constPupil; }
        }
        /// <summary>Is lid CAD    (GET ONLY)</summary>
        [XmlIgnore]
        public bool IsCAD
        {
            get { return LeeftijdCategorie == constCadet; }
        }
        /// <summary>Is lid JUN    (GET ONLY)</summary>
        [XmlIgnore]
        public bool IsJUN
        {
            get { return LeeftijdCategorie == constJunior; }
        }
        /// <summary>Is lid SEN1    (GET ONLY)</summary>
        [XmlIgnore]
        public bool IsSEN1
        {
            get { return LeeftijdCategorieLong == constSenior1; }
        }
        /// <summary>Checks if LID is SEN, </summary>
        [XmlIgnore]
        private bool IsSEN
        {
            get { return LeeftijdCategorieLong == constSenior; }
        }
        /// <summary>Is lid 65+    (GET ONLY)</summary>
        [XmlIgnore]
        public bool Is65plus
        {
            get { return LeeftijdCategorieLong == const65Plus; }
        }
        /// <summary>Checks if LID is WLP,PUP,CAD,JUN or SEN1</summary>
        [XmlIgnore]
        public bool Is_WLP_PUP_CAD_JUN_SEN1
        {
            get { return IsWLP || IsPUP || IsCAD || IsJUN || IsSEN1; }
        }
        /// <summary>Checks if LID is Sen1 or 65+ or SEN</summary>
        [XmlIgnore]
        public bool Is_SEN1_65_SEN
        {
            get { return IsSEN1 || Is65plus || IsSEN; }
        }
        #endregion

        #region Lidtype & contributie type & Bonddingen

        
        [XmlIgnore]
        public bool IsLidNormaal
        {
            get { return _LidType == constLidNormaal; }
        }
        [XmlIgnore]
        public bool IsLidZwerf
        {
            get { return _LidType == constLidZwerflid; }
        }
        [XmlIgnore]
        public bool IsLidContVrij
        {
            get { return _LidType == constLidContributieVrij; }
        }
        [XmlIgnore]
        public bool IsLidPakket
        {
            get { return _LidType == constLidPakket; }
        }



        [XmlIgnore]
        public bool IsRekening
        {
            get { return _BetaalWijze == constBetwRekening; }
        }

        [XmlIgnore]
        public bool IsIncasso
        {
            get { return _BetaalWijze == constBetwIncasso; }
        }

        [XmlIgnore]
        public bool IsUPas
        {
            get { return _BetaalWijze == constBetwUPas; }
        }

        [XmlIgnore]
        public bool IsZelfBetaler
        {
            get { return _BetaalWijze == constZelfBetaler; }
        }




        private string _BondsNr;
        /// <summary>Get or Set BondsNr value</summary>
        [Category(A)]
        public string BondsNr
        {
            get { return _BondsNr; }
            set { _BondsNr = value; Dirty = true; }
        }

        private bool _LidBond;
        /// <summary>Get or Set LidBond value</summary>
        [Category(A)]
        [JsonConverter(typeof(BoolConverter))]
        public bool LidBond
        {
            get { return _LidBond; }
            set { _LidBond = value; Dirty = true; }
        }

        private bool _CompGerechtigd;
        /// <summary>Get or Set CompGerechtigd value</summary>
        [Category(A)]
        [JsonConverter(typeof(BoolConverter))]
        public bool CompGerechtigd
        {
            get { return _CompGerechtigd; }
            set { _CompGerechtigd = value; Dirty = true; }
        }
        #endregion

        #region Email
        private string _Email1;
		/// <summary>Get or Set Email1 value</summary>
        [Category(A)]
        public string Email1 
		{
			get { return _Email1 ; }
			set { _Email1 = value; Dirty = true; }
		}

		private string _Email2 ;
		/// <summary>Get or Set Email2 value (FB)</summary>
        [Category(A)]
        public string Email2 
		{
			get { return _Email2 ; }
			set { _Email2 = value; Dirty = true; }
		}

        /// <summary>Belangrijkste email adres voor incasso mail</summary>
        [Category(A)]
        [XmlIgnore]
        public string MainEmailAdress
        {
            get {return ( Is_WLP_PUP_CAD_JUN_SEN1 && _Ouder1_Email1 != string.Empty) ?  _Ouder1_Email1 : _Email1; }
        }
        #endregion

        /// <summary>
        /// Returns the serialnumber of the LidType Codes "N" --> 1   { "N", "Z", "V", "P" }
        /// </summary> 
        [XmlIgnore]
        public int ItemNr_From_To_LidType
        {
            get
            {
                for (int i = 0; i < tblLid.LidTypes.Length; i++)
                    if (tblLid.LidTypes[i] == _LidType) return i;
                return 0;
            }
            set
            {
                int nbr = value;
                _LidType = tblLid.LidTypes[nbr]; Dirty = true;
            }
        }

        private string _LidType;
		/// <summary>Get or Set LidType value;
        ///  LidTypes = { "N", "Z", "V", "P" };
        /// </summary>
        [Category(A)]
        public string LidType 
		{
			get { return _LidType ; }
			set { _LidType = value; Dirty = true; }
		}

		private DateTime _LidVanaf;
		/// <summary>Get or Set LidVanafvalue</summary>
		public DateTime LidVanaf
		{
			get { return _LidVanaf; }
			set { _LidVanaf= value; Dirty = true; }
		}

        private bool _Opgezegd;
        /// <summary>Get or Set Opgezegd value</summary>
        [Category(A)]
        [JsonConverter(typeof(BoolConverter))]
        public bool Opgezegd
        {
            get { return _Opgezegd; }
            set { _Opgezegd = value; Dirty = true; }
        }

        private DateTime _LidTot;
		/// <summary>Get or Set LidTotvalue</summary>
		public DateTime LidTot
		{
			get { return _LidTot; }
			set { _LidTot= value; Dirty = true; }
		}

		private DateTime _PakketTot;
		/// <summary>Get or Set PakketTotvalue</summary>
		public DateTime PakketTot
		{
			get { return _PakketTot; }
			set { _PakketTot= value; Dirty = true; }
		}

		private string _Medisch ;
		/// <summary>Get Set Medisch value</summary>
        [Category(A)]
        public string Medisch 
		{
			get { return _Medisch ; }
			set { _Medisch = value; Dirty = true; }
		}

		private bool _Gemerkt ;
		/// <summary>Get or Set Gemerkt value</summary>
        [Category(A)]
        [JsonConverter(typeof(BoolConverter))]
        public bool Gemerkt 
		{
			get { return _Gemerkt ; }
			set { _Gemerkt = value; Dirty = true; }
		}


        private byte[] _Image;
        public byte[] Image
        {
            get { return _Image; }
            set { _Image = value; Dirty = true; }
        }

        #region Financieel
        private string _IBAN;
        /// <summary>Get or Set IBAN value</summary>
        [Category(FinancieelGegevens)]
        public string IBAN
        {
            get { return _IBAN; }
            set { _IBAN = value; Dirty = true; }
        }

        private string _BIC;
        /// <summary>Get or Set BIC value</summary>
        [Category(FinancieelGegevens)]
        public string BIC
        {
            get { return _BIC; }
            set { _BIC = value; Dirty = true; }
        }

        [Category(FinancieelGegevens)]
        [XmlIgnore]
        public int ItemNr_From_To_BetaalWijze
        {
            get
            {
                for (int i = 0; i < tblLid.BetaalWijzes.Length; i++)
                    if (tblLid.BetaalWijzes[i] == _BetaalWijze) return i;
                return 0;
            }
            set
            {
                _BetaalWijze = tblLid.BetaalWijzes[value]; Dirty = true;
            }
        }

        private string _BetaalWijze;
        /// <summary>Get or Set BetaalWijze value</summary>
        [Category(FinancieelGegevens)]
        public string BetaalWijze
        {
            get { return _BetaalWijze; }
            set { _BetaalWijze = value; Dirty = true; }
        }

        private decimal _VastBedrag;
        /// <summary>Get or Set VastBedragvalue</summary>
        [Category(FinancieelGegevens)]
        public decimal VastBedrag
        {
            get { return _VastBedrag; }
            set { _VastBedrag = value; Dirty = true; }
        }

        private decimal _Korting;
        /// <summary>Get or Set Kortingvalue</summary>
        
        [Category(FinancieelGegevens)]
        public decimal Korting
        {
            get { return _Korting; }
            set { _Korting = value; Dirty = true; }
        }

        private string _U_PasNr;
        /// <summary>Get or Set U-PasNrvalue</summary>
        [Category(FinancieelGegevens)]
        public string U_PasNr
        {
            get { return _U_PasNr; }
            set { _U_PasNr = value; Dirty = true; }
        }

        private bool _Geincasseerd;
        /// <summary>Get or Set Geincasseerd</summary>
        [Category(FinancieelGegevens)]
        [XmlIgnore]
        [JsonConverter(typeof(BoolConverter))]
        public bool Geincasseerd
        {
            get { return _Geincasseerd; }
            set { _Geincasseerd = value; Dirty = true; }
        }

        private string _LicentieJun;
        [Category(Overig)]
        public string LicentieJun
        {
            get { return _LicentieJun; }
            set { _LicentieJun = value; Dirty = true; }
        }

        [XmlIgnore]
        public bool IsLicentieA
        {
            get { return _LicentieJun == "A"; }
            set {
                    if (value)
                    {
                        LicentieJun = "A";
                        Dirty = true;
                    }
            }
        }

        [XmlIgnore]
        public bool IsLicentieB
        {
            get { return _LicentieJun == "B"; }
            set
            {
                if (value)
                {
                    LicentieJun = "B";
                    Dirty = true;
                }
            }
        }

        [XmlIgnore]
        public bool IsLicentieGeen
        {
            get { return _LicentieJun == string.Empty; }
            set
            {
                if (value)
                {
                    LicentieJun = string.Empty;
                    Dirty = true;
                }
            }
        }
        [XmlIgnore]
        public bool IsLicentieAB
        {
            get { return (IsLicentieA || IsLicentieB); }
        }

        private int _ToernooiSpeler;
        [Category(Overig)]
        public int ToernooiSpeler
        {
            get { return _ToernooiSpeler; }
            set { _ToernooiSpeler = value; Dirty = true; }
        }

        [XmlIgnore]
        public bool IsToernooiSpeler
        {
            get { return _ToernooiSpeler == 1; }
            set { _ToernooiSpeler = 1; Dirty = true; }
        }

        [XmlIgnore]
        public bool IsRanglijstSpeler
        {
            get { return _ToernooiSpeler == 2; }
            set { _ToernooiSpeler = 2; Dirty = true; }
        }

        [XmlIgnore]
        public bool IsMinimeerkampSpeler
        {
            get { return IsToernooiSpeler && (IsWLP || IsPUP); }
        }

        #endregion
        #region Ouder1
        private string _Ouder1_Naam ;
		/// <summary>Get or Set Ouder1_Naam value</summary>
        [Category(Ouder1Gegevens)]
        public string Ouder1_Naam 
		{
			get { return _Ouder1_Naam ; }
			set { _Ouder1_Naam = value; Dirty = true; }
		}

		private string _Ouder1_Email1 ;
		/// <summary>Get or Set Ouder1_Email1 value</summary>
        [Category(Ouder1Gegevens)]
        public string Ouder1_Email1 
		{
			get { return _Ouder1_Email1 ; }
			set { _Ouder1_Email1 = value; Dirty = true; }
		}

		private string _Ouder1_Email2 ;
		/// <summary>Get or Set Ouder1_Email2 value</summary>
        [Category(Ouder1Gegevens)]
        public string Ouder1_Email2 
		{
			get { return _Ouder1_Email2 ; }
			set { _Ouder1_Email2 = value; Dirty = true; }
		}

		private string _Ouder1_Mobiel ;
		/// <summary>Get or Set Ouder1_Mobiel value</summary>
        [Category(Ouder1Gegevens)]
        public string Ouder1_Mobiel 
		{
			get { return _Ouder1_Mobiel ; }
			set { _Ouder1_Mobiel = value; Dirty = true; }
		}

		private string _Ouder1_Telefoon ;
		/// <summary>Get or Set Ouder1_Telefoon value</summary>
        [Category(Ouder1Gegevens)]
        public string Ouder1_Telefoon 
		{
			get { return _Ouder1_Telefoon ; }
			set { _Ouder1_Telefoon = value; Dirty = true; }
		}
        #endregion
        #region Ouder2
        private string _Ouder2_Naam ;
		/// <summary>Get or Set Ouder2_Naam value</summary>
        [Category(Ouder2Gegevens)]
        public string Ouder2_Naam 
		{
			get { return _Ouder2_Naam ; }
			set { _Ouder2_Naam = value; Dirty = true; }
		}

		private string _Ouder2_Email1 ;
		/// <summary>Get or Set Ouder2_Email1 value</summary>
        [Category(Ouder2Gegevens)]
        public string Ouder2_Email1 
		{
			get { return _Ouder2_Email1 ; }
			set { _Ouder2_Email1 = value; Dirty = true; }
		}

		private string _Ouder2_Email2 ;
		/// <summary>Get or Set Ouder2_Email2 value</summary>
        [Category(Ouder2Gegevens)]
        public string Ouder2_Email2 
		{
			get { return _Ouder2_Email2 ; }
			set { _Ouder2_Email2 = value; Dirty = true; }
		}

		private string _Ouder2_Mobiel ;
		/// <summary>Get or Set Ouder2_Mobiel value</summary>
        [Category(Ouder2Gegevens)]
        public string Ouder2_Mobiel 
		{
			get { return _Ouder2_Mobiel ; }
			set { _Ouder2_Mobiel = value; Dirty = true; }
		}
		
        private string _Ouder2_Telefoon ;
		/// <summary>Get or Set Ouder2_Telefoon value</summary>
        [Category(Ouder2Gegevens)]
        public string Ouder2_Telefoon 
		{
			get { return _Ouder2_Telefoon ; }
			set { _Ouder2_Telefoon = value; Dirty = true; }
		}
        #endregion
        
        private bool _VrijwillgersRegelingIsVanToepassing;
        /// <summary>Get or Set Is de vrijwilligersregeling van toepassing? (</summary>
        [Category(Overig)]
        [JsonConverter(typeof(BoolConverter))]
        public bool VrijwillgersRegelingIsVanToepassing
        {
            get { return _VrijwillgersRegelingIsVanToepassing; }
            set { _VrijwillgersRegelingIsVanToepassing = value; Dirty = true; }
        }
       
        #region Extra

        private int _Rating;
        /// <summary>Get or Set Rating</summary>
        [Category(Overig)]
        public int Rating
        {
            get { return _Rating; }
            set { _Rating = value; Dirty = true; }
        }

        private bool _VrijwillgersVasteTaak;
        /// <summary>Get or Set VrijwillgersVasteTaak</summary>
        [Category(Overig)]
        [JsonConverter(typeof(BoolConverter))]
        public bool VrijwillgersVasteTaak
        {
            get { return _VrijwillgersVasteTaak; }
            set { _VrijwillgersVasteTaak = value; Dirty = true; }
        }

        private bool _VrijwillgersAfgekocht;
        /// <summary>Get or Set VrijwillgersAfgekocht</summary>
        [Category(Overig)]
        [JsonConverter(typeof(BoolConverter))]
        public bool VrijwillgersAfgekocht
        {
            get { return _VrijwillgersAfgekocht; }
            set { _VrijwillgersAfgekocht = value; Dirty = true; }
        }

        private string _VrijwillgersToelichting;
        /// <summary>Get or Set VrijwillgersToelichting</summary>
        [Category(Overig)]
        public string VrijwillgersToelichting
        {
            get { return _VrijwillgersToelichting; }
            set { _VrijwillgersToelichting = value; Dirty = true; }
        }

        private string _LicentieSen;
        /// <summary>Get or Set LicentieSen</summary>
        [Category(Extra)]
        public string LicentieSen
        {
            get { return _LicentieSen; }
            set { _LicentieSen = value; Dirty = true; }
        }

        private string _ExtraD;
        /// <summary>Get or Set ExtraD</summary>
        [Category(Extra)]
        public string ExtraD
        {
            get { return _ExtraD; }
            set { _ExtraD = value; Dirty = true; }
        }

        private string _ExtraE;
        /// <summary>Get or Set ExtraE</summary>
        [Category(Extra)]
        public string ExtraE
        {
            get { return _ExtraE; }
            set { _ExtraE = value; Dirty = true; }
        }

        #endregion

        [XmlIgnore]
        public List<EmailAdresLid> EmailAdresses
        {
            get
            {
                List<EmailAdresLid> _EmailAdresses = new List<EmailAdresLid>();

                if (_Email1 != string.Empty)
                    if (_Ouder1_Email1 == string.Empty || Is_SEN1_65_SEN)
                        _EmailAdresses.Add(new EmailAdresLid(_Email1, NetteNaam, C.OnlyFinanicalMailAddresses));
                    else
                        _EmailAdresses.Add(new EmailAdresLid(_Email1, NetteNaam, C.AllEmailAddresses));

                if (_Email2 != string.Empty)
                    _EmailAdresses.Add(new EmailAdresLid(_Email2, NetteNaam, C.AllEmailAddresses));


                if (Is_WLP_PUP_CAD_JUN_SEN1)
                {
                    if (_Ouder1_Email1 != string.Empty)
                        _EmailAdresses.Add(new EmailAdresLid(_Ouder1_Email1, "Ouder van " + NetteNaam, C.OnlyFinanicalMailAddresses));
                    if (_Ouder1_Email2 != string.Empty)
                        _EmailAdresses.Add(new EmailAdresLid(_Ouder1_Email2, "Ouder van " + NetteNaam, C.AllEmailAddresses));
                    if (_Ouder2_Email1 != string.Empty)
                        _EmailAdresses.Add(new EmailAdresLid(_Ouder2_Email1, "Ouder van " + NetteNaam, C.AllEmailAddresses));
                    if (_Ouder1_Email2 != string.Empty)
                        _EmailAdresses.Add(new EmailAdresLid(_Ouder2_Email1, "Ouder van " + NetteNaam, C.AllEmailAddresses));
                }
                return _EmailAdresses;
            }
        }

        /// <summary>
        /// Deze string wordt gebruikt in de url van de call naar het PHP . Dit script gebruikt deze params in een SQL statement
        /// </summary>
        /// <returns></returns>
        public string CreatePHPUrlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&LidNr=" + _LidNr);
            sb.Append("&Voornaam=" + _Voornaam);
            sb.Append("&Achternaam=" + _Achternaam);
            sb.Append("&Tussenvoegsel=" + _Tussenvoegsel);
            sb.Append("&Adres=" + _Adres);
            sb.Append("&Woonplaats=" + _Woonplaats);
            sb.Append("&Postcode=" + _Postcode);
            sb.Append("&Mobiel=" + _Mobiel);
            sb.Append("&Telefoon=" + _Telefoon);
            sb.Append("&BondsNr=" + _BondsNr);
            sb.Append("&Geslacht=" + _Geslacht);
            sb.Append("&GeboorteDatum=" + _GeboorteDatum.ToString("yyyy-MM-dd"));
            sb.Append("&Email1=" + _Email1);
            sb.Append("&Email2=" + _Email2);
            sb.Append("&IBAN=" + _IBAN);
            sb.Append("&BIC=" + _BIC);
            sb.Append("&LidBond=" + (_LidBond ? "1" : "0"));
            sb.Append("&CompGerechtigd=" + (_CompGerechtigd ? "1" : "0"));
            sb.Append("&ToernooiSpeler=" + _ToernooiSpeler);
            sb.Append("&LidType=" + _LidType);
            sb.Append("&LidVanaf=" + _LidVanaf.ToString("yyyy-MM-dd"));
            sb.Append("&Opgezegd=" + (_Opgezegd ? "1" : "0"));
            sb.Append("&LidTot=" + _LidTot.ToString("yyyy-MM-dd"));
            sb.Append("&Medisch=" + _Medisch);
            sb.Append("&Gemerkt=" + (_Gemerkt ? "1" : "0"));
            sb.Append("&U_PasNr=" + _U_PasNr);
            sb.Append("&PakketTot=" + _PakketTot.ToString("yyyy-MM-dd"));
            sb.Append("&BetaalWijze=" + _BetaalWijze);
            sb.Append("&VastBedrag=" + _VastBedrag.ToXMLString());
            sb.Append("&Korting=" + _Korting.ToXMLString());
            sb.Append("&Geincasseerd=" + (_Geincasseerd ? "1" : "0"));
            sb.Append("&Ouder1_Naam=" + _Ouder1_Naam);
            sb.Append("&Ouder1_Email1=" + _Ouder1_Email1);
            sb.Append("&Ouder1_Email2=" + _Ouder1_Email2);
            sb.Append("&Ouder1_Mobiel=" + _Ouder1_Mobiel);
            sb.Append("&Ouder1_Telefoon=" + _Ouder1_Telefoon);
            sb.Append("&Ouder2_Naam=" + _Ouder2_Naam);
            sb.Append("&Ouder2_Email1=" + _Ouder2_Email1);
            sb.Append("&Ouder2_Email2=" + _Ouder2_Email2);
            sb.Append("&Ouder2_Mobiel=" + _Ouder2_Mobiel);
            sb.Append("&Ouder2_Telefoon=" + _Ouder2_Telefoon);
            sb.Append("&VrijwillgersRegelingIsVanToepassing=" + (_VrijwillgersRegelingIsVanToepassing ? "1" : "0"));
            sb.Append("&VrijwillgersVasteTaak=" + (_VrijwillgersVasteTaak ? "1" : "0"));
            sb.Append("&VrijwillgersAfgekocht=" + (_VrijwillgersAfgekocht ? "1" : "0"));
            sb.Append("&VrijwillgersToelichting=" + _VrijwillgersToelichting);
            sb.Append("&LicentieSen=" + _LicentieSen);
            sb.Append("&LicentieJun=" + _LicentieJun);
            sb.Append("&Extra1=" + "1");
            sb.Append("&Extra2=" + "2");
            sb.Append("&Rating=" + _Rating.ToString());
            sb.Append("&Extra4=" + "4");
            sb.Append("&Extra5=" + "5");
            sb.Append("&ExtraA=" + "_ExtraA");
            sb.Append("&ExtraB=" + "_ExtraB");
            sb.Append("&ExtraC=" + "_ExtraC");
            sb.Append("&ExtraD=" + _ExtraD);
            sb.Append("&ExtraE=" + _ExtraE);
            sb.Append("&ToegangsCode=" + "_ToegangsCode");
            sb.Append("&Rol=" + "_Rol");
            sb.Append("&Image=" + _Image);

            return sb.ToString();
        }
    }

    #region Sorteren LedenLijst
    public class LedenComparer : IComparer<tblLid>
    {
        private string _sortItem;

        public LedenComparer(string sortItem) { _sortItem = sortItem; }
        public LedenComparer() {}
        public int Compare(tblLid x, tblLid y)
        {
            try
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                switch (_sortItem)
                {
                    case "LidNr"            : //Console.WriteLine(x.LidNr + " >= " + y.LidNr + " --> " +  ((x.LidNr > y.LidNr) ? "true" : "false"));
                                              return (x.LidNr >= y.LidNr) ? 1 : -1; 
                    case "GeboorteDatum"    : return (x.GeboorteDatum > y.GeboorteDatum) ? 1 : -1;

                    case "Verjaardag"       : return (x.GeboorteDatum.DayOfYear > y.GeboorteDatum.DayOfYear) ? 1 : -1;
                    default: //Console.WriteLine(x.VolledigeNaam + " > " + y.VolledigeNaam);
                                              return string.Compare(x.VolledigeNaam, y.VolledigeNaam); 
                }
            }
            catch
            {
                return 0;
            }
        }
    }
    #endregion

    #region EmailAdresLid
    public class EmailAdresLid
    {
        public EmailAdresLid()
        {
            _Naam = string.Empty;
            _EmailAddress = string.Empty;
            _FinancialMail = false;
        }
        public EmailAdresLid(string EmailAddress, string Name, bool Financial)
        {
            _Naam = Name;
            _EmailAddress = EmailAddress;
            _FinancialMail = Financial;
        }
        public EmailAdresLid(string EmailAddress) : this(EmailAddress, string.Empty, false) { }
        public EmailAdresLid(string EmailAddress, string Name) : this(EmailAddress, Name, false) { }
        public EmailAdresLid(string EmailAddress, bool Financial) : this(EmailAddress, string.Empty, Financial) { }
        
        private string _Naam;
        public string Naam
        {
            get {return _Naam;}
            set {_Naam = value;}
        }

        private bool _FinancialMail;
        public bool FinancialMail
        {
            get { return _FinancialMail; }
            set { _FinancialMail = value; }
        }

        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }

        public string EmailWithDisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_Naam.Trim()))
                    return _EmailAddress;
                else
                    return @"""" + _Naam + @""" <" + _EmailAddress + ">";
            }
        }
    }
#endregion


    public class MySQLLidResponse
    {
        public int success { get; set; }
        public string message { get; set; }
        public LedenLijst posts { get; set; }
    }
}
 