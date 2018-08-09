using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace Util.Forms
{
	/// <summary>
	/// Summary description for SplashForm.
	/// </summary>
	/// <example>
	/// Typical usage would be:
	/// <code lang="C#">
	/// class SomeFancyForm : Form
	/// {
	///   private SomeFancyForm()
	///   {
	///     SplashForm sf = new SplashForm("SomeFancyApp");
	///     sf.Show();
	///     sf.Refresh();
	///     //Do constuctor stuff
	///     sf.Dispose()
	///   }
	/// }  
	/// </code>
	/// </example>
	public class SplashForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblInterpay;
		private System.Windows.Forms.Label lblMainTitle;
		private System.Windows.Forms.Label lblSubTitle;
		private System.Windows.Forms.Panel pnlWhite;
		private System.Windows.Forms.Label lblProgress;
		private System.ComponentModel.IContainer components = null;
		private int displayTime = 0;
		private DateTime disposeTime = DateTime.Now;

		/// <summary>
		/// Initialise a new SplashForm with the default title and subtitle.
		/// </summary>
		public SplashForm() : this("MainTitle"){}
		/// <summary>
		/// Initialise a new SplashForm with the specified title and the default subtitle
		/// </summary>
		public SplashForm(string MainTitle) : this (MainTitle, "A Mosaic Product"){}
		/// <summary>
		/// Initialise a new SplashForm with the specified title and subtitle
		/// </summary>
		public SplashForm(string MainTitle, string SubTitle) : this (MainTitle, SubTitle, 0){}
		/// <summary>
		/// Initialise a new SplashForm with the specified title, default subtitle, and specified minimum display time
		/// </summary>
		public SplashForm(string MainTitle, int displayTime) : this (MainTitle, "A Mosaic Product", displayTime){}
		/// <summary>
		/// Initialise a new SplashForm with the specified title, subtitle, and minimum display time
		/// </summary>
		public SplashForm(string MainTitle, string SubTitle, int displayTime)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            lblMainTitle.Text = MainTitle;
			lblSubTitle.Text = SubTitle;

			pnlWhite.Left = 4;
			pnlWhite.Top = 4;
			if (lblMainTitle.Right > pnlWhite.Right)
				pnlWhite.Width = lblMainTitle.Width + lblMainTitle.Left;
			pnlWhite.Height = 248 + lblProgress.Height;
			lblProgress.Text = string.Empty;
			this.Height = pnlWhite.Height + 8;
			this.Width = pnlWhite.Width + 8;
			lblInterpay.Top = lblMainTitle.Top - lblInterpay.Height;
			lblSubTitle.Top = lblMainTitle.Bottom;
			if (displayTime > 0)
				this.displayTime = displayTime;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				// Sleep a while when instructed to do so.
				if (DateTime.Compare(DateTime.Now, disposeTime) < 0)	Thread.Sleep(disposeTime.Subtract(DateTime.Now));
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
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lblMainTitle = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblSubTitle = new System.Windows.Forms.Label();
			this.pnlWhite = new System.Windows.Forms.Panel();
			this.lblProgress = new System.Windows.Forms.Label();
			this.lblInterpay = new System.Windows.Forms.Label();
			this.pnlWhite.SuspendLayout();
			this.SuspendLayout();
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(94, 188);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(196, 17);
			this.label6.TabIndex = 5;
			this.label6.Text = "Kielen Automatisering";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Gray;
			this.label5.Location = new System.Drawing.Point(94, 171);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(204, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "This product is licensed to                                           ";
			// 
			// lblMainTitle
			// 
			this.lblMainTitle.AutoSize = true;
			this.lblMainTitle.BackColor = System.Drawing.Color.White;
			this.lblMainTitle.Font = new System.Drawing.Font("Arial Black", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMainTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblMainTitle.Location = new System.Drawing.Point(111, 68);
			this.lblMainTitle.Name = "lblMainTitle";
			this.lblMainTitle.Size = new System.Drawing.Size(227, 56);
			this.lblMainTitle.TabIndex = 3;
			this.lblMainTitle.Text = "Stand.Net";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Maroon;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(85, 264);
			this.panel2.TabIndex = 1;
			// 
			// lblSubTitle
			// 
			this.lblSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblSubTitle.BackColor = System.Drawing.Color.White;
			this.lblSubTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSubTitle.Location = new System.Drawing.Point(102, 128);
			this.lblSubTitle.Name = "lblSubTitle";
			this.lblSubTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblSubTitle.Size = new System.Drawing.Size(325, 24);
			this.lblSubTitle.TabIndex = 2;
			this.lblSubTitle.Text = "Keeping Score";
			// 
			// pnlWhite
			// 
			this.pnlWhite.BackColor = System.Drawing.Color.White;
			this.pnlWhite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlWhite.Controls.Add(this.lblProgress);
			this.pnlWhite.Controls.Add(this.label6);
			this.pnlWhite.Controls.Add(this.label5);
			this.pnlWhite.Controls.Add(this.lblInterpay);
			this.pnlWhite.Controls.Add(this.lblMainTitle);
			this.pnlWhite.Controls.Add(this.panel2);
			this.pnlWhite.Controls.Add(this.lblSubTitle);
			this.pnlWhite.Location = new System.Drawing.Point(3, 3);
			this.pnlWhite.Name = "pnlWhite";
			this.pnlWhite.Size = new System.Drawing.Size(435, 266);
			this.pnlWhite.TabIndex = 4;
			// 
			// lblProgress
			// 
			this.lblProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lblProgress.Location = new System.Drawing.Point(85, 244);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(348, 20);
			this.lblProgress.TabIndex = 6;
			this.lblProgress.Text = "Progress here...";
			// 
			// lblInterpay
			// 
			this.lblInterpay.BackColor = System.Drawing.Color.White;
			this.lblInterpay.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInterpay.Location = new System.Drawing.Point(94, 34);
			this.lblInterpay.Name = "lblInterpay";
			this.lblInterpay.Size = new System.Drawing.Size(162, 43);
			this.lblInterpay.TabIndex = 2;
			this.lblInterpay.Text = "Kielen\'s";
			this.lblInterpay.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// SplashForm
			// 
			this.AutoScaleMode = AutoScaleMode.Inherit;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(443, 273);
			this.Controls.Add(this.pnlWhite);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "SplashForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSplash";
			this.pnlWhite.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>Show progress on the splash form</summary>
		/// <param name="text"></param>
		public void ShowProgress(string text)
		{
			lblProgress.Text = text;
		}

		/// <summary>Refresh the display of the SplashForm. The display time is reset as well.</summary>
		public override void Refresh()
		{
			if (displayTime > 0)
				disposeTime = DateTime.Now.AddSeconds(displayTime);
			base.Refresh();
		}
	}
}
