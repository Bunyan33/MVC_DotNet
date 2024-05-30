using MVC_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC_DotNet.DAL
{
    public class ProductDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["defaultConnection"].ToString();

        //Get all products
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = reader.GetInt32(reader.GetOrdinal("ProductId")),
                        ProductName =  reader.GetString(reader.GetOrdinal("ProductName")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                       
                    });
                }
            }
            
            return products;
        }

        //Insert Product
        public bool InsertProduct(Product product)
        {
            int id = 0;
            using (var connection = new SqlConnection(conString))
            {
                connection.Open();
                var command = new SqlCommand("InsertProduct", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Qty", product.Qty);
               
                id = command.ExecuteNonQuery();
            }
            if (id >0)
            {
                return true;
            }
            return false;
               
        }
    }
}