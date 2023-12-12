using CsvHelper;
using SpotifyClone.Entities;
using SpotifyLibrary.ModelsFolder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyLibrary.DTOs;

namespace Spotify_Service.Services
{
    public class ReadFromDBservice
    {
        public List<Album> ReadAlbumsFromCsvFile(string filePath)
        {
            // Utilizza CsvHelper per leggere il file CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Configura CsvHelper per mappare le colonne alle proprietà della classe AlbumDTO
                csv.Context.RegisterClassMap<AlbumDTO>();

                // Leggi tutti i record dal file CSV e restituisci una lista di Album
                return csv.GetRecords<Album>().ToList();
            }
        }

        public List<Artist> ReadArtistsFromCsvFile(string filePath)
        {
            // Utilizza CsvHelper per leggere il file CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Configura CsvHelper per mappare le colonne alle proprietà della classe AlbumDTO
                csv.Context.RegisterClassMap<ArtistDTO>();

                // Leggi tutti i record dal file CSV e restituisci una lista di Album
                return csv.GetRecords<Artist>().ToList();
            }
        }

        public List<Media> ReadSongsFromCsvFile(string filePath)
        {
            // Utilizza CsvHelper per leggere il file CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Configura CsvHelper per mappare le colonne alle proprietà della classe AlbumDTO
                csv.Context.RegisterClassMap<SongDTO>();

                // Leggi tutti i record dal file CSV e restituisci una lista di Album
                return csv.GetRecords<Media>().ToList();
            }
        }

        public List<Media> ReadMoviesFromCsvFile(string filePath)
        {
            // Utilizza CsvHelper per leggere il file CSV
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Configura CsvHelper per mappare le colonne alle proprietà della classe AlbumDTO
                csv.Context.RegisterClassMap<MovieDTO>();

                // Leggi tutti i record dal file CSV e restituisci una lista di Album
                return csv.GetRecords<Media>().ToList();
            }
        }
    }


}



