using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using Util.Text;

namespace Util.Forms
{
	/// <summary>
	/// Some general routines to easy GUI development: OpenFile, SaveFile, ExceptionMessageBox, SetEditControlTabs
	/// </summary>
	public class GuiRoutines
	{
		private GuiRoutines(){}

		#region Set FlatStyle to FlatStyle.System for all (child) controls

		/// <summary>Sets the FlatStyle property of supported controls to <see cref="FlatStyle.System" />. (Recursive)</summary>
		/// <param name="controls">The control collection to change</param>
		/// <example>
		/// <code lang="C#">
		/// private class Form1 : System.Windows.Forms.Form
		/// {
		/// static Main()
		/// {
		/// Application.EnableVisualStyles();
		/// Application.DoEvents();
		/// Application.Run(new Form1());
		/// }
		/// private Form1()
		/// {
		/// // Add your controls here
		/// }
		/// protected override OnLoad(EventArgs e)
		/// {
		/// Mosaic.Common.Windows.Forms.GuiRoutines.SetFlatStyle(this.Controls, FlatStyle.System);
		/// }
		/// }
		/// </code></example>
		public static void SetFlatStyle(System.Windows.Forms.Control.ControlCollection controls)

		{

			SetFlatStyle(controls, FlatStyle.System);

		}

		/// <summary>Sets the FlatStyle property of supported controls to the specified <see cref="FlatStyle" />. (Recursive)</summary>
		/// <param name="controls">The control collection to change</param>
		/// <param name="newStyle">The <see cref="FlatStyle"/> to change to.</param>

		public static void SetFlatStyle(System.Windows.Forms.Control.ControlCollection controls, FlatStyle newStyle)

		{

			foreach (Control o in controls)

			{

				if (o is ButtonBase)

				{

					ButtonBase b = (ButtonBase) o;

					if (b.FlatStyle != newStyle) b.FlatStyle = newStyle;

				}

				else if (o is GroupBox)

				{

					GroupBox g = (GroupBox) o;

					if (g.FlatStyle != newStyle) g.FlatStyle = newStyle;

				}

				else if (o is Label)

				{

					Label l = (Label) o;

					if (l.FlatStyle != newStyle) l.FlatStyle = newStyle;

				}

				SetFlatStyle(o.Controls);

			}

		}

		#endregion

		#region ExceptionMessageBox
		/// <summary>Show a messagebox showing the specified exception.</summary>
		/// <remarks>Uses <see cref="ShowText"/> to display the exception text and stacktrace information</remarks>
		public static void ExceptionMessageBox(Form parentform, Exception ex)
		{
			string stackTrace = ex.StackTrace;
			StringBuilder sb = new StringBuilder("Exception thrown:");
			do
			{
				sb.Append(Environment.NewLine);
				sb.Append(ex.Message);
				ex = ex.InnerException; 
			} while (ex != null);
			sb.Append(Environment.NewLine);
			sb.Append(stackTrace);
			sb.Replace("\x0D", "");	// Remove all CR chars
			sb.Replace("\x0A", Environment.NewLine);	// Replace all LF chars with the NewLine string. 
			ShowText.Show(parentform, sb.ToString(), parentform == null ? "Exception" : parentform.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}	
		#endregion

		#region GetOpenFileName
		/// <summary>
		/// Show a openfiledialogbox with the specified extension list.
		/// </summary>
		/// <param name="dialog"></param>
		/// <param name="extensionWithoutDot"></param>
		/// <returns>The selected file, or <see cref="String.Empty"/> if no file was selected.</returns>
		public static string GetOpenFileName(OpenFileDialog dialog, string extensionWithoutDot)
		{
			dialog.Reset();
			dialog.CheckFileExists = true;
			dialog.Title = "Open File";
			dialog.Filter = string.Format("{0} files (*.{0})|*.{0}|All files (*.*)|*.*", extensionWithoutDot);
			dialog.DefaultExt = extensionWithoutDot;
			dialog.FilterIndex = 0;
			dialog.ShowDialog();

			if (dialog.FileName.Length == 0)
				return "";
			return dialog.FileName;
		}
		#endregion

		#region GetSaveFileName
		/// <summary>
		/// Open a savefiledialogbox with the specified extension list and the specified default name.
		/// </summary>
		/// <param name="dialog"></param>
		/// <param name="extensionWithoutDot"></param>
		/// <returns>The selected file, or <see cref="String.Empty"/> if no file was selected.</returns>
		public static string GetSaveFileName(SaveFileDialog dialog, string extensionWithoutDot)
		{
			return GetSaveFileName (dialog, extensionWithoutDot, "");
		}
		/// <summary>
		/// Open a savefiledialogbox with the specified extension list and the specified default name.
		/// </summary>
		/// <param name="dialog"></param>
		/// <param name="extensionWithoutDot"></param>
		/// <param name="defaultname"></param>
		/// <returns>The selected file, or <see cref="String.Empty"/> if no file was selected.</returns>
		public static string GetSaveFileName(SaveFileDialog dialog, string extensionWithoutDot, string defaultname)
		{
			dialog.Reset();
			dialog.OverwritePrompt = true;
			dialog.Title = "Save File As";
			dialog.Filter = string.Format("{0} files (*.{0})|*.{0}|All files (*.*)|*.*", extensionWithoutDot);
			dialog.DefaultExt = extensionWithoutDot;
			dialog.FileName = defaultname;
			dialog.ShowDialog();
			if (dialog.FileName.Length == 0)
				return "";
			return dialog.FileName;
		}
		#endregion

		#region Setting tab stops in TextBoxes
		private const int EM_SETTABSTOPS = 0xCB;

		[DllImport("user32", EntryPoint="SendMessage")]
		private extern static int SetTabs(IntPtr handle, int msg, 
			int tabCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex=2)] int[] tabStops);

		/// <summary>Set or Reset the tab positions in a <see cref="TextBox"/>.</summary>
		/// <param name="textBox">The text box to change</param>
		/// <param name="tabs">An array of tab positions, expressed in dialog units.</param>
		/// <remarks>
		/// If tabs parameter is <see langword="null" /> or has length zero the text box tabs will be reset to every 32 
		/// dialog units. If the array has a length of 1 the tab will repeat at the given value. Otherwise
		/// the tabs are set explicitly.
		/// </remarks>
		/// <exception cref="ArgumentNullException">if <i>textBox</i> is <see langword="null"/></exception>
		public static void SetEditControlTabs(TextBox textBox, int[] tabs)
		{
			if (textBox == null) throw new ArgumentNullException("textBox");
			if (tabs == null || tabs.Length == 0)
				SetTabs(textBox.Handle, EM_SETTABSTOPS, 0, null);
			else
				SetTabs(textBox.Handle, EM_SETTABSTOPS, tabs.Length, tabs);
		}
		#endregion

        #region ShowMessage
        public static void ShowMessage(Exception ex)
        {
            MessageBox.Show(StringUtil.GetExceptionText(ex, false), "Foutmelding");
        }
        public static void ShowMessage(string s)
        {
            ShowText.Show(s);
        }
        public static void ShowMessage(string s, string caption)
        {
            ShowText.Show(s,caption);
        }
        #endregion
    }
}