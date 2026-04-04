using System;
using System.Collections.Generic;

namespace DecisionMakingConstructors.HandsOn.WEEK5
{
    // ✅ Record / Structure
    public class Student
    {
        public int RollNumber { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public int Marks { get; set; }
    }

    public class StudentTask1
    {
        static List<Student> students = new List<Student>();

        static void Main()
        {
            int choice;

            do
            {
                Console.WriteLine("\n--- Student Record Management ---");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display All Students");
                Console.WriteLine("3. Search by Roll Number");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                // ✅ Better input handling
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddStudents();
                        break;

                    case 2:
                        DisplayStudents();
                        break;

                    case 3:
                        SearchStudent();
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

            } while (choice != 4);
        }

        // ✅ Add Students
        static void AddStudents()
        {
            Console.Write("Enter number of students: ");
            int count;

            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.Write("Invalid input. Enter a valid number: ");
            }

            for (int i = 0; i < count; i++)
            {
                Student s = new Student();

                // Roll Number with duplicate check
                Console.Write("Enter Roll Number: ");
                int roll;
                while (!int.TryParse(Console.ReadLine(), out roll))
                {
                    Console.Write("Invalid Roll Number. Enter again: ");
                }

                if (students.Exists(st => st.RollNumber == roll))
                {
                    Console.WriteLine("❌ Roll Number already exists! Try again.");
                    i--;
                    continue;
                }
                s.RollNumber = roll;

                // Name validation
                Console.Write("Enter Name: ");
                s.Name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(s.Name))
                {
                    Console.Write("Name cannot be empty. Enter again: ");
                    s.Name = Console.ReadLine();
                }

                // Course validation
                Console.Write("Enter Course: ");
                s.Course = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(s.Course))
                {
                    Console.Write("Course cannot be empty. Enter again: ");
                    s.Course = Console.ReadLine();
                }

                // Marks validation
                Console.Write("Enter Marks: ");
                int marks;
                while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
                {
                    Console.Write("Invalid Marks (0-100). Enter again: ");
                }
                s.Marks = marks;

                students.Add(s);
            }

            Console.WriteLine("✅ Students added successfully!");
        }

        // ✅ Display Students
        static void DisplayStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("⚠ No records found.");
                return;
            }

            Console.WriteLine("\n--- Student Records ---");
            foreach (var s in students)
            {
                Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
            }
        }

        // ✅ Search Student
        static void SearchStudent()
        {
            Console.Write("Enter Roll Number to search: ");
            int roll;

            if (!int.TryParse(Console.ReadLine(), out roll))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            var student = students.Find(s => s.RollNumber == roll);

            Console.WriteLine("\n--- Search Result ---");
            if (student != null)
            {
                Console.WriteLine("✅ Student Found:");
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("❌ Student not found.");
            }
        }
    }
}