using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Util.Forms
{
    public class ReadOnlyPropertyGrid : PropertyGrid
    {

        private bool _readOnly;
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                this.SetObjectAsReadOnly(this.SelectedObject, _readOnly);
            }
        }

        protected override void OnSelectedObjectsChanged(EventArgs e)
        {
            this.SetObjectAsReadOnly(this.SelectedObject, this._readOnly);
            base.OnSelectedObjectsChanged(e);
        }

        private void SetObjectAsReadOnly(object selectedObject, bool isReadOnly)
        {
            if (this.SelectedObject != null)
            {
                TypeDescriptor.AddAttributes(this.SelectedObject, new Attribute[] { new ReadOnlyAttribute(_readOnly) });
                this.Refresh();
            }
        }
    }

    
}