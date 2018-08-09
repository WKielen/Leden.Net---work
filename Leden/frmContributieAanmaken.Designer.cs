namespace Leden.Net
{
    partial class frmContributieAanmaken
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContributieAanmaken));
            this.dtpPeilDatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdMaakRekeningen = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.clbLidTypes = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSelectieType = new System.Windows.Forms.ComboBox();
            this.txtWlpPup = new Util.Forms.currencyTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt65 = new Util.Forms.currencyTextBox(this.components);
            this.txtSen = new Util.Forms.currencyTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCadJun = new Util.Forms.currencyTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPakketBedrag = new Util.Forms.currencyTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKostenRekening = new Util.Forms.currencyTextBox(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCompBijdrageJun = new Util.Forms.currencyTextBox(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtBondsBijdrage = new Util.Forms.currencyTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.txtCompBijdrageSen = new Util.Forms.currencyTextBox(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.lblOmschrijving = new System.Windows.Forms.Label();
            this.txtPercZwerf = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbRelatief = new System.Windows.Forms.CheckBox();
            this.cmdOutput = new System.Windows.Forms.Button();
            this.txtKortingVrijwilliger = new Util.Forms.currencyTextBox(this.components);
            this.label14 = new System.Windows.Forms.Label();
            this.cmdToelichting = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpPeilDatum
            // 
            this.dtpPeilDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpPeilDatum.Location = new System.Drawing.Point(93, 18);
            this.dtpPeilDatum.Name = "dtpPeilDatum";
            this.dtpPeilDatum.Size = new System.Drawing.Size(87, 20);
            this.dtpPeilDatum.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Peildatum";
            // 
            // cmdMaakRekeningen
            // 
            this.cmdMaakRekeningen.Location = new System.Drawing.Point(390, 380);
            this.cmdMaakRekeningen.Name = "cmdMaakRekeningen";
            this.cmdMaakRekeningen.Size = new System.Drawing.Size(75, 23);
            this.cmdMaakRekeningen.TabIndex = 2;
            this.cmdMaakRekeningen.Text = "Maak!";
            this.cmdMaakRekeningen.UseVisualStyleBackColor = true;
            this.cmdMaakRekeningen.Click += new System.EventHandler(this.cmdMaakRekeningen_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(390, 409);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 459;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // clbLidTypes
            // 
            this.clbLidTypes.CheckOnClick = true;
            this.clbLidTypes.FormattingEnabled = true;
            this.clbLidTypes.Location = new System.Drawing.Point(93, 94);
            this.clbLidTypes.Name = "clbLidTypes";
            this.clbLidTypes.Size = new System.Drawing.Size(87, 64);
            this.clbLidTypes.TabIndex = 460;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selectie Type";
            // 
            // cboSelectieType
            // 
            this.cboSelectieType.FormattingEnabled = true;
            this.cboSelectieType.Items.AddRange(new object[] {
            "Lid Types",
            "Gemerkt"});
            this.cboSelectieType.Location = new System.Drawing.Point(93, 54);
            this.cboSelectieType.Name = "cboSelectieType";
            this.cboSelectieType.Size = new System.Drawing.Size(87, 21);
            this.cboSelectieType.TabIndex = 3;
            this.cboSelectieType.SelectedIndexChanged += new System.EventHandler(this.cboSelectieType_SelectedIndexChanged);
            // 
            // txtWlpPup
            // 
            this.txtWlpPup.DecimalPlaces = 2;
            this.txtWlpPup.DecimalsSeparator = ',';
            this.txtWlpPup.Location = new System.Drawing.Point(71, 19);
            this.txtWlpPup.Name = "txtWlpPup";
            this.txtWlpPup.PreFix = "€";
            this.txtWlpPup.Size = new System.Drawing.Size(63, 20);
            this.txtWlpPup.TabIndex = 461;
            this.txtWlpPup.Text = "€ 0";
            this.txtWlpPup.ThousandsSeparator = '.';
            this.txtWlpPup.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtWlpPup.ToFromInteger = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Wlp/Pup";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt65);
            this.groupBox1.Controls.Add(this.txtSen);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCadJun);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWlpPup);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(246, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 157);
            this.groupBox1.TabIndex = 462;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Halfjaar Contributie";
            // 
            // txt65
            // 
            this.txt65.DecimalPlaces = 2;
            this.txt65.DecimalsSeparator = ',';
            this.txt65.Location = new System.Drawing.Point(71, 118);
            this.txt65.Name = "txt65";
            this.txt65.PreFix = "€";
            this.txt65.Size = new System.Drawing.Size(63, 20);
            this.txt65.TabIndex = 461;
            this.txt65.Text = "€ 0";
            this.txt65.ThousandsSeparator = '.';
            this.txt65.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt65.ToFromInteger = 0;
            // 
            // txtSen
            // 
            this.txtSen.DecimalPlaces = 2;
            this.txtSen.DecimalsSeparator = ',';
            this.txtSen.Location = new System.Drawing.Point(71, 85);
            this.txtSen.Name = "txtSen";
            this.txtSen.PreFix = "€";
            this.txtSen.Size = new System.Drawing.Size(63, 20);
            this.txtSen.TabIndex = 461;
            this.txtSen.Text = "€ 0";
            this.txtSen.ThousandsSeparator = '.';
            this.txtSen.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSen.ToFromInteger = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "65+";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sen";
            // 
            // txtCadJun
            // 
            this.txtCadJun.DecimalPlaces = 2;
            this.txtCadJun.DecimalsSeparator = ',';
            this.txtCadJun.Location = new System.Drawing.Point(71, 52);
            this.txtCadJun.Name = "txtCadJun";
            this.txtCadJun.PreFix = "€";
            this.txtCadJun.Size = new System.Drawing.Size(63, 20);
            this.txtCadJun.TabIndex = 461;
            this.txtCadJun.Text = "€ 0";
            this.txtCadJun.ThousandsSeparator = '.';
            this.txtCadJun.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCadJun.ToFromInteger = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Cad/Jun";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 228);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Zwerflid Percentage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lid Type";
            // 
            // txtPakketBedrag
            // 
            this.txtPakketBedrag.DecimalPlaces = 2;
            this.txtPakketBedrag.DecimalsSeparator = ',';
            this.txtPakketBedrag.Location = new System.Drawing.Point(128, 255);
            this.txtPakketBedrag.Name = "txtPakketBedrag";
            this.txtPakketBedrag.PreFix = "€";
            this.txtPakketBedrag.Size = new System.Drawing.Size(64, 20);
            this.txtPakketBedrag.TabIndex = 465;
            this.txtPakketBedrag.Text = "€ 0";
            this.txtPakketBedrag.ThousandsSeparator = '.';
            this.txtPakketBedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPakketBedrag.ToFromInteger = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 464;
            this.label9.Text = "Pakket Bedrag";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 464;
            this.label10.Text = "Kosten Rekening";
            // 
            // txtKostenRekening
            // 
            this.txtKostenRekening.DecimalPlaces = 2;
            this.txtKostenRekening.DecimalsSeparator = ',';
            this.txtKostenRekening.Location = new System.Drawing.Point(128, 283);
            this.txtKostenRekening.Name = "txtKostenRekening";
            this.txtKostenRekening.PreFix = "€";
            this.txtKostenRekening.Size = new System.Drawing.Size(64, 20);
            this.txtKostenRekening.TabIndex = 466;
            this.txtKostenRekening.Text = "€ 0";
            this.txtKostenRekening.ThousandsSeparator = '.';
            this.txtKostenRekening.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKostenRekening.ToFromInteger = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCompBijdrageJun);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtBondsBijdrage);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtCompBijdrageSen);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(246, 187);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 129);
            this.groupBox2.TabIndex = 467;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kosten NTTB";
            // 
            // txtCompBijdrageJun
            // 
            this.txtCompBijdrageJun.DecimalPlaces = 2;
            this.txtCompBijdrageJun.DecimalsSeparator = ',';
            this.txtCompBijdrageJun.Location = new System.Drawing.Point(144, 54);
            this.txtCompBijdrageJun.Name = "txtCompBijdrageJun";
            this.txtCompBijdrageJun.PreFix = "€";
            this.txtCompBijdrageJun.Size = new System.Drawing.Size(53, 20);
            this.txtCompBijdrageJun.TabIndex = 473;
            this.txtCompBijdrageJun.Text = "€ 0";
            this.txtCompBijdrageJun.ThousandsSeparator = '.';
            this.txtCompBijdrageJun.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCompBijdrageJun.ToFromInteger = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 13);
            this.label13.TabIndex = 472;
            this.label13.Text = "Competitie Bijdrage Jun";
            // 
            // txtBondsBijdrage
            // 
            this.txtBondsBijdrage.DecimalPlaces = 2;
            this.txtBondsBijdrage.DecimalsSeparator = ',';
            this.txtBondsBijdrage.Location = new System.Drawing.Point(144, 85);
            this.txtBondsBijdrage.Name = "txtBondsBijdrage";
            this.txtBondsBijdrage.PreFix = "€";
            this.txtBondsBijdrage.Size = new System.Drawing.Size(53, 20);
            this.txtBondsBijdrage.TabIndex = 471;
            this.txtBondsBijdrage.Text = "€ 0";
            this.txtBondsBijdrage.ThousandsSeparator = '.';
            this.txtBondsBijdrage.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtBondsBijdrage.ToFromInteger = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 470;
            this.label12.Text = "BondsBijdrage per jaar";
            // 
            // txtCompBijdrageSen
            // 
            this.txtCompBijdrageSen.DecimalPlaces = 2;
            this.txtCompBijdrageSen.DecimalsSeparator = ',';
            this.txtCompBijdrageSen.Location = new System.Drawing.Point(144, 25);
            this.txtCompBijdrageSen.Name = "txtCompBijdrageSen";
            this.txtCompBijdrageSen.PreFix = "€";
            this.txtCompBijdrageSen.Size = new System.Drawing.Size(55, 20);
            this.txtCompBijdrageSen.TabIndex = 469;
            this.txtCompBijdrageSen.Text = "€ 0";
            this.txtCompBijdrageSen.ThousandsSeparator = '.';
            this.txtCompBijdrageSen.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtCompBijdrageSen.ToFromInteger = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 13);
            this.label11.TabIndex = 468;
            this.label11.Text = "Competitie Bijdrage Sen";
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(112, 340);
            this.txtOmschrijving.MaxLength = 150;
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(353, 20);
            this.txtOmschrijving.TabIndex = 469;
            // 
            // lblOmschrijving
            // 
            this.lblOmschrijving.AutoSize = true;
            this.lblOmschrijving.Location = new System.Drawing.Point(21, 343);
            this.lblOmschrijving.Name = "lblOmschrijving";
            this.lblOmschrijving.Size = new System.Drawing.Size(67, 13);
            this.lblOmschrijving.TabIndex = 468;
            this.lblOmschrijving.Text = "Omschrijving";
            // 
            // txtPercZwerf
            // 
            this.txtPercZwerf.Location = new System.Drawing.Point(130, 228);
            this.txtPercZwerf.Name = "txtPercZwerf";
            this.txtPercZwerf.Size = new System.Drawing.Size(24, 20);
            this.txtPercZwerf.TabIndex = 470;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbRelatief);
            this.groupBox3.Controls.Add(this.clbLidTypes);
            this.groupBox3.Controls.Add(this.dtpPeilDatum);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboSelectieType);
            this.groupBox3.Location = new System.Drawing.Point(12, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 197);
            this.groupBox3.TabIndex = 471;
            this.groupBox3.TabStop = false;
            // 
            // ckbRelatief
            // 
            this.ckbRelatief.AutoSize = true;
            this.ckbRelatief.Location = new System.Drawing.Point(12, 171);
            this.ckbRelatief.Name = "ckbRelatief";
            this.ckbRelatief.Size = new System.Drawing.Size(188, 17);
            this.ckbRelatief.TabIndex = 461;
            this.ckbRelatief.Text = "Nieuwe leden halverwege seizoen";
            this.ckbRelatief.UseVisualStyleBackColor = true;
            // 
            // cmdOutput
            // 
            this.cmdOutput.Location = new System.Drawing.Point(23, 409);
            this.cmdOutput.Name = "cmdOutput";
            this.cmdOutput.Size = new System.Drawing.Size(75, 23);
            this.cmdOutput.TabIndex = 472;
            this.cmdOutput.Text = "Show logfile";
            this.cmdOutput.UseVisualStyleBackColor = true;
            this.cmdOutput.Click += new System.EventHandler(this.cmdOutput_Click);
            // 
            // txtKortingVrijwilliger
            // 
            this.txtKortingVrijwilliger.DecimalPlaces = 2;
            this.txtKortingVrijwilliger.DecimalsSeparator = ',';
            this.txtKortingVrijwilliger.Location = new System.Drawing.Point(130, 309);
            this.txtKortingVrijwilliger.Name = "txtKortingVrijwilliger";
            this.txtKortingVrijwilliger.PreFix = "€";
            this.txtKortingVrijwilliger.Size = new System.Drawing.Size(64, 20);
            this.txtKortingVrijwilliger.TabIndex = 474;
            this.txtKortingVrijwilliger.Text = "€ 0";
            this.txtKortingVrijwilliger.ThousandsSeparator = '.';
            this.txtKortingVrijwilliger.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtKortingVrijwilliger.ToFromInteger = 0;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 312);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 13);
            this.label14.TabIndex = 473;
            this.label14.Text = "Korting Vrijwilligers";
            // 
            // cmdToelichting
            // 
            this.cmdToelichting.Location = new System.Drawing.Point(128, 409);
            this.cmdToelichting.Name = "cmdToelichting";
            this.cmdToelichting.Size = new System.Drawing.Size(75, 23);
            this.cmdToelichting.TabIndex = 475;
            this.cmdToelichting.Text = "Toelichting";
            this.cmdToelichting.UseVisualStyleBackColor = true;
            this.cmdToelichting.Click += new System.EventHandler(this.cmdToelichting_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmContributieAanmaken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(493, 454);
            this.Controls.Add(this.cmdToelichting);
            this.Controls.Add(this.txtKortingVrijwilliger);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmdOutput);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtPercZwerf);
            this.Controls.Add(this.txtOmschrijving);
            this.Controls.Add(this.lblOmschrijving);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtKostenRekening);
            this.Controls.Add(this.txtPakketBedrag);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdMaakRekeningen);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmContributieAanmaken";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Contributie Rekeningen Aanmaken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmContributieAanmaken_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpPeilDatum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdMaakRekeningen;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.CheckedListBox clbLidTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSelectieType;
        private Util.Forms.currencyTextBox txtWlpPup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private Util.Forms.currencyTextBox txt65;
        private Util.Forms.currencyTextBox txtSen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private Util.Forms.currencyTextBox txtCadJun;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private Util.Forms.currencyTextBox txtPakketBedrag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Util.Forms.currencyTextBox txtKostenRekening;
        private System.Windows.Forms.GroupBox groupBox2;
        private Util.Forms.currencyTextBox txtBondsBijdrage;
        private System.Windows.Forms.Label label12;
        private Util.Forms.currencyTextBox txtCompBijdrageSen;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.Label lblOmschrijving;
        private System.Windows.Forms.TextBox txtPercZwerf;
        private Util.Forms.currencyTextBox txtCompBijdrageJun;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckbRelatief;
        private System.Windows.Forms.Button cmdOutput;
        private Util.Forms.currencyTextBox txtKortingVrijwilliger;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdToelichting;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
} 