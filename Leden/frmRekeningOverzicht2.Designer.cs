namespace Leden.Net
{
    partial class frmRekeningOverzicht2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRekeningOverzicht2));
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.olvRekeningen = new BrightIdeasSoftware.FastObjectListView();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.lblOmschrijving = new System.Windows.Forms.Label();
            this.lblVerstuurd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbGestorneerd = new System.Windows.Forms.CheckBox();
            this.lblCreditIBAN = new System.Windows.Forms.Label();
            this.lblVerstuurdDate = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdChange = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.CmdNew = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAanmaakDatum = new System.Windows.Forms.Label();
            this.lblTypeRekening = new System.Windows.Forms.Label();
            this.lblCreditBIC = new System.Windows.Forms.Label();
            this.txtTotaalbedrag = new Util.Forms.currencyTextBox(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKortingVrijwilliger = new Util.Forms.currencyTextBox(this.components);
            this.txtKorting = new Util.Forms.currencyTextBox(this.components);
            this.txtExtraBedrag = new Util.Forms.currencyTextBox(this.components);
            this.lblContributieBedrag = new System.Windows.Forms.Label();
            this.lblCompetitieBijdrage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBondsbijdrage = new System.Windows.Forms.Label();
            this.txtContributieBedrag = new Util.Forms.currencyTextBox(this.components);
            this.txtCompetitieBijdrage = new Util.Forms.currencyTextBox(this.components);
            this.txtBondsbijdrage = new Util.Forms.currencyTextBox(this.components);
            this.lblDebitIBAN = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.ckbMailOnderdrukken = new System.Windows.Forms.CheckBox();
            this.grpStorneren = new System.Windows.Forms.GroupBox();
            this.rduZelfbetalingsMail = new System.Windows.Forms.RadioButton();
            this.rduStornoBrief = new System.Windows.Forms.RadioButton();
            this.txtStornoKosten = new Util.Forms.currencyTextBox(this.components);
            this.cmdStorneren = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDebitBIC = new System.Windows.Forms.Label();
            this.txtCreditBIC = new System.Windows.Forms.TextBox();
            this.lblTotaalbedrag = new System.Windows.Forms.Label();
            this.txtCreditIBAN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDebitBIC = new System.Windows.Forms.TextBox();
            this.dtpDatumVerstuurd = new System.Windows.Forms.DateTimePicker();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.ckbVerstuurd = new System.Windows.Forms.CheckBox();
            this.txtDebitIBAN = new System.Windows.Forms.TextBox();
            this.dtpAanmaakDatum = new System.Windows.Forms.DateTimePicker();
            this.cboTypeRekening = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Verstuurd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Storno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Omschrijving = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bedrag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lboLeden = new System.Windows.Forms.ListBox();
            this.pnlLeden = new System.Windows.Forms.Panel();
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvRekeningen)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpStorneren.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlLeden.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.Controls.Add(this.olvRekeningen);
            this.pnlBackground.Controls.Add(this.pnlDetails);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(200, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(777, 554);
            this.pnlBackground.TabIndex = 1;
            // 
            // olvRekeningen
            // 
            this.olvRekeningen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvRekeningen.Location = new System.Drawing.Point(0, 0);
            this.olvRekeningen.Name = "olvRekeningen";
            this.olvRekeningen.ShowGroups = false;
            this.olvRekeningen.Size = new System.Drawing.Size(777, 135);
            this.olvRekeningen.TabIndex = 3;
            this.olvRekeningen.UseCompatibleStateImageBehavior = false;
            this.olvRekeningen.View = System.Windows.Forms.View.Details;
            this.olvRekeningen.VirtualMode = true;
            this.olvRekeningen.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvRekeningen_FormatRow);
            this.olvRekeningen.SelectedIndexChanged += new System.EventHandler(this.olvRekeningen_SelectedIndexChanged);
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.lblOmschrijving);
            this.pnlDetails.Controls.Add(this.lblVerstuurd);
            this.pnlDetails.Controls.Add(this.label8);
            this.pnlDetails.Controls.Add(this.ckbGestorneerd);
            this.pnlDetails.Controls.Add(this.lblCreditIBAN);
            this.pnlDetails.Controls.Add(this.lblVerstuurdDate);
            this.pnlDetails.Controls.Add(this.pnlButtons);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.label7);
            this.pnlDetails.Controls.Add(this.lblAanmaakDatum);
            this.pnlDetails.Controls.Add(this.lblTypeRekening);
            this.pnlDetails.Controls.Add(this.lblCreditBIC);
            this.pnlDetails.Controls.Add(this.txtTotaalbedrag);
            this.pnlDetails.Controls.Add(this.groupBox1);
            this.pnlDetails.Controls.Add(this.lblDebitIBAN);
            this.pnlDetails.Controls.Add(this.textBox2);
            this.pnlDetails.Controls.Add(this.ckbMailOnderdrukken);
            this.pnlDetails.Controls.Add(this.grpStorneren);
            this.pnlDetails.Controls.Add(this.lblDebitBIC);
            this.pnlDetails.Controls.Add(this.txtCreditBIC);
            this.pnlDetails.Controls.Add(this.lblTotaalbedrag);
            this.pnlDetails.Controls.Add(this.txtCreditIBAN);
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.textBox1);
            this.pnlDetails.Controls.Add(this.txtDebitBIC);
            this.pnlDetails.Controls.Add(this.dtpDatumVerstuurd);
            this.pnlDetails.Controls.Add(this.txtOmschrijving);
            this.pnlDetails.Controls.Add(this.ckbVerstuurd);
            this.pnlDetails.Controls.Add(this.txtDebitIBAN);
            this.pnlDetails.Controls.Add(this.dtpAanmaakDatum);
            this.pnlDetails.Controls.Add(this.cboTypeRekening);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetails.Location = new System.Drawing.Point(0, 135);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(777, 419);
            this.pnlDetails.TabIndex = 1;
            // 
            // lblOmschrijving
            // 
            this.lblOmschrijving.AutoSize = true;
            this.lblOmschrijving.Location = new System.Drawing.Point(30, 28);
            this.lblOmschrijving.Name = "lblOmschrijving";
            this.lblOmschrijving.Size = new System.Drawing.Size(67, 13);
            this.lblOmschrijving.TabIndex = 468;
            this.lblOmschrijving.Text = "Omschrijving";
            this.lblOmschrijving.Click += new System.EventHandler(this.lblOmschrijving_Click);
            // 
            // lblVerstuurd
            // 
            this.lblVerstuurd.AutoSize = true;
            this.lblVerstuurd.Location = new System.Drawing.Point(30, 220);
            this.lblVerstuurd.Name = "lblVerstuurd";
            this.lblVerstuurd.Size = new System.Drawing.Size(52, 13);
            this.lblVerstuurd.TabIndex = 472;
            this.lblVerstuurd.Text = "Verstuurd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(307, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 474;
            this.label8.Text = "Credit IBAN";
            // 
            // ckbGestorneerd
            // 
            this.ckbGestorneerd.AutoSize = true;
            this.ckbGestorneerd.Location = new System.Drawing.Point(121, 280);
            this.ckbGestorneerd.Name = "ckbGestorneerd";
            this.ckbGestorneerd.Size = new System.Drawing.Size(15, 14);
            this.ckbGestorneerd.TabIndex = 492;
            this.ckbGestorneerd.UseVisualStyleBackColor = true;
            // 
            // lblCreditIBAN
            // 
            this.lblCreditIBAN.AutoSize = true;
            this.lblCreditIBAN.Location = new System.Drawing.Point(307, 124);
            this.lblCreditIBAN.Name = "lblCreditIBAN";
            this.lblCreditIBAN.Size = new System.Drawing.Size(62, 13);
            this.lblCreditIBAN.TabIndex = 474;
            this.lblCreditIBAN.Text = "Credit IBAN";
            // 
            // lblVerstuurdDate
            // 
            this.lblVerstuurdDate.AutoSize = true;
            this.lblVerstuurdDate.Location = new System.Drawing.Point(30, 252);
            this.lblVerstuurdDate.Name = "lblVerstuurdDate";
            this.lblVerstuurdDate.Size = new System.Drawing.Size(86, 13);
            this.lblVerstuurdDate.TabIndex = 471;
            this.lblVerstuurdDate.Text = "Datum Verstuurd";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.cmdCancel);
            this.pnlButtons.Controls.Add(this.cmdChange);
            this.pnlButtons.Controls.Add(this.cmdExit);
            this.pnlButtons.Controls.Add(this.cmdSave);
            this.pnlButtons.Controls.Add(this.CmdNew);
            this.pnlButtons.Controls.Add(this.cmdDelete);
            this.pnlButtons.Location = new System.Drawing.Point(676, 268);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(75, 112);
            this.pnlButtons.TabIndex = 496;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(0, 30);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 496;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(0, 0);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(75, 23);
            this.cmdChange.TabIndex = 495;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(0, 87);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 486;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(0, 0);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 485;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // CmdNew
            // 
            this.CmdNew.Location = new System.Drawing.Point(0, 58);
            this.CmdNew.Name = "CmdNew";
            this.CmdNew.Size = new System.Drawing.Size(75, 23);
            this.CmdNew.TabIndex = 493;
            this.CmdNew.Text = "New";
            this.CmdNew.UseVisualStyleBackColor = true;
            this.CmdNew.Click += new System.EventHandler(this.CmdNew_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(0, 29);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 487;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 491;
            this.label5.Text = "Gestorneerd";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 473;
            this.label7.Text = "Credit BIC";
            // 
            // lblAanmaakDatum
            // 
            this.lblAanmaakDatum.AutoSize = true;
            this.lblAanmaakDatum.Location = new System.Drawing.Point(30, 188);
            this.lblAanmaakDatum.Name = "lblAanmaakDatum";
            this.lblAanmaakDatum.Size = new System.Drawing.Size(86, 13);
            this.lblAanmaakDatum.TabIndex = 467;
            this.lblAanmaakDatum.Text = "Aanmaak Datum";
            // 
            // lblTypeRekening
            // 
            this.lblTypeRekening.AutoSize = true;
            this.lblTypeRekening.Location = new System.Drawing.Point(30, 60);
            this.lblTypeRekening.Name = "lblTypeRekening";
            this.lblTypeRekening.Size = new System.Drawing.Size(80, 13);
            this.lblTypeRekening.TabIndex = 469;
            this.lblTypeRekening.Text = "Type Rekening";
            // 
            // lblCreditBIC
            // 
            this.lblCreditBIC.AutoSize = true;
            this.lblCreditBIC.Location = new System.Drawing.Point(307, 156);
            this.lblCreditBIC.Name = "lblCreditBIC";
            this.lblCreditBIC.Size = new System.Drawing.Size(54, 13);
            this.lblCreditBIC.TabIndex = 473;
            this.lblCreditBIC.Text = "Credit BIC";
            // 
            // txtTotaalbedrag
            // 
            this.txtTotaalbedrag.DecimalPlaces = 2;
            this.txtTotaalbedrag.DecimalsSeparator = ',';
            this.txtTotaalbedrag.Location = new System.Drawing.Point(121, 88);
            this.txtTotaalbedrag.Name = "txtTotaalbedrag";
            this.txtTotaalbedrag.PreFix = "€";
            this.txtTotaalbedrag.Size = new System.Drawing.Size(67, 20);
            this.txtTotaalbedrag.TabIndex = 463;
            this.txtTotaalbedrag.Text = "€ 0";
            this.txtTotaalbedrag.ThousandsSeparator = '.';
            this.txtTotaalbedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotaalbedrag.ToFromInteger = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKortingVrijwilliger);
            this.groupBox1.Controls.Add(this.txtKorting);
            this.groupBox1.Controls.Add(this.txtExtraBedrag);
            this.groupBox1.Controls.Add(this.lblContributieBedrag);
            this.groupBox1.Controls.Add(this.lblCompetitieBijdrage);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBondsbijdrage);
            this.groupBox1.Controls.Add(this.txtContributieBedrag);
            this.groupBox1.Controls.Add(this.txtCompetitieBijdrage);
            this.groupBox1.Controls.Add(this.txtBondsbijdrage);
            this.groupBox1.Location = new System.Drawing.Point(530, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 194);
            this.groupBox1.TabIndex = 478;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contributie bedragen";
            // 
            // txtKortingVrijwilliger
            // 
            this.txtKortingVrijwilliger.DecimalPlaces = 2;
            this.txtKortingVrijwilliger.DecimalsSeparator = ',';
            this.txtKortingVrijwilliger.Location = new System.Drawing.Point(123, 159);
            this.txtKortingVrijwilliger.Name = "txtKortingVrijwilliger";
            this.txtKortingVrijwilliger.PreFix = "€";
            this.txtKortingVrijwilliger.Size = new System.Drawing.Size(77, 20);
            this.txtKortingVrijwilliger.TabIndex = 446;
            this.txtKortingVrijwilliger.Text = "€ 0";
            this.txtKortingVrijwilliger.ThousandsSeparator = '.';
            this.txtKortingVrijwilliger.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKortingVrijwilliger.ToFromInteger = 0;
            // 
            // txtKorting
            // 
            this.txtKorting.DecimalPlaces = 2;
            this.txtKorting.DecimalsSeparator = ',';
            this.txtKorting.Location = new System.Drawing.Point(123, 134);
            this.txtKorting.Name = "txtKorting";
            this.txtKorting.PreFix = "€";
            this.txtKorting.Size = new System.Drawing.Size(77, 20);
            this.txtKorting.TabIndex = 446;
            this.txtKorting.Text = "€ 0";
            this.txtKorting.ThousandsSeparator = '.';
            this.txtKorting.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKorting.ToFromInteger = 0;
            // 
            // txtExtraBedrag
            // 
            this.txtExtraBedrag.DecimalPlaces = 2;
            this.txtExtraBedrag.DecimalsSeparator = ',';
            this.txtExtraBedrag.Location = new System.Drawing.Point(123, 107);
            this.txtExtraBedrag.Name = "txtExtraBedrag";
            this.txtExtraBedrag.PreFix = "€";
            this.txtExtraBedrag.Size = new System.Drawing.Size(77, 20);
            this.txtExtraBedrag.TabIndex = 446;
            this.txtExtraBedrag.Text = "€ 0";
            this.txtExtraBedrag.ThousandsSeparator = '.';
            this.txtExtraBedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtExtraBedrag.ToFromInteger = 0;
            // 
            // lblContributieBedrag
            // 
            this.lblContributieBedrag.AutoSize = true;
            this.lblContributieBedrag.Location = new System.Drawing.Point(8, 30);
            this.lblContributieBedrag.Name = "lblContributieBedrag";
            this.lblContributieBedrag.Size = new System.Drawing.Size(94, 13);
            this.lblContributieBedrag.TabIndex = 445;
            this.lblContributieBedrag.Text = "Contributie Bedrag";
            // 
            // lblCompetitieBijdrage
            // 
            this.lblCompetitieBijdrage.AutoSize = true;
            this.lblCompetitieBijdrage.Location = new System.Drawing.Point(8, 57);
            this.lblCompetitieBijdrage.Name = "lblCompetitieBijdrage";
            this.lblCompetitieBijdrage.Size = new System.Drawing.Size(97, 13);
            this.lblCompetitieBijdrage.TabIndex = 445;
            this.lblCompetitieBijdrage.Text = "Competitie Bijdrage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 445;
            this.label6.Text = "Korting Vrijwilligers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 445;
            this.label3.Text = "Korting";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 445;
            this.label2.Text = "Extra Bedrag";
            // 
            // lblBondsbijdrage
            // 
            this.lblBondsbijdrage.AutoSize = true;
            this.lblBondsbijdrage.Location = new System.Drawing.Point(8, 84);
            this.lblBondsbijdrage.Name = "lblBondsbijdrage";
            this.lblBondsbijdrage.Size = new System.Drawing.Size(78, 13);
            this.lblBondsbijdrage.TabIndex = 445;
            this.lblBondsbijdrage.Text = "Bonds Bijdrage";
            // 
            // txtContributieBedrag
            // 
            this.txtContributieBedrag.DecimalPlaces = 2;
            this.txtContributieBedrag.DecimalsSeparator = ',';
            this.txtContributieBedrag.Location = new System.Drawing.Point(122, 28);
            this.txtContributieBedrag.Name = "txtContributieBedrag";
            this.txtContributieBedrag.PreFix = "€";
            this.txtContributieBedrag.Size = new System.Drawing.Size(78, 20);
            this.txtContributieBedrag.TabIndex = 1;
            this.txtContributieBedrag.Text = "€ 0";
            this.txtContributieBedrag.ThousandsSeparator = '.';
            this.txtContributieBedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtContributieBedrag.ToFromInteger = 0;
            // 
            // txtCompetitieBijdrage
            // 
            this.txtCompetitieBijdrage.DecimalPlaces = 2;
            this.txtCompetitieBijdrage.DecimalsSeparator = ',';
            this.txtCompetitieBijdrage.Location = new System.Drawing.Point(123, 54);
            this.txtCompetitieBijdrage.Name = "txtCompetitieBijdrage";
            this.txtCompetitieBijdrage.PreFix = "€";
            this.txtCompetitieBijdrage.Size = new System.Drawing.Size(77, 20);
            this.txtCompetitieBijdrage.TabIndex = 1;
            this.txtCompetitieBijdrage.Text = "€ 0";
            this.txtCompetitieBijdrage.ThousandsSeparator = '.';
            this.txtCompetitieBijdrage.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCompetitieBijdrage.ToFromInteger = 0;
            // 
            // txtBondsbijdrage
            // 
            this.txtBondsbijdrage.DecimalPlaces = 2;
            this.txtBondsbijdrage.DecimalsSeparator = ',';
            this.txtBondsbijdrage.Location = new System.Drawing.Point(123, 81);
            this.txtBondsbijdrage.Name = "txtBondsbijdrage";
            this.txtBondsbijdrage.PreFix = "€";
            this.txtBondsbijdrage.Size = new System.Drawing.Size(77, 20);
            this.txtBondsbijdrage.TabIndex = 1;
            this.txtBondsbijdrage.Text = "€ 0";
            this.txtBondsbijdrage.ThousandsSeparator = '.';
            this.txtBondsbijdrage.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBondsbijdrage.ToFromInteger = 0;
            // 
            // lblDebitIBAN
            // 
            this.lblDebitIBAN.AutoSize = true;
            this.lblDebitIBAN.Location = new System.Drawing.Point(30, 124);
            this.lblDebitIBAN.Name = "lblDebitIBAN";
            this.lblDebitIBAN.Size = new System.Drawing.Size(60, 13);
            this.lblDebitIBAN.TabIndex = 476;
            this.lblDebitIBAN.Text = "Debit IBAN";
            // 
            // textBox2
            // 
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox2.Location = new System.Drawing.Point(375, 153);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 20);
            this.textBox2.TabIndex = 477;
            this.textBox2.Text = "NLING000000";
            this.textBox2.Validating += new System.ComponentModel.CancelEventHandler(this.BIC_Validating);
            // 
            // ckbMailOnderdrukken
            // 
            this.ckbMailOnderdrukken.AutoSize = true;
            this.ckbMailOnderdrukken.Location = new System.Drawing.Point(173, 308);
            this.ckbMailOnderdrukken.Name = "ckbMailOnderdrukken";
            this.ckbMailOnderdrukken.Size = new System.Drawing.Size(15, 14);
            this.ckbMailOnderdrukken.TabIndex = 489;
            this.ckbMailOnderdrukken.UseVisualStyleBackColor = true;
            // 
            // grpStorneren
            // 
            this.grpStorneren.Controls.Add(this.rduZelfbetalingsMail);
            this.grpStorneren.Controls.Add(this.rduStornoBrief);
            this.grpStorneren.Controls.Add(this.txtStornoKosten);
            this.grpStorneren.Controls.Add(this.cmdStorneren);
            this.grpStorneren.Controls.Add(this.label4);
            this.grpStorneren.Location = new System.Drawing.Point(375, 268);
            this.grpStorneren.Name = "grpStorneren";
            this.grpStorneren.Size = new System.Drawing.Size(257, 94);
            this.grpStorneren.TabIndex = 490;
            this.grpStorneren.TabStop = false;
            this.grpStorneren.Text = "Storneren";
            // 
            // rduZelfbetalingsMail
            // 
            this.rduZelfbetalingsMail.AutoSize = true;
            this.rduZelfbetalingsMail.Location = new System.Drawing.Point(134, 52);
            this.rduZelfbetalingsMail.Name = "rduZelfbetalingsMail";
            this.rduZelfbetalingsMail.Size = new System.Drawing.Size(106, 17);
            this.rduZelfbetalingsMail.TabIndex = 493;
            this.rduZelfbetalingsMail.TabStop = true;
            this.rduZelfbetalingsMail.Text = "Zelfbetalings-mail";
            this.rduZelfbetalingsMail.UseVisualStyleBackColor = true;
            // 
            // rduStornoBrief
            // 
            this.rduStornoBrief.AutoSize = true;
            this.rduStornoBrief.Location = new System.Drawing.Point(134, 29);
            this.rduStornoBrief.Name = "rduStornoBrief";
            this.rduStornoBrief.Size = new System.Drawing.Size(77, 17);
            this.rduStornoBrief.TabIndex = 493;
            this.rduStornoBrief.TabStop = true;
            this.rduStornoBrief.Text = "Storno-mail";
            this.rduStornoBrief.UseVisualStyleBackColor = true;
            // 
            // txtStornoKosten
            // 
            this.txtStornoKosten.DecimalPlaces = 2;
            this.txtStornoKosten.DecimalsSeparator = ',';
            this.txtStornoKosten.Location = new System.Drawing.Point(65, 58);
            this.txtStornoKosten.Name = "txtStornoKosten";
            this.txtStornoKosten.PreFix = "€";
            this.txtStornoKosten.Size = new System.Drawing.Size(52, 20);
            this.txtStornoKosten.TabIndex = 491;
            this.txtStornoKosten.Text = "€ 0";
            this.txtStornoKosten.ThousandsSeparator = '.';
            this.txtStornoKosten.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtStornoKosten.ToFromInteger = 0;
            // 
            // cmdStorneren
            // 
            this.cmdStorneren.Enabled = false;
            this.cmdStorneren.Location = new System.Drawing.Point(13, 27);
            this.cmdStorneren.Name = "cmdStorneren";
            this.cmdStorneren.Size = new System.Drawing.Size(104, 23);
            this.cmdStorneren.TabIndex = 0;
            this.cmdStorneren.Text = "Storneren";
            this.cmdStorneren.UseVisualStyleBackColor = true;
            this.cmdStorneren.Click += new System.EventHandler(this.cmdStorneren_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 492;
            this.label4.Text = "Kosten";
            // 
            // lblDebitBIC
            // 
            this.lblDebitBIC.AutoSize = true;
            this.lblDebitBIC.Location = new System.Drawing.Point(30, 156);
            this.lblDebitBIC.Name = "lblDebitBIC";
            this.lblDebitBIC.Size = new System.Drawing.Size(52, 13);
            this.lblDebitBIC.TabIndex = 475;
            this.lblDebitBIC.Text = "Debit BIC";
            // 
            // txtCreditBIC
            // 
            this.txtCreditBIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditBIC.Location = new System.Drawing.Point(375, 153);
            this.txtCreditBIC.Name = "txtCreditBIC";
            this.txtCreditBIC.Size = new System.Drawing.Size(84, 20);
            this.txtCreditBIC.TabIndex = 477;
            this.txtCreditBIC.Text = "NLING000000";
            this.txtCreditBIC.Validating += new System.ComponentModel.CancelEventHandler(this.BIC_Validating);
            // 
            // lblTotaalbedrag
            // 
            this.lblTotaalbedrag.AutoSize = true;
            this.lblTotaalbedrag.Location = new System.Drawing.Point(30, 92);
            this.lblTotaalbedrag.Name = "lblTotaalbedrag";
            this.lblTotaalbedrag.Size = new System.Drawing.Size(74, 13);
            this.lblTotaalbedrag.TabIndex = 470;
            this.lblTotaalbedrag.Text = "Totaal Bedrag";
            // 
            // txtCreditIBAN
            // 
            this.txtCreditIBAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditIBAN.Location = new System.Drawing.Point(375, 121);
            this.txtCreditIBAN.Name = "txtCreditIBAN";
            this.txtCreditIBAN.Size = new System.Drawing.Size(138, 20);
            this.txtCreditIBAN.TabIndex = 465;
            this.txtCreditIBAN.Text = "NL58RABO1234567890";
            this.txtCreditIBAN.Validating += new System.ComponentModel.CancelEventHandler(this.IBAN_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 308);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 488;
            this.label1.Text = "Incasso Mail Onderdrukken";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(375, 121);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 20);
            this.textBox1.TabIndex = 465;
            this.textBox1.Text = "NL58RABO1234567890";
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.IBAN_Validating);
            // 
            // txtDebitBIC
            // 
            this.txtDebitBIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitBIC.Location = new System.Drawing.Point(121, 153);
            this.txtDebitBIC.Name = "txtDebitBIC";
            this.txtDebitBIC.Size = new System.Drawing.Size(84, 20);
            this.txtDebitBIC.TabIndex = 466;
            this.txtDebitBIC.Text = "NLING000000";
            this.txtDebitBIC.Validating += new System.ComponentModel.CancelEventHandler(this.BIC_Validating);
            // 
            // dtpDatumVerstuurd
            // 
            this.dtpDatumVerstuurd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumVerstuurd.Location = new System.Drawing.Point(121, 246);
            this.dtpDatumVerstuurd.Name = "dtpDatumVerstuurd";
            this.dtpDatumVerstuurd.Size = new System.Drawing.Size(74, 20);
            this.dtpDatumVerstuurd.TabIndex = 480;
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(121, 25);
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(630, 20);
            this.txtOmschrijving.TabIndex = 462;
            // 
            // ckbVerstuurd
            // 
            this.ckbVerstuurd.AutoSize = true;
            this.ckbVerstuurd.Location = new System.Drawing.Point(121, 219);
            this.ckbVerstuurd.Name = "ckbVerstuurd";
            this.ckbVerstuurd.Size = new System.Drawing.Size(15, 14);
            this.ckbVerstuurd.TabIndex = 481;
            this.ckbVerstuurd.UseVisualStyleBackColor = true;
            // 
            // txtDebitIBAN
            // 
            this.txtDebitIBAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDebitIBAN.Location = new System.Drawing.Point(121, 121);
            this.txtDebitIBAN.Name = "txtDebitIBAN";
            this.txtDebitIBAN.Size = new System.Drawing.Size(138, 20);
            this.txtDebitIBAN.TabIndex = 464;
            this.txtDebitIBAN.Text = "NL58RABO1234567890";
            this.txtDebitIBAN.Validating += new System.ComponentModel.CancelEventHandler(this.IBAN_Validating);
            // 
            // dtpAanmaakDatum
            // 
            this.dtpAanmaakDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmaakDatum.Location = new System.Drawing.Point(121, 185);
            this.dtpAanmaakDatum.Name = "dtpAanmaakDatum";
            this.dtpAanmaakDatum.Size = new System.Drawing.Size(74, 20);
            this.dtpAanmaakDatum.TabIndex = 479;
            // 
            // cboTypeRekening
            // 
            this.cboTypeRekening.FormattingEnabled = true;
            this.cboTypeRekening.ItemHeight = 13;
            this.cboTypeRekening.Location = new System.Drawing.Point(121, 58);
            this.cboTypeRekening.Name = "cboTypeRekening";
            this.cboTypeRekening.Size = new System.Drawing.Size(121, 21);
            this.cboTypeRekening.TabIndex = 484;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 497;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Nr
            // 
            this.Nr.Text = "Nr";
            this.Nr.Width = 50;
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            // 
            // Verstuurd
            // 
            this.Verstuurd.Text = "Verstuurd";
            this.Verstuurd.Width = 20;
            // 
            // Storno
            // 
            this.Storno.Text = "Storno";
            this.Storno.Width = 20;
            // 
            // Omschrijving
            // 
            this.Omschrijving.Text = "Omschrijving";
            this.Omschrijving.Width = 300;
            // 
            // Bedrag
            // 
            this.Bedrag.Text = "Bedrag";
            this.Bedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lboLeden
            // 
            this.lboLeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lboLeden.FormattingEnabled = true;
            this.lboLeden.Location = new System.Drawing.Point(0, 0);
            this.lboLeden.Name = "lboLeden";
            this.lboLeden.Size = new System.Drawing.Size(200, 554);
            this.lboLeden.TabIndex = 0;
            this.lboLeden.SelectedIndexChanged += new System.EventHandler(this.lboLeden_SelectedIndexChanged);
            // 
            // pnlLeden
            // 
            this.pnlLeden.Controls.Add(this.lboLeden);
            this.pnlLeden.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeden.Location = new System.Drawing.Point(0, 0);
            this.pnlLeden.Name = "pnlLeden";
            this.pnlLeden.Size = new System.Drawing.Size(200, 554);
            this.pnlLeden.TabIndex = 0;
            // 
            // frmRekeningOverzicht2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 576);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.pnlLeden);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRekeningOverzicht2";
            this.Text = "Overzicht rekeningen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRekeningOverzicht2_FormClosing);
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvRekeningen)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpStorneren.ResumeLayout(false);
            this.grpStorneren.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlLeden.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.ListBox lboLeden;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlLeden;
        private System.Windows.Forms.ColumnHeader Nr;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Omschrijving;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ColumnHeader Verstuurd;
        private System.Windows.Forms.ColumnHeader Bedrag;
        private System.Windows.Forms.ColumnHeader Storno;
        private System.Windows.Forms.Button CmdNew;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCreditIBAN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCreditBIC;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtCreditBIC;
        private System.Windows.Forms.Label lblOmschrijving;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCreditIBAN;
        private System.Windows.Forms.GroupBox grpStorneren;
        private System.Windows.Forms.RadioButton rduZelfbetalingsMail;
        private System.Windows.Forms.RadioButton rduStornoBrief;
        private Util.Forms.currencyTextBox txtStornoKosten;
        private System.Windows.Forms.Button cmdStorneren;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVerstuurd;
        private System.Windows.Forms.CheckBox ckbGestorneerd;
        private System.Windows.Forms.Label lblVerstuurdDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private Util.Forms.currencyTextBox txtKorting;
        private Util.Forms.currencyTextBox txtExtraBedrag;
        private System.Windows.Forms.Label lblContributieBedrag;
        private System.Windows.Forms.Label lblCompetitieBijdrage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBondsbijdrage;
        private Util.Forms.currencyTextBox txtContributieBedrag;
        private Util.Forms.currencyTextBox txtCompetitieBijdrage;
        private Util.Forms.currencyTextBox txtBondsbijdrage;
        private System.Windows.Forms.Label lblAanmaakDatum;
        private System.Windows.Forms.Label lblTypeRekening;
        private Util.Forms.currencyTextBox txtTotaalbedrag;
        private System.Windows.Forms.Label lblDebitIBAN;
        private System.Windows.Forms.CheckBox ckbMailOnderdrukken;
        private System.Windows.Forms.Label lblDebitBIC;
        private System.Windows.Forms.Label lblTotaalbedrag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDebitBIC;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.TextBox txtDebitIBAN;
        private System.Windows.Forms.ComboBox cboTypeRekening;
        private System.Windows.Forms.DateTimePicker dtpAanmaakDatum;
        private System.Windows.Forms.CheckBox ckbVerstuurd;
        private System.Windows.Forms.DateTimePicker dtpDatumVerstuurd;
        private Util.Forms.currencyTextBox txtKortingVrijwilliger;
        private System.Windows.Forms.Label label6;
        private BrightIdeasSoftware.FastObjectListView olvRekeningen;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}