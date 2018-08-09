using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Util.Forms
{
	/// <summary>
	/// Summary description for DatePicker.
	/// </summary>
	public class DatePicker : System.Windows.Forms.Form
	{
		/// <summary>
		/// Summary description for DatePicker.
		/// DatePicker is a Pop-Up form for selecting a date
		/// </summary>
		/// <example>
		/// Typical usage would be:
		/// <code lang="C#">
		/// class SomeFancyForm : Form
		/// {
		///   private SomeFancyForm()
		///   {
		///		private void txtExample_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		///		{
		///			TextBox tb = (TextBox)sender;
		///			if (e.Button == MouseButtons.Right)
		///			{
		///				System.Drawing.Point loc = new Point(e.X, e.Y);
		///				loc = tb.Parent.PointToScreen(tb.Location);
		///				loc.Offset(0,tb.Height + 1);
		///				using (DatePicker dp = new DatePicker())
		///				{
		///					dp.Location = loc;
		///					DialogResult res = dp.ShowDialog(this);
		///					if (DialogResult.OK == res)
		///						tb.Text = dp.SelectedDate.ToShortDateString();
		///				}
		///			}
		///		}
		/// }
		/// </code>
		/// </example>
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Button cmdOK;
		private System.Windows.Forms.Button cmdCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DatePicker()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.monthCalendar1.Top = 2;
			this.monthCalendar1.Left = 2;
			this.Height = this.monthCalendar1.Height + this.cmdOK.Height + 4;
			
			this.cmdCancel.Top = this.monthCalendar1.Bottom;
			this.cmdCancel.Left = 0;
			this.cmdCancel.Width = 50;

			this.cmdOK.Top = this.monthCalendar1.Bottom;
			this.cmdOK.Left = 49;
			this.cmdOK.Width = this.Width -50;

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
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
			this.monthCalendar1.Location = new System.Drawing.Point(8, 8);
			this.monthCalendar1.MaxSelectionCount = 1;
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.ShowWeekNumbers = true;
			this.monthCalendar1.TabIndex = 0;
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Location = new System.Drawing.Point(104, 168);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Size = new System.Drawing.Size(104, 23);
			this.cmdOK.TabIndex = 1;
			this.cmdOK.Text = "&OK";
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Location = new System.Drawing.Point(8, 168);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Size = new System.Drawing.Size(96, 24);
			this.cmdCancel.TabIndex = 2;
			this.cmdCancel.Text = "&Cancel";
			// 
			// DatePicker
			// 
			this.AcceptButton = this.cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ControlDark;
			this.CancelButton = this.cmdCancel;
			this.ClientSize = new System.Drawing.Size(208, 200);
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.monthCalendar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DatePicker";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.ResumeLayout(false);

		}
		#endregion
	
		/// <summary>
		/// Gets or sets the selected date.
		/// </summary>
		/// <value></value>
		public DateTime SelectedDate
		{
			get {return this.monthCalendar1.SelectionStart;}
			set {this.monthCalendar1.SelectionStart = value;}
		}
	}
}
