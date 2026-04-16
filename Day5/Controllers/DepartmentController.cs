using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Departments.ToList());
        }

        // ✅ ADD
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            _context.Departments.Add(dept);
            _context.SaveChanges();
            return Ok(dept);
        }
    }
}