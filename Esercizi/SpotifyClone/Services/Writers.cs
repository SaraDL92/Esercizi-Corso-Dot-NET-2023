using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Services
{
    public class Writers
    {
        public void WritePlaylistToFile(List<Song> playlist)
        {
            string filePath = @"C:\\Users\\sarad\\Documents\\DataBaseSpotify.csv";
            string tempFilePath = @"C:\\Users\\sarad\\Documents\\TempDataBaseSpotify.csv";

            using (StreamWriter tempWriter = new StreamWriter(tempFilePath))
            {
                int i = 0;

                tempWriter.WriteLine("ID, RATING, TITLE, ALBUM, ARTIST, GENRE, PLAYLIST, PLAYLIST ID");
                foreach (Song a in playlist)
                {
                    i = i + 1;
                    tempWriter.WriteLine($"{a.Id1}, {a.Rating}, {a.Title}, {a.Albums[0].Title}, {a.Artist.ArtistName}, {a.Genre}, {a.Playlists[0].Name}, {a.Playlists[0].Id}");
                }
            }

           
            File.Copy(tempFilePath, filePath, true);
            File.Delete(tempFilePath);  
        }

        public void WriteTopRatedSongsToFile(List<Song> playlist, int topCount)
        {
            string filePath = @"C:\\Users\\sarad\\Documents\\Top5Songs.csv";
            string tempFilePath = @"C:\\Users\\sarad\\Documents\\TempDataBaseSpotify1.csv";

            
            playlist.Sort((a, b) => b.Rating.CompareTo(a.Rating));

            using (StreamWriter tempWriter = new StreamWriter(tempFilePath))
            {
                int i = 0;

                tempWriter.WriteLine("ID, RATING, TITLE, ALBUM, ARTIST, GENRE, PLAYLIST, PLAYLIST ID");

                
                foreach (Song song in playlist.Take(topCount))
                {
                    i++;
                    tempWriter.WriteLine($"{song.Id1}, {song.Rating}, {song.Title}, {song.Albums[0].Title}, {song.Artist.ArtistName}, {song.Genre}, {song.Playlists[0].Name}, {song.Playlists[0].Id}");

                    if (i >= topCount)
                        break;
                }
            }

           
            File.Copy(tempFilePath, filePath, true);
            File.Delete(tempFilePath);  
        }



    }
}

