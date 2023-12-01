using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class SongDbContext
    {
        List<Song> _songList;

        public void InizializeDBSongs()
        { Artist mj = new();
            Album dangerous = new Album();
            Song healtheworld = new Song("Heal the World","POP",180,mj,null,dangerous,0);
            Song gonetoosoon = new Song("Gone too soon", "POP", 180, mj, null, dangerous, 0);


        }

        internal List<Song> SongList { get => _songList; set => _songList = value; }
    }
}
