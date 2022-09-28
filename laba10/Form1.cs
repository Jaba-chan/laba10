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
            canvas = new Canvas();
            this.BackColor = Color.FromArgb(200, 200, 200); 
            this.Size = new System.Drawing.Size(1450, 850);
            canvas.Location = new Point(border, border);
            
            this.Controls.Add(canvas);
        }

        private void cicleButton1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(-1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(-2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            canvas.SetIndex(2);
        }
    }
}
