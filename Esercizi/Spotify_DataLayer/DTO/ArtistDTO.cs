using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class ArtistDTO
    {
        public int Id_Artist { get; set; }
        public string NameOfArtist { get; set; }
        public List<AlbumDTO> Albums { get; set; }=new List<AlbumDTO>();
        public List<SongDTO> Songs { get; set; }=new List<SongDTO>();

        public ArtistDTO(string name)
        {
            NameOfArtist = name;
           
           
          
        }
        public ArtistDTO() { }
    }
}
