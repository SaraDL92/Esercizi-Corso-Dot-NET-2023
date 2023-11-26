using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
       public class PlayList
    {
        private static int _nextid = 5;
        int _id;
        User _user;
        List<Song> _songs=new List<Song> ();
        string _name;

        public PlayList(User user, string name)
        {
            _id = _nextid++;
            _user = user;
            _songs = new List<Song>();
            _name = name;
        }
        public PlayList(string name,Song song)
        {   _id= _nextid++;
            _name = name;
            _songs.Add(song); }

        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        public void AddSong(Song song)
        {
            _songs.Add(song);

        }

    }
}
