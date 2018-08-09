using System;
using System.Linq;
using System.Collections.Generic;

using Util.Forms;

namespace Leden.Net
{
    public static class C
    {
        public const bool OnlyFinanicalMailAddresses = true;
        public const bool AllEmailAddresses = false;
    }

    /// <summary>Class holding tblLid fields</summary>
    public class tblParameters
    {
        public tblParameters()
        {
            _IBAN = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "IBAN");
            _BIC = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "BIC");
            _LocationTemplates = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "LocationTemplates");
            _LocationLogFiles = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "LocationLogfiles");
            _ClubNameLong = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "ClubNameLong");
            if (_ClubNameLong == string.Empty) { _ClubNameLong = "Tafeltennisvereniging Nieuwegein"; }
            _ClubNameShort = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "ClubNameShort");
            if (_ClubNameShort == string.Empty) {_ClubNameShort = "TTVN"; }
            _KvK = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "KvK");
            _STMPserver = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "STMPserver");
            if (_STMPserver == string.Empty) { _STMPserver = "smtp.myprovider.nl"; }
            int.TryParse(PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "STMPport"), out _STMPport);
            _EmailReturnAdress = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "EmailReturnAdress");
            if (_EmailReturnAdress == string.Empty) { _EmailReturnAdress = @"""TTVN - Yourfunction"" <your_return_address@ttvn.nl>"; }
            _BijlageStatuten = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "BijlageStatuten");
            _BijlageReglement = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "BijlageReglement");
            _BijlageInfoFolder = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "BijlageInfoFolder");

            _EmailPassword = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "x");
            _EmailUserId = PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "UserId");
            _LogEmail = ("true" == PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "LogEmail"));
            _DoNotSendEmail = ("true" == PersistControlValue.ReadLocalAppSetting(@"Leden.Net", "DoNotSendEmail"));
        }
        
        public decimal cCompBijdrageSen         { get; set; }
        public decimal cCompBijdrageJun         { get; set; }
        public decimal cBondsBijdrage           { get; set; }
        public decimal cSen                     { get; set; }
        public decimal c65                      { get; set; }
        public decimal cWlpPup                  { get; set; }
        public decimal cCadJun                  { get; set; }
        public decimal cKostenRekening          { get; set; }
        public int     cPercZwerf               { get; set; }
        public decimal cPakketBedrag            { get; set; }
        public string  cOmschrijving            { get; set; }
        public decimal cKortingVrijwilliger     { get; set; }


        public string itxtFilePrefix            { get; set; }
        public int    itxtFileSeqnr             { get; set; }
        public string itxtMsgID                 { get; set; }
        public string itxtOutputLocationInc     { get; set; }
        public string itxtOutputLocationRek     { get; set; }
        public string itxtFilePrefixRek         { get; set; }
        public int    itxtFileSeqnrRek          { get; set; }
        public string itxtOutputLocationUPas    { get; set; }
        public string itxtFilePrefixUPas        { get; set; }
        public int    itxtFileSeqnrUPas         { get; set; }
        public bool ichkPrintVerslag          { get; set; }

        public string ltxtOutputLocation        { get; set; }
        public string ltxtEmailLeden            { get; set; }
        public string ltxtEmailJeugd            { get; set; }
        public string mtxtOutputMailLocation    { get; set; }
        public List<string> mtxtExtraEmail      { get; set; }
        public List<string> mmtxtExtraEmail      { get; set; }

        private string _LocationTemplates;
        /// <summary>Get or Set LocationTemplates value</summary>
        public string LocationTemplates
        {
            get { return _LocationTemplates; }
            set { _LocationTemplates = value; }
        }

        private string _LocationLogFiles;
        /// <summary>Get or Set LocationLogFiles value</summary>
        public string LocationLogFiles
        {
            get { return _LocationLogFiles; }
            set { _LocationLogFiles = value; }
        }
        private string _ClubNameLong;
        /// <summary>Get or Set ClubNameLong value</summary>
        public string ClubNameLong
        {
            get { return _ClubNameLong; }
            set { _ClubNameLong = value; }
        }

        private string _ClubNameShort;
        /// <summary>Get or Set ClubNameShort value</summary>
        public string ClubNameShort
        {
            get { return _ClubNameShort; }
            set { _ClubNameShort = value; }
        }

        private string _BIC;
        /// <summary>Get or Set BIC value</summary>
        public string BIC
        {
            get { return _BIC; }
            set { _BIC = value; }
        }

        private string _KvK;
        /// <summary>Get or Set KvK value</summary>
        public string KvK
        {
            get { return _KvK; }
            set { _KvK = value; }
        }

        private string _IBAN;
        /// <summary>Get or Set IBAN value</summary>
        public string IBAN
        {
            get { return _IBAN; }
            set { _IBAN = value; }
        }

        private string _STMPserver;
        /// <summary>Get or Set STMPserver value</summary>
        public string STMPserver
        {
            get { return _STMPserver; }
            set { _STMPserver = value; }
        }
        private int _STMPport;
        /// <summary>Get or Set STMPport value</summary>
        public int STMPport
        {
            get { return _STMPport; }
            set { _STMPport = value; }
        }
        private string _EmailUserId;
        /// <summary>Get or Set EmailUserId value</summary>
        public string EmailUserId
        {
            get { return _EmailUserId; }
            set { _EmailUserId = value; }
        }
        private string _EmailPassword;
        /// <summary>Get or Set EmailPassword value</summary>
        public string EmailPassword
        {
            get { return _EmailPassword; }
            set { _EmailPassword = value; }
        }
        private string _EmailReturnAdress;
        /// <summary>Get or Set EmailReturnAdress value</summary>
        public string EmailReturnAdress
        {
            get { return _EmailReturnAdress; }
            set { _EmailReturnAdress = value; }
        }
        private bool _LogEmail;
        /// <summary>
        /// Get or Set Whether the emails send have to be logged
        /// </summary>
        public bool LogEmail
        {
            get { return _LogEmail; }
            set { _LogEmail = value; }
        }

        private bool _DoNotSendEmail;
        /// <summary>
        /// Get or Set Whether the emails have to be send 
        /// </summary>
        public bool DoNotSendEmail
        {
            get { return _DoNotSendEmail; }
            set { _DoNotSendEmail = value; }
        }


        private string _BijlageStatuten;
        /// <summary>Get or Set BijlageStatuten value</summary>
        public string BijlageStatuten
        {
            get { return _BijlageStatuten; }
            set { _BijlageStatuten = value; }
        }
        private string _BijlageReglement;
        /// <summary>Get or Set BijlageReglement value</summary>
        public string BijlageReglement
        {
            get { return _BijlageReglement; }
            set { _BijlageReglement = value; }
        }
        private string _BijlageInfoFolder;
        /// <summary>Get or Set BijlageInfoFolder value</summary>
        public string BijlageInfoFolder
        {
            get { return _BijlageInfoFolder; }
            set { _BijlageInfoFolder = value; }
        }
        //private bool _LedenAdministratieModule;
        ///// <summary>Get or Set LedenAdministratieModule value</summary>
        //public bool LedenAdministratieModule
        //{
        //    get { return _LedenAdministratieModule; }
        //    set { _LedenAdministratieModule = value; }
        //}
        //private bool _RekeningModule;
        ///// <summary>Get or Set ckbRekeningModule value</summary>
        //public bool RekeningModule
        //{
        //    get { return _RekeningModule; }
        //    set { _RekeningModule = value; }
        //}
        public DateTime ContributiePeilDatum
        {
            get
            {
                DateTime now_date = DateTime.Now;
                DateTime jan_1_thisYear = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
                DateTime july_1_thisYear = new DateTime(DateTime.Now.Year, 7, 1, 0, 0, 0);
                if (now_date < july_1_thisYear)
                    return jan_1_thisYear;
                else
                    return july_1_thisYear;
            }
        }
        public enum LedenLijstType
        {
            Vrijwilligers,
            Toernooien,
            Selected
        };

    }
}