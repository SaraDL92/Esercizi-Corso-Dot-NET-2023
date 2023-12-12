using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void SaveOrder(Order order)
        {
            Console.WriteLine($"The order {order} is saved");
        }
    }
}
