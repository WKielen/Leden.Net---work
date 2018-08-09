
using Util.Forms;
using Util.Text;

namespace Leden.Net
{
    partial class frmLeden
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeden));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cnLeden = new System.Data.OleDb.OleDbConnection();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.grpVrijwilligers = new System.Windows.Forms.GroupBox();
            this.ckbVrijwVasteTaak = new System.Windows.Forms.CheckBox();
            this.ckbVrijwAfgekocht = new System.Windows.Forms.CheckBox();
            this.ckbVrijwKorting = new System.Windows.Forms.CheckBox();
            this.grpToernooiInfo = new System.Windows.Forms.GroupBox();
            this.txtLicSen = new System.Windows.Forms.TextBox();
            this.txtLicJun = new System.Windows.Forms.TextBox();
            this.lblLicSen = new System.Windows.Forms.Label();
            this.lblLicJun = new System.Windows.Forms.Label();
            this.ckbRanglijst = new System.Windows.Forms.CheckBox();
            this.ckbToernooi = new System.Windows.Forms.CheckBox();
            this.lblLeeftijdCategorie = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLeeftijd = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpGeboorteDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rtbMemo = new System.Windows.Forms.RichTextBox();
            this.txtMedisch = new System.Windows.Forms.TextBox();
            this.grpOuder2 = new System.Windows.Forms.GroupBox();
            this.txtOuder2_Telefoon = new System.Windows.Forms.TextBox();
            this.lblOuder2_Telefoon = new System.Windows.Forms.Label();
            this.txtOuder2_Mobiel = new System.Windows.Forms.TextBox();
            this.lblOuder2_Mobiel = new System.Windows.Forms.Label();
            this.txtOuder2_Email2 = new System.Windows.Forms.TextBox();
            this.lblOuder2_Email2 = new System.Windows.Forms.Label();
            this.txtOuder2_Email1 = new System.Windows.Forms.TextBox();
            this.lblOuder2_Email1 = new System.Windows.Forms.Label();
            this.txtOuder2_Naam = new System.Windows.Forms.TextBox();
            this.lblOuder2_Naam = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtpPakketTot = new System.Windows.Forms.DateTimePicker();
            this.dtpLidVanaf = new System.Windows.Forms.DateTimePicker();
            this.dtpLidTot = new System.Windows.Forms.DateTimePicker();
            this.lblLidVanaf = new System.Windows.Forms.Label();
            this.ckbOpgezegd = new System.Windows.Forms.CheckBox();
            this.lblPakketTot = new System.Windows.Forms.Label();
            this.lblLidTot = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtBondsNr = new System.Windows.Forms.TextBox();
            this.lblBondsNr = new System.Windows.Forms.Label();
            this.ckbCompGerechtigd = new System.Windows.Forms.CheckBox();
            this.ckbLidBond = new System.Windows.Forms.CheckBox();
            this.rbuV = new System.Windows.Forms.RadioButton();
            this.rbuM = new System.Windows.Forms.RadioButton();
            this.ckbGemerkt = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboBetaalwijze = new System.Windows.Forms.ComboBox();
            this.cboLidType = new System.Windows.Forms.ComboBox();
            this.lblBetaalWijze = new System.Windows.Forms.Label();
            this.lblVastBedrag = new System.Windows.Forms.Label();
            this.ckbGeincasseerd = new System.Windows.Forms.CheckBox();
            this.txtVastBedrag = new Util.Forms.currencyTextBox(this.components);
            this.lblKorting = new System.Windows.Forms.Label();
            this.txtKorting = new Util.Forms.currencyTextBox(this.components);
            this.lblLidType = new System.Windows.Forms.Label();
            this.grpOuder1 = new System.Windows.Forms.GroupBox();
            this.txtOuder1_Naam = new System.Windows.Forms.TextBox();
            this.lblOuder1_Naam = new System.Windows.Forms.Label();
            this.txtOuder1_Email1 = new System.Windows.Forms.TextBox();
            this.txtOuder1_Email2 = new System.Windows.Forms.TextBox();
            this.txtOuder1_Mobiel = new System.Windows.Forms.TextBox();
            this.txtOuder1_Telefoon = new System.Windows.Forms.TextBox();
            this.lblOuder1_Email1 = new System.Windows.Forms.Label();
            this.lblOuder1_Email2 = new System.Windows.Forms.Label();
            this.lblOuder1_Mobiel = new System.Windows.Forms.Label();
            this.lblOuder1_Telefoon = new System.Windows.Forms.Label();
            this.lblLidNr = new System.Windows.Forms.Label();
            this.txtLidNr = new System.Windows.Forms.TextBox();
            this.lblVoornaam = new System.Windows.Forms.Label();
            this.txtVoornaam = new System.Windows.Forms.TextBox();
            this.lblAchternaam = new System.Windows.Forms.Label();
            this.txtAchternaam = new System.Windows.Forms.TextBox();
            this.lblTussenvoegsel = new System.Windows.Forms.Label();
            this.txtTussenvoegsel = new System.Windows.Forms.TextBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.lblWoonplaats = new System.Windows.Forms.Label();
            this.txtWoonplaats = new System.Windows.Forms.TextBox();
            this.lblPostcode = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.lblMobiel = new System.Windows.Forms.Label();
            this.txtMobiel = new System.Windows.Forms.TextBox();
            this.lblTelefoon = new System.Windows.Forms.Label();
            this.txtTelefoon = new System.Windows.Forms.TextBox();
            this.lblGeslacht = new System.Windows.Forms.Label();
            this.lblGeboorteDatum = new System.Windows.Forms.Label();
            this.lblEmail1 = new System.Windows.Forms.Label();
            this.txtEmail1 = new System.Windows.Forms.TextBox();
            this.lblEmail2 = new System.Windows.Forms.Label();
            this.txtEmail2 = new System.Windows.Forms.TextBox();
            this.lblIBAN = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.lblBIC = new System.Windows.Forms.Label();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.lblU_PasNr = new System.Windows.Forms.Label();
            this.txtU_PasNr = new System.Windows.Forms.TextBox();
            this.pnlPoule = new System.Windows.Forms.Panel();
            this.cmdRekeningen = new System.Windows.Forms.Button();
            this.cmdChange = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.sbpFileName = new System.Windows.Forms.StatusBarPanel();
            this.sbpStatusMessage = new System.Windows.Forms.StatusBarPanel();
            this.sbpRecordNr = new System.Windows.Forms.StatusBarPanel();
            this.cmdTTKaart = new System.Windows.Forms.Button();
            this.cmdSendEmail = new System.Windows.Forms.Button();
            this.cmdSelectForm = new System.Windows.Forms.Button();
            this.cmdCancel2 = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbkInclOpgezegd = new System.Windows.Forms.CheckBox();
            this.ckbSortLidNbr = new System.Windows.Forms.CheckBox();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.rekeningenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overzichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incassoKandidatenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aanmakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.handmatigAanmakenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versturenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.verstuurdeVerwijderenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lijstenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportNaarCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aanmaakOutputForMailProgrammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lijstschermenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toernooienBondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrijwilligersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legeLijstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailVersturenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuratieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compResulatenJeugdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vergelijkMetNASToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inlezenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aanmakenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadNaarWebserverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toonOuder2BlokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leesRatingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cboLeden = new Leden.Net.DropDownLeden(this.components);
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.dsLeden1 = new Leden.Net.dsLeden();
            this.versturenAankondigingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlDetails.SuspendLayout();
            this.grpVrijwilligers.SuspendLayout();
            this.grpToernooiInfo.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpOuder2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpOuder1.SuspendLayout();
            this.pnlPoule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sbpFileName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpStatusMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpRecordNr)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLeden1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cnLeden
            // 
            this.cnLeden.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Documents and Settings\\kielen\\My " +
    "Documents\\Stand.mdb";
            // 
            // cmdNew
            // 
            this.cmdNew.Location = new System.Drawing.Point(1217, 468);
            this.cmdNew.Margin = new System.Windows.Forms.Padding(4);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(100, 28);
            this.cmdNew.TabIndex = 0;
            this.cmdNew.Text = "New";
            this.toolTip1.SetToolTip(this.cmdNew, "Ctrl-N\r\nShift Click maakt een Nieuw Lid mail \r\nvan een bestaand lid.");
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(1217, 431);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 28);
            this.cmdSave.TabIndex = 22;
            this.cmdSave.Text = "Save";
            this.toolTip1.SetToolTip(this.cmdSave, "Ctrl-S");
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.grpVrijwilligers);
            this.pnlDetails.Controls.Add(this.grpToernooiInfo);
            this.pnlDetails.Controls.Add(this.lblLeeftijdCategorie);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.lblLeeftijd);
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.dtpGeboorteDatum);
            this.pnlDetails.Controls.Add(this.groupBox6);
            this.pnlDetails.Controls.Add(this.grpOuder2);
            this.pnlDetails.Controls.Add(this.groupBox4);
            this.pnlDetails.Controls.Add(this.groupBox3);
            this.pnlDetails.Controls.Add(this.rbuV);
            this.pnlDetails.Controls.Add(this.rbuM);
            this.pnlDetails.Controls.Add(this.ckbGemerkt);
            this.pnlDetails.Controls.Add(this.groupBox2);
            this.pnlDetails.Controls.Add(this.grpOuder1);
            this.pnlDetails.Controls.Add(this.lblLidNr);
            this.pnlDetails.Controls.Add(this.txtLidNr);
            this.pnlDetails.Controls.Add(this.lblVoornaam);
            this.pnlDetails.Controls.Add(this.txtVoornaam);
            this.pnlDetails.Controls.Add(this.lblAchternaam);
            this.pnlDetails.Controls.Add(this.txtAchternaam);
            this.pnlDetails.Controls.Add(this.lblTussenvoegsel);
            this.pnlDetails.Controls.Add(this.txtTussenvoegsel);
            this.pnlDetails.Controls.Add(this.lblAdres);
            this.pnlDetails.Controls.Add(this.txtAdres);
            this.pnlDetails.Controls.Add(this.lblWoonplaats);
            this.pnlDetails.Controls.Add(this.txtWoonplaats);
            this.pnlDetails.Controls.Add(this.lblPostcode);
            this.pnlDetails.Controls.Add(this.txtPostcode);
            this.pnlDetails.Controls.Add(this.lblMobiel);
            this.pnlDetails.Controls.Add(this.txtMobiel);
            this.pnlDetails.Controls.Add(this.lblTelefoon);
            this.pnlDetails.Controls.Add(this.txtTelefoon);
            this.pnlDetails.Controls.Add(this.lblGeslacht);
            this.pnlDetails.Controls.Add(this.lblGeboorteDatum);
            this.pnlDetails.Controls.Add(this.lblEmail1);
            this.pnlDetails.Controls.Add(this.txtEmail1);
            this.pnlDetails.Controls.Add(this.lblEmail2);
            this.pnlDetails.Controls.Add(this.txtEmail2);
            this.pnlDetails.Controls.Add(this.lblIBAN);
            this.pnlDetails.Controls.Add(this.txtIBAN);
            this.pnlDetails.Controls.Add(this.lblBIC);
            this.pnlDetails.Controls.Add(this.txtBIC);
            this.pnlDetails.Controls.Add(this.lblU_PasNr);
            this.pnlDetails.Controls.Add(this.txtU_PasNr);
            this.pnlDetails.Location = new System.Drawing.Point(4, 6);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(1189, 620);
            this.pnlDetails.TabIndex = 448;
            this.toolTip1.SetToolTip(this.pnlDetails, "xx");
            // 
            // grpVrijwilligers
            // 
            this.grpVrijwilligers.Controls.Add(this.ckbVrijwVasteTaak);
            this.grpVrijwilligers.Controls.Add(this.ckbVrijwAfgekocht);
            this.grpVrijwilligers.Controls.Add(this.ckbVrijwKorting);
            this.grpVrijwilligers.Location = new System.Drawing.Point(667, 138);
            this.grpVrijwilligers.Margin = new System.Windows.Forms.Padding(4);
            this.grpVrijwilligers.Name = "grpVrijwilligers";
            this.grpVrijwilligers.Padding = new System.Windows.Forms.Padding(4);
            this.grpVrijwilligers.Size = new System.Drawing.Size(187, 123);
            this.grpVrijwilligers.TabIndex = 447;
            this.grpVrijwilligers.TabStop = false;
            this.grpVrijwilligers.Text = "Vrijwilligers";
            // 
            // ckbVrijwVasteTaak
            // 
            this.ckbVrijwVasteTaak.AutoSize = true;
            this.ckbVrijwVasteTaak.Location = new System.Drawing.Point(17, 89);
            this.ckbVrijwVasteTaak.Margin = new System.Windows.Forms.Padding(4);
            this.ckbVrijwVasteTaak.Name = "ckbVrijwVasteTaak";
            this.ckbVrijwVasteTaak.Size = new System.Drawing.Size(130, 21);
            this.ckbVrijwVasteTaak.TabIndex = 2;
            this.ckbVrijwVasteTaak.Text = "Vaste vrijwilliger";
            this.toolTip1.SetToolTip(this.ckbVrijwVasteTaak, "Vaste vrijwilligerstaak zoals bestuur, cie, trainer e.d.");
            this.ckbVrijwVasteTaak.UseVisualStyleBackColor = true;
            // 
            // ckbVrijwAfgekocht
            // 
            this.ckbVrijwAfgekocht.AutoSize = true;
            this.ckbVrijwAfgekocht.Location = new System.Drawing.Point(17, 60);
            this.ckbVrijwAfgekocht.Margin = new System.Windows.Forms.Padding(4);
            this.ckbVrijwAfgekocht.Name = "ckbVrijwAfgekocht";
            this.ckbVrijwAfgekocht.Size = new System.Drawing.Size(129, 21);
            this.ckbVrijwAfgekocht.TabIndex = 2;
            this.ckbVrijwAfgekocht.Text = "Taak Afgekocht";
            this.ckbVrijwAfgekocht.UseVisualStyleBackColor = true;
            // 
            // ckbVrijwKorting
            // 
            this.ckbVrijwKorting.AutoSize = true;
            this.ckbVrijwKorting.Location = new System.Drawing.Point(16, 33);
            this.ckbVrijwKorting.Margin = new System.Windows.Forms.Padding(4);
            this.ckbVrijwKorting.Name = "ckbVrijwKorting";
            this.ckbVrijwKorting.Size = new System.Drawing.Size(156, 21);
            this.ckbVrijwKorting.TabIndex = 2;
            this.ckbVrijwKorting.Text = "Regeling toepassen";
            this.toolTip1.SetToolTip(this.ckbVrijwKorting, "Afkoopbedrag voor Vrijwilligerstaak bij Contributie innen");
            this.ckbVrijwKorting.UseVisualStyleBackColor = true;
            // 
            // grpToernooiInfo
            // 
            this.grpToernooiInfo.Controls.Add(this.txtLicSen);
            this.grpToernooiInfo.Controls.Add(this.txtLicJun);
            this.grpToernooiInfo.Controls.Add(this.lblLicSen);
            this.grpToernooiInfo.Controls.Add(this.lblLicJun);
            this.grpToernooiInfo.Controls.Add(this.ckbRanglijst);
            this.grpToernooiInfo.Controls.Add(this.ckbToernooi);
            this.grpToernooiInfo.Location = new System.Drawing.Point(667, 270);
            this.grpToernooiInfo.Margin = new System.Windows.Forms.Padding(4);
            this.grpToernooiInfo.Name = "grpToernooiInfo";
            this.grpToernooiInfo.Padding = new System.Windows.Forms.Padding(4);
            this.grpToernooiInfo.Size = new System.Drawing.Size(187, 130);
            this.grpToernooiInfo.TabIndex = 444;
            this.grpToernooiInfo.TabStop = false;
            this.grpToernooiInfo.Text = "Toernooi Info";
            // 
            // txtLicSen
            // 
            this.txtLicSen.Location = new System.Drawing.Point(144, 30);
            this.txtLicSen.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicSen.MaxLength = 1;
            this.txtLicSen.Name = "txtLicSen";
            this.txtLicSen.Size = new System.Drawing.Size(17, 22);
            this.txtLicSen.TabIndex = 5;
            this.txtLicSen.Text = "S";
            // 
            // txtLicJun
            // 
            this.txtLicJun.Location = new System.Drawing.Point(80, 30);
            this.txtLicJun.Margin = new System.Windows.Forms.Padding(4);
            this.txtLicJun.MaxLength = 1;
            this.txtLicJun.Name = "txtLicJun";
            this.txtLicJun.Size = new System.Drawing.Size(17, 22);
            this.txtLicJun.TabIndex = 5;
            this.txtLicJun.Text = "A";
            // 
            // lblLicSen
            // 
            this.lblLicSen.AutoSize = true;
            this.lblLicSen.Location = new System.Drawing.Point(111, 33);
            this.lblLicSen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicSen.Name = "lblLicSen";
            this.lblLicSen.Size = new System.Drawing.Size(33, 17);
            this.lblLicSen.TabIndex = 4;
            this.lblLicSen.Text = "Sen";
            // 
            // lblLicJun
            // 
            this.lblLicJun.AutoSize = true;
            this.lblLicJun.Location = new System.Drawing.Point(16, 33);
            this.lblLicJun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLicJun.Name = "lblLicJun";
            this.lblLicJun.Size = new System.Drawing.Size(57, 17);
            this.lblLicJun.TabIndex = 3;
            this.lblLicJun.Text = "Lic. Jun";
            // 
            // ckbRanglijst
            // 
            this.ckbRanglijst.AutoSize = true;
            this.ckbRanglijst.Enabled = false;
            this.ckbRanglijst.Location = new System.Drawing.Point(16, 95);
            this.ckbRanglijst.Margin = new System.Windows.Forms.Padding(4);
            this.ckbRanglijst.Name = "ckbRanglijst";
            this.ckbRanglijst.Size = new System.Drawing.Size(152, 21);
            this.ckbRanglijst.TabIndex = 1;
            this.ckbRanglijst.Text = "Ranglijsttoernooien";
            this.ckbRanglijst.UseVisualStyleBackColor = true;
            // 
            // ckbToernooi
            // 
            this.ckbToernooi.AutoSize = true;
            this.ckbToernooi.Location = new System.Drawing.Point(17, 65);
            this.ckbToernooi.Margin = new System.Windows.Forms.Padding(4);
            this.ckbToernooi.Name = "ckbToernooi";
            this.ckbToernooi.Size = new System.Drawing.Size(142, 21);
            this.ckbToernooi.TabIndex = 1;
            this.ckbToernooi.Text = "Speelt toernooien";
            this.ckbToernooi.UseVisualStyleBackColor = true;
            this.ckbToernooi.CheckedChanged += new System.EventHandler(this.ckbToernooi_CheckedChanged);
            // 
            // lblLeeftijdCategorie
            // 
            this.lblLeeftijdCategorie.AutoSize = true;
            this.lblLeeftijdCategorie.Location = new System.Drawing.Point(523, 278);
            this.lblLeeftijdCategorie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLeeftijdCategorie.Name = "lblLeeftijdCategorie";
            this.lblLeeftijdCategorie.Size = new System.Drawing.Size(28, 17);
            this.lblLeeftijdCategorie.TabIndex = 440;
            this.lblLeeftijdCategorie.Text = "wlp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(405, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 439;
            this.label3.Text = "Leeftijdcategorie";
            // 
            // lblLeeftijd
            // 
            this.lblLeeftijd.AutoSize = true;
            this.lblLeeftijd.Location = new System.Drawing.Point(351, 278);
            this.lblLeeftijd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLeeftijd.Name = "lblLeeftijd";
            this.lblLeeftijd.Size = new System.Drawing.Size(24, 17);
            this.lblLeeftijd.TabIndex = 438;
            this.lblLeeftijd.Text = "18";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 278);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 437;
            this.label1.Text = "Leeftijd";
            // 
            // dtpGeboorteDatum
            // 
            this.dtpGeboorteDatum.AllowDrop = true;
            this.dtpGeboorteDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGeboorteDatum.Location = new System.Drawing.Point(137, 273);
            this.dtpGeboorteDatum.Margin = new System.Windows.Forms.Padding(4);
            this.dtpGeboorteDatum.Name = "dtpGeboorteDatum";
            this.dtpGeboorteDatum.Size = new System.Drawing.Size(129, 22);
            this.dtpGeboorteDatum.TabIndex = 11;
            this.dtpGeboorteDatum.ValueChanged += new System.EventHandler(this.dtpGeboorteDatum_ValueChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rtbMemo);
            this.groupBox6.Controls.Add(this.txtMedisch);
            this.groupBox6.Location = new System.Drawing.Point(872, 407);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(269, 199);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Medisch / Memo";
            // 
            // rtbMemo
            // 
            this.rtbMemo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbMemo.Location = new System.Drawing.Point(21, 26);
            this.rtbMemo.Margin = new System.Windows.Forms.Padding(4);
            this.rtbMemo.Name = "rtbMemo";
            this.rtbMemo.Size = new System.Drawing.Size(223, 148);
            this.rtbMemo.TabIndex = 447;
            this.rtbMemo.Text = "";
            // 
            // txtMedisch
            // 
            this.txtMedisch.AllowDrop = true;
            this.txtMedisch.Location = new System.Drawing.Point(20, 25);
            this.txtMedisch.Margin = new System.Windows.Forms.Padding(4);
            this.txtMedisch.Multiline = true;
            this.txtMedisch.Name = "txtMedisch";
            this.txtMedisch.Size = new System.Drawing.Size(221, 147);
            this.txtMedisch.TabIndex = 44;
            this.txtMedisch.Text = "Medisch ";
            // 
            // grpOuder2
            // 
            this.grpOuder2.Controls.Add(this.txtOuder2_Telefoon);
            this.grpOuder2.Controls.Add(this.lblOuder2_Telefoon);
            this.grpOuder2.Controls.Add(this.txtOuder2_Mobiel);
            this.grpOuder2.Controls.Add(this.lblOuder2_Mobiel);
            this.grpOuder2.Controls.Add(this.txtOuder2_Email2);
            this.grpOuder2.Controls.Add(this.lblOuder2_Email2);
            this.grpOuder2.Controls.Add(this.txtOuder2_Email1);
            this.grpOuder2.Controls.Add(this.lblOuder2_Email1);
            this.grpOuder2.Controls.Add(this.txtOuder2_Naam);
            this.grpOuder2.Controls.Add(this.lblOuder2_Naam);
            this.grpOuder2.Location = new System.Drawing.Point(463, 407);
            this.grpOuder2.Margin = new System.Windows.Forms.Padding(4);
            this.grpOuder2.Name = "grpOuder2";
            this.grpOuder2.Padding = new System.Windows.Forms.Padding(4);
            this.grpOuder2.Size = new System.Drawing.Size(381, 199);
            this.grpOuder2.TabIndex = 53;
            this.grpOuder2.TabStop = false;
            this.grpOuder2.Text = "Ouder2";
            // 
            // txtOuder2_Telefoon
            // 
            this.txtOuder2_Telefoon.AllowDrop = true;
            this.txtOuder2_Telefoon.Location = new System.Drawing.Point(100, 153);
            this.txtOuder2_Telefoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder2_Telefoon.Name = "txtOuder2_Telefoon";
            this.txtOuder2_Telefoon.Size = new System.Drawing.Size(100, 22);
            this.txtOuder2_Telefoon.TabIndex = 64;
            this.txtOuder2_Telefoon.Text = "Ouder2_Telefoon ";
            this.txtOuder2_Telefoon.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder2_Telefoon_Validating);
            // 
            // lblOuder2_Telefoon
            // 
            this.lblOuder2_Telefoon.AutoSize = true;
            this.lblOuder2_Telefoon.Location = new System.Drawing.Point(4, 156);
            this.lblOuder2_Telefoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder2_Telefoon.Name = "lblOuder2_Telefoon";
            this.lblOuder2_Telefoon.Size = new System.Drawing.Size(68, 17);
            this.lblOuder2_Telefoon.TabIndex = 65;
            this.lblOuder2_Telefoon.Text = "Telefoon ";
            // 
            // txtOuder2_Mobiel
            // 
            this.txtOuder2_Mobiel.AllowDrop = true;
            this.txtOuder2_Mobiel.Location = new System.Drawing.Point(100, 121);
            this.txtOuder2_Mobiel.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder2_Mobiel.Name = "txtOuder2_Mobiel";
            this.txtOuder2_Mobiel.Size = new System.Drawing.Size(100, 22);
            this.txtOuder2_Mobiel.TabIndex = 63;
            this.txtOuder2_Mobiel.Text = "Ouder2_Mobiel ";
            this.txtOuder2_Mobiel.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder2_Mobiel_Validating);
            // 
            // lblOuder2_Mobiel
            // 
            this.lblOuder2_Mobiel.AutoSize = true;
            this.lblOuder2_Mobiel.Location = new System.Drawing.Point(8, 124);
            this.lblOuder2_Mobiel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder2_Mobiel.Name = "lblOuder2_Mobiel";
            this.lblOuder2_Mobiel.Size = new System.Drawing.Size(53, 17);
            this.lblOuder2_Mobiel.TabIndex = 66;
            this.lblOuder2_Mobiel.Text = "Mobiel ";
            // 
            // txtOuder2_Email2
            // 
            this.txtOuder2_Email2.AllowDrop = true;
            this.txtOuder2_Email2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtOuder2_Email2.Location = new System.Drawing.Point(100, 89);
            this.txtOuder2_Email2.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder2_Email2.Name = "txtOuder2_Email2";
            this.txtOuder2_Email2.Size = new System.Drawing.Size(264, 22);
            this.txtOuder2_Email2.TabIndex = 62;
            this.txtOuder2_Email2.Text = "ouder2_email2 ";
            this.txtOuder2_Email2.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder2_Email2_Validating);
            // 
            // lblOuder2_Email2
            // 
            this.lblOuder2_Email2.AutoSize = true;
            this.lblOuder2_Email2.Location = new System.Drawing.Point(8, 92);
            this.lblOuder2_Email2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder2_Email2.Name = "lblOuder2_Email2";
            this.lblOuder2_Email2.Size = new System.Drawing.Size(54, 17);
            this.lblOuder2_Email2.TabIndex = 67;
            this.lblOuder2_Email2.Text = "Email2 ";
            // 
            // txtOuder2_Email1
            // 
            this.txtOuder2_Email1.AllowDrop = true;
            this.txtOuder2_Email1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtOuder2_Email1.Location = new System.Drawing.Point(100, 57);
            this.txtOuder2_Email1.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder2_Email1.Name = "txtOuder2_Email1";
            this.txtOuder2_Email1.Size = new System.Drawing.Size(264, 22);
            this.txtOuder2_Email1.TabIndex = 61;
            this.txtOuder2_Email1.Text = "ouder2_email1 ";
            this.txtOuder2_Email1.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder2_Email1_Validating);
            // 
            // lblOuder2_Email1
            // 
            this.lblOuder2_Email1.AutoSize = true;
            this.lblOuder2_Email1.Location = new System.Drawing.Point(8, 60);
            this.lblOuder2_Email1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder2_Email1.Name = "lblOuder2_Email1";
            this.lblOuder2_Email1.Size = new System.Drawing.Size(54, 17);
            this.lblOuder2_Email1.TabIndex = 68;
            this.lblOuder2_Email1.Text = "Email1 ";
            // 
            // txtOuder2_Naam
            // 
            this.txtOuder2_Naam.AllowDrop = true;
            this.txtOuder2_Naam.Location = new System.Drawing.Point(100, 25);
            this.txtOuder2_Naam.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder2_Naam.Name = "txtOuder2_Naam";
            this.txtOuder2_Naam.Size = new System.Drawing.Size(264, 22);
            this.txtOuder2_Naam.TabIndex = 60;
            this.txtOuder2_Naam.Text = "Ouder2_Naam ";
            // 
            // lblOuder2_Naam
            // 
            this.lblOuder2_Naam.AutoSize = true;
            this.lblOuder2_Naam.Location = new System.Drawing.Point(8, 28);
            this.lblOuder2_Naam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder2_Naam.Name = "lblOuder2_Naam";
            this.lblOuder2_Naam.Size = new System.Drawing.Size(49, 17);
            this.lblOuder2_Naam.TabIndex = 69;
            this.lblOuder2_Naam.Text = "Naam ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtpPakketTot);
            this.groupBox4.Controls.Add(this.dtpLidVanaf);
            this.groupBox4.Controls.Add(this.dtpLidTot);
            this.groupBox4.Controls.Add(this.lblLidVanaf);
            this.groupBox4.Controls.Add(this.ckbOpgezegd);
            this.groupBox4.Controls.Add(this.lblPakketTot);
            this.groupBox4.Controls.Add(this.lblLidTot);
            this.groupBox4.Location = new System.Drawing.Point(872, 228);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(269, 158);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            // 
            // dtpPakketTot
            // 
            this.dtpPakketTot.Enabled = false;
            this.dtpPakketTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPakketTot.Location = new System.Drawing.Point(89, 114);
            this.dtpPakketTot.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPakketTot.Name = "dtpPakketTot";
            this.dtpPakketTot.Size = new System.Drawing.Size(129, 22);
            this.dtpPakketTot.TabIndex = 4;
            this.dtpPakketTot.Value = new System.DateTime(2013, 5, 15, 0, 0, 0, 0);
            // 
            // dtpLidVanaf
            // 
            this.dtpLidVanaf.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLidVanaf.Location = new System.Drawing.Point(89, 23);
            this.dtpLidVanaf.Margin = new System.Windows.Forms.Padding(4);
            this.dtpLidVanaf.Name = "dtpLidVanaf";
            this.dtpLidVanaf.Size = new System.Drawing.Size(129, 22);
            this.dtpLidVanaf.TabIndex = 1;
            this.dtpLidVanaf.Value = new System.DateTime(2013, 5, 15, 0, 0, 0, 0);
            // 
            // dtpLidTot
            // 
            this.dtpLidTot.Enabled = false;
            this.dtpLidTot.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLidTot.Location = new System.Drawing.Point(89, 82);
            this.dtpLidTot.Margin = new System.Windows.Forms.Padding(4);
            this.dtpLidTot.Name = "dtpLidTot";
            this.dtpLidTot.Size = new System.Drawing.Size(129, 22);
            this.dtpLidTot.TabIndex = 3;
            this.dtpLidTot.TabStop = false;
            this.dtpLidTot.Value = new System.DateTime(2013, 5, 15, 0, 0, 0, 0);
            // 
            // lblLidVanaf
            // 
            this.lblLidVanaf.AutoSize = true;
            this.lblLidVanaf.Location = new System.Drawing.Point(11, 27);
            this.lblLidVanaf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLidVanaf.Name = "lblLidVanaf";
            this.lblLidVanaf.Size = new System.Drawing.Size(64, 17);
            this.lblLidVanaf.TabIndex = 44;
            this.lblLidVanaf.Text = "LidVanaf";
            // 
            // ckbOpgezegd
            // 
            this.ckbOpgezegd.Location = new System.Drawing.Point(91, 55);
            this.ckbOpgezegd.Margin = new System.Windows.Forms.Padding(4);
            this.ckbOpgezegd.Name = "ckbOpgezegd";
            this.ckbOpgezegd.Size = new System.Drawing.Size(100, 21);
            this.ckbOpgezegd.TabIndex = 2;
            this.ckbOpgezegd.TabStop = false;
            this.ckbOpgezegd.Text = "Opgezegd";
            this.ckbOpgezegd.UseVisualStyleBackColor = true;
            this.ckbOpgezegd.CheckedChanged += new System.EventHandler(this.ckbOpgezegd_CheckedChanged);
            // 
            // lblPakketTot
            // 
            this.lblPakketTot.AutoSize = true;
            this.lblPakketTot.Location = new System.Drawing.Point(11, 119);
            this.lblPakketTot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPakketTot.Name = "lblPakketTot";
            this.lblPakketTot.Size = new System.Drawing.Size(72, 17);
            this.lblPakketTot.TabIndex = 45;
            this.lblPakketTot.Text = "PakketTot";
            // 
            // lblLidTot
            // 
            this.lblLidTot.AutoSize = true;
            this.lblLidTot.Location = new System.Drawing.Point(11, 87);
            this.lblLidTot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLidTot.Name = "lblLidTot";
            this.lblLidTot.Size = new System.Drawing.Size(48, 17);
            this.lblLidTot.TabIndex = 46;
            this.lblLidTot.Text = "LidTot";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBondsNr);
            this.groupBox3.Controls.Add(this.lblBondsNr);
            this.groupBox3.Controls.Add(this.ckbCompGerechtigd);
            this.groupBox3.Controls.Add(this.ckbLidBond);
            this.groupBox3.Location = new System.Drawing.Point(667, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(187, 114);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // txtBondsNr
            // 
            this.txtBondsNr.AllowDrop = true;
            this.txtBondsNr.Location = new System.Drawing.Point(89, 80);
            this.txtBondsNr.Margin = new System.Windows.Forms.Padding(4);
            this.txtBondsNr.MaxLength = 7;
            this.txtBondsNr.Name = "txtBondsNr";
            this.txtBondsNr.Size = new System.Drawing.Size(68, 22);
            this.txtBondsNr.TabIndex = 3;
            this.txtBondsNr.Text = "BondsNr ";
            this.toolTip1.SetToolTip(this.txtBondsNr, "Ctrl-B is bondsnummer kopieren");
            this.txtBondsNr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBondsNr_KeyDown);
            this.txtBondsNr.Validating += new System.ComponentModel.CancelEventHandler(this.txtBondsNr_Validating);
            // 
            // lblBondsNr
            // 
            this.lblBondsNr.AutoSize = true;
            this.lblBondsNr.Location = new System.Drawing.Point(12, 84);
            this.lblBondsNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBondsNr.Name = "lblBondsNr";
            this.lblBondsNr.Size = new System.Drawing.Size(67, 17);
            this.lblBondsNr.TabIndex = 33;
            this.lblBondsNr.Text = "BondsNr ";
            // 
            // ckbCompGerechtigd
            // 
            this.ckbCompGerechtigd.AutoSize = true;
            this.ckbCompGerechtigd.Location = new System.Drawing.Point(16, 49);
            this.ckbCompGerechtigd.Margin = new System.Windows.Forms.Padding(4);
            this.ckbCompGerechtigd.Name = "ckbCompGerechtigd";
            this.ckbCompGerechtigd.Size = new System.Drawing.Size(140, 21);
            this.ckbCompGerechtigd.TabIndex = 2;
            this.ckbCompGerechtigd.Text = "Comp.Gerechtigd";
            this.ckbCompGerechtigd.UseVisualStyleBackColor = true;
            // 
            // ckbLidBond
            // 
            this.ckbLidBond.AutoSize = true;
            this.ckbLidBond.Location = new System.Drawing.Point(16, 17);
            this.ckbLidBond.Margin = new System.Windows.Forms.Padding(4);
            this.ckbLidBond.Name = "ckbLidBond";
            this.ckbLidBond.Size = new System.Drawing.Size(86, 21);
            this.ckbLidBond.TabIndex = 1;
            this.ckbLidBond.Text = "Lid Bond";
            this.ckbLidBond.UseVisualStyleBackColor = true;
            this.ckbLidBond.CheckedChanged += new System.EventHandler(this.ckbLidBond_CheckedChanged);
            // 
            // rbuV
            // 
            this.rbuV.AutoSize = true;
            this.rbuV.Location = new System.Drawing.Point(181, 306);
            this.rbuV.Margin = new System.Windows.Forms.Padding(4);
            this.rbuV.Name = "rbuV";
            this.rbuV.Size = new System.Drawing.Size(38, 21);
            this.rbuV.TabIndex = 13;
            this.rbuV.Text = "V";
            this.rbuV.UseVisualStyleBackColor = true;
            // 
            // rbuM
            // 
            this.rbuM.AutoSize = true;
            this.rbuM.Checked = true;
            this.rbuM.Location = new System.Drawing.Point(136, 306);
            this.rbuM.Margin = new System.Windows.Forms.Padding(4);
            this.rbuM.Name = "rbuM";
            this.rbuM.Size = new System.Drawing.Size(40, 21);
            this.rbuM.TabIndex = 12;
            this.rbuM.TabStop = true;
            this.rbuM.Text = "M";
            this.rbuM.UseVisualStyleBackColor = true;
            // 
            // ckbGemerkt
            // 
            this.ckbGemerkt.AutoSize = true;
            this.ckbGemerkt.Location = new System.Drawing.Point(212, 15);
            this.ckbGemerkt.Margin = new System.Windows.Forms.Padding(4);
            this.ckbGemerkt.Name = "ckbGemerkt";
            this.ckbGemerkt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckbGemerkt.Size = new System.Drawing.Size(84, 21);
            this.ckbGemerkt.TabIndex = 404;
            this.ckbGemerkt.Text = "Gemerkt";
            this.ckbGemerkt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboBetaalwijze);
            this.groupBox2.Controls.Add(this.cboLidType);
            this.groupBox2.Controls.Add(this.lblBetaalWijze);
            this.groupBox2.Controls.Add(this.lblVastBedrag);
            this.groupBox2.Controls.Add(this.ckbGeincasseerd);
            this.groupBox2.Controls.Add(this.txtVastBedrag);
            this.groupBox2.Controls.Add(this.lblKorting);
            this.groupBox2.Controls.Add(this.txtKorting);
            this.groupBox2.Controls.Add(this.lblLidType);
            this.groupBox2.Location = new System.Drawing.Point(872, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(269, 207);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            // 
            // cboBetaalwijze
            // 
            this.cboBetaalwijze.FormattingEnabled = true;
            this.cboBetaalwijze.Location = new System.Drawing.Point(113, 59);
            this.cboBetaalwijze.Margin = new System.Windows.Forms.Padding(4);
            this.cboBetaalwijze.Name = "cboBetaalwijze";
            this.cboBetaalwijze.Size = new System.Drawing.Size(128, 24);
            this.cboBetaalwijze.TabIndex = 2;
            this.cboBetaalwijze.SelectedIndexChanged += new System.EventHandler(this.cboBetaalwijze_SelectedIndexChanged);
            // 
            // cboLidType
            // 
            this.cboLidType.FormattingEnabled = true;
            this.cboLidType.Location = new System.Drawing.Point(113, 23);
            this.cboLidType.Margin = new System.Windows.Forms.Padding(4);
            this.cboLidType.Name = "cboLidType";
            this.cboLidType.Size = new System.Drawing.Size(129, 24);
            this.cboLidType.TabIndex = 1;
            this.cboLidType.SelectedIndexChanged += new System.EventHandler(this.cboLidType_SelectedIndexChanged);
            // 
            // lblBetaalWijze
            // 
            this.lblBetaalWijze.AutoSize = true;
            this.lblBetaalWijze.Location = new System.Drawing.Point(8, 65);
            this.lblBetaalWijze.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBetaalWijze.Name = "lblBetaalWijze";
            this.lblBetaalWijze.Size = new System.Drawing.Size(82, 17);
            this.lblBetaalWijze.TabIndex = 35;
            this.lblBetaalWijze.Text = "BetaalWijze";
            // 
            // lblVastBedrag
            // 
            this.lblVastBedrag.AutoSize = true;
            this.lblVastBedrag.Location = new System.Drawing.Point(9, 100);
            this.lblVastBedrag.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVastBedrag.Name = "lblVastBedrag";
            this.lblVastBedrag.Size = new System.Drawing.Size(82, 17);
            this.lblVastBedrag.TabIndex = 36;
            this.lblVastBedrag.Text = "VastBedrag";
            // 
            // ckbGeincasseerd
            // 
            this.ckbGeincasseerd.AutoSize = true;
            this.ckbGeincasseerd.Location = new System.Drawing.Point(12, 169);
            this.ckbGeincasseerd.Margin = new System.Windows.Forms.Padding(4);
            this.ckbGeincasseerd.Name = "ckbGeincasseerd";
            this.ckbGeincasseerd.Size = new System.Drawing.Size(227, 21);
            this.ckbGeincasseerd.TabIndex = 1;
            this.ckbGeincasseerd.Text = "Lid is al een keer geincasseerd";
            this.toolTip1.SetToolTip(this.ckbGeincasseerd, "Dit heeft te maken met de incasso\'s.\r\nBij de incasso moeten we aangeven of het de" +
        "\r\neerste keer is dat een lid wordt geincasseerd.");
            this.ckbGeincasseerd.UseVisualStyleBackColor = true;
            this.ckbGeincasseerd.CheckedChanged += new System.EventHandler(this.ckbToernooi_CheckedChanged);
            // 
            // txtVastBedrag
            // 
            this.txtVastBedrag.DecimalPlaces = 2;
            this.txtVastBedrag.DecimalsSeparator = ',';
            this.txtVastBedrag.Location = new System.Drawing.Point(113, 96);
            this.txtVastBedrag.Margin = new System.Windows.Forms.Padding(4);
            this.txtVastBedrag.Name = "txtVastBedrag";
            this.txtVastBedrag.PreFix = "€";
            this.txtVastBedrag.Size = new System.Drawing.Size(129, 22);
            this.txtVastBedrag.TabIndex = 3;
            this.txtVastBedrag.TabStop = false;
            this.txtVastBedrag.Text = "€ 0";
            this.txtVastBedrag.ThousandsSeparator = '.';
            this.txtVastBedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtVastBedrag.ToFromInteger = 0;
            // 
            // lblKorting
            // 
            this.lblKorting.AutoSize = true;
            this.lblKorting.Location = new System.Drawing.Point(9, 132);
            this.lblKorting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKorting.Name = "lblKorting";
            this.lblKorting.Size = new System.Drawing.Size(53, 17);
            this.lblKorting.TabIndex = 37;
            this.lblKorting.Text = "Korting";
            // 
            // txtKorting
            // 
            this.txtKorting.DecimalPlaces = 2;
            this.txtKorting.DecimalsSeparator = ',';
            this.txtKorting.Location = new System.Drawing.Point(113, 128);
            this.txtKorting.Margin = new System.Windows.Forms.Padding(4);
            this.txtKorting.Name = "txtKorting";
            this.txtKorting.PreFix = "€";
            this.txtKorting.Size = new System.Drawing.Size(129, 22);
            this.txtKorting.TabIndex = 4;
            this.txtKorting.TabStop = false;
            this.txtKorting.Text = "€ 0";
            this.txtKorting.ThousandsSeparator = '.';
            this.txtKorting.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKorting.ToFromInteger = 0;
            // 
            // lblLidType
            // 
            this.lblLidType.AutoSize = true;
            this.lblLidType.Location = new System.Drawing.Point(9, 27);
            this.lblLidType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLidType.Name = "lblLidType";
            this.lblLidType.Size = new System.Drawing.Size(63, 17);
            this.lblLidType.TabIndex = 38;
            this.lblLidType.Text = "LidType ";
            // 
            // grpOuder1
            // 
            this.grpOuder1.Controls.Add(this.txtOuder1_Naam);
            this.grpOuder1.Controls.Add(this.lblOuder1_Naam);
            this.grpOuder1.Controls.Add(this.txtOuder1_Email1);
            this.grpOuder1.Controls.Add(this.txtOuder1_Email2);
            this.grpOuder1.Controls.Add(this.txtOuder1_Mobiel);
            this.grpOuder1.Controls.Add(this.txtOuder1_Telefoon);
            this.grpOuder1.Controls.Add(this.lblOuder1_Email1);
            this.grpOuder1.Controls.Add(this.lblOuder1_Email2);
            this.grpOuder1.Controls.Add(this.lblOuder1_Mobiel);
            this.grpOuder1.Controls.Add(this.lblOuder1_Telefoon);
            this.grpOuder1.Location = new System.Drawing.Point(36, 407);
            this.grpOuder1.Margin = new System.Windows.Forms.Padding(4);
            this.grpOuder1.Name = "grpOuder1";
            this.grpOuder1.Padding = new System.Windows.Forms.Padding(4);
            this.grpOuder1.Size = new System.Drawing.Size(381, 199);
            this.grpOuder1.TabIndex = 17;
            this.grpOuder1.TabStop = false;
            this.grpOuder1.Text = "Ouders";
            // 
            // txtOuder1_Naam
            // 
            this.txtOuder1_Naam.AllowDrop = true;
            this.txtOuder1_Naam.Location = new System.Drawing.Point(100, 32);
            this.txtOuder1_Naam.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder1_Naam.Name = "txtOuder1_Naam";
            this.txtOuder1_Naam.Size = new System.Drawing.Size(264, 22);
            this.txtOuder1_Naam.TabIndex = 1;
            this.txtOuder1_Naam.Text = "Ouder1_Naam ";
            // 
            // lblOuder1_Naam
            // 
            this.lblOuder1_Naam.AutoSize = true;
            this.lblOuder1_Naam.Location = new System.Drawing.Point(8, 36);
            this.lblOuder1_Naam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder1_Naam.Name = "lblOuder1_Naam";
            this.lblOuder1_Naam.Size = new System.Drawing.Size(49, 17);
            this.lblOuder1_Naam.TabIndex = 1;
            this.lblOuder1_Naam.Text = "Naam ";
            // 
            // txtOuder1_Email1
            // 
            this.txtOuder1_Email1.AllowDrop = true;
            this.txtOuder1_Email1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtOuder1_Email1.Location = new System.Drawing.Point(100, 64);
            this.txtOuder1_Email1.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder1_Email1.Name = "txtOuder1_Email1";
            this.txtOuder1_Email1.Size = new System.Drawing.Size(264, 22);
            this.txtOuder1_Email1.TabIndex = 2;
            this.txtOuder1_Email1.Text = "ouder1_email1 ";
            this.txtOuder1_Email1.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder1_Email1_Validating);
            // 
            // txtOuder1_Email2
            // 
            this.txtOuder1_Email2.AllowDrop = true;
            this.txtOuder1_Email2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtOuder1_Email2.Location = new System.Drawing.Point(100, 96);
            this.txtOuder1_Email2.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder1_Email2.Name = "txtOuder1_Email2";
            this.txtOuder1_Email2.Size = new System.Drawing.Size(264, 22);
            this.txtOuder1_Email2.TabIndex = 3;
            this.txtOuder1_Email2.Text = "ouder1_email2 ";
            this.txtOuder1_Email2.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder1_Email2_Validating);
            // 
            // txtOuder1_Mobiel
            // 
            this.txtOuder1_Mobiel.AllowDrop = true;
            this.txtOuder1_Mobiel.Location = new System.Drawing.Point(100, 128);
            this.txtOuder1_Mobiel.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder1_Mobiel.Name = "txtOuder1_Mobiel";
            this.txtOuder1_Mobiel.Size = new System.Drawing.Size(100, 22);
            this.txtOuder1_Mobiel.TabIndex = 4;
            this.txtOuder1_Mobiel.Text = "Ouder1_Mobiel ";
            this.txtOuder1_Mobiel.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder1_Mobiel_Validating);
            // 
            // txtOuder1_Telefoon
            // 
            this.txtOuder1_Telefoon.AllowDrop = true;
            this.txtOuder1_Telefoon.Location = new System.Drawing.Point(100, 160);
            this.txtOuder1_Telefoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtOuder1_Telefoon.Name = "txtOuder1_Telefoon";
            this.txtOuder1_Telefoon.Size = new System.Drawing.Size(100, 22);
            this.txtOuder1_Telefoon.TabIndex = 5;
            this.txtOuder1_Telefoon.Text = "Ouder1_Telefoon ";
            this.txtOuder1_Telefoon.Validating += new System.ComponentModel.CancelEventHandler(this.txtOuder1_Telefoon_Validating);
            // 
            // lblOuder1_Email1
            // 
            this.lblOuder1_Email1.AutoSize = true;
            this.lblOuder1_Email1.Location = new System.Drawing.Point(8, 68);
            this.lblOuder1_Email1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder1_Email1.Name = "lblOuder1_Email1";
            this.lblOuder1_Email1.Size = new System.Drawing.Size(54, 17);
            this.lblOuder1_Email1.TabIndex = 6;
            this.lblOuder1_Email1.Text = "Email1 ";
            // 
            // lblOuder1_Email2
            // 
            this.lblOuder1_Email2.AutoSize = true;
            this.lblOuder1_Email2.Location = new System.Drawing.Point(8, 100);
            this.lblOuder1_Email2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder1_Email2.Name = "lblOuder1_Email2";
            this.lblOuder1_Email2.Size = new System.Drawing.Size(54, 17);
            this.lblOuder1_Email2.TabIndex = 7;
            this.lblOuder1_Email2.Text = "Email2 ";
            // 
            // lblOuder1_Mobiel
            // 
            this.lblOuder1_Mobiel.AutoSize = true;
            this.lblOuder1_Mobiel.Location = new System.Drawing.Point(8, 132);
            this.lblOuder1_Mobiel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder1_Mobiel.Name = "lblOuder1_Mobiel";
            this.lblOuder1_Mobiel.Size = new System.Drawing.Size(53, 17);
            this.lblOuder1_Mobiel.TabIndex = 8;
            this.lblOuder1_Mobiel.Text = "Mobiel ";
            // 
            // lblOuder1_Telefoon
            // 
            this.lblOuder1_Telefoon.AutoSize = true;
            this.lblOuder1_Telefoon.Location = new System.Drawing.Point(8, 164);
            this.lblOuder1_Telefoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOuder1_Telefoon.Name = "lblOuder1_Telefoon";
            this.lblOuder1_Telefoon.Size = new System.Drawing.Size(68, 17);
            this.lblOuder1_Telefoon.TabIndex = 9;
            this.lblOuder1_Telefoon.Text = "Telefoon ";
            // 
            // lblLidNr
            // 
            this.lblLidNr.AutoSize = true;
            this.lblLidNr.Location = new System.Drawing.Point(44, 16);
            this.lblLidNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLidNr.Name = "lblLidNr";
            this.lblLidNr.Size = new System.Drawing.Size(42, 17);
            this.lblLidNr.TabIndex = 407;
            this.lblLidNr.Text = "LidNr";
            this.lblLidNr.Click += new System.EventHandler(this.lblLidNr_Click);
            // 
            // txtLidNr
            // 
            this.txtLidNr.Location = new System.Drawing.Point(136, 12);
            this.txtLidNr.Margin = new System.Windows.Forms.Padding(4);
            this.txtLidNr.Name = "txtLidNr";
            this.txtLidNr.ReadOnly = true;
            this.txtLidNr.Size = new System.Drawing.Size(49, 22);
            this.txtLidNr.TabIndex = 101;
            this.txtLidNr.Text = "LidNr";
            // 
            // lblVoornaam
            // 
            this.lblVoornaam.AutoSize = true;
            this.lblVoornaam.Location = new System.Drawing.Point(44, 82);
            this.lblVoornaam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVoornaam.Name = "lblVoornaam";
            this.lblVoornaam.Size = new System.Drawing.Size(73, 17);
            this.lblVoornaam.TabIndex = 408;
            this.lblVoornaam.Text = "Voornaam";
            // 
            // txtVoornaam
            // 
            this.txtVoornaam.AllowDrop = true;
            this.txtVoornaam.Location = new System.Drawing.Point(136, 79);
            this.txtVoornaam.Margin = new System.Windows.Forms.Padding(4);
            this.txtVoornaam.Name = "txtVoornaam";
            this.txtVoornaam.Size = new System.Drawing.Size(129, 22);
            this.txtVoornaam.TabIndex = 3;
            this.txtVoornaam.Text = "Voornaam";
            // 
            // lblAchternaam
            // 
            this.lblAchternaam.AutoSize = true;
            this.lblAchternaam.Location = new System.Drawing.Point(44, 48);
            this.lblAchternaam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAchternaam.Name = "lblAchternaam";
            this.lblAchternaam.Size = new System.Drawing.Size(88, 17);
            this.lblAchternaam.TabIndex = 410;
            this.lblAchternaam.Text = "Achternaam ";
            // 
            // txtAchternaam
            // 
            this.txtAchternaam.AllowDrop = true;
            this.txtAchternaam.Location = new System.Drawing.Point(136, 44);
            this.txtAchternaam.Margin = new System.Windows.Forms.Padding(4);
            this.txtAchternaam.Name = "txtAchternaam";
            this.txtAchternaam.Size = new System.Drawing.Size(209, 22);
            this.txtAchternaam.TabIndex = 1;
            this.txtAchternaam.Text = "Achternaam ";
            // 
            // lblTussenvoegsel
            // 
            this.lblTussenvoegsel.AutoSize = true;
            this.lblTussenvoegsel.Location = new System.Drawing.Point(355, 48);
            this.lblTussenvoegsel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTussenvoegsel.Name = "lblTussenvoegsel";
            this.lblTussenvoegsel.Size = new System.Drawing.Size(66, 17);
            this.lblTussenvoegsel.TabIndex = 412;
            this.lblTussenvoegsel.Text = "Tussenv.";
            // 
            // txtTussenvoegsel
            // 
            this.txtTussenvoegsel.AllowDrop = true;
            this.txtTussenvoegsel.Location = new System.Drawing.Point(425, 44);
            this.txtTussenvoegsel.Margin = new System.Windows.Forms.Padding(4);
            this.txtTussenvoegsel.Name = "txtTussenvoegsel";
            this.txtTussenvoegsel.Size = new System.Drawing.Size(100, 22);
            this.txtTussenvoegsel.TabIndex = 2;
            this.txtTussenvoegsel.Text = "Tussenvoegsel ";
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Location = new System.Drawing.Point(44, 117);
            this.lblAdres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(49, 17);
            this.lblAdres.TabIndex = 414;
            this.lblAdres.Text = "Adres ";
            // 
            // txtAdres
            // 
            this.txtAdres.AllowDrop = true;
            this.txtAdres.Location = new System.Drawing.Point(136, 113);
            this.txtAdres.Margin = new System.Windows.Forms.Padding(4);
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(264, 22);
            this.txtAdres.TabIndex = 4;
            this.txtAdres.Text = "Adres ";
            // 
            // lblWoonplaats
            // 
            this.lblWoonplaats.AutoSize = true;
            this.lblWoonplaats.Location = new System.Drawing.Point(308, 149);
            this.lblWoonplaats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWoonplaats.Name = "lblWoonplaats";
            this.lblWoonplaats.Size = new System.Drawing.Size(87, 17);
            this.lblWoonplaats.TabIndex = 416;
            this.lblWoonplaats.Text = "Woonplaats ";
            // 
            // txtWoonplaats
            // 
            this.txtWoonplaats.AllowDrop = true;
            this.txtWoonplaats.AutoCompleteCustomSource.AddRange(new string[] {
            "NIEUWEGEIN",
            "IJSSELSTEIN",
            "UTRECHT"});
            this.txtWoonplaats.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtWoonplaats.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtWoonplaats.Location = new System.Drawing.Point(425, 145);
            this.txtWoonplaats.Margin = new System.Windows.Forms.Padding(4);
            this.txtWoonplaats.Name = "txtWoonplaats";
            this.txtWoonplaats.Size = new System.Drawing.Size(209, 22);
            this.txtWoonplaats.TabIndex = 6;
            this.txtWoonplaats.Text = "Woonplaats ";
            // 
            // lblPostcode
            // 
            this.lblPostcode.AutoSize = true;
            this.lblPostcode.Location = new System.Drawing.Point(44, 149);
            this.lblPostcode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostcode.Name = "lblPostcode";
            this.lblPostcode.Size = new System.Drawing.Size(71, 17);
            this.lblPostcode.TabIndex = 418;
            this.lblPostcode.Text = "Postcode ";
            // 
            // txtPostcode
            // 
            this.txtPostcode.AllowDrop = true;
            this.txtPostcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPostcode.Location = new System.Drawing.Point(136, 145);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostcode.MaxLength = 6;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(68, 22);
            this.txtPostcode.TabIndex = 5;
            this.txtPostcode.Text = "1234AA";
            this.txtPostcode.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostcode_Validating);
            // 
            // lblMobiel
            // 
            this.lblMobiel.AutoSize = true;
            this.lblMobiel.Location = new System.Drawing.Point(308, 181);
            this.lblMobiel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMobiel.Name = "lblMobiel";
            this.lblMobiel.Size = new System.Drawing.Size(53, 17);
            this.lblMobiel.TabIndex = 420;
            this.lblMobiel.Text = "Mobiel ";
            // 
            // txtMobiel
            // 
            this.txtMobiel.AllowDrop = true;
            this.txtMobiel.Location = new System.Drawing.Point(425, 177);
            this.txtMobiel.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobiel.Name = "txtMobiel";
            this.txtMobiel.Size = new System.Drawing.Size(129, 22);
            this.txtMobiel.TabIndex = 8;
            this.txtMobiel.Text = "Mobiel ";
            this.txtMobiel.Validating += new System.ComponentModel.CancelEventHandler(this.txtMobiel_Validating);
            // 
            // lblTelefoon
            // 
            this.lblTelefoon.AutoSize = true;
            this.lblTelefoon.Location = new System.Drawing.Point(44, 181);
            this.lblTelefoon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefoon.Name = "lblTelefoon";
            this.lblTelefoon.Size = new System.Drawing.Size(68, 17);
            this.lblTelefoon.TabIndex = 422;
            this.lblTelefoon.Text = "Telefoon ";
            // 
            // txtTelefoon
            // 
            this.txtTelefoon.AllowDrop = true;
            this.txtTelefoon.Location = new System.Drawing.Point(136, 177);
            this.txtTelefoon.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefoon.MaxLength = 25;
            this.txtTelefoon.Name = "txtTelefoon";
            this.txtTelefoon.Size = new System.Drawing.Size(100, 22);
            this.txtTelefoon.TabIndex = 7;
            this.txtTelefoon.Text = "030-1234567";
            this.txtTelefoon.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefoon_Validating);
            // 
            // lblGeslacht
            // 
            this.lblGeslacht.AutoSize = true;
            this.lblGeslacht.Location = new System.Drawing.Point(44, 310);
            this.lblGeslacht.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeslacht.Name = "lblGeslacht";
            this.lblGeslacht.Size = new System.Drawing.Size(68, 17);
            this.lblGeslacht.TabIndex = 424;
            this.lblGeslacht.Text = "Geslacht ";
            // 
            // lblGeboorteDatum
            // 
            this.lblGeboorteDatum.AutoSize = true;
            this.lblGeboorteDatum.Location = new System.Drawing.Point(44, 278);
            this.lblGeboorteDatum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGeboorteDatum.Name = "lblGeboorteDatum";
            this.lblGeboorteDatum.Size = new System.Drawing.Size(84, 17);
            this.lblGeboorteDatum.TabIndex = 425;
            this.lblGeboorteDatum.Text = "Geb.Datum ";
            // 
            // lblEmail1
            // 
            this.lblEmail1.AutoSize = true;
            this.lblEmail1.Location = new System.Drawing.Point(44, 213);
            this.lblEmail1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail1.Name = "lblEmail1";
            this.lblEmail1.Size = new System.Drawing.Size(42, 17);
            this.lblEmail1.TabIndex = 426;
            this.lblEmail1.Text = "Email";
            // 
            // txtEmail1
            // 
            this.txtEmail1.AllowDrop = true;
            this.txtEmail1.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail1.Location = new System.Drawing.Point(136, 209);
            this.txtEmail1.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail1.Name = "txtEmail1";
            this.txtEmail1.Size = new System.Drawing.Size(291, 22);
            this.txtEmail1.TabIndex = 9;
            this.txtEmail1.Text = "email1 ";
            this.txtEmail1.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail1_Validating);
            // 
            // lblEmail2
            // 
            this.lblEmail2.AutoSize = true;
            this.lblEmail2.Location = new System.Drawing.Point(44, 245);
            this.lblEmail2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail2.Name = "lblEmail2";
            this.lblEmail2.Size = new System.Drawing.Size(50, 17);
            this.lblEmail2.TabIndex = 428;
            this.lblEmail2.Text = "Email2";
            // 
            // txtEmail2
            // 
            this.txtEmail2.AllowDrop = true;
            this.txtEmail2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail2.Location = new System.Drawing.Point(136, 241);
            this.txtEmail2.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail2.Name = "txtEmail2";
            this.txtEmail2.Size = new System.Drawing.Size(291, 22);
            this.txtEmail2.TabIndex = 10;
            this.txtEmail2.Text = "email2 ";
            this.txtEmail2.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail2_Validating);
            // 
            // lblIBAN
            // 
            this.lblIBAN.AutoSize = true;
            this.lblIBAN.Location = new System.Drawing.Point(44, 340);
            this.lblIBAN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(43, 17);
            this.lblIBAN.TabIndex = 430;
            this.lblIBAN.Text = "IBAN ";
            // 
            // txtIBAN
            // 
            this.txtIBAN.AllowDrop = true;
            this.txtIBAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIBAN.Location = new System.Drawing.Point(136, 336);
            this.txtIBAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(183, 22);
            this.txtIBAN.TabIndex = 14;
            this.txtIBAN.Text = "NL58RABO1234567890";
            this.txtIBAN.Validating += new System.ComponentModel.CancelEventHandler(this.txtIBAN_Validating);
            // 
            // lblBIC
            // 
            this.lblBIC.AutoSize = true;
            this.lblBIC.Location = new System.Drawing.Point(348, 340);
            this.lblBIC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBIC.Name = "lblBIC";
            this.lblBIC.Size = new System.Drawing.Size(33, 17);
            this.lblBIC.TabIndex = 432;
            this.lblBIC.Text = "BIC ";
            // 
            // txtBIC
            // 
            this.txtBIC.AllowDrop = true;
            this.txtBIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBIC.Location = new System.Drawing.Point(387, 336);
            this.txtBIC.Margin = new System.Windows.Forms.Padding(4);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(111, 22);
            this.txtBIC.TabIndex = 15;
            this.txtBIC.Text = "NLING000000";
            this.txtBIC.Validating += new System.ComponentModel.CancelEventHandler(this.txtBIC_Validating);
            // 
            // lblU_PasNr
            // 
            this.lblU_PasNr.AutoSize = true;
            this.lblU_PasNr.Location = new System.Drawing.Point(44, 372);
            this.lblU_PasNr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblU_PasNr.Name = "lblU_PasNr";
            this.lblU_PasNr.Size = new System.Drawing.Size(62, 17);
            this.lblU_PasNr.TabIndex = 434;
            this.lblU_PasNr.Text = "U-PasNr";
            // 
            // txtU_PasNr
            // 
            this.txtU_PasNr.AllowDrop = true;
            this.txtU_PasNr.Location = new System.Drawing.Point(136, 368);
            this.txtU_PasNr.Margin = new System.Windows.Forms.Padding(4);
            this.txtU_PasNr.Name = "txtU_PasNr";
            this.txtU_PasNr.Size = new System.Drawing.Size(129, 22);
            this.txtU_PasNr.TabIndex = 16;
            this.txtU_PasNr.Text = "U_PasNr";
            // 
            // pnlPoule
            // 
            this.pnlPoule.AllowDrop = true;
            this.pnlPoule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPoule.Controls.Add(this.cmdRekeningen);
            this.pnlPoule.Controls.Add(this.cmdChange);
            this.pnlPoule.Controls.Add(this.statusBar1);
            this.pnlPoule.Controls.Add(this.cmdTTKaart);
            this.pnlPoule.Controls.Add(this.cmdSendEmail);
            this.pnlPoule.Controls.Add(this.cmdSelectForm);
            this.pnlPoule.Controls.Add(this.cmdNew);
            this.pnlPoule.Controls.Add(this.cmdSave);
            this.pnlPoule.Controls.Add(this.cmdCancel2);
            this.pnlPoule.Controls.Add(this.Exit);
            this.pnlPoule.Controls.Add(this.pnlDetails);
            this.pnlPoule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPoule.Location = new System.Drawing.Point(0, 89);
            this.pnlPoule.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPoule.Name = "pnlPoule";
            this.pnlPoule.Size = new System.Drawing.Size(1345, 654);
            this.pnlPoule.TabIndex = 0;
            this.pnlPoule.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheel_Event);
            // 
            // cmdRekeningen
            // 
            this.cmdRekeningen.Location = new System.Drawing.Point(1217, 123);
            this.cmdRekeningen.Margin = new System.Windows.Forms.Padding(4);
            this.cmdRekeningen.Name = "cmdRekeningen";
            this.cmdRekeningen.Size = new System.Drawing.Size(100, 28);
            this.cmdRekeningen.TabIndex = 445;
            this.cmdRekeningen.Text = "Rekeningen";
            this.cmdRekeningen.UseVisualStyleBackColor = true;
            this.cmdRekeningen.Click += new System.EventHandler(this.cmdRekeningen_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(1217, 431);
            this.cmdChange.Margin = new System.Windows.Forms.Padding(4);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(100, 28);
            this.cmdChange.TabIndex = 496;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 625);
            this.statusBar1.Margin = new System.Windows.Forms.Padding(4);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.sbpFileName,
            this.sbpStatusMessage,
            this.sbpRecordNr});
            this.statusBar1.ShowPanels = true;
            this.statusBar1.Size = new System.Drawing.Size(1343, 27);
            this.statusBar1.SizingGrip = false;
            this.statusBar1.TabIndex = 436;
            // 
            // sbpFileName
            // 
            this.sbpFileName.MinWidth = 100;
            this.sbpFileName.Name = "sbpFileName";
            this.sbpFileName.Width = 500;
            // 
            // sbpStatusMessage
            // 
            this.sbpStatusMessage.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.sbpStatusMessage.Name = "sbpStatusMessage";
            this.sbpStatusMessage.Width = 783;
            // 
            // sbpRecordNr
            // 
            this.sbpRecordNr.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised;
            this.sbpRecordNr.MinWidth = 60;
            this.sbpRecordNr.Name = "sbpRecordNr";
            this.sbpRecordNr.Width = 60;
            // 
            // cmdTTKaart
            // 
            this.cmdTTKaart.Location = new System.Drawing.Point(1217, 245);
            this.cmdTTKaart.Margin = new System.Windows.Forms.Padding(4);
            this.cmdTTKaart.Name = "cmdTTKaart";
            this.cmdTTKaart.Size = new System.Drawing.Size(100, 28);
            this.cmdTTKaart.TabIndex = 446;
            this.cmdTTKaart.Text = "TT-Kaart";
            this.cmdTTKaart.UseVisualStyleBackColor = true;
            this.cmdTTKaart.Click += new System.EventHandler(this.cmdTTKaart_Click);
            // 
            // cmdSendEmail
            // 
            this.cmdSendEmail.Location = new System.Drawing.Point(1217, 181);
            this.cmdSendEmail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSendEmail.Name = "cmdSendEmail";
            this.cmdSendEmail.Size = new System.Drawing.Size(100, 28);
            this.cmdSendEmail.TabIndex = 445;
            this.cmdSendEmail.Text = "Send E-Mail";
            this.cmdSendEmail.UseVisualStyleBackColor = true;
            this.cmdSendEmail.Click += new System.EventHandler(this.cmdSendEmail_Click);
            // 
            // cmdSelectForm
            // 
            this.cmdSelectForm.Location = new System.Drawing.Point(1217, 16);
            this.cmdSelectForm.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSelectForm.Name = "cmdSelectForm";
            this.cmdSelectForm.Size = new System.Drawing.Size(100, 28);
            this.cmdSelectForm.TabIndex = 0;
            this.cmdSelectForm.Text = "Select";
            this.cmdSelectForm.UseVisualStyleBackColor = true;
            this.cmdSelectForm.Click += new System.EventHandler(this.cmdSelectForm_Click);
            // 
            // cmdCancel2
            // 
            this.cmdCancel2.Location = new System.Drawing.Point(1217, 468);
            this.cmdCancel2.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancel2.Name = "cmdCancel2";
            this.cmdCancel2.Size = new System.Drawing.Size(100, 28);
            this.cmdCancel2.TabIndex = 22;
            this.cmdCancel2.Text = "Cancel";
            this.cmdCancel2.UseVisualStyleBackColor = true;
            this.cmdCancel2.Visible = false;
            this.cmdCancel2.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // Exit
            // 
            this.Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Exit.Location = new System.Drawing.Point(1216, 565);
            this.Exit.Margin = new System.Windows.Forms.Padding(4);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(100, 28);
            this.Exit.TabIndex = 442;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.txtSearch);
            this.pnlButtons.Controls.Add(this.cbkInclOpgezegd);
            this.pnlButtons.Controls.Add(this.ckbSortLidNbr);
            this.pnlButtons.Controls.Add(this.mnuMenu);
            this.pnlButtons.Controls.Add(this.cboLeden);
            this.pnlButtons.Controls.Add(this.btnPrevious);
            this.pnlButtons.Controls.Add(this.btnFirst);
            this.pnlButtons.Controls.Add(this.btnNext);
            this.pnlButtons.Controls.Add(this.btnLast);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1345, 89);
            this.pnlButtons.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtSearch.Location = new System.Drawing.Point(1135, 44);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(181, 22);
            this.txtSearch.TabIndex = 464;
            this.txtSearch.Text = "Search ...";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // cbkInclOpgezegd
            // 
            this.cbkInclOpgezegd.AutoSize = true;
            this.cbkInclOpgezegd.Location = new System.Drawing.Point(833, 47);
            this.cbkInclOpgezegd.Margin = new System.Windows.Forms.Padding(4);
            this.cbkInclOpgezegd.Name = "cbkInclOpgezegd";
            this.cbkInclOpgezegd.Size = new System.Drawing.Size(125, 21);
            this.cbkInclOpgezegd.TabIndex = 405;
            this.cbkInclOpgezegd.Text = "Incl. Opgezegd";
            this.cbkInclOpgezegd.UseVisualStyleBackColor = true;
            this.cbkInclOpgezegd.CheckedChanged += new System.EventHandler(this.cbkInclOpgezegd_CheckedChanged);
            // 
            // ckbSortLidNbr
            // 
            this.ckbSortLidNbr.AutoSize = true;
            this.ckbSortLidNbr.Location = new System.Drawing.Point(685, 47);
            this.ckbSortLidNbr.Margin = new System.Windows.Forms.Padding(4);
            this.ckbSortLidNbr.Name = "ckbSortLidNbr";
            this.ckbSortLidNbr.Size = new System.Drawing.Size(114, 21);
            this.ckbSortLidNbr.TabIndex = 100;
            this.ckbSortLidNbr.Text = "Sort on LidNr";
            this.ckbSortLidNbr.UseVisualStyleBackColor = true;
            this.ckbSortLidNbr.CheckedChanged += new System.EventHandler(this.ckbSortLidNbr_CheckedChanged);
            // 
            // mnuMenu
            // 
            this.mnuMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.rekeningenToolStripMenuItem,
            this.lijstenToolStripMenuItem,
            this.mailToolStripMenuItem,
            this.extraToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMenu.Size = new System.Drawing.Size(1345, 28);
            this.mnuMenu.TabIndex = 406;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripSeparator1,
            this.mnuFileFiles,
            this.toolStripSeparator2,
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(44, 24);
            this.mnuFile.Text = "&File";
            // 
            // mnuFileOpen
            // 
            this.mnuFileOpen.Name = "mnuFileOpen";
            this.mnuFileOpen.Size = new System.Drawing.Size(153, 26);
            this.mnuFileOpen.Text = "Open";
            this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(150, 6);
            // 
            // mnuFileFiles
            // 
            this.mnuFileFiles.Name = "mnuFileFiles";
            this.mnuFileFiles.Size = new System.Drawing.Size(153, 26);
            this.mnuFileFiles.Text = "Bestanden";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(150, 6);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(153, 26);
            this.mnuFileExit.Text = "&Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // rekeningenToolStripMenuItem
            // 
            this.rekeningenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overzichtToolStripMenuItem,
            this.incassoKandidatenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aanmakenToolStripMenuItem,
            this.versturenAankondigingenToolStripMenuItem,
            this.handmatigAanmakenToolStripMenuItem,
            this.versturenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.verstuurdeVerwijderenToolStripMenuItem});
            this.rekeningenToolStripMenuItem.Name = "rekeningenToolStripMenuItem";
            this.rekeningenToolStripMenuItem.Size = new System.Drawing.Size(98, 24);
            this.rekeningenToolStripMenuItem.Text = "Rekeningen";
            // 
            // overzichtToolStripMenuItem
            // 
            this.overzichtToolStripMenuItem.Name = "overzichtToolStripMenuItem";
            this.overzichtToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.overzichtToolStripMenuItem.Text = "Overzicht per lid";
            this.overzichtToolStripMenuItem.Click += new System.EventHandler(this.overzichtToolStripMenuItem_Click);
            // 
            // incassoKandidatenToolStripMenuItem
            // 
            this.incassoKandidatenToolStripMenuItem.Name = "incassoKandidatenToolStripMenuItem";
            this.incassoKandidatenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.incassoKandidatenToolStripMenuItem.Text = "Overzicht Te Incasseren Rekeningen";
            this.incassoKandidatenToolStripMenuItem.Click += new System.EventHandler(this.incassoKandidatenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(315, 6);
            // 
            // aanmakenToolStripMenuItem
            // 
            this.aanmakenToolStripMenuItem.Name = "aanmakenToolStripMenuItem";
            this.aanmakenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.aanmakenToolStripMenuItem.Text = "Aanmaken Contributie";
            this.aanmakenToolStripMenuItem.Click += new System.EventHandler(this.aanmakenToolStripMenuItem_Click);
            // 
            // handmatigAanmakenToolStripMenuItem
            // 
            this.handmatigAanmakenToolStripMenuItem.Name = "handmatigAanmakenToolStripMenuItem";
            this.handmatigAanmakenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.handmatigAanmakenToolStripMenuItem.Text = "Aanmaken Eenmalige Rekening";
            this.handmatigAanmakenToolStripMenuItem.Click += new System.EventHandler(this.handmatigAanmakenToolStripMenuItem_Click);
            // 
            // versturenToolStripMenuItem
            // 
            this.versturenToolStripMenuItem.Name = "versturenToolStripMenuItem";
            this.versturenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.versturenToolStripMenuItem.Text = "Aanmaken Incasso Bestand";
            this.versturenToolStripMenuItem.Click += new System.EventHandler(this.versturenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(315, 6);
            // 
            // verstuurdeVerwijderenToolStripMenuItem
            // 
            this.verstuurdeVerwijderenToolStripMenuItem.Name = "verstuurdeVerwijderenToolStripMenuItem";
            this.verstuurdeVerwijderenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.verstuurdeVerwijderenToolStripMenuItem.Text = "Verwijderen Verstuurde Rekeningen";
            this.verstuurdeVerwijderenToolStripMenuItem.Click += new System.EventHandler(this.verstuurdeVerwijderenToolStripMenuItem_Click);
            // 
            // lijstenToolStripMenuItem
            // 
            this.lijstenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportNaarCSVToolStripMenuItem,
            this.aanmaakOutputForMailProgrammaToolStripMenuItem,
            this.lijstschermenToolStripMenuItem});
            this.lijstenToolStripMenuItem.Name = "lijstenToolStripMenuItem";
            this.lijstenToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.lijstenToolStripMenuItem.Text = "Lijsten";
            // 
            // exportNaarCSVToolStripMenuItem
            // 
            this.exportNaarCSVToolStripMenuItem.Name = "exportNaarCSVToolStripMenuItem";
            this.exportNaarCSVToolStripMenuItem.Size = new System.Drawing.Size(333, 26);
            this.exportNaarCSVToolStripMenuItem.Text = "Aanmaak LedenLijsten";
            this.exportNaarCSVToolStripMenuItem.Click += new System.EventHandler(this.exportNaarCSVToolStripMenuItem_Click);
            // 
            // aanmaakOutputForMailProgrammaToolStripMenuItem
            // 
            this.aanmaakOutputForMailProgrammaToolStripMenuItem.Name = "aanmaakOutputForMailProgrammaToolStripMenuItem";
            this.aanmaakOutputForMailProgrammaToolStripMenuItem.Size = new System.Drawing.Size(333, 26);
            this.aanmaakOutputForMailProgrammaToolStripMenuItem.Text = "Aanmaak output for Mail programma";
            this.aanmaakOutputForMailProgrammaToolStripMenuItem.Click += new System.EventHandler(this.aanmaakOutputForMailProgrammaToolStripMenuItem_Click);
            // 
            // lijstschermenToolStripMenuItem
            // 
            this.lijstschermenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toernooienBondToolStripMenuItem,
            this.vrijwilligersToolStripMenuItem,
            this.legeLijstToolStripMenuItem});
            this.lijstschermenToolStripMenuItem.Name = "lijstschermenToolStripMenuItem";
            this.lijstschermenToolStripMenuItem.Size = new System.Drawing.Size(333, 26);
            this.lijstschermenToolStripMenuItem.Text = "Lijstschermen";
            // 
            // toernooienBondToolStripMenuItem
            // 
            this.toernooienBondToolStripMenuItem.Name = "toernooienBondToolStripMenuItem";
            this.toernooienBondToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.toernooienBondToolStripMenuItem.Text = "Toernooien en Bond";
            this.toernooienBondToolStripMenuItem.Click += new System.EventHandler(this.toernooienBondToolStripMenuItem_Click);
            // 
            // vrijwilligersToolStripMenuItem
            // 
            this.vrijwilligersToolStripMenuItem.Name = "vrijwilligersToolStripMenuItem";
            this.vrijwilligersToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.vrijwilligersToolStripMenuItem.Text = "Vrijwilligers";
            this.vrijwilligersToolStripMenuItem.Click += new System.EventHandler(this.vrijwilligersToolStripMenuItem_Click);
            // 
            // legeLijstToolStripMenuItem
            // 
            this.legeLijstToolStripMenuItem.Name = "legeLijstToolStripMenuItem";
            this.legeLijstToolStripMenuItem.Size = new System.Drawing.Size(218, 26);
            this.legeLijstToolStripMenuItem.Text = "Lege lijst";
            this.legeLijstToolStripMenuItem.Click += new System.EventHandler(this.legeLijstToolStripMenuItem_Click);
            // 
            // mailToolStripMenuItem
            // 
            this.mailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mailVersturenToolStripMenuItem});
            this.mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            this.mailToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.mailToolStripMenuItem.Text = "Mail";
            // 
            // mailVersturenToolStripMenuItem
            // 
            this.mailVersturenToolStripMenuItem.Name = "mailVersturenToolStripMenuItem";
            this.mailVersturenToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.mailVersturenToolStripMenuItem.Text = "Versturen Mail";
            this.mailVersturenToolStripMenuItem.ToolTipText = "Ctrl-M";
            this.mailVersturenToolStripMenuItem.Click += new System.EventHandler(this.mailVersturenToolStripMenuItem_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuratieToolStripMenuItem,
            this.compResulatenJeugdToolStripMenuItem,
            this.vergelijkMetNASToolStripMenuItem1,
            this.backupToolStripMenuItem,
            this.toonOuder2BlokToolStripMenuItem,
            this.leesRatingToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // configuratieToolStripMenuItem
            // 
            this.configuratieToolStripMenuItem.Name = "configuratieToolStripMenuItem";
            this.configuratieToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.configuratieToolStripMenuItem.Text = "Beheer Configuratie";
            this.configuratieToolStripMenuItem.Click += new System.EventHandler(this.configuratieToolStripMenuItem_Click);
            // 
            // compResulatenJeugdToolStripMenuItem
            // 
            this.compResulatenJeugdToolStripMenuItem.Name = "compResulatenJeugdToolStripMenuItem";
            this.compResulatenJeugdToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.compResulatenJeugdToolStripMenuItem.Text = "Invoer Jeugd Resultaten";
            this.compResulatenJeugdToolStripMenuItem.Click += new System.EventHandler(this.compResulatenJeugdToolStripMenuItem_Click);
            // 
            // vergelijkMetNASToolStripMenuItem1
            // 
            this.vergelijkMetNASToolStripMenuItem1.Name = "vergelijkMetNASToolStripMenuItem1";
            this.vergelijkMetNASToolStripMenuItem1.Size = new System.Drawing.Size(285, 26);
            this.vergelijkMetNASToolStripMenuItem1.Text = "Vergelijk met NAS";
            this.vergelijkMetNASToolStripMenuItem1.Click += new System.EventHandler(this.vergelijkMetNASToolStripMenuItem1_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inlezenToolStripMenuItem,
            this.aanmakenToolStripMenuItem1,
            this.uploadNaarWebserverToolStripMenuItem});
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.backupToolStripMenuItem.Text = "Backup";
            // 
            // inlezenToolStripMenuItem
            // 
            this.inlezenToolStripMenuItem.Name = "inlezenToolStripMenuItem";
            this.inlezenToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.inlezenToolStripMenuItem.Text = "Inlezen";
            this.inlezenToolStripMenuItem.Click += new System.EventHandler(this.inlezenBackupToolStripMenuItem_Click);
            // 
            // aanmakenToolStripMenuItem1
            // 
            this.aanmakenToolStripMenuItem1.Name = "aanmakenToolStripMenuItem1";
            this.aanmakenToolStripMenuItem1.Size = new System.Drawing.Size(239, 26);
            this.aanmakenToolStripMenuItem1.Text = "Aanmaken";
            this.aanmakenToolStripMenuItem1.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // uploadNaarWebserverToolStripMenuItem
            // 
            this.uploadNaarWebserverToolStripMenuItem.Name = "uploadNaarWebserverToolStripMenuItem";
            this.uploadNaarWebserverToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
            this.uploadNaarWebserverToolStripMenuItem.Text = "Upload naar Webserver";
            this.uploadNaarWebserverToolStripMenuItem.Click += new System.EventHandler(this.uploadNaarWebserverToolStripMenuItem_Click);
            // 
            // toonOuder2BlokToolStripMenuItem
            // 
            this.toonOuder2BlokToolStripMenuItem.Name = "toonOuder2BlokToolStripMenuItem";
            this.toonOuder2BlokToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.toonOuder2BlokToolStripMenuItem.Text = "Toon Ouder2 Blok";
            this.toonOuder2BlokToolStripMenuItem.Click += new System.EventHandler(this.toonOuder2BlokToolStripMenuItem_Click);
            // 
            // leesRatingToolStripMenuItem
            // 
            this.leesRatingToolStripMenuItem.Name = "leesRatingToolStripMenuItem";
            this.leesRatingToolStripMenuItem.Size = new System.Drawing.Size(285, 26);
            this.leesRatingToolStripMenuItem.Text = "Lees Ratings van Ranglijsten.nl";
            this.leesRatingToolStripMenuItem.Click += new System.EventHandler(this.leesRatingToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(62, 24);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // cboLeden
            // 
            this.cboLeden.Location = new System.Drawing.Point(57, 44);
            this.cboLeden.Margin = new System.Windows.Forms.Padding(4);
            this.cboLeden.Name = "cboLeden";
            this.cboLeden.Size = new System.Drawing.Size(320, 24);
            this.cboLeden.TabIndex = 407;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrevious.Location = new System.Drawing.Point(499, 41);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(43, 28);
            this.btnPrevious.TabIndex = 400;
            this.btnPrevious.TabStop = false;
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFirst.Location = new System.Drawing.Point(448, 41);
            this.btnFirst.Margin = new System.Windows.Forms.Padding(4);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(43, 28);
            this.btnFirst.TabIndex = 401;
            this.btnFirst.TabStop = false;
            this.btnFirst.Text = "|<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNext.Location = new System.Drawing.Point(552, 41);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(43, 28);
            this.btnNext.TabIndex = 402;
            this.btnNext.TabStop = false;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLast.Location = new System.Drawing.Point(603, 41);
            this.btnLast.Margin = new System.Windows.Forms.Padding(4);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(43, 28);
            this.btnLast.TabIndex = 403;
            this.btnLast.TabStop = false;
            this.btnLast.Text = ">>|";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // dsLeden1
            // 
            this.dsLeden1.DataSetName = "dsLeden";
            this.dsLeden1.Locale = new System.Globalization.CultureInfo("en-US");
            this.dsLeden1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // versturenAankondigingenToolStripMenuItem
            // 
            this.versturenAankondigingenToolStripMenuItem.Name = "versturenAankondigingenToolStripMenuItem";
            this.versturenAankondigingenToolStripMenuItem.Size = new System.Drawing.Size(318, 26);
            this.versturenAankondigingenToolStripMenuItem.Text = "Versturen Aankondigingen";
            this.versturenAankondigingenToolStripMenuItem.Click += new System.EventHandler(this.versturenAankondigingenToolStripMenuItem_Click);
            // 
            // frmLeden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1345, 743);
            this.Controls.Add(this.pnlPoule);
            this.Controls.Add(this.pnlButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLeden";
            this.Text = "Leden";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLeden_FormClosing);
            this.Load += new System.EventHandler(this.frmLeden_Load);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.grpVrijwilligers.ResumeLayout(false);
            this.grpVrijwilligers.PerformLayout();
            this.grpToernooiInfo.ResumeLayout(false);
            this.grpToernooiInfo.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpOuder2.ResumeLayout(false);
            this.grpOuder2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpOuder1.ResumeLayout(false);
            this.grpOuder1.PerformLayout();
            this.pnlPoule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sbpFileName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpStatusMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sbpRecordNr)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsLeden1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPoule;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.StatusBarPanel sbpFileName;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileFiles;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Data.OleDb.OleDbConnection cnLeden;
        private DropDownLeden cboLeden;
        private System.Windows.Forms.CheckBox ckbSortLidNbr;
        private System.Windows.Forms.TextBox txtLidNr;
        private System.Windows.Forms.Label lblLidNr;
        private System.Windows.Forms.TextBox txtVoornaam;
        private System.Windows.Forms.Label lblVoornaam;
        private System.Windows.Forms.TextBox txtAchternaam;
        private System.Windows.Forms.Label lblAchternaam;
        private System.Windows.Forms.TextBox txtTussenvoegsel;
        private System.Windows.Forms.Label lblTussenvoegsel;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.Label lblAdres;
        private System.Windows.Forms.TextBox txtWoonplaats;
        private System.Windows.Forms.Label lblWoonplaats;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label lblPostcode;
        private System.Windows.Forms.TextBox txtMobiel;
        private System.Windows.Forms.Label lblMobiel;
        private System.Windows.Forms.TextBox txtTelefoon;
        private System.Windows.Forms.Label lblTelefoon;
        private System.Windows.Forms.TextBox txtBondsNr;
        private System.Windows.Forms.Label lblBondsNr;
        private System.Windows.Forms.Label lblGeslacht;
        private System.Windows.Forms.Label lblGeboorteDatum;
        private System.Windows.Forms.TextBox txtEmail1;
        private System.Windows.Forms.Label lblEmail1;
        private System.Windows.Forms.TextBox txtEmail2;
        private System.Windows.Forms.Label lblEmail2;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label lblIBAN;
        private System.Windows.Forms.TextBox txtBIC;
        private System.Windows.Forms.Label lblBIC;
        private System.Windows.Forms.Label lblBetaalWijze;
        private System.Windows.Forms.Label lblLidType;
        private System.Windows.Forms.Label lblLidVanaf;
        private System.Windows.Forms.Label lblLidTot;
        private System.Windows.Forms.TextBox txtU_PasNr;
        private System.Windows.Forms.Label lblU_PasNr;
        private System.Windows.Forms.Label lblPakketTot;
        private Util.Forms.currencyTextBox txtVastBedrag;
        private System.Windows.Forms.Label lblVastBedrag;
        private Util.Forms.currencyTextBox txtKorting;
        private System.Windows.Forms.Label lblKorting;
        private System.Windows.Forms.TextBox txtMedisch;
        private System.Windows.Forms.TextBox txtOuder1_Naam;
        private System.Windows.Forms.Label lblOuder1_Naam;
        private System.Windows.Forms.TextBox txtOuder1_Email1;
        private System.Windows.Forms.Label lblOuder1_Email1;
        private System.Windows.Forms.TextBox txtOuder1_Email2;
        private System.Windows.Forms.Label lblOuder1_Email2;
        private System.Windows.Forms.TextBox txtOuder1_Mobiel;
        private System.Windows.Forms.Label lblOuder1_Mobiel;
        private System.Windows.Forms.TextBox txtOuder1_Telefoon;
        private System.Windows.Forms.Label lblOuder1_Telefoon;
        private System.Windows.Forms.TextBox txtOuder2_Naam;
        private System.Windows.Forms.Label lblOuder2_Naam;
        private System.Windows.Forms.TextBox txtOuder2_Email1;
        private System.Windows.Forms.Label lblOuder2_Email1;
        private System.Windows.Forms.TextBox txtOuder2_Email2;
        private System.Windows.Forms.Label lblOuder2_Email2;
        private System.Windows.Forms.TextBox txtOuder2_Mobiel;
        private System.Windows.Forms.Label lblOuder2_Mobiel;
        private System.Windows.Forms.TextBox txtOuder2_Telefoon;
        private System.Windows.Forms.Label lblOuder2_Telefoon;
        private System.Windows.Forms.GroupBox grpOuder1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbGemerkt;
        private System.Windows.Forms.CheckBox ckbLidBond;
        private System.Windows.Forms.CheckBox ckbCompGerechtigd;
        private System.Windows.Forms.RadioButton rbuV;
        private System.Windows.Forms.RadioButton rbuM;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox grpOuder2;
        private System.Windows.Forms.DateTimePicker dtpGeboorteDatum;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox ckbOpgezegd;
        private System.Windows.Forms.CheckBox cbkInclOpgezegd;
        private System.Windows.Forms.DateTimePicker dtpPakketTot;
        private System.Windows.Forms.DateTimePicker dtpLidTot;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdCancel2;
        private System.Windows.Forms.DateTimePicker dtpLidVanaf;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.ComboBox cboLidType;
        private System.Windows.Forms.ComboBox cboBetaalwijze;
        private System.Windows.Forms.Label lblLeeftijdCategorie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLeeftijd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelectForm;
        private System.Windows.Forms.ToolStripMenuItem rekeningenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aanmakenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versturenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem handmatigAanmakenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lijstenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportNaarCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuratieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compResulatenJeugdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vergelijkMetNASToolStripMenuItem1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.ToolStripMenuItem mailVersturenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verstuurdeVerwijderenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inlezenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aanmakenToolStripMenuItem1;
        private System.Windows.Forms.StatusBarPanel sbpStatusMessage;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grpToernooiInfo;
        private System.Windows.Forms.CheckBox ckbRanglijst;
        private System.Windows.Forms.CheckBox ckbToernooi;
        private System.Windows.Forms.Button cmdRekeningen;
        private System.Windows.Forms.ToolStripMenuItem toonOuder2BlokToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbGeincasseerd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ToolStripMenuItem incassoKandidatenToolStripMenuItem;
        private System.Windows.Forms.StatusBarPanel sbpRecordNr;
        private System.Windows.Forms.ToolStripMenuItem lijstschermenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toernooienBondToolStripMenuItem;
        private System.Windows.Forms.Button cmdSendEmail;
        private System.Windows.Forms.ToolStripMenuItem overzichtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aanmaakOutputForMailProgrammaToolStripMenuItem;
        private System.Windows.Forms.Button cmdTTKaart;
        private System.Windows.Forms.RichTextBox rtbMemo;
        private System.Windows.Forms.GroupBox grpVrijwilligers;
        private System.Windows.Forms.CheckBox ckbVrijwKorting;
        private System.Windows.Forms.CheckBox ckbVrijwVasteTaak;
        private System.Windows.Forms.CheckBox ckbVrijwAfgekocht;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.ToolStripMenuItem vrijwilligersToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLicSen;
        private System.Windows.Forms.TextBox txtLicJun;
        private System.Windows.Forms.Label lblLicSen;
        private System.Windows.Forms.Label lblLicJun;
        private dsLeden dsLeden1;
        private System.Windows.Forms.ToolStripMenuItem legeLijstToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadNaarWebserverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leesRatingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versturenAankondigingenToolStripMenuItem;
    }
}