using DataLayer.DbContext;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Interfaces
{
    public interface ISongRepository
    {
       public List<Song> GetAllSongs();


      public Song GetSongById(int id);


        public void AddSong(Song song);


        public void DeleteSong(int id);
       
    }
}
