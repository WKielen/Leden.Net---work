using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Util.Forms
{
	/// <summary>
	/// The ShowText format is a DialogBox type of form, suitable for showing large amounts of text.
	/// The text will be selectable, but otherwise resembles <see cref="MessageBox"/> very much.
	/// </summary>
	/// <remarks>
	/// </remarks>
	public class ShowText : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.CheckBox chkWrapText;

		#region static
		static Icon iconInformation;
		static Icon iconWarning;
		static Icon iconError;
		static Icon iconQuestion;
		static System.IO.Stream GetIconStream(string iconName)
		{
			return System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Util.Icons." + iconName);
		}
		static ShowText()
		{
			iconInformation = new Icon(GetIconStream("Information.ico"));
			iconWarning = new Icon(GetIconStream("Warning.ico"));
			iconError= new Icon(GetIconStream("Error.ico"));
			iconQuestion = new Icon(GetIconStream("HelpBalloon.ico"));
		}
		#endregion

		private System.ComponentModel.IContainer components = null;
        
		/// <summary>Get or set the text inside the dialog.</summary>
		public string Message { get { return textBox1.Text; } set { textBox1.Text = value; } }

		/// <summary>Initialise a new ShowText instance.</summary>
		public ShowText()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>Clean up any resources being used.</summary>
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkWrapText = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 8);
            this.textBox1.MaxLength = 1000000;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(600, 344);
            this.textBox1.TabIndex = 1;
            this.textBox1.WordWrap = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(248, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 24);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            // 
            // chkWrapText
            // 
            this.chkWrapText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWrapText.Location = new System.Drawing.Point(16, 360);
            this.chkWrapText.Name = "chkWrapText";
            this.chkWrapText.Size = new System.Drawing.Size(104, 24);
            this.chkWrapText.TabIndex = 2;
            this.chkWrapText.Text = "&Wrap Text";
            this.chkWrapText.CheckedChanged += new System.EventHandler(this.chkWrapText_CheckedChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Location = new System.Drawing.Point(464, 360);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(120, 24);
            this.btnCopy.TabIndex = 0;
            this.btnCopy.Text = "&Copy to Clipboard";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // ShowText
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(600, 390);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkWrapText);
            this.Controls.Add(this.btnCopy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(280, 240);
            this.Name = "ShowText";
            this.Text = "ShowText";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>Show a ShowText dialog with the specified text.</summary>
		public static DialogResult Show(string text)
		{
			return Show(null, text, null, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		/// <summary>Show a ShowText dialog with the specified text, and the specified owner.</summary>
		public static DialogResult Show(IWin32Window owner, string text)
		{
			return Show(owner, text, null, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		/// <summary>Displays a message box with specified text and caption.</summary>
		public static DialogResult Show(string text, string caption)
		{
			return Show(null, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		/// <summary>Displays a message box in front of the specified object and with the specified text and caption.</summary>
		public static DialogResult Show(IWin32Window owner, string text, string caption)
		{
			return Show(owner, text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		/// <summary>Displays a message box with specified text, caption, and buttons.</summary>
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
		{
			return Show(null, text, caption, buttons, MessageBoxIcon.None);
		}

		/// <summary>Displays a message box in front of the specified object and with the specified text, caption, and buttons.</summary>
		public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
		{
			return Show(owner, text, caption, buttons, MessageBoxIcon.None);
		}

		/// <summary>Displays a message box with specified text, caption, buttons, and icon.</summary>
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return Show(null, text, caption, buttons, icon);
		}

		/// <summary>Displays a message box in front of the specified object and with the specified text, caption, buttons, and icon.</summary>
		public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{ 
			using(ShowText st = new ShowText())
			{
				st.Message = text;
				if (caption != null)
					st.Text = caption;

				// Set the dialogbox/taskbar icon to the icon of the owning form.
				if (owner != null)
				{
					Form f = owner as Form;
					if (f == null)
					{
						Control c = owner as Control;
						if (c != null)
							f = c.FindForm();
					}
					if (f != null && f.Icon != null)
						st.Icon = (Icon) f.Icon.Clone();
				}
			
				// Determine the MessageBoxIcon to use
				Icon iconInstance = null;
				switch(icon)
				{
					case MessageBoxIcon.Error:			iconInstance = iconError;		break;
					case MessageBoxIcon.Information:	iconInstance = iconInformation; break;
					case MessageBoxIcon.Question:		iconInstance = iconQuestion;	break;
					case MessageBoxIcon.Warning:		iconInstance = iconWarning;		break;
				}
				if (iconInstance != null)
				{
					System.Windows.Forms.PictureBox pb = new PictureBox();
					pb.SizeMode = PictureBoxSizeMode.Normal;
					pb.Size = iconInstance.Size;
					pb.Image = iconInstance.ToBitmap();
					pb.Location = new Point(st.textBox1.Left + 2, st.textBox1.Top + (st.textBox1.Height / 2) - (pb.Height / 2));
					pb.Anchor = AnchorStyles.Left;
					int shiftAmount = pb.Size.Width + 5;
					st.textBox1.Left += shiftAmount;
					st.textBox1.Width -= shiftAmount;
					st.Controls.Add(pb);
				}

				// Show the DialogBox.
				
                DialogResult dr = st.ShowDialog(owner);
				return dr;
			}
		}

		private void chkWrapText_CheckedChanged(object sender, System.EventArgs e)
		{
			textBox1.WordWrap = chkWrapText.Checked;
		}

		private void btnCopy_Click(object sender, System.EventArgs e)
		{
			if(textBox1.SelectedText == "")
				Clipboard.SetDataObject(textBox1.Text);
			else
				Clipboard.SetDataObject(textBox1.SelectedText);
		}
 	}
}
