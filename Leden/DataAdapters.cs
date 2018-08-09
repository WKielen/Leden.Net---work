using System;
using System.Data.OleDb;

using Util.Forms;

namespace Leden.Net
{
	/// <summary>
	/// Summary description for DataAdapters.
	/// </summary>
	public delegate void PositionChangedEventHandler(object sender, EventArgs e);


	public class DataAdapters : System.ComponentModel.Component
	{
//=============================================================================================================
// Leden
//=============================================================================================================
        internal dsLeden dsDataSet2;
        private System.Data.OleDb.OleDbConnection cnLeden = null;

        internal System.Data.OleDb.OleDbDataAdapter daLid;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommandLid;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommandLid;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommandLid;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommandLid;

        internal System.Data.OleDb.OleDbDataAdapter daRekening;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommandRekening;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommandRekening;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommandRekening;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommandRekening;

        internal System.Data.OleDb.OleDbDataAdapter daCompResult;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommandCompResult;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommandCompResult;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommandCompResult;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommandCompResult;

        internal System.Data.OleDb.OleDbDataAdapter daBetaling;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommandBetaling;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommandBetaling;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommandBetaling;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommandBetaling;

        internal System.Data.OleDb.OleDbDataAdapter daCrediteur;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommandCrediteur;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommandCrediteur;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommandCrediteur;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommandCrediteur;
 
        //=============================================================================================================
 
        /// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        string databaseString = "user=3198048&pw=_ToegangsCode&db=LedenTest";


		public DataAdapters(System.ComponentModel.IContainer container)
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			container.Add(this);
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public DataAdapters()
		{
			///
			/// Required for Windows.Forms Class Composition Designer support
			///
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
        private void InitializeComponent()
        {
            //=============================================================================================================
            // Leden
            //=============================================================================================================
            this.dsDataSet2 = new dsLeden();


            this.daLid = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommandLid = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommandLid = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommandLid = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommandLid = new System.Data.OleDb.OleDbCommand();

            this.daRekening = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommandRekening = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommandRekening = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommandRekening = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommandRekening = new System.Data.OleDb.OleDbCommand();

            this.daCompResult = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommandCompResult = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommandCompResult = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommandCompResult = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommandCompResult = new System.Data.OleDb.OleDbCommand();

            this.daBetaling = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommandBetaling = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommandBetaling = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommandBetaling = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommandBetaling = new System.Data.OleDb.OleDbCommand();

            this.daCrediteur = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommandCrediteur = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommandCrediteur = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommandCrediteur = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommandCrediteur = new System.Data.OleDb.OleDbCommand();
            
            ((System.ComponentModel.ISupportInitialize)(this.dsDataSet2)).BeginInit();


            this.dsDataSet2.DataSetName = "dsLeden";
            this.dsDataSet2.Locale = new System.Globalization.CultureInfo("en-US");



            //=============================================================================================================
            // LID
            //=============================================================================================================
            this.daLid.DeleteCommand = this.oleDbDeleteCommandLid;
            this.daLid.InsertCommand = this.oleDbInsertCommandLid;
            this.daLid.SelectCommand = this.oleDbSelectCommandLid;
            this.daLid.UpdateCommand = this.oleDbUpdateCommandLid;

            this.daLid.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "tblLid", new System.Data.Common.DataColumnMapping[] {
            new System.Data.Common.DataColumnMapping("LidNr", "LidNr"),
            new System.Data.Common.DataColumnMapping("Voornaam", "Voornaam"),
            new System.Data.Common.DataColumnMapping("Achternaam", "Achternaam"),
            new System.Data.Common.DataColumnMapping("Tussenvoegsel","Tussenvoegsel"),
            new System.Data.Common.DataColumnMapping("Adres","Adres"),

            new System.Data.Common.DataColumnMapping("Woonplaats","Woonplaats"),
            new System.Data.Common.DataColumnMapping("Postcode","Postcode"),
            new System.Data.Common.DataColumnMapping("Mobiel","Mobiel"),
            new System.Data.Common.DataColumnMapping("Telefoon","Telefoon"),
            new System.Data.Common.DataColumnMapping("BondsNr","BondsNr"),

            new System.Data.Common.DataColumnMapping("Geslacht","Geslacht"),
            new System.Data.Common.DataColumnMapping("GeboorteDatum","GeboorteDatum"),
            new System.Data.Common.DataColumnMapping("Email1","Email1"),
            new System.Data.Common.DataColumnMapping("Email2","Email2"),
            new System.Data.Common.DataColumnMapping("IBAN","IBAN"),

            new System.Data.Common.DataColumnMapping("BIC","BIC"),
            new System.Data.Common.DataColumnMapping("BetaalWijze","BetaalWijze"),
            new System.Data.Common.DataColumnMapping("LidBond","LidBond"),
            new System.Data.Common.DataColumnMapping("CompGerechtigd","CompGerechtigd"),
            new System.Data.Common.DataColumnMapping("LidType","LidType"),

            new System.Data.Common.DataColumnMapping("LidVanaf","LidVanaf"),
            new System.Data.Common.DataColumnMapping("Opgezegd","Opgezegd"),
            new System.Data.Common.DataColumnMapping("LidTot","LidTot"),
            new System.Data.Common.DataColumnMapping("U_PasNr","U_PasNr"),
            new System.Data.Common.DataColumnMapping("PakketTot","PakketTot"),

            new System.Data.Common.DataColumnMapping("VastBedrag","VastBedrag"),
            new System.Data.Common.DataColumnMapping("Korting","Korting"),
            new System.Data.Common.DataColumnMapping("Medisch","Medisch"),
            new System.Data.Common.DataColumnMapping("Gemerkt","Gemerkt"),
            new System.Data.Common.DataColumnMapping("Ouder1_Naam","Ouder1_Naam"),

            new System.Data.Common.DataColumnMapping("Ouder1_Email1","Ouder1_Email1"),
            new System.Data.Common.DataColumnMapping("Ouder1_Email2","Ouder1_Email2"),
            new System.Data.Common.DataColumnMapping("Ouder1_Mobiel","Ouder1_Mobiel"),
            new System.Data.Common.DataColumnMapping("Ouder1_Telefoon","Ouder1_Telefoon"),
            new System.Data.Common.DataColumnMapping("Ouder2_Naam","Ouder2_Naam"),

            new System.Data.Common.DataColumnMapping("Ouder2_Email1","Ouder2_Email1"),
            new System.Data.Common.DataColumnMapping("Ouder2_Email2","Ouder2_Email2"),
            new System.Data.Common.DataColumnMapping("Ouder2_Mobiel","Ouder2_Mobiel"),
            new System.Data.Common.DataColumnMapping("Ouder2_Telefoon","Ouder2_Telefoon"),
            new System.Data.Common.DataColumnMapping("Geincasseerd","Geincasseerd"),

            new System.Data.Common.DataColumnMapping("ToernooiSpeler","ToernooiSpeler"),
            new System.Data.Common.DataColumnMapping("Extra2","Extra2"),
            new System.Data.Common.DataColumnMapping("Extra3","Extra3"),
            new System.Data.Common.DataColumnMapping("Extra4","Extra4"),
            new System.Data.Common.DataColumnMapping("Extra5","Extra5"),

            new System.Data.Common.DataColumnMapping("Licentie","Licentie"),
            new System.Data.Common.DataColumnMapping("ExtraB","ExtraB"),
            new System.Data.Common.DataColumnMapping("ExtraC","ExtraC"),
            new System.Data.Common.DataColumnMapping("ExtraD","ExtraD"),
            new System.Data.Common.DataColumnMapping("ExtraE","ExtraE")

    })});

            // 
            // Insert Command Lid
            // 
            string strInsertCommand = "INSERT INTO tblLid(";
            strInsertCommand += "LidNr";
            strInsertCommand += ", Voornaam";
            strInsertCommand += ", Achternaam";
            strInsertCommand += ", Tussenvoegsel";
            strInsertCommand += ", Adres";

            strInsertCommand += ", Woonplaats";
            strInsertCommand += ", Postcode";
            strInsertCommand += ", Mobiel";
            strInsertCommand += ", Telefoon";
            strInsertCommand += ", BondsNr";

            strInsertCommand += ", Geslacht";
            strInsertCommand += ", GeboorteDatum";
            strInsertCommand += ", Email1";
            strInsertCommand += ", Email2";
            strInsertCommand += ", IBAN";
            
            strInsertCommand += ", BIC";
            strInsertCommand += ", BetaalWijze";
            strInsertCommand += ", LidBond";
            strInsertCommand += ", CompGerechtigd";
            strInsertCommand += ", LidType";

            strInsertCommand += ", LidVanaf";
            strInsertCommand += ", Opgezegd";
            strInsertCommand += ", LidTot";
            strInsertCommand += ", U_PasNr";
            strInsertCommand += ", PakketTot";
            
            strInsertCommand += ", VastBedrag";
            strInsertCommand += ", Korting";
            strInsertCommand += ", Medisch";
            strInsertCommand += ", Gemerkt";
            strInsertCommand += ", Ouder1_Naam";

            strInsertCommand += ", Ouder1_Email1";
            strInsertCommand += ", Ouder1_Email2";
            strInsertCommand += ", Ouder1_Mobiel";
            strInsertCommand += ", Ouder1_Telefoon";
            strInsertCommand += ", Ouder2_Naam";

            strInsertCommand += ", Ouder2_Email1";
            strInsertCommand += ", Ouder2_Email2";
            strInsertCommand += ", Ouder2_Mobiel";
            strInsertCommand += ", Ouder2_Telefoon";
            strInsertCommand += ", Geincasseerd";

            strInsertCommand += ", ToernooiSpeler";
            strInsertCommand += ", Extra2";
            strInsertCommand += ", Extra3";
            strInsertCommand += ", Extra4";
            strInsertCommand += ", Extra5";
            
            strInsertCommand += ", Licentie";
            strInsertCommand += ", ExtraB";
            strInsertCommand += ", ExtraC";
            strInsertCommand += ", ExtraD";
            strInsertCommand += ", ExtraE";
            
