using ECommApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.DataAccess
{
    public interface IProductInfoRepo1<T>
    {
        Task<List<T>> GetAllProducts();

    }
}
