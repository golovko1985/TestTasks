using System;
using System.Drawing;

namespace WindowsFormsGraphicShapes
{
    public class Square : Rectangle
    {
        public Square(SolidBrush brush, float width) : base(brush, width, width)
        {
        }
    }
}
