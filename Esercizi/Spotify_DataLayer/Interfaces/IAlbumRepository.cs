using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface IAlbumRepository
    {
        List<Album> ReadAlbums();
        void WriteAlbums(List<Album> albums);
        Album ReadAlbumById(int albumId);
        List<Song> ReadAlbumSongs(Album album);
        void WriteAlbumSongs(List <Song>songs,string title);
    }
}
