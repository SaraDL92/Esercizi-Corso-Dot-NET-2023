using CsvHelper.Configuration;
using CsvHelper;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyMovies.csv";

        public List<Movie> ReadMovies()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Movie>().ToList();
                }
            }

            return new List<Movie>();
        }
        public Movie ReadMoviesById(int Id)
        {
            var movies = ReadMovies();
            return movies.FirstOrDefault(m => m.Id_Movie == Id);
        }

        public void WriteMovies(List<Movie> movies)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(movies);
            }
        }
    }
}