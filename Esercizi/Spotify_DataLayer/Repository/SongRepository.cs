using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Models;

namespace Spotify_DataLayer.Repository
{
    public class SongRepository:ISongRepository
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifySongs.csv";

        public List<Song> ReadSongs()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Song>().ToList();
                }
            }

            return new List<Song>();
        }
        public Song ReadSongById(int songId)
        {
            var songs = ReadSongs();
            return songs.FirstOrDefault(song => song.Id_Song == songId);
        }

        public void WriteSongs(List<Song> songs)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(songs);
            }
        }
    }
}