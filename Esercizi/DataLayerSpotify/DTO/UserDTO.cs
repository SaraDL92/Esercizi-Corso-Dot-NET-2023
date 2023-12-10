using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Entities;

namespace DataLayerSpotify.DTO
{
    public class UserDTO
    {
        List<PlaylistDTO> _playList = new List<PlaylistDTO>();
        string _userName;
        string _password;
        List<MediaDTO> _favSongs=new List<MediaDTO>();
        bool _isArtist;
        List<RadioDTO> _favRadio=new List<RadioDTO>();

        SettingDTO setting;
        bool _isFree = true;
        bool isPremium = false;
        bool _isGold;

        bool _isLogged = false;
        string language;
        DateTime _localDateTime;
        DateTime _startTimeSong = DateTime.Now;
        DateTime _endTimeSong = DateTime.Now;


        TimeSpan _sessionDuration;

        public UserDTO(User u)
        {
            foreach(PlayList p in u.PlayLists)
            {
                PlayList.Add(new PlaylistDTO(p));
            }

            UserName=u.UserName;
            Password=u.Password;
            foreach(Media m in u.FavSongs)
            {
                FavSongs.Add(new MediaDTO(m));
            }
            IsArtist=u.IsArtist;
            foreach(Radio r in u.FavRadio)
            {
                FavRadio.Add(new RadioDTO(r));
            }
            Setting = new SettingDTO( u.Setting);
            IsFree=u.IsFree;
            isPremium = u.IsPremium;
            IsGold = u.IsGold;
            IsLogged = u.IsLogged;
            language = u.Language;
            _localDateTime = u.LocalDateTime;
            _startTimeSong = u.StartTimeSong;
            _endTimeSong = u.EndTimeSong;
            _sessionDuration = u.SessionDuration;


        }

        

        public List<PlaylistDTO> PlayList { get => _playList; set => _playList = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public List<MediaDTO> FavSongs { get => _favSongs; set => _favSongs = value; }
        public bool IsArtist { get => _isArtist; set => _isArtist = value; }
        public List<RadioDTO> FavRadio { get => _favRadio; set => _favRadio = value; }
        public bool IsFree { get => _isFree; set => _isFree = value; }
        public bool IsPremium { get => isPremium; set => isPremium = value; }
        public bool IsGold { get => _isGold; set => _isGold = value; }
        public bool IsLogged { get => _isLogged; set => _isLogged = value; }
        public string Language { get => language; set => language = value; }
        public DateTime LocalDateTime { get => _localDateTime; set => _localDateTime = value; }
        public DateTime StartTimeSong { get => _startTimeSong; set => _startTimeSong = value; }
        public DateTime EndTimeSong { get => _endTimeSong; set => _endTimeSong = value; }
        public TimeSpan SessionDuration { get => _sessionDuration; set => _sessionDuration = value; }
        internal SettingDTO Setting { get => setting; set => setting = value; }
    }
}
