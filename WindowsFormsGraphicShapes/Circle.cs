using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public class Circle : Shape
    {
        private float radius;
        public float Radius
        {
            get => radius;
            set => radius = value < 0 ? -value : value; 
        }
        public override void Draw(Graphics g, SolidBrush pen, int x, int y)
        {
            g.FillEllipse(pen, x, y, Radius, Radius);
        }
        public Circle(float radius)
        {
            this.Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return Math.PI * Radius;
        }
    }
}
