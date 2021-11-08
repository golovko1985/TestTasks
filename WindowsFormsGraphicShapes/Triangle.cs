using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    class Triangle : Shape
    {
        private int leg1;
        private int leg2;
        private SolidBrush brush;

        public int Leg1
        {
            get => leg1;
            set => leg1 = value < 0 ? -value : value;
        }
        public int Leg2
        {
            get => leg2;
            set => leg2 = value < 0 ? -value : value;
        }

        public override SolidBrush Brush
        {
            get => brush; 
            set => brush = value; 
        }

        public Triangle(SolidBrush sb, int leg1Length, int leg2Length)
        {
            this.Brush = sb;
            this.Leg1 = leg1Length;
            this.Leg2 = leg2Length;
        }
        public override void Draw(Graphics g, int x, int y)
        {
            g.FillPolygon(Brush, new Point[]
              {
                new Point(x, y),
                new Point(x + Leg1, y),
                new Point(x, y + Leg2)
              });
        }

        public override double GetArea() => Leg1 * Leg2 * 0.5;

        public override double GetPerimeter()
        {
            double hypotenuse = Math.Sqrt(Leg1 * Leg1 + Leg2 * Leg2);
            return hypotenuse + Leg1 + Leg2;
        }
    }
}
