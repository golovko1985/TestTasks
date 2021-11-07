using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGraphicShapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.Black);

            SolidBrush brush = new SolidBrush(Color.Coral);
            List<Shape> shapes = new List<Shape>();
            Shape r = new Rectangle(30, 20);
            r.Draw(g, brush, 20, 50);
            shapes.Add(r);
            var area = r.GetArea();
            var perimeter = r.GetPerimeter();

            Shape s = new Square(10);
            s.Draw(g, brush, 120, 150);
            shapes.Add(s);

            brush = new SolidBrush(Color.Gold);
            Shape c = new Circle(30);
            c.Draw(g, brush, 130, 180);
            shapes.Add(c);

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Object: {shape.GetType().Name} Area: {shape.GetArea()} Perimeter: {shape.GetPerimeter()}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
