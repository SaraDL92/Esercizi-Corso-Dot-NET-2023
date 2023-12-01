using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class PlayList
    {
        private static int _nextid = 5;
        int _id;
        User _user;
        List<Media> _songs = new List<Media>();
        string _name;
        int _rating;

       internal static int Nextid { get => _nextid; set => _nextid = value; }
       internal int Id { get => _id; set => _id = value; }
        internal string Name { get => _name; set => _name = value; }
       internal int Rating { get => _rating; set => _rating = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Media> Songs { get => _songs; set => _songs = value; }
    }
}
