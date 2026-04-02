using ECommApp.Entities;
using ECommApp.Productmanagement.DataAccess;
using ECommApp.Productmanagement.Entites;
using ECommApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Productmanagement.Main
{
    public class Program1
    {
    
            static async Task Main()
            {
                Console.WriteLine(DatabaseHelper.GetConnectionString() ?? "NULL VALUE");
                ProductRepo repo = new ProductRepo();

            // 🔹 Add Product
            //Product newProduct = new Product
            //{
            //    ProductId = 1,
            //    ProductName = "Laptop",
            //    Category = "Device",
            //    Price = 55000

            //};
            //await repo.AddProduct(newProduct);
            //Console.WriteLine("Product Added");

            //update
            //Product product = new Product()
            //{
            //    ProductId =2,
            //    ProductName = "Gaming Laptop",
            //    Category = "Electric Device",
            //    Price = 100000

            //};
            //await repo.UpdateProduct(product);
            //Console.WriteLine("Product Updated");


            Console.WriteLine("Enter Product ID to delete:");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                bool result = await repo.RemoveProduct(id);

                Console.WriteLine(result
                    ? "Product Deleted Successfully"
                    : "Delete Failed");
            }
            else
            {
                Console.WriteLine("Invalid ID entered!");
                return;
            }
            

            // get all products
            var product =await repo.GetAllProducts();
            Console.WriteLine("\nAll Products:");
            foreach (var item in product)
            {
                Console.WriteLine($"{item.ProductId} - {item.ProductName} - {item.Category} - {item.Price}");
            }
        }
    }
}
