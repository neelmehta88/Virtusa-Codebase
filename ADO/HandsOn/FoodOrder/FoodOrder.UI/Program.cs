using System;
using FoodOrder.Services;
using System.Data;
namespace FoodOrder.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1.New Order");
            Console.WriteLine("2.Show Order Details");
            Console.WriteLine("3.Show All the Order Details");
            Console.WriteLine("Enter Option");
            int ch = int.Parse(Console.ReadLine());
            OrderSevice orderSevice = new OrderSevice();
            switch(ch)
            {
                case 1:
                    {
                        try
                        {
                           if( orderSevice.CreateOrder(
                               new Model.Order() {Order_Id=4,Order_Name="Chips",Order_Date=DateTime.Now }))
                            {
                                Console.WriteLine("Order Created");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter OrderId");
                    int Oid = int.Parse(Console.ReadLine());
                    DataRow row = orderSevice.GetOrderById(Oid);
                    if (row != null)
                        Console.WriteLine($"OrderName:{row["Order_Name"]} OrderDate:{row["Order_Date"]}");
                    else
                        Console.WriteLine("Invalid Oder_Id");
                    break;
                case 3:
                    DataTable dt = orderSevice.GetOrders();
                    foreach(DataRow r in dt.Rows)
                    {
                        Console.WriteLine($"OrderName:{r["Order_Name"]} OrderDate:{r["Order_Date"]}");
                    }
                    break;
            }
           
            Console.ReadKey();
        }
    }
}
