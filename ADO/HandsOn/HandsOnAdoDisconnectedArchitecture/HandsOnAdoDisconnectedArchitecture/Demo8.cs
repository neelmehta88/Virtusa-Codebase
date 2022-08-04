using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
    class Demo8
    {
        static void Main()
        {
            SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True");
            SqlDataAdapter da = null;
            da = new SqlDataAdapter("Select * from Product", con);
            DataSet ds = new DataSet("Products");
            da.Fill(ds, "Product");
            var resultset = ds.Tables["Product"].AsEnumerable();
            //get products whose price >300
            var result1 = from e in resultset
                          where e.Field<int>("Price") > 300
                          select e;
            foreach(var row in result1)
            {
                Console.WriteLine($"{row["Pid"]} {row["Pname"]} {row["Price"]} {row["Stock"]}");
            }
            Console.ReadKey();
        }
    }
}
