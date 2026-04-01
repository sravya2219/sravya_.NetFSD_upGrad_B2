using TagHelpersAndRouting.Models;

namespace TagHelpersAndRouting.DataAccess
{
    public class ContactService : IContactService<ContactInfo>
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "sravya",
                LastName = "yaragorla",
                CompanyName = "TCS",
                EmailId = "yaragorla@gmail.com",
                MobileNo = 9392087839,
                Designation = "software"
            }
        };

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public bool AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
            return true;
        }

        public ContactInfo GetContactById(int? id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}