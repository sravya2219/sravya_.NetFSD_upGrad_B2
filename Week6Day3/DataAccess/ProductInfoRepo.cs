using ECommApp.DataAccess;
using ECommApp.Entities;
using ECommApp.Util;
using Microsoft.Data.SqlClient;
using System.Data;

public class ProductInfoRepo : IProductInfoRepo<ProductInfo>
{
    public async Task<ProductInfo> AddProduct(ProductInfo entity)
    {
        try
        {
            using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
            using var cmd = new SqlCommand(
                "INSERT INTO ProductInfo (ProductId, ProductName, ListPrice, ExpiryDate) VALUES (@id,@name,@price,@expiry)", sqlCon);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = entity.ProductId;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = entity.ProductName;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = entity.ListPrice;
            cmd.Parameters.Add("@expiry", SqlDbType.DateTime).Value = entity.ExpiryDate;

           await sqlCon.OpenAsync();
            await cmd.ExecuteNonQueryAsync(); // to perform insert, delete,update

            return entity;
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<List<ProductInfo>> GetAllProducts()
    {
        var products = new List<ProductInfo>();

        try
        {
            using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
            using var cmd = new SqlCommand("SELECT * FROM ProductInfo", sqlCon);

            await sqlCon.OpenAsync();

            using var dr = await cmd.ExecuteReaderAsync();

            while (await dr.ReadAsync())
            {
                products.Add(new ProductInfo
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    ListPrice = Convert.ToDouble(dr["ListPrice"]),
                    ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"])
                });
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return products;
    }

    public async Task<ProductInfo> RemoveProduct(int id)
    {
        var product = await Search(id);

        try
        {
            using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
            using var cmd = new SqlCommand("DELETE FROM ProductInfo WHERE ProductId=@id", sqlCon);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            await sqlCon.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return product;
    }

    public async Task<ProductInfo> UpdateProduct(ProductInfo entity)
    {
        try
        {
            using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
            using var cmd = new SqlCommand(
                @"UPDATE ProductInfo 
                  SET ProductName=@name, ListPrice=@price, ExpiryDate=@expiry 
                  WHERE ProductId=@id", sqlCon);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = entity.ProductId;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = entity.ProductName;
            cmd.Parameters.Add("@price", SqlDbType.Decimal).Value = entity.ListPrice;
            cmd.Parameters.Add("@expiry", SqlDbType.DateTime).Value = entity.ExpiryDate;

            await sqlCon.OpenAsync();
            await cmd.ExecuteNonQueryAsync();

            return entity;
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<ProductInfo> Search(int id)
    {
        ProductInfo product = null;

        try
        {
            using var sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString());
            using var cmd = new SqlCommand("SELECT * FROM ProductInfo WHERE ProductId=@id", sqlCon);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

            await sqlCon.OpenAsync();

            using var dr = await cmd.ExecuteReaderAsync();

            if (await dr.ReadAsync())
            {
                product = new ProductInfo
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = dr["ProductName"].ToString(),
                    ListPrice = Convert.ToDouble(dr["ListPrice"]),
                    ExpiryDate = Convert.ToDateTime(dr["ExpiryDate"])
                };
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return product;
    }
}