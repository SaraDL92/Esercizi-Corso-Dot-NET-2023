using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class Media
    {
        private static int personalrating = 0;
        int rating = personalrating;
        private static int _nextid = 1;
        int _id;
        string _genre;
        string _title;
        int _duration;
        string _releaseDate;
        Group _group;
        Artist _artist;
        Album _album;
        List<Album> _albums=new List<Album>();
        List<Group> _groups=new List<Group>();
        List<Artist> _artists=new List<Artist>();
        List<PlayList> _playlists=new List<PlayList>();
        List<Director> _directors = new List<Director>();
        Director _director;
        bool isVideo;
        public Media (Director director, string title, int duration,string releaseDate,string genre)
        {
            _director=director;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            isVideo = true;

        }

        public Media( string genre, string title, int duration, string releaseDate, List<Album> albums, List<Group> groups, List<Artist> artists,bool isVideo)
        {   _id=_nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _groups = groups;
            _artists = artists;
            isVideo = false;
        }
        public Media(string genre, string title, int duration, string releaseDate, List<Album> albums, Group group, List<Artist> artists)
        {
            _id = _nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _group = group;
            _artists = artists; isVideo = false;
        }
        public Media(string genre, string title, int duration, string releaseDate, List<Album> albums, List<Group> groups, Artist artist)
        {
            _id = _nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _groups = groups;
            _artist = artist; isVideo = false;

        }
        public Media(string genre, string title, int duration, string releaseDate, Album album, Artist artist)
        {
            _id = _nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _album = album;

            _artist = artist; isVideo = false;

        }
        public Media(string genre, string title, int duration, string releaseDate, Artist artist)
        {
            _id = _nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;


            _artist = artist; isVideo = false;

        }
        public override string ToString()
        {
            return $"Title:{Title}-Artist:{Artist}-Genre:{Genre}-Release Date:{ReleaseDate}-Duration:{Duration}";
        }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
      public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Group> Groups { get => _groups; set => _groups = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
        public Group Group { get => _group; set => _group = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
       
        public int Id1 { get => _id; set => _id = value; }
        public List<PlayList> Playlists { get => _playlists; set => _playlists = value; }
        public int Rating { get => rating; set => rating = value; }
        public static int Personalrating { get => personalrating; set => personalrating = value; }
        internal List<Director> Directors { get => _directors; set => _directors = value; }
        internal Director Director { get => _director; set => _director = value; }
        public bool IsVideo { get => isVideo; set => isVideo = value; }
        public Album Album { get => _album; set => _album = value; }
    }
}
