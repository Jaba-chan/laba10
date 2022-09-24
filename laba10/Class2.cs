using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public class BorderlessForm : Form
    {
        private const int grip = 15;
        public BorderlessForm()
        {
            
            FormBorderStyle = FormBorderStyle.None;
            SetStyle(ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(ClientSize.Width - grip, ClientSize.Height - grip, grip, grip);
            ControlPaint.DrawSizeGrip(e.Graphics, BackColor, rect);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point location = new Point(m.LParam.ToInt32());
                location = this.PointToScreen(location);
                if (location.X > ClientSize.Width - grip && location.Y > ClientSize.Height - grip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
