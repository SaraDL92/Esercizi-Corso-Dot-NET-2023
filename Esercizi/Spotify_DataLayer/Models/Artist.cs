using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Artist
    {
        public int Id_Artist { get; set; }
        public string NameOfArtist { get; set; }
        public List <Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
    }
}
