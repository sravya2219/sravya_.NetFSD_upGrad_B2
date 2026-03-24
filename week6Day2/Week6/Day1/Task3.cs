using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.Week6.Day1
{
    public abstract class Shape 
    {
        public abstract double CalculateArea();

    }
    public class Rectangle: Shape
    {
         public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double CalculateArea()
        {
            return Length * Width;
        }
    }
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
    class Program2
    {
        static void Main()
        {
            Shape s1 = new Rectangle(10,20);
            Console.WriteLine(s1.CalculateArea());
            Shape s2 = new Circle(10);
            Console.WriteLine(s2.CalculateArea());
        }
    }
}
