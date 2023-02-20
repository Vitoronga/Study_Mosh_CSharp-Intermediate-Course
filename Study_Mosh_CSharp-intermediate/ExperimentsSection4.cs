using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    internal class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Shape method executed");
        }
    }

    internal class Circle : Shape
    {
        public int x { get; set; }
        public int y { get; set; }

        public override void Draw()
        {
            Console.WriteLine("Circle method executed");
        }
    }

    internal class ExperimentsSection4
    {
        public static void Start()
        {
            Shape shape = new Shape();
            Circle circle = new Circle();

            shape.Draw();
            circle.Draw();

            shape = circle;
            shape.Draw();

        }
    }
}
