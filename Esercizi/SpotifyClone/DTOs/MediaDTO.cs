using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class MediaDTO
    {
        private static int personalrating = 0;
        int rating = personalrating;
        private static int _nextid = 1;
        int _id;
        string _genre;
        string _title;
        int _duration;
        string _releaseDate;
        GroupDTO _group;
        ArtistDTO _artist;
        AlbumDTO _album;
        List<AlbumDTO> _albums=new List<AlbumDTO>();
        List<GroupDTO> _groups=new List<GroupDTO>();
        List<ArtistDTO> _artists=new List<ArtistDTO>();
        List<PlayListDTO> _playlists=new List<PlayListDTO>();
        List<Director> _directors = new List<Director>();
        Director _director;
        bool isVideo;
        public MediaDTO (Director director, string title, int duration,string releaseDate,string genre)
        {
            _director=director;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            isVideo = true;

        }

        public MediaDTO( string genre, string title, int duration, string releaseDate, List<AlbumDTO> albums, List<GroupDTO> groups, List<ArtistDTO> artists,bool isVideo)
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
        public MediaDTO(string genre, string title, int duration, string releaseDate, List<AlbumDTO> albums, GroupDTO group, List<ArtistDTO> artists)
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
        public MediaDTO(string genre, string title, int duration, string releaseDate, List<AlbumDTO> albums, List<GroupDTO> groups, ArtistDTO artist)
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
        public MediaDTO(string genre, string title, int duration, string releaseDate, AlbumDTO album, ArtistDTO artist)
        {
            _id = _nextid++;
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _album = album;

            _artist = artist; isVideo = false;

        }
        public MediaDTO(string genre, string title, int duration, string releaseDate, ArtistDTO artist)
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
      public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        public List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        public List<ArtistDTO> Artists { get => _artists; set => _artists = value; }
        public GroupDTO Group { get => _group; set => _group = value; }
        public ArtistDTO Artist { get => _artist; set => _artist = value; }
       
        public int Id1 { get => _id; set => _id = value; }
        public List<PlayListDTO> Playlists { get => _playlists; set => _playlists = value; }
        public int Rating { get => rating; set => rating = value; }
        public static int Personalrating { get => personalrating; set => personalrating = value; }
        internal List<Director> Directors { get => _directors; set => _directors = value; }
        internal Director Director { get => _director; set => _director = value; }
        public bool IsVideo { get => isVideo; set => isVideo = value; }
    }
}
