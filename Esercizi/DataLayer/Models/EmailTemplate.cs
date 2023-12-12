using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class EmailTemplate:IEmailTemplate
    {

        public string TextEmail(Order order) {
            return $"Dear {order.CustomerName}, the order {order.Id} has been confirmed. ";
        }
    }
}
