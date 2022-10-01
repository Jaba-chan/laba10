using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public class LineList
    {
        private Point _P1;
        private Point _P2;
        private Rectangle _rectangle_;
        private Color _Brush_L;
        private float _brush_weight;
        private int _index; 
        public static long Lenght_l;

        public Point P1
        {
            get { return _P1; }
            set { _P1 = value; }
        }
        public Point P2
        {
            get { return _P2; }
            set { _P2 = value; }
        }
        public Rectangle rectangle
        {
            get { return _rectangle_; }
            set { _rectangle_ = value; }
        }
        public Color Brush_L
        {
            get { return _Brush_L; }
            set { _Brush_L = value; }
        }
        public float brush_weight
        {
            get { return _brush_weight;}
            set { _brush_weight = value; }
        }
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }
 
        public LineList(Point _P1, Point _P2, Color _Brush_L, float _brush_weight, int _index)

        {
            P1 = _P1;
            P2 = _P2;
            Brush_L = _Brush_L;
            brush_weight = _brush_weight;
            index = _index;
            Lenght_l += 1;
        }
        public LineList(Rectangle rect, Color _Brush_L, float _brush_weight, int _index)
        {
            rectangle = rect;
            Brush_L = _Brush_L;
            brush_weight = _brush_weight;
            index = _index;
            Lenght_l += 1;
        }
    }

}
