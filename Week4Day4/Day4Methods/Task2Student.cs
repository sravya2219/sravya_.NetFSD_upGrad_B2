using DecisionMakingConstructors.Branching;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day4Methods
{
    internal class Task2Student
    {
        public double CalculateAverage(int m1,int m2,int m3)
        {
            double average = (m1 + m2 + m3) / 3;
            return average;
       
        }
        static void Main()
        {
            Console.Write("enter m1");
            int m1 = int.Parse(Console.ReadLine());
            Console.Write("enter m2");
            int m2 = int.Parse(Console.ReadLine());
            Console.Write("enter m3");
            int m3 = int.Parse(Console.ReadLine());
            Task2Student student = new Task2Student();
            double average = student.CalculateAverage(m1, m2, m3);
            string grade;
            if (average > 80)
            {
                grade = "A";
            }
            else if (average > 70 && average < 80)
            {
                grade = "B";
            }
            else
            {
                grade = "C";
            }

            Console.WriteLine("Average:" + average);
            Console.WriteLine("Grade:" + grade);
        }


    }
}
