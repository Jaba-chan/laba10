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
        private Color _brush_color = Color.Black;
        private float _brush_size;
        Pen pen1 = new Pen(Color.Red, 2);
        Point line_p1, line_p2;
        private const int grip = 15;
        bool is_painting;
        bool resizeble_x;
        bool resizeble_y;
        int index = -100;
        Point p_1, p_2;

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
        public void SetIndex(int ind)
        {
            index = ind;
        }
        public void SetBrush(Color n_c, float size)
        {
            pen1 = new Pen(n_c, size);
            Debug.WriteLine(n_c);
        }
        public Color BrushColor
        {
            get { return _brush_color; }
            set { _brush_color = value; }
        }
        public float BrushSize
        {
            get { return _brush_size; }
            set { _brush_size = value; }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (is_painting && index > 0)
            {
                p_2 = e.Location;
                pb_bm = new Bitmap(this.Width, this.Height);
                pb_g = Graphics.FromImage(pb_bm);
                pb_g.DrawImage(this.Image, 0, 0);
                pb.Image = pb_bm;

                switch (index)
                {
                    case 6:
                        g.DrawLine(pen1, p_1, p_2);
                        p_1 = p_2;
                        break;
                    case 1: 
                        pb_g.DrawLine(pen1, p_1, p_2);
                        break;
                    case 2:
                        pb_g.DrawEllipse(pen1, new Rectangle(p_1.X, p_1.Y, p_2.X - p_1.X, p_2.Y - p_1.Y));
                        break;
                    case 3:
                        if (p_2.X < p_1.X && p_2.Y > p_1.Y)
                        {
                            pb_g.DrawRectangle(pen1, new Rectangle(p_2.X, p_1.Y, p_1.X - p_2.X, p_2.Y - p_1.Y));
                        }
                        else if (p_2.X < p_1.X && p_2.Y < p_1.Y)
                        {
                            pb_g.DrawRectangle(pen1, new Rectangle(p_2.X, p_2.Y, p_1.X - p_2.X, p_1.Y - p_2.Y));
                        }
                        else if (p_2.X > p_1.X && p_2.Y < p_1.Y)
                        {
                            pb_g.DrawRectangle(pen1, new Rectangle(p_1.X, p_2.Y, p_2.X - p_1.X, p_1.Y - p_2.Y));
                        }
                        else if (p_2.X > p_1.X && p_2.Y > p_1.Y)
                        {
                            pb_g.DrawRectangle(pen1, new Rectangle(p_1.X, p_1.Y, p_2.X - p_1.X, p_2.Y - p_1.Y));
                        }
                        break;
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
            rect = new Rectangle(p_1.X, p_1.Y, p_2.X - p_1.X, p_2.Y - p_1.Y);
            switch (index)
            {
                case 1:
                    new_l = new LineList(p_1, p_2, pen1.Color, pen1.Width, index);
                    lines.Add(new_l);
                    g.DrawLine(pen1, p_1, p_2);
                    break;
                case 2:
                    new_l = new LineList(rect, pen1.Color, pen1.Width, index);
                    
                    g.DrawEllipse(pen1, rect);
                    lines.Add(new_l);
                    break;
                case 3:
                    if (p_2.X < p_1.X && p_2.Y > p_1.Y)
                    {
                       rect =  new Rectangle(p_2.X, p_1.Y, p_1.X - p_2.X, p_2.Y - p_1.Y);
                    }
                    else if (p_2.X < p_1.X && p_2.Y < p_1.Y)
                    {
                       rect = new Rectangle(p_2.X, p_2.Y, p_1.X - p_2.X, p_1.Y - p_2.Y);
                    }
                    else if (p_2.X > p_1.X && p_2.Y < p_1.Y)
                    {
                       rect = new Rectangle(p_1.X, p_2.Y, p_2.X - p_1.X, p_1.Y - p_2.Y);
                    }
                    else if (p_2.X > p_1.X && p_2.Y > p_1.Y)
                    {
                       rect = new Rectangle(p_1.X, p_1.Y, p_2.X - p_1.X, p_2.Y - p_1.Y);
                    }
                    new_l = new LineList (rect, pen1.Color, pen1.Width, index);
                    g.DrawRectangle(pen1, rect);
                    lines.Add(new_l);
                    break;
            }
            if (index == 1 || index == 2 || index == 3)   {pb.Dispose();}
            this.Refresh();  
        }
   
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (index == 1 || index == 2 || index == 3)
            {
                pb = new PictureBox();
                this.Controls.Add(pb);
                pb.Size = this.Size;
            }

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
                        Rectangle rect_elip = lines[i].rectangle;
                        g.DrawEllipse(pen, rect_elip);
                        break;
                    case 3:
                        Rectangle rect_rect = lines[i].rectangle;
                        g.DrawRectangle(pen, rect_rect);
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
                    case 3:
                        rect_r = lines[(lines.Count - 1)].rectangle;
                        g.DrawRectangle(pen_r, rect_r);
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
