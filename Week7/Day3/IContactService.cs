using week7Day3.Models;

namespace week7Day3.Repos
{
    public interface IContactService<TEntity>
    {
        List<TEntity> GetAllContacts();
        TEntity GetContactById(int id);
        void AddContact(ContactInfo contact);
    }
}
