using DAL.Models;

namespace DAL.DataAccess
{
    public interface IContactRepo
    {
        Task<IReadOnlyList<ContactInfo>> GetAllAsync();
        Task<ContactInfo> GetByIdAsync(int id);
        Task<ContactInfo> AddAsync(ContactInfo contact);
        Task UpdateAsync(int id, ContactInfo contact);
        Task DeleteAsync(int id);
    }
}