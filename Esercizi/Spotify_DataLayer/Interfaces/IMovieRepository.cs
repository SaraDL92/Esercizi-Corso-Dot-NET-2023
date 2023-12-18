using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Interfaces
{
   public interface IMovieRepository
    {
        List<Movie> ReadMovies();
        void WriteMovies(List<Movie> directors);
        Movie ReadMoviesById(int Id);
    }
}
