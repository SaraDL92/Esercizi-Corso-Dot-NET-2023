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
        List <PlayList> _playList=new List<PlayList>();
        string _userName;
        string _password;
        List<Song> _favSongs;
        bool _isArtist;
        List<Radio> _favRadio;
        Setting setting;
        
        

        public User(string Name, string Surname, string Birthday,string username, string password,bool isArtist):base(Name,Surname,Birthday)
        {

        
             
            
            _userName = username;
            _password = password;
            _favSongs = new List<Song> ();
            _isArtist = isArtist;
            _favRadio = new List<Radio> ();
           

        }
        public User(string Name, string Surname, string Birthday):base(Name,Surname,Birthday) { }

        public void AddPlaylist(PlayList playlist)
        {
           

            if (_playList != null)
            {
                _playList.Add(playlist);
                
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        public void ShowAllThePlaylists()
        {
            if (_playList != null)
            {
                foreach (PlayList play in _playList)
                {
                    Console.WriteLine(play.Name);
                }
            }
            else
            {
                Console.WriteLine("No playlists for this User!");
            }
        }

        public List <PlayList> PlayLists { get { return _playList; } set { _playList = value; } }
        public List<Song> FavSongs { get { return _favSongs; } set { _favSongs = value; } }

        public List<Radio> FavRadio { get { return _favRadio; } set { _favRadio = value; } }

        public bool IsArtist { get => _isArtist; set => _isArtist = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
