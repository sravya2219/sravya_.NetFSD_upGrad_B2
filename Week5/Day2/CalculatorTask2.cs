using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5
{
    internal class CalculatorTask2
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            CalculatorTask2 calc = new CalculatorTask2();

            Console.Write("Enter Numerator: ");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Denominator: ");
            int den = Convert.ToInt32(Console.ReadLine());

            calc.Divide(num, den);

            Console.WriteLine("Program continues...");
        }
    }
}
