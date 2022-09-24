using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public class CicleButton : Control
    {
        public CicleButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Size = new System.Drawing.Size(17, 17);
            Text = String.Empty;
            BackColor = Color.Red;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gr = e.Graphics;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.Clear(Parent.BackColor);
            Rectangle rect_draw = new Rectangle(0, 0, Width-1, Height-1);
            Rectangle rect_fill = new Rectangle(1, 1, Width - 3, Height - 3);
            gr.DrawEllipse(new Pen(Brushes.Black, 1), rect_draw);
            gr.FillEllipse(new SolidBrush(BackColor), rect_draw);
        }
    }
}
