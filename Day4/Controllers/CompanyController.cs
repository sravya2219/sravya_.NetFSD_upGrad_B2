using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Companies.ToList());
        }

        // ✅ ADD
        [HttpPost]
        public IActionResult Create(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return Ok(company);
        }
    }
}