namespace Leden.Net
{
    partial class frmBetalingenBestand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBetalingenBestand));
            this.fdiBrowseTemplate = new System.Windows.Forms.FolderBrowserDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPrintVerslagB = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLocatieOutput = new System.Windows.Forms.Label();
            this.cmdMaakbestand = new System.Windows.Forms.Button();
            this.txtOutputLocationIncB = new System.Windows.Forms.TextBox();
            this.txtMsgIDB = new System.Windows.Forms.TextBox();
            this.txtFilePrefixB = new System.Windows.Forms.TextBox();
            this.txtFileSeqnrB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(695, 193);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 8;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPrintVerslagB);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.lblLocatieOutput);
            this.groupBox1.Controls.Add(this.cmdMaakbestand);
            this.groupBox1.Controls.Add(this.txtOutputLocationIncB);
            this.groupBox1.Controls.Add(this.txtMsgIDB);
            this.groupBox1.Controls.Add(this.txtFilePrefixB);
            this.groupBox1.Controls.Add(this.txtFileSeqnrB);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(32, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incassobestand";
            // 
            // chkPrintVerslagB
            // 
            this.chkPrintVerslagB.AutoSize = true;
            this.chkPrintVerslagB.Location = new System.Drawing.Point(506, 23);
            this.chkPrintVerslagB.Name = "chkPrintVerslagB";
            this.chkPrintVerslagB.Size = new System.Drawing.Size(85, 17);
            this.chkPrintVerslagB.TabIndex = 9;
            this.chkPrintVerslagB.Text = "Print Verslag";
            this.chkPrintVerslagB.UseVisualStyleBackColor = true;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(14, 27);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(35, 13);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.Text = "label8";
            // 
            // lblLocatieOutput
            // 
            this.lblLocatieOutput.AutoSize = true;
            this.lblLocatieOutput.Location = new System.Drawing.Point(14, 51);
            this.lblLocatieOutput.Name = "lblLocatieOutput";
            this.lblLocatieOutput.Size = new System.Drawing.Size(87, 13);
            this.lblLocatieOutput.TabIndex = 4;
            this.lblLocatieOutput.Text = "Locatie output ...";
            this.lblLocatieOutput.Click += new System.EventHandler(this.lblLocatieOutput_Click);
            // 
            // cmdMaakbestand
            // 
            this.cmdMaakbestand.Location = new System.Drawing.Point(506, 99);
            this.cmdMaakbestand.Name = "cmdMaakbestand";
            this.cmdMaakbestand.Size = new System.Drawing.Size(85, 23);
            this.cmdMaakbestand.TabIndex = 0;
            this.cmdMaakbestand.Text = "Maak bestand";
            this.cmdMaakbestand.UseVisualStyleBackColor = true;
            this.cmdMaakbestand.Click += new System.EventHandler(this.cmdMaakbestand_Click);
            // 
            // txtOutputLocationIncB
            // 
            this.txtOutputLocationIncB.Location = new System.Drawing.Point(166, 48);
            this.txtOutputLocationIncB.Name = "txtOutputLocationIncB";
            this.txtOutputLocationIncB.Size = new System.Drawing.Size(415, 20);
            this.txtOutputLocationIncB.TabIndex = 3;
            this.txtOutputLocationIncB.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // txtMsgIDB
            // 
            this.txtMsgIDB.Location = new System.Drawing.Point(166, 76);
            this.txtMsgIDB.Name = "txtMsgIDB";
            this.txtMsgIDB.Size = new System.Drawing.Size(166, 20);
            this.txtMsgIDB.TabIndex = 2;
            this.txtMsgIDB.Text = "TTVN incasso";
            // 
            // txtFilePrefixB
            // 
            this.txtFilePrefixB.Location = new System.Drawing.Point(166, 106);
            this.txtFilePrefixB.Name = "txtFilePrefixB";
            this.txtFilePrefixB.Size = new System.Drawing.Size(166, 20);
            this.txtFilePrefixB.TabIndex = 2;
            this.txtFilePrefixB.Text = "PAIN";
            // 
            // txtFileSeqnrB
            // 
            this.txtFileSeqnrB.Location = new System.Drawing.Point(166, 134);
            this.txtFileSeqnrB.Name = "txtFileSeqnrB";
            this.txtFileSeqnrB.Size = new System.Drawing.Size(53, 20);
            this.txtFileSeqnrB.TabIndex = 2;
            this.txtFileSeqnrB.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bestand MsgID";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Bestand Seqnr";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Bestand Prefix";
            // 
            // frmBetalingenBestand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(782, 230);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBetalingenBestand";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Rekening Bestand maken";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRekeningVersturen_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdMaakbestand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog fdiBrowseTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMsgIDB;
        private System.Windows.Forms.Label lblLocatieOutput;
        private System.Windows.Forms.TextBox txtOutputLocationIncB;
        private System.Windows.Forms.TextBox txtFilePrefixB;
        private System.Windows.Forms.TextBox txtFileSeqnrB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button cmdExit;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox chkPrintVerslagB;
    }
}