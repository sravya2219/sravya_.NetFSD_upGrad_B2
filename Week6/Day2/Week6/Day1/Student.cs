using DecisionMakingConstructors.collections;
using System.Collections.Generic;
using System;


namespace DecisionMakingConstructors.HandsOn.Week6.Day1
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }

    }
    // manage data
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();
        public void AddStudent(Student student)
        {
            students.Add(student);
        }
        public List<Student> GetAllStudents()
        {
            return students;
        }
    }
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("----- Student Report -----");

            foreach (var student in students)
            {
                string grade;

                if (student.Marks >= 90)
                    grade = "A";
                else if (student.Marks >= 75)
                    grade = "B";
                else if (student.Marks >= 50)
                    grade = "C";
                else
                    grade = "Fail";

                Console.WriteLine($"ID: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine($"Grade: {grade}");
                Console.WriteLine("--------------------------");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            StudentRepository repo = new StudentRepository();

            repo.AddStudent(new Student { StudentId = 1, StudentName = "Sravya", Marks = 92 });
            repo.AddStudent(new Student { StudentId = 2, StudentName = "Ravi", Marks = 67 });
            repo.AddStudent(new Student { StudentId = 3, StudentName = "Anu", Marks = 45 });

            ReportGenerator report = new ReportGenerator();
            report.GenerateReport(repo.GetAllStudents());
        }
    }
}
