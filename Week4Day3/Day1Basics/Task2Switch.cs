using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day1Basics
{
    internal class Task2Switch
    {
        static void Main()
        {
            Console.Write("enter number1:");
            double num1 = double.Parse(Console.ReadLine());
            Console.Write("enter number12:");
            double num2 = double.Parse(Console.ReadLine());
            Console.Write("enter operator (+,-,*,/):");
            char op = Convert.ToChar(Console.ReadLine());
            double result = 0;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine(result);
                    break;
                case '-':
                    result = num1 - num2;
                    Console.WriteLine(result);
                    break;
                case '*':
                    result = num1 * num2;
                    Console.WriteLine(result);
                    break;
                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine(result);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator");
                    break;
            }

        }
    }
}
