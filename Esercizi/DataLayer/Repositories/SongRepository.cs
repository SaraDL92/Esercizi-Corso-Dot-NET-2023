using DataLayer.DbContext;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataLayer.Dto;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("ServiceLayer")]

namespace DataLayer.Repositories
{
    internal class SongRepository 
    {
        private readonly SongDbContext _songDbContext;

        public SongRepository(SongDbContext dbcontext)
        {
            _songDbContext = dbcontext;
        }

       internal List<SongDTO> GetAllSongs()
        {
            List<SongDTO> listacanzoni = new();
           List <Song>listacanzonii=_songDbContext.SongList.ToList();
            foreach(Song song in listacanzonii)
            {
                SongDTO songDTO = new(song);
                listacanzoni.Add(songDTO);
            }
            return listacanzoni;
        }

        internal SongDTO GetSongById(int id)
        {List <SongDTO> listacanzoni = new();
            List<Song> songs= _songDbContext.SongList.ToList();
            foreach(Song song in songs)
            {
                SongDTO songDTO = new(song);
                listacanzoni.Add(songDTO);
            }
            return listacanzoni.FirstOrDefault(s => s.Id == id);
        }

        internal void AddSong(Song song)
        {
            
            _songDbContext.SongList.Add(song);

        }

       internal   void DeleteSong(int id)
        {
            var songtodelete = _songDbContext.SongList.FirstOrDefault(s => s.Id == id);
            if (songtodelete != null)
            {
                _songDbContext.SongList.Remove(songtodelete);


            }
        }


    }
}