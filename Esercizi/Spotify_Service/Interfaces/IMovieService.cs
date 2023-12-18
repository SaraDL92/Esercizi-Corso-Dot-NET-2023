using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Service.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetAllMovies();
        MovieDTO GetMovieById(int Id);
        List<DirectorDTO> GetAllDirectors();
        DirectorDTO GetDirectorById(int Id);
        void AddMovie(MovieDTO newMovie);
        void AddDirector(DirectorDTO newDirector);
    }
}
