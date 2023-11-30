using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class User : Person
    {
        List<PlayList> _playList = new List<PlayList>();
        string _userName;
        string _password;
        List<Media> _favSongs;
        bool _isArtist;
        List<Radio> _favRadio;

        Setting setting=new Setting();
        bool _isFree = true;
        bool isPremium = false;
        bool _isGold;

        bool _isLogged = false;
        string language;
        DateTime _localDateTime;
        DateTime _startTimeSong=DateTime.Now;
        DateTime _endTimeSong=DateTime.Now;
        
      
        TimeSpan _sessionDuration;


        public User(string Name, string Surname, string Birthday, string username, string password, bool isArtist) : base(Name, Surname, Birthday)
        {


            

            _userName = username;
            _password = password;
            _favSongs = new List<Media>();
            _isArtist = isArtist;
            _favRadio = new List<Radio>();


        }
        public User(string Name, string Surname, string Birthday) : base(Name, Surname, Birthday) { }
        public List<PlayList> PlayLists { get { return _playList; } set { _playList = value; } }
        public List<Media> FavSongs { get { return _favSongs; } set { _favSongs = value; } }

        public List<Radio> FavRadio { get { return _favRadio; } set { _favRadio = value; } }

        public bool IsArtist { get => _isArtist; set => _isArtist = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        internal List<PlayList> PlayList { get => _playList; set => _playList = value; }
        public Setting Setting { get => setting; set => setting = value; }
        public bool IsPremium { get => isPremium; set => isPremium = value; }
        public bool IsLogged { get => _isLogged; set => _isLogged = value; }
        public string Language { get => language; set => language = value; }
        public DateTime LocalDateTime { get => _localDateTime; set => _localDateTime = value; }
        public DateTime StartTimeSong { get => _startTimeSong; set => _startTimeSong = value; }
        public DateTime EndTimeSong { get => _endTimeSong; set => _endTimeSong = value; }
        public TimeSpan SessionDuration { get => _sessionDuration; set => _sessionDuration = value; }
        public bool IsFree { get => _isFree; set => _isFree = value; }
        public bool IsGold { get => _isGold; set => _isGold = value; }

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
        public void AddSongToPlaylist(Media song, PlayList playlist1)
        {
            if (PlayList != null) { playlist1.AddSong(song); } else { Console.WriteLine("Error!"); }

        }
        public void ShowAllThePlaylists()
        {
            if (_playList != null)
            {
                int i = 0;
                foreach (PlayList play in _playList)
                {
                    i++;
                    Console.WriteLine(i + "-" + play.Name);
                }
            }
            else
            {
                Console.WriteLine("No playlists for this User!");
            }
        }
        public void ShowMeOnePlaylist(PlayList playlist)
        {
            int i = 0;
            List<Media> songs = playlist.Songs;
            foreach (Media s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
    }
}