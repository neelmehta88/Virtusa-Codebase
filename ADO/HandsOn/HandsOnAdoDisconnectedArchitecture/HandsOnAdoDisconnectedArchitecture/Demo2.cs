using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
    class Demo2
    {
        static void Main()
        {
            //create table
            DataTable dt = new DataTable("Student");
            //add table schema
            dt.Columns.Add("Sid", typeof(System.Int32));
            dt.Columns.Add("Sname", typeof(System.String));
            //Create Row with Student Table schema
            DataRow dr = dt.NewRow();
            dr["Sid"] = 1;
            dr["Sname"] = "Rohan";
            //add row to datatable
            dt.Rows.Add(dr);
            foreach(dynamic row in dt.Rows)
            {
                Console.WriteLine("{0} {1}", row["Sid"], row["Sname"]);
            }
            //adding data table to dataset
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            foreach (dynamic row in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0} {1}", row["Sid"], row["Sname"]);
            }

        }
    }
}
