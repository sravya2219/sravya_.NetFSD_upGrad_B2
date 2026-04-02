using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day4
{
    internal class TuplesandPatterMatchingTask3
    {
        static void Main()
        {
            Console.Write("Employee Name:");
            var name = Console.ReadLine();
            Console.Write("sales Amount:");
            var amount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Rating:");
            var rate = Convert.ToInt32(Console.ReadLine());
           

            var result = GetPerformance(amount, rate);

            //pattern matching
            string performance = result switch
            {
                ( >= 100000, >= 4) => "High Performance",
                ( >= 50000, >= 3) => "Average Performance",
                _ => "Need Improvement"
            };
            Console.WriteLine("\nEmployee Name: " + name);
            Console.WriteLine("Sales Amount: " + result.amount);
            Console.WriteLine("Rating: " + result.rate);
            Console.WriteLine("Performance: " + performance);

        }
        public static (double amount,int rate) GetPerformance(double amount,int rate)
        {
            return (amount,rate);
        }
    }
}
