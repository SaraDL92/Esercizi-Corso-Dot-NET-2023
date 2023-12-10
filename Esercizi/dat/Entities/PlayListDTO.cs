using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
       public class PlayListDTO
    {
        private static int _nextid = 5;
        int _id;
        UserDTO _user;
        List<MediaDTO> _songs=new List<MediaDTO> ();
        string _name;
        int _rating;
        public PlayListDTO(UserDTO user, string name)
        {
            _id = _nextid++;
            _user = user;
            _songs = new List<MediaDTO>();
            _name = name;
        }
        public PlayListDTO(string name,MediaDTO song)
        {   _id= _nextid++;
            _name = name;
            _songs.Add(song); }
       

        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }
        public UserDTO User { get => _user; set => _user = value; }
        public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        public int Rating { get => _rating; set => _rating = value; }

        public void AddSong(MediaDTO song)
        {
            _songs.Add(song);

        }

    }
}
