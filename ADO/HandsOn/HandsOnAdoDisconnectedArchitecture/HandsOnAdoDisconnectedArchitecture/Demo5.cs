using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
    class ProductCRUD
    {
        SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True");
        SqlDataAdapter da = null;
        DataTable dt = null;
        SqlCommandBuilder cb = null;
        public ProductCRUD()
        {
            da = new SqlDataAdapter("Select * from Product", con);
            cb = new SqlCommandBuilder(da);
            dt = new DataTable("Product");
            da.Fill(dt);
            //set Primary key
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Pid"] };
        }
        public void AddProduct(int Pid,string Pname,int Price,int Stock)
        {
            DataRow dr = dt.NewRow();
            dr["Pid"] = Pid;
            dr["Pname"] = Pname;
            dr["Price"] = Price;
            dr["Stock"] = Stock;
            dt.Rows.Add(dr); //adding new row to the DataTable.
            da.Update(dt);
        }
        public void DeleteProduct(int Pid)
        {
            dt.Rows.Find(Pid).Delete();
            da.Update(dt);
        }
        public void UpdateProduct(int Pid,int Price,int Stock)
        {
            dt.Rows.Find(Pid)["Price"] = Price;
            dt.Rows.Find(Pid)["Stock"] = Stock;
            da.Update(dt);
        }
        static void Main()
        {
            ProductCRUD obj = new ProductCRUD();
            //obj.AddProduct(6, "BBB", 10, 10);
            obj.DeleteProduct(6);
        }
    }
}
