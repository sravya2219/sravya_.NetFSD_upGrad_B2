using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day1Basics
{
    internal class Task1Statements
    {
        static void Main()
        {
            Console.Write("enter Name:");
            string name = Console.ReadLine();
            Console.Write("enter marks:");
            int marks = int.Parse(Console.ReadLine());
            if(marks<0 || marks > 100)
            {
                Console.WriteLine("invalid marks");
            }
            else
            {
                string grade;
                if (marks >= 90)
                {
                    grade = "A";
                }
                else if(marks>=75 && marks < 90)
                {
                    grade = "B";
                }
                else if (marks >= 60 && marks < 75)
                {
                    grade = "C";
                }
                else if (marks >= 50 && marks < 60)
                {
                    grade = "D";
                }
                else
                {
                    grade = "Fail";
                }
                Console.WriteLine("Student:" + name);
                Console.WriteLine("Grade:" + grade);
            }

        }
    }
}
