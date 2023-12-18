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
    public class AlbumRepository : IAlbumRepository
    {

        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyAlbums.csv";
        private const string FilePathTrackList = "C:\\Users\\sarad\\Documents\\";

        public List<Album> ReadAlbums()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Album>().ToList();
                }
            }

            return new List<Album>();
        }
        public List<Song> ReadAlbumSongs(Album album)
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePathTrackList+album.TitleOfAlbum+"Tracklist.csv"))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Song>().ToList();
                }
            }

            return new List<Song>();
        }
        public Album ReadAlbumById(int albumId)
        {
            var albums = ReadAlbums();
            return albums.FirstOrDefault(a => a.Id_Album == albumId);
        }

        public void WriteAlbums(List<Album> albums)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(albums);
            }
        }

        public void WriteAlbumSongs(List<Song> songs, string title)
        {
           
            using (var writer = new StreamWriter(FilePathTrackList + title + "Tracklist.csv"))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(songs);
            }
        }
    }
}
   