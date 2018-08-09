namespace Leden.Net
{
    partial class frmParameters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameters));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLocatieLogFiles = new System.Windows.Forms.TextBox();
            this.pnlRekeningNummers = new System.Windows.Forms.GroupBox();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKvK = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLocatieLogfiles = new System.Windows.Forms.Label();
            this.pnlTemplates = new System.Windows.Forms.GroupBox();
            this.lblLocatieTemplates = new System.Windows.Forms.Label();
            this.txtTemplateLoc = new System.Windows.Forms.TextBox();
            this.pnlBijlagen = new System.Windows.Forms.GroupBox();
            this.txtInfoFolder = new System.Windows.Forms.TextBox();
            this.lblInformatieFolder = new System.Windows.Forms.Label();
            this.txtReglement = new System.Windows.Forms.TextBox();
            this.lblReglement = new System.Windows.Forms.Label();
            this.txtStatuten = new System.Windows.Forms.TextBox();
            this.lblStatuten = new System.Windows.Forms.Label();
            this.pnlNaam = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameLong = new System.Windows.Forms.TextBox();
            this.txtNameShort = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbDoNotSendEmail = new System.Windows.Forms.CheckBox();
            this.chkLogEmail = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtReturnAddress = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdCheckServer = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlRekeningNummers.SuspendLayout();
            this.pnlTemplates.SuspendLayout();
            this.pnlBijlagen.SuspendLayout();
            this.pnlNaam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(888, 524);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 28);
            this.button1.TabIndex = 20;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtLocatieLogFiles
            // 
            this.txtLocatieLogFiles.Location = new System.Drawing.Point(180, 342);
            this.txtLocatieLogFiles.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocatieLogFiles.Name = "txtLocatieLogFiles";
            this.txtLocatieLogFiles.Size = new System.Drawing.Size(600, 22);
            this.txtLocatieLogFiles.TabIndex = 7;
            this.txtLocatieLogFiles.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // pnlRekeningNummers
            // 
            this.pnlRekeningNummers.Controls.Add(this.txtIBAN);
            this.pnlRekeningNummers.Controls.Add(this.txtBIC);
            this.pnlRekeningNummers.Controls.Add(this.label4);
            this.pnlRekeningNummers.Controls.Add(this.label3);
            this.pnlRekeningNummers.Controls.Add(this.txtKvK);
            this.pnlRekeningNummers.Controls.Add(this.label5);
            this.pnlRekeningNummers.Location = new System.Drawing.Point(44, 386);
            this.pnlRekeningNummers.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRekeningNummers.Name = "pnlRekeningNummers";
            this.pnlRekeningNummers.Padding = new System.Windows.Forms.Padding(4);
            this.pnlRekeningNummers.Size = new System.Drawing.Size(791, 151);
            this.pnlRekeningNummers.TabIndex = 24;
            this.pnlRekeningNummers.TabStop = false;
            this.pnlRekeningNummers.Text = "Rekeningnummers";
            // 
            // txtIBAN
            // 
            this.txtIBAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIBAN.Location = new System.Drawing.Point(160, 28);
            this.txtIBAN.Margin = new System.Windows.Forms.Padding(4);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(183, 22);
            this.txtIBAN.TabIndex = 2;
            this.txtIBAN.Text = "NL84RABO0331065266";
            this.txtIBAN.Validating += new System.ComponentModel.CancelEventHandler(this.txtIBAN_Validating);
            // 
            // txtBIC
            // 
            this.txtBIC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBIC.Location = new System.Drawing.Point(160, 66);
            this.txtBIC.Margin = new System.Windows.Forms.Padding(4);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(111, 22);
            this.txtBIC.TabIndex = 3;
            this.txtBIC.Text = "NLING000000";
            this.txtBIC.TextChanged += new System.EventHandler(this.txtBIC_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kvk";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "IBAN";
            // 
            // txtKvK
            // 
            this.txtKvK.Location = new System.Drawing.Point(159, 106);
            this.txtKvK.Margin = new System.Windows.Forms.Padding(4);
            this.txtKvK.Name = "txtKvK";
            this.txtKvK.Size = new System.Drawing.Size(89, 22);
            this.txtKvK.TabIndex = 4;
            this.txtKvK.Text = "87654321";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 70);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "BIC";
            // 
            // lblLocatieLogfiles
            // 
            this.lblLocatieLogfiles.AutoSize = true;
            this.lblLocatieLogfiles.Location = new System.Drawing.Point(48, 346);
            this.lblLocatieLogfiles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieLogfiles.Name = "lblLocatieLogfiles";
            this.lblLocatieLogfiles.Size = new System.Drawing.Size(115, 17);
            this.lblLocatieLogfiles.TabIndex = 6;
            this.lblLocatieLogfiles.Text = "Locate logfiles ...";
            this.lblLocatieLogfiles.Click += new System.EventHandler(this.lblLocatieLogfiles_Click);
            // 
            // pnlTemplates
            // 
            this.pnlTemplates.Controls.Add(this.lblLocatieTemplates);
            this.pnlTemplates.Controls.Add(this.txtTemplateLoc);
            this.pnlTemplates.Location = new System.Drawing.Point(44, 556);
            this.pnlTemplates.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTemplates.Name = "pnlTemplates";
            this.pnlTemplates.Padding = new System.Windows.Forms.Padding(4);
            this.pnlTemplates.Size = new System.Drawing.Size(791, 81);
            this.pnlTemplates.TabIndex = 22;
            this.pnlTemplates.TabStop = false;
            this.pnlTemplates.Text = "Template Locaties";
            // 
            // lblLocatieTemplates
            // 
            this.lblLocatieTemplates.AutoSize = true;
            this.lblLocatieTemplates.Location = new System.Drawing.Point(27, 39);
            this.lblLocatieTemplates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieTemplates.Name = "lblLocatieTemplates";
            this.lblLocatieTemplates.Size = new System.Drawing.Size(132, 17);
            this.lblLocatieTemplates.TabIndex = 0;
            this.lblLocatieTemplates.Text = "Locate templates ...";
            this.lblLocatieTemplates.Click += new System.EventHandler(this.lblLocatieTemplates_Click);
            // 
            // txtTemplateLoc
            // 
            this.txtTemplateLoc.Location = new System.Drawing.Point(160, 36);
            this.txtTemplateLoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtTemplateLoc.Name = "txtTemplateLoc";
            this.txtTemplateLoc.Size = new System.Drawing.Size(600, 22);
            this.txtTemplateLoc.TabIndex = 5;
            this.txtTemplateLoc.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // pnlBijlagen
            // 
            this.pnlBijlagen.Controls.Add(this.txtInfoFolder);
            this.pnlBijlagen.Controls.Add(this.lblInformatieFolder);
            this.pnlBijlagen.Controls.Add(this.txtReglement);
            this.pnlBijlagen.Controls.Add(this.lblReglement);
            this.pnlBijlagen.Controls.Add(this.txtStatuten);
            this.pnlBijlagen.Controls.Add(this.lblStatuten);
            this.pnlBijlagen.Location = new System.Drawing.Point(44, 652);
            this.pnlBijlagen.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBijlagen.Name = "pnlBijlagen";
            this.pnlBijlagen.Padding = new System.Windows.Forms.Padding(4);
            this.pnlBijlagen.Size = new System.Drawing.Size(791, 174);
            this.pnlBijlagen.TabIndex = 6;
            this.pnlBijlagen.TabStop = false;
            this.pnlBijlagen.Text = "Bijlagen nieuw lid";
            // 
            // txtInfoFolder
            // 
            this.txtInfoFolder.Location = new System.Drawing.Point(155, 107);
            this.txtInfoFolder.Margin = new System.Windows.Forms.Padding(4);
            this.txtInfoFolder.Name = "txtInfoFolder";
            this.txtInfoFolder.Size = new System.Drawing.Size(600, 22);
            this.txtInfoFolder.TabIndex = 3;
            this.txtInfoFolder.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // lblInformatieFolder
            // 
            this.lblInformatieFolder.AutoSize = true;
            this.lblInformatieFolder.Location = new System.Drawing.Point(21, 111);
            this.lblInformatieFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInformatieFolder.Name = "lblInformatieFolder";
            this.lblInformatieFolder.Size = new System.Drawing.Size(126, 17);
            this.lblInformatieFolder.TabIndex = 23;
            this.lblInformatieFolder.Text = "Informatie folder ...";
            this.lblInformatieFolder.Click += new System.EventHandler(this.lblInformatieFolder_Click);
            // 
            // txtReglement
            // 
            this.txtReglement.Location = new System.Drawing.Point(155, 71);
            this.txtReglement.Margin = new System.Windows.Forms.Padding(4);
            this.txtReglement.Name = "txtReglement";
            this.txtReglement.Size = new System.Drawing.Size(600, 22);
            this.txtReglement.TabIndex = 2;
            this.txtReglement.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // lblReglement
            // 
            this.lblReglement.AutoSize = true;
            this.lblReglement.Location = new System.Drawing.Point(21, 75);
            this.lblReglement.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReglement.Name = "lblReglement";
            this.lblReglement.Size = new System.Drawing.Size(92, 17);
            this.lblReglement.TabIndex = 21;
            this.lblReglement.Text = "Reglement ...";
            this.lblReglement.Click += new System.EventHandler(this.lblReglement_Click);
            // 
            // txtStatuten
            // 
            this.txtStatuten.Location = new System.Drawing.Point(155, 33);
            this.txtStatuten.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatuten.Name = "txtStatuten";
            this.txtStatuten.Size = new System.Drawing.Size(600, 22);
            this.txtStatuten.TabIndex = 1;
            this.txtStatuten.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // lblStatuten
            // 
            this.lblStatuten.AutoSize = true;
            this.lblStatuten.Location = new System.Drawing.Point(21, 37);
            this.lblStatuten.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatuten.Name = "lblStatuten";
            this.lblStatuten.Size = new System.Drawing.Size(77, 17);
            this.lblStatuten.TabIndex = 19;
            this.lblStatuten.Text = "Statuten ...";
            this.lblStatuten.Click += new System.EventHandler(this.lblStatuten_Click);
            // 
            // pnlNaam
            // 
            this.pnlNaam.Controls.Add(this.label2);
            this.pnlNaam.Controls.Add(this.label1);
            this.pnlNaam.Controls.Add(this.txtNameLong);
            this.pnlNaam.Controls.Add(this.txtNameShort);
            this.pnlNaam.Location = new System.Drawing.Point(44, 199);
            this.pnlNaam.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNaam.Name = "pnlNaam";
            this.pnlNaam.Padding = new System.Windows.Forms.Padding(4);
            this.pnlNaam.Size = new System.Drawing.Size(791, 128);
            this.pnlNaam.TabIndex = 21;
            this.pnlNaam.TabStop = false;
            this.pnlNaam.Text = "Naam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Korte Verenigingsnaam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lange Verenigingsnaam";
            // 
            // txtNameLong
            // 
            this.txtNameLong.Location = new System.Drawing.Point(231, 71);
            this.txtNameLong.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameLong.Name = "txtNameLong";
            this.txtNameLong.Size = new System.Drawing.Size(373, 22);
            this.txtNameLong.TabIndex = 1;
            this.txtNameLong.Text = "Tafeltennisvereniging Nieuwegein";
            // 
            // txtNameShort
            // 
            this.txtNameShort.Location = new System.Drawing.Point(231, 30);
            this.txtNameShort.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameShort.Name = "txtNameShort";
            this.txtNameShort.Size = new System.Drawing.Size(165, 22);
            this.txtNameShort.TabIndex = 0;
            this.txtNameShort.Text = "TTVN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbDoNotSendEmail);
            this.groupBox1.Controls.Add(this.chkLogEmail);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtReturnAddress);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.txtSMTPServer);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(44, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(791, 158);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Parameters";
            // 
            // ckbDoNotSendEmail
            // 
            this.ckbDoNotSendEmail.AutoSize = true;
            this.ckbDoNotSendEmail.Location = new System.Drawing.Point(292, 121);
            this.ckbDoNotSendEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ckbDoNotSendEmail.Name = "ckbDoNotSendEmail";
            this.ckbDoNotSendEmail.Size = new System.Drawing.Size(305, 21);
            this.ckbDoNotSendEmail.TabIndex = 6;
            this.ckbDoNotSendEmail.Text = "Emails niet versturen (voor test doeleinden)";
            this.ckbDoNotSendEmail.UseVisualStyleBackColor = true;
            // 
            // chkLogEmail
            // 
            this.chkLogEmail.AutoSize = true;
            this.chkLogEmail.Location = new System.Drawing.Point(25, 121);
            this.chkLogEmail.Margin = new System.Windows.Forms.Padding(4);
            this.chkLogEmail.Name = "chkLogEmail";
            this.chkLogEmail.Size = new System.Drawing.Size(180, 21);
            this.chkLogEmail.TabIndex = 6;
            this.chkLogEmail.Text = "Schrijf alle mail in logfile";
            this.chkLogEmail.UseVisualStyleBackColor = true;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(435, 33);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.MaxLength = 4;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(37, 22);
            this.txtPort.TabIndex = 5;
            this.txtPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPort_KeyDown);
            // 
            // txtReturnAddress
            // 
            this.txtReturnAddress.Location = new System.Drawing.Point(143, 76);
            this.txtReturnAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtReturnAddress.Name = "txtReturnAddress";
            this.txtReturnAddress.Size = new System.Drawing.Size(329, 22);
            this.txtReturnAddress.TabIndex = 2;
            this.txtReturnAddress.Text = "\"TTVN - my_function\" <my_return_email@ttvn.nl>";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(576, 76);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 22);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "queen00";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(576, 33);
            this.txtUserID.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(180, 22);
            this.txtUserID.TabIndex = 3;
            this.txtUserID.Text = "w.kielen@casema.nl";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Location = new System.Drawing.Point(143, 33);
            this.txtSMTPServer.Margin = new System.Windows.Forms.Padding(4);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(283, 22);
            this.txtSMTPServer.TabIndex = 1;
            this.txtSMTPServer.Text = "smtp.ziggo.nl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 80);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "Afzender email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(497, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 17);
            this.label9.TabIndex = 0;
            this.label9.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(497, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "UserID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 37);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "SMTP server";
            // 
            // cmdCheckServer
            // 
            this.cmdCheckServer.Location = new System.Drawing.Point(888, 35);
            this.cmdCheckServer.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCheckServer.Name = "cmdCheckServer";
            this.cmdCheckServer.Size = new System.Drawing.Size(125, 28);
            this.cmdCheckServer.TabIndex = 20;
            this.cmdCheckServer.Text = "Check Server";
            this.cmdCheckServer.UseVisualStyleBackColor = true;
            this.cmdCheckServer.Click += new System.EventHandler(this.cmdCheckServer_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(888, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 25;
            // 
            // frmParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1040, 592);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtLocatieLogFiles);
            this.Controls.Add(this.pnlRekeningNummers);
            this.Controls.Add(this.lblLocatieLogfiles);
            this.Controls.Add(this.pnlTemplates);
            this.Controls.Add(this.pnlBijlagen);
            this.Controls.Add(this.pnlNaam);
            this.Controls.Add(this.cmdCheckServer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmParameters";
            this.ShowInTaskbar = false;
            this.Text = "Vaste gegevens";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmParameters_FormClosing);
            this.pnlRekeningNummers.ResumeLayout(false);
            this.pnlRekeningNummers.PerformLayout();
            this.pnlTemplates.ResumeLayout(false);
            this.pnlTemplates.PerformLayout();
            this.pnlBijlagen.ResumeLayout(false);
            this.pnlBijlagen.PerformLayout();
            this.pnlNaam.ResumeLayout(false);
            this.pnlNaam.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLocatieTemplates;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.TextBox txtBIC;
        private System.Windows.Forms.TextBox txtNameShort;
        private System.Windows.Forms.TextBox txtNameLong;
        private System.Windows.Forms.TextBox txtTemplateLoc;
        private System.Windows.Forms.TextBox txtKvK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReturnAddress;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox pnlNaam;
        private System.Windows.Forms.TextBox txtStatuten;
        private System.Windows.Forms.Label lblStatuten;
        private System.Windows.Forms.TextBox txtInfoFolder;
        private System.Windows.Forms.Label lblInformatieFolder;
        private System.Windows.Forms.TextBox txtReglement;
        private System.Windows.Forms.Label lblReglement;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtLocatieLogFiles;
        private System.Windows.Forms.Label lblLocatieLogfiles;
        public System.Windows.Forms.GroupBox pnlTemplates;
        public System.Windows.Forms.GroupBox pnlRekeningNummers;
        public System.Windows.Forms.GroupBox pnlBijlagen;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.CheckBox ckbDoNotSendEmail;
        private System.Windows.Forms.CheckBox chkLogEmail;
        private System.Windows.Forms.Button cmdCheckServer;
        private System.Windows.Forms.Label lblStatus;
    }
}