using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Radio
    {
        int _id;
        string _name;
        List<Media> _songlist = new List<Media>();

        int _rating;

        internal string Name { get => _name; set => _name = value; }
        internal int Rating { get => _rating; set => _rating = value; }
       internal int Id { get => _id; set => _id = value; }
        internal List<Media> Songlist { get => _songlist; set => _songlist = value; }
    }
}
