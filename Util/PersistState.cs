using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.IsolatedStorage;

namespace Util.Forms
{
	#region PersistWindowState
	/// <summary>This class saves the location and shape of a form when exiting the form</summary>
 	/// <example>
	/// Typical usage would be:
	/// <code lang="C#">
	/// class SomeFancyForm : Form
	/// {
	///   private PersistWindowState m_windowState;
	///   private SomeFancyForm()
	///   {
	///	    m_windowState = new PersistWindowState(this, solutionPathMaster);
	///   }
	/// }  
	/// </code>
	/// </example>
	public class PersistWindowState
	{
		private Form m_parent;
		private string m_regPath;
		private int m_normalLeft;
		private int m_normalTop;
		private int m_normalWidth;
		private int m_normalHeight;
		private FormWindowState m_windowState;
		private bool m_allowSaveMinimized = false;

		/// <summary>
		/// Initialise the PersistWindowState with the parentform and LocolStoragePath
		/// </summary>
		/// <param name="myform"></param>
		/// <param name="localstoragepath"></param>
		public PersistWindowState(Form myform, string localstoragepath)
		{
			this.Parent = myform;
            this.LocalStoragePath = localstoragepath;
		}
		/// <summary>Get or set the Parent Form</summary>
		public Form Parent
		{
			get { return m_parent; }
			set
			{
				m_parent = value;

				// subscribe to parent form's events
				m_parent.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
				m_parent.Resize += new System.EventHandler(OnResize);
				m_parent.Move += new System.EventHandler(OnMove);
				m_parent.Load += new System.EventHandler(OnLoad);

				// get initial width and height in case form is never resized
				m_normalWidth = m_parent.Width;
				m_normalHeight = m_parent.Height;
			}
		}
		/// <summary>
		/// Set the path in the Local Storage
		/// </summary>
		public string LocalStoragePath
		{
			set
			{
				m_regPath = value;		
			}
			get
			{
				return m_regPath;
			}
		}
		/// <summary>
		/// Do you allow the form saved as Minimized
		/// </summary>
		public bool AllowSaveMinimized
		{
			set
			{
				m_allowSaveMinimized = value;
			}
		}

		private void OnResize(object sender, System.EventArgs e)
		{
			// save width and height
			if(m_parent.WindowState == FormWindowState.Normal)
			{
				m_normalWidth = m_parent.Width;
				m_normalHeight = m_parent.Height;
			}
		}

		private void OnMove(object sender, System.EventArgs e)
		{
			// save position
			if(m_parent.WindowState == FormWindowState.Normal)
			{
				m_normalLeft = m_parent.Left;
				m_normalTop = m_parent.Top;
			}
			// save state
			m_windowState = m_parent.WindowState;
		}

		private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			PersistControlValue.SaveLocalAppSetting(m_regPath, "Left", m_normalLeft.ToString());
			PersistControlValue.SaveLocalAppSetting(m_regPath, "Top", m_normalTop.ToString());
			PersistControlValue.SaveLocalAppSetting(m_regPath, "Width", m_normalWidth.ToString());
			PersistControlValue.SaveLocalAppSetting(m_regPath, "Height", m_normalHeight.ToString());

			// check if we are allowed to save the state as minimized (not normally)
			if(!m_allowSaveMinimized)
			{
				if(m_windowState == FormWindowState.Minimized)
					m_windowState = FormWindowState.Normal;
			}
			PersistControlValue.SaveLocalAppSetting(m_regPath, "WindowState", ((int)m_windowState).ToString());
			
		}

