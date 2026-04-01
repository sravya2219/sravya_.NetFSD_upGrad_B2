using Microsoft.AspNetCore.Mvc;
using TagHelpersAndRouting.DataAccess;
using TagHelpersAndRouting.Models;

namespace TagHelpersAndRouting.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService<ContactInfo> _contactService;

        public ContactController(IContactService<ContactInfo> contactService)
        {
            this._contactService = contactService;
        }

        [Route("/")] // default for /contact
        [Route("Data", Name = "Data")]
        public IActionResult ViewAllContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        [HttpGet]
        [Route("AddContact", Name = "AddContact")]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveContact", Name = "SaveContact")]
        public IActionResult AddContact(ContactInfo contact)
        {
            var isSaved = _contactService.AddContact(contact);
            if (isSaved)
            {
                return RedirectToRoute("Data");
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("GetId/{id?}", Name ="GetId")]
        public IActionResult SearchById(int? id)
        {
            var getById = _contactService.GetContactById(id);
            if(getById != null)
            {
                return View(getById);
            }
            else
            {
               return  NotFound();
            }
        }
    }
}