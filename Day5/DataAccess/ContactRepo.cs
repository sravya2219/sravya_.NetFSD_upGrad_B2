using DAL.Models;
using Microsoft.EntityFrameworkCore;
using DAL.Exceptions;   // ✅ add this

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
        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            var contact = await _context.Contacts
                .AsNoTracking()
                .Include(c => c.Company)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
                throw new NotFoundException($"Contact with ID {id} not found");

            return contact;
        }

        // ✅ ADD
        public async Task<ContactInfo> AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        // ✅ UPDATE
        public async Task<bool> UpdateAsync(int id, ContactInfo contact)
        {
            var existing = await _context.Contacts
                .FirstOrDefaultAsync(c => c.ContactId == id);

            if (existing == null)
                throw new NotFoundException($"Contact with ID {id} not found");

            _context.Entry(existing).CurrentValues.SetValues(contact);

            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                throw new NotFoundException($"Contact with ID {id} not found");

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}