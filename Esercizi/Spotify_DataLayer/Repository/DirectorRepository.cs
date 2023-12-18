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
    public class DirectorRepository : IDirectorRepository
   
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyDirectors.csv";

        public List<Director> ReadDirectors()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Director>().ToList();
                }
            }

            return new List<Director>();
        }
        public Director ReadDirectorById(int Id)
        {
            var directors = ReadDirectors();
            return directors.FirstOrDefault(m => m.Id_Director == Id);
        }

        public void WriteDirectors(List<Director> directors)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(directors);
            }
        }
    }
}