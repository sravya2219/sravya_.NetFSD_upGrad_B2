using ContactManagement.API.Models;

namespace ContactManagement.API.DataAccess
{
    public interface IContactRepo
    {
        Task<List<ContactInfo>> GetAllAsync();
        Task<ContactInfo?> GetByIdAsync(int id);
        Task<ContactInfo> AddAsync(ContactInfo contact);
        Task<bool> UpdateAsync(int id, ContactInfo contact);
        Task<bool> DeleteAsync(int id);
    }
}
