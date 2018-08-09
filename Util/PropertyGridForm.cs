using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Util.Forms
{
	/// <summary>A prefactored class to display a PropertyForm for an object.</summary>
	public class PropertyGridForm : System.Windows.Forms.Form
	{
		private object customisedObject;
		/// <summary>Set the customised object.</summary>
		public object CustomisedObject
		{
			get { return customisedObject; }
			set 
			{
				customisedObject = value;
				propertyGrid.SelectedObject = customisedObject;
			}
		}
		/// <summary>Required designer variable.</summary>
        private System.ComponentModel.Container components = null;
		/// <summary>The OK Button</summary>
		protected System.Windows.Forms.Button btnOK;
		/// <summary>The grid component</summary>
		public System.Windows.Forms.PropertyGrid propertyGrid;

		private PropertyGridForm()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initialise a new propertyform, customizing the supplied object.
		/// </summary>
		/// <param name="customisedObject"></param>
        public PropertyGridForm(object customisedObject)
		{
            InitializeComponent();

            this.CustomisedObject = customisedObject;
			propertyGrid.CollapseAllGridItems();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
           if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
           }
           base.Dispose(disposing);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() 
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyGridForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnOK.Location = new System.Drawing.Point(0, 388);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(344, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(344, 388);
            this.propertyGrid.TabIndex = 1;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // PropertyGridForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(344, 411);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertyGridForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Property Form";
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>Fired when the value of a property is changed in the PropertyGrid</summary>
		public PropertyValueChangedEventHandler PropertyValueChanged;

		private void propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			if (this.PropertyValueChanged != null)
				this.PropertyValueChanged(s, e);
		}

		public void CollapseAll()
		{
			propertyGrid.CollapseAllGridItems();
		}
		public void ExpandAll()
		{
			propertyGrid.ExpandAllGridItems();
		}

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}