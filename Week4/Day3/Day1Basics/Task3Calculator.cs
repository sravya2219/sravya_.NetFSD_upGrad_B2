using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day1Basics
{
    internal class Task3Calculator
    {
        static void Main()
        {
            Console.Write("enter employee name:");
            string name = Console.ReadLine();
            Console.Write("enter employee salary:");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("enter year of experience:");
            int expe = int.Parse(Console.ReadLine());
            double bonusPercent;
            if (expe < 2)
            {
                 bonusPercent = 0.05;
               

            }
            else if(expe>2 && expe <= 5)
            {
                 bonusPercent = 0.10;
               
            }
            else
            {
                 bonusPercent = 0.15;
                
            }
            double bonus = salary > 0 ? salary * bonusPercent : 0;
            double finalSalary = salary + bonus;
            Console.WriteLine("Name:" + name);
            Console.WriteLine("Bonus:" + bonus);
            Console.WriteLine("Final Salary:" + finalSalary);
        }
    }
}
