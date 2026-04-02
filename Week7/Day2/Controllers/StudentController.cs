
using Microsoft.AspNetCore.Mvc;
using StudentDemo.DataAccess;
using StudentDemo.Models;

namespace StudentDemo.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService<Student> _studentService;
        public StudentController(IStudentService<Student> contactService)
        {
            this._studentService = contactService;
        }
         [Route("/")]
        [Route("Get",Name="Get")]
        public IActionResult ViewAllStudents()
        {
            var student = _studentService.GetAllStudents();
            return View(student);
        }
        [HttpGet]
        [Route("Add",Name ="Add")]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        [Route("Save", Name = "Save")]
        public IActionResult AddStudent(Student student)
        {
            var isSaved = _studentService.AddStudent(student);

            if (isSaved)
            {
              return  RedirectToRoute("Get");
                return View(isSaved);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
