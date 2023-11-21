using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class User:Person
    {
        List <PlayList> _playList;
        string _userName;
        string _password;
        List<Song> _favSongs;
       
        List<Radio> _favRadio;
        Setting setting;
        

        public User(string Name, string Surname, string Birthday,List<PlayList> playlist, string username, string password, List<Song> favsong, List<Radio> favradio):base(Name,Surname,Birthday)
        {

            _playList = playlist;
            _userName = username;
            _password = password;
            _favSongs = favsong;
           
            _favRadio = favradio;
           

        }

        public List <PlayList> PlayLists { get { return _playList; } set { _playList = value; } }
        public List<Song> FavSongs { get { return _favSongs; } set { _favSongs = value; } }

        public List<Radio> FavRadio { get { return _favRadio; } set { _favRadio = value; } }





    }
}
