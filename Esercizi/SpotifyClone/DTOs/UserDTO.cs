using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class UserDTO : PersonDTO
    {
        List<PlayListDTO> _playList = new List<PlayListDTO>();
        string _userName;
        string _password;
        List<MediaDTO> _favSongs;
        bool _isArtist;
        List<Radio> _favRadio;

        SettingDTO setting=new SettingDTO();
        bool _isFree = true;
        bool isPremium = false;
        bool _isGold;

        bool _isLogged = false;
        string language;
        DateTime _localDateTime;
        DateTime _startTimeSong=DateTime.Now;
        DateTime _endTimeSong=DateTime.Now;
        
      
        TimeSpan _sessionDuration;


        public UserDTO(string Name, string Surname, string Birthday, string username, string password, bool isArtist) : base(Name, Surname, Birthday)
        {


            

            _userName = username;
            _password = password;
            _favSongs = new List<MediaDTO>();
            _isArtist = isArtist;
            _favRadio = new List<Radio>();


        }
        public UserDTO(string Name, string Surname, string Birthday) : base(Name, Surname, Birthday) { }
        public List<PlayListDTO> PlayLists { get { return _playList; } set { _playList = value; } }
        public List<MediaDTO> FavSongs { get { return _favSongs; } set { _favSongs = value; } }

        public List<Radio> FavRadio { get { return _favRadio; } set { _favRadio = value; } }

        public bool IsArtist { get => _isArtist; set => _isArtist = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        internal List<PlayListDTO> PlayList { get => _playList; set => _playList = value; }
        public SettingDTO Setting { get => setting; set => setting = value; }
        public bool IsPremium { get => isPremium; set => isPremium = value; }
        public bool IsLogged { get => _isLogged; set => _isLogged = value; }
        public string Language { get => language; set => language = value; }
        public DateTime LocalDateTime { get => _localDateTime; set => _localDateTime = value; }
        public DateTime StartTimeSong { get => _startTimeSong; set => _startTimeSong = value; }
        public DateTime EndTimeSong { get => _endTimeSong; set => _endTimeSong = value; }
        public TimeSpan SessionDuration { get => _sessionDuration; set => _sessionDuration = value; }
        public bool IsFree { get => _isFree; set => _isFree = value; }
        public bool IsGold { get => _isGold; set => _isGold = value; }

        public void AddPlaylist(PlayListDTO playlist)
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
        public void AddSongToPlaylist(MediaDTO song, PlayListDTO playlist1)
        {
            if (PlayList != null) { playlist1.AddSong(song); } else { Console.WriteLine("Error!"); }

        }
        public void ShowAllThePlaylists()
        {
            if (_playList != null)
            {
                int i = 0;
                foreach (PlayListDTO play in _playList)
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
        public void ShowMeOnePlaylist(PlayListDTO playlist)
        {
            int i = 0;
            List<MediaDTO> songs = playlist.Songs;
            foreach (MediaDTO s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
    }
}