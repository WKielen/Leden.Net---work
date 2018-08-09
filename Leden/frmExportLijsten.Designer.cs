namespace Leden.Net
{
    partial class frmExportLijsten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportLijsten));
            this.lblLocatieOutput = new System.Windows.Forms.Label();
            this.txtOutputLocation = new System.Windows.Forms.TextBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdExportCSV = new System.Windows.Forms.Button();
            this.grpEmailLedenLijsten = new System.Windows.Forms.GroupBox();
            this.cmdMail = new System.Windows.Forms.Button();
            this.txtEmailJeugd = new System.Windows.Forms.TextBox();
            this.txtEmailLeden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOnlyMarked = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdCreateMailOutput = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdUploadLijstenWebsite = new System.Windows.Forms.Button();
            this.grpEmailLedenLijsten.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLocatieOutput
            // 
            this.lblLocatieOutput.AutoSize = true;
            this.lblLocatieOutput.Location = new System.Drawing.Point(31, 41);
            this.lblLocatieOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocatieOutput.Name = "lblLocatieOutput";
            this.lblLocatieOutput.Size = new System.Drawing.Size(114, 17);
            this.lblLocatieOutput.TabIndex = 6;
            this.lblLocatieOutput.Text = "Locatie output ...";
            this.lblLocatieOutput.Click += new System.EventHandler(this.lblLocatieOutput_Click);
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputLocation.Location = new System.Drawing.Point(171, 37);
            this.txtOutputLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.Size = new System.Drawing.Size(595, 22);
            this.txtOutputLocation.TabIndex = 5;
            this.txtOutputLocation.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(765, 362);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(108, 28);
            this.cmdExit.TabIndex = 7;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdExportCSV
            // 
            this.cmdExportCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExportCSV.Location = new System.Drawing.Point(765, 84);
            this.cmdExportCSV.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExportCSV.Name = "cmdExportCSV";
            this.cmdExportCSV.Size = new System.Drawing.Size(108, 28);
            this.cmdExportCSV.TabIndex = 8;
            this.cmdExportCSV.Text = "Maak Lijsten";
            this.cmdExportCSV.UseVisualStyleBackColor = true;
            this.cmdExportCSV.Click += new System.EventHandler(this.cmdExportCSV_Click);
            // 
            // grpEmailLedenLijsten
            // 
            this.grpEmailLedenLijsten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmailLedenLijsten.Controls.Add(this.cmdMail);
            this.grpEmailLedenLijsten.Controls.Add(this.txtEmailJeugd);
            this.grpEmailLedenLijsten.Controls.Add(this.txtEmailLeden);
            this.grpEmailLedenLijsten.Controls.Add(this.label3);
            this.grpEmailLedenLijsten.Controls.Add(this.label1);
            this.grpEmailLedenLijsten.Location = new System.Drawing.Point(35, 119);
            this.grpEmailLedenLijsten.Margin = new System.Windows.Forms.Padding(4);
            this.grpEmailLedenLijsten.Name = "grpEmailLedenLijsten";
            this.grpEmailLedenLijsten.Padding = new System.Windows.Forms.Padding(4);
            this.grpEmailLedenLijsten.Size = new System.Drawing.Size(865, 209);
            this.grpEmailLedenLijsten.TabIndex = 9;
            this.grpEmailLedenLijsten.TabStop = false;
            this.grpEmailLedenLijsten.Text = "E-mail  LedenLijsten";
            // 
            // cmdMail
            // 
            this.cmdMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdMail.Enabled = false;
            this.cmdMail.Location = new System.Drawing.Point(731, 162);
            this.cmdMail.Margin = new System.Windows.Forms.Padding(4);
            this.cmdMail.Name = "cmdMail";
            this.cmdMail.Size = new System.Drawing.Size(108, 28);
            this.cmdMail.TabIndex = 2;
            this.cmdMail.Text = "Mail Lijsten";
            this.cmdMail.UseVisualStyleBackColor = true;
            this.cmdMail.Click += new System.EventHandler(this.cmdMail_Click);
            // 
            // txtEmailJeugd
            // 
            this.txtEmailJeugd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailJeugd.Location = new System.Drawing.Point(243, 74);
            this.txtEmailJeugd.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailJeugd.Name = "txtEmailJeugd";
            this.txtEmailJeugd.Size = new System.Drawing.Size(593, 22);
            this.txtEmailJeugd.TabIndex = 1;
            // 
            // txtEmailLeden
            // 
            this.txtEmailLeden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailLeden.Location = new System.Drawing.Point(243, 37);
            this.txtEmailLeden.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailLeden.Name = "txtEmailLeden";
            this.txtEmailLeden.Size = new System.Drawing.Size(593, 22);
            this.txtEmailLeden.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "E-mail Adressen Jeugdlijsten";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-mail Adressen Ledenlijsten";
            // 
            // chkOnlyMarked
            // 
            this.chkOnlyMarked.AutoSize = true;
            this.chkOnlyMarked.Location = new System.Drawing.Point(171, 73);
            this.chkOnlyMarked.Margin = new System.Windows.Forms.Padding(4);
            this.chkOnlyMarked.Name = "chkOnlyMarked";
            this.chkOnlyMarked.Size = new System.Drawing.Size(171, 21);
            this.chkOnlyMarked.TabIndex = 11;
            this.chkOnlyMarked.Text = "Alleen gemerkte leden";
            this.chkOnlyMarked.UseVisualStyleBackColor = true;
            // 
            // cmdCreateMailOutput
            // 
            this.cmdCreateMailOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCreateMailOutput.Location = new System.Drawing.Point(35, 362);
            this.cmdCreateMailOutput.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCreateMailOutput.Name = "cmdCreateMailOutput";
            this.cmdCreateMailOutput.Size = new System.Drawing.Size(247, 28);
            this.cmdCreateMailOutput.TabIndex = 13;
            this.cmdCreateMailOutput.Text = "Aanmaak output for Mail programma";
            this.cmdCreateMailOutput.UseVisualStyleBackColor = true;
            this.cmdCreateMailOutput.Click += new System.EventHandler(this.cmdCreateMailOutput_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 408);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(949, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdUploadLijstenWebsite
            // 
            this.cmdUploadLijstenWebsite.Enabled = false;
            this.cmdUploadLijstenWebsite.Location = new System.Drawing.Point(346, 362);
            this.cmdUploadLijstenWebsite.Name = "cmdUploadLijstenWebsite";
            this.cmdUploadLijstenWebsite.Size = new System.Drawing.Size(244, 28);
            this.cmdUploadLijstenWebsite.TabIndex = 15;
            this.cmdUploadLijstenWebsite.Text = "Upload Ledenlijsten naar website";
            this.cmdUploadLijstenWebsite.UseVisualStyleBackColor = true;
            this.cmdUploadLijstenWebsite.Click += new System.EventHandler(this.cmdUploadLijstenWebsite_Click);
            // 
            // frmExportLijsten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(949, 430);
            this.Controls.Add(this.cmdUploadLijstenWebsite);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdCreateMailOutput);
            this.Controls.Add(this.chkOnlyMarked);
            this.Controls.Add(this.grpEmailLedenLijsten);
            this.Controls.Add(this.cmdExportCSV);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lblLocatieOutput);
            this.Controls.Add(this.txtOutputLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExportLijsten";
            this.ShowInTaskbar = false;
            this.Text = "Export Lijsten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExportLijsten_FormClosing);
            this.grpEmailLedenLijsten.ResumeLayout(false);
            this.grpEmailLedenLijsten.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLocatieOutput;
        private System.Windows.Forms.TextBox txtOutputLocation;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdExportCSV;
        private System.Windows.Forms.TextBox txtEmailJeugd;
        private System.Windows.Forms.TextBox txtEmailLeden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdMail;
        private System.Windows.Forms.CheckBox chkOnlyMarked;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.GroupBox grpEmailLedenLijsten;
        public System.Windows.Forms.Button cmdCreateMailOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button cmdUploadLijstenWebsite;
    }
}