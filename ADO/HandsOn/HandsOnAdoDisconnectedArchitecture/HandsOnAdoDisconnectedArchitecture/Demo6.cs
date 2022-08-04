using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace HandsOnAdoDisconnectedArchitecture
{
   
    class Demo6
    {
        public static void WriteXml()
        {
            SqlConnection con = new SqlConnection(@"Data Source=SANTU\MSSQLSERVER2019;Initial Catalog=Training1DB;Integrated Security=True");
            SqlDataAdapter da = null;
            da = new SqlDataAdapter("Selec * from Product", con);
            DataSet ds = new DataSet("Products");
            da.Fill(ds, "Product");
            ds.WriteXml("Product.xml");
        }
        public static void ReadXml(string filePath)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("Product.xml");
            foreach(DataRow r in ds.Tables[0].Rows)
            {
                Console.WriteLine("Id:{0} Name:{1} Price:{2} Stock{3}", r["Pid"], r["Pname"], r["Price"], r["Stock"]);
            }
        }
        static void Main()
        {
            WriteXml();
            ReadXml("Product.xml");
        }
    }
}
