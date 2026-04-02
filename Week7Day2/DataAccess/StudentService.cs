
using StudentDemo.Models;

namespace StudentDemo.DataAccess
{
    public class StudentService: IStudentService<Student>
    {
        public static List<Student> students = new List<Student>
        {
            new Student
            {
               Name="sravya",
               Age=22,
               Course="cse"
            }
        };
       public List<Student> GetAllStudents()
        {
            return students;
        }
        public bool AddStudent(Student student)
        {
            students.Add(student);
            return true;
        }
    }
}
