using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public class Rectangle : Shape
    {
        private float width;
        private float height;
        private SolidBrush brush;

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

        public override SolidBrush Brush
        {
            get => brush;
            set => brush = value;
        }

        public Rectangle(SolidBrush solidBrush, float width, float height)
        {
            this.Brush = solidBrush;
            this.Width = width;
            this.Height = height;
        }

        public override void Draw(Graphics g,  int x, int y)
        {
            g.FillRectangle(Brush, x, y, Width, Height);
        }

        public override double GetArea() => Width * Height;

        public override double GetPerimeter() => Width * 2 + Height * 2;
    }
}
