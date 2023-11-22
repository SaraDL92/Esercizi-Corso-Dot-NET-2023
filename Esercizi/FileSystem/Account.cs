using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class Account
    {
        public int AccountId { get; set; }
        public decimal Saldo { get; set; } 
        
        public override string ToString()
    {
            return $"id {AccountId},{Saldo}€";
    }
    }
   
}
