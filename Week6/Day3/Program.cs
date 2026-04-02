using ECommApp.DataAccess;
using ECommApp.Entities;
using ECommApp.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommApp.Main
{
    internal class Program
    {

        static async Task Main()
        {
            Console.WriteLine(DatabaseHelper.GetConnectionString() ?? "NULL VALUE");
            //ProductInfoRepo repo = new ProductInfoRepo();

            //// 🔹 Add Product
            //ProductInfo newProduct = new ProductInfo
            //{
            //    ProductId = 1,
            //    ProductName = "Laptop",
            //    ListPrice = 55000,
            //    ExpiryDate = DateTime.Now.AddYears(2)
            //};

            //await repo.AddProduct(newProduct);
            //Console.WriteLine("Product Added");

            //// 🔹 Get All Products
            //var products = await repo.GetAllProducts();
            //Console.WriteLine("\nAll Products:");
            //foreach (var item in products)
            //{
            //    Console.WriteLine($"{item.ProductId} - {item.ProductName} - {item.ListPrice} - {item.ExpiryDate}");
            //}

            //// 🔹 Search Product
            //var product = await repo.Search(1);
            //if (product != null)
            //{
            //    Console.WriteLine($"\nFound: {product.ProductName}");
            //}

            //// 🔹 Update Product
            //product.ProductName = "Gaming Laptop";
            //product.ListPrice = 75000;

            //await repo.UpdateProduct(product);
            //Console.WriteLine("Product Updated");

            // 🔹 Delete Product
            //await repo.RemoveProduct(1);
            //Console.WriteLine("Product Deleted");

          

            //Console.ReadLine();


            // Diconnected MOdel

            ProductInfoRepo1 repo1 = new ProductInfoRepo1();
            var products = await repo1.GetAllProducts();
            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductId} - {product.ProductName} - {product.ListPrice} - {product.ExpiryDate}");
            }
        }
    }

}
