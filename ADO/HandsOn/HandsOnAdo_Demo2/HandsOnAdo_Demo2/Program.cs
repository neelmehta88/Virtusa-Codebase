using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsOnAdo_Demo2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductDAO product = new ProductDAO();
           //product.AddProduct(3, "Pendrive", 400, 10);
            //product.AddProduct(4, "Speaker", 1200, 20);
            product.GetProducts();
           Console.WriteLine("Enter Product Id");
           int id = int.Parse(Console.ReadLine());
            //product.GetProductById(id);
            //product.DeleteProduct(id);
            product.UpdateProduct(id, 500, 20);
        }
    }
}
