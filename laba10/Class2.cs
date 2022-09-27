using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public class Canvas : PictureBox
    {
        Pen pen1 = new Pen(Brushes.Red, 2);
        private const int grip = 15;
        bool is_painting;
        bool resizeble_x;
        bool resizeble_y;
        Point p_1, p_2;
        Bitmap bm;
        Graphics g;
        public Canvas()
        {
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            MouseDown += canvas_MouseDown;
            MouseMove += canvas_MouseMove;
            MouseUp += canvas_MouseUp;
            BackColor = Color.Aqua;
            bm = new Bitmap(this.Width, this.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            this.Image = bm;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_painting)
            {
                p_2 = e.Location;
                g.DrawLine(pen1, p_1, p_2);
                p_1 = p_2;
            }
            if (resizeble_x | resizeble_y)
            { 
                int x, y;
                if (resizeble_x)
                {
                    x = e.Location.X;
                }
                else
                {
                    x = this.Height;
                }
                if (resizeble_y)
                {
                    y = e.Location.Y;
                }
                else
                {
                    y = this.Height;
                }
                
                this.Size = new Size(x, y);
                Debug.WriteLine(this.Size);
            }
            this.Refresh();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            is_painting = false;
            resizeble_x = false;
            resizeble_y = false;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            is_painting = true;
            p_1 = e.Location;
            if (e.Location.X > this.Width - grip && e.Location.X < this.Width + grip)
            {
                resizeble_x = true;
                is_painting = false;
            }
            if (e.Location.Y > this.Height - grip && e.Location.Y < this.Height + grip)
            {
                resizeble_y = true;
                is_painting = false;
            }
        }
    }
}
