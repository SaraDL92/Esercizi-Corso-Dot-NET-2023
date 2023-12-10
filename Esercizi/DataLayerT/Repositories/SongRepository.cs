using DataLayerT.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.Models;

namespace DataLayerT.Repositories
{
    public class SongRepository
    {
        DataBase _database;

        public SongRepository(DataBase database) {
            _database = database;
        }

        internal DataBase Database { get => _database; set => _database = value; }

        public void GetAllSongs() {
           foreach (Song s in _database.SongList)
            {
                Console.WriteLine(s.Title);
            }
        }
        public void AddSong(Song song) {
            _database.SongList.Add(song);
        }
    }
}
