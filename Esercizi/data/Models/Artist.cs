using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Models
{
    internal class Artist
    {
        string _name;

       List <song> songlist=new List<song>();
        public Artist(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public List<song> Songlist { get => songlist; set => songlist = value; }
    }
}
