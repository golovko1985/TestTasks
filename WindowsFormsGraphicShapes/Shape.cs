using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public abstract class Shape 
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
        public abstract void Draw(Graphics g, SolidBrush drawDevice, int x, int y);
    }
}
