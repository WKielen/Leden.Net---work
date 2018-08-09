using System;      
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Text;

using Util.Text;
using Util.Forms;

namespace Stand.Net
{
	/// <summary>
	/// Summary description for frmSnelInvoeren.
	/// </summary>
	public class frmSnelInvoeren : frmBasis
	{
		#region Controls

		private System.Windows.Forms.Button cmdCancel;
		private System.Windows.Forms.Button cmdAccept;		// Voeg ik runtime toe
		private System.Data.OleDb.OleDbConnection cnLeden;
		#endregion

		private int maxNbrSpelers = 10;
		private DataAdapters da = null;
		private System.Windows.Forms.TextBox txtWedstrijdNummer;
		private System.Windows.Forms.Label lblWedstrijd;
		private System.Windows.Forms.TextBox txtThuis;
		private System.Windows.Forms.TextBox txtUit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox[] txtGespeeld;
		private System.Windows.Forms.Label[] lblNaamSpeler;
		private System.Windows.Forms.TextBox[] txtGewonnen;
		private System.Windows.Forms.Button cmdVolgende;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuVolgende;
		private System.Windows.Forms.Label lblTeam;
		private System.Windows.Forms.Label lblUitslag;
		private System.Windows.Forms.Label lblTeamNaam;
		private System.Windows.Forms.MenuItem mnuShowStand;
		private System.Windows.Forms.ListBox lboUitslagen;
		private PersistWindowState m_windowState;

		#region Constructor
		// Constructor for at design time only
		private frmSnelInvoeren()
		{
			InitializeComponent();
		}

		public frmSnelInvoeren(DataAdapters da)
		{
			InitializeComponent();
			this.da = da;
			#region Create Controls
			lblNaamSpeler = new Label[maxNbrSpelers];
			txtGespeeld = new TextBox[maxNbrSpelers];
			txtGewonnen = new TextBox[maxNbrSpelers];
			int beginHoogte = 190;
			int controlSpace = 2;
				
			for (int y = 0; y < maxNbrSpelers; y++)
			{
				#region Create all dynamic control)
				lblNaamSpeler[y] = new Label();						// Voeg ik runtime toe
				this.Controls.Add(this.lblNaamSpeler[y]);

				lblNaamSpeler[y].Location = new System.Drawing.Point(10, beginHoogte + controlHeight + controlSpace);
				lblNaamSpeler[y].Size = new System.Drawing.Size(120, controlHeight);
				lblNaamSpeler[y].Name = "lblNaamSpeler" + y.ToString();
				lblNaamSpeler[y].CausesValidation = true;
				lblNaamSpeler[y].Visible = false;
				lblNaamSpeler[y].Text = "Spelers " + y.ToString();
					
				txtGespeeld[y] = new TextBox();
				txtGewonnen[y] = new TextBox();
				this.Controls.Add(txtGespeeld[y]);
				this.Controls.Add(txtGewonnen[y]);

				txtGespeeld[y].Location = new System.Drawing.Point((lblNaamSpeler[y].Right + 10), beginHoogte + controlHeight + controlSpace);
				txtGespeeld[y].Size = new System.Drawing.Size(16, controlHeight);
				txtGespeeld[y].Name = "Gespeeld" + y.ToString();
				txtGespeeld[y].MaxLength = 1;
				txtGespeeld[y].ReadOnly = false;
				txtGespeeld[y].TextAlign = HorizontalAlignment.Center;
				txtGespeeld[y].TabIndex = y;
				txtGespeeld[y].Visible = false;
				txtGespeeld[y].CausesValidation = true;
				txtGespeeld[y].BorderStyle = BorderStyle.None;
				txtGespeeld[y].TabStop = false;
				txtGespeeld[y].MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseDown);
				txtGespeeld[y].Enter += new System.EventHandler(this.SelectAll_Enter);
				txtGespeeld[y].KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGespeeld_KeyDown);
				txtGespeeld[y].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck_KeyPress);
				txtGespeeld[y].Validating += new System.ComponentModel.CancelEventHandler(textBox_Validating);
				txtGespeeld[y].BackColor = System.Drawing.SystemColors.Control;

