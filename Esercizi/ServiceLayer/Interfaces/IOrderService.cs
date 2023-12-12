using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace ServiceLayer.Interfaces
{
   public interface IOrderService
    {
        void PlaceOrder(Order order);

    }
}
