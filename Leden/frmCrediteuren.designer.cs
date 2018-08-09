using BrightIdeasSoftware;
using System.Drawing;
namespace Leden.Net
{
    partial class frmCrediteuren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrediteuren));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.olvVCard = new BrightIdeasSoftware.FastObjectListView();
            this.pnlLeftBottum = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtOutputLocation = new System.Windows.Forms.TextBox();
            this.lblLocatieOutput = new System.Windows.Forms.Label();
            this.cmdPrint = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.groupBox9.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvVCard)).BeginInit();
            this.pnlLeftBottum.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.txtFilter);
            this.groupBox9.Location = new System.Drawing.Point(800, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(117, 44);
            this.groupBox9.TabIndex = 18;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Filter";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(7, 20);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 20);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Location = new System.Drawing.Point(817, 100);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(81, 23);
            this.cmdDelete.TabIndex = 28;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdNew.Location = new System.Drawing.Point(817, 71);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(81, 23);
            this.cmdNew.TabIndex = 26;
            this.cmdNew.Text = "New";
            this.cmdNew.UseVisualStyleBackColor = true;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdExit.Location = new System.Drawing.Point(817, 369);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(81, 23);
            this.cmdExit.TabIndex = 19;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.panel2);
            this.pnlLeft.Controls.Add(this.pnlLeftBottum);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(794, 411);
            this.pnlLeft.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.olvVCard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 345);
            this.panel2.TabIndex = 2;
            // 
            // olvVCard
            // 
            this.olvVCard.AlternateRowBackColor = System.Drawing.Color.Bisque;
            this.olvVCard.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.olvVCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.olvVCard.EmptyListMsg = "This list is empty. Press \"Add\" to create some items";
            this.olvVCard.FullRowSelect = true;
            this.olvVCard.GroupWithItemCountFormat = "{0} ({1} contacten)";
            this.olvVCard.GroupWithItemCountSingularFormat = "{0} ({1} contact)";
            this.olvVCard.HeaderWordWrap = true;
            this.olvVCard.Location = new System.Drawing.Point(0, 0);
            this.olvVCard.Name = "olvVCard";
            this.olvVCard.OwnerDraw = true;
            this.olvVCard.ShowGroups = false;
            this.olvVCard.ShowImagesOnSubItems = true;
            this.olvVCard.ShowItemCountOnGroups = true;
            this.olvVCard.Size = new System.Drawing.Size(794, 345);
            this.olvVCard.TabIndex = 0;
            this.olvVCard.UseAlternatingBackColors = true;
            this.olvVCard.UseCompatibleStateImageBehavior = false;
            this.olvVCard.UseFilterIndicator = true;
            this.olvVCard.UseFiltering = true;
            this.olvVCard.View = System.Windows.Forms.View.Details;
            this.olvVCard.VirtualMode = true;
            // 
            // pnlLeftBottum
            // 
            this.pnlLeftBottum.Controls.Add(this.statusStrip1);
            this.pnlLeftBottum.Controls.Add(this.txtOutputLocation);
            this.pnlLeftBottum.Controls.Add(this.lblLocatieOutput);
            this.pnlLeftBottum.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLeftBottum.Location = new System.Drawing.Point(0, 345);
            this.pnlLeftBottum.Name = "pnlLeftBottum";
            this.pnlLeftBottum.Size = new System.Drawing.Size(794, 66);
            this.pnlLeftBottum.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 44);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(794, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // txtOutputLocation
            // 
            this.txtOutputLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputLocation.Location = new System.Drawing.Point(115, 17);
            this.txtOutputLocation.Name = "txtOutputLocation";
            this.txtOutputLocation.Size = new System.Drawing.Size(676, 20);
            this.txtOutputLocation.TabIndex = 7;
            this.txtOutputLocation.Text = "C:\\Temp\\Visual studio projects\\Leden.Net - work\\Leden\\Files";
            // 
            // lblLocatieOutput
            // 
            this.lblLocatieOutput.AutoSize = true;
            this.lblLocatieOutput.Location = new System.Drawing.Point(19, 20);
            this.lblLocatieOutput.Name = "lblLocatieOutput";
            this.lblLocatieOutput.Size = new System.Drawing.Size(87, 13);
            this.lblLocatieOutput.TabIndex = 8;
            this.lblLocatieOutput.Text = "Locatie output ...";
            this.lblLocatieOutput.Click += new System.EventHandler(this.lblLocatieOutput_Click);
            // 
            // cmdPrint
            // 
            this.cmdPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdPrint.Location = new System.Drawing.Point(818, 249);
            this.cmdPrint.Name = "cmdPrint";
            this.cmdPrint.Size = new System.Drawing.Size(81, 23);
            this.cmdPrint.TabIndex = 29;
            this.cmdPrint.Text = "Print";
            this.cmdPrint.UseVisualStyleBackColor = true;
            this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSave.Location = new System.Drawing.Point(817, 340);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(81, 23);
            this.cmdSave.TabIndex = 28;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // frmCrediteuren
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 411);
            this.Controls.Add(this.cmdPrint);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.pnlLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCrediteuren";
            this.ShowInTaskbar = false;
            this.Text = "Crediteuren";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVCard_FormClosing);
            this.SizeChanged += new System.EventHandler(this.frmVCard_SizeChanged);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvVCard)).EndInit();
            this.pnlLeftBottum.ResumeLayout(false);
            this.pnlLeftBottum.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlLeftBottum;
        private System.Windows.Forms.TextBox txtOutputLocation;
        private System.Windows.Forms.Label lblLocatieOutput;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private BrightIdeasSoftware.FastObjectListView olvVCard;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button cmdPrint;
        private System.Windows.Forms.Button cmdSave;
    }
}