using System;
using System.Collections.Generic;
using System.Text;
using FoodOrder.DAL;
using FoodOrder.Model;
using System.Data;
namespace FoodOrder.Services
{
    public class OrderSevice
    {
        OrderDAO order = new OrderDAO();
        public bool CreateOrder(Order item)
        {
            return order.CreateOrder(item);
        }
        public DataTable GetOrders()
        {
            return order.GetOrders();
        }
        public DataRow GetOrderById(int Order_Id)
        {
            return order.GetOrderById(Order_Id);
        }
    }
}
