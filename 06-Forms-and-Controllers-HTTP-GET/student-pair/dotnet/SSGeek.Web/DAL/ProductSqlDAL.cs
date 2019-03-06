using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public class ProductSqlDAL : IProductDAL
    {
        private string connectionString;

        public ProductSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            Product product = new Product();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM products WHERE product_id = @productID", conn);
                cmd.Parameters.AddWithValue("@productID", id);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {    
                    product.Id = Convert.ToInt32(reader["product_id"]);
                    product.Name = Convert.ToString(reader["name"]);
                    product.Description = Convert.ToString(reader["description"]);
                    product.Cost = Convert.ToInt32(reader["price"]);
                    product.ImageName = Convert.ToString(reader["image_name"]);
                }
            }
            return product;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> output = new List<Product>();

            //Always wrap connection to a database in a try-catch block
            try
            {
                //Create a SqlConnection to our database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from products", connection);

                    // Execute the query to the database
                    SqlDataReader reader = cmd.ExecuteReader();

                    // The results come back as a SqlDataReader. Loop through each of the rows
                    // and add to the output list
                    while (reader.Read())
                    {
                        // Read in the value from the reader
                        // Reference by index or by column_name
                        Product product = new Product();
                        product.Id = Convert.ToInt32(reader["product_id"]);
                        product.Name = Convert.ToString(reader["name"]);
                        product.Description = Convert.ToString(reader["description"]);
                        product.Cost = Convert.ToInt32(reader["price"]);
                        product.ImageName = Convert.ToString(reader["image_name"]);

                        // Add the department to the output list                       
                        output.Add(product);
                    }
                }
            }
            catch (SqlException ex)
            {
                // A SQL Exception Occurred. Log and throw to our application!!
                throw;
            }
            return output;
        }
    }
}
