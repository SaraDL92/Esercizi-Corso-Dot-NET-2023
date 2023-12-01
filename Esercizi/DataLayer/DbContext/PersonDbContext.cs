using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class PersonDbContext
    {
        List<Person> _persons;

        internal List<Person> Persons { get => _persons; set => _persons = value; }
    }
}
