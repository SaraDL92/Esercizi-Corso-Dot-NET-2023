using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
       public class PlayList
    {
        User _user;
        List<Song> _songs;
        string _name;

        public PlayList(User user, string name)
        {
            _user = user;
            _songs = new List<Song>();
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        public void AddSong(Song song)
        {
            _songs.Add(song);

        }

    }
}
