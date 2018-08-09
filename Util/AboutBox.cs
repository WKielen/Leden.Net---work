using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Util.Forms
{
	/// <summary>
	/// Summary description for AboutBox.
	/// </summary>
	public class AboutBox : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblProductName;
		private System.Windows.Forms.TextBox txtLicensed;
		private System.Windows.Forms.Label lblLicensed;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnSystemInfo;
		private System.Windows.Forms.Label lblAcknowledgements;
		private System.Windows.Forms.Label lblDotNetVersion;
		private System.Windows.Forms.Label lblWarning;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtAcknowledgements;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private AboutBox()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			try
			{
				Assembly thisassembly = Assembly.GetEntryAssembly();
				if (thisassembly != null)
					FillPropertiesFromAssembly(thisassembly);
			} 
			catch{}
		}
		public AboutBox(Form aboutApplicationForm)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Assembly thisassembly;
			if (aboutApplicationForm != null)
			{
				thisassembly = aboutApplicationForm.GetType().Assembly;
				this.Text = "About " + aboutApplicationForm.Text;
				this.Icon = aboutApplicationForm.Icon;
			}
			else
				thisassembly = Assembly.GetEntryAssembly();
			if (thisassembly != null)
				FillPropertiesFromAssembly(thisassembly);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtLicensed = new System.Windows.Forms.TextBox();
            this.lblLicensed = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSystemInfo = new System.Windows.Forms.Button();
            this.lblAcknowledgements = new System.Windows.Forms.Label();
            this.lblDotNetVersion = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAcknowledgements = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(96, 9);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(367, 37);
            this.lblProductName.TabIndex = 1;
            this.lblProductName.Text = "ProductName";
            // 
            // txtLicensed
            // 
            this.txtLicensed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLicensed.Location = new System.Drawing.Point(96, 225);
            this.txtLicensed.Multiline = true;
            this.txtLicensed.Name = "txtLicensed";
            this.txtLicensed.ReadOnly = true;
            this.txtLicensed.Size = new System.Drawing.Size(367, 46);
            this.txtLicensed.TabIndex = 2;
            this.txtLicensed.Text = "User\r\nCompany";
            this.txtLicensed.WordWrap = false;
            // 
            // lblLicensed
            // 
            this.lblLicensed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLicensed.Location = new System.Drawing.Point(96, 207);
            this.lblLicensed.Name = "lblLicensed";
            this.lblLicensed.Size = new System.Drawing.Size(422, 18);
            this.lblLicensed.TabIndex = 3;
            this.lblLicensed.Text = "This product is licensed to:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(367, 280);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 27);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSystemInfo
            // 
            this.btnSystemInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSystemInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemInfo.Location = new System.Drawing.Point(96, 280);
            this.btnSystemInfo.Name = "btnSystemInfo";
            this.btnSystemInfo.Size = new System.Drawing.Size(90, 27);
            this.btnSystemInfo.TabIndex = 5;
            this.btnSystemInfo.Text = "&System Info";
            this.btnSystemInfo.Click += new System.EventHandler(this.btnSystemInfo_Click);
            // 
            // lblAcknowledgements
            // 
            this.lblAcknowledgements.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblAcknowledgements.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcknowledgements.Location = new System.Drawing.Point(96, 138);
            this.lblAcknowledgements.Name = "lblAcknowledgements";
            this.lblAcknowledgements.Size = new System.Drawing.Size(432, 19);
            this.lblAcknowledgements.TabIndex = 7;
            this.lblAcknowledgements.Text = "Acknowledgements:";
            // 
            // lblDotNetVersion
            // 
            this.lblDotNetVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDotNetVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDotNetVersion.Location = new System.Drawing.Point(96, 46);
            this.lblDotNetVersion.Name = "lblDotNetVersion";
            this.lblDotNetVersion.Size = new System.Drawing.Size(367, 27);
            this.lblDotNetVersion.TabIndex = 8;
            this.lblDotNetVersion.Text = "Microsoft .Net Framework Version";
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWarning.Location = new System.Drawing.Point(96, 308);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(367, 74);
            this.lblWarning.TabIndex = 9;
            this.lblWarning.Text = resources.GetString("lblWarning.Text");
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(96, 83);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(367, 46);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Assembly Description";
            // 
            // txtAcknowledgements
            // 
            this.txtAcknowledgements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAcknowledgements.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcknowledgements.Location = new System.Drawing.Point(96, 157);
            this.txtAcknowledgements.Multiline = true;
            this.txtAcknowledgements.Name = "txtAcknowledgements";
            this.txtAcknowledgements.ReadOnly = true;
            this.txtAcknowledgements.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAcknowledgements.Size = new System.Drawing.Size(367, 55);
            this.txtAcknowledgements.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 326);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AboutBox
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(472, 378);
            this.Controls.Add(this.txtAcknowledgements);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblDotNetVersion);
            this.Controls.Add(this.lblAcknowledgements);
            this.Controls.Add(this.btnSystemInfo);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLicensed);
            this.Controls.Add(this.txtLicensed);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(413, 425);
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "About Your Application";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void btnSystemInfo_Click(object sender, System.EventArgs e)
		{
			string wininfoexe = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonProgramFiles), @"Microsoft Shared\MSInfo\msinfo32.exe"); //C:\Program Files\Common Files\
			string consoleinfoexe = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "SystemInfo.exe");
			if (System.IO.File.Exists(wininfoexe))
				Process.Start(wininfoexe);
			else if (System.IO.File.Exists(consoleinfoexe))
			{
				ProcessStartInfo psi = new ProcessStartInfo(consoleinfoexe);
				psi.CreateNoWindow = true;
				psi.ErrorDialog = false;
				psi.RedirectStandardError = false;
				psi.RedirectStandardOutput = true;
				psi.WindowStyle = ProcessWindowStyle.Hidden;
				psi.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
				psi.UseShellExecute = false;

				Process proc = System.Diagnostics.Process.Start(psi);
				string text = proc.StandardOutput.ReadToEnd();
				ShowText.Show(this, text);
			}
			else
                MessageBox.Show("System Information can not be displayed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		private void FillPropertiesFromAssembly(Assembly ass)
		{
			if (ass == null)
				return;

            // Get the build date

            string filePath = System.Reflection.Assembly.GetCallingAssembly().Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;
            byte[] b = new byte[2048];
            System.IO.Stream s = null;

            try
            {
                s = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            int i = System.BitConverter.ToInt32(b, c_PeHeaderOffset);
            int secondsSince1970 = System.BitConverter.ToInt32(b, i + c_LinkerTimestampOffset);
            DateTime buildDate = new DateTime(1970, 1, 1, 0, 0, 0);
            buildDate = buildDate.AddSeconds(secondsSince1970);
            buildDate = buildDate.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(buildDate).Hours);



			foreach (object attr in ass.GetCustomAttributes(true))
			{
				AssemblyCompanyAttribute aca = attr as AssemblyCompanyAttribute;
				if (aca != null && aca.Company != null && aca.Company.Length != 0)
					Company = aca.Company;
				AssemblyCopyrightAttribute acra = attr as AssemblyCopyrightAttribute;
				if (acra != null && acra.Copyright != null && acra.Copyright.Length != 0)				
					Copyright = acra.Copyright;
				AssemblyTitleAttribute ata = attr as AssemblyTitleAttribute;
				if (ata != null && ata.Title != null && ata.Title.Length != 0)
					ApplicationName = ata.Title;
				AssemblyDescriptionAttribute ada = attr as AssemblyDescriptionAttribute;
				if (ada != null && ada.Description != null && ada.Description.Length != 0)
					Description = ada.Description;
			}
            Version = ass.GetName(true).Version.ToString() + " / " + buildDate.ToShortDateString() + " / " + filePath;
		}
		protected override void OnVisibleChanged(EventArgs e)
		{
			lblProductName.Text = ApplicationName + "     Version " + Version + Environment.NewLine + Copyright;
			lblDotNetVersion.Text = string.Format("Microsoft .Net Framework {0}.{1}     Version {2}", Environment.Version.Major, Environment.Version.Minor, Assembly.GetExecutingAssembly().ImageRuntimeVersion);
			lblDescription.Text = Description;

			if (Ackowledgements == null || Ackowledgements.Length == 0)
			{
				lblAcknowledgements.Visible = false;
				txtAcknowledgements.Visible = false;
			}
			else
			{
				lblAcknowledgements.Visible = true;
				txtAcknowledgements.Visible = true;
				txtAcknowledgements.Text = Ackowledgements;
				txtAcknowledgements.Select(0,0);
			}
			txtLicensed.Text = Environment.UserName + Environment.NewLine + Environment.UserDomainName;
			txtLicensed.Select(0,0);
			base.OnVisibleChanged (e);
		}

		private string _ackowledgements;
		public string Ackowledgements
		{
			get { return _ackowledgements; }
			set { _ackowledgements = value; }
		}
		private string _applicationName;
		public string ApplicationName
		{
			get { return _applicationName; }
			set { _applicationName = value; }
		}
		private string _company = "Kielen Automatisering";
		public string Company
		{
			get { return _company; }
			set { _company = value; }
		}
		private string _copyright = "© 2005 Kielen Automatisering. All rights reserved";
		public string Copyright
		{
			get { return _copyright; }
			set { _copyright = value; }
		}
		private string _description;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		private string _version = "0.0.0.0";
		public string Version
		{
			get { return _version; }
			set { _version = value; }
		}
		public Image Image
		{
			get { return pictureBox1.Image; } 
			set { pictureBox1.Image = value; }
		}
	}
}
