using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Album
    {
        public int Id_Album { get; set; }
        public string TitleOfAlbum { get; set; }
        public Artist ArtistOfAlbum { get; set; }
        public List<Song> Songs { get; set; }
    }
}
