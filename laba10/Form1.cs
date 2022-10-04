using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace laba10
{
    public partial class Form1 : Form
    {
        const int border = 20;
        Canvas canvas;
        public Form1()
        {
            InitializeComponent();
            Panel settings = new Panel();
            settings.Size = new Size(this.Width, 40);
            settings.Location = new Point(0, 0);
            settings.BackColor = Color.Coral;
            settings.Dock = DockStyle.Top;

            Panel instruments = new Panel();
            instruments.Size = new Size(this.Width, 120);
            instruments.Location = new Point(0, settings.Height);
            instruments.BackColor = Color.Gold;
            instruments.Dock = DockStyle.Top;

            CustomGroupBox buf = new CustomGroupBox();
            instruments.Controls.Add(buf);
            buf.Size = new Size(100, instruments.Height);
            buf.Location = new Point(0, 0);

            CustomGroupBox main = new CustomGroupBox();
            instruments.Controls.Add(buf);
            main.Size = new Size(100, instruments.Height);

            this.BackColor = Color.FromArgb(200, 200, 200); 
            this.Size = new System.Drawing.Size(1450, 850);
            this.KeyPreview = true;
            this.KeyDown += CancelAction;
            this.Name = "MyPaint";

            canvas = new Canvas();
            canvas.Location = new Point(border, border + settings.Height + instruments.Height);


            this.Controls.Add(instruments);
            this.Controls.Add(settings);
            this.Controls.Add(canvas);
            instruments.Controls.Add(cicleButton1);
        }

        public void CancelAction(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Z)
            {
                canvas.CancelActionCanvas();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(2);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
