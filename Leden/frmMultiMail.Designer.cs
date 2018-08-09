namespace Leden.Net
{
    partial class frmMultiMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMultiMail));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.clbLeden = new System.Windows.Forms.CheckedListBox();
            this.htmlTextbox1 = new Util.Forms.HtmlTextbox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdPaste = new System.Windows.Forms.Button();
            this.lblAddtoList = new System.Windows.Forms.Label();
            this.lblExtraEmail = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlBottum = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdShowLogfileMail = new System.Windows.Forms.Button();
            this.ckbDoNotSendEmail = new System.Windows.Forms.CheckBox();
            this.chkLogEmail = new System.Windows.Forms.CheckBox();
            this.cmdToelichting = new System.Windows.Forms.Button();
            this.clbExtraEmail = new System.Windows.Forms.CheckedListBox();
            this.ckbHtml = new System.Windows.Forms.CheckBox();
            this.cmdGetMail = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExtraEmail = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.cmdSaveMail = new System.Windows.Forms.Button();
            this.txtBijlage3 = new System.Windows.Forms.TextBox();
            this.cmdVerstuurMail = new System.Windows.Forms.Button();
            this.lblBijlage3 = new System.Windows.Forms.Label();
            this.lblBijlage1 = new System.Windows.Forms.Label();
            this.txtBijlage2 = new System.Windows.Forms.TextBox();
            this.txtBijlage1 = new System.Windows.Forms.TextBox();
            this.lblBijlage2 = new System.Windows.Forms.Label();
            this.pnlFill.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBottum.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 1200000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 0;
            // 
            // clbLeden
            // 
            this.clbLeden.CheckOnClick = true;
            this.clbLeden.ColumnWidth = 250;
            this.clbLeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLeden.FormattingEnabled = true;
            this.clbLeden.HorizontalScrollbar = true;
            this.clbLeden.Location = new System.Drawing.Point(0, 0);
            this.clbLeden.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbLeden.MultiColumn = true;
            this.clbLeden.Name = "clbLeden";
            this.clbLeden.Size = new System.Drawing.Size(456, 923);
            this.clbLeden.TabIndex = 10;
            this.toolTip1.SetToolTip(this.clbLeden, resources.GetString("clbLeden.ToolTip"));
            // 
            // htmlTextbox1
            // 
            this.htmlTextbox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlTextbox1.Fonts = new string[] {
        "Verdana",
        "Arial",
        "Courier New"};
            this.htmlTextbox1.IllegalPatterns = new string[] {
        "<script.*?>",
        "<\\w+\\s+.*?(j|java|vb|ecma)script:.*?>",
        "<\\w+(\\s+|\\s+.*?\\s+)on\\w+\\s*=.+?>",
        "</?input.*?>"};
            this.htmlTextbox1.Location = new System.Drawing.Point(0, 0);
            this.htmlTextbox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.htmlTextbox1.Name = "htmlTextbox1";
            this.htmlTextbox1.Padding = new System.Windows.Forms.Padding(1);
            this.htmlTextbox1.ShowHtmlSource = false;
            this.htmlTextbox1.Size = new System.Drawing.Size(897, 399);
            this.htmlTextbox1.TabIndex = 16;
            this.toolTip1.SetToolTip(this.htmlTextbox1, resources.GetString("htmlTextbox1.ToolTip"));
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(357, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 59);
            this.panel1.TabIndex = 20;
            this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // cmdPaste
            // 
            this.cmdPaste.Location = new System.Drawing.Point(731, 17);
            this.cmdPaste.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdPaste.Name = "cmdPaste";
            this.cmdPaste.Size = new System.Drawing.Size(100, 28);
            this.cmdPaste.TabIndex = 18;
            this.cmdPaste.Text = "Paste";
            this.toolTip1.SetToolTip(this.cmdPaste, "Past text (from msWord) without formatting.");
            this.cmdPaste.UseVisualStyleBackColor = true;
            this.cmdPaste.Click += new System.EventHandler(this.cmdPaste_Click);
            // 
            // lblAddtoList
            // 
            this.lblAddtoList.AutoSize = true;
            this.lblAddtoList.Location = new System.Drawing.Point(391, 126);
            this.lblAddtoList.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddtoList.Name = "lblAddtoList";
            this.lblAddtoList.Size = new System.Drawing.Size(74, 17);
            this.lblAddtoList.TabIndex = 3;
            this.lblAddtoList.Text = "Add to list:";
            this.toolTip1.SetToolTip(this.lblAddtoList, "Enter to add email address to list");
            // 
            // lblExtraEmail
            // 
            this.lblExtraEmail.AutoSize = true;
            this.lblExtraEmail.Location = new System.Drawing.Point(23, 126);
            this.lblExtraEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExtraEmail.Name = "lblExtraEmail";
            this.lblExtraEmail.Size = new System.Drawing.Size(82, 17);
            this.lblExtraEmail.TabIndex = 3;
            this.lblExtraEmail.Text = "Extra Email:";
            this.toolTip1.SetToolTip(this.lblExtraEmail, "Delete-key deletes all non-selected items");
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(731, 475);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(100, 28);
            this.cmdExit.TabIndex = 16;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.clbLeden);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 0);
            this.pnlFill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(456, 923);
            this.pnlFill.TabIndex = 0;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.htmlTextbox1);
            this.pnlRight.Controls.Add(this.pnlBottum);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(456, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(897, 923);
            this.pnlRight.TabIndex = 0;
            // 
            // pnlBottum
            // 
            this.pnlBottum.Controls.Add(this.groupBox1);
            this.pnlBottum.Controls.Add(this.cmdToelichting);
            this.pnlBottum.Controls.Add(this.panel1);
            this.pnlBottum.Controls.Add(this.clbExtraEmail);
            this.pnlBottum.Controls.Add(this.cmdPaste);
            this.pnlBottum.Controls.Add(this.ckbHtml);
            this.pnlBottum.Controls.Add(this.cmdGetMail);
            this.pnlBottum.Controls.Add(this.cmdExit);
            this.pnlBottum.Controls.Add(this.lblAddtoList);
            this.pnlBottum.Controls.Add(this.lblExtraEmail);
            this.pnlBottum.Controls.Add(this.label1);
            this.pnlBottum.Controls.Add(this.txtExtraEmail);
            this.pnlBottum.Controls.Add(this.txtSubject);
            this.pnlBottum.Controls.Add(this.cmdSaveMail);
            this.pnlBottum.Controls.Add(this.txtBijlage3);
            this.pnlBottum.Controls.Add(this.cmdVerstuurMail);
            this.pnlBottum.Controls.Add(this.lblBijlage3);
            this.pnlBottum.Controls.Add(this.lblBijlage1);
            this.pnlBottum.Controls.Add(this.txtBijlage2);
            this.pnlBottum.Controls.Add(this.txtBijlage1);
            this.pnlBottum.Controls.Add(this.lblBijlage2);
            this.pnlBottum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottum.Location = new System.Drawing.Point(0, 399);
            this.pnlBottum.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBottum.Name = "pnlBottum";
            this.pnlBottum.Size = new System.Drawing.Size(897, 524);
            this.pnlBottum.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdShowLogfileMail);
            this.groupBox1.Controls.Add(this.ckbDoNotSendEmail);
            this.groupBox1.Controls.Add(this.chkLogEmail);
            this.groupBox1.Location = new System.Drawing.Point(27, 404);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(329, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cmdShowLogfileMail
            // 
            this.cmdShowLogfileMail.Location = new System.Drawing.Point(225, 27);
            this.cmdShowLogfileMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdShowLogfileMail.Name = "cmdShowLogfileMail";
            this.cmdShowLogfileMail.Size = new System.Drawing.Size(96, 46);
            this.cmdShowLogfileMail.TabIndex = 478;
            this.cmdShowLogfileMail.Text = "Show logfile Mail";
            this.cmdShowLogfileMail.UseVisualStyleBackColor = true;
            this.cmdShowLogfileMail.Click += new System.EventHandler(this.cmdShowLogfileMail_Click);
            // 
            // ckbDoNotSendEmail
            // 
            this.ckbDoNotSendEmail.AutoSize = true;
            this.ckbDoNotSendEmail.Location = new System.Drawing.Point(20, 48);
            this.ckbDoNotSendEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.chkLogEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkLogEmail.Name = "chkLogEmail";
            this.chkLogEmail.Size = new System.Drawing.Size(180, 21);
            this.chkLogEmail.TabIndex = 8;
            this.chkLogEmail.Text = "Schrijf alle mail in logfile";
            this.chkLogEmail.UseVisualStyleBackColor = true;
            // 
            // cmdToelichting
            // 
            this.cmdToelichting.Location = new System.Drawing.Point(731, 439);
            this.cmdToelichting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdToelichting.Name = "cmdToelichting";
            this.cmdToelichting.Size = new System.Drawing.Size(100, 28);
            this.cmdToelichting.TabIndex = 476;
            this.cmdToelichting.Text = "Toelichting";
            this.cmdToelichting.UseVisualStyleBackColor = true;
            this.cmdToelichting.Click += new System.EventHandler(this.cmdToelichting_Click);
            // 
            // clbExtraEmail
            // 
            this.clbExtraEmail.CheckOnClick = true;
            this.clbExtraEmail.FormattingEnabled = true;
            this.clbExtraEmail.Location = new System.Drawing.Point(113, 122);
            this.clbExtraEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clbExtraEmail.Name = "clbExtraEmail";
            this.clbExtraEmail.Size = new System.Drawing.Size(251, 123);
            this.clbExtraEmail.TabIndex = 19;
            // 
            // ckbHtml
            // 
            this.ckbHtml.AutoSize = true;
            this.ckbHtml.Location = new System.Drawing.Point(640, 22);
            this.ckbHtml.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckbHtml.Name = "ckbHtml";
            this.ckbHtml.Size = new System.Drawing.Size(58, 21);
            this.ckbHtml.TabIndex = 17;
            this.ckbHtml.Text = "Html";
            this.ckbHtml.UseVisualStyleBackColor = true;
            // 
            // cmdGetMail
            // 
            this.cmdGetMail.Location = new System.Drawing.Point(27, 17);
            this.cmdGetMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdGetMail.Name = "cmdGetMail";
            this.cmdGetMail.Size = new System.Drawing.Size(144, 28);
            this.cmdGetMail.TabIndex = 1;
            this.cmdGetMail.Text = "Open Mail bericht";
            this.cmdGetMail.UseVisualStyleBackColor = true;
            this.cmdGetMail.Click += new System.EventHandler(this.cmdGetMail_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Onderwerp:";
            // 
            // txtExtraEmail
            // 
            this.txtExtraEmail.Location = new System.Drawing.Point(481, 122);
            this.txtExtraEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExtraEmail.Name = "txtExtraEmail";
            this.txtExtraEmail.Size = new System.Drawing.Size(220, 22);
            this.txtExtraEmail.TabIndex = 5;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(113, 82);
            this.txtSubject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(588, 22);
            this.txtSubject.TabIndex = 3;
            // 
            // cmdSaveMail
            // 
            this.cmdSaveMail.Location = new System.Drawing.Point(205, 17);
            this.cmdSaveMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdSaveMail.Name = "cmdSaveMail";
            this.cmdSaveMail.Size = new System.Drawing.Size(144, 28);
            this.cmdSaveMail.TabIndex = 2;
            this.cmdSaveMail.Text = "Save Mail bericht";
            this.cmdSaveMail.UseVisualStyleBackColor = true;
            this.cmdSaveMail.Click += new System.EventHandler(this.cmdSaveMail_Click);
            // 
            // txtBijlage3
            // 
            this.txtBijlage3.Location = new System.Drawing.Point(113, 361);
            this.txtBijlage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBijlage3.Name = "txtBijlage3";
            this.txtBijlage3.Size = new System.Drawing.Size(588, 22);
            this.txtBijlage3.TabIndex = 14;
            // 
            // cmdVerstuurMail
            // 
            this.cmdVerstuurMail.Location = new System.Drawing.Point(712, 404);
            this.cmdVerstuurMail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmdVerstuurMail.Name = "cmdVerstuurMail";
            this.cmdVerstuurMail.Size = new System.Drawing.Size(128, 28);
            this.cmdVerstuurMail.TabIndex = 15;
            this.cmdVerstuurMail.Text = "Verstuur mail";
            this.cmdVerstuurMail.UseVisualStyleBackColor = true;
            this.cmdVerstuurMail.Click += new System.EventHandler(this.cmdVerstuurMail_Click);
            // 
            // lblBijlage3
            // 
            this.lblBijlage3.AutoSize = true;
            this.lblBijlage3.Location = new System.Drawing.Point(23, 364);
            this.lblBijlage3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBijlage3.Name = "lblBijlage3";
            this.lblBijlage3.Size = new System.Drawing.Size(78, 17);
            this.lblBijlage3.TabIndex = 13;
            this.lblBijlage3.Text = "Bijlage 3 ...";
            this.lblBijlage3.Click += new System.EventHandler(this.lblBijlage3_Click);
            // 
            // lblBijlage1
            // 
            this.lblBijlage1.AutoSize = true;
            this.lblBijlage1.Location = new System.Drawing.Point(23, 281);
            this.lblBijlage1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBijlage1.Name = "lblBijlage1";
            this.lblBijlage1.Size = new System.Drawing.Size(78, 17);
            this.lblBijlage1.TabIndex = 9;
            this.lblBijlage1.Text = "Bijlage 1 ...";
            this.lblBijlage1.Click += new System.EventHandler(this.lblBijlage1_Click);
            // 
            // txtBijlage2
            // 
            this.txtBijlage2.Location = new System.Drawing.Point(113, 318);
            this.txtBijlage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBijlage2.Name = "txtBijlage2";
            this.txtBijlage2.Size = new System.Drawing.Size(588, 22);
            this.txtBijlage2.TabIndex = 12;
            // 
            // txtBijlage1
            // 
            this.txtBijlage1.Location = new System.Drawing.Point(113, 277);
            this.txtBijlage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBijlage1.Name = "txtBijlage1";
            this.txtBijlage1.Size = new System.Drawing.Size(588, 22);
            this.txtBijlage1.TabIndex = 10;
            // 
            // lblBijlage2
            // 
            this.lblBijlage2.AutoSize = true;
            this.lblBijlage2.Location = new System.Drawing.Point(23, 321);
            this.lblBijlage2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBijlage2.Name = "lblBijlage2";
            this.lblBijlage2.Size = new System.Drawing.Size(78, 17);
            this.lblBijlage2.TabIndex = 11;
            this.lblBijlage2.Text = "Bijlage 2 ...";
            this.lblBijlage2.Click += new System.EventHandler(this.lblBijlage2_Click);
            // 
            // frmMultiMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(1353, 923);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlRight);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMultiMail";
            this.ShowInTaskbar = false;
            this.Text = "Mail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMultiMail_FormClosing);
            this.pnlFill.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlBottum.ResumeLayout(false);
            this.pnlBottum.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbLeden;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Button cmdGetMail;
        private System.Windows.Forms.Button cmdSaveMail;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button cmdVerstuurMail;
        private System.Windows.Forms.TextBox txtBijlage1;
        private System.Windows.Forms.Label lblBijlage1;
        private System.Windows.Forms.TextBox txtBijlage2;
        private System.Windows.Forms.Label lblBijlage2;
        private System.Windows.Forms.TextBox txtBijlage3;
        private System.Windows.Forms.Label lblBijlage3;
        private Util.Forms.HtmlTextbox htmlTextbox1;
        private System.Windows.Forms.Panel pnlBottum;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Label lblExtraEmail;
        private System.Windows.Forms.TextBox txtExtraEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox ckbHtml;
        private System.Windows.Forms.Button cmdPaste;
        private System.Windows.Forms.CheckedListBox clbExtraEmail;
        private System.Windows.Forms.Label lblAddtoList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdToelichting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckbDoNotSendEmail;
        private System.Windows.Forms.CheckBox chkLogEmail;
        private System.Windows.Forms.Button cmdShowLogfileMail;
    }
}