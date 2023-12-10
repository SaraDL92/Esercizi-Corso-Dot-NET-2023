using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datalayer1.Models;

namespace datalayer1.DbContext
{
    public class DB
    {
        public List<Song> Songs { get; set; }
        public List <Movie> Movies { get; set; }
        public List <Album> Albums {  get; set; }
        public List<Playlist> Playlists { get; set; } 

        public List <Artist> Artists { get; set; }

        public DB() {
            Songs = new List<Song>();
            Movies=new List<Movie>();
            Albums = new List<Album>();
            Artists = new List<Artist>();
            Playlists=new List<Playlist>();
        }
    }
}
