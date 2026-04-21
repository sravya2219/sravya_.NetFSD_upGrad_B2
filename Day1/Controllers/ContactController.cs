using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL.DataAccess;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ContactController(IContactRepo repo, ILogger<ContactController> logger) : ControllerBase
    {
        private readonly IContactRepo _repo = repo;
        private readonly ILogger<ContactController> _logger = logger;


        // ✅ GET ALL (Admin + User)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repo.GetAllAsync();
            _logger.LogInformation("Retrieved all contacts");
            return Ok(data);
        }

        // ✅ GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _repo.GetByIdAsync(id);

            if (contact == null)
                return NotFound($"Contact with ID {id} not found");

            return Ok(contact);
        }

        // ✅ CREATE (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repo.AddAsync(contact);
            _logger.LogInformation("Contact created: {Name}", contact.FirstName);

            return CreatedAtAction(nameof(GetById), new { id = result.ContactId }, result);
        }

        // ✅ UPDATE (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ContactInfo contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _repo.UpdateAsync(id, contact);

                _logger.LogInformation("Contact updated: ID {Id}", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Update failed: ID {Id}", id);
                return NotFound($"Contact with ID {id} not found");
            }
        }

        // ✅ DELETE (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repo.DeleteAsync(id);

                _logger.LogWarning("Contact deleted: ID {Id}", id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Delete failed: ID {Id}", id);
                return NotFound($"Contact with ID {id} not found");
            }
        }
    }
}