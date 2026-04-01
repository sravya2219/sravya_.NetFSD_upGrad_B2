using ECommApp.Entities;
using ECommApp.Productmanagement.Entites;
using ECommApp.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommApp.Productmanagement.DataAccess
{
    public class ProductRepo : IProduct<Product>
    {
        public async Task<Product> AddProduct(Product entity)
        {
            try
            {
                using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
                using var cmd = new SqlCommand("sp_InsertProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = entity.ProductName;
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = entity.Category;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = entity.Price;

                await sqlCon.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                return entity;            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public async Task<Product> UpdateProduct(Product entity)
        {
            try
            {
                using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
                using var cmd = new SqlCommand("sp_UpdateProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = entity.ProductId;
                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = entity.ProductName;
                cmd.Parameters.Add("@category", SqlDbType.VarChar).Value = entity.Category;
                cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = entity.Price;

                await sqlCon.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                return entity;
            }catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> RemoveProduct(int id)
        {


            try
            {
                using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
                using var cmd = new SqlCommand("sp_DeleteProduct", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                await sqlCon.OpenAsync();
              int rows=  await cmd.ExecuteNonQueryAsync();
                if(rows == 0)
                {
                    
                        Console.WriteLine("No record found to delete");
                        return false;
                  

                    
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return true;

           }
        public async Task<List<Product>> GetAllProducts()
        {
            var products = new List<Product>();

            try
            {
                using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
                using var cmd = new SqlCommand("sp_GetAllProducts", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                await sqlCon.OpenAsync();

                using var dr = await cmd.ExecuteReaderAsync();

                while (await dr.ReadAsync())
                {
                    products.Add(new Product
                    {
                        ProductId = Convert.ToInt32(dr["ProductId"]),
                        ProductName = dr["ProductName"].ToString(),
                        Category = dr["Category"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"])
                    });
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return products;
        }

    }
}
