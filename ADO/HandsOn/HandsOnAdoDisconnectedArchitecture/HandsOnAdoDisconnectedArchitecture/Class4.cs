using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
    class Demo4
    {
        SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True");

        SqlDataAdapter da = null;

        public void GetEmployees()
        {
            string qry = "Select * from Employee";
            da = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable("Employee");
            da.Fill(dt);
            //sorting data using Dataview
            DataView dv = new DataView(dt);
           // dv.Sort = "Salary";
            //dv.RowFilter="Salary=14000";
            dv.RowFilter = "Deptid='D001'";
            foreach(DataRowView dr in dv)
            {
                Console.WriteLine("{0} {1} {2} {3}", dr["Eid"], dr["Ename"], dr["Salary"], dr["JoinDate"]);
            }
        }
        public static void Main()
        {
            Demo4 obj = new Demo4();
            obj.GetEmployees();
        }
    }
}
