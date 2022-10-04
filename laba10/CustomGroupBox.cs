using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba10
{
    public class CustomGroupBox : GroupBox
    {
        private string _Text = "";
        private int cosmetic_board_size = 10;
        public CustomGroupBox()
        {
            base.Text = this.Name;
        }
        public override string  Text
        {
            get { return _Text; }
            set { _Text = value; this.Invalidate(); }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            SolidBrush text_color = new SolidBrush(this.ForeColor);
            SolidBrush back_color = new SolidBrush(this.BackColor);
            Pen pen_boards = new Pen(Color.FromArgb(235,235,235), 2);
            Pen pen_cosmetic_board = new Pen(BackColor, 2);
            var size = TextRenderer.MeasureText(this.Text, this.Font);
            int text_x = (this.Width - size.Width) / 2; 
            e.Graphics.FillRectangle(back_color, new Rectangle(0, 0, this.Width - 1, this.Height -1)); 
            e.Graphics.DrawRectangle(pen_boards, new Rectangle(1, 1, this.Width - 2 , this.Height - 2));
            e.Graphics.DrawLine(pen_cosmetic_board, 1, 2, 1, cosmetic_board_size);
            e.Graphics.DrawLine(pen_cosmetic_board, 1, this.Height - cosmetic_board_size, 1, this.Height - 2);
            e.Graphics.DrawLine(pen_cosmetic_board, this.Width - 1, 2, this.Width - 1, cosmetic_board_size);
            e.Graphics.DrawLine(pen_cosmetic_board, this.Width - 1, this.Height - cosmetic_board_size, this.Width - 1, this.Height - 2);
            e.Graphics.DrawString(this.Text, this.Font, text_color, new PointF(text_x, this.Height - (float)1.5*Font.Height));

        }
    }
    
}
