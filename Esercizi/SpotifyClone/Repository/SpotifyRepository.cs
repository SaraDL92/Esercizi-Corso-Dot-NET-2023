using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using SpotifyClone.Entities;
using System.Linq;

namespace SpotifyClone.Repositories
{
    public class SpotifyRepository
    {
        private readonly string filePath;

        public SpotifyRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public List<AlbumDTO> ReadAlbumsFromCsv()
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<AlbumDTO>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return new List<AlbumDTO>();
            }
        }

        public void WriteAlbumsToCsv(List<AlbumDTO> albums)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(albums);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }

        public List<ArtistDTO> ReadArtistsFromCsv()
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<ArtistDTO>().ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return new List<ArtistDTO>();
            }
        }

        public void WriteArtistsToCsv(List<ArtistDTO> artists)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.WriteRecords(artists);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }

       
    }
}
