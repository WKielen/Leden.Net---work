namespace Leden.Net
{
    partial class frmEenmaligeBetaling
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEenmaligeBetaling));
            this.pnlBackground = new System.Windows.Forms.Panel();
            this.olvBetalingen = new BrightIdeasSoftware.FastObjectListView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.cboCrediteur = new Util.Forms.DropDownObject(this.components);
            this.txtEndToEndid = new System.Windows.Forms.MaskedTextBox();
            this.dtpGewensteDatum = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEndToEndId = new System.Windows.Forms.Label();
            this.lblOmschrijving = new System.Windows.Forms.Label();
            this.cboTypeRekening = new System.Windows.Forms.ComboBox();
            this.dtpAanmaakDatum = new System.Windows.Forms.DateTimePicker();
            this.ckbVerstuurd = new System.Windows.Forms.CheckBox();
            this.txtOmschrijving = new System.Windows.Forms.TextBox();
            this.lblGewensteDatum = new System.Windows.Forms.Label();
            this.lblVerstuurdDate = new System.Windows.Forms.Label();
            this.dtpDatumVerstuurd = new System.Windows.Forms.DateTimePicker();
            this.lblAanmaakDatum = new System.Windows.Forms.Label();
            this.lblTotaalbedrag = new System.Windows.Forms.Label();
            this.lblTypeRekening = new System.Windows.Forms.Label();
            this.txtTotaalbedrag = new Util.Forms.currencyTextBox(this.components);
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdChange = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.CmdNew = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkFilter = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.Nr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Datum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Verstuurd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Storno = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Omschrijving = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bedrag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvBetalingen)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlDetails.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBackground
            // 
            this.pnlBackground.Controls.Add(this.olvBetalingen);
            this.pnlBackground.Controls.Add(this.pnlBottom);
            this.pnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBackground.Location = new System.Drawing.Point(0, 0);
            this.pnlBackground.Name = "pnlBackground";
            this.pnlBackground.Size = new System.Drawing.Size(977, 554);
            this.pnlBackground.TabIndex = 1;
            // 
            // olvBetalingen
            // 
            this.olvBetalingen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvBetalingen.Location = new System.Drawing.Point(0, 0);
            this.olvBetalingen.Name = "olvBetalingen";
            this.olvBetalingen.ShowGroups = false;
            this.olvBetalingen.Size = new System.Drawing.Size(977, 336);
            this.olvBetalingen.TabIndex = 3;
            this.olvBetalingen.UseCompatibleStateImageBehavior = false;
            this.olvBetalingen.View = System.Windows.Forms.View.Details;
            this.olvBetalingen.VirtualMode = true;
            this.olvBetalingen.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvRekeningen_FormatRow);
            this.olvBetalingen.SelectedIndexChanged += new System.EventHandler(this.olvBetalingen_SelectedIndexChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlDetails);
            this.pnlBottom.Controls.Add(this.pnlButtons);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 336);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(977, 218);
            this.pnlBottom.TabIndex = 1;
            // 
            // pnlDetails
            // 
            this.pnlDetails.Controls.Add(this.cboCrediteur);
            this.pnlDetails.Controls.Add(this.txtEndToEndid);
            this.pnlDetails.Controls.Add(this.dtpGewensteDatum);
            this.pnlDetails.Controls.Add(this.label1);
            this.pnlDetails.Controls.Add(this.lblEndToEndId);
            this.pnlDetails.Controls.Add(this.lblOmschrijving);
            this.pnlDetails.Controls.Add(this.cboTypeRekening);
            this.pnlDetails.Controls.Add(this.dtpAanmaakDatum);
            this.pnlDetails.Controls.Add(this.ckbVerstuurd);
            this.pnlDetails.Controls.Add(this.txtOmschrijving);
            this.pnlDetails.Controls.Add(this.lblGewensteDatum);
            this.pnlDetails.Controls.Add(this.lblVerstuurdDate);
            this.pnlDetails.Controls.Add(this.dtpDatumVerstuurd);
            this.pnlDetails.Controls.Add(this.lblAanmaakDatum);
            this.pnlDetails.Controls.Add(this.lblTotaalbedrag);
            this.pnlDetails.Controls.Add(this.lblTypeRekening);
            this.pnlDetails.Controls.Add(this.txtTotaalbedrag);
            this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetails.Location = new System.Drawing.Point(0, 0);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(875, 218);
            this.pnlDetails.TabIndex = 498;
            // 
            // cboCrediteur
            // 
            this.cboCrediteur.FormattingEnabled = true;
            this.cboCrediteur.Location = new System.Drawing.Point(137, 94);
            this.cboCrediteur.Name = "cboCrediteur";
            this.cboCrediteur.Size = new System.Drawing.Size(242, 21);
            this.cboCrediteur.TabIndex = 489;
            // 
            // txtEndToEndid
            // 
            this.txtEndToEndid.Location = new System.Drawing.Point(137, 58);
            this.txtEndToEndid.Mask = "0000.0000.0000.0000";
            this.txtEndToEndid.Name = "txtEndToEndid";
            this.txtEndToEndid.Size = new System.Drawing.Size(121, 20);
            this.txtEndToEndid.TabIndex = 486;
            this.txtEndToEndid.TextChanged += new System.EventHandler(this.txtEndToEndid_TextChanged);
            // 
            // dtpGewensteDatum
            // 
            this.dtpGewensteDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpGewensteDatum.Location = new System.Drawing.Point(693, 90);
            this.dtpGewensteDatum.Name = "dtpGewensteDatum";
            this.dtpGewensteDatum.Size = new System.Drawing.Size(74, 20);
            this.dtpGewensteDatum.TabIndex = 485;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 468;
            this.label1.Text = "Crediteur";
            // 
            // lblEndToEndId
            // 
            this.lblEndToEndId.AutoSize = true;
            this.lblEndToEndId.Location = new System.Drawing.Point(23, 61);
            this.lblEndToEndId.Name = "lblEndToEndId";
            this.lblEndToEndId.Size = new System.Drawing.Size(86, 13);
            this.lblEndToEndId.TabIndex = 468;
            this.lblEndToEndId.Text = "Betalingkenmerk";
            // 
            // lblOmschrijving
            // 
            this.lblOmschrijving.AutoSize = true;
            this.lblOmschrijving.Location = new System.Drawing.Point(23, 21);
            this.lblOmschrijving.Name = "lblOmschrijving";
            this.lblOmschrijving.Size = new System.Drawing.Size(67, 13);
            this.lblOmschrijving.TabIndex = 468;
            this.lblOmschrijving.Text = "Omschrijving";
            // 
            // cboTypeRekening
            // 
            this.cboTypeRekening.FormattingEnabled = true;
            this.cboTypeRekening.ItemHeight = 13;
            this.cboTypeRekening.Location = new System.Drawing.Point(693, 129);
            this.cboTypeRekening.Name = "cboTypeRekening";
            this.cboTypeRekening.Size = new System.Drawing.Size(121, 21);
            this.cboTypeRekening.TabIndex = 484;
            // 
            // dtpAanmaakDatum
            // 
            this.dtpAanmaakDatum.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAanmaakDatum.Location = new System.Drawing.Point(693, 55);
            this.dtpAanmaakDatum.Name = "dtpAanmaakDatum";
            this.dtpAanmaakDatum.Size = new System.Drawing.Size(74, 20);
            this.dtpAanmaakDatum.TabIndex = 479;
            // 
            // ckbVerstuurd
            // 
            this.ckbVerstuurd.AutoSize = true;
            this.ckbVerstuurd.Location = new System.Drawing.Point(693, 173);
            this.ckbVerstuurd.Name = "ckbVerstuurd";
            this.ckbVerstuurd.Size = new System.Drawing.Size(15, 14);
            this.ckbVerstuurd.TabIndex = 481;
            this.ckbVerstuurd.UseVisualStyleBackColor = true;
            this.ckbVerstuurd.CheckedChanged += new System.EventHandler(this.ckbVerstuurd_CheckedChanged);
            // 
            // txtOmschrijving
            // 
            this.txtOmschrijving.Location = new System.Drawing.Point(137, 21);
            this.txtOmschrijving.MaxLength = 140;
            this.txtOmschrijving.Name = "txtOmschrijving";
            this.txtOmschrijving.Size = new System.Drawing.Size(630, 20);
            this.txtOmschrijving.TabIndex = 462;
            this.txtOmschrijving.TextChanged += new System.EventHandler(this.txtOmschrijving_TextChanged);
            // 
            // lblGewensteDatum
            // 
            this.lblGewensteDatum.Location = new System.Drawing.Point(559, 85);
            this.lblGewensteDatum.Name = "lblGewensteDatum";
            this.lblGewensteDatum.Size = new System.Drawing.Size(112, 30);
            this.lblGewensteDatum.TabIndex = 471;
            this.lblGewensteDatum.Text = "Gewenste verwerkingsdatum";
            // 
            // lblVerstuurdDate
            // 
            this.lblVerstuurdDate.AutoSize = true;
            this.lblVerstuurdDate.Location = new System.Drawing.Point(559, 174);
            this.lblVerstuurdDate.Name = "lblVerstuurdDate";
            this.lblVerstuurdDate.Size = new System.Drawing.Size(86, 13);
            this.lblVerstuurdDate.TabIndex = 471;
            this.lblVerstuurdDate.Text = "Datum Verstuurd";
            // 
            // dtpDatumVerstuurd
            // 
            this.dtpDatumVerstuurd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumVerstuurd.Location = new System.Drawing.Point(724, 167);
            this.dtpDatumVerstuurd.Name = "dtpDatumVerstuurd";
            this.dtpDatumVerstuurd.Size = new System.Drawing.Size(74, 20);
            this.dtpDatumVerstuurd.TabIndex = 480;
            // 
            // lblAanmaakDatum
            // 
            this.lblAanmaakDatum.AutoSize = true;
            this.lblAanmaakDatum.Location = new System.Drawing.Point(559, 61);
            this.lblAanmaakDatum.Name = "lblAanmaakDatum";
            this.lblAanmaakDatum.Size = new System.Drawing.Size(86, 13);
            this.lblAanmaakDatum.TabIndex = 467;
            this.lblAanmaakDatum.Text = "Aanmaak Datum";
            // 
            // lblTotaalbedrag
            // 
            this.lblTotaalbedrag.AutoSize = true;
            this.lblTotaalbedrag.Location = new System.Drawing.Point(23, 132);
            this.lblTotaalbedrag.Name = "lblTotaalbedrag";
            this.lblTotaalbedrag.Size = new System.Drawing.Size(41, 13);
            this.lblTotaalbedrag.TabIndex = 470;
            this.lblTotaalbedrag.Text = "Bedrag";
            // 
            // lblTypeRekening
            // 
            this.lblTypeRekening.AutoSize = true;
            this.lblTypeRekening.Location = new System.Drawing.Point(559, 132);
            this.lblTypeRekening.Name = "lblTypeRekening";
            this.lblTypeRekening.Size = new System.Drawing.Size(80, 13);
            this.lblTypeRekening.TabIndex = 469;
            this.lblTypeRekening.Text = "Type Rekening";
            // 
            // txtTotaalbedrag
            // 
            this.txtTotaalbedrag.DecimalPlaces = 2;
            this.txtTotaalbedrag.DecimalsSeparator = ',';
            this.txtTotaalbedrag.Location = new System.Drawing.Point(137, 129);
            this.txtTotaalbedrag.Name = "txtTotaalbedrag";
            this.txtTotaalbedrag.PreFix = "€";
            this.txtTotaalbedrag.Size = new System.Drawing.Size(67, 20);
            this.txtTotaalbedrag.TabIndex = 463;
            this.txtTotaalbedrag.Text = "€ 0";
            this.txtTotaalbedrag.ThousandsSeparator = '.';
            this.txtTotaalbedrag.ToFromDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTotaalbedrag.ToFromInteger = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.cmdCancel);
            this.pnlButtons.Controls.Add(this.cmdChange);
            this.pnlButtons.Controls.Add(this.cmdExit);
            this.pnlButtons.Controls.Add(this.cmdSave);
            this.pnlButtons.Controls.Add(this.CmdNew);
            this.pnlButtons.Controls.Add(this.cmdDelete);
            this.pnlButtons.Controls.Add(this.label2);
            this.pnlButtons.Controls.Add(this.chkFilter);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlButtons.Location = new System.Drawing.Point(875, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(102, 218);
            this.pnlButtons.TabIndex = 496;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(15, 121);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 496;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdChange
            // 
            this.cmdChange.Location = new System.Drawing.Point(15, 91);
            this.cmdChange.Name = "cmdChange";
            this.cmdChange.Size = new System.Drawing.Size(75, 23);
            this.cmdChange.TabIndex = 495;
            this.cmdChange.Text = "Change";
            this.cmdChange.UseVisualStyleBackColor = true;
            this.cmdChange.Click += new System.EventHandler(this.cmdChange_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(15, 178);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 486;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(15, 91);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 485;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Visible = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // CmdNew
            // 
            this.CmdNew.Location = new System.Drawing.Point(15, 149);
            this.CmdNew.Name = "CmdNew";
            this.CmdNew.Size = new System.Drawing.Size(75, 23);
            this.CmdNew.TabIndex = 493;
            this.CmdNew.Text = "New";
            this.CmdNew.UseVisualStyleBackColor = true;
            this.CmdNew.Click += new System.EventHandler(this.CmdNew_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(15, 120);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 487;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 471;
            this.label2.Text = "Filter Verstuurd";
            // 
            // chkFilter
            // 
            this.chkFilter.AutoSize = true;
            this.chkFilter.Location = new System.Drawing.Point(40, 39);
            this.chkFilter.Name = "chkFilter";
            this.chkFilter.Size = new System.Drawing.Size(15, 14);
            this.chkFilter.TabIndex = 481;
            this.chkFilter.UseVisualStyleBackColor = true;
            this.chkFilter.CheckedChanged += new System.EventHandler(this.chkFilter_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 497;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // Nr
            // 
            this.Nr.Text = "Nr";
            this.Nr.Width = 50;
            // 
            // Datum
            // 
            this.Datum.Text = "Datum";
            // 
            // Verstuurd
            // 
            this.Verstuurd.Text = "Verstuurd";
            this.Verstuurd.Width = 20;
            // 
            // Storno
            // 
            this.Storno.Text = "Storno";
            this.Storno.Width = 20;
            // 
            // Omschrijving
            // 
            this.Omschrijving.Text = "Omschrijving";
            this.Omschrijving.Width = 300;
            // 
            // Bedrag
            // 
            this.Bedrag.Text = "Bedrag";
            this.Bedrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmEenmaligeBetaling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 576);
            this.Controls.Add(this.pnlBackground);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEenmaligeBetaling";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Betalingen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRekeningOverzicht2_FormClosing);
            this.pnlBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvBetalingen)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackground;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ColumnHeader Nr;
        private System.Windows.Forms.ColumnHeader Datum;
        private System.Windows.Forms.ColumnHeader Omschrijving;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ColumnHeader Verstuurd;
        private System.Windows.Forms.ColumnHeader Bedrag;
        private System.Windows.Forms.ColumnHeader Storno;
        private System.Windows.Forms.Button CmdNew;
        private System.Windows.Forms.Button cmdChange;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Label lblOmschrijving;
        private System.Windows.Forms.Label lblVerstuurdDate;
        private System.Windows.Forms.Label lblAanmaakDatum;
        private System.Windows.Forms.Label lblTypeRekening;
        private Util.Forms.currencyTextBox txtTotaalbedrag;
        private System.Windows.Forms.Label lblTotaalbedrag;
        private System.Windows.Forms.TextBox txtOmschrijving;
        private System.Windows.Forms.ComboBox cboTypeRekening;
        private System.Windows.Forms.DateTimePicker dtpAanmaakDatum;
        private System.Windows.Forms.CheckBox ckbVerstuurd;
        private System.Windows.Forms.DateTimePicker dtpDatumVerstuurd;
        private BrightIdeasSoftware.FastObjectListView olvBetalingen;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.DateTimePicker dtpGewensteDatum;
        private System.Windows.Forms.Label lblGewensteDatum;
        private System.Windows.Forms.Label lblEndToEndId;
        private System.Windows.Forms.MaskedTextBox txtEndToEndid;
        private System.Windows.Forms.Label label1;
        private Util.Forms.DropDownObject cboCrediteur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkFilter;
    }
}