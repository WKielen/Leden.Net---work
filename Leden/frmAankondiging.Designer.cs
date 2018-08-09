namespace Leden.Net
{
    partial class frmAankondiging
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAankondiging));
            this.fdiBrowseTemplate = new System.Windows.Forms.FolderBrowserDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExit = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmdShowLogfileMail = new System.Windows.Forms.Button();
            this.chkLogEmail = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdMailRek = new System.Windows.Forms.Button();
            this.lblMessageRek = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdMail = new System.Windows.Forms.Button();
            this.ckbDoNotSendEmail = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpIncassoDatum = new System.Windows.Forms.DateTimePicker();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(607, 251);
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
            this.groupBox5.Controls.Add(this.chkLogEmail);
            this.groupBox5.Location = new System.Drawing.Point(492, 31);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(215, 121);
            this.groupBox5.TabIndex = 476;
            this.groupBox5.TabStop = false;
            // 
            // cmdShowLogfileMail
            // 
            this.cmdShowLogfileMail.Location = new System.Drawing.Point(18, 56);
            this.cmdShowLogfileMail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShowLogfileMail.Name = "cmdShowLogfileMail";
            this.cmdShowLogfileMail.Size = new System.Drawing.Size(96, 46);
            this.cmdShowLogfileMail.TabIndex = 477;
            this.cmdShowLogfileMail.Text = "Show logfile Mail";
            this.cmdShowLogfileMail.UseVisualStyleBackColor = true;
            this.cmdShowLogfileMail.Click += new System.EventHandler(this.cmdShowLogfileMail_Click);
            // 
            // chkLogEmail
            // 
            this.chkLogEmail.AutoSize = true;
            this.chkLogEmail.Location = new System.Drawing.Point(18, 18);
            this.chkLogEmail.Margin = new System.Windows.Forms.Padding(4);
            this.chkLogEmail.Name = "chkLogEmail";
            this.chkLogEmail.Size = new System.Drawing.Size(180, 21);
            this.chkLogEmail.TabIndex = 8;
            this.chkLogEmail.Text = "Schrijf alle mail in logfile";
            this.chkLogEmail.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdMailRek);
            this.groupBox2.Controls.Add(this.lblMessageRek);
            this.groupBox2.Location = new System.Drawing.Point(43, 182);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(418, 97);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rekening aankondigingen";
            // 
            // cmdMailRek
            // 
            this.cmdMailRek.Location = new System.Drawing.Point(224, 20);
            this.cmdMailRek.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMailRek.Name = "cmdMailRek";
            this.cmdMailRek.Size = new System.Drawing.Size(121, 42);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdMail);
            this.groupBox1.Controls.Add(this.ckbDoNotSendEmail);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpIncassoDatum);
            this.groupBox1.Location = new System.Drawing.Point(43, 31);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(418, 129);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incasso aankondigingen";
            // 
            // cmdMail
            // 
            this.cmdMail.Location = new System.Drawing.Point(223, 20);
            this.cmdMail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMail.Name = "cmdMail";
            this.cmdMail.Size = new System.Drawing.Size(122, 42);
            this.cmdMail.TabIndex = 6;
            this.cmdMail.Text = "Versturen Aankondigingen";
            this.cmdMail.UseVisualStyleBackColor = true;
            this.cmdMail.Click += new System.EventHandler(this.cmdMail_Click);
            // 
            // ckbDoNotSendEmail
            // 
            this.ckbDoNotSendEmail.AutoSize = true;
            this.ckbDoNotSendEmail.Location = new System.Drawing.Point(224, 80);
            this.ckbDoNotSendEmail.Margin = new System.Windows.Forms.Padding(4);
            this.ckbDoNotSendEmail.Name = "ckbDoNotSendEmail";
            this.ckbDoNotSendEmail.Size = new System.Drawing.Size(169, 38);
            this.ckbDoNotSendEmail.TabIndex = 7;
            this.ckbDoNotSendEmail.Text = "Emails niet versturen\r\n(voor test doeleinden)";
            this.ckbDoNotSendEmail.UseVisualStyleBackColor = true;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gewenste Incassodatum";
            // 
            // dtpIncassoDatum
            // 
            this.dtpIncassoDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIncassoDatum.Location = new System.Drawing.Point(22, 89);
            this.dtpIncassoDatum.Margin = new System.Windows.Forms.Padding(4);
            this.dtpIncassoDatum.Name = "dtpIncassoDatum";
            this.dtpIncassoDatum.Size = new System.Drawing.Size(107, 22);
            this.dtpIncassoDatum.TabIndex = 0;
            // 
            // frmAankondiging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(737, 301);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAankondiging";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Aankondigingen versturen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRekeningVersturen_FormClosing);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpIncassoDatum;
        private System.Windows.Forms.FolderBrowserDialog fdiBrowseTemplate;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button cmdMail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblMessageRek;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdMailRek;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox ckbDoNotSendEmail;
        private System.Windows.Forms.CheckBox chkLogEmail;
        private System.Windows.Forms.Button cmdShowLogfileMail;
    }
}