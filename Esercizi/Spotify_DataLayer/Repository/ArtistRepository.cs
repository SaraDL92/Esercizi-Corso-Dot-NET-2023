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
   public class ArtistRepository:IArtistRepository
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyArtists.csv";

        public List<Artist> ReadArtists()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Artist>().ToList();
                }
            }

            return new List<Artist>();
        }
        public Artist ReadArtistById(int artistId)
        {
            var artists = ReadArtists();
            return artists.FirstOrDefault(a => a.Id_Artist == artistId);
        }
        public void WriteArtists(List<Artist> artists)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(artists);
            }
        }
    }
}
