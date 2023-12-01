using DataLayer.DbContext;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories
{
    internal class SongRepository : ISongRepository
    {
        private readonly SongDbContext _songDbContext;

        public SongRepository(SongDbContext dbcontext)
        {
            _songDbContext = dbcontext;
        }

       public List<Song> GetAllSongs()
        {
            return _songDbContext.SongList.ToList();
        }

        public Song GetSongById(int id)
        {
            return _songDbContext.SongList.FirstOrDefault(s => s.Id == id);
        }

        public void AddSong(Song song)
        {
            _songDbContext.SongList.Add(song);

        }

       public void DeleteSong(int id)
        {
            var songtodelete = _songDbContext.SongList.FirstOrDefault(s => s.Id == id);
            if (songtodelete != null)
            {
                _songDbContext.SongList.Remove(songtodelete);


            }
        }


    }
}