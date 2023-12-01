using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Person
    {
        private string name;
        private string surname;
        private string birthday;

       internal string Name { get => name; set => name = value; }
        internal string Surname { get => surname; set => surname = value; }
        internal string Birthday { get => birthday; set => birthday = value; }
    }
}
