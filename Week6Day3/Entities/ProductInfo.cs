using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Entities
{
    public  class ProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ListPrice { get; set; }
        public DateTime? ExpiryDate  { get; set; }


    }
}
