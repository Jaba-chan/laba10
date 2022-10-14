using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;


namespace laba10
{
    
    public partial class Form1 : Form
    {
        const int border = 20;
        float _radius = 10;
        Canvas canvas;
        public Form1()
        {
            InitializeComponent();


            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(200, 200, 200);
            this.Size = new System.Drawing.Size(1450, 857);
            this.KeyPreview = true;
            this.KeyDown += CancelAction;
            this.Name = "MyPaint";

            canvas = new Canvas();
            canvas.Location = new Point(border, border);

            this.Controls.Add(canvas);

        }


        public void CancelAction(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                canvas.CancelActionCanvas();
            }
        }


        private GraphicsPath RoundedForm(RectangleF rect, float radius)
        {
            radius = 10F;
            GraphicsPath graphics_path = new GraphicsPath();
            graphics_path.StartFigure();
            Debug.WriteLine($"{rect.X} {rect.Y} {rect.Right} {rect.Bottom}");
            graphics_path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            graphics_path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            graphics_path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            graphics_path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

            graphics_path.CloseFigure();
            return graphics_path;
        }

        private void OnPaintBoards(Form form, Graphics g)
        {
            using(GraphicsPath rounded_form = RoundedForm(form.ClientRectangle, _radius))
            {
                
                form.Region = new Region(rounded_form);

                g.DrawPath(new Pen(this.BackColor, 1F), rounded_form);
                RectangleF rect = form.ClientRectangle;
            
                }   
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            OnPaintBoards(this, e.Graphics);
        }

        private void cicleButton1_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(1);

        }

        private void cicleButton2_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(2);
        }

        private void cicleButton3_Click(object sender, EventArgs e)
        {
            //canvas.TEST();
            canvas.SetIndex(6);
        }
    }
}
