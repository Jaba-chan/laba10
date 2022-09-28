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
        List<LineList> lines = new List<LineList>();
        Pen pen1 = new Pen(Brushes.Red, 2);
        Point line_p1, line_p2;
        private const int grip = 15;
        bool is_painting;
        bool resizeble_x;
        bool resizeble_y;
        int index = 0;
        Point p_1, p_2;
        int rect_x_1, rect_y_1, rect_x_2, rect_y_2;
        Bitmap bm;
        Graphics g;
        public Canvas()
        {
            this.Size = new Size(600, 400);
            MouseDown += canvas_MouseDown;
            MouseMove += canvas_MouseMove;
            MouseUp += canvas_MouseUp;
            BackColor = Color.Aqua;
            bm = new Bitmap(10000, 10000);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            this.Image = bm;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_painting)
            {
                if (index == 1)
                {
                p_2 = e.Location;
                g.DrawLine(pen1, p_1, p_2);
                p_1 = p_2;
                }
                else if (index == 2)
                {

                }
                else if (index == 3)
                {

                }
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
                    x = this.Width;
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
            }
            this.Refresh();
            
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            is_painting = false;
            resizeble_x = false;
            resizeble_y = false;
            rect_x_2 = e.Location.X;
            rect_y_2 = e.Location.Y;
            
            if (index == 2)
            {
                Rectangle rect = new Rectangle(new Point(rect_x_1, rect_y_1), new Size(rect_x_2 - rect_x_1, rect_y_2 - rect_y_1));
                LineList new_rect = new LineList(rect, Color.White, 2, 2);
                lines.Add(new_rect);
                g.DrawEllipse(pen1, rect);
            }
            else if (index == 3)
            {
                line_p2 = e.Location;
                g.DrawLine(pen1, line_p1, line_p2);
                LineList new_line = new LineList(p_1, line_p2, Color.Red, 2, 3);
                lines.Add(new_line);
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            rect_x_1 = e.Location.X;
            rect_y_1 = e.Location.Y;
            line_p1 = e.Location;
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
            if (index == -1)
            {
                Point p1_r = lines[lines.Count - 1].P1;
                Point p2_r = lines[lines.Count - 1].P2;
                Color color1 = Color.White;
                int weight_p = lines[lines.Count - 1].brush_weight;
                Pen pen_r = new Pen(color1, weight_p);
                g.DrawLine(pen_r, p1_r, p2_r);
                lines.RemoveAt(lines.Count - 1);
            }
            if (index == -2)
            {
                Rectangle rect = lines[lines.Count - 1].rectangle;
                Color color1 = Color.White;
                int weight = lines[lines.Count - 1].brush_weight;
                Pen pen = new Pen(color1, weight);
                g.DrawEllipse(pen, rect);
                lines.RemoveAt(lines.Count - 1);
            }
        } 
        public void SetIndex(int ind)
        {
            index = ind;
        }
    }
}
