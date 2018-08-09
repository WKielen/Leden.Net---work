namespace Leden.Net
{
    partial class frmCompResult2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompResult2));
            this.cboSeizoen = new System.Windows.Forms.ComboBox();
            this.cboJaar = new System.Windows.Forms.ComboBox();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.ckbInclSen = new System.Windows.Forms.CheckBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdTTKaart = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSeizoen
            // 
            this.cboSeizoen.FormattingEnabled = true;
            this.cboSeizoen.Location = new System.Drawing.Point(487, 12);
            this.cboSeizoen.Name = "cboSeizoen";
            this.cboSeizoen.Size = new System.Drawing.Size(86, 21);
            this.cboSeizoen.TabIndex = 15;
            this.cboSeizoen.TabStop = false;
            this.cboSeizoen.SelectedIndexChanged += new System.EventHandler(this.cboSeizoen_SelectedIndexChanged);
            // 
            // cboJaar
            // 
            this.cboJaar.FormattingEnabled = true;
            this.cboJaar.Location = new System.Drawing.Point(487, 50);
            this.cboJaar.Name = "cboJaar";
            this.cboJaar.Size = new System.Drawing.Size(66, 21);
            this.cboJaar.TabIndex = 14;
            this.cboJaar.TabStop = false;
            this.cboJaar.SelectedIndexChanged += new System.EventHandler(this.cboJaar_SelectedIndexChanged);
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToOrderColumns = true;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.RowHeadersVisible = false;
            this.dgView.Size = new System.Drawing.Size(454, 324);
            this.dgView.TabIndex = 25;
            this.dgView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_RowEnter);
            // 
            // ckbInclSen
            // 
            this.ckbInclSen.AutoSize = true;
            this.ckbInclSen.Location = new System.Drawing.Point(487, 89);
            this.ckbInclSen.Name = "ckbInclSen";
            this.ckbInclSen.Size = new System.Drawing.Size(68, 17);
            this.ckbInclSen.TabIndex = 26;
            this.ckbInclSen.Text = "Incl. Sen";
            this.ckbInclSen.UseVisualStyleBackColor = true;
            this.ckbInclSen.CheckedChanged += new System.EventHandler(this.ckbInclSen_CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdSave.Location = new System.Drawing.Point(651, 244);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 28;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(651, 285);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 27;
            this.cmdExit.TabStop = false;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdTTKaart
            // 
            this.cmdTTKaart.Image = ((System.Drawing.Image)(resources.GetObject("cmdTTKaart.Image")));
            this.cmdTTKaart.Location = new System.Drawing.Point(641, 12);
            this.cmdTTKaart.Name = "cmdTTKaart";
            this.cmdTTKaart.Size = new System.Drawing.Size(85, 120);
            this.cmdTTKaart.TabIndex = 29;
            this.toolTip1.SetToolTip(this.cmdTTKaart, resources.GetString("cmdTTKaart.ToolTip"));
            this.cmdTTKaart.UseVisualStyleBackColor = true;
            this.cmdTTKaart.Click += new System.EventHandler(this.cmdTTKaart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(651, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 447;
            this.button1.Text = "TT-Kaart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 324);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(759, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 448;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmCompResult2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 346);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdTTKaart);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.dgView);
            this.Controls.Add(this.ckbInclSen);
            this.Controls.Add(this.cboSeizoen);
            this.Controls.Add(this.cboJaar);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompResult2";
            this.ShowInTaskbar = false;
            this.Text = "Competitie Resultaten Jeugd";
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSeizoen;
        private System.Windows.Forms.ComboBox cboJaar;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.CheckBox ckbInclSen;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdTTKaart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}