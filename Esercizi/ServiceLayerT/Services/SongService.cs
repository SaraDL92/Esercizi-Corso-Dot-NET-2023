using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.Repositories;
using DataLayerT.DTO;
using DataLayerT.Models;
using DataLayerT.DB;

namespace ServiceLayerT.Services
{
   public class SongService
    {
        SongRepository _songRepository;
       

        public SongService(SongRepository songRepository)
        {
            _songRepository = songRepository;
            

        }

        public void GetAllSongs()
        {
            _songRepository.GetAllSongs();



        }
        public void AddSong(SongDTO song)
        {
            Song song1 = new Song(song);


            _songRepository.AddSong(song1);

        }
        public SongRepository SongRepository { get => _songRepository; set => _songRepository = value; }
    }
}
