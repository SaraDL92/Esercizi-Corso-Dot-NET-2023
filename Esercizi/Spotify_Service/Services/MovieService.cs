using AutoMapper;
using Spotify_DataLayer.DTO;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Models;
using Spotify_DataLayer.Repository;
using Spotify_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Service.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;

        private readonly IMapper _mapper;

        public MovieService(IMovieRepository mRepository, IDirectorRepository dRepository, IMapper mapper)
        {
            _movieRepository = mRepository;
            _directorRepository = dRepository;

            _mapper = mapper;
        }

        public List<MovieDTO> GetAllMovies()
        {
            var movies = _movieRepository.ReadMovies();
            return _mapper.Map<List<MovieDTO>>(movies);
        }
        public MovieDTO GetMovieById(int Id)
        {
            var movie = _movieRepository.ReadMoviesById(Id);

            if (movie == null)
            {

                return null;
            }

            return _mapper.Map<MovieDTO>(movie);
        }

        public List<DirectorDTO> GetAllDirectors()
        {
            var directors = _directorRepository.ReadDirectors();
            return _mapper.Map<List<DirectorDTO>>(directors);
        }
        public DirectorDTO GetDirectorById(int Id)
        {
            var director = _directorRepository.ReadDirectorById(Id);

            if (director == null)
            {

                return null;
            }

            return _mapper.Map<DirectorDTO>(director);
        }

        public void AddMovie(MovieDTO newMovie)
        {
            var movies = _movieRepository.ReadMovies();
            int nuovoId = movies.Count + 1;

            var movie = _mapper.Map<Movie>(newMovie);
            movie.Id_Movie = nuovoId;

            movies.Add(movie);
            _movieRepository.WriteMovies(movies);

        }
        public void AddDirector(DirectorDTO newDirector)
        {
            var directors = _directorRepository.ReadDirectors();
            int nuovoId = directors.Count + 1;

            var director = _mapper.Map<Director>(newDirector);
            director.Id_Director = nuovoId;

            directors.Add(director);
            _directorRepository.WriteDirectors(directors);

        }
    } 
    }
   

