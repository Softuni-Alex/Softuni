using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Shapes.Interfaces;
using Shapes.Shapes;

namespace Shapes
{

    class MainClass
    {
        static void Main()
        {

            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(3, 2);
            Rhombus rhombus = new Rhombus(3, 2, 5);


            IShape[] shapes = new IShape[3]
            {
               circle,rectangle,rhombus
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("{0}: Perimeter: {1}, Area: {2}", shape.GetType().Name, shape.CalculatePerimeter(), shape.CalculateArea());
            }





        }
    }
}
