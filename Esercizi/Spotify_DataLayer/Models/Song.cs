using System;

namespace Spotify_DataLayer.Models
{
    public class Song
    {
        public int Id_Song { get; set; }
        public string TitleOfSong { get; set; }
        public Artist ArtistOfSong { get; set; }
        public Radio Radio {  get; set; }
        public Album AlbumOfSong { get; set;}
    }
}
