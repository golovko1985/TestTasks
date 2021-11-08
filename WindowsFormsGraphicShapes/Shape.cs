using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public abstract class Shape
    {
        public abstract SolidBrush Brush { get; set; }
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract void Draw(Graphics g, int x, int y);


    }
}
