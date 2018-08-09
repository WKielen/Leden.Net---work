namespace Leden.Net
{
    partial class frmLedenOverzicht1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLedenOverzicht1));
            this.rbuJunioren = new System.Windows.Forms.RadioButton();
            this.rbuSenioren = new System.Windows.Forms.RadioButton();
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.olvVrijwilligers = new BrightIdeasSoftware.FastObjectListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.rbuGemerkt = new System.Windows.Forms.RadioButton();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvVrijwilligers)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbuJunioren
            // 
            this.rbuJunioren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbuJunioren.AutoSize = true;
            this.rbuJunioren.Location = new System.Drawing.Point(1062, 53);
            this.rbuJunioren.Margin = new System.Windows.Forms.Padding(4);
            this.rbuJunioren.Name = "rbuJunioren";
            this.rbuJunioren.Size = new System.Drawing.Size(84, 21);
            this.rbuJunioren.TabIndex = 26;
            this.rbuJunioren.Text = "Junioren";
            this.rbuJunioren.UseVisualStyleBackColor = true;
            this.rbuJunioren.CheckedChanged += new System.EventHandler(this.rbu_CheckedChanged);
            // 
            // rbuSenioren
            // 
            this.rbuSenioren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbuSenioren.AutoSize = true;
            this.rbuSenioren.Checked = true;
            this.rbuSenioren.Location = new System.Drawing.Point(1062, 25);
            this.rbuSenioren.Margin = new System.Windows.Forms.Padding(4);
            this.rbuSenioren.Name = "rbuSenioren";
            this.rbuSenioren.Size = new System.Drawing.Size(86, 21);
            this.rbuSenioren.TabIndex = 25;
            this.rbuSenioren.TabStop = true;
            this.rbuSenioren.Text = "Senioren";
            this.rbuSenioren.UseVisualStyleBackColor = true;
            this.rbuSenioren.CheckedChanged += new System.EventHandler(this.rbu_CheckedChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(1059, 279);
            this.cmdSave.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(100, 28);
            this.cmdSave.TabIndex = 23;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(1059, 326);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(100, 28);
            this.cmdExit.TabIndex = 17;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.olvVrijwilligers);
            this.pnlGrid.Controls.Add(this.statusStrip1);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(0, 0);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(4);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1001, 369);
            this.pnlGrid.TabIndex = 1;
            // 
            // olvVrijwilligers
            // 
            this.olvVrijwilligers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvVrijwilligers.Location = new System.Drawing.Point(0, 0);
            this.olvVrijwilligers.Margin = new System.Windows.Forms.Padding(4);
            this.olvVrijwilligers.Name = "olvVrijwilligers";
            this.olvVrijwilligers.ShowGroups = false;
            this.olvVrijwilligers.Size = new System.Drawing.Size(1001, 347);
            this.olvVrijwilligers.TabIndex = 1;
            this.olvVrijwilligers.UseCompatibleStateImageBehavior = false;
            this.olvVrijwilligers.View = System.Windows.Forms.View.Details;
            this.olvVrijwilligers.VirtualMode = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 347);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1001, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Location = new System.Drawing.Point(1059, 231);
            this.cmdPrint.Margin = new System.Windows.Forms.Padding(4);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(100, 28);
            this.cmdPrint.TabIndex = 30;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // rbuGemerkt
            // 
            this.rbuGemerkt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbuGemerkt.AutoSize = true;
            this.rbuGemerkt.Location = new System.Drawing.Point(1063, 82);
            this.rbuGemerkt.Margin = new System.Windows.Forms.Padding(4);
            this.rbuGemerkt.Name = "rbuGemerkt";
            this.rbuGemerkt.Size = new System.Drawing.Size(83, 21);
            this.rbuGemerkt.TabIndex = 31;
            this.rbuGemerkt.Text = "Gemerkt";
            this.rbuGemerkt.UseVisualStyleBackColor = true;
            this.rbuGemerkt.CheckedChanged += new System.EventHandler(this.rbu_CheckedChanged);
            // 
            // frmLedenOverzicht1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 369);
            this.Controls.Add(this.rbuGemerkt);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.rbuJunioren);
            this.Controls.Add(this.rbuSenioren);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.pnlGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLedenOverzicht1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Vrijwilligers Overzicht";
            this.Activated += new System.EventHandler(this.frmLedenOverzicht1_Activated);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvVrijwilligers)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.RadioButton rbuSenioren;
        private System.Windows.Forms.RadioButton rbuJunioren;
        private BrightIdeasSoftware.FastObjectListView olvVrijwilligers;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.RadioButton rbuGemerkt;
    }
}