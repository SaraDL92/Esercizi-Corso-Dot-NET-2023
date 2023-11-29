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
        List<Media> _songs=new List<Media> ();
        string _name;

        public PlayList(User user, string name)
        {
            _id = _nextid++;
            _user = user;
            _songs = new List<Media>();
            _name = name;
        }
        public PlayList(string name,Media song)
        {   _id= _nextid++;
            _name = name;
            _songs.Add(song); }

        public string Name { get => _name; set => _name = value; }
        public int Id { get => _id; set => _id = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Media> Songs { get => _songs; set => _songs = value; }
        public void AddSong(Media song)
        {
            _songs.Add(song);

        }

    }
}
