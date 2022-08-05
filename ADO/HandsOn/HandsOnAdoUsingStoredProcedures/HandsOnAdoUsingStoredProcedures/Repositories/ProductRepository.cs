using HandsOnAdoUsingStoredProcedures.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HandsOnAdoUsingStoredProcedures.Repositories
{
    class ProductRepository : IProductRepository
    {
        SqlConnection connection = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Batch2DB;Integrated Security=True");
        SqlCommand command = null;
        public bool AddProduct(Product product)
        {
            //command = new SqlCommand("AddProduct", connection);
            //command.CommandType = System.Data.CommandType.StoredProcedure;
           try
            {

                command = new SqlCommand()
                {
                    CommandText = "AddProduct",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                //passing values to parameters
                command.Parameters.AddWithValue("@Pid", product.Pid);
                command.Parameters.AddWithValue("@Pname", product.Pname);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        public bool DeleteProduct(int Pid)
        {
            try
            {

                command = new SqlCommand()
                {
                    CommandText = "DeleteProduct",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                //passing values to parameters
                command.Parameters.AddWithValue("@Pid",Pid);
              
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public Product GetProduct(int Pid)
        {
            try
            {
                command = new SqlCommand()
                {
                    CommandText = "GetProductById",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                command.Parameters.AddWithValue("@Pid", Pid);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                Product product = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    
                      product=new Product()
                        {
                           
                            Pname = reader["Pname"].ToString(),
                            Price = (int)reader["Price"],
                            Stock = (int)reader["Stock"]
                        };

                    
                }
                return product;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Product> GetProducts()
        {
           try
            {
                command = new SqlCommand()
                {
                    CommandText = "GetProducts",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                connection.Open();
                SqlDataReader reader=command.ExecuteReader();
                
                List<Product> products = null;
                if(reader.HasRows)
                {
                    products = new List<Product>();
                    while (reader.Read())
                    {
                        connection.Close();
                        products.Add(new Product()
                        {
                            Pid = (int)reader["Pid"],
                            Pname = reader["Pname"].ToString(),
                            Price=(int)reader["Price"],
                            Stock=(int)reader["Stock"]
                        }) ;
                        
                    }
                }
                return products;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {

                command = new SqlCommand()
                {
                    CommandText = "UpdateProduct",
                    CommandType = System.Data.CommandType.StoredProcedure,
                    Connection = connection
                };
                //passing values to parameters
                command.Parameters.AddWithValue("@Pid", product.Pid);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
