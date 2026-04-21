using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Exceptions;

namespace DAL.DataAccess
{
    public class ContactRepo(AppDbContext context) : IContactRepo
    {
        private readonly AppDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

        // ✅ GET ALL
        public async Task<IReadOnlyList<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        // ✅ GET BY ID
        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await GetContactOrThrowAsync(id, track: false);
        }

        // ✅ ADD
        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            ValidateContact(contact);

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        // ✅ UPDATE
        public async Task UpdateAsync(int id, ContactInfo contact)
        {
            ValidateContact(contact);

            var existing = await GetContactOrThrowAsync(id, track: true);

            // Explicit mapping (safe update)
            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            await _context.SaveChangesAsync();
        }

        // ✅ DELETE
        public async Task DeleteAsync(int id)
        {
            var contact = await GetContactOrThrowAsync(id, track: true);

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        // 🔹 Reusable method (removes duplication)
        private async Task<ContactInfo> GetContactOrThrowAsync(int id, bool track)
        {
            IQueryable<ContactInfo> query = _context.Contacts;

            if (!track)
                query = query.AsNoTracking();

            var contact = await query
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);

            return contact ?? throw new NotFoundException($"Contact with ID {id} not found");
        }

        // 🔹 Validation
        private static void ValidateContact(ContactInfo contact)
        {
            ArgumentNullException.ThrowIfNull(contact);

            if (string.IsNullOrWhiteSpace(contact.FirstName))
                throw new ArgumentException("First Name is required");

            if (string.IsNullOrWhiteSpace(contact.EmailId))
                throw new ArgumentException("Email is required");
        }
    }
}