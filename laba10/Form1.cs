using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public partial class Form1 : Form
    {
        const int border = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            this.Size = new System.Drawing.Size(1450, 850);
            BorderlessForm inside_form = new BorderlessForm();
            inside_form.TopLevel = false;
            inside_form.Location = new Point(border, border);
            this.Controls.Add(inside_form);
            inside_form.Show();
        } 


        private void cicleButton1_Click_1(object sender, EventArgs e)
        {
 if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color c = colorDialog1.Color;
            }
        }
    }
}
