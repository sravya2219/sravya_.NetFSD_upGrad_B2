using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day4Methods
{
    internal class Task5Recursive
    {
        public static int CalculatePower(int baseNum,int exponent)
        {
            if (exponent == 0)
                return 1;
            return baseNum * CalculatePower(baseNum, exponent - 1);
        }
        static void Main()
        {
            Console.Write("Enter Base: ");
            int baseNum = int.Parse(Console.ReadLine());

            Console.Write("Enter Exponent: ");
            int exponent = int.Parse(Console.ReadLine());

            int result = CalculatePower(baseNum, exponent);

            Console.WriteLine("Base: " + baseNum);
            Console.WriteLine("Exponent: " + exponent);
            Console.WriteLine("Result (Power): " + result);
        }
    }
}
