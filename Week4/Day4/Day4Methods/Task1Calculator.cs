using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day4Methods
{
    internal class Task1Calculator
    {
       
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        static void Main()
        {
            Console.Write("enter a value:");
            int a = int.Parse(Console.ReadLine());
            Console.Write("enter b value:");
            int b = int.Parse(Console.ReadLine());
            Task1Calculator calc = new Task1Calculator();
            int add=calc.Add(a, b);
            Console.WriteLine($"Addition:{add}");
            int sub=calc.Subtract(a, b);
            Console.WriteLine($"Subtraction:{sub}");
        }

    }
}
