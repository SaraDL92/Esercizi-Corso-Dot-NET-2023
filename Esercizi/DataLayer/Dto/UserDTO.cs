using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class UserDTO:PersonDTO
    {
        int _id;
        List<PlaylistDTO> _playList = new List<PlaylistDTO>();
        string _userName;
        string _password;
        List<MediaDTO> _favSongs;
        bool _isArtist;
        List<RadioDTO> _favRadio;

        SettingDTO setting = new SettingDTO();
        bool _isFree = true;
        bool isPremium = false;
        bool _isGold;

        bool _isLogged = false;
        string language;
        DateTime _localDateTime;
        DateTime _startTimeSong = DateTime.Now;
        DateTime _endTimeSong = DateTime.Now;


        TimeSpan _sessionDuration;

        public int Id { get => _id; set => _id = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public bool IsArtist { get => _isArtist; set => _isArtist = value; }
        public bool IsFree { get => _isFree; set => _isFree = value; }
        public bool IsPremium { get => isPremium; set => isPremium = value; }
        public bool IsGold { get => _isGold; set => _isGold = value; }
        public bool IsLogged { get => _isLogged; set => _isLogged = value; }
        public string Language { get => language; set => language = value; }
        public DateTime LocalDateTime { get => _localDateTime; set => _localDateTime = value; }
        public DateTime StartTimeSong { get => _startTimeSong; set => _startTimeSong = value; }
        public DateTime EndTimeSong { get => _endTimeSong; set => _endTimeSong = value; }
        public TimeSpan SessionDuration { get => _sessionDuration; set => _sessionDuration = value; }
        internal List<PlaylistDTO> PlayList { get => _playList; set => _playList = value; }
        internal List<MediaDTO> FavSongs { get => _favSongs; set => _favSongs = value; }
        internal List<RadioDTO> FavRadio { get => _favRadio; set => _favRadio = value; }
        internal SettingDTO Setting { get => setting; set => setting = value; }
    }
}
