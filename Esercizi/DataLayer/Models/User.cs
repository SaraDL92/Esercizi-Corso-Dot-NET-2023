using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class User:Person
    {
        int _id;
        List<PlayList> _playList = new List<PlayList>();
        string _userName;
        string _password;
        List<Media> _favSongs;
        bool _isArtist;
        List<Radio> _favRadio;

        Setting setting = new Setting();
        bool _isFree = true;
        bool isPremium = false;
        bool _isGold;

        bool _isLogged = false;
        string language;
        DateTime _localDateTime;
        DateTime _startTimeSong = DateTime.Now;
        DateTime _endTimeSong = DateTime.Now;


        TimeSpan _sessionDuration;

        internal string UserName { get => _userName; set => _userName = value; }
        internal string Password { get => _password; set => _password = value; }
        internal bool IsArtist { get => _isArtist; set => _isArtist = value; }
        internal bool IsFree { get => _isFree; set => _isFree = value; }
        internal bool IsPremium { get => isPremium; set => isPremium = value; }
        internal bool IsGold { get => _isGold; set => _isGold = value; }
       internal bool IsLogged { get => _isLogged; set => _isLogged = value; }
       internal string Language { get => language; set => language = value; }
        internal DateTime LocalDateTime { get => _localDateTime; set => _localDateTime = value; }
        internal DateTime StartTimeSong { get => _startTimeSong; set => _startTimeSong = value; }
       internal DateTime EndTimeSong { get => _endTimeSong; set => _endTimeSong = value; }
        internal TimeSpan SessionDuration { get => _sessionDuration; set => _sessionDuration = value; }
        internal List<PlayList> PlayList { get => _playList; set => _playList = value; }
        internal List<Media> FavSongs { get => _favSongs; set => _favSongs = value; }
        internal List<Radio> FavRadio { get => _favRadio; set => _favRadio = value; }
        internal Setting Setting { get => setting; set => setting = value; }
    }
}
