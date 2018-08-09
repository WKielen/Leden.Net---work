namespace Leden.Net
{
    partial class frmCompareNAS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompareNAS));
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgView = new System.Windows.Forms.DataGridView();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtNASteamindeling = new System.Windows.Forms.TextBox();
            this.lblTeamIndeling = new System.Windows.Forms.Label();
            this.lblImportFile = new System.Windows.Forms.Label();
            this.txtNASLeden = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(767, 13);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 0;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgView);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(0, 202);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(561, 186);
            this.pnlGrid.TabIndex = 8;
            // 
            // dgView
            // 
            this.dgView.AllowUserToAddRows = false;
            this.dgView.AllowUserToDeleteRows = false;
            this.dgView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            this.dgView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgView.Location = new System.Drawing.Point(0, 0);
            this.dgView.Name = "dgView";
            this.dgView.RowHeadersVisible = false;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgView.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgView.Size = new System.Drawing.Size(561, 186);
            this.dgView.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtNASteamindeling);
            this.pnlTop.Controls.Add(this.lblTeamIndeling);
            this.pnlTop.Controls.Add(this.lblImportFile);
            this.pnlTop.Controls.Add(this.txtNASLeden);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(869, 202);
            this.pnlTop.TabIndex = 9;
            // 
            // txtNASteamindeling
            // 
            this.txtNASteamindeling.AllowDrop = true;
            this.txtNASteamindeling.Location = new System.Drawing.Point(20, 37);
            this.txtNASteamindeling.Multiline = true;
            this.txtNASteamindeling.Name = "txtNASteamindeling";
            this.txtNASteamindeling.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNASteamindeling.Size = new System.Drawing.Size(384, 154);
            this.txtNASteamindeling.TabIndex = 6;
            this.txtNASteamindeling.Text = "Copy de teamindeling vanuit  NAS door \r\nteamindeling te selecteren en met ctrl-C\r" +
    "\nte kopieeren. Dan in deze box met ctrl-V\r\nplakken. ";
            // 
            // lblTeamIndeling
            // 
            this.lblTeamIndeling.AutoSize = true;
            this.lblTeamIndeling.Location = new System.Drawing.Point(17, 12);
            this.lblTeamIndeling.Name = "lblTeamIndeling";
            this.lblTeamIndeling.Size = new System.Drawing.Size(128, 13);
            this.lblTeamIndeling.TabIndex = 4;
            this.lblTeamIndeling.Text = "TeamIndeling vanuit NAS";
            // 
            // lblImportFile
            // 
            this.lblImportFile.AutoSize = true;
            this.lblImportFile.Location = new System.Drawing.Point(436, 12);
            this.lblImportFile.Name = "lblImportFile";
            this.lblImportFile.Size = new System.Drawing.Size(108, 13);
            this.lblImportFile.TabIndex = 2;
            this.lblImportFile.Text = "Ledenlijst vanuit NAS";
            // 
            // txtNASLeden
            // 
            this.txtNASLeden.AllowDrop = true;
            this.txtNASLeden.Location = new System.Drawing.Point(439, 37);
            this.txtNASLeden.Multiline = true;
            this.txtNASLeden.Name = "txtNASLeden";
            this.txtNASLeden.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNASLeden.Size = new System.Drawing.Size(384, 154);
            this.txtNASLeden.TabIndex = 7;
            this.txtNASLeden.Text = resources.GetString("txtNASLeden.Text");
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.statusStrip1);
            this.pnlBottom.Controls.Add(this.cmdSave);
            this.pnlBottom.Controls.Add(this.cmdExit);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 388);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(869, 71);
            this.pnlBottom.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 49);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(869, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(670, 13);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmCompareNAS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(869, 459);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompareNAS";
            this.ShowInTaskbar = false;
            this.Text = "Vergelijk administratie met NAS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCompareNAS_FormClosing);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblImportFile;
        private System.Windows.Forms.Label lblTeamIndeling;
        private System.Windows.Forms.TextBox txtNASteamindeling;
        private System.Windows.Forms.TextBox txtNASLeden;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}