namespace Leden.Net
{
    partial class frmIncassoBestand2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIncassoBestand2));
            this.fdiBrowseTemplate = new System.Windows.Forms.FolderBrowserDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExit = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdShowLogfileMail = new System.Windows.Forms.Button();
            this.ckbDoNotSendEmail = new System.Windows.Forms.CheckBox();
            this.chkLogEmail = new System.Windows.Forms.CheckBox();
            this.cmdOutput = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMessageUPas = new System.Windows.Forms.Label();
            this.lblLocatieOutputUPas = new System.Windows.Forms.Label();
            this.cmdMaakBestandUPas = new System.Windows.Forms.Button();
            this.txtOutputLocationUPas = new System.Windows.Forms.TextBox();
            this.txtFilePrefixUPas = new System.Windows.Forms.TextBox();
            this.txtFileSeqnrUPas = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdMailRek = new System.Windows.Forms.Button();
            this.lblMessageRek = new System.Windows.Forms.Label();
            this.lblLocatieOutputCSV = new System.Windows.Forms.Label();
            this.cmdMaakBestandRek = new System.Windows.Forms.Button();
            this.txtOutputLocationRek = new System.Windows.Forms.TextBox();
            this.txtFilePrefixRek = new System.Windows.Forms.TextBox();
            this.txtFileSeqnrRek = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdMail = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLocatieOutput = new System.Windows.Forms.Label();
            this.cmdMaakbestand = new System.Windows.Forms.Button();
            this.txtOutputLocationInc = new System.Windows.Forms.TextBox();
            this.txtMsgID = new System.Windows.Forms.TextBox();
            this.txtFilePrefix = new System.Windows.Forms.TextBox();
            this.txtFileSeqnr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpIncassoDatum = new System.Windows.Forms.DateTimePicker();
            this.chkPrintVerslag = new System.Windows.Forms.CheckBox();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(1111, 690);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(100, 28);
            this.cmdExit.TabIndex = 8;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmdShowLogfileMail);
            this.groupBox5.Controls.Add(this.ckbDoNotSendEmail);
            this.groupBox5.Controls.Add(this.chkLogEmail);
            this.groupBox5.Location = new System.Drawing.Point(881, 535);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(329, 91);
            this.groupBox5.TabIndex = 476;
            this.groupBox5.TabStop = false;
            // 
            // cmdShowLogfileMail
            // 
            this.cmdShowLogfileMail.Location = new System.Drawing.Point(229, 18);
            this.cmdShowLogfileMail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShowLogfileMail.Name = "cmdShowLogfileMail";
            this.cmdShowLogfileMail.Size = new System.Drawing.Size(96, 46);
            this.cmdShowLogfileMail.TabIndex = 477;
            this.cmdShowLogfileMail.Text = "Show logfile Mail";
            this.cmdShowLogfileMail.UseVisualStyleBackColor = true;
            this.cmdShowLogfileMail.Click += new System.EventHandler(this.cmdShowLogfileMail_Click);
            // 
            // ckbDoNotSendEmail
            // 
            this.ckbDoNotSendEmail.AutoSize = true;
            this.ckbDoNotSendEmail.Location = new System.Drawing.Point(20, 48);
            this.ckbDoNotSendEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ckbDoNotSendEmail.Name = "ckbDoNotSendEmail";
            this.ckbDoNotSendEmail.Size = new System.Drawing.Size(169, 38);
            this.ckbDoNotSendEmail.TabIndex = 7;
            this.ckbDoNotSendEmail.Text = "Emails niet versturen\r\n(voor test doeleinden)";
            this.ckbDoNotSendEmail.UseVisualStyleBackColor = true;
            // 
            // chkLogEmail
            // 
            this.chkLogEmail.AutoSize = true;
            this.chkLogEmail.Location = new System.Drawing.Point(20, 20);
            this.chkLogEmail.Margin = new System.Windows.Forms.Padding(4);
            this.chkLogEmail.Name = "chkLogEmail";
            this.chkLogEmail.Size = new System.Drawing.Size(180, 21);
            this.chkLogEmail.TabIndex = 8;
            this.chkLogEmail.Text = "Schrijf alle mail in logfile";
            this.chkLogEmail.UseVisualStyleBackColor = true;
            // 
            // cmdOutput
            // 
            this.cmdOutput.Location = new System.Drawing.Point(901, 52);
            this.cmdOutput.Margin = new System.Windows.Forms.Padding(4);
            this.cmdOutput.Name = "cmdOutput";
            this.cmdOutput.Size = new System.Drawing.Size(116, 46);
            this.cmdOutput.TabIndex = 474;
            this.cmdOutput.Text = "Show logfile Rekeningen";
            this.cmdOutput.UseVisualStyleBackColor = true;
            this.cmdOutput.Click += new System.EventHandler(this.cmdOutput_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblMessageUPas);
            this.groupBox3.Controls.Add(this.lblLocatieOutputUPas);
            this.groupBox3.Controls.Add(this.cmdMaakBestandUPas);
            this.groupBox3.Controls.Add(this.txtOutputLocationUPas);
            this.groupBox3.Controls.Add(this.txtFilePrefixUPas);
            this.groupBox3.Controls.Add(this.txtFileSeqnrUPas);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Location = new System.Drawing.Point(43, 535);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(813, 183);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rekeningbestand U-Pas";
            // 
            // lblMessageUPas
            // 
            this.lblMessageUPas.AutoSize = true;
            this.lblMessageUPas.Location = new System.Drawing.Point(19, 33);
            this.lblMessageUPas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageUPas.Name = "lblMessageUPas";
            this.lblMessageUPas.Size = new System.Drawing.Size(113, 17);
            this.lblMessageUPas.TabIndex = 5;
            this.lblMessageUPas.Text = "lblMessageUPas";
            // 
            // lblLocatieOutputUPas
            // 
            this.lblLocatieOutputUPas.AutoSize = true;
            this.lblLocatieOutputUPas.Location = new System.Drawing.Point(19, 73);
            this.lblLocatieOutputUPas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieOutputUPas.Name = "lblLocatieOutputUPas";
            this.lblLocatieOutputUPas.Size = new System.Drawing.Size(114, 17);
            this.lblLocatieOutputUPas.TabIndex = 4;
            this.lblLocatieOutputUPas.Text = "Locatie output ...";
            this.lblLocatieOutputUPas.Click += new System.EventHandler(this.lblLocatieOutputUPas_Click);
            // 
            // cmdMaakBestandUPas
            // 
            this.cmdMaakBestandUPas.Location = new System.Drawing.Point(675, 111);
            this.cmdMaakBestandUPas.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMaakBestandUPas.Name = "cmdMaakBestandUPas";
            this.cmdMaakBestandUPas.Size = new System.Drawing.Size(113, 28);
            this.cmdMaakBestandUPas.TabIndex = 0;
            this.cmdMaakBestandUPas.Text = "Maak bestand";
            this.cmdMaakBestandUPas.UseVisualStyleBackColor = true;
            this.cmdMaakBestandUPas.Click += new System.EventHandler(this.cmdMaakBestandUPas_Click);
            // 
            // txtOutputLocationUPas
            // 
            this.txtOutputLocationUPas.Location = new System.Drawing.Point(221, 69);
            this.txtOutputLocationUPas.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputLocationUPas.Name = "txtOutputLocationUPas";
            this.txtOutputLocationUPas.Size = new System.Drawing.Size(552, 22);
            this.txtOutputLocationUPas.TabIndex = 3;
            this.txtOutputLocationUPas.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // txtFilePrefixUPas
            // 
            this.txtFilePrefixUPas.Location = new System.Drawing.Point(221, 107);
            this.txtFilePrefixUPas.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePrefixUPas.Name = "txtFilePrefixUPas";
            this.txtFilePrefixUPas.Size = new System.Drawing.Size(220, 22);
            this.txtFilePrefixUPas.TabIndex = 2;
            this.txtFilePrefixUPas.Text = "UPas";
            // 
            // txtFileSeqnrUPas
            // 
            this.txtFileSeqnrUPas.Location = new System.Drawing.Point(221, 142);
            this.txtFileSeqnrUPas.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileSeqnrUPas.Name = "txtFileSeqnrUPas";
            this.txtFileSeqnrUPas.Size = new System.Drawing.Size(69, 22);
            this.txtFileSeqnrUPas.TabIndex = 2;
            this.txtFileSeqnrUPas.Text = "1";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 145);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Bestand Seqnr";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 111);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 17);
            this.label14.TabIndex = 1;
            this.label14.Text = "Bestand Prefix";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdMailRek);
            this.groupBox2.Controls.Add(this.lblMessageRek);
            this.groupBox2.Controls.Add(this.lblLocatieOutputCSV);
            this.groupBox2.Controls.Add(this.cmdMaakBestandRek);
            this.groupBox2.Controls.Add(this.txtOutputLocationRek);
            this.groupBox2.Controls.Add(this.txtFilePrefixRek);
            this.groupBox2.Controls.Add(this.txtFileSeqnrRek);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(43, 303);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(813, 204);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rekeningbestand CSV";
            // 
            // cmdMailRek
            // 
            this.cmdMailRek.Enabled = false;
            this.cmdMailRek.Location = new System.Drawing.Point(675, 150);
            this.cmdMailRek.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMailRek.Name = "cmdMailRek";
            this.cmdMailRek.Size = new System.Drawing.Size(113, 42);
            this.cmdMailRek.TabIndex = 6;
            this.cmdMailRek.Text = "Versturen Aankondigingen";
            this.cmdMailRek.UseVisualStyleBackColor = true;
            this.cmdMailRek.Click += new System.EventHandler(this.cmdMailRek_Click);
            // 
            // lblMessageRek
            // 
            this.lblMessageRek.AutoSize = true;
            this.lblMessageRek.Location = new System.Drawing.Point(19, 33);
            this.lblMessageRek.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessageRek.Name = "lblMessageRek";
            this.lblMessageRek.Size = new System.Drawing.Size(46, 17);
            this.lblMessageRek.TabIndex = 5;
            this.lblMessageRek.Text = "label8";
            // 
            // lblLocatieOutputCSV
            // 
            this.lblLocatieOutputCSV.AutoSize = true;
            this.lblLocatieOutputCSV.Location = new System.Drawing.Point(19, 73);
            this.lblLocatieOutputCSV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieOutputCSV.Name = "lblLocatieOutputCSV";
            this.lblLocatieOutputCSV.Size = new System.Drawing.Size(114, 17);
            this.lblLocatieOutputCSV.TabIndex = 4;
            this.lblLocatieOutputCSV.Text = "Locatie output ...";
            this.lblLocatieOutputCSV.Click += new System.EventHandler(this.lblLocatieOutputCSV_Click);
            // 
            // cmdMaakBestandRek
            // 
            this.cmdMaakBestandRek.Location = new System.Drawing.Point(675, 111);
            this.cmdMaakBestandRek.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMaakBestandRek.Name = "cmdMaakBestandRek";
            this.cmdMaakBestandRek.Size = new System.Drawing.Size(113, 28);
            this.cmdMaakBestandRek.TabIndex = 0;
            this.cmdMaakBestandRek.Text = "Maak bestand";
            this.cmdMaakBestandRek.UseVisualStyleBackColor = true;
            this.cmdMaakBestandRek.Click += new System.EventHandler(this.cmdMaakBestandRek_Click);
            // 
            // txtOutputLocationRek
            // 
            this.txtOutputLocationRek.Location = new System.Drawing.Point(221, 69);
            this.txtOutputLocationRek.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputLocationRek.Name = "txtOutputLocationRek";
            this.txtOutputLocationRek.Size = new System.Drawing.Size(552, 22);
            this.txtOutputLocationRek.TabIndex = 3;
            this.txtOutputLocationRek.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // txtFilePrefixRek
            // 
            this.txtFilePrefixRek.Location = new System.Drawing.Point(221, 107);
            this.txtFilePrefixRek.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePrefixRek.Name = "txtFilePrefixRek";
            this.txtFilePrefixRek.Size = new System.Drawing.Size(220, 22);
            this.txtFilePrefixRek.TabIndex = 2;
            this.txtFilePrefixRek.Text = "Rekening";
            // 
            // txtFileSeqnrRek
            // 
            this.txtFileSeqnrRek.Location = new System.Drawing.Point(221, 142);
            this.txtFileSeqnrRek.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileSeqnrRek.Name = "txtFileSeqnrRek";
            this.txtFileSeqnrRek.Size = new System.Drawing.Size(69, 22);
            this.txtFileSeqnrRek.TabIndex = 2;
            this.txtFileSeqnrRek.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Bestand Seqnr";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 111);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 17);
            this.label12.TabIndex = 1;
            this.label12.Text = "Bestand Prefix";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPrintVerslag);
            this.groupBox1.Controls.Add(this.cmdMail);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.lblLocatieOutput);
            this.groupBox1.Controls.Add(this.cmdMaakbestand);
            this.groupBox1.Controls.Add(this.txtOutputLocationInc);
            this.groupBox1.Controls.Add(this.txtMsgID);
            this.groupBox1.Controls.Add(this.txtFilePrefix);
            this.groupBox1.Controls.Add(this.txtFileSeqnr);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpIncassoDatum);
            this.groupBox1.Location = new System.Drawing.Point(43, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(813, 252);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incassobestand";
            // 
            // cmdMail
            // 
            this.cmdMail.Enabled = false;
            this.cmdMail.Location = new System.Drawing.Point(675, 199);
            this.cmdMail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMail.Name = "cmdMail";
            this.cmdMail.Size = new System.Drawing.Size(113, 42);
            this.cmdMail.TabIndex = 6;
            this.cmdMail.Text = "Versturen Aankondigingen";
            this.cmdMail.UseVisualStyleBackColor = true;
            this.cmdMail.Click += new System.EventHandler(this.cmdMail_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(19, 33);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(46, 17);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "label8";
            // 
            // lblLocatieOutput
            // 
            this.lblLocatieOutput.AutoSize = true;
            this.lblLocatieOutput.Location = new System.Drawing.Point(19, 101);
            this.lblLocatieOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieOutput.Name = "lblLocatieOutput";
            this.lblLocatieOutput.Size = new System.Drawing.Size(114, 17);
            this.lblLocatieOutput.TabIndex = 4;
            this.lblLocatieOutput.Text = "Locatie output ...";
            this.lblLocatieOutput.Click += new System.EventHandler(this.lblLocatieOutput_Click);
            // 
            // cmdMaakbestand
            // 
            this.cmdMaakbestand.Location = new System.Drawing.Point(675, 160);
            this.cmdMaakbestand.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMaakbestand.Name = "cmdMaakbestand";
            this.cmdMaakbestand.Size = new System.Drawing.Size(113, 28);
            this.cmdMaakbestand.TabIndex = 0;
            this.cmdMaakbestand.Text = "Maak bestand";
            this.cmdMaakbestand.UseVisualStyleBackColor = true;
            this.cmdMaakbestand.Click += new System.EventHandler(this.cmdMaakbestand_Click);
            // 
            // txtOutputLocationInc
            // 
            this.txtOutputLocationInc.Location = new System.Drawing.Point(221, 97);
            this.txtOutputLocationInc.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputLocationInc.Name = "txtOutputLocationInc";
            this.txtOutputLocationInc.Size = new System.Drawing.Size(552, 22);
            this.txtOutputLocationInc.TabIndex = 3;
            this.txtOutputLocationInc.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // txtMsgID
            // 
            this.txtMsgID.Location = new System.Drawing.Point(221, 132);
            this.txtMsgID.Margin = new System.Windows.Forms.Padding(4);
            this.txtMsgID.Name = "txtMsgID";
            this.txtMsgID.Size = new System.Drawing.Size(220, 22);
            this.txtMsgID.TabIndex = 2;
            this.txtMsgID.Text = "TTVN incasso";
            // 
            // txtFilePrefix
            // 
            this.txtFilePrefix.Location = new System.Drawing.Point(221, 169);
            this.txtFilePrefix.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePrefix.Name = "txtFilePrefix";
            this.txtFilePrefix.Size = new System.Drawing.Size(220, 22);
            this.txtFilePrefix.TabIndex = 2;
            this.txtFilePrefix.Text = "PAIN";
            // 
            // txtFileSeqnr
            // 
            this.txtFileSeqnr.Location = new System.Drawing.Point(221, 203);
            this.txtFileSeqnr.Margin = new System.Windows.Forms.Padding(4);
            this.txtFileSeqnr.Name = "txtFileSeqnr";
            this.txtFileSeqnr.Size = new System.Drawing.Size(69, 22);
            this.txtFileSeqnr.TabIndex = 2;
            this.txtFileSeqnr.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bestand MsgID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 207);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Bestand Seqnr";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 172);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bestand Prefix";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gewenste Incassodatum";
            // 
            // dtpIncassoDatum
            // 
            this.dtpIncassoDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIncassoDatum.Location = new System.Drawing.Point(221, 64);
            this.dtpIncassoDatum.Margin = new System.Windows.Forms.Padding(4);
            this.dtpIncassoDatum.Name = "dtpIncassoDatum";
            this.dtpIncassoDatum.Size = new System.Drawing.Size(107, 22);
            this.dtpIncassoDatum.TabIndex = 0;
            // 
            // chkPrintVerslag
            // 
            this.chkPrintVerslag.AutoSize = true;
            this.chkPrintVerslag.Location = new System.Drawing.Point(662, 35);
            this.chkPrintVerslag.Name = "chkPrintVerslag";
            this.chkPrintVerslag.Size = new System.Drawing.Size(111, 21);
            this.chkPrintVerslag.TabIndex = 8;
            this.chkPrintVerslag.Text = "Print Verslag";
            this.chkPrintVerslag.UseVisualStyleBackColor = true;
            // 
            // frmIncassoBestand2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(1227, 738);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmdOutput);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmIncassoBestand2";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rekening Bestand maken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRekeningVersturen_FormClosing);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdMaakbestand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIncassoDatum;
        private System.Windows.Forms.FolderBrowserDialog fdiBrowseTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMsgID;
        private System.Windows.Forms.Label lblLocatieOutput;
        private System.Windows.Forms.TextBox txtOutputLocationInc;
        private System.Windows.Forms.TextBox txtFilePrefix;
        private System.Windows.Forms.TextBox txtFileSeqnr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button cmdMail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMessageRek;
        private System.Windows.Forms.Label lblLocatieOutputCSV;
        private System.Windows.Forms.Button cmdMaakBestandRek;
        private System.Windows.Forms.TextBox txtOutputLocationRek;
        private System.Windows.Forms.TextBox txtFilePrefixRek;
        private System.Windows.Forms.TextBox txtFileSeqnrRek;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMessageUPas;
        private System.Windows.Forms.Label lblLocatieOutputUPas;
        private System.Windows.Forms.Button cmdMaakBestandUPas;
        private System.Windows.Forms.TextBox txtOutputLocationUPas;
        private System.Windows.Forms.TextBox txtFilePrefixUPas;
        private System.Windows.Forms.TextBox txtFileSeqnrUPas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdMailRek;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button cmdOutput;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ckbDoNotSendEmail;
        private System.Windows.Forms.CheckBox chkLogEmail;
        private System.Windows.Forms.Button cmdShowLogfileMail;
        private System.Windows.Forms.CheckBox chkPrintVerslag;
    }
}