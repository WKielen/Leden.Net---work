using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Util.Forms;

namespace Leden.Net
{
    public partial class frmNotes : frmBasis, IMruUser
    {
        public frmNotes()
        {
            InitializeComponent();
            _windowState = new PersistWindowState(this, @"Leden\Notes");
            PersistControlValue.ReadControlValue(richTextBox1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            PersistControlValue.StoreControlValue(richTextBox1);
        }
        // Nodig om mru interface te implementeren.    
        void IMruUser.ItemSelected(object obj)
        {
        }
    }
}
