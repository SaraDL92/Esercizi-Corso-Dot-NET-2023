using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class PlaylistDTO
    {
        private static int _nextid = 5;
        int _id;
        UserDTO _user;
        List<MediaDTO> _songs = new List<MediaDTO>();
        string _name;
        int _rating;

        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal UserDTO User { get => _user; set => _user = value; }
        internal List<MediaDTO> Songs { get => _songs; set => _songs = value; }
    }
}
