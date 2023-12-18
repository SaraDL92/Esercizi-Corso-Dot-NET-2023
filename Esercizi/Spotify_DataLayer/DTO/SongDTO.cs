using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class SongDTO
    {
        public int Id_Song { get; set; }
        public string TitleOfSong { get; set; }
        public ArtistDTO ArtistOfSong { get; set; }
        public AlbumDTO AlbumOfSong { get; set; }
        public RadioDTO Radio { get; set; }

        public SongDTO() { }

        public SongDTO(string title, ArtistDTO artist, AlbumDTO album,RadioDTO radio) 
        {
            TitleOfSong = title;
            ArtistOfSong = artist;
            AlbumOfSong = album;
            Radio = radio;
            artist.Songs.Add(this);
            album.Songs.Add(this);
            radio.Songs.Add(this);

        
        }
    }
}
