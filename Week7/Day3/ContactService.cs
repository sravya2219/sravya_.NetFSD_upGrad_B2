using week7Day3.Models;

namespace week7Day3.Repos
{
    public class ContactService : IContactService<ContactInfo>
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ravi",
                LastName = "Kumar",
                CompanyName = "TCS",
                EmailId = "ravi.kumar@gmail.com",
                MobileNo = 9876543210,
                Designation = "Software Engineer"
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Sita",
                LastName = "Reddy",
                CompanyName = "Infosys",
                EmailId = "sita.reddy@gmail.com",
                MobileNo = 9123456780,
                Designation = "System Analyst"
            },
            new ContactInfo
            {
                ContactId = 3,
                FirstName = "Arjun",
                LastName = "Varma",
                CompanyName = "Wipro",
                EmailId = "arjun.varma@gmail.com",
                MobileNo = 9012345678,
                Designation = "Developer"
            },
            new ContactInfo
            {
                ContactId = 4,
                FirstName = "Priya",
                LastName = "Sharma",
                CompanyName = "HCL",
                EmailId = "priya.sharma@gmail.com",
                MobileNo = 9988776655,
                Designation = "Tester"
            },
            new ContactInfo
            {
                ContactId = 5,
                FirstName = "Kiran",
                LastName = "Naidu",
                CompanyName = "Capgemini",
                EmailId = "kiran.naidu@gmail.com",
                MobileNo = 9090909090,
                Designation = "Team Lead"
            }
        };

        public void AddContact(ContactInfo contact)
        {
            contacts.Add(contact);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id);
        }
    }
}