using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Util.Text;
using Util.Forms;
using System.Text;

namespace Leden.Net
{
    [Serializable]
    [XmlRoot("CrediteurenLijst")]
    public class CrediteurenLijst : List<tblCrediteur>
    {
        public CrediteurenLijst() { }
    }


    /// <summary>Class holding tblLid fields</summary>
    [Serializable]
    [XmlType("Crediteur")]
    public class tblCrediteur
    {
        public static string[] BetalingTypeDescriptions = { "Overig" };
        // Een parameterloze contructor is nodig om te kunnen "serializen"
        public tblCrediteur()
        {
            _Crediteur = string.Empty;
            _Naam = "Nieuw";
            _IBAN = string.Empty;
            _BIC = string.Empty;
            _Omschrijving = string.Empty;

            _isDirty = true;
        }

        public tblCrediteur(CrediteurenLijst crediteuren)
        {
            _Crediteur = string.Empty;
            _Naam = "Nieuw";
            _IBAN = string.Empty;
            _BIC = string.Empty;
            _Omschrijving = string.Empty;

            _isDirty = true;
            crediteuren.Add(this);
        }

        /// <summary>Get or Set Crediteur</summary>
        public string Crediteur
        {
            get { return _Crediteur; }
            set { _Crediteur = value; Dirty = true; }
        }
        private string _Crediteur;

        /// <summary>Get or Set Naam</summary>
        public string Naam
        {
            get { return _Naam; }
            set { _Naam = value; Dirty = true; }
        }
        private string _Naam;

        /// <summary>Get or Set the Dirty flag</summary>
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        private bool _isDirty;

        /// <summary>Get or Set IBAN value</summary>
        public string IBAN
        {
            get { return _IBAN; }
            set { _IBAN = value; Dirty = true; }
        }
        private string _IBAN;

        /// <summary>Get or Set BIC value</summary>
        public string BIC
        {
            get { return _BIC; }
            set { _BIC = value; Dirty = true; }
        }
        private string _BIC;

        /// <summary>Get or Set Omschrijvingvalue</summary>
        public string Omschrijving
        {
            get { return _Omschrijving; }
            set { _Omschrijving = value; Dirty = true; }
        }
        private string _Omschrijving;


        /// <summary>
        /// Deze string wordt gebruikt in de url van de call naar het PHP . Dit script gebruikt deze params in een SQL statement
        /// </summary>
        /// <returns></returns>
        public string CreatePHPUrlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&Crediteur=" + _Crediteur);
            sb.Append("&Naam=" + _Naam);
            sb.Append("&IBAN="+ _IBAN);
            sb.Append("&BIC="+ _BIC);
            sb.Append("&Omschrijving=" + _Omschrijving);
            return sb.ToString();
        }


    }

    public class MySQLCrediteurResponse
    {
        public int success { get; set; }
        public string message { get; set; }
        public CrediteurenLijst posts { get; set; }
    }
}