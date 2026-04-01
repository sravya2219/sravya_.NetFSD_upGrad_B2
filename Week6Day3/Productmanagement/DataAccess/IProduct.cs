using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Productmanagement.DataAccess
{
    public interface IProduct<T>
    {
       
            Task<T> AddProduct(T entity);

        Task<bool> RemoveProduct(int id);

        Task<T> UpdateProduct(T entity);



        Task<List<T>> GetAllProducts();


    }
}
