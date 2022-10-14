using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

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

        Graphics pb_g;
        PictureBox pb;
        Bitmap pb_bm;

        Point p1_r, p2_r;
        Color color_r;
        float weight_r;
        Rectangle rect_r;

        Bitmap bm;
        Graphics g;
        public Canvas()
        {
            this.Size = new Size(600, 400);
            this.BackColor = Color.White;
            MouseDown += canvas_MouseDown;
            MouseMove += canvas_MouseMove;
            MouseUp += canvas_MouseUp;
            bm = new Bitmap(1000, 1000);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            this.Image = bm;
        }
        public Bitmap BM
        {
            get { return bm; }
            set { bm = value; }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_painting)
            {
                if (index == 3)
                {
                    p_2 = e.Location;
                    g.DrawLine(pen1, p_1, p_2);
                    p_1 = p_2;
                }
                else if (index == 6)
                { 
                    p_2 = e.Location;
                    pb_bm = new Bitmap(this.Width, this.Height);
                    pb_g = Graphics.FromImage(pb_bm);
                    pb_g.DrawImage(this.Image, 0, 0);
                    pb.Image = pb_bm;
                    pb_g.DrawLine(pen1, p_1, p_2);
                    
                }
                else if (index == 9)
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
            LineList new_l;
            Rectangle rect;
            p_2 = e.Location;
            if (index == 6) { pb.Dispose(); g.DrawLine(pen1, p_1, p_2); }
            switch (index)
            {
                case 1:
                    p_2 = e.Location;
                    new_l = new LineList(p_1, p_2, pen1.Color, pen1.Width, index);
                    lines.Add(new_l);
                    g.DrawLine(pen1, p_1, p_2);
                    break;
                case 2:
                    rect_x_2 = e.Location.X;
                    rect_y_2 = e.Location.Y;
                    rect = new Rectangle(new Point(rect_x_1, rect_y_1), new Size(rect_x_2 - rect_x_1, rect_y_2 - rect_y_1));
                    new_l = new LineList(rect, pen1.Color, pen1.Width, index);
                    g.DrawEllipse(pen1, rect);
                    lines.Add(new_l);
                    break;
            }
            
        }
   
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (index == 6)
            {
                pb = new PictureBox();
                this.Controls.Add(pb);
                pb.Size = this.Size;
            }

            rect_x_1 = e.Location.X;
            rect_y_1 = e.Location.Y;
            line_p1 = e.Location;
            p_1 = e.Location;
            is_painting = true;
            
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
        public void SetIndex(int ind)
        {
            index = ind;
        }
        public void RedrawALL()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                int ind = lines[i].index;
                float weight_p = lines[i].brush_weight;
                Color color1 = lines[i].Brush_L;
                Pen pen = new Pen(color1, weight_p);
                switch (ind)
                {
                    case 1:
                        Point p1_r = lines[i].P1;
                        Point p2_r = lines[i].P2;
                        g.DrawLine(pen, p1_r, p2_r);
                        break;

                    case 2:
                        Rectangle rect = lines[i].rectangle;
                        g.DrawEllipse(pen, rect);
                        Debug.WriteLine(weight_p);
                        break;

                }
                this.Refresh();
            }
        }
        public void CancelActionCanvas()
        {
            try
            {
                int ind = lines[lines.Count - 1].index;
                color_r = BackColor;
                weight_r = lines[lines.Count - 1].brush_weight;
                Pen pen_r = new Pen(color_r, weight_r);
                switch (ind)
                {
                    case 1:
                        p1_r = lines[lines.Count - 1].P1;
                        p2_r = lines[lines.Count - 1].P2;
                        g.DrawLine(pen_r, p1_r, p2_r);
                        break;

                    case 2:
                        rect_r = lines[lines.Count - 1].rectangle;
                        g.DrawEllipse(pen_r, rect_r);
                        break;
                }
                lines.RemoveAt(lines.Count - 1); 
                RedrawALL();
                this.Refresh();
               
            }
            catch { }
        }



    }
}
