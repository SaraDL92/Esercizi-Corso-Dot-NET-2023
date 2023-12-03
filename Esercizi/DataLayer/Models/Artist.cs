using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Artist:Person
    {
        int _id;
        string _artistName;
        List<Album> _albums;
        List<Song> _songs = new List<Song>();
        string _bio;
        List<Group> _groups;
        int _rating;

       internal string ArtistName { get => _artistName; set => _artistName = value; }
       internal string Bio { get => _bio; set => _bio = value; }
       internal int Rating { get => _rating; set => _rating = value; }
        internal int Id { get => _id; set => _id = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<Group> Groups { get => _groups; set => _groups = value; }
    }
}
