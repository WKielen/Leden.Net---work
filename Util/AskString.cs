using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Util.Forms
{
	/// <summary>
	/// Simnple form that asks for a string input
	/// </summary>
	public class AskString : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label lblPrompt;
		private System.Windows.Forms.TextBox txtAnswer;
		private System.Windows.Forms.Button btnCancel;

		private System.ComponentModel.Container components = null;
		private AskString()
		{
			InitializeComponent();
		}

		private AskString(string title, string prompt, string original, bool multiLine)
		{
			InitializeComponent();

			this.Text = title;
			lblPrompt.Text = prompt; 
			txtAnswer.Text = original == null ? string.Empty : original;
			txtAnswer.Select(0,0);

			if (multiLine)
			{
				txtAnswer.Multiline = true;
				txtAnswer.ScrollBars = ScrollBars.Vertical;
				txtAnswer.AcceptsReturn = true;
				txtAnswer.WordWrap = true;
				this.Height += 10 * txtAnswer.Height;	// Will automatically grow the textbox.
			}
		}

		public static string Ask(IWin32Window owner, string title, string prompt, string original)
		{
			return Ask(owner, title, prompt, original, false); 
		}
		public static string Ask(IWin32Window owner, string title, string prompt, string original, bool multiLine)
		{
			return Ask(owner, title, prompt, original, multiLine, false); 
		}
		public static string Ask(IWin32Window owner, string title, string prompt, string original, bool multiLine, bool fixedSizeFont)
		{
			AskString ask = new AskString(title, prompt, original, multiLine);
			if (fixedSizeFont)
				ask.txtAnswer.Font = new Font(FontFamily.GenericMonospace, ask.Font.SizeInPoints, ask.Font.Style);

			DialogResult dr = ask.ShowDialog(owner);

			if (dr == DialogResult.Cancel) return original;

			string result = ask.txtAnswer.Text;
			ask.Dispose();
			return result;
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
			this.lblPrompt = new System.Windows.Forms.Label();
			this.txtAnswer = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblPrompt
			// 
			this.lblPrompt.Location = new System.Drawing.Point(13, 14);
			this.lblPrompt.Name = "lblPrompt";
			this.lblPrompt.Size = new System.Drawing.Size(247, 14);
			this.lblPrompt.TabIndex = 0;
			this.lblPrompt.Text = "lblPrompt";
			// 
			// txtAnswer
			// 
			this.txtAnswer.AcceptsReturn = true;
			this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtAnswer.Location = new System.Drawing.Point(13, 28);
			this.txtAnswer.Name = "txtAnswer";
			this.txtAnswer.Size = new System.Drawing.Size(323, 20);
			this.txtAnswer.TabIndex = 1;
			this.txtAnswer.Text = "txtAnswer";
			this.txtAnswer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnswer_KeyPress);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(236, 55);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(47, 21);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(289, 55);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(47, 21);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			// 
			// AskString
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(344, 86);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtAnswer);
			this.Controls.Add(this.lblPrompt);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(176, 112);
			this.Name = "AskString";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AskString";
			this.ResumeLayout(false);

		}
		#endregion

		private void txtAnswer_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				btnOK.PerformClick(); 
				e.Handled = true;
			}
		}
	}
}

