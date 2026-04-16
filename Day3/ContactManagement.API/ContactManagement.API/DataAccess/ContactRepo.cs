using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
  
        public class ContactRepo : IContactRepo
        {
            // Static List (Mandatory)
            public static List<ContactInfo> contacts = new List<ContactInfo>();
            private static int _nextId = 1;

        static ContactRepo()
        {
            contacts.Add(new ContactInfo
            {
                ContactId = _nextId++,
                FirstName = "Sravya",
                LastName = "Y",
                EmailId = "sravya@gmail.com",
                MobileNo = 9876543210,
                Designation = "Developer",
                CompanyId = 1,
                DepartmentId = 1
            });
        }

            public async Task<List<ContactInfo>> GetAllAsync()
            {
                return await Task.FromResult(contacts);
            }

            public async Task<ContactInfo?> GetByIdAsync(int id)
            {
                var contact = contacts.FirstOrDefault(c => c.ContactId == id);
                return await Task.FromResult(contact);
            }

            public async Task<ContactInfo> AddAsync(ContactInfo contact)
            {
                contact.ContactId = _nextId++;
                contacts.Add(contact);
                return await Task.FromResult(contact);
            }

            public async Task<bool> UpdateAsync(int id, ContactInfo contact)
            {
                var existing = contacts.FirstOrDefault(c => c.ContactId == id);

                if (existing == null)
                    return await Task.FromResult(false);

                existing.FirstName = contact.FirstName;
                existing.LastName = contact.LastName;
                existing.EmailId = contact.EmailId;
                existing.MobileNo = contact.MobileNo;
                existing.Designation = contact.Designation;
                existing.CompanyId = contact.CompanyId;
                existing.DepartmentId = contact.DepartmentId;

                return await Task.FromResult(true);
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var contact = contacts.FirstOrDefault(c => c.ContactId == id);

                if (contact == null)
                    return await Task.FromResult(false);

                contacts.Remove(contact);
                return await Task.FromResult(true);
            }
        }
    }

