using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Util.Forms
{
	/// <summary>
	/// Summary description for PouleTeamDropDown.
	/// </summary>

	public delegate void ChangedEventHandler(object sender, EventArgs e);
	public class DropDownObject : System.Windows.Forms.ComboBox
	{
		public event ChangedEventHandler Changed;
		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        public DropDownObject() { }
        public DropDownObject(System.ComponentModel.IContainer container)
		{
            this.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left))));
            this.Name = "cboDropDownObject";
            this.TabIndex = 0;
            this.TabStop = false;
            container.Add(this);
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

        List<object> myObjectList = new List<object>();

        public void Load()
		{
            throw new NotImplementedException();
            //myObjectList = myList;

            //Items.Clear();

            //foreach (object myObject in myObjectList)
            //{
            //    Multi
            //}


            //Items.AddRange((from lid in myList select lid.VolledigeNaam).ToArray());

            //if (myList.Count < 1)
            //    this.SelectedIndex = -1;
            //else 
            //    this.SelectedIndex = 0;
		}

		protected virtual void OnChanged(EventArgs e) 
		{
			if (Changed != null)
				Changed(this, e);
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			OnChanged(e);
		}

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageDown) { Next(); }
            if (e.KeyCode == Keys.PageUp) { Previous(); }
            e.Handled = true;
        }

        public object SelectedObject
        {
            get
            {
                return myObjectList[base.SelectedIndex];
            }
        }

		/// <summary>
		/// Selects the first item in the list.
		/// </summary>
		public void First()
		{
			if (this.Items.Count > 0)
				this.SelectedIndex = 0;
		}

		/// <summary>
		/// Selects the next item in the list.
		/// </summary>
		public void Next()
		{
			if (this.SelectedIndex < this.Items.Count-1 && this.Items.Count > 0)
				this.SelectedIndex += 1;
		}
		/// <summary>
		/// Selects the previous item in the list.
		/// </summary>
		public void Previous()
		{
			if (this.SelectedIndex > 0 && this.Items.Count > 0)
				this.SelectedIndex -= 1;
		}
		/// <summary>
		/// Selects the last item in the list.
		/// </summary>
		public void Last()
		{
			if (this.Items.Count > 0)
				this.SelectedIndex = this.Items.Count - 1;
		}

        /// <summary>
        /// Refresh the current record
        /// </summary>
        public void RefreshCurrent()
        {
            Changed(this, new EventArgs());
        }
        
        /// <summary>
		/// Adds an item of the list, sorts and Refreshed the control
		/// </summary>
		/// <param name="TeamNaam">Team naam.</param>
		public void AddRecord(string DropDownText, object myObject)
		{
			Items.Add(DropDownText);
            myObjectList.Add(myObject);
		}
		/// <summary>
		/// Deletes an item of the list, sorts and Refreshed the control
		/// </summary>
		/// <param name="LidNaam">Volledige naam.</param>
        public void DeleteRecord(string DropDownText)
		{
			Next();
            int i = Items.IndexOf(DropDownText);
			Items.RemoveAt(i);
            myObjectList.RemoveAt(i);
		}
        /// <summary>
        /// Sets control to specifis item
        /// </summary>
        /// <param name="LidNr">LidNr</param>
        public void SelectRecord(string Naam)
        {
            this.SelectedIndex = this.FindString(Naam);
        }
    }
}

