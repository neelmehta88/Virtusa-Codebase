using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
    class Demo3
    {
        SqlConnection con = new SqlConnection(@"DESKTOP-4O1D65I\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True");
     
        SqlDataAdapter da = null;
       
        public void GetEmployees()
        {
            string qry = "Select Eid,Ename,Salary,JoinDate from Employee";
            da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable("Employee");
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID:{0} Name:{1} Salary:{2} JoinDate:{3}", row["Eid"], row["Ename"],
                    row["Salary"], row["JoinDate"]);
            }
        }
        public static void Main()
        {
            Demo3 obj = new Demo3();
            obj.GetEmployees();
        }
    }
}
