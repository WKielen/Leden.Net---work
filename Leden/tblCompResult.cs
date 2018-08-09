using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Util.Forms;

namespace Leden.Net
{
    [Serializable]
    [XmlRoot("ResultatenLijst")]
    public class ResultatenLijst : List<tblCompResult>
    {
        public ResultatenLijst() { }

        public tblCompResult GetLatestResult(int lidnr)
        {
            tblCompResult lastResult = null;
            // We zoeken het laatste resultaat van dit lid.
            //selecteer alle resultaten  van dit lid
            foreach (tblCompResult currentResult in this)
            {
                if (currentResult.LidNr == lidnr) 
                {
                    // We hebben een resultaat gevonden. We gaan deze bewaren in lastResult.
                    lastResult = new tblCompResult();

                    // het bewaarde result heeft een ouder jaartal dan het ingevoerde dus vervangen.
                    if (currentResult.Jaar > lastResult.Jaar)
                        lastResult = currentResult;
                    // We zitten in hetzelfde jaar dus gaan we bepalen dat het najaar later is dan het voorjaar.
                    if (currentResult.Jaar == lastResult.Jaar && currentResult.Seizoen == "N" && lastResult.Seizoen == "V")
                       lastResult = currentResult;
                }
            }
            return lastResult;
        }

        public tblCompResult GetResult(int lidnr, int jaar, string seizoen)
        {
            tblCompResult result = null;
            foreach (tblCompResult cr in this)
            {
                if (cr.LidNr == lidnr && cr.Jaar == jaar && cr.SeizoenCombo == seizoen)
                {
                    // We hebben een resultaat gevonden. We gaan deze bewaren in lastResult.
                    result = new tblCompResult();
                    break;
                }
            }
            return result;
        }

        public void InsertOrUpdate(tblCompResult compResult)
        {
            bool found = false;
            foreach (tblCompResult cr in this)
            {
                if (cr.LidNr == compResult.LidNr && cr.Jaar == compResult.Jaar && cr.SeizoenCombo == compResult.SeizoenCombo)
                {
                    // We hebben een resultaat gevonden.
                    found = true;
                    cr.Klasse = compResult.Klasse;
                    cr.Percentage = compResult.Percentage;
                    break;
                }
            }
            if (!found)
            {
                this.Add(compResult);
            }
        }
    }

    /// <summary>Class holding tblLid fields</summary>
    [Serializable]
    [XmlType("Resultaat")]
    public class tblCompResult
    {
        public tblCompResult()
        {
            _LidNr = 0;
            _Lid = null;
        }
        public tblCompResult(tblLid lid)
        {
            _LidNr = 0;
            _Lid = lid;
        }

        private bool _isDirty;
        /// <summary>Get or Set the Dirty flag</summary>
        public bool Dirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        private int _Jaar;
        /// <summary>Get or Set Jaar</summary>
        public int Jaar
        {
            get { return _Jaar; }
            set { _Jaar = value; Dirty = true; }
        }

        private string _Seizoen;
        /// <summary>Get or Set Seizoen</summary>
        public string Seizoen
        {
            get { return _Seizoen; }
            set { _Seizoen = value; Dirty = true; }
        }

        private int _Percentage;
        /// <summary>Get or Set Percentage</summary>
        public int Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; Dirty = true; }
        }

        private string _CompetitieType;
        /// <summary>Get or Set CompetitieType</summary>
        public string CompetitieType
        {
            get { return _CompetitieType; }
            set { _CompetitieType = value; Dirty = true; }
        }

        private string _Klasse;
        /// <summary>Get or Set Klasse</summary>
        public string Klasse
        {
            get { return _Klasse; }
            set { _Klasse = value; Dirty = true; }
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
        public static string[] CompKlasses = { "Kamp.poule", "Land. A", "Land. B", "Land. C", "1ste klasse",
                 "2de klasse","3de klasse","4de klasse","5de klasse","6de klasse","Starters",
                 "1e Divisie ","2e Divisie ","3e Divisie ",
                 "Duo 1","Duo 2","Duo 3","Duo 4","Duo 5","Duo 6"                             };
        public static string[] CompKlasseTypes = { "K", "A", "B", "C", "1", "2", "3", "4", "5", "6", "S", "1D", "2D", "3D", "D1", "D2", "D3", "D4", "D5", "D6"};

        [XmlIgnore]
        public string KlasseCombo
        {
            get 
            {
                for (int i = 0; i < CompKlasseTypes.Length; i++)
                {
                    if (CompKlasseTypes[i] == _Klasse)
                        return CompKlasses[i];
                }
                return null;}
            set
            {
                for (int i = 0; i < CompKlasses.Length; i++)
                {
                    _Klasse = string.Empty;
                    if (CompKlasses[i] == value)
                    {
                        _Klasse = CompKlasseTypes[i];
                        break;
                    }
                }
               Dirty = true;
            }
        }

        public static string[] CompSeizoen = { "Voorjaar", "Najaar" };
        public static string[] CompSeizoenTypes = { "V", "N"};
        [XmlIgnore]
        public string SeizoenCombo
        {
            get
            {
                for (int i = 0; i < CompSeizoenTypes.Length; i++)
                {
                    if (CompSeizoenTypes[i] == _Seizoen)
                        return CompSeizoen[i];
                }
                return null;
            }
            set
            {
                for (int i = 0; i < CompSeizoen.Length; i++)
                {
                    _Seizoen = string.Empty;
                    if (CompSeizoen[i] == value)
                    {
                        _Seizoen = CompSeizoenTypes[i];
                        break;
                    }
                }
                Dirty = true;
            }
        }

        public static tblCompResult CreateCompResultRecord(tblLid lid)
        {
            tblCompResult CompResult = new tblCompResult();
            try
            {
                CompResult.LidNr = lid.LidNr;
                CompResult.Lid = lid;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return CompResult;
        }

        /// <summary>
        /// Deze string wordt gebruikt in de url van de call naar het PHP . Dit script gebruikt deze params in een SQL statement
        /// </summary>
        /// <returns></returns>
        public string CreatePHPUrlString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&LidNr=" + _LidNr);
            sb.Append("&Jaar=" + _Jaar);
            sb.Append("&Seizoen=" + _Seizoen);
            sb.Append("&CompetitieType=" +  _CompetitieType);
            sb.Append("&Klasse="+ _Klasse);
            sb.Append("&Percentage=" + _Percentage);
            return sb.ToString();
        }

    }
 
    public class MySQLCompResultResponse
    {
        public int success { get; set; }
        public string message { get; set; }
        public ResultatenLijst posts { get; set; }
    }

}