            strInsertCommand += ") VALUES (";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?)";

            this.oleDbInsertCommandLid.CommandText = strInsertCommand;
            this.oleDbInsertCommandLid.Connection = this.cnLeden;
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("LidNr", OleDbType.Integer, 0, "LidNr"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Voornaam", OleDbType.VarWChar, 50, "Voornaam"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Achternaam", OleDbType.VarWChar, 50, "Achternaam"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Tussenvoegsel", OleDbType.VarWChar, 20, "Tussenvoegsel"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Adres", OleDbType.VarWChar, 100, "Adres"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Woonplaats", OleDbType.VarWChar, 100, "Woonplaats"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Postcode", OleDbType.VarWChar, 6, "Postcode"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Mobiel", OleDbType.VarWChar, 20, "Mobiel"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Telefoon", OleDbType.VarWChar, 20, "Telefoon"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("BondsNr", OleDbType.VarWChar, 7, "BondsNr"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Geslacht", OleDbType.VarWChar, 1, "Geslacht"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("GeboorteDatum", OleDbType.Date, 0, "GeboorteDatum"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Email1", OleDbType.VarWChar, 50, "Email1"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Email2", OleDbType.VarWChar, 50, "Email2"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 30, "IBAN"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 11, "BIC"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("BetaalWijze", OleDbType.VarWChar, 1, "BetaalWijze"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("LidBond", OleDbType.Integer, 0, "LidBond"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("CompGerechtigd", OleDbType.Integer, 0, "CompGerechtigd"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("LidType", OleDbType.VarWChar, 1, "LidType"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("LidVanaf", OleDbType.Date, 0, "LidVanaf"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Opgezegd", OleDbType.Integer, 0, "Opgezegd"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("LidTot", OleDbType.Date, 0, "LidTot"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("U_PasNr", OleDbType.VarWChar, 50, "U_PasNr"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("PakketTot", OleDbType.Date, 0, "PakketTot"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("VastBedrag", OleDbType.Currency, 0, "VastBedrag"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Korting", OleDbType.Currency, 0, "Korting"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Medisch", OleDbType.VarWChar, 255, "Medisch"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Gemerkt", OleDbType.Integer, 0, "Gemerkt"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Naam", OleDbType.VarWChar, 100, "Ouder1_Naam"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Email1", OleDbType.VarWChar, 50, "Ouder1_Email1"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Email2", OleDbType.VarWChar, 50, "Ouder1_Email2"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Mobiel", OleDbType.VarWChar, 20, "Ouder1_Mobiel"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Telefoon", OleDbType.VarWChar, 20, "Ouder1_Telefoon"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Naam", OleDbType.VarWChar, 100, "Ouder2_Naam"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Email1", OleDbType.VarWChar, 50, "Ouder2_Email1"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Email2", OleDbType.VarWChar, 50, "Ouder2_Email2"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Mobiel", OleDbType.VarWChar, 20, "Ouder2_Mobiel"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Telefoon", OleDbType.VarWChar, 20, "Ouder2_Telefoon"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Geincasseerd", OleDbType.Integer, 0, "Geincasseerd"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("ToernooiSpeler", OleDbType.Integer, 0, "ToernooiSpeler"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Extra2", OleDbType.Integer, 0, "Extra2"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Extra3", OleDbType.Integer, 0, "Extra3"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Extra4", OleDbType.Integer, 0, "Extra4"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Extra5", OleDbType.Integer, 0, "Extra5"));
            
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("Licentie", OleDbType.VarWChar, 50, "Licentie"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("ExtraB", OleDbType.VarWChar, 50, "ExtraB"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("ExtraC", OleDbType.VarWChar, 50, "ExtraC"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("ExtraD", OleDbType.VarWChar, 50, "ExtraD"));
            this.oleDbInsertCommandLid.Parameters.Add(new OleDbParameter("ExtraE", OleDbType.VarWChar, 50, "ExtraE"));
            
            // 
            // Select Command Lid
            // 
            this.oleDbSelectCommandLid.CommandText = "SELECT LidNr,Voornaam,Achternaam ,Tussenvoegsel ,Adres ,Woonplaats ,Postcode ," +
"Mobiel ,Telefoon ,BondsNr ,Geslacht, GeboorteDatum ,Email1 ,Email2 ,IBAN ,BIC ,BetaalWijze ,LidBond ," +
"CompGerechtigd ,LidType ,LidVanaf,Opgezegd,LidTot,U_PasNr,PakketTot,VastBedrag,Korting,Medisch ," +
"Gemerkt ,Ouder1_Naam ,Ouder1_Email1 ,Ouder1_Email2 ,Ouder1_Mobiel ,Ouder1_Telefoon ," +
"Ouder2_Naam ,Ouder2_Email1 ,Ouder2_Email2 ,Ouder2_Mobiel ,Ouder2_Telefoon,Geincasseerd, " +
"ToernooiSpeler, Extra2, Extra3, Extra4, Extra5, Licentie, ExtraB, ExtraC, ExtraD, ExtraE " +
"FROM tblLid ORDER BY Lidnr";
            this.oleDbSelectCommandLid.Connection = this.cnLeden;

            // 
            // Update Command Lid
            // 
            string strUpdateCommand = "UPDATE tblLid SET ";
            strUpdateCommand += " Voornaam = ?";
            strUpdateCommand += ", Achternaam = ?";
            strUpdateCommand += ", Tussenvoegsel = ?";
            strUpdateCommand += ", Adres = ?";
            strUpdateCommand += ", Woonplaats = ?";
            strUpdateCommand += ", Postcode = ?";
            strUpdateCommand += ", Mobiel = ?";
            strUpdateCommand += ", Telefoon = ?";
            strUpdateCommand += ", BondsNr = ?";
            strUpdateCommand += ", Geslacht = ?";
            strUpdateCommand += ", GeboorteDatum = ?";
            strUpdateCommand += ", Email1= ?";
            strUpdateCommand += ", Email2 = ?";
            strUpdateCommand += ", IBAN = ?";
            strUpdateCommand += ", BIC = ?";
            strUpdateCommand += ", BetaalWijze = ?";
            strUpdateCommand += ", LidBond = ?";
            strUpdateCommand += ", CompGerechtigd = ?";
            strUpdateCommand += ", LidType = ?";
            strUpdateCommand += ", LidVanaf = ?";
            strUpdateCommand += ", Opgezegd = ?";
            strUpdateCommand += ", LidTot = ?";
            strUpdateCommand += ", U_PasNr = ?";
            strUpdateCommand += ", PakketTot= ?";
            strUpdateCommand += ", VastBedrag= ?";
            strUpdateCommand += ", Korting= ?";
            strUpdateCommand += ", Medisch= ?";
            strUpdateCommand += ", Gemerkt= ?";
            strUpdateCommand += ", Ouder1_Naam= ?";
            strUpdateCommand += ", Ouder1_Email1= ?";
            strUpdateCommand += ", Ouder1_Email2= ?";
            strUpdateCommand += ", Ouder1_Mobiel= ?";
            strUpdateCommand += ", Ouder1_Telefoon= ?";
            strUpdateCommand += ", Ouder2_Naam = ?";
            strUpdateCommand += ", Ouder2_Email1 = ?";
            strUpdateCommand += ", Ouder2_Email2 = ?";
            strUpdateCommand += ", Ouder2_Mobiel= ?";
            strUpdateCommand += ", Ouder2_Telefoon = ?";
            strUpdateCommand += ", Geincasseerd = ?";
            strUpdateCommand += ", ToernooiSpeler = ?";
            strUpdateCommand += ", Extra2 = ?";
            strUpdateCommand += ", Extra3 = ?";
            strUpdateCommand += ", Extra4 = ?";
            strUpdateCommand += ", Extra5 = ?";
            strUpdateCommand += ", Licentie = ?";
            strUpdateCommand += ", ExtraB = ?";
            strUpdateCommand += ", ExtraC = ?";
            strUpdateCommand += ", ExtraD = ?";
            strUpdateCommand += ", ExtraE = ?";
            strUpdateCommand += " WHERE (LidNr = ?)";

            this.oleDbUpdateCommandLid.CommandText = strUpdateCommand;
            this.oleDbUpdateCommandLid.Connection = this.cnLeden;
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Voornaam", OleDbType.VarWChar, 50, "Voornaam"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Achternaam", OleDbType.VarWChar, 50, "Achternaam"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Tussenvoegsel", OleDbType.VarWChar, 20, "Tussenvoegsel"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Adres", OleDbType.VarWChar, 100, "Adres"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Woonplaats", OleDbType.VarWChar, 100, "Woonplaats"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Postcode", OleDbType.VarWChar, 6, "Postcode"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Mobiel", OleDbType.VarWChar, 20, "Mobiel"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Telefoon", OleDbType.VarWChar, 20, "Telefoon"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("BondsNr", OleDbType.VarWChar, 7, "BondsNr"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Geslacht", OleDbType.VarWChar, 1, "Geslacht"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("GeboorteDatum", OleDbType.Date, 0, "GeboorteDatum"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Email1", OleDbType.VarWChar, 50, "Email1"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Email2", OleDbType.VarWChar, 50, "Email2"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 30, "IBAN"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 11, "BIC"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("BetaalWijze", OleDbType.VarWChar, 1, "BetaalWijze"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("LidBond", OleDbType.Integer, 0, "LidBond"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("CompGerechtigd", OleDbType.Integer, 0, "CompGerechtigd"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("LidType", OleDbType.VarWChar, 1, "LidType"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("LidVanaf", OleDbType.Date, 0, "LidVanaf"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Opgezegd", OleDbType.Integer, 0, "Opgezegd"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("LidTot", OleDbType.Date, 0, "LidTot"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("U_PasNr", OleDbType.VarWChar, 50, "U_PasNr"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("PakketTot", OleDbType.Date, 0, "PakketTot"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("VastBedrag", OleDbType.Currency, 0, "VastBedrag"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Korting", OleDbType.Currency, 0, "Korting"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Medisch", OleDbType.VarWChar, 255, "Medisch"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Gemerkt", OleDbType.Integer, 0, "Gemerkt"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Naam", OleDbType.VarWChar, 100, "Ouder1_Naam"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Email1", OleDbType.VarWChar, 50, "Ouder1_Email1"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Email2", OleDbType.VarWChar, 50, "Ouder1_Email2"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Mobiel", OleDbType.VarWChar, 20, "Ouder1_Mobiel"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder1_Telefoon", OleDbType.VarWChar, 20, "Ouder1_Telefoon"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Naam", OleDbType.VarWChar, 100, "Ouder2_Naam"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Email1", OleDbType.VarWChar, 50, "Ouder2_Email1"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Email2", OleDbType.VarWChar, 50, "Ouder2_Email2"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Mobiel", OleDbType.VarWChar, 20, "Ouder2_Mobiel"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Ouder2_Telefoon", OleDbType.VarWChar, 20, "Ouder2_Telefoon"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Geincasseerd", OleDbType.Integer, 0, "Geincasseerd"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("ToernooiSpeler", OleDbType.Integer, 0, "ToernooiSpeler"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Extra2", OleDbType.Integer, 0, "Extra2"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Extra3", OleDbType.Integer, 0, "Extra3"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Extra4", OleDbType.Integer, 0, "Extra4"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Extra5", OleDbType.Integer, 0, "Extra5"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("Licentie", OleDbType.VarWChar, 50, "Licentie"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("ExtraB", OleDbType.VarWChar, 50, "ExtraB"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("ExtraC", OleDbType.VarWChar, 50, "ExtraC"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("ExtraD", OleDbType.VarWChar, 50, "ExtraD"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("ExtraE", OleDbType.VarWChar, 50, "ExtraE"));
            this.oleDbUpdateCommandLid.Parameters.Add(new OleDbParameter("LidNr", OleDbType.Integer, 0, "LidNr"));

            this.oleDbDeleteCommandLid.CommandText = @"DELETE FROM tblLid WHERE (Lidnr = ? )";
            this.oleDbDeleteCommandLid.Connection = this.cnLeden;
            this.oleDbDeleteCommandLid.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            
            //=============================================================================================================
            // REKENING
            //=============================================================================================================

            this.daRekening.DeleteCommand = this.oleDbDeleteCommandRekening;
            this.daRekening.InsertCommand = this.oleDbInsertCommandRekening;
            this.daRekening.SelectCommand = this.oleDbSelectCommandRekening;
            this.daRekening.UpdateCommand = this.oleDbUpdateCommandRekening;




            this.daRekening.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "tblRekening", new System.Data.Common.DataColumnMapping[] {


           new System.Data.Common.DataColumnMapping("Lidnr", "Lidnr"),
           new System.Data.Common.DataColumnMapping("RekeningSeqNr", "RekeningSeqNr"),
           new System.Data.Common.DataColumnMapping("IBAN", "IBAN"),
           new System.Data.Common.DataColumnMapping("BIC", "BIC"),
           new System.Data.Common.DataColumnMapping("TotaalBedrag", "TotaalBedrag"),
           
           new System.Data.Common.DataColumnMapping("ContributieBedrag", "ContributieBedrag"),
           new System.Data.Common.DataColumnMapping("Bondsbijdrage", "Bondsbijdrage"),
           new System.Data.Common.DataColumnMapping("CompetitieBijdrage", "CompetitieBijdrage"),
           new System.Data.Common.DataColumnMapping("Korting", "Korting"),
           new System.Data.Common.DataColumnMapping("ExtraBedrag", "ExtraBedrag"),
           
           new System.Data.Common.DataColumnMapping("TypeRekening", "TypeRekening"),
           new System.Data.Common.DataColumnMapping("Omschrijving", "Omschrijving"),
           new System.Data.Common.DataColumnMapping("AanmaakDatum", "AanmaakDatum"),
           new System.Data.Common.DataColumnMapping("PeilDatum", "PeilDatum"),
           new System.Data.Common.DataColumnMapping("VerstuurdDatum", "VerstuurdDatum"),
           
           new System.Data.Common.DataColumnMapping("Verstuurd", "Verstuurd"),
           new System.Data.Common.DataColumnMapping("Gestorneerd", "Gestorneerd"),
           new System.Data.Common.DataColumnMapping("KostenStornering", "KostenStornering"),
           new System.Data.Common.DataColumnMapping("MailOnderdrukken", "MailOnderdrukken"),
           new System.Data.Common.DataColumnMapping("Extra1", "Extra1"),
           
           new System.Data.Common.DataColumnMapping("ExtraA", "ExtraA")  
        })});

            // 
            // Insert Command Rekening
            // 
            strInsertCommand = "INSERT INTO tblRekening(";

            strInsertCommand += "Lidnr";
            strInsertCommand += ", RekeningSeqNr";
            strInsertCommand += ", IBAN";
            strInsertCommand += ", BIC";
            strInsertCommand += ", TotaalBedrag";

            strInsertCommand += ", ContributieBedrag";
            strInsertCommand += ", Bondsbijdrage";
            strInsertCommand += ", CompetitieBijdrage";
            strInsertCommand += ", Korting";
            strInsertCommand += ", ExtraBedrag";

            strInsertCommand += ", TypeRekening";
            strInsertCommand += ", Omschrijving";
            strInsertCommand += ", AanmaakDatum";
            strInsertCommand += ", PeilDatum";
            strInsertCommand += ", VerstuurdDatum";

            strInsertCommand += ", Verstuurd";
            strInsertCommand += ", Gestorneerd";
            strInsertCommand += ", KostenStornering";
            strInsertCommand += ", MailOnderdrukken";
            strInsertCommand += ", Extra1";

            strInsertCommand += ", ExtraA";

            strInsertCommand += ") VALUES (";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,";
            strInsertCommand += "?,?,?,?,?, ?,?,?,?,?,?)";

            this.oleDbInsertCommandRekening.CommandText = strInsertCommand;
            this.oleDbInsertCommandRekening.Connection = this.cnLeden;

            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("RekeningSeqNr", OleDbType.Integer, 0, "RekeningSeqNr"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 0, "IBAN"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 0, "BIC"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("TotaalBedrag", OleDbType.Currency, 0, "TotaalBedrag"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("ContributieBedrag", OleDbType.Currency, 0, "ContributieBedrag"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Bondsbijdrage", OleDbType.Currency, 0, "Bondsbijdrage"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("CompetitieBijdrage", OleDbType.Currency, 0, "CompetitieBijdrage"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Korting", OleDbType.Currency, 0, "Korting"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("ExtraBedrag", OleDbType.Currency, 0, "ExtraBedrag"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("TypeRekening", OleDbType.VarWChar, 0, "TypeRekening"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("AanmaakDatum", OleDbType.Date, 0, "AanmaakDatum"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("PeilDatum", OleDbType.Date, 0, "PeilDatum"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("VerstuurdDatum", OleDbType.Date, 0, "VerstuurdDatum"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Verstuurd", OleDbType.Integer, 0, "Verstuurd"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Gestorneerd", OleDbType.Integer, 0, "Gestorneerd"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("KostenStornering", OleDbType.Currency, 0, "KostenStornering"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("MailOnderdrukken", OleDbType.Integer, 0, "MailOnderdrukken"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("Extra1", OleDbType.Integer, 0, "Extra1"));
            this.oleDbInsertCommandRekening.Parameters.Add(new OleDbParameter("ExtraA", OleDbType.VarWChar, 0, "ExtraA"));

            // 
            // Select Command Rekening
            // 
            this.oleDbSelectCommandRekening.CommandText = "SELECT ";
            this.oleDbSelectCommandRekening.CommandText += "Lidnr, ";
            this.oleDbSelectCommandRekening.CommandText += "RekeningSeqNr, ";
            this.oleDbSelectCommandRekening.CommandText += "IBAN, ";
            this.oleDbSelectCommandRekening.CommandText += "BIC, ";
            this.oleDbSelectCommandRekening.CommandText += "TotaalBedrag, ";

            this.oleDbSelectCommandRekening.CommandText += "ContributieBedrag, ";
            this.oleDbSelectCommandRekening.CommandText += "Bondsbijdrage, ";
            this.oleDbSelectCommandRekening.CommandText += "CompetitieBijdrage, ";
            this.oleDbSelectCommandRekening.CommandText += "Korting, ";
            this.oleDbSelectCommandRekening.CommandText += "ExtraBedrag, ";

            this.oleDbSelectCommandRekening.CommandText += "TypeRekening, ";
            this.oleDbSelectCommandRekening.CommandText += "Omschrijving, ";
            this.oleDbSelectCommandRekening.CommandText += "AanmaakDatum, ";
            this.oleDbSelectCommandRekening.CommandText += "PeilDatum, ";
            this.oleDbSelectCommandRekening.CommandText += "VerstuurdDatum, ";

            this.oleDbSelectCommandRekening.CommandText += "Verstuurd, ";
            this.oleDbSelectCommandRekening.CommandText += "Gestorneerd, ";
            this.oleDbSelectCommandRekening.CommandText += "KostenStornering, ";
            this.oleDbSelectCommandRekening.CommandText += "MailOnderdrukken, ";
            this.oleDbSelectCommandRekening.CommandText += "Extra1, ";
            this.oleDbSelectCommandRekening.CommandText += "ExtraA ";

            this.oleDbSelectCommandRekening.CommandText += "FROM tblRekening ORDER BY Lidnr,RekeningSeqNr";

            this.oleDbSelectCommandRekening.Connection = this.cnLeden;

            // 
            // Update Command Rekening
            // 
            strUpdateCommand = "UPDATE tblRekening SET ";

            strUpdateCommand += "IBAN = ?";
            strUpdateCommand += ", BIC = ?";
            strUpdateCommand += ", TotaalBedrag = ?";

            strUpdateCommand += ", ContributieBedrag = ?";
            strUpdateCommand += ", Bondsbijdrage = ?";
            strUpdateCommand += ", CompetitieBijdrage = ?";
            strUpdateCommand += ", Korting = ?";
            strUpdateCommand += ", ExtraBedrag = ?";

            strUpdateCommand += ", TypeRekening = ?";
            strUpdateCommand += ", Omschrijving = ?";
            strUpdateCommand += ", AanmaakDatum = ?";
            strUpdateCommand += ", PeilDatum = ?";
            strUpdateCommand += ", VerstuurdDatum = ?";

            strUpdateCommand += ", Verstuurd = ?";
            strUpdateCommand += ", Gestorneerd = ?";
            strUpdateCommand += ", KostenStornering = ?";
            strUpdateCommand += ", MailOnderdrukken = ?";
            strUpdateCommand += ", Extra1 = ?";
            strUpdateCommand += ", ExtraA = ?";

            strUpdateCommand += " WHERE (Lidnr = ?) AND (RekeningSeqNr = ?)";

            this.oleDbUpdateCommandRekening.CommandText = strUpdateCommand;
            this.oleDbUpdateCommandRekening.Connection = this.cnLeden;

            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 0, "IBAN"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 0, "BIC"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("TotaalBedrag", OleDbType.Currency, 0, "TotaalBedrag"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("ContributieBedrag", OleDbType.Currency, 0, "ContributieBedrag"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Bondsbijdrage", OleDbType.Currency, 0, "Bondsbijdrage"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("CompetitieBijdrage", OleDbType.Currency, 0, "CompetitieBijdrage"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Korting", OleDbType.Currency, 0, "Korting"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("ExtraBedrag", OleDbType.Currency, 0, "ExtraBedrag"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("TypeRekening", OleDbType.VarWChar, 0, "TypeRekening"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("AanmaakDatum", OleDbType.Date, 0, "AanmaakDatum"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("PeilDatum", OleDbType.Date, 0, "PeilDatum"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("VerstuurdDatum", OleDbType.Date, 0, "VerstuurdDatum"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Verstuurd", OleDbType.Integer, 0, "Verstuurd"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Gestorneerd", OleDbType.Integer, 0, "Gestorneerd"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("KostenStornering", OleDbType.Currency, 0, "KostenStornering"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("MailOnderdrukken", OleDbType.Integer, 0, "MailOnderdrukken"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Extra1", OleDbType.Integer, 0, "Extra1"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("ExtraA", OleDbType.VarWChar, 0, "ExtraA"));

            
            
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbUpdateCommandRekening.Parameters.Add(new OleDbParameter("RekeningSeqNr", OleDbType.Integer, 0, "RekeningSeqNr"));


            this.oleDbDeleteCommandRekening.CommandText = @"DELETE FROM tblRekening WHERE (Lidnr = ? AND RekeningSeqNr = ?)";
            this.oleDbDeleteCommandRekening.Connection = this.cnLeden;
            this.oleDbDeleteCommandRekening.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbDeleteCommandRekening.Parameters.Add(new OleDbParameter("RekeningSeqNr", OleDbType.Integer, 0, "RekeningSeqNr"));

        
 //=============================================================================================================
 // CompResult
 //=============================================================================================================

            this.daCompResult.DeleteCommand = this.oleDbDeleteCommandCompResult;
            this.daCompResult.InsertCommand = this.oleDbInsertCommandCompResult;
            this.daCompResult.SelectCommand = this.oleDbSelectCommandCompResult;
            this.daCompResult.UpdateCommand = this.oleDbUpdateCommandCompResult;




            this.daCompResult.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "tblCompResult", new System.Data.Common.DataColumnMapping[] {


           new System.Data.Common.DataColumnMapping("Lidnr", "Lidnr"),
           new System.Data.Common.DataColumnMapping("Jaar", "Jaar"),
           new System.Data.Common.DataColumnMapping("Seizoen", "Seizoen"),
           new System.Data.Common.DataColumnMapping("Klasse", "Klasse"),
           new System.Data.Common.DataColumnMapping("Percentage", "Percentage"),
  
        })});

            // 
            // Insert Command CompResult
            // 
            strInsertCommand = "INSERT INTO tblCompResult(";

            strInsertCommand += "Lidnr";
            strInsertCommand += ", Jaar";
            strInsertCommand += ", Seizoen";
            strInsertCommand += ", Klasse";
            strInsertCommand += ", Percentage";

            strInsertCommand += ") VALUES (";
            strInsertCommand += "?,?,?,?,?)";

            this.oleDbInsertCommandCompResult.CommandText = strInsertCommand;
            this.oleDbInsertCommandCompResult.Connection = this.cnLeden;

            this.oleDbInsertCommandCompResult.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbInsertCommandCompResult.Parameters.Add(new OleDbParameter("Jaar", OleDbType.Integer, 0, "Jaar"));
            this.oleDbInsertCommandCompResult.Parameters.Add(new OleDbParameter("Seizoen", OleDbType.VarWChar, 1, "Seizoen"));
            this.oleDbInsertCommandCompResult.Parameters.Add(new OleDbParameter("Klasse", OleDbType.VarWChar, 2, "Klasse"));
            this.oleDbInsertCommandCompResult.Parameters.Add(new OleDbParameter("Percentage", OleDbType.Integer, 0, "Percentage"));

            // 
            // Select Command CompResult
            // 
            this.oleDbSelectCommandCompResult.CommandText = "SELECT ";
            this.oleDbSelectCommandCompResult.CommandText += "Lidnr, ";
            this.oleDbSelectCommandCompResult.CommandText += "Jaar, ";
            this.oleDbSelectCommandCompResult.CommandText += "Seizoen, ";
            this.oleDbSelectCommandCompResult.CommandText += "Klasse, ";
            this.oleDbSelectCommandCompResult.CommandText += "Percentage ";

            this.oleDbSelectCommandCompResult.CommandText += "FROM tblCompResult ORDER BY Lidnr,Jaar";

            this.oleDbSelectCommandCompResult.Connection = this.cnLeden;

            // 
            // Update Command CompResult
            // 
            strUpdateCommand = "UPDATE tblCompResult SET ";

            strUpdateCommand += "Klasse = ?";
            strUpdateCommand += ", Percentage = ?";
            
            strUpdateCommand += " WHERE (Lidnr = ?) AND (Jaar = ?) AND (Seizoen = ?)";

            this.oleDbUpdateCommandCompResult.CommandText = strUpdateCommand;
            this.oleDbUpdateCommandCompResult.Connection = this.cnLeden;

            this.oleDbUpdateCommandCompResult.Parameters.Add(new OleDbParameter("Klasse", OleDbType.VarWChar, 2, "Klasse"));
            this.oleDbUpdateCommandCompResult.Parameters.Add(new OleDbParameter("Percentage", OleDbType.Integer, 0, "Percentage"));
            this.oleDbUpdateCommandCompResult.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbUpdateCommandCompResult.Parameters.Add(new OleDbParameter("Jaar", OleDbType.Integer, 0, "Jaar"));
            this.oleDbUpdateCommandCompResult.Parameters.Add(new OleDbParameter("Seizoen", OleDbType.VarWChar, 1, "Seizoen"));

            this.oleDbDeleteCommandCompResult.CommandText = @"DELETE FROM tblCompResult WHERE (Lidnr = ?) AND (Jaar = ?) AND (Seizoen = ?)";
            this.oleDbDeleteCommandCompResult.Connection = this.cnLeden;
            this.oleDbDeleteCommandCompResult.Parameters.Add(new OleDbParameter("Lidnr", OleDbType.Integer, 0, "Lidnr"));
            this.oleDbDeleteCommandCompResult.Parameters.Add(new OleDbParameter("Jaar", OleDbType.Integer, 0, "Jaar"));
            this.oleDbDeleteCommandCompResult.Parameters.Add(new OleDbParameter("Seizoen", OleDbType.VarWChar, 0, "Seizoen"));
            
 //=============================================================================================================
 // Betaling
 //=============================================================================================================

            this.daBetaling.DeleteCommand = this.oleDbDeleteCommandBetaling;
            this.daBetaling.InsertCommand = this.oleDbInsertCommandBetaling;
            this.daBetaling.SelectCommand = this.oleDbSelectCommandBetaling;
            this.daBetaling.UpdateCommand = this.oleDbUpdateCommandBetaling;

            this.daBetaling.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "tblBetaling", new System.Data.Common.DataColumnMapping[] {

           new System.Data.Common.DataColumnMapping("BetalingsSeqNr","BetalingsSeqNr"),
           new System.Data.Common.DataColumnMapping("IBAN_Creditor","IBAN_Creditor"),
           new System.Data.Common.DataColumnMapping("BIC_Creditor","BIC_Creditor"),
           new System.Data.Common.DataColumnMapping("Omschrijving","Omschrijving"),
           new System.Data.Common.DataColumnMapping("EndToEndId","EndToEndId"),
           new System.Data.Common.DataColumnMapping("TotaalBedrag","TotaalBedrag"),
           new System.Data.Common.DataColumnMapping("TypeBetaling","TypeBetaling"),
           new System.Data.Common.DataColumnMapping("AanmaakDatum","AanmaakDatum"),
           new System.Data.Common.DataColumnMapping("Verstuurd","Verstuurd"),
           new System.Data.Common.DataColumnMapping("VerstuurdDatum","VerstuurdDatum"),
           new System.Data.Common.DataColumnMapping("GewensteVerwerkingsDatum","GewensteVerwerkingsDatum"),
           new System.Data.Common.DataColumnMapping("Extra1","Extra1"),
           new System.Data.Common.DataColumnMapping("Extra2","Extra2"),
           new System.Data.Common.DataColumnMapping("Extra3","Extra3"),
           new System.Data.Common.DataColumnMapping("ExtraA","ExtraA"),
           new System.Data.Common.DataColumnMapping("ExtraB","ExtraB"),
           new System.Data.Common.DataColumnMapping("ExtraC","ExtraC"),

        })});

            // 
            // Insert Command Betaling
            // 
            strInsertCommand = "INSERT INTO tblBetaling(";
            strInsertCommand += "BetalingsSeqNr";
            strInsertCommand += ", IBAN_Creditor";
            strInsertCommand += ", BIC_Creditor";
            strInsertCommand += ", Omschrijving";
            strInsertCommand += ", EndToEndId";

            strInsertCommand += ", TotaalBedrag";
            strInsertCommand += ", TypeBetaling";
            strInsertCommand += ", AanmaakDatum";
            strInsertCommand += ", Verstuurd";
            strInsertCommand += ", VerstuurdDatum";
            
            strInsertCommand += ", GewensteVerwerkingsDatum";
            strInsertCommand += ", Extra1";
            strInsertCommand += ", Extra2";
            strInsertCommand += ", Extra3";
            strInsertCommand += ", ExtraA";
            
            strInsertCommand += ", ExtraB";
            strInsertCommand += ", ExtraC";

            strInsertCommand += ") VALUES (";
            strInsertCommand += "?,?,?,?,?  ,?,?,?,?,?  ,?,?,?,?,?   ,?,?)";

            this.oleDbInsertCommandBetaling.CommandText = strInsertCommand;
            this.oleDbInsertCommandBetaling.Connection = this.cnLeden;

            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("BetalingsSeqNr", OleDbType.Integer, 0, "BetalingsSeqNr"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("IBAN_Creditor", OleDbType.VarWChar, 0, "IBAN_Creditor"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("BIC_Creditor", OleDbType.VarWChar, 0, "BIC_Creditor"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("EndToEndId", OleDbType.VarWChar, 0, "EndToEndId"));

            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("TotaalBedrag", OleDbType.Currency, 0, "TotaalBedrag"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("TypeBetaling", OleDbType.Integer, 0, "TypeBetaling"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("AanmaakDatum", OleDbType.Date, 0, "AanmaakDatum"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("Verstuurd", OleDbType.Integer, 0, "Verstuurd"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("VerstuurdDatum", OleDbType.Date, 0, "VerstuurdDatum"));

            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("GewensteVerwerkingsDatum", OleDbType.Date, 0, "GewensteVerwerkingsDatum"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("Extra1", OleDbType.Integer, 0, "Extra1"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("Extra2", OleDbType.Integer, 0, "Extra2"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("Extra3", OleDbType.Integer, 0, "Extra3"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("ExtraA", OleDbType.VarWChar, 0, "ExtraA"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("ExtraB", OleDbType.VarWChar, 0, "ExtraB"));
            this.oleDbInsertCommandBetaling.Parameters.Add(new OleDbParameter("ExtraC", OleDbType.VarWChar, 0, "ExtraC"));

            // 
            // Select Command Betaling
            // 
            this.oleDbSelectCommandBetaling.CommandText = "SELECT ";
            this.oleDbSelectCommandBetaling.CommandText += "BetalingsSeqNr,";
            this.oleDbSelectCommandBetaling.CommandText += "IBAN_Creditor,";
            this.oleDbSelectCommandBetaling.CommandText += "BIC_Creditor,";
            this.oleDbSelectCommandBetaling.CommandText += "Omschrijving,";
            this.oleDbSelectCommandBetaling.CommandText += "EndToEndId,";

            this.oleDbSelectCommandBetaling.CommandText += "TotaalBedrag,";
            this.oleDbSelectCommandBetaling.CommandText += "TypeBetaling,";
            this.oleDbSelectCommandBetaling.CommandText += "AanmaakDatum,";
            this.oleDbSelectCommandBetaling.CommandText += "AanmaakDatum,";
            this.oleDbSelectCommandBetaling.CommandText += "Verstuurd,";
            this.oleDbSelectCommandBetaling.CommandText += "VerstuurdDatum,";
            this.oleDbSelectCommandBetaling.CommandText += "GewensteVerwerkingsDatum,";
            this.oleDbSelectCommandBetaling.CommandText += "Extra1,";
            this.oleDbSelectCommandBetaling.CommandText += "Extra2,";
            this.oleDbSelectCommandBetaling.CommandText += "Extra3,";
            this.oleDbSelectCommandBetaling.CommandText += "ExtraA,";
            this.oleDbSelectCommandBetaling.CommandText += "ExtraB,";
            this.oleDbSelectCommandBetaling.CommandText += "ExtraC";

            this.oleDbSelectCommandBetaling.CommandText += " FROM tblBetaling ORDER BY BetalingsSeqNr";

            this.oleDbSelectCommandBetaling.Connection = this.cnLeden;

            // 
            // Update Command Betaling
            // 
            strUpdateCommand = "UPDATE tblBetaling SET ";

            strUpdateCommand += "IBAN_Creditor= ?";
            strUpdateCommand += ", BIC_Creditor= ?";
            strUpdateCommand += ", Omschrijving= ?";
            strUpdateCommand += ", EndToEndId= ?";

            strUpdateCommand += ", TotaalBedrag= ?";
            strUpdateCommand += ", TypeBetaling= ?";
            strUpdateCommand += ", AanmaakDatum= ?";
            strUpdateCommand += ", Verstuurd= ?";
            strUpdateCommand += ", VerstuurdDatum= ?";
            strUpdateCommand += ", GewensteVerwerkingsDatum= ?";
            strUpdateCommand += ", Extra1= ?";
            strUpdateCommand += ", Extra2= ?";
            strUpdateCommand += ", Extra3= ?";
            strUpdateCommand += ", ExtraA= ?";
            strUpdateCommand += ", ExtraB= ?";
            strUpdateCommand += ", ExtraC= ?";

            strUpdateCommand += " WHERE (BetalingsSeqNr = ?)";

            this.oleDbUpdateCommandBetaling.CommandText = strUpdateCommand;
            this.oleDbUpdateCommandBetaling.Connection = this.cnLeden;

            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("IBAN_Creditor", OleDbType.VarWChar, 0, "IBAN_Creditor"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("BIC_Creditor", OleDbType.VarWChar, 0, "BIC_Creditor"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("EndToEndId", OleDbType.VarWChar, 0, "EndToEndId"));

            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("TotaalBedrag", OleDbType.Currency, 0, "TotaalBedrag"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("TypeBetaling", OleDbType.Integer, 0, "TypeBetaling"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("AanmaakDatum", OleDbType.Date, 0, "AanmaakDatum"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("Verstuurd", OleDbType.Integer, 0, "Verstuurd"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("VerstuurdDatum", OleDbType.Date, 0, "VerstuurdDatum"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("GewensteVerwerkingsDatum", OleDbType.Date, 0, "GewensteVerwerkingsDatum"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("Extra1", OleDbType.Integer, 0, "Extra1"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("Extra2", OleDbType.Integer, 0, "Extra2"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("Extra3", OleDbType.Integer, 0, "Extra3"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("ExtraA", OleDbType.VarWChar, 0, "ExtraA"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("ExtraB", OleDbType.VarWChar, 0, "ExtraB"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("ExtraC", OleDbType.VarWChar, 0, "ExtraC"));
            this.oleDbUpdateCommandBetaling.Parameters.Add(new OleDbParameter("BetalingsSeqNr", OleDbType.Integer, 0, "BetalingsSeqNr"));

            this.oleDbDeleteCommandBetaling.CommandText = @"DELETE FROM tblBetaling WHERE (BetalingsSeqNr = ?)";
            this.oleDbDeleteCommandBetaling.Connection = this.cnLeden;
            this.oleDbDeleteCommandBetaling.Parameters.Add(new OleDbParameter("BetalingsSeqNr", OleDbType.Integer, 0, "BetalingsSeqNr"));

            //=============================================================================================================
            // Crediteur
            //=============================================================================================================

            this.daCrediteur.DeleteCommand = this.oleDbDeleteCommandCrediteur;
            this.daCrediteur.InsertCommand = this.oleDbInsertCommandCrediteur;
            this.daCrediteur.SelectCommand = this.oleDbSelectCommandCrediteur;
            this.daCrediteur.UpdateCommand = this.oleDbUpdateCommandCrediteur;

            this.daCrediteur.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "tblCrediteur", new System.Data.Common.DataColumnMapping[] {

           new System.Data.Common.DataColumnMapping("Crediteur","Crediteur"),
           new System.Data.Common.DataColumnMapping("Naam","Naam"),
           new System.Data.Common.DataColumnMapping("IBAN","IBAN"),
           new System.Data.Common.DataColumnMapping("BIC","BIC"),
           new System.Data.Common.DataColumnMapping("Omschrijving","Omschrijving"),

        })});

            // 
            // Insert Command Crediteur
            // 
            strInsertCommand = "INSERT INTO tblCrediteur(";
            strInsertCommand += "Crediteur";
            strInsertCommand += ", Naam";
            strInsertCommand += ", IBAN";
            strInsertCommand += ", BIC";
            strInsertCommand += ", Omschrijving";

            strInsertCommand += ") VALUES (";
            strInsertCommand += "?,?,?,?,?)";

            this.oleDbInsertCommandCrediteur.CommandText = strInsertCommand;
            this.oleDbInsertCommandCrediteur.Connection = this.cnLeden;

            this.oleDbInsertCommandCrediteur.Parameters.Add(new OleDbParameter("Crediteur", OleDbType.VarWChar, 0, "Crediteur"));
            this.oleDbInsertCommandCrediteur.Parameters.Add(new OleDbParameter("Naam", OleDbType.VarWChar, 0, "Naam"));
            this.oleDbInsertCommandCrediteur.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 0, "IBAN"));
            this.oleDbInsertCommandCrediteur.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 0, "BIC"));
            this.oleDbInsertCommandCrediteur.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));

            // 
            // Select Command Crediteur
            // 
            this.oleDbSelectCommandCrediteur.CommandText = "SELECT ";
            this.oleDbSelectCommandCrediteur.CommandText += "Crediteur,";
            this.oleDbSelectCommandCrediteur.CommandText += "Naam,";
            this.oleDbSelectCommandCrediteur.CommandText += "IBAN,";
            this.oleDbSelectCommandCrediteur.CommandText += "BIC,";
            this.oleDbSelectCommandCrediteur.CommandText += "Omschrijving";

            this.oleDbSelectCommandCrediteur.CommandText += " FROM tblCrediteur ORDER BY Crediteur";

            this.oleDbSelectCommandCrediteur.Connection = this.cnLeden;

            // 
            // Update Command Crediteur
            // 
            strUpdateCommand = "UPDATE tblCrediteur SET ";

            strUpdateCommand += "Naam= ?";
            strUpdateCommand += ", IBAN= ?";
            strUpdateCommand += ", BIC= ?";
            strUpdateCommand += ", Omschrijving= ?";

            strUpdateCommand += " WHERE (Crediteur = ?)";

            this.oleDbUpdateCommandCrediteur.CommandText = strUpdateCommand;
            this.oleDbUpdateCommandCrediteur.Connection = this.cnLeden;

            this.oleDbUpdateCommandCrediteur.Parameters.Add(new OleDbParameter("Naam", OleDbType.VarWChar, 0, "Naam"));
            this.oleDbUpdateCommandCrediteur.Parameters.Add(new OleDbParameter("IBAN", OleDbType.VarWChar, 0, "IBAN"));
            this.oleDbUpdateCommandCrediteur.Parameters.Add(new OleDbParameter("BIC", OleDbType.VarWChar, 0, "BIC"));
            this.oleDbUpdateCommandCrediteur.Parameters.Add(new OleDbParameter("Omschrijving", OleDbType.VarWChar, 0, "Omschrijving"));
            this.oleDbUpdateCommandCrediteur.Parameters.Add(new OleDbParameter("Crediteur", OleDbType.VarWChar, 0, "Crediteur"));




            this.oleDbDeleteCommandCrediteur.CommandText = @"DELETE FROM tblCrediteur WHERE (Crediteur = ?)";
            this.oleDbDeleteCommandCrediteur.Connection = this.cnLeden;
            this.oleDbDeleteCommandCrediteur.Parameters.Add(new OleDbParameter("Crediteur", OleDbType.VarWChar, 0, "Crediteur"));

        
            ((System.ComponentModel.ISupportInitialize)(this.dsDataSet2)).EndInit();

        }
        //=============================================================================================================

        private OleDbConnection _connection;
		public OleDbConnection Connection
		{
			get { return _connection; }
			set { _connection = value; RefreshConnection(); }
		}

		private OleDbTransaction _transaction;
		public OleDbTransaction Transaction
		{
			get { return _transaction; }
//			set { _transaction = value; }
		}
		private void RefreshConnection()
		{
			_connection.Open();
			_transaction = _connection.BeginTransaction();
			ConnectCommandsToTransaction();
			FillPrimaryDataSets();
		}
		#region ConnectCommandsToTransaction
		private void ConnectCommandsToTransaction()
		{

            daLid.SelectCommand.Transaction = _transaction;
            daLid.UpdateCommand.Transaction = _transaction;
            daLid.InsertCommand.Transaction = _transaction;
            daLid.DeleteCommand.Transaction = _transaction;

            daLid.SelectCommand.Connection = _transaction.Connection;
            daLid.UpdateCommand.Connection = _transaction.Connection;
            daLid.InsertCommand.Connection = _transaction.Connection;
            daLid.DeleteCommand.Connection = _transaction.Connection;

            daRekening.SelectCommand.Transaction = _transaction;
            daRekening.UpdateCommand.Transaction = _transaction;
            daRekening.InsertCommand.Transaction = _transaction;
            daRekening.DeleteCommand.Transaction = _transaction;

            daRekening.SelectCommand.Connection = _transaction.Connection;
            daRekening.UpdateCommand.Connection = _transaction.Connection;
            daRekening.InsertCommand.Connection = _transaction.Connection;
            daRekening.DeleteCommand.Connection = _transaction.Connection;

            daCompResult.SelectCommand.Transaction = _transaction;
            daCompResult.UpdateCommand.Transaction = _transaction;
            daCompResult.InsertCommand.Transaction = _transaction;
            daCompResult.DeleteCommand.Transaction = _transaction;

            daCompResult.SelectCommand.Connection = _transaction.Connection;
            daCompResult.UpdateCommand.Connection = _transaction.Connection;
            daCompResult.InsertCommand.Connection = _transaction.Connection;
            daCompResult.DeleteCommand.Connection = _transaction.Connection;

            daBetaling.SelectCommand.Transaction = _transaction;
            daBetaling.UpdateCommand.Transaction = _transaction;
            daBetaling.InsertCommand.Transaction = _transaction;
            daBetaling.DeleteCommand.Transaction = _transaction;

            daBetaling.SelectCommand.Connection = _transaction.Connection;
            daBetaling.UpdateCommand.Connection = _transaction.Connection;
            daBetaling.InsertCommand.Connection = _transaction.Connection;
            daBetaling.DeleteCommand.Connection = _transaction.Connection;

            daCrediteur.SelectCommand.Transaction = _transaction;
            daCrediteur.UpdateCommand.Transaction = _transaction;
            daCrediteur.InsertCommand.Transaction = _transaction;
            daCrediteur.DeleteCommand.Transaction = _transaction;

            daCrediteur.SelectCommand.Connection = _transaction.Connection;
            daCrediteur.UpdateCommand.Connection = _transaction.Connection;
            daCrediteur.InsertCommand.Connection = _transaction.Connection;
            daCrediteur.DeleteCommand.Connection = _transaction.Connection;
        }

		private void FillPrimaryDataSets()
		{
			try
			{
                dsDataSet2.tblLid.Clear();
                dsDataSet2.tblRekening.Clear();
                dsDataSet2.tblCompResult.Clear();
                dsDataSet2.tblBetaling.Clear();
                dsDataSet2.tblCrediteur.Clear();

                daLid.Fill(dsDataSet2.tblLid);
                daRekening.Fill(dsDataSet2.tblRekening);
                daCompResult.Fill(dsDataSet2.tblCompResult);
                daBetaling.Fill(dsDataSet2.tblBetaling);
                daCrediteur.Fill(dsDataSet2.tblCrediteur);
            }
			catch (Exception ex)
			{
				GuiRoutines.ShowMessage(ex);
			}
		}
       //==================================================================================================================================

        private tblLid lid = null;
        /// <summary>
        /// Fill ArrayList with DataSet records
        /// </summary>
        public LedenLijst VulLedenLijst()
        {
            return VulLedenLijst(false);
        }
        /// <summary>Get or Set IBAN value</summary>
        public bool SortLedenOnNameWhenLoading
        {
            get { return _SortLedenOnName; }
            set { _SortLedenOnName = value;  }
        }
        private bool _SortLedenOnName = true;

        public LedenLijst VulLedenLijst(bool InclOpgezegd)
        {
            try
            {
                LedenLijst itemList = new LedenLijst();
                for (int i = 0; i < this.dsDataSet2.tblLid.Count; i++)
                {
                    if (InclOpgezegd || this.dsDataSet2.tblLid[i].Opgezegd == 0 ||
                        (this.dsDataSet2.tblLid[i].Opgezegd == 1 && this.dsDataSet2.tblLid[i].LidTot > DateTime.Now))
                    {
                        dsLeden.tblLidRow dr = dsDataSet2.tblLid[i];
                        lid = VulLidRecord(dr);
                        itemList.Add(lid);
                    }
                }
                if (_SortLedenOnName)
                    itemList.Sort(new LedenComparer());
                else
                    itemList.Sort(new LedenComparer("LidNr"));

                return itemList;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        private tblLid VulLidRecord(dsLeden.tblLidRow dr)
        {
            try
            {
                lid = new tblLid();

                lid.LidNr = dr.LidNr;
                lid.Voornaam = dr.Voornaam;
                lid.Achternaam = dr.Achternaam;
                lid.Tussenvoegsel = dr.Tussenvoegsel;
                lid.Adres = dr.Adres;
                lid.Woonplaats = dr.Woonplaats;
                lid.Postcode = dr.Postcode;
                lid.Mobiel = dr.Mobiel;
                lid.Telefoon = dr.Telefoon;
                lid.BondsNr = dr.BondsNr;
                lid.Geslacht = dr.Geslacht;
                lid.GeboorteDatum = dr.GeboorteDatum;
                lid.Email1 = dr.Email1;
                lid.Email2 = dr.Email2;
                lid.IBAN = dr.IBAN;
                lid.BIC = dr.BIC;
                lid.BetaalWijze = dr.BetaalWijze;
                lid.LidBond = (dr.LidBond == 1);
                lid.CompGerechtigd = (dr.CompGerechtigd == 1);
                lid.LidType = dr.LidType;
                lid.LidVanaf = dr.LidVanaf;
                lid.Opgezegd = (dr.Opgezegd == 1);
                lid.LidTot = (dr.IsLidTotNull() ? new DateTime(2100, 1, 1, 0, 0, 0) : dr.LidTot);
                lid.U_PasNr = dr.U_PasNr;
                lid.PakketTot = dr.PakketTot;
                lid.VastBedrag = dr.VastBedrag;
                lid.Korting = dr.Korting;
                lid.Medisch = dr.Medisch;
                lid.Gemerkt = (dr.Gemerkt == 1);
                lid.Ouder1_Naam = dr.Ouder1_Naam;
                lid.Ouder1_Email1 = dr.Ouder1_Email1;
                lid.Ouder1_Email2 = dr.Ouder1_Email2;
                lid.Ouder1_Mobiel = dr.Ouder1_Mobiel;
                lid.Ouder1_Telefoon = dr.Ouder1_Telefoon;
                lid.Ouder2_Naam = dr.Ouder2_Naam;
                lid.Ouder2_Email1 = dr.Ouder2_Email1;
                lid.Ouder2_Email2 = dr.Ouder2_Email2;
                lid.Ouder2_Mobiel = dr.Ouder2_Mobiel;
                lid.Ouder2_Telefoon = dr.Ouder2_Telefoon;
                lid.Geincasseerd = (dr.Geincasseerd == 1);
                lid.ToernooiSpeler = dr.ToernooiSpeler;
                lid.VrijwillgersRegelingIsVanToepassing = (dr.Extra2 == 1);
                lid.Rating = dr.Extra3;
                lid.VrijwillgersVasteTaak = (dr.Extra4 == 1);
                lid.VrijwillgersAfgekocht = (dr.Extra5 == 1);
                lid.LicentieJun = dr.Licentie;
                lid.VrijwillgersToelichting = dr.ExtraB;
                lid.LicentieSen = dr.ExtraC;
                lid.ExtraD = dr.ExtraD;
                lid.ExtraE = dr.ExtraE;

                lid.Dirty = false;
               return lid;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        public void DeleteAlleLeden()
        {
            try
            {
                foreach (dsLeden.tblLidRow dr in dsDataSet2.tblLid)
                {
                    dr.Delete();
                }
                daLid.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        public void UpdateLeden(LedenLijst itemList)
        {
            try
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    tblLid lid = itemList[i];
                    if (!lid.Dirty) continue;
                    dsLeden.tblLidRow dataRow = (dsLeden.tblLidRow)dsDataSet2.tblLid.FindByLidNr(lid.LidNr);
                    if (dataRow == null)
                    {
                        dataRow = dsDataSet2.tblLid.NewtblLidRow();
                        dataRow.LidNr = lid.LidNr;
                        dsDataSet2.tblLid.AddtblLidRow(dataRow);
                    }
                    dataRow.Voornaam = lid.Voornaam;
                    dataRow.Achternaam = lid.Achternaam;
                    dataRow.Tussenvoegsel = lid.Tussenvoegsel;
                    dataRow.Adres = lid.Adres;
                    dataRow.Woonplaats = lid.Woonplaats;
                    dataRow.Postcode = lid.Postcode;
                    dataRow.Mobiel = lid.Mobiel;
                    dataRow.Telefoon = lid.Telefoon;
                    dataRow.BondsNr = lid.BondsNr;
                    dataRow.Geslacht = lid.Geslacht;
                    dataRow.GeboorteDatum = lid.GeboorteDatum;
                    dataRow.Email1 = lid.Email1;
                    dataRow.Email2 = lid.Email2;
                    dataRow.IBAN = lid.IBAN;
                    dataRow.BIC = lid.BIC;
                    dataRow.BetaalWijze = lid.BetaalWijze;
                    dataRow.LidBond = (lid.LidBond ? 1 : 0);
                    dataRow.CompGerechtigd = (lid.CompGerechtigd ? 1 : 0);
                    dataRow.LidType = lid.LidType;
                    dataRow.LidVanaf = lid.LidVanaf;
                    dataRow.Opgezegd = (lid.Opgezegd ? 1 : 0);
                    dataRow.LidTot = lid.LidTot;
                    dataRow.U_PasNr = lid.U_PasNr;
                    dataRow.PakketTot = lid.PakketTot;
                    dataRow.VastBedrag = lid.VastBedrag;
                    dataRow.Korting = lid.Korting;
                    dataRow.Medisch = lid.Medisch;
                    dataRow.Gemerkt = (lid.Gemerkt ? 1 : 0);
                    dataRow.Ouder1_Naam = lid.Ouder1_Naam;
                    dataRow.Ouder1_Email1 = lid.Ouder1_Email1;
                    dataRow.Ouder1_Email2 = lid.Ouder1_Email2;
                    dataRow.Ouder1_Mobiel = lid.Ouder1_Mobiel;
                    dataRow.Ouder1_Telefoon = lid.Ouder1_Telefoon;
                    dataRow.Ouder2_Naam = lid.Ouder2_Naam;
                    dataRow.Ouder2_Email1 = lid.Ouder2_Email1;
                    dataRow.Ouder2_Email2 = lid.Ouder2_Email2;
                    dataRow.Ouder2_Mobiel = lid.Ouder2_Mobiel;
                    dataRow.Ouder2_Telefoon = lid.Ouder2_Telefoon;
                    dataRow.Geincasseerd = (lid.Geincasseerd ? 1: 0);
                    dataRow.ToernooiSpeler = lid.ToernooiSpeler;
                    dataRow.Extra2 = (lid.VrijwillgersRegelingIsVanToepassing ? 1 : 0);
                    dataRow.Extra3 = lid.Rating;
                    dataRow.Extra4 = (lid.VrijwillgersVasteTaak ? 1 : 0);
                    dataRow.Extra5 = (lid.VrijwillgersAfgekocht ? 1 : 0);
                    dataRow.Licentie = lid.LicentieJun;
                    dataRow.ExtraB = lid.VrijwillgersToelichting;
                    dataRow.ExtraC = lid.LicentieSen;
                    dataRow.ExtraD = lid.ExtraD;
                    dataRow.ExtraE = lid.ExtraE;
                }
 
                daLid.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        
        
        public tblLid CreateLidRecord() 
        {
            tblLid lid = new tblLid();
            try
            {
                for (int i = 0; i < this.dsDataSet2.tblLid.Count;i++ )
                {
                    if (dsDataSet2.tblLid[i].LidNr > lid.LidNr)
                        lid.LidNr = dsDataSet2.tblLid[i].LidNr;
                }
                lid.LidNr++;
                lid.Achternaam = "Nieuw Lid " + lid.LidNr.ToString();
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return lid;
        }

        //==================================================================================================================================
        //
        // REKENING
        //
        //==================================================================================================================================

        private tblRekening rekening = null;
        /// <summary>
        /// Fill RekeningenLijst with DataSet records
        /// </summary>
        public RekeningenLijst VulRekeningRecords()
        {
            try
            {
                RekeningenLijst itemList = new RekeningenLijst();
                for (int i = 0; i < this.dsDataSet2.tblRekening.Count; i++)
                {
                    rekening = new tblRekening();

                    rekening.LidNr = this.dsDataSet2.tblRekening[i].Lidnr;
                    rekening.RekeningSeqNr = this.dsDataSet2.tblRekening[i].RekeningSeqNr;

                    rekening.IBAN = this.dsDataSet2.tblRekening[i].IBAN;
                    rekening.BIC = this.dsDataSet2.tblRekening[i].BIC;
                    rekening.TotaalBedrag = this.dsDataSet2.tblRekening[i].TotaalBedrag;
                    rekening.ContributieBedrag = this.dsDataSet2.tblRekening[i].ContributieBedrag;

                    rekening.Bondsbijdrage = this.dsDataSet2.tblRekening[i].Bondsbijdrage;
                    rekening.CompetitieBijdrage = this.dsDataSet2.tblRekening[i].CompetitieBijdrage;
                    rekening.Korting = this.dsDataSet2.tblRekening[i].Korting;
                    rekening.ExtraBedrag = this.dsDataSet2.tblRekening[i].ExtraBedrag;
                    rekening.TypeRekening = this.dsDataSet2.tblRekening[i].TypeRekening;

                    rekening.Omschrijving = this.dsDataSet2.tblRekening[i].Omschrijving;
                    rekening.AanmaakDatum = this.dsDataSet2.tblRekening[i].AanmaakDatum;
                    rekening.PeilDatum = this.dsDataSet2.tblRekening[i].PeilDatum;
                    rekening.VerstuurdDatum = this.dsDataSet2.tblRekening[i].VerstuurdDatum;
                    rekening.Verstuurd = (this.dsDataSet2.tblRekening[i].Verstuurd == 1);

                    rekening.Gestorneerd = (this.dsDataSet2.tblRekening[i].Gestorneerd == 1);
                    rekening.KostenStornering = this.dsDataSet2.tblRekening[i].KostenStornering;
                    rekening.MailOnderdrukken = (this.dsDataSet2.tblRekening[i].MailOnderdrukken == 1);
                    rekening.BedragKortingVrijwilliger = this.dsDataSet2.tblRekening[i].Extra1 / 100;
                    rekening.ExtraA = this.dsDataSet2.tblRekening[i].ExtraA;

                    dsLeden.tblLidRow dataRow = (dsLeden.tblLidRow)dsDataSet2.tblLid.FindByLidNr(rekening.LidNr);
                    rekening.Lid = VulLidRecord(dataRow);
                    itemList.Add(rekening);
                }
                return itemList;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        public void UpdateRekeningen(RekeningenLijst itemList)
        {
            try
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    tblRekening Rekening = (tblRekening)itemList[i];
                    if (!Rekening.Dirty) continue;
                    dsLeden.tblRekeningRow dataRow = (dsLeden.tblRekeningRow)dsDataSet2.tblRekening.FindByLidnrRekeningSeqNr(Rekening.LidNr, Rekening.RekeningSeqNr);
                    if (dataRow == null)
                    {
                        dataRow = dsDataSet2.tblRekening.NewtblRekeningRow();
                        dataRow.Lidnr = Rekening.LidNr;
                        dataRow.RekeningSeqNr = Rekening.RekeningSeqNr;
                        dsDataSet2.tblRekening.AddtblRekeningRow(dataRow);
                    }

                    dataRow.IBAN = Rekening.IBAN;
                    dataRow.BIC = Rekening.BIC;
                    dataRow.TotaalBedrag = Rekening.TotaalBedrag;
                    dataRow.ContributieBedrag = Rekening.ContributieBedrag;
                    
                    dataRow.Bondsbijdrage = Rekening.Bondsbijdrage;
                    dataRow.CompetitieBijdrage = Rekening.CompetitieBijdrage;
                    dataRow.Korting = Rekening.Korting;
                    dataRow.ExtraBedrag = Rekening.ExtraBedrag;
                    dataRow.TypeRekening = Rekening.TypeRekening;

                    dataRow.Omschrijving = Rekening.Omschrijving;
                    dataRow.AanmaakDatum = Rekening.AanmaakDatum;
                    dataRow.PeilDatum = Rekening.PeilDatum;
                    dataRow.VerstuurdDatum = Rekening.VerstuurdDatum;
                    dataRow.Verstuurd = (Rekening.Verstuurd ? 1 : 0);

                    dataRow.Gestorneerd = (Rekening.Gestorneerd ? 1 : 0);
                    dataRow.KostenStornering = Rekening.KostenStornering;
                    dataRow.MailOnderdrukken = (Rekening.MailOnderdrukken ? 1 : 0);
                    dataRow.Extra1 = Convert.ToInt32(Rekening.BedragKortingVrijwilliger * 100);
                    dataRow.ExtraA = Rekening.ExtraA;
                }

                daRekening.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }


        public void DeleteRekening(tblRekening rekening)
        {
            try
            {
                //int i = dsDataSet2.tblRekening.Count;
                dsLeden.tblRekeningRow dataRow = (dsLeden.tblRekeningRow)dsDataSet2.tblRekening.FindByLidnrRekeningSeqNr(rekening.LidNr, rekening.RekeningSeqNr);
                dataRow.Delete();
                daRekening.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }
        
        public void DeleteAlleRekeningen()
        {
            try
            {
                foreach (dsLeden.tblRekeningRow dr in dsDataSet2.tblRekening)
                {
                    dr.Delete();
                }
                daRekening.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        //==================================================================================================================================
        //
        // BETALING
        //
        //==================================================================================================================================

        private tblBetaling betaling = null;
        /// <summary>
        /// Fill BetalingenLijst with DataSet records
        /// </summary>
        public BetalingenLijst VulBetalingRecords()
        {
            try
            {
                BetalingenLijst itemList = new BetalingenLijst();
                for (int i = 0; i < this.dsDataSet2.tblBetaling.Count; i++)
                {
                    betaling = new tblBetaling(itemList);
                    
                    betaling.IBAN_Creditor = this.dsDataSet2.tblBetaling[i].IBAN_Creditor;
                    betaling.BIC_Creditor = this.dsDataSet2.tblBetaling[i].BIC_Creditor;

                    betaling.Omschrijving = this.dsDataSet2.tblBetaling[i].Omschrijving;
                    betaling.EndToEndId = this.dsDataSet2.tblBetaling[i].EndToEndId;
                    betaling.TypeBetaling = this.dsDataSet2.tblBetaling[i].TypeBetaling;
                    betaling.TotaalBedrag = this.dsDataSet2.tblBetaling[i].TotaalBedrag;
                    betaling.AanmaakDatum = this.dsDataSet2.tblBetaling[i].AanmaakDatum;

                    betaling.Verstuurd = (this.dsDataSet2.tblBetaling[i].Verstuurd == 1);
                    betaling.VerstuurdDatum = this.dsDataSet2.tblBetaling[i].VerstuurdDatum;
                    betaling.GewensteVerwerkingsDatum = this.dsDataSet2.tblBetaling[i].GewensteVerwerkingsDatum;
                    betaling.Crediteur = this.dsDataSet2.tblBetaling[i].ExtraA;
                    betaling.ExtraB = this.dsDataSet2.tblBetaling[i].ExtraB;
                    betaling.ExtraC = this.dsDataSet2.tblBetaling[i].ExtraC;
                    betaling.Extra1 = this.dsDataSet2.tblBetaling[i].Extra1;
                    betaling.Extra2 = this.dsDataSet2.tblBetaling[i].Extra2;
                    betaling.Extra3 = this.dsDataSet2.tblBetaling[i].Extra3;
                }
                return itemList;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        public void UpdateBetalingen(BetalingenLijst itemList)
        {
            try
            {
                foreach (tblBetaling betaling in itemList)
                {
                    if (!betaling.Dirty) continue;
                    dsLeden.tblBetalingRow dataRow = (dsLeden.tblBetalingRow)dsDataSet2.tblBetaling.FindByBetalingsSeqNr(betaling.BetalingsSeqNr);
                    if (dataRow == null)
                    {
                        dataRow = dsDataSet2.tblBetaling.NewtblBetalingRow();
                        dataRow.BetalingsSeqNr = betaling.BetalingsSeqNr;
                        dsDataSet2.tblBetaling.AddtblBetalingRow(dataRow);
                    }

                    dataRow.IBAN_Creditor = betaling.IBAN_Creditor;
                    dataRow.BIC_Creditor = betaling.BIC_Creditor;

                    dataRow.Omschrijving = betaling.Omschrijving;
                    dataRow.EndToEndId = betaling.EndToEndId;
                    dataRow.TypeBetaling = betaling.TypeBetaling;
                    dataRow.TotaalBedrag = betaling.TotaalBedrag;
                    dataRow.AanmaakDatum = betaling.AanmaakDatum;
                    
                    dataRow.Verstuurd = (betaling.Verstuurd ? 1 : 0);
                    dataRow.VerstuurdDatum = betaling.VerstuurdDatum;
                    dataRow.GewensteVerwerkingsDatum = betaling.GewensteVerwerkingsDatum;
                    dataRow.ExtraA = betaling.Crediteur;
                    dataRow.ExtraB = betaling.ExtraB;
                    dataRow.ExtraC = betaling.ExtraC;
                    dataRow.Extra1 = betaling.Extra1;
                    dataRow.Extra2 = betaling.Extra2;
                    dataRow.Extra3 = betaling.Extra3;
                }

                daBetaling.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }


        public void DeleteBetaling(tblBetaling betaling)
        {
            try
            {
                //int i = dsDataSet2.tblBetaling.Count;
                dsLeden.tblBetalingRow dataRow = (dsLeden.tblBetalingRow)dsDataSet2.tblBetaling.FindByBetalingsSeqNr(betaling.BetalingsSeqNr);
                dataRow.Delete();
                daBetaling.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }


        public void DeleteAlleBetalingen()
        {
            try
            {
                foreach (dsLeden.tblBetalingRow dr in dsDataSet2.tblBetaling)
                {
                    dr.Delete();
                }
                daBetaling.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }



        //==================================================================================================================================
        //
        // CompResult
        //
        //==================================================================================================================================

        private tblCompResult CompResult = null;
        /// <summary>
        /// Fill CompResultenLijst with DataSet records
        /// </summary>
        public ResultatenLijst VulCompResultRecords()
        {
            try
            {
                ResultatenLijst itemList = new ResultatenLijst();
                for (int i = 0; i < this.dsDataSet2.tblCompResult.Count; i++)
                {
                    CompResult = new tblCompResult();

                    CompResult.LidNr = this.dsDataSet2.tblCompResult[i].Lidnr;
                    CompResult.Jaar = this.dsDataSet2.tblCompResult[i].Jaar;

                    CompResult.Seizoen = this.dsDataSet2.tblCompResult[i].Seizoen;
                    CompResult.Klasse = this.dsDataSet2.tblCompResult[i].Klasse;
                    CompResult.Percentage = this.dsDataSet2.tblCompResult[i].Percentage;

                    dsLeden.tblLidRow dataRow = (dsLeden.tblLidRow)dsDataSet2.tblLid.FindByLidNr(CompResult.LidNr);
                    CompResult.Lid = VulLidRecord(dataRow);
                    itemList.Add(CompResult);
                }
                return itemList;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        public void DeleteAlleCompResults()
        {
            try
            {
                foreach (dsLeden.tblCompResultRow dr in dsDataSet2.tblCompResult)
                {
                    dr.Delete();
                }
                daCompResult.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        public void UpdateCompResulten(ResultatenLijst itemList)
        {
            try
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    tblCompResult CompResult = (tblCompResult)itemList[i];
                    if (!CompResult.Dirty) continue;
                    dsLeden.tblCompResultRow dataRow = (dsLeden.tblCompResultRow)dsDataSet2.tblCompResult.FindByLidnrJaarSeizoen(CompResult.LidNr, CompResult.Jaar, CompResult.Seizoen);
                    if (dataRow == null)
                    {
                        dataRow = dsDataSet2.tblCompResult.NewtblCompResultRow();
                        dataRow.Lidnr = CompResult.LidNr;
                        dataRow.Jaar = CompResult.Jaar;
                        dataRow.Seizoen = CompResult.Seizoen;
                        dsDataSet2.tblCompResult.AddtblCompResultRow(dataRow);
                    }

                    dataRow.Klasse = CompResult.Klasse;
                    dataRow.Percentage = CompResult.Percentage;
                }

                daCompResult.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        //==================================================================================================================================


        //==================================================================================================================================
        //
        // Crediteur
        //
        //==================================================================================================================================

        private tblCrediteur Crediteur = null;
        /// <summary>
        /// Fill CompResultenLijst with DataSet records
        /// </summary>
        public CrediteurenLijst VulCrediteurenRecords()
        {
            try
            {
                CrediteurenLijst itemList = new CrediteurenLijst();
                for (int i = 0; i < this.dsDataSet2.tblCrediteur.Count; i++)
                {
                    Crediteur = new tblCrediteur(itemList);

                    Crediteur.Naam = this.dsDataSet2.tblCrediteur[i].Naam;
                    Crediteur.Crediteur = this.dsDataSet2.tblCrediteur[i].Crediteur;

                    Crediteur.IBAN = this.dsDataSet2.tblCrediteur[i].IBAN;
                    Crediteur.BIC = this.dsDataSet2.tblCrediteur[i].BIC;
                    Crediteur.Omschrijving = this.dsDataSet2.tblCrediteur[i].Omschrijving;

                    Crediteur.Dirty = false;
                }
                return itemList;
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
            return null;
        }

        public void DeleteCrediteur(tblCrediteur crediteur)
        {
            try
            {
                dsLeden.tblCrediteurRow dataRow = (dsLeden.tblCrediteurRow)dsDataSet2.tblCrediteur.FindByCrediteur(crediteur.Crediteur);
                dataRow.Delete();
                daCrediteur.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        
        public void DeleteAlleCrediteurs()
        {
            try
            {
                foreach (dsLeden.tblCrediteurRow dr in dsDataSet2.tblCrediteur)
                {
                    dr.Delete();
                }
                daCrediteur.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        public void UpdateCrediteuren(CrediteurenLijst itemList)
        {
            try
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    tblCrediteur Crediteur = (tblCrediteur)itemList[i];
                    if (!Crediteur.Dirty) continue;
                    dsLeden.tblCrediteurRow dataRow = (dsLeden.tblCrediteurRow)dsDataSet2.tblCrediteur.FindByCrediteur(Crediteur.Crediteur);
                    if (dataRow == null)
                    {
                        dataRow = dsDataSet2.tblCrediteur.NewtblCrediteurRow();
                        dataRow.Crediteur = Crediteur.Crediteur = Crediteur.Naam.Replace(" ", string.Empty);
                        dsDataSet2.tblCrediteur.AddtblCrediteurRow(dataRow);
                    }

                    dataRow.Naam = Crediteur.Naam;
                    dataRow.Omschrijving = Crediteur.Omschrijving;
                    dataRow.IBAN = Crediteur.IBAN;
                    dataRow.BIC = Crediteur.BIC;
                    Crediteur.Dirty = false;
                }

                daCrediteur.Update(dsDataSet2);
            }
            catch (Exception ex)
            {
                GuiRoutines.ShowMessage(ex);
            }
        }

        //==================================================================================================================================
        
        
        //==================================================================================================================================

        public void CommitTransaction()
		{
			CommitTransaction(false);
		}
		public void CommitTransaction(bool Restart)
		{
			try
			{
				_transaction.Commit();
			}
			catch (Exception ex)
			{
				try
				{
					_transaction.Rollback();
				}
				catch (OleDbException ex2)
				{
					if (_transaction.Connection != null)
					{
						Console.WriteLine("An exception of type " + ex2.GetType() +
							" was encountered while attempting to roll back the transaction.");
					}
				}
				Console.WriteLine("An exception of type " + ex.GetType() +
					" was encountered while inserting the data.");
				Console.WriteLine("Neither record was written to database.");
			}
			if (Restart)
			{
				_transaction = _connection.BeginTransaction();
				ConnectCommandsToTransaction();
				FillPrimaryDataSets();
			}
		}
		public void CancelTransaction()
		{
			CancelTransaction(false);
		}
		public void CancelTransaction(bool Restart)
		{
			_transaction.Rollback();
			if (Restart)
			{
				_transaction = _connection.BeginTransaction();
				ConnectCommandsToTransaction();
				FillPrimaryDataSets();
			}
		}

    }
}
        #endregion