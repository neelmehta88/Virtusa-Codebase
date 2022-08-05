using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandsOnAdoUsingStoredProcedures.Entities;
using HandsOnAdoUsingStoredProcedures.Repositories;
namespace HandsOnAdoUsingStoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProductRepository repository = new ProductRepository();
                //Product product = new Product()
                //{
                //    Pid = 130,
                //    Pname = "AAA",
                //    Price = 10,
                //    Stock = 20
                //};
                //repository.AddProduct(product);
                List<Product> products = repository.GetProducts();
                foreach (var item in products)
                {
                    Console.WriteLine("ID:{0} Name:{1} Price:{2} Stock:{3}", item.Pid, item.Pname, item.Price, item.Stock);
                }
                //Console.WriteLine("Enter Product Id");
                //int Pid = int.Parse(Console.ReadLine());
                //Product product = repository.GetProduct(Pid);
                //if (product != null)
                //{
                //    Console.WriteLine("Name:{0} Price {1}", product.Pname, product.Price);
                //}
                //else
                //    Console.WriteLine("Invalid id");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
