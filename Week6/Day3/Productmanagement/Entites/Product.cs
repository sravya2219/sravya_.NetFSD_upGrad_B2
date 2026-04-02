using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Productmanagement.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public string Category { get; set; }
        public Decimal Price { get; set; }
             

    }
}
