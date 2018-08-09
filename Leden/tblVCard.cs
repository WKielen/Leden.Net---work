using System;
using System.Xml.Serialization;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using Util.Text;
using Util.Extensions;

namespace Leden.Net
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("VCardLijst")]
    public class tblVCard : List<VCard>, ICloneable
    {
        public object Clone()
        {
            tblVCard copy = new tblVCard();
            foreach (VCard lid in this)
            {
                VCard copyLid = (VCard)lid.Clone();
                copy.Add(copyLid);
            }
            return copy;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class VCard: ICloneable
    {
        public VCard()
        {
            _Voornaam = DateTime.Now.ToString();
            _Achternaam = "Onbekend";
            _Tussenvoegsel = string.Empty;

            _emailLijst = new List<EmailAddressClass>();
            _telefoonNummerLijst = new List<TelephoneNumberClass>();
            _adresLijst = new List<AddressClass>();
            _GeboorteDatum = string.Empty;
            _Organisatie = string.Empty;
            _Note = string.Empty;
            _Title = string.Empty;
            _Leden = false;
        }


        #region Constants
        protected const string NAW = "A NAW";
        protected const string Contact = "B Telnr and Mail";
        protected const string Overig = "C Overig";
        #endregion
        #region NAW gegevens
        private string _Voornaam;
        /// <summary>Get or Set Voornaamvalue</summary>
        [Category(NAW)]
        public string Voornaam
        {
            get { return _Voornaam; }
            set { _Voornaam = value; Dirty = true; }
        }

        private string _Achternaam;
        /// <summary>Get or Set Achternaam value</summary>
        [Category(NAW)]
        public string Achternaam
        {
            get { return _Achternaam; }
            set { _Achternaam = value; Dirty = true; }
        }

        private string _Tussenvoegsel;
        /// <summary>Get or Set Tussenvoegsel value</summary>
        [Category(NAW)]
        public string Tussenvoegsel
        {
            get { return _Tussenvoegsel; }
            set { _Tussenvoegsel = value; Dirty = true; }
        }

        /// <summary>
        /// De naam in de vorm Achternaam, Voornaam tussenvoegsel
        /// </summary>
        [Category(NAW)]
        [XmlIgnore]
        public string VolledigeNaam
        {
            get
            {
                string naam;
                if (_Achternaam.Trim() == string.Empty)
                    naam = _Voornaam.Trim();
                else
                    naam = _Achternaam.Trim() + ", " + _Voornaam.Trim();
                if (_Tussenvoegsel.Trim() != string.Empty)
                    naam += " " + _Tussenvoegsel.Trim();
                return naam;
            }
        }

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

        #endregion
        #region Overig
        private string _GeboorteDatum;
        /// <summary>Get or Set GeboorteDatum value</summary>
        [Category(Overig)]
        public string GeboorteDatum
        {
            get { return _GeboorteDatum; }
            set { _GeboorteDatum = value; Dirty = true; }
        }

        private string _Note;
        /// <summary>Get or Set Note value</summary>
        [Category(Overig)]
        public string Note
        {
            get { return _Note; }
            set { _Note = value; Dirty = true; }
        }

        private string _Organisatie;
        /// <summary>Get or Set Organisatie value</summary>
        [Category(Overig)]
        public string Organisatie
        {
            get { return _Organisatie; }
            set { _Organisatie = value; Dirty = true; }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private bool _Leden;
        public bool Leden
        {
            get { return _Leden; }
            set { _Leden = value; }
        }

        #endregion
        private List<AddressClass> _adresLijst;
        [Category(NAW)]
        public List<AddressClass> adresLijst
        {
            get { return _adresLijst; }
            set { _adresLijst = value; Dirty = true; }
        }
        #region Contacts

        private List<EmailAddressClass> _emailLijst;
        [Category(Contact)]
        public List<EmailAddressClass> emailLijst
		{
            get { return _emailLijst; }
            set { _emailLijst = value; Dirty = true; }
		}
        private List<TelephoneNumberClass> _telefoonNummerLijst;
        [Category(Contact)]
        public List<TelephoneNumberClass> telefoonNummerLijst
		{
            get { return _telefoonNummerLijst; }
            set { _telefoonNummerLijst = value; Dirty = true; }
		}
        #endregion
        #region Dirty and Clone
        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        [XmlIgnore]
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        public object Clone()
        {
            VCard copy = new VCard();
            copy._Voornaam = (string)this._Voornaam.Clone();
            copy._Achternaam = (string)this._Achternaam.Clone();
            copy._Tussenvoegsel = (string)this._Tussenvoegsel.Clone();

            copy._GeboorteDatum = (string)this._GeboorteDatum.Clone();
            copy._Organisatie = (string)this._Organisatie.Clone();
            copy._Note = (string)this._Note.Clone();
            copy._Title = (string)this.Title.Clone();
        
            // wordt hieronder daadwerkelijk gecloned?
            copy._adresLijst = this._adresLijst;
            copy._emailLijst = this._emailLijst;
            copy._telefoonNummerLijst = this._telefoonNummerLijst;
            copy._Leden = this._Leden;
            return copy;
        }
        #endregion
    }


    public class vCardComparer : IComparer<VCard>
    {
        public int Compare(VCard x, VCard y)
        {
            try
            {
                if (x == null && y == null) return 0;
                if (x == null) return -1;
                if (y == null) return 1;

                return string.Compare(x.VolledigeNaam, y.VolledigeNaam);
            }
            catch
            {
                return 0;
            }
        }
    }


    /// <summary>
    /// 
    /// </summary>
    public class AddressClass
    {
        public AddressClass()
        {
            _Adres = string.Empty;
            _Woonplaats = string.Empty;
            _Postcode = string.Empty;
            _Type = string.Empty;
        }
        public AddressClass(string Adres, string Postcode, string Woonplaats)
        {
            _Adres = Adres;
            _Woonplaats = Woonplaats;
            _Postcode = Postcode;
            _Type = string.Empty;
        }


        private string _Adres;
        /// <summary>Get or Set Adres value</summary>
        public string Adres
        {
            get { return _Adres; }
            set { _Adres = value; Dirty = true; }
        }

        private string _Woonplaats;
        /// <summary>Get or Set Woonplaats value</summary>
        public string Woonplaats
        {
            get { return _Woonplaats; }
            set { _Woonplaats = value; Dirty = true; }
        }

        private string _Postcode;
        /// <summary>Get or Set Postcode value</summary>
        public string Postcode
        {
            get { return _Postcode; }
            set { _Postcode = value; Dirty = true; }
        }



        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        #region Dirty and Clone
        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        [XmlIgnore]
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        #endregion
    }

    
    /// <summary>
    /// 
    /// </summary>
    public class EmailAddressClass
    {
        public EmailAddressClass()
        {
            Init();
        }
        public EmailAddressClass(string email)
        {
            Init();
            _EmailAddress = email;
        }

        private void Init()
        {
            _EmailAddress = string.Empty;
            _Type = string.Empty;
            _Preference = false;
            _isDirty = false;
        }

        private string _EmailAddress;
        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value;}
        }
        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        private bool _Preference;
        public bool Preference
        {
            get { return _Preference; }
            set { _Preference = value; }
        }
        
        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        [XmlIgnore]
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TelephoneNumberClass
    {
        public TelephoneNumberClass()
        {
            _Type = string.Empty;
            _TelephoneNumber = string.Empty;
            _Preference = false;
        }
        public TelephoneNumberClass(string Type, string Telnr, bool Preference)
        {
            _Type = Type;
            _TelephoneNumber = Telnr;
            _Preference = Preference;
        }

        private string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value;}
        }

        private string _TelephoneNumber;
        public string TelephoneNumber
        {
            get { return _TelephoneNumber; }
            set { _TelephoneNumber = value;}
        }

        public void AddCountryCode()
        {
            if (_TelephoneNumber.StartsWith("06"))
            {
                _TelephoneNumber = _TelephoneNumber.Remove(0, 2);
                _TelephoneNumber = "+316" + _TelephoneNumber;
            }
            if (_TelephoneNumber.StartsWith("030"))
            {
                _TelephoneNumber = _TelephoneNumber.Remove(0, 3);
                _TelephoneNumber = "+3130" + _TelephoneNumber;
            }
            _TelephoneNumber = _TelephoneNumber.Replace(" ", string.Empty);
        }

        private bool _Preference;
        public bool Preference
        {
            get { return _Preference; }
            set { _Preference = value; }
        }
        
        
        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        [XmlIgnore]
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
    }
}
 