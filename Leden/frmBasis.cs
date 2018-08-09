using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing;
using Util.Forms;

namespace Leden.Net
{
	/// <summary>
	/// Summary description for frmPercentage.
	/// </summary>
	public class frmBasis : System.Windows.Forms.Form
	{
		internal System.Data.OleDb.OleDbTransaction transaction = null;
		internal int controlHeight = 16;					// De hoogte van de controls
		internal int controlSpace = 1;						// De ruimte tussen de controls
		internal int controlStart = 20;
        protected string RegExBic = "[a-zA-Z]{4}[a-zA-Z]{2}[a-zA-Z0-9]{2}([a-zA-Z0-9]{3})?";

//        protected LedenLijst leden = null;
        protected tblParameters param = null;
        protected PersistWindowState _windowState;

		private void InitializeComponent()
		{
			// 
			// frmBasis
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "frmBasis";
		}
		
        public frmBasis()
        {
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form_KeyDown);
            KeyDown += new KeyEventHandler(EscapeDown);
        }
        public virtual void Form_KeyDown(object sender, KeyEventArgs e)
        {
        }

        public void EscapeDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

		#region SelectAll
		protected void SelectAll_Enter(object sender, System.EventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) ((TextBox)sender).SelectAll();
			else if (sender.GetType() == typeof(ComboBox)) ((ComboBox)sender).SelectAll();
		}
		protected void SelectAll_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (sender.GetType() == typeof(TextBox)) ((TextBox)sender).SelectAll();
			else if (sender.GetType() == typeof(ComboBox)) ((ComboBox)sender).SelectAll();
		}
		#endregion

		#region NumericCheck KeyDown & KeyPress
		protected bool numberEntered = true;
		protected void NumericCheck_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Initialize the flag to false.
			numberEntered = false;

			// Determine whether the keystroke is a number from the top of the keyboard.
			// Determine whether the keystroke is a number from the keypad.
			if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
				(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9))
				numberEntered = true;
				
		}

		protected void NumericCheck_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			// Check for the flag being set in the KeyDown event.
			
			if (numberEntered == false || e.KeyChar == (char)13)
			{
				// Stop the character from being entered into the control since it is non-numerical.
				e.Handled = true;
			}
		}
		#endregion

        #region InitDataGridView
        protected void InitializeDataGridView(DataGridView dgv)
        {
            dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.ColumnHeadersHeight = 40;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = false;
            dgv.Rows.Clear();
        }
        #endregion


	}
}
