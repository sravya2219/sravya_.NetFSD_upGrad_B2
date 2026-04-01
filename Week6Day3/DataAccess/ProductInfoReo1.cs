using ECommApp.Entities;
using ECommApp.Productmanagement.Entites;
using ECommApp.Util;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ECommApp.DataAccess
{
    public  class ProductInfoRepo1 : IProductInfoRepo1<ProductInfo>
    {
        SqlConnection sqlCon;
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public async Task<List<ProductInfo>> GetAllProducts()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            try
            {
                using(sqlCon = new SqlConnection(DatabaseHelper.GetConnectionString()))
                {
                    da = new SqlDataAdapter("select * from ProductInfo", sqlCon);
                    ds.Clear();
                    da.Fill(ds, "ProductDetails");
                    var dataRows = ds.Tables["ProductDetails"].Rows;
                    foreach(DataRow dataRow in dataRows)
                    {

                        ProductInfo product1 = new ProductInfo
                        {
                            ProductId = Convert.ToInt32(dataRow["ProductId"]),
                            ProductName = dataRow["ProductName"].ToString(),
                            ListPrice = Convert.ToDouble(dataRow["ListPrice"]),
                            ExpiryDate = Convert.ToDateTime(dataRow["ExpiryDate"])

                          
                        };
                        products.Add(product1);
                    }
                }

                return products;

            }

            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
                return new List<ProductInfo>();
            }
        }

    }
}
