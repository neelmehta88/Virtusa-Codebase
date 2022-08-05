using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace HandsOnAdoDisconnectedArchitecture
{
    //Disconnected Architecture
    class Demo1
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["SqlConnection"]);
        SqlConnection con = new SqlConnection(@"DESKTOP-4O1D65I\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True");
        SqlConnection con1=new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Pubs;Integrated Security=True");
        SqlDataAdapter da = null;
        DataSet ds = null;
        public void GetEmployees()
        {
            string qry = "Select Eid,Ename,Salary,JoinDate from Employee";
            da = new SqlDataAdapter(qry, con);
            //store the result set data into dataset
            ds = new DataSet();
            //fill the dataset
            da.Fill(ds, "Employee");
            da = new SqlDataAdapter("Select * from Sales", con1);
            da.Fill(ds, "Sales");
            Console.WriteLine("Sales Records");
            foreach(DataRow row in ds.Tables["Employee"].Rows)
            {
                Console.WriteLine("ID:{0} Name:{1} Salary:{2} JoinDate:{3}", row["Eid"], row["Ename"], 
                    row["Salary"], row["JoinDate"]);
            }
            Console.WriteLine("Product Records");
            foreach (DataRow row in ds.Tables["Sales"].Rows)
            {
                Console.WriteLine("ID:{0} Number:{1} Date:{2} Qty:{3}", row["Stor_id"], row["Ord_num"], 
                    row["Ord_Date"], row["qty"]);
            }
          

        }
        static void Main()
        {
            Demo1 obj = new Demo1();
            obj.GetEmployees();
        }
    }
}