		private void OnLoad(object sender, System.EventArgs e)
		{		
			try
			{	
				int left = int.Parse(PersistControlValue.ReadLocalAppSetting(m_regPath, "Left"));
				int top = int.Parse(PersistControlValue.ReadLocalAppSetting(m_regPath, "Top"));
				int width = int.Parse(PersistControlValue.ReadLocalAppSetting(m_regPath, "Width"));
				int height = int.Parse(PersistControlValue.ReadLocalAppSetting(m_regPath, "Height"));
				
				int tmp = int.Parse(PersistControlValue.ReadLocalAppSetting(m_regPath, "WindowState"));
				FormWindowState windowState = (FormWindowState)tmp;

				m_parent.Location = new Point(left, top);
				m_parent.Size = new Size(width, height);
				m_parent.WindowState = windowState;
			}
			catch {}
		}
	}
	#endregion

	#region Persist Control state
	/// <summary>
	/// This class saves the location and shape of a control when exiting the main form.
	/// </summary>
	/// <remarks>Do not save the state of any <see cref="Splitter"/>s, it will not yield the desired effect.</remarks>
	/// <example>
	/// Typical usage would be:
	/// <code lang="C#">
	/// class SomeFancyForm : Form
	/// {
	///   private PersistControlState someControlState;
	///   private SomeFancyForm()
	///   {
	///     //
	///	    // Required for Windows Form Designer support
	///	    //
	///	    InitializeComponent();
	///
	///	    someControlState = new PersistControlState(this, this.someControl, solutionPathMaster);
	///   }
	/// }  
	/// </code>
	/// </example>
	public class PersistControlState
	{
		/// <summary>
		/// Create a control state persister instance and binds it to to provided parent and control.
		/// </summary>
		/// <param name="parent">The parent frame providing close and start up events.</param>
		/// <param name="control">The target control whos state is being persisted.</param>
		/// <param name="localstoragepath">The path in the local storage where the control state is being persisted.</param>
		public PersistControlState(Form parent, Control control, string localstoragepath)
		{
			Parent = parent;
			Control = control;
			LocalStoragePath = localstoragepath;
		}

		private Form parent;
		private Control control;
		private string regPath;
		private int left;
		private int top;
		private int width;
		private int height;
		private bool visible;

		/// <summary>
		/// Set the Parent Form
		/// </summary>
		public Form Parent
		{
			set
			{
				parent = value;

				// subscribe to parent form's events
				if (value != null)
				{
					parent.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
					parent.Load += new System.EventHandler(OnLoad);
				}
			}
			get
			{
				return parent;
			}
		}
		/// <summary>
		/// Set the Control
		/// </summary>
		public Control Control
		{
			set
			{
				control = value;

				// subscribe to parent form's events
				control.Resize += new System.EventHandler(OnResize);
				control.Move += new System.EventHandler(OnMove);
				control.VisibleChanged += new System.EventHandler(OnVisibleChanged);

				// get initial width and height in case form is never resized
				width = control.Width;
				height = control.Height;
				visible = control.Visible;
			}
			get
			{
				return control;
			}
		}
		/// <summary>
		/// Set the path in the Local Storage
		/// </summary>
		public string LocalStoragePath
		{
			set
			{
				regPath = value;		
				if (regPath[regPath.Length - 1] != '\\' || regPath[regPath.Length - 1] != '/')
					regPath += '\\';
			}
			get
			{
				return regPath;
			}
		}

		private void OnResize(object sender, System.EventArgs e)
		{
			width = control.Width;
			height = control.Height;
		}

		private void OnMove(object sender, System.EventArgs e)
		{
			left = control.Left;
			top = control.Top;
		}

		private void OnVisibleChanged(object sender, System.EventArgs e)
		{
			visible = control.Visible;
		}

		private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
		{

			PersistControlValue.SaveLocalAppSetting(regPath, "Left", left.ToString());
			PersistControlValue.SaveLocalAppSetting(regPath, "Top", top.ToString());
			PersistControlValue.SaveLocalAppSetting(regPath, "Width", width.ToString());
			PersistControlValue.SaveLocalAppSetting(regPath, "Height", height.ToString());
			PersistControlValue.SaveLocalAppSetting(regPath, "Visible", visible.ToString());
		}

		private void OnLoad(object sender, System.EventArgs e)
		{		
			try
			{	
				int l = int.Parse(PersistControlValue.ReadLocalAppSetting(regPath, "Left"));
				int t = int.Parse(PersistControlValue.ReadLocalAppSetting(regPath, "Top"));
				int w = int.Parse(PersistControlValue.ReadLocalAppSetting(regPath, "Width"));
				int h = int.Parse(PersistControlValue.ReadLocalAppSetting(regPath, "Height"));
				bool v = bool.Parse(PersistControlValue.ReadLocalAppSetting(regPath, "Visible"));

				control.Location = new Point(l, t);
				control.Size = new Size(w, h);
				control.Visible = v;

			}
			catch {}
		}
	}
	#endregion

	#region PersistControlValue
	public class PersistControlValue
	{
		#region Local Storage
		public static void StoreControlValue(Control control)
		{
			string solutionPath = @"Leden.Net";
			if (control.GetType() == typeof(TextBox))
			{
				TextBox c = (TextBox)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text); 
			}
            else if (control.GetType() == typeof(currencyTextBox))
            {
                currencyTextBox c = (currencyTextBox)control;
                PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text);
            }
            else if (control.GetType() == typeof(CheckBox))
			{
				CheckBox c = (CheckBox)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Checked ? "True" : "False"); 
			}
			else if (control.GetType() == typeof(RadioButton))
			{
				RadioButton c = (RadioButton)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Checked ? "True" : "False"); 
			}
			else if (control.GetType() == typeof(Label))
			{
				Label c = (Label)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text); 
			}
			else if (control.GetType() == typeof(NumericUpDown))
			{
				NumericUpDown c = (NumericUpDown)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Value.ToString());
			}
			else if (control.GetType() == typeof(ComboBox))
			{
				ComboBox c = (ComboBox)control;
				PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text);
			}
            else if (control.GetType() == typeof(DateTimePicker))
            {
                DateTimePicker c = (DateTimePicker)control;
                PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text);
            }
            else if (control.GetType() == typeof(RichTextBox))
            {
                RichTextBox c = (RichTextBox)control;
                PersistControlValue.SaveLocalAppSetting(solutionPath, c.Name, c.Text);
            }


		}
