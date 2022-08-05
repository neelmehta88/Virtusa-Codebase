using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HandsOnAdo_Demo2
{
    class ProductDAO
    {
        public void GetProducts() //get all products
        {
            try
            {
                using(SqlConnection con=new SqlConnection(@"Data Source=DESKTOP-4O1D65I\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand("Select * from Product", con);
                    con.Open();
                    SqlDataReader dr=cmd.ExecuteReader();
                    if(dr.HasRows)
                    {
                        while(dr.Read())
                        {
                            Console.WriteLine("Id:{0} Name:{1} Price:{2},Stock:{3}", dr["Pid"], dr["Pname"], dr["Price"], dr["Stock"]);
                        }
                    }
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void GetProductById(int Pid) //get product by Id
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = SANTU\MSSQLSERVER2019; Initial Catalog = Training1DB; Integrated Security = True"))
                {
                    SqlCommand cmd = new SqlCommand("Select Pname,Price,Stock from Product where Pid="+Pid, con);
                    con.Open();
                    SqlDataReader dr=cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dr.Read();
                        Console.WriteLine("Name:{0} Price:{1},Stock:{2}", dr["Pname"], dr["Price"], dr["Stock"]);

                    }
                    else
                        Console.WriteLine("Invalid Product Id");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddProduct(int pid,string pname,int price,int stock) //add product
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = SANTU\MSSQLSERVER2019; Initial Catalog = Training1DB; Integrated Security = True"))
                {
                    //SqlCommand cmd = new SqlCommand("insert into Product values(@Pid,@Pname,@Price,@Stock)", con);
                    ////passing values to sql parameter
                    //cmd.Parameters.AddWithValue("@Pid", pid);
                    //cmd.Parameters.AddWithValue("@Pname", pname);
                    //cmd.Parameters.AddWithValue("@Price", price);
                    //// cmd.Parameters.AddWithValue("@Stock", stock);
                    //SqlParameter p = new SqlParameter("@Stock", stock);
                    ////add paramter to cmd 
                    //cmd.Parameters.Add(p);
                    SqlCommand cmd = new SqlCommand($"insert into product values({pid},'{pname}',{price},{stock})");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteProduct(int Pid) //delete product
        {
            try
            {
                using(SqlConnection con=new SqlConnection(@"Data Source = SANTU\MSSQLSERVER2019; Initial Catalog = Training1DB; Integrated Security = True"))
                {
                    SqlCommand cmd = new SqlCommand("Delete from Product where Pid="+Pid, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateProduct(int pid,int price,int stock) //update product 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source = SANTU\MSSQLSERVER2019; Initial Catalog = Training1DB; Integrated Security = True"))
                {
                    //SqlCommand cmd = new SqlCommand("Update Product set Price=@Price,Stock=@Stock Where Pid=@Pid", con);
                    //cmd.Parameters.AddWithValue("@Pid", pid);
                    //cmd.Parameters.AddWithValue("@Price", price);
                    //cmd.Parameters.AddWithValue("@stock", stock);
                    SqlCommand cmd = new SqlCommand($"Update Product set Price={price},Stock={stock} Where Pid={pid}", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
