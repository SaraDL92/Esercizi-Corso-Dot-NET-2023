using SpotifyClone.Entities;
using SpotifyLibrary.ModelsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLibrary.DTOs
{
    public class MovieDTO: CsvHelper.Configuration.ClassMap<Media>
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
        Artist _artist;
        Album _album;
        List<AlbumDTO> _albums = new List<AlbumDTO>();
        List<GroupDTO> _groups = new List<GroupDTO>();
        List<Artist> _artists = new List<Artist>();
        List<PlayList> _playlists = new List<PlayList>();
        List<DirectorDTO> _directors = new List<DirectorDTO>();
        DirectorDTO _director;
        bool isVideo;
        public MovieDTO()
        {
            Map(m => m.Title).Name("TITLE");
            Map(m => m.Director.Name).Name("DIRECTOR");
            Map(m => m.Duration).Name("DURATION");
            Map(m => m.ReleaseDate).Name("RELEASE DATE");
          
           
            Map(m => m.Genre).Name("GENRE");

        }
        public static int Personalrating { get => personalrating; set => personalrating = value; }
        public int Rating { get => rating; set => rating = value; }
        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public GroupDTO Group { get => _group; set => _group = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public Album Album { get => _album; set => _album = value; }
        public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        public List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        public List<Artist> Artists { get => _artists; set => _artists = value; }
        public List<PlayList> Playlists { get => _playlists; set => _playlists = value; }
        public List<DirectorDTO> Directors { get => _directors; set => _directors = value; }
        public DirectorDTO Director { get => _director; set => _director = value; }
        public bool IsVideo { get => isVideo; set => isVideo = value; }

    }
}
