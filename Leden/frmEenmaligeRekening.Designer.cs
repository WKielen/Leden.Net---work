
using Util.Forms;
using Util.Text;

namespace Leden.Net
{
    partial class frmEenmaligeRekening
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       private System.ComponentModel.IContainer components = null;

  
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEenmaligeRekening));
            this.txtTotaalbedrag = new Util.Forms.currencyTextBox(this.components);
            this.lblTotaalbedrag = new System.Windows.Forms.Label();
            this.lblTypeRekening = new System.Windows.Forms.Label();
            this.lblOmschrijving = new System.Windows.Forms.Label();
            this.lblAanmaakDatum = new System.Windows.Forms.Label();
            this.txtLidNr = new System.Windows.Forms.TextBox();
            this.lblLidNr = new System.Windows.Forms.Label();
            this.dtpAanmaakDatum = new System.Windows.Forms.DateTimePicker();
            this.cboTypeRekening = new System.Windows.Forms.ComboBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.clbLeden = new System.Windows.Forms.CheckedListBox();
            this.cmdCreate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdOutput = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTotaalbedrag
            // 
            this.txtTotaalbedrag.DecimalPlaces = 2;
            this.txtTotaalbedrag.DecimalsSeparator = ',';
            this.txtTotaalbedrag.Location = new System.Drawing.Point(103, 75);
            this.txtTotaalbedrag.Name = "txtTotaalbedrag";
            this.txtTotaalbedrag.PreFix = "€";
            this.txtTotaalbedrag.Size = new System.Drawing.Size(120, 20);
            this.txtTotaalbedrag.TabIndex = 3;
            this.txtTotaalbedrag.Text = "€ 0";
            this.txtTotaalbedrag.ThousandsSeparator = '.';
            this.txtTotaalbedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotaalbedrag.ToFromInteger = 0;
            // 
            // lblTotaalbedrag
            // 
            this.lblTotaalbedrag.AutoSize = true;
            this.lblTotaalbedrag.Location = new System.Drawing.Point(12, 78);
            this.lblTotaalbedrag.Name = "lblTotaalbedrag";
            this.lblTotaalbedrag.Size = new System.Drawing.Size(41, 13);
            this.lblTotaalbedrag.TabIndex = 445;
            this.lblTotaalbedrag.Text = "Bedrag";
            // 
            // lblTypeRekening
            // 
            this.lblTypeRekening.AutoSize = true;
            this.lblTypeRekening.Location = new System.Drawing.Point(12, 46);
            this.lblTypeRekening.Name = "lblTypeRekening";
            this.lblTypeRekening.Size = new System.Drawing.Size(80, 13);
            this.lblTypeRekening.TabIndex = 445;
            this.lblTypeRekening.Text = "Type Rekening";
            // 
            // lblOmschrijving
            // 
            this.lblOmschrijving.AutoSize = true;
            this.lblOmschrijving.Location = new System.Drawing.Point(12, 14);
            this.lblOmschrijving.Name = "lblOmschrijving";
            this.lblOmschrijving.Size = new System.Drawing.Size(67, 13);
            this.lblOmschrijving.TabIndex = 445;
            this.lblOmschrijving.Text = "Omschrijving";
            // 
            // lblAanmaakDatum
            // 
            this.lblAanmaakDatum.AutoSize = true;
            this.lblAanmaakDatum.Location = new System.Drawing.Point(12, 106);
            this.lblAanmaakDatum.Name = "lblAanmaakDatum";
            this.lblAanmaakDatum.Size = new System.Drawing.Size(86, 13);
            this.lblAanmaakDatum.TabIndex = 445;
            this.lblAanmaakDatum.Text = "Aanmaak Datum";
            // 
            // txtLidNr
            // 
            this.txtLidNr.Location = new System.Drawing.Point(0, 0);
            this.txtLidNr.Name = "txtLidNr";
            this.txtLidNr.Size = new System.Drawing.Size(100, 20);
            this.txtLidNr.TabIndex = 0;
            // 
            // lblLidNr
            // 
            this.lblLidNr.Location = new System.Drawing.Point(0, 0);
            this.lblLidNr.Name = "lblLidNr";
            this.lblLidNr.Size = new System.Drawing.Size(100, 23);
            this.lblLidNr.TabIndex = 0;
            // 
            // dtpAanmaakDatum
            // 
            this.dtpAanmaakDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmaakDatum.Location = new System.Drawing.Point(103, 103);
            this.dtpAanmaakDatum.Name = "dtpAanmaakDatum";
            this.dtpAanmaakDatum.Size = new System.Drawing.Size(74, 20);
            this.dtpAanmaakDatum.TabIndex = 451;
            // 
            // cboTypeRekening
            // 
            this.cboTypeRekening.FormattingEnabled = true;
            this.cboTypeRekening.ItemHeight = 13;
            this.cboTypeRekening.Location = new System.Drawing.Point(103, 44);
            this.cboTypeRekening.Name = "cboTypeRekening";
            this.cboTypeRekening.Size = new System.Drawing.Size(121, 21);
            this.cboTypeRekening.TabIndex = 455;
            this.cboTypeRekening.Text = "Inschrijfgeld";
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(408, 218);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 458;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOmschrijving.Location = new System.Drawing.Point(103, 11);
            this.txtOmschrijving.MaxLength = 140;
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(360, 20);
            this.txtOmschrijving.TabIndex = 1;
            // 
            // clbLeden
            // 
            this.clbLeden.CheckOnClick = true;
            this.clbLeden.ColumnWidth = 160;
            this.clbLeden.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbLeden.FormattingEnabled = true;
            this.clbLeden.Location = new System.Drawing.Point(0, 0);
            this.clbLeden.MultiColumn = true;
            this.clbLeden.Name = "clbLeden";
            this.clbLeden.Size = new System.Drawing.Size(718, 281);
            this.clbLeden.TabIndex = 462;
            // 
            // cmdCreate
            // 
            this.cmdCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCreate.Location = new System.Drawing.Point(408, 189);
            this.cmdCreate.Name = "cmdCreate";
            this.cmdCreate.Size = new System.Drawing.Size(75, 23);
            this.cmdCreate.TabIndex = 463;
            this.cmdCreate.Text = "Create";
            this.cmdCreate.UseVisualStyleBackColor = true;
            this.cmdCreate.Click += new System.EventHandler(this.cmdCreate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdOutput);
            this.panel1.Controls.Add(this.lblAanmaakDatum);
            this.panel1.Controls.Add(this.cmdCreate);
            this.panel1.Controls.Add(this.lblOmschrijving);
            this.panel1.Controls.Add(this.lblTypeRekening);
            this.panel1.Controls.Add(this.txtOmschrijving);
            this.panel1.Controls.Add(this.lblTotaalbedrag);
            this.panel1.Controls.Add(this.cmdExit);
            this.panel1.Controls.Add(this.txtTotaalbedrag);
            this.panel1.Controls.Add(this.dtpAanmaakDatum);
            this.panel1.Controls.Add(this.cboTypeRekening);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(223, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 259);
            this.panel1.TabIndex = 464;
            // 
            // cmdOutput
            // 
            this.cmdOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOutput.Location = new System.Drawing.Point(15, 218);
            this.cmdOutput.Name = "cmdOutput";
            this.cmdOutput.Size = new System.Drawing.Size(75, 23);
            this.cmdOutput.TabIndex = 473;
            this.cmdOutput.Text = "Show logfile";
            this.cmdOutput.UseVisualStyleBackColor = true;
            this.cmdOutput.Click += new System.EventHandler(this.cmdOutput_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 259);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(718, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 474;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // frmEenmaligeRekening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdExit;
            this.ClientSize = new System.Drawing.Size(718, 281);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clbLeden);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEenmaligeRekening";
            this.ShowInTaskbar = false;
            this.Text = "Eenmalige rekening";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEenmaligeRekening_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotaalbedrag;
        private Util.Forms.currencyTextBox txtTotaalbedrag;
        private System.Windows.Forms.Label lblTypeRekening;
        private System.Windows.Forms.Label lblOmschrijving;
        private System.Windows.Forms.Label lblAanmaakDatum;
        private System.Windows.Forms.Label lblLidNr;
        private System.Windows.Forms.TextBox txtLidNr;
        private System.Windows.Forms.DateTimePicker dtpAanmaakDatum;
        private System.Windows.Forms.ComboBox cboTypeRekening;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.TextBox txtOmschrijving;
        //        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.CheckedListBox clbLeden;
        private System.Windows.Forms.Button cmdCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}