				txtGewonnen[y].Location = new System.Drawing.Point(txtGespeeld[y].Right + 10, beginHoogte + controlHeight + controlSpace);
				txtGewonnen[y].Size = new System.Drawing.Size(16, controlHeight);
				txtGewonnen[y].Name = "Gewonnen" + y.ToString();
				txtGewonnen[y].MaxLength = 1;
				txtGewonnen[y].ReadOnly = false;
				txtGewonnen[y].TextAlign = HorizontalAlignment.Center;
				txtGewonnen[y].TabIndex = y+2;
				txtGewonnen[y].TabStop = true;
				txtGewonnen[y].Visible = false;
				txtGewonnen[y].CausesValidation = true;
				txtGewonnen[y].BorderStyle = BorderStyle.None;;
				txtGewonnen[y].Text = string.Empty;
				txtGewonnen[y].MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseDown);
				txtGewonnen[y].Enter += new System.EventHandler(this.SelectAll_Enter);
				txtGewonnen[y].KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGewonnen_KeyDown);
				txtGewonnen[y].KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck_KeyPress);
				txtGewonnen[y].Validating += new System.ComponentModel.CancelEventHandler(textBox_Validating);


				beginHoogte += (controlSpace + controlHeight);
				#endregion
			}
			#endregion

			GuiRoutines.SetFlatStyle(this.Controls);				
			m_windowState = new PersistWindowState(this, @"Stand\SnelInvoeren");
		}

		private void VulTabellen(string TeamNaam)
		{
			da.VulPouleRecord(TeamNaam);
			da.VulSchemaRecord(da.poule.SchemaNaam);
			da.VulSchemaWedRecords(da.poule.SchemaNaam);
			tblPouleTeam[] pt = da.VulPouleTeamRecords(da.poule.TeamNaam, da.schema.AantalTeams);
			da.VulUitslagRecords(da.poule.TeamNaam, da.schemaWed.Length);
			da.VulWeekNbrRecords(da.poule.WeekNbrNaam);
			da.VulUitslagRegels(da.schemaWed, da.poule, da.pouleTeam, da.uitslagen, da.weekNummers);
			da.VulStandTabel(pt, da.uitslagRegels);
			da.VulSpelerRecords(TeamNaam);
		}

		private void frmSnelInvoeren_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor;
				this.Owner.TopMost = true;
				((frmMain)this.Owner).WindowState = FormWindowState.Minimized;
				this.Activate();

				// zoek eerste vrije wedstrijd
				int wedstrijdNbr = ZoekEersteVrijeWedstrijd(0);
				int volgNbr = ZoekUitslagRegel(wedstrijdNbr);
				UpdateDisplay(volgNbr);
			}
			catch (Exception ex)
			{
				Utils.ShowMessage(ex);
			}

			this.Cursor = Cursors.Arrow;
		}
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSnelInvoeren));
			this.cnLeden = new System.Data.OleDb.OleDbConnection();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.cmdAccept = new System.Windows.Forms.Button();
			this.txtWedstrijdNummer = new System.Windows.Forms.TextBox();
			this.lblWedstrijd = new System.Windows.Forms.Label();
			this.txtThuis = new System.Windows.Forms.TextBox();
			this.txtUit = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdVolgende = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuVolgende = new System.Windows.Forms.MenuItem();
			this.mnuShowStand = new System.Windows.Forms.MenuItem();
			this.lblTeam = new System.Windows.Forms.Label();
			this.lblUitslag = new System.Windows.Forms.Label();
			this.lblTeamNaam = new System.Windows.Forms.Label();
			this.lboUitslagen = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// cnLeden
			// 
			this.cnLeden.ConnectionString = @"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source=""C:\Documents and Settings\kielen\My Documents\Stand.mdb"";Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Global Bulk Transactions=1";
			// 
			// cmdCancel
			// 
			this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Location = new System.Drawing.Point(40, 568);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 106;
			this.cmdCancel.TabStop = false;
			this.cmdCancel.Text = "&Cancel";
			this.cmdCancel.Visible = false;
			// 
			// cmdAccept
			// 
			this.cmdAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdAccept.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdAccept.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdAccept.Location = new System.Drawing.Point(112, 568);
			this.cmdAccept.Name = "cmdAccept";
			this.cmdAccept.TabIndex = 102;
			this.cmdAccept.TabStop = false;
			this.cmdAccept.Text = "&Accept";
			this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
			// 
			// txtWedstrijdNummer
			// 
			this.txtWedstrijdNummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtWedstrijdNummer.Location = new System.Drawing.Point(72, 112);
			this.txtWedstrijdNummer.MaxLength = 6;
			this.txtWedstrijdNummer.Name = "txtWedstrijdNummer";
			this.txtWedstrijdNummer.Size = new System.Drawing.Size(72, 29);
			this.txtWedstrijdNummer.TabIndex = 1;
			this.txtWedstrijdNummer.Text = "";
			this.txtWedstrijdNummer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtWedstrijdNummer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWedstrijdNummer_KeyDown);
			this.txtWedstrijdNummer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseDown);
			this.txtWedstrijdNummer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck_KeyPress);
			this.txtWedstrijdNummer.Enter += new System.EventHandler(this.SelectAll_Enter);
			// 
			// lblWedstrijd
			// 
			this.lblWedstrijd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWedstrijd.Location = new System.Drawing.Point(0, 56);
			this.lblWedstrijd.Name = "lblWedstrijd";
			this.lblWedstrijd.Size = new System.Drawing.Size(208, 24);
			this.lblWedstrijd.TabIndex = 8;
			this.lblWedstrijd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtThuis
			// 
			this.txtThuis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtThuis.Location = new System.Drawing.Point(56, 152);
			this.txtThuis.MaxLength = 2;
			this.txtThuis.Name = "txtThuis";
			this.txtThuis.Size = new System.Drawing.Size(32, 29);
			this.txtThuis.TabIndex = 100;
			this.txtThuis.Text = "";
			this.txtThuis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtThuis.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtThuis_KeyDown);
			this.txtThuis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseDown);
			this.txtThuis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck_KeyPress);
			this.txtThuis.Validating += new System.ComponentModel.CancelEventHandler(this.txtThuis_Validating);
			this.txtThuis.Enter += new System.EventHandler(this.SelectAll_Enter);
			// 
			// txtUit
			// 
			this.txtUit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtUit.Location = new System.Drawing.Point(120, 152);
			this.txtUit.MaxLength = 2;
			this.txtUit.Name = "txtUit";
			this.txtUit.Size = new System.Drawing.Size(32, 29);
			this.txtUit.TabIndex = 1001;
			this.txtUit.Text = "";
			this.txtUit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtUit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUit_KeyDown);
			this.txtUit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectAll_MouseDown);
			this.txtUit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericCheck_KeyPress);
			this.txtUit.Validating += new System.ComponentModel.CancelEventHandler(this.txtUit_Validating);
			this.txtUit.Enter += new System.EventHandler(this.SelectAll_Enter);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(98, 152);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 24);
			this.label1.TabIndex = 10;
			this.label1.Text = "-";
			// 
			// cmdVolgende
			// 
			this.cmdVolgende.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdVolgende.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdVolgende.Location = new System.Drawing.Point(112, 536);
			this.cmdVolgende.Name = "cmdVolgende";
			this.cmdVolgende.TabIndex = 106;
			this.cmdVolgende.TabStop = false;
			this.cmdVolgende.Text = "&Volgende";
			this.cmdVolgende.Click += new System.EventHandler(this.cmdVolgende_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuVolgende,
																					  this.mnuShowStand});
			// 
			// mnuVolgende
			// 
			this.mnuVolgende.Index = 0;
			this.mnuVolgende.Shortcut = System.Windows.Forms.Shortcut.F2;
			this.mnuVolgende.Text = "mnuVolgende";
			this.mnuVolgende.Visible = false;
			this.mnuVolgende.Click += new System.EventHandler(this.mnuVolgende_Click);
			// 
			// mnuShowStand
			// 
			this.mnuShowStand.Index = 1;
			this.mnuShowStand.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.mnuShowStand.Text = "mnuShowStand";
			this.mnuShowStand.Visible = false;
			this.mnuShowStand.Click += new System.EventHandler(this.mnuShowStand_Click);
			// 
			// lblTeam
			// 
			this.lblTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeam.Location = new System.Drawing.Point(0, 32);
			this.lblTeam.Name = "lblTeam";
			this.lblTeam.Size = new System.Drawing.Size(208, 24);
			this.lblTeam.TabIndex = 8;
			this.lblTeam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblUitslag
			// 
			this.lblUitslag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblUitslag.Location = new System.Drawing.Point(0, 80);
			this.lblUitslag.Name = "lblUitslag";
			this.lblUitslag.Size = new System.Drawing.Size(208, 24);
			this.lblUitslag.TabIndex = 1002;
			this.lblUitslag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblTeamNaam
			// 
			this.lblTeamNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeamNaam.Location = new System.Drawing.Point(0, 8);
			this.lblTeamNaam.Name = "lblTeamNaam";
			this.lblTeamNaam.Size = new System.Drawing.Size(208, 24);
			this.lblTeamNaam.TabIndex = 1003;
			this.lblTeamNaam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lboUitslagen
			// 
			this.lboUitslagen.Location = new System.Drawing.Point(0, 328);
			this.lboUitslagen.Name = "lboUitslagen";
			this.lboUitslagen.Size = new System.Drawing.Size(248, 186);
			this.lboUitslagen.TabIndex = 1005;
			// 
			// frmSnelInvoeren
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(248, 601);
			this.Controls.Add(this.lboUitslagen);
			this.Controls.Add(this.txtThuis);
			this.Controls.Add(this.txtWedstrijdNummer);
			this.Controls.Add(this.txtUit);
			this.Controls.Add(this.lblTeamNaam);
			this.Controls.Add(this.lblUitslag);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lblWedstrijd);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdAccept);
			this.Controls.Add(this.cmdVolgende);
			this.Controls.Add(this.lblTeam);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(0, 100);
			this.MaximizeBox = false;
			this.Menu = this.mainMenu1;
			this.MinimizeBox = false;
			this.Name = "frmSnelInvoeren";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Snel Invoeren";
			this.Load += new System.EventHandler(this.frmSnelInvoeren_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region Utility Functions
		int rondeNummer = 0;
		private void UpdateDisplay(int volgNbr)
		{
			if (volgNbr > -1)
			{
				txtThuis.Enabled = true;
				txtUit.Enabled = true;

				// Laat alle wedstrijden zien in de multiline textbox				
				StringBuilder sb = new StringBuilder();
				int lboIndex = 0;
				for (int i = 0; i < da.uitslagRegels.Length; i++)
				{
					sb = new StringBuilder();
					sb.AppendFormat("{0} {1,-10:G} \t- {2,-10:G}\t", 
					da.uitslagRegels[i].WedstrijdNummer.ToString(),
					(da.uitslagRegels[i].TeamThuis + "          ").Substring(0,10),
					(da.uitslagRegels[i].TeamUit + "          ").Substring(0,10));


					if (da.uitslagRegels[i].UitslagThuis == -1)
						txtThuis.Text = string.Empty;
					else
					{
						sb.AppendFormat("{0:#0}", da.uitslagRegels[i].UitslagThuis);
						txtThuis.Text = da.uitslagRegels[i].UitslagThuis.ToString();
						lboIndex = i;
					}
					if (da.uitslagRegels[i].UitslagUit == -1)
						txtUit.Text = string.Empty;
					else
					{
						txtUit.Text =  da.uitslagRegels[i].UitslagUit.ToString();
						sb.AppendFormat(" - {0:#0}", da.uitslagRegels[i].UitslagUit);
					}
					lboUitslagen.Items.Add(sb.ToString());
					lboUitslagen.SelectedIndex = lboUitslagen.Items.Count-1;
				}
				lboUitslagen.SelectedIndex = lboIndex;
				
				txtWedstrijdNummer.Text = da.uitslagRegels[volgNbr].WedstrijdNummer.ToString();
				lblWedstrijd.Text = da.uitslagRegels[volgNbr].TeamThuis 
					+ " - "
					+ da.uitslagRegels[volgNbr].TeamUit;
				
				sb = new StringBuilder();
				if (da.uitslagRegels[volgNbr].UitslagThuis == -1)
					txtThuis.Text = string.Empty;
				else
				{
					sb.AppendFormat("{0:#0}", da.uitslagRegels[volgNbr].UitslagThuis);
					txtThuis.Text = da.uitslagRegels[volgNbr].UitslagThuis.ToString();
				}
				if (da.uitslagRegels[volgNbr].UitslagUit == -1)
					txtUit.Text = string.Empty;
				else
				{
					txtUit.Text =  da.uitslagRegels[volgNbr].UitslagUit.ToString();
					sb.AppendFormat(" - {0:#0}", da.uitslagRegels[volgNbr].UitslagUit);
				}
				lblUitslag.Text = sb.ToString();
				lblTeamNaam.Text = da.poule.TeamNaam;
				lblTeam.Text = "Klasse: " + da.poule.Klasse;

				if (da.uitslagRegels[volgNbr].EigenTeam)
				{
					ShowControls(da.spelers.Length);
				}
				else
					ShowControls(0);
				rondeNummer = da.uitslagRegels[volgNbr].RondeNummer;
				for (int i = 0; i < da.spelers.Length; i++)
				{
					lblNaamSpeler[i].Text = da.spelers[i].SpelerNaam;
					tblPercentage[] p =  da.VulPercentageRecords(da.spelers[i]);
					if (p[rondeNummer] != null)
					{
						if (p[rondeNummer].Gespeeld != -1)
							txtGespeeld[i].Text = p[rondeNummer].Gespeeld.ToString();
						else
							txtGespeeld[i].Text = da.schema.SetsperSpeler.ToString();
						if (p[rondeNummer].Gewonnen != -1)
							txtGewonnen[i].Text = p[rondeNummer].Gewonnen.ToString();
						else
							txtGewonnen[i].Text = string.Empty;
					}
					else
					{
						txtGespeeld[i].Text = da.schema.SetsperSpeler.ToString();
						txtGewonnen[i].Text = string.Empty;
					}
				}
			}
			else
			{
				lblWedstrijd.Text = "Wedstrijd niet gevonden";
				lblUitslag.Text = string.Empty;
				txtThuis.Enabled = false;
				txtUit.Enabled = false;
			}
		}

		private void ShowControls(int aantal)
		{
			for (int i = 0; i < aantal; i++)
			{
				if (lblNaamSpeler[i].Visible == true) continue;
				txtGespeeld[i].Visible = true;
				txtGewonnen[i].Visible = true;
				lblNaamSpeler[i].Visible = true;
			}
			for (int i = aantal; i < maxNbrSpelers; i++)
			{
				if (lblNaamSpeler[i].Visible == false) continue;
				txtGespeeld[i].Visible = false;
				txtGewonnen[i].Visible = false;
				lblNaamSpeler[i].Visible = false;
			}
		}
		#endregion

		#region Accept & Cancel
		protected void cmdAccept_Click(object sender, System.EventArgs e)
		{ 
			try
			{
				da.CommitTransaction(true);
			}
			finally 
			{
				this.Close();
			}
		}
		protected override void OnClosing(CancelEventArgs e)
		{
			try
			{
				if (!e.Cancel && (this.DialogResult == DialogResult.Cancel))
				{
					da.CancelTransaction(true);
				}
			}
			finally 
			{
			}
		}
		#endregion

		#region Enter Field events
		private bool EnteredNumericCharacter(System.Windows.Forms.KeyEventArgs e)
		{
			numberEntered = true;
			// Determine whether the keystroke is a number from the top of the keyboard.
			// Determine whether the keystroke is a number from the keypad.
			if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
				(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
				return numberEntered;
			// Determine whether the keystroke is a backspace.
			if( e.KeyCode != Keys.Back &&
				e.KeyCode != Keys.Enter &&
				e.KeyCode != Keys.Return &&
				e.KeyCode != Keys.Tab)
			{
				// A non-numerical keystroke was pressed.
				// Set the flag to true and evaluate in KeyPress event.
				numberEntered = false;
				return numberEntered;
			}
			return numberEntered;
		}
		#endregion

		#region ZoekEersteVrijeWedstrijd en geef wedstrijdnummer
		/// <summary>
		/// Deze method zoek de eerste vrije wedstrijd vanaf het opgegeven poulenummer
		/// Deze method plaats de teamnaam en klasse nr op het form
		/// </summary>
		/// <param name="lokaalPouleNummer"></param>
		/// <returns>Het wedstrijdnummer of -1 als er geen wedstrijd is gevonden</returns>
		private int ZoekEersteVrijeWedstrijd(int lokaalPouleNummer)
		{
			int orgineelPoulenummer = lokaalPouleNummer;
			bool gevonden = false;
			int volgNbr = 0;
			int aantalPoules = da.dsDataSet1.tblPoule.Count;
			
			while (!gevonden)
			{
				DataRow drv = da.dsDataSet1.tblPoule.Rows[lokaalPouleNummer];
				string teamNaam = drv["TeamNaam"].ToString().Trim();


				int EersteWednbr = int.Parse(drv["EersteWednbr"].ToString().Trim());
			
				VulTabellen(teamNaam);
				int i = 0;
				for (i = 0; i < da.uitslagRegels.Length; i++)
				{
					if (da.uitslagRegels[da.uitslagRegels.Length -1 - i].UitslagThuis != -1)
					{
						if (i == 0) // Laatste wedstrijd
							break;  // we gaan de volgende poule doen
						gevonden = true;
						volgNbr = da.uitslagRegels[da.uitslagRegels.Length - i].WedstrijdNummer;
						break;
					}
				}
				if (i == da.uitslagRegels.Length) // Er waren geen uitslagen voor deze poule.
				{
					gevonden = true;	
					volgNbr = da.uitslagRegels[0].WedstrijdNummer;
				}

				lokaalPouleNummer++;
				if (lokaalPouleNummer >= da.dsDataSet1.tblPoule.Count)
					lokaalPouleNummer = 0;
				if (lokaalPouleNummer == orgineelPoulenummer)
				{
					gevonden = true;
					lokaalPouleNummer = -1;
				}
			}
			if (gevonden)
			{
				lblTeam.Text = da.poule.TeamNaam + "  - Klasse: " + da.poule.Klasse;
				pouleNummer = lokaalPouleNummer;
				return volgNbr;
			}			
			else
			{
				lblTeam.Text = string.Empty;
				return -1;
			}			
		}	
		#endregion	
				
		#region ZoekUitslagRegel en geef volgnbr
		/// <summary>
		/// Deze method zoekt een uitslagregel ahv een wedstrijdnummer
		/// </summary>
		/// <param name="WedstrijdNummer"></param>
		/// <returns>Het volgnr van de uitslagregel</returns>
		private int ZoekUitslagRegel(int WedstrijdNummer)
		{
			bool gevonden = false;
			int volgNbr = 0;
			int aantalPoules = da.dsDataSet1.tblPoule.Count;
			int currentPoule = 0;
			for (currentPoule = 0; currentPoule < aantalPoules; currentPoule++)
			{
				// Ik zoek eerst of het opgegeven wednr in de buurt ligt van
				// het eerste wednr van een poule. Als dat zo is vullen we de 
				// tabellen en gaan we op zoek naar de wedstrijd
				DataRow drv = da.dsDataSet1.tblPoule.Rows[currentPoule];
				string teamNaam = drv["TeamNaam"].ToString().Trim();
				int EersteWednbr = int.Parse(drv["EersteWednbr"].ToString().Trim());
			
				if (EersteWednbr <= WedstrijdNummer && WedstrijdNummer <= EersteWednbr + 50)
				{
					VulTabellen(teamNaam);
					for (int i = 0; i < da.uitslagRegels.Length; i++)
					{
						if (da.uitslagRegels[i].WedstrijdNummer == WedstrijdNummer)
						{
							gevonden = true;
							volgNbr = i;
							break;
						}
					}
				}
				if (gevonden)
					break;
			}
	
			if (gevonden)
			{
				pouleNummer = currentPoule;
				return volgNbr;
			}			
			else
				return -1;
		}	
		#endregion
		
		#region Naar de volgende poule
		int pouleNummer = 0;
		private void cmdVolgende_Click(object sender, System.EventArgs e)
		{
			pouleNummer++;
			if (pouleNummer >= da.dsDataSet1.tblPoule.Count)
				pouleNummer = 0;
			int wedstrijdNbr = ZoekEersteVrijeWedstrijd(pouleNummer);
			int volgnbr = ZoekUitslagRegel(wedstrijdNbr);
			UpdateDisplay(volgnbr);
			txtWedstrijdNummer.Focus();
		}

		private void mnuVolgende_Click(object sender, System.EventArgs e)
		{
			cmdVolgende.PerformClick();
			txtWedstrijdNummer.Focus();
		}
		#endregion

		#region Afhandeling Database
		private void UpdatePercentageRecord(TextBox sender)
		{
			string type = sender.Name.Substring(0,8);
			int row = int.Parse(StringUtil.Right(sender.Name,1));
			string naam = lblNaamSpeler[row].Text;
						
			DataRow drRecord = da.dsDataSet1.tblPercentage.FindBySpelerNaamWednbr(naam, rondeNummer);
			if (drRecord == null)
				drRecord = CreateNewPercentageRecord(naam, rondeNummer);
				
			if (type == "Gespeeld" && sender.Text != string.Empty)
				drRecord["Gespeeld"] = int.Parse(txtGespeeld[row].Text);

			if (type == "Gewonnen" && sender.Text != string.Empty)
			{
				drRecord["Gespeeld"] = int.Parse(txtGespeeld[row].Text);
				drRecord["Gewonnen"] = int.Parse(txtGewonnen[row].Text);
			}
			da.daPercentage.Update(da.dsDataSet1, "tblPercentage");
		}

		private DataRow CreateNewPercentageRecord(string TeamNaam, int RowNumber)
		{
			dsPoule.tblPercentageRow drNew;
			drNew = (dsPoule.tblPercentageRow) da.dsDataSet1.tblPercentage.NewRow();

			drNew["SpelerNaam"] = TeamNaam;
			drNew["Wednbr"] = RowNumber;
			drNew["Gespeeld"] = -1;
			drNew["Gewonnen"] = -1;

			da.dsDataSet1.tblPercentage.AddtblPercentageRow(drNew);
			return drNew;
		}

//		private DataRow CreateNewUitslagRecord(string TeamNaam, int RowNumber)
//		{
//			dsPoule.tblUitslagRow drNew;
//			drNew = (dsPoule.tblUitslagRow) da.dsDataSet1.tblUitslag.NewRow();
//
//			drNew["WedNbr"] = RowNumber;
//			drNew["TeamNaam"] = TeamNaam;
//			drNew["Opmerking"] = string.Empty;
//
//			drNew["Thuis"] = -1;
//			drNew["Uit"] = -1;
//			drNew["Datum"] = string.Empty;
//
//			da.dsDataSet1.tblUitslag.AddtblUitslagRow(drNew);
//			return drNew;
//		}
		#endregion

		#region Afhandeling txtWedstrijdNummer
		private void txtWedstrijdNummer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (!EnteredNumericCharacter(e)) return;
			switch (e.KeyCode)
			{
				case Keys.Enter :
				case Keys.Tab :
					int i = ZoekUitslagRegel(int.Parse(((TextBox)sender).Text));
					UpdateDisplay(i);
					// Naar de volgende control
					if (i == -1)
						((TextBox)sender).Focus();
					else
						((TextBox)sender).Parent.SelectNextControl(ActiveControl,true, true, false,true);
					return;
			}
		}
		#endregion

		#region Afhandeling txtThuis		
		private void txtThuis_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (!EnteredNumericCharacter(e)) return;
				switch (e.KeyCode)
				{
					case Keys.Enter :
					case Keys.Tab :
						// Naar de volgende control; Ook om validating af te dwingen
						((TextBox)sender).Parent.SelectNextControl(ActiveControl,true, true, false,true);
						return;
				}
			}
			catch (Exception ex)
			{
				Utils.ShowMessage(ex);
			}
		}
		private void txtThuis_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				TextBox box = (TextBox)sender;
				int wedstrijdNbr = int.Parse(txtWedstrijdNummer.Text);
				int puntenThuis = Utils.IsNumeric(box.Text) ? int.Parse(box.Text) : -1;
				if (puntenThuis == -1)
					box.Text = string.Empty;
				else
				{
					if (puntenThuis > da.schema.SetsperWed)
					{
						box.Text = da.schema.SetsperWed.ToString();
						puntenThuis = da.schema.SetsperWed;
					}
					txtUit.Text = ((int)(da.schema.SetsperWed - puntenThuis)).ToString();
				}

				int puntenUit = Utils.IsNumeric(txtUit.Text) ? int.Parse(txtUit.Text) : -1;
				int nbr = wedstrijdNbr - da.poule.EersteWednbr;
				if (puntenThuis == -1)
					txtThuis.Text = string.Empty;
				if (puntenUit == -1)
					txtUit.Text = string.Empty;

				DataRow drRecord = da.dsDataSet1.tblUitslag.FindByTeamNaamWedNbr(da.poule.TeamNaam, nbr);

				if (drRecord == null)
					drRecord = da.CreateNewUitslagRecord(da.poule.TeamNaam, nbr);

				drRecord["Thuis"] = puntenThuis;
				drRecord["Uit"] = puntenUit;
				da.daUitslag.Update(da.dsDataSet1, "tblUitslag");
			}
			catch (Exception ex)
			{
				Utils.ShowMessage(ex);
			}
		}
		#endregion

		#region Afhandeling txtUit
		private void txtUit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				if (!EnteredNumericCharacter(e)) return;
				switch (e.KeyCode)
				{
					case Keys.Enter :
					case Keys.Tab :
						// We gebruiken geen NextControl omdat de UpdateDisplay de percentage textboxen
						// maakt voordat wedstrijdnummer focus heeft gekregen. De focus komt dan bij percentage
						txtWedstrijdNummer.Focus();
						return;
				}
			}			
			catch (Exception ex)
			{
				Utils.ShowMessage(ex);
			}
		}
		private void txtUit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				TextBox box = (TextBox)sender;
				int puntenUit = Utils.IsNumeric(box.Text) ? int.Parse(txtUit.Text) : -1;
				if (puntenUit == -1)
					txtUit.Text = string.Empty;
				
				if (puntenUit > da.schema.SetsperWed)
				{
					box.Text = da.schema.SetsperWed.ToString();
					puntenUit = da.schema.SetsperWed;
				}

				int wedstrijdNbr = int.Parse(txtWedstrijdNummer.Text);
				int puntenThuis = Utils.IsNumeric(txtThuis.Text) ? int.Parse(txtThuis.Text) : -1;
				if (puntenThuis == -1)
					txtThuis.Text = string.Empty;
				
				int nbr = wedstrijdNbr - da.poule.EersteWednbr;
				DataRow drRecord = da.dsDataSet1.tblUitslag.FindByTeamNaamWedNbr(da.poule.TeamNaam, nbr);

				if (drRecord == null)
					drRecord = da.CreateNewUitslagRecord(da.poule.TeamNaam, nbr);

				drRecord["Thuis"] = puntenThuis;
				drRecord["Uit"] = puntenUit;
				da.daUitslag.Update(da.dsDataSet1, "tblUitslag");

				if (wedstrijdNbr+1 < da.poule.EersteWednbr + 
					da.uitslagRegels.Length)
				{
					int volgnbr = ZoekUitslagRegel(wedstrijdNbr+1);
					UpdateDisplay(volgnbr);
				}
				else
					cmdVolgende.PerformClick();

			}
			catch (Exception ex)
			{
				Utils.ShowMessage(ex);
			}
		}
		#endregion

		#region Afhandeling txtGespeeld
		private void txtGespeeld_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (!EnteredNumericCharacter(e)) return;
			switch (e.KeyCode)
			{
				case Keys.Enter :
					//case Keys.Return :
				case Keys.Tab :
					TextBox box = (TextBox)sender;
					if (box.Text.Length < 1) box.Text = string.Empty;
					box.Parent.SelectNextControl(ActiveControl,true, true, false,true);
					return;
			}
		}
		private void textBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			UpdatePercentageRecord((TextBox)sender);
		
		}


		#endregion

		#region Afhandeling txtGewonnen
		private void txtGewonnen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (!EnteredNumericCharacter(e)) return;
			switch (e.KeyCode)
			{
				case Keys.Enter :
				case Keys.Tab :
					TextBox box = (TextBox)sender;
					if (box.Text.Length < 1) box.Text = string.Empty;
					box.Parent.SelectNextControl(ActiveControl,true, true, false,true);
					return;
			}
		}
		#endregion

		frmStand formStand = null;
		private void mnuShowStand_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			if (formStand == null || formStand.IsDisposed)
			{
				formStand = new frmStand();
				formStand.Show();
			}
			VulTabellen(lblTeamNaam.Text);
			formStand.PrintStandRegels(da.standRegels);
			formStand.Activate();
			this.Cursor = Cursors.Arrow;	
		}
	}
}
