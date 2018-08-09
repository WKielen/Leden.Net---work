namespace Leden.Net
{
    partial class frmSelectLeden
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectLeden));
            this.clbLeden = new System.Windows.Forms.CheckedListBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdClearSelectie = new System.Windows.Forms.Button();
            this.cboFilterLeeftijd = new System.Windows.Forms.ComboBox();
            this.cboFilterLidBond = new System.Windows.Forms.ComboBox();
            this.cboFilterCompetitie = new System.Windows.Forms.ComboBox();
            this.cboFilterLidType = new System.Windows.Forms.ComboBox();
            this.cboFilterBetaalWijze = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clbLeden
            // 
            this.clbLeden.CheckOnClick = true;
            this.clbLeden.ColumnWidth = 160;
            this.clbLeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLeden.Location = new System.Drawing.Point(0, 0);
            this.clbLeden.MultiColumn = true;
            this.clbLeden.Name = "clbLeden";
            this.clbLeden.Size = new System.Drawing.Size(537, 718);
            this.clbLeden.TabIndex = 0;
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(115, 237);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(85, 23);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "&Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdClearSelectie
            // 
            this.cmdClearSelectie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdClearSelectie.Location = new System.Drawing.Point(115, 195);
            this.cmdClearSelectie.Name = "cmdClearSelectie";
            this.cmdClearSelectie.Size = new System.Drawing.Size(85, 23);
            this.cmdClearSelectie.TabIndex = 3;
            this.cmdClearSelectie.Text = "Clear Selectie";
            this.cmdClearSelectie.UseVisualStyleBackColor = true;
            this.cmdClearSelectie.Click += new System.EventHandler(this.cmdClearSelectie_Click);
            // 
            // cboFilterLeeftijd
            // 
            this.cboFilterLeeftijd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterLeeftijd.FormattingEnabled = true;
            this.cboFilterLeeftijd.Location = new System.Drawing.Point(115, 14);
            this.cboFilterLeeftijd.Name = "cboFilterLeeftijd";
            this.cboFilterLeeftijd.Size = new System.Drawing.Size(121, 21);
            this.cboFilterLeeftijd.TabIndex = 4;
            // 
            // cboFilterLidBond
            // 
            this.cboFilterLidBond.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterLidBond.FormattingEnabled = true;
            this.cboFilterLidBond.Location = new System.Drawing.Point(115, 42);
            this.cboFilterLidBond.Name = "cboFilterLidBond";
            this.cboFilterLidBond.Size = new System.Drawing.Size(121, 21);
            this.cboFilterLidBond.TabIndex = 5;
            // 
            // cboFilterCompetitie
            // 
            this.cboFilterCompetitie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterCompetitie.FormattingEnabled = true;
            this.cboFilterCompetitie.Location = new System.Drawing.Point(115, 70);
            this.cboFilterCompetitie.Name = "cboFilterCompetitie";
            this.cboFilterCompetitie.Size = new System.Drawing.Size(121, 21);
            this.cboFilterCompetitie.TabIndex = 6;
            // 
            // cboFilterLidType
            // 
            this.cboFilterLidType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterLidType.FormattingEnabled = true;
            this.cboFilterLidType.Location = new System.Drawing.Point(115, 98);
            this.cboFilterLidType.Name = "cboFilterLidType";
            this.cboFilterLidType.Size = new System.Drawing.Size(121, 21);
            this.cboFilterLidType.TabIndex = 7;
            // 
            // cboFilterBetaalWijze
            // 
            this.cboFilterBetaalWijze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFilterBetaalWijze.FormattingEnabled = true;
            this.cboFilterBetaalWijze.Location = new System.Drawing.Point(115, 126);
            this.cboFilterBetaalWijze.Name = "cboFilterBetaalWijze";
            this.cboFilterBetaalWijze.Size = new System.Drawing.Size(121, 21);
            this.cboFilterBetaalWijze.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Leeftijd";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lid Bond";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Competitie";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Lid Type";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Betaalwijze";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Controls.Add(this.cmdClearSelectie);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboFilterLeeftijd);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboFilterLidBond);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cboFilterCompetitie);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboFilterLidType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboFilterBetaalWijze);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(292, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 718);
            this.panel1.TabIndex = 10;
            // 
            // frmSelectLeden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(537, 718);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clbLeden);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSelectLeden";
            this.ShowInTaskbar = false;
            this.Text = "Selecteer Leden";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSelectLeden_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbLeden;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdClearSelectie;
        private System.Windows.Forms.ComboBox cboFilterLeeftijd;
        private System.Windows.Forms.ComboBox cboFilterLidBond;
        private System.Windows.Forms.ComboBox cboFilterCompetitie;
        public System.Windows.Forms.ComboBox cboFilterLidType;
        public System.Windows.Forms.ComboBox cboFilterBetaalWijze;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}