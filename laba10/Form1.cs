using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        Canvas pb;
        Image img;
        Bitmap objBitmap;
        Canvas canvas;
        Image returned_img;
        public Form1()
        {
            InitializeComponent();


            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(200, 200, 200);
            this.Size = new System.Drawing.Size(1450, 857);
            this.KeyPreview = true;
            this.KeyDown += HotKeys;
            this.Name = "MyPaint";

            canvas = new Canvas();
            canvas.Location = new Point(border, border);

            this.Controls.Add(canvas);

        }


        public void HotKeys(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                canvas.CancelActionCanvas();
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.V)
            {
                if (!(pb is null)) { pb.Dispose(); }
                pb = new Canvas();
                pb.Location = new Point(0, 0);
                pb.Size = new Size(300, 300);
                this.canvas.Controls.Add(pb);
                if (Clipboard.ContainsImage())
                {
                    img = Clipboard.GetImage();
                }
                else
                {
                    StringCollection str = Clipboard.GetFileDropList();
                    if (str.Count != 0)
                    {
                        img = Image.FromFile(str[0]);
                        objBitmap = new Bitmap(img, new Size(pb.Width, pb.Height));
                        pb.SetIndex(1);
                    }
                }
                returned_img = objBitmap;
                pb.DrawImage(objBitmap, new Point(0, 0));
            }
        }


        private GraphicsPath RoundedForm(RectangleF rect, float radius)
        {
            radius = 10F;
            GraphicsPath graphics_path = new GraphicsPath();
            graphics_path.StartFigure();
            graphics_path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            graphics_path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            graphics_path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            graphics_path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);

            graphics_path.CloseFigure();
            return graphics_path;
        }

        private void OnPaintBoards(Form form, Graphics g)
        {
            using (GraphicsPath rounded_form = RoundedForm(form.ClientRectangle, _radius))
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
        private Image ScaleImage(Image img, Size size)
        {
            float x_s = img.Width / size.Width;
            float y_s = img.Height / size.Height;
            Bitmap bit_mp;
            if (x_s >= y_s)
            {
               bit_mp = new Bitmap(img, new Size((int)(img.Width/x_s), (int)(img.Height/x_s)));
            }
            else
            {
               bit_mp = new Bitmap(img, new Size((int)(img.Width / y_s), (int)(img.Height / y_s)));
            }
            return (Image)bit_mp;
        }
        private void cicleButton1_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(1);
            pb.SetIndex(1);
        }

        private void cicleButton2_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(2);
            pb.SetIndex(2);
        }

        private void cicleButton4_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(3);
            pb.SetIndex(3);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            canvas.BrushSize = (float)numericUpDown1.Value;
            canvas.SetBrush(canvas.BrushColor, canvas.BrushSize);
            pb.BrushSize = (float)numericUpDown1.Value;
            pb.SetBrush(canvas.BrushColor, canvas.BrushSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            canvas.BrushColor = colorDialog2.Color;
            canvas.SetBrush(canvas.BrushColor, canvas.BrushSize);
            pb.BrushColor = colorDialog2.Color;
            pb.SetBrush(canvas.BrushColor, canvas.BrushSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.BMP, *.JPG, + *.GIF, *.PNG) | *.bmp; *.jpg; *.gif; *.png)";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (!(pb is null)) {pb.Dispose();}
                    Image image = Image.FromFile(dialog.FileName);
                    pb = new Canvas();
                    this.canvas.Controls.Add(pb);
                    pb.Location = new Point(0, 0);
                    returned_img = ScaleImage(image, new Size(300, 300)); 
                    pb.Size = new Size(returned_img.Width, returned_img.Height);
                    pb.DrawImage(returned_img, new Point(0,0));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Title = "Сохранить картинку как...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
            "Bitmap File(*.bmp)|*.bmp|" +
            "GIF File(*.gif)|*.gif|" +
            "JPEG File(*.jpg)|*.jpg|" +
            "PNG File(*.png)|*.png";
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = savedialog.FileName;
                string strFilExtn = fileName.Remove(0,
                fileName.Length - 3);
                Bitmap image = pb.CanvasGraphics;
                Image bmp = image.Clone(new Rectangle(0, 0, returned_img.Width, returned_img.Height), image.PixelFormat);
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName,
                         System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName,
                         System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName,
                        System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
