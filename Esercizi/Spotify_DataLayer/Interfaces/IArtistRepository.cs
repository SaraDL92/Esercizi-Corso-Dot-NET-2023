using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
    public interface IArtistRepository
    {
        List<Artist> ReadArtists();
        void WriteArtists(List<Artist> artists);
        Artist ReadArtistById(int artistId);
    }
}
