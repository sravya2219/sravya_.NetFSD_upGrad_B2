using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.Day4Methods
{
    internal class Task3
    {

        public static void CalculateResult(int m1, int m2, int m3, out int totalMarks, out double averageMarks)
        {
            totalMarks = m1 + m2 + m3;
            averageMarks = totalMarks / 3.0;
        }

        static void Main()
        {
            char choice;

            do
            {
                int m1, m2, m3;

                Console.WriteLine("Enter marks for 3 subjects (0-100):");

                m1 = GetValidMarks("Subject 1: ");
                m2 = GetValidMarks("Subject 2: ");
                m3 = GetValidMarks("Subject 3: ");

                int total;
                double average;

                // Method call with out parameters
                CalculateResult(m1, m2, m3, out total, out average);

                Console.WriteLine("Total Marks = " + total);
                Console.WriteLine("Average Marks = " + average);

                if (average >= 40)
                    Console.WriteLine("Result: Pass");
                else
                    Console.WriteLine("Result: Fail");

                Console.Write("Do you want to enter another student? (y/n): ");
                choice = char.ToLower(Console.ReadKey().KeyChar);
                Console.WriteLine();

            } while (choice == 'y');
        }

        // Method for input validation
        public static int GetValidMarks(string subject)
        {
            int marks;
            while (true)
            {
                Console.Write(subject);
                marks = int.Parse(Console.ReadLine());

                if (marks >= 0 && marks <= 100)
                    return marks;
                else
                    Console.WriteLine("Invalid marks! Please enter between 0 and 100.");
            }
        }
    }
}

