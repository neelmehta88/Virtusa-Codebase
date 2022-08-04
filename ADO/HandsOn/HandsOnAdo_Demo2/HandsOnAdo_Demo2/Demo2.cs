using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace HandsOnAdo_Demo2
{
    class Demo2
    {
        SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True");
        SqlCommand cmd = null;
        public  decimal GetMaxSalary()
        {
            try
            {
                string qry = "Select Max(Salary) from Employee";
                cmd = new SqlCommand(qry, con);
                con.Open();
               decimal max_salary= (decimal)cmd.ExecuteScalar();
                return max_salary;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        //Invoking Stored Procedure ussing Command class
        public void AddProduct(string pname,int price,int stock)
        {
            cmd = new SqlCommand("AddProduct", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //passing value to stored procedure paramters
            cmd.Parameters.AddWithValue("@Pname", pname);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@Stock", stock);
            con.Open();
            cmd.ExecuteNonQuery(); //execute stored procedure
            con.Close();
        }
        public void GetDeptWiseEmployees(string Did)
        {
            cmd = new SqlCommand("GetDeptWiseEmployee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //passing values to stored procedure paramter
            cmd.Parameters.AddWithValue("@deptid", Did);
            con.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    Console.WriteLine("ID:{0} Name:{1} ", dr["Eid"], dr["Ename"]);
                }
                dr.Close();
                con.Close();
            }
            
            else
            {
                Console.WriteLine("Invalid Did");
            }
        }
        static void Main()
        {
            Demo2 obj = new Demo2();
            //decimal result = obj.GetMaxSalary();
            //Console.WriteLine(result);
            //obj.AddProduct("AAA", 20, 100);
            obj.GetDeptWiseEmployees("D001");
        }
    }
}
