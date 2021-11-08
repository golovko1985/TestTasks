using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public class Circle : Shape
    {
        private float radius;
        private SolidBrush brush;

        public float Radius
        {
            get => radius;
            set => radius = value < 0 ? -value : value; 
        }

        public override SolidBrush Brush
        {
            get => brush; 
            set => brush = value;
        }

        public override void Draw(Graphics g, int x, int y)
        {
            g.FillEllipse(Brush, x, y, Radius, Radius);
        }
        public Circle(SolidBrush sb, float radius)
        {
            this.Brush = sb;
            this.Radius = radius;
        }

        public override double GetArea() => Math.PI* Radius * Radius;

        public override double GetPerimeter() => Math.PI * Radius;
    }
}
