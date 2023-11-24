using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class Song
    {
        string _genre;
        string _title;
        int _duration;
        string _releaseDate;
        Group _group;
        Artist _artist;
        Album _album;
        List<Album> _albums;
        List<Group> _groups;
        List<Artist> _artists;

        public Song(string genre, string title, int duration, string releaseDate, List<Album> albums, List<Group> groups, List<Artist> artists)
        {
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _groups = groups;
            _artists = artists;
        }
        public Song(string genre, string title, int duration, string releaseDate, List<Album> albums, Group group, List<Artist> artists)
        {
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _group = group;
            _artists = artists;
        }
        public Song(string genre, string title, int duration, string releaseDate, List<Album> albums, List<Group> groups, Artist artist)
        {
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _albums = albums;
            _groups = groups;
            _artist = artist;

        }
        public Song(string genre, string title, int duration, string releaseDate, Album album, Artist artist)
        {
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;
            _album = album;

            _artist = artist;

        }
        public Song(string genre, string title, int duration, string releaseDate, Artist artist)
        {
            _genre = genre;
            _title = title;
            _duration = duration;
            _releaseDate = releaseDate;


            _artist = artist;

        }
        public override string ToString()
        {
            return $"Title:{Title}-Artist:{Artist}-Genre:{Genre}-Release Date:{ReleaseDate}-Duration:{Duration}";
        }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Group> Groups { get => _groups; set => _groups = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal Group Group { get => _group; set => _group = value; }
        internal Artist Artist { get => _artist; set => _artist = value; }
    }
}
