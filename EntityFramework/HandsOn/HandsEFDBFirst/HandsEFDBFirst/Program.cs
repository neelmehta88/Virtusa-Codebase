using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandsEFDBFirst
{
    internal class Program
    {
        public static void GetProducts()
        {
            using(PracticeDBEntities db=new PracticeDBEntities())
            {
                List<Product> products = db.Products.ToList(); //return all the products
                foreach(var item in products)
                {
                    Console.WriteLine($"Id:{item.Pid} Name:{item.Pname} Price:{item.Price} Stock:{item.Stock}");
                }
            }
        }
        public static void GetProduct(int id)
        {
            using(PracticeDBEntities db=new PracticeDBEntities())
            {
                Product product = db.Products.SingleOrDefault(p => p.Pid == id);
                if (product != null)
                    Console.WriteLine($"Id:{product.Pid} Name:{product.Pname} Price:{product.Price} Stock:{product.Stock}");
                else
                    Console.WriteLine("Invalid Id");
            }
        }
        public static void AddProduct(Product product)
        {
            using (PracticeDBEntities db = new PracticeDBEntities())
            {
                db.Products.Add(product); //add product details to the table
                db.SaveChanges();
            }
        }
        public static void DeleteProduct(int id)
        {
            using (PracticeDBEntities db = new PracticeDBEntities())
            {
                Product product = db.Products.SingleOrDefault(p => p.Pid == id);
                db.Products.Remove(product); //remove product details from the table
                db.SaveChanges();
            }
        }
        public static void EditProduct(Product new_product)
        {
            using (PracticeDBEntities db = new PracticeDBEntities())
            {
                //update existing product
                Product product = db.Products.SingleOrDefault(p => p.Pid == new_product.Pid);
                product.Price = new_product.Price;
                product.Stock = new_product.Stock;
                db.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            //AddProduct(new Product()
            //{
            //    Pid = 4545,
            //    Pname = "bottle",
            //    Price = 450,
            //    Stock=10
            //}); 
            GetProducts();
            //Console.WriteLine("Enter ProductId");
            //int id = int.Parse(Console.ReadLine());
            //GetProduct(id);
            DeleteProduct(3918);
            EditProduct(new Product()
            {
                Pid = 4545,
                Pname = "bottle",
                Price = 400,
                Stock = 50
            });
            GetProducts();
            Console.ReadKey();
        }
    }
}
