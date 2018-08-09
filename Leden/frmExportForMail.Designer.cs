namespace Leden.Net
{
    partial class frmExportForMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportForMail));
            this.lblLocatieOutput = new System.Windows.Forms.Label();
            this.txtOutputMailLocation = new System.Windows.Forms.TextBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblLijst = new System.Windows.Forms.Label();
            this.clbExtraEmail = new System.Windows.Forms.CheckedListBox();
            this.lblAddtoList = new System.Windows.Forms.Label();
            this.lblExtraEmail = new System.Windows.Forms.Label();
            this.txtExtraEmail = new System.Windows.Forms.TextBox();
            this.cmdVerstuurMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLocatieOutput
            // 
            this.lblLocatieOutput.AutoSize = true;
            this.lblLocatieOutput.Location = new System.Drawing.Point(50, 33);
            this.lblLocatieOutput.Name = "lblLocatieOutput";
            this.lblLocatieOutput.Size = new System.Drawing.Size(87, 13);
            this.lblLocatieOutput.TabIndex = 6;
            this.lblLocatieOutput.Text = "Locatie output ...";
            this.lblLocatieOutput.Click += new System.EventHandler(this.lblLocatieOutput_Click);
            // 
            // txtOutputMailLocation
            // 
            this.txtOutputMailLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputMailLocation.Location = new System.Drawing.Point(152, 30);
            this.txtOutputMailLocation.Name = "txtOutputMailLocation";
            this.txtOutputMailLocation.Size = new System.Drawing.Size(396, 20);
            this.txtOutputMailLocation.TabIndex = 5;
            this.txtOutputMailLocation.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(467, 238);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(81, 23);
            this.cmdExit.TabIndex = 7;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdExport
            // 
            this.cmdExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExport.Location = new System.Drawing.Point(467, 77);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(81, 23);
            this.cmdExport.TabIndex = 8;
            this.cmdExport.Text = "Maak Output";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExportCSV_Click);
            // 
            // lblLijst
            // 
            this.lblLijst.AutoSize = true;
            this.lblLijst.Location = new System.Drawing.Point(50, 299);
            this.lblLijst.Name = "lblLijst";
            this.lblLijst.Size = new System.Drawing.Size(0, 13);
            this.lblLijst.TabIndex = 12;
            // 
            // clbExtraEmail
            // 
            this.clbExtraEmail.CheckOnClick = true;
            this.clbExtraEmail.FormattingEnabled = true;
            this.clbExtraEmail.Location = new System.Drawing.Point(152, 117);
            this.clbExtraEmail.Name = "clbExtraEmail";
            this.clbExtraEmail.Size = new System.Drawing.Size(189, 109);
            this.clbExtraEmail.TabIndex = 23;
            // 
            // lblAddtoList
            // 
            this.lblAddtoList.AutoSize = true;
            this.lblAddtoList.Location = new System.Drawing.Point(50, 244);
            this.lblAddtoList.Name = "lblAddtoList";
            this.lblAddtoList.Size = new System.Drawing.Size(56, 13);
            this.lblAddtoList.TabIndex = 20;
            this.lblAddtoList.Text = "Add to list:";
            // 
            // lblExtraEmail
            // 
            this.lblExtraEmail.AutoSize = true;
            this.lblExtraEmail.Location = new System.Drawing.Point(50, 117);
            this.lblExtraEmail.Name = "lblExtraEmail";
            this.lblExtraEmail.Size = new System.Drawing.Size(62, 13);
            this.lblExtraEmail.TabIndex = 21;
            this.lblExtraEmail.Text = "Extra Email:";
            // 
            // txtExtraEmail
            // 
            this.txtExtraEmail.Location = new System.Drawing.Point(152, 241);
            this.txtExtraEmail.Name = "txtExtraEmail";
            this.txtExtraEmail.Size = new System.Drawing.Size(189, 20);
            this.txtExtraEmail.TabIndex = 22;
            // 
            // cmdVerstuurMail
            // 
            this.cmdVerstuurMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdVerstuurMail.Location = new System.Drawing.Point(467, 148);
            this.cmdVerstuurMail.Name = "cmdVerstuurMail";
            this.cmdVerstuurMail.Size = new System.Drawing.Size(81, 23);
            this.cmdVerstuurMail.TabIndex = 24;
            this.cmdVerstuurMail.Text = "Verstuur Mail";
            this.cmdVerstuurMail.UseVisualStyleBackColor = true;
            this.cmdVerstuurMail.Click += new System.EventHandler(this.cmdVerstuurMail_Click);
            // 
            // frmExportForMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(577, 301);
            this.Controls.Add(this.cmdVerstuurMail);
            this.Controls.Add(this.clbExtraEmail);
            this.Controls.Add(this.lblAddtoList);
            this.Controls.Add(this.lblExtraEmail);
            this.Controls.Add(this.txtExtraEmail);
            this.Controls.Add(this.lblLijst);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblLocatieOutput);
            this.Controls.Add(this.txtOutputMailLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmExportForMail";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Export Lijsten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportLijsten_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocatieOutput;
        private System.Windows.Forms.TextBox txtOutputMailLocation;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblLijst;
        private System.Windows.Forms.CheckedListBox clbExtraEmail;
        private System.Windows.Forms.Label lblAddtoList;
        private System.Windows.Forms.Label lblExtraEmail;
        private System.Windows.Forms.TextBox txtExtraEmail;
        private System.Windows.Forms.Button cmdVerstuurMail;
    }
}