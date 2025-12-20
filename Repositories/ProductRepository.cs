using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ProductionSystem.Data;
using ProductionSystem.Models;

namespace ProductionSystem.Repositories
{
    public class ProductRepository
    {
        public void InsertProduct(Product product)
        {
            // 1. First open the connection database 
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                // 2. Create the SQL command
                string query = "INSERT INTO Products (Code, ProductName, ProductDescription, UOM) " + "VALUES (@Code, @ProductName, @ProductDescription, @UOM)";

                // 3. Pass as a params
                SqlCommand command = new SqlCommand(query, connection);

                // 4. Values by params
                command.Parameters.AddWithValue("@Code", product.Code);
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@UOM", product.UOM);

                // 5. Executing and passing the values
                command.ExecuteNonQuery();

            }

        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Products";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        Code = reader["Code"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                        ProductDescription = reader["ProductDescription"].ToString(),
                        UOM = reader["UOM"].ToString()
                    };

                    products.Add(product);
                }

            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Products WHERE ProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductId = (int)reader["ProductId"],
                        Code = reader["Code"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                        ProductDescription = reader["ProductDescription"].ToString(),
                        UOM = reader["UOM"].ToString()
                    };

                    return product;
                }

                return null;

            }

        }

        public void UpdateProduct(Product product)
        {
            using(SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Products SET ProductName = @ProductName, Code = @Code, ProductDescription = @ProductDescription, UOM = @UOM WHERE ProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@ProductName", product.ProductName);
                command.Parameters.AddWithValue("@Code", product.Code);
                command.Parameters.AddWithValue("@ProductDescription", product.ProductDescription);
                command.Parameters.AddWithValue("@UOM", product.UOM);
                command.Parameters.AddWithValue("@ProductId", product.ProductId);

                command.ExecuteNonQuery();
            }
        }
    }
}