using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Group
    {
        int _id;
        string _name;
        List<Artist> _members;
        List<Media> _songs;
        List<Album> _albums;
        string _bio;

        internal string Name { get => _name; set => _name = value; }
        internal string Bio { get => _bio; set => _bio = value; }
        internal int Id { get => _id; set => _id = value; }
        internal List<Artist> Members { get => _members; set => _members = value; }
        internal List<Media> Songs { get => _songs; set => _songs = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
    }
}
