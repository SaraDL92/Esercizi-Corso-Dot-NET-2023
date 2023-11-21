using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class PlayList
    {
        User _user;
        List<Song> _songs;
        string _name;

        public PlayList(User user, List<Song> songs, string name)
        {
            _user = user;
            _songs = songs;
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
        internal User User { get => _user; set => _user = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }

        public void AddSong(Song song)
        {
            _songs.Add(song);

        }

        public void RemoveSong(Song song)
        {

            _songs.Remove(song);
        }

        public void CreatePlayList()
        {
            List<PlayList> playlist = new();
        }





    }




}
