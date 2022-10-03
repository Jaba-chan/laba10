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
        }

        private void cicleButton1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
            }
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

        private void customGroupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
