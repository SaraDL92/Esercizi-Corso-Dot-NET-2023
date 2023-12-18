using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface ISongRepository
    {
        List<Song> ReadSongs();
        Song ReadSongById(int songId);
        void WriteSongs(List<Song> songs);
    }
}
