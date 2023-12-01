using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class MediaDTO
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
        List<AlbumDTO> _albums = new List<AlbumDTO>();
        List<GroupDTO> _groups = new List<GroupDTO>();
        List<ArtistDTO> _artists = new List<ArtistDTO>();
        List<PlaylistDTO> _playlists = new List<PlaylistDTO>();
        DirectorDTO _director;
        bool isVideo;

        public static int Personalrating { get => personalrating; set => personalrating = value; }
        public int Rating { get => rating; set => rating = value; }
        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        internal GroupDTO Group { get => _group; set => _group = value; }
        internal ArtistDTO Artist { get => _artist; set => _artist = value; }
        internal AlbumDTO Album { get => _album; set => _album = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        internal List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        internal List<ArtistDTO> Artists { get => _artists; set => _artists = value; }
        internal List<PlaylistDTO> Playlists { get => _playlists; set => _playlists = value; }
        internal DirectorDTO Director { get => _director; set => _director = value; }
        public bool IsVideo { get => isVideo; set => isVideo = value; }
    }
}
