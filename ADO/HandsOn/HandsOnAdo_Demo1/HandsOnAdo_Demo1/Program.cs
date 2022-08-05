using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HandsOnAdo_Demo1
{
    class Program
    {
        public static void GetProductById(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4O1D65I\SQLEXPRESS;Database=TrainingDB;Integrated Security=True");
            try
            {
                //con.ConnectionString = @"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True";
                con.Open(); //open connection

                SqlCommand cmd = new SqlCommand("Select Pid,Pname from product where pid=" + id, con);
                SqlDataReader dr = cmd.ExecuteReader(); //ExecureReader() method stores result set data into DataReader object

                dr.Read();


                Console.WriteLine("Id:{0} Name:{1}", dr["Pid"], dr["Pname"]);


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();//close connection i.e disconnected from database
            }
        }
        public static void GetAll()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4O1D65I\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True");
            try
            {
                //con.ConnectionString = @"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True";
                con.Open(); //open connection
                SqlCommand cmd = new SqlCommand("Select * from Product", con);
              
                SqlDataReader dr = cmd.ExecuteReader(); //ExecureReader() method stores result set data into DataReader object

                while (dr.Read())
                {

                    Console.WriteLine("Id:{0} Name:{1} Price {2} Stock {3}", dr["Pid"], dr["Pname"], dr["Price"], dr[3]);

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();//close connection i.e disconnected from database
            }
        }
        static void Main(string[] args)
        {
            //GetProductById(1);
            GetAll();
        }
    }
}