//		public static void ReadControlValue(Control control)
//		{
//			if (control.GetType() == typeof(TextBox))
//			{
//				TextBox c = (TextBox)control;
//				c.Text = PersistControlValue.ReadLocalAppSetting(@"Stand.Net", c.Name);
//			}
//			else if (control.GetType() == typeof(CheckBox))
//			{
//				CheckBox c = (CheckBox)control;
//				c.Checked = PersistControlValue.ReadLocalAppSetting(@"Stand.Net", c.Name) == "True" ? true : false;
//			}
//			else if (control.GetType() == typeof(RadioButton))
//			{
//				RadioButton c = (RadioButton)control;
//				c.Checked = PersistControlValue.ReadLocalAppSetting(@"Stand.Net", c.Name) == "True" ? true : false;
//			}
//			else if (control.GetType() == typeof(Label))
//			{
//				Label c = (Label)control;
//				c.Text = PersistControlValue.ReadLocalAppSetting(@"Stand.Net", c.Name);
//			}
//			else if (control.GetType() == typeof(NumericUpDown))
//			{
//				NumericUpDown c = (NumericUpDown)control;
//				try{c.Value = decimal.Parse(PersistControlValue.ReadLocalAppSetting("BatchFileGenerator", c.Name));}
//				catch {};
//			}
//			else if (control.GetType() == typeof(ComboBox))
//			{
//				ComboBox c = (ComboBox)control;
//				c.Text = PersistControlValue.ReadLocalAppSetting("BatchFileGenerator", c.Name);
//			}
//		}
	
		public static string ReadControlValue(Control control)
		{
			string solutionPath = @"Leden.Net";
			if (control.GetType() == typeof(TextBox))
			{
				TextBox c = (TextBox)control;
				c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
				return c.Text;
			}
            else if (control.GetType() == typeof(currencyTextBox))
            {
                currencyTextBox c = (currencyTextBox)control;
                c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
                return c.Text;
            }
            else if (control.GetType() == typeof(CheckBox))
			{
				CheckBox c = (CheckBox)control;
				c.Checked = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name) == "True" ? true : false;
				return c.Checked.ToString();
			}
			else if (control.GetType() == typeof(RadioButton))
			{
				RadioButton c = (RadioButton)control;
				c.Checked = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name) == "True" ? true : false;
				return c.Checked.ToString();
			}
			else if (control.GetType() == typeof(Label))
			{
				Label c = (Label)control;
				c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
				return c.Text;
			}
			else if (control.GetType() == typeof(NumericUpDown))
			{
				NumericUpDown c = (NumericUpDown)control;
				try
				{
					c.Value = decimal.Parse(PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name));
					return c.Value.ToString();
				}
				catch {};
			}
			else if (control.GetType() == typeof(ComboBox))
			{
				ComboBox c = (ComboBox)control;
				c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
				return c.Text;
			}
            else if (control.GetType() == typeof(DateTimePicker))
            {
                DateTimePicker c = (DateTimePicker)control;
                c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
            }
            else if (control.GetType() == typeof(RichTextBox))
            {
                RichTextBox c = (RichTextBox)control;
                c.Text = PersistControlValue.ReadLocalAppSetting(solutionPath, c.Name);
            } return string.Empty;
		}
		/// <summary>
		/// Save the specified value to the specified file and solutionpath. The store used is scoped on
		/// <c>IsolatedStorageScope.User | IsolatedStorageScope.Assembly</c>
		/// </summary>
		/// <param name="solutionpath"></param>
		/// <param name="filename"></param>
		/// <param name="storevalue"></param>
		public static void SaveLocalAppSetting(string solutionpath, string filename, string storevalue)
		{
			IsolatedStorageFile isoStore = null;;
			StreamWriter writer = null;
			try
			{
				isoStore =  IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
				isoStore.CreateDirectory (solutionpath);
				writer = new StreamWriter(new IsolatedStorageFileStream(Path.Combine(solutionpath, filename), FileMode.Create, FileAccess.Write, FileShare.Read, isoStore));
				writer.Write(storevalue);
			}
			catch (Exception ex)
			{
				throw new Exception( @"Can't save in Local Storage" + Environment.NewLine +
					Path.Combine(solutionpath, filename) + Environment.NewLine +
					storevalue, ex);
			}
			finally
			{
				if (writer != null) writer.Close();
				if (isoStore != null) isoStore.Close();
			}
		}

		/// <summary>
		/// Read the data in the specified file in the specified solutionpath. The store used is scoped
		/// on <c>IsolatedStorageScope.User | IsolatedStorageScope.Assembly</c>
		/// </summary>
		/// <param name="solutionpath"></param>
		/// <param name="filename"></param>
		/// <returns></returns>
		public static string ReadLocalAppSetting(string solutionpath, string filename)
		{
			IsolatedStorageFile isoStore = null;;
			StreamReader reader = null;
			try
			{
				isoStore =  IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
				reader = new StreamReader(new IsolatedStorageFileStream(Path.Combine(solutionpath, filename), FileMode.Open, FileAccess.Read, FileShare.Read, isoStore));
				return reader.ReadToEnd();
			}
			catch
			{
				return "";
			}
			finally
			{
				if (reader != null) reader.Close();
				if (isoStore != null) isoStore.Close();
			}
		}

		#endregion


	}
	#endregion

}




