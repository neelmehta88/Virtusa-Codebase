using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FoodOrder.Model;
namespace FoodOrder.DAL
{ 
    public class OrderDAO
    {
        SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=FoodOrder;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataSet ds = null;
        DataTable dt = null;
        string Qry = null;
        public bool CreateOrder(Order order)
        {
            try
            {
                Qry = "Insert into Orders values(@OrderId,@OrderName,@OrderDate)";
                cmd = new SqlCommand(Qry, con);
                cmd.Parameters.AddWithValue("@OrderId", order.Order_Id);
                cmd.Parameters.AddWithValue("@OrderName", order.Order_Name);
                cmd.Parameters.AddWithValue("@OrderDate", order.Order_Date);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable GetOrders()
        {
           try
            {
                Qry = "Select * from Orders";
                da = new SqlDataAdapter(Qry, con);
                dt = new DataTable("Orders");
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataRow GetOrderById(int Order_Id)
        {
            try
            {
                Qry = "Select * from Orders where Order_Id="+Order_Id;
                da = new SqlDataAdapter(Qry, con);
                dt = new DataTable("Orders");
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
