using DataLayerT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerT.DB
{
    public class DataBase
    {
       public List<Song> SongList =new List<Song>();
       public List<Album> AlbumList =new List<Album>();
       public List<Artist> ArtistList = new List<Artist>();
       public List<MusicalGroup> GroupList = new List<MusicalGroup>();

        public DataBase() {
            SongList = new List<Song>();
            AlbumList = new List<Album>();
            ArtistList = new List<Artist>();
            GroupList = new List<MusicalGroup>();
        }
    }
}
