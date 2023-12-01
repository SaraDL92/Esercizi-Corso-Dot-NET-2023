using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Dispositive
    {
        int _id;
        string _name;

       internal string Name { get => _name; set => _name = value; }
       internal int Id { get => _id; set => _id = value; }
    }
}
