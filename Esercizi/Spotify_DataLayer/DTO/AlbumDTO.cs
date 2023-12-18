using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class AlbumDTO
    {
        public int Id_Album { get; set; }

        public string TitleOfAlbum { get; set; }
        public ArtistDTO ArtistOfAlbum { get; set; }
        public List<SongDTO> Songs { get; set; } = new List<SongDTO>();

        public AlbumDTO() { }   

        public AlbumDTO(string title, ArtistDTO artist) 
        {  
            TitleOfAlbum = title;
            ArtistOfAlbum = artist;
            Songs=new List<SongDTO>();
          
            artist.Albums.Add(this);
            

        }
    }
}
