using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommApp.DataAccess
{
    public interface IProductInfoRepo<T>
    {
        Task<T> AddProduct(T entity);

        Task<T> RemoveProduct(int id);

        Task<T> UpdateProduct(T entity);

        Task<T> Search(int id);

        Task<List<T>> GetAllProducts();

        
    }
}