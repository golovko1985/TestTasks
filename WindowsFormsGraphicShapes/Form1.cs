using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsGraphicShapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Gray);

            List<Shape> shapes = new List<Shape>();
            SolidBrush brush = new SolidBrush(Color.Coral);

            Shape r = new Rectangle(brush, 80, 40);
            r.Draw(g, 120, 60);
            shapes.Add(r);

            Shape s = new Square(brush, 70);
            s.Draw(g, 250, 150);
            shapes.Add(s);

            brush = new SolidBrush(Color.Gold);
            Shape c = new Circle(brush, 60);
            c.Draw(g, 350, 230);
            shapes.Add(c);

            Shape r2 = new Rectangle(brush, 60, 125);
            r2.Draw(g, 500, 100);
            shapes.Add(r2);

            Shape t = new Triangle(brush, 80, 60);
            t.Draw(g, 700, 200);
            shapes.Add(t);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var shape in shapes)
            {
                stringBuilder.AppendLine($"Object: {shape.GetType().Name, -15}" +
                                         $"Color: {shape.Brush.Color.Name, -10}" +
                                         $"Area: {shape.GetArea(), -15:F2}" +
                                         $"Perimeter: {shape.GetPerimeter(), -15:F2}");
            }
            textBox1.Text = stringBuilder.ToString();
        }
    }
}
