using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public class Rectangle : Shape
    {
        private float width;
        private float height;

        public float Width
        {
            get => width; 
            set => width = value < 0 ? -value : value; 
        }
        public float Height
        {
            get => height; 
            set => height = value < 0 ? -value : value;
        }
        public Rectangle(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }
        public override void Draw(Graphics g, SolidBrush brush, int x, int y)
        {
            g.FillRectangle(brush, x, y, Width, Height);
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return Width * 2 + Height * 2;
        }
    }
}
