using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Director
    {
        int _id;
        string _name;
        List<Media> _media = new List<Media>();

        internal string Name { get => _name; set => _name = value; }
        internal int Id { get => _id; set => _id = value; }
        internal List<Media> Media { get => _media; set => _media = value; }
    }
}
