using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataAccess
{
    public class ContactRepo : IContactRepo
    {
        private readonly AppDbContext _context;

        public ContactRepo(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET ALL
        public async Task<List<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.Department)
                .ToListAsync();
        }

        // ✅ GET BY ID
        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            return await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);
        }

        // ✅ ADD
        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            var existing = await _context.Contacts.FirstOrDefaultAsync(c => c.ContactId == id);

            if (existing == null)
                return false;

            // safer field updates
            _context.Entry(existing).CurrentValues.SetValues(contact);

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return false;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}