using Microsoft.AspNetCore.Mvc;
using week7Day3.Models;
using week7Day3.Repos;

namespace week7Day3.Controllers
{
    [Route("contact")] // Base route
    public class ContactController : Controller
    {
        private readonly IContactService<ContactInfo> _contactService;

        public ContactController(IContactService<ContactInfo> contactService)
        {
            _contactService = contactService;
        }

        [Route("/")]
        [HttpGet("show", Name = "show")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts(); 
            return View(contacts);
        }

        // GET: contact/get/5
        [HttpGet("get/{id}", Name = "get")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // GET: contact/add
        [HttpGet("add", Name = "add")]
        public IActionResult AddContact()
        {
            return View();
        }

        // POST: contact/add
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToRoute("show");
        }
    }
}