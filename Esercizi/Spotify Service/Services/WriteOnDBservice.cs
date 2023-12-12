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

namespace SpotifyClone.Services
{
    public class WriteOnDBservice
    {
        public void WriteAlbumsOnCsvFile(List<Album> albums, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<AlbumDTO>();
                csvWriter.WriteRecords(albums);
            }
        }

        public void WriteArtistsOnCsvFile(List<Artist> artists, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<ArtistDTO>();
                csvWriter.WriteRecords(artists);
            }
        }
        public void WriteSongsOnCsvFile(List<Media> songs, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<SongDTO>();
                csvWriter.WriteRecords(songs);
            }
        }

        public void WriteMoviesOnCsvFile(List<Media> movies, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.Context.RegisterClassMap<MovieDTO>();
                csvWriter.WriteRecords(movies);
            }
        }
        public void WritePlaylistToFilee<T>(List<T> playlist, string filepath, string filepathtemp)
        {
            string tempFilePath = filepathtemp;

            using (StreamWriter tempWriter = new StreamWriter(tempFilePath))
            using (CsvWriter csvWriter = new CsvWriter(tempWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(playlist);
            }

            File.Copy(tempFilePath, filepath, true);
            File.Delete(tempFilePath);
        }

        public void WriteListeningTimeToFile(UserDTO user)
        {
            string filePath = @"C:\\Users\\sarad\\Documents\\DataBaseSpotify.csv";


            string newLine = $"duration of the music listening session: {user.SessionDuration.TotalSeconds} seconds";


            string[] lines = File.ReadAllLines(filePath);


            int durationIndex = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("duration of the music listening session:"))
                {
                    durationIndex = i;
                    break;
                }
            }


            if (durationIndex != -1)
            {
                lines[durationIndex] = newLine;
            }
            else
            {
                List<string> linesList = lines.ToList();
                linesList.Add(newLine);
                lines = linesList.ToArray();
            }


            File.WriteAllLines(filePath, lines);
        }


        public void WriteTopRatedSongsToFile(List<Media> playlist, int topCount)
        {
            string filePath = @"C:\\Users\\sarad\\Documents\\Top5Songs.csv";
            string tempFilePath = @"C:\\Users\\sarad\\Documents\\TempDataBaseSpotify1.csv";


            playlist.Sort((a, b) => b.Rating.CompareTo(a.Rating));

            using (StreamWriter tempWriter = new StreamWriter(tempFilePath))
            {
                int i = 0;

                tempWriter.WriteLine("ID, RATING, TITLE, ALBUM, ARTIST, GENRE, PLAYLIST, PLAYLIST ID");


                foreach (Media song in playlist.Take(topCount))
                {
                    i++;
                    if (song.IsVideo == false)
                    {
                        tempWriter.WriteLine($"{song.Id1}, {song.Rating}, {song.Title}, {song.Albums[0].Title}, {song.Artist.ArtistName}, {song.Genre}, {song.Playlists[0].Name}, {song.Playlists[0].Id}");
                    }

                    if (i >= topCount)
                        break;
                }
            }


            File.Copy(tempFilePath, filePath, true);
            File.Delete(tempFilePath);
        }



    }
}