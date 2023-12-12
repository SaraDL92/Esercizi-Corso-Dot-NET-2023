using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerMail {  get; set; }
        public string CustomerName {  get; set; }

        public override string ToString()
        {
            return $"ID:{Id} CUSTOMER: {CustomerName} MAIL:{CustomerMail} ";
        }
    }
}
