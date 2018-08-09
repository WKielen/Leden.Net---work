using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Util.Forms
{
    public class Semi_TransparentPanel : Panel
    {
        public Semi_TransparentPanel() : base()
        {}

        const int WS_EX_TRANSPARENT = 0x00000020;
        
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(0, this.BackColor));//semi-transparent color.
            e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));
        }
    }
}
