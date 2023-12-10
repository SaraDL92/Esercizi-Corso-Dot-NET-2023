using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using datalayer1.DbContext;
using datalayer1.DTO;
using datalayer1.Models;


namespace datalayer1.Repositories
{
    public class Repository
    {
        readonly DB database;
        public DbContext.DbContext dbcontext;

        public Repository(DB data)
        {
            database = data;
            dbcontext = new DbContext.DbContext();
        }

        public void AddItem<T>(T item) where T : class
        {
            if (typeof(T) == typeof(Song))
            {
                var song = item as Song;
                database.Songs.Add(song);
            }
            else if (typeof(T) == typeof(Movie))
            {
                var movie = item as Movie;
                database.Movies.Add(movie);
            }
            else if (typeof(T) == typeof(Playlist))
            {
                var playlist = item as Playlist;
                database.Playlists.Add(playlist);
            }
            else if (typeof(T) == typeof(Album))
            {
                var album = item as Album;
                database.Albums.Add(album);
            }
            else if (typeof(T) == typeof(Artist))
            {
                var artist = item as Artist;
                database.Artists.Add(artist);
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T)}");
            }
        }
        public T GetItemById<T>(int id) where T : class
        {
            object foundItem = null;

            if (typeof(T) == typeof(Song))
            {
                foundItem = database.Songs.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
            }
            else if (typeof(T) == typeof(Movie))
            {
                foundItem = database.Movies.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
            }
            else if (typeof(T) == typeof(Playlist))
            {
                foundItem = database.Playlists.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
            }
            else if (typeof(T) == typeof(Album))
            {
                foundItem = database.Albums.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
            }
            else if (typeof(T) == typeof(Artist))
            {
                foundItem = database.Artists.FirstOrDefault(item => (int)item.GetType().GetProperty("Id").GetValue(item) == id);
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T)}");
            }

            T typedItem = foundItem as T;

            if (typedItem != null)
            {
                PrintItemDetails(typedItem);
            }
            else
            {
                Console.WriteLine($"Item with ID {id} not found.");
            }

            return typedItem;
        }

        private void PrintItemDetails<T>(T item) where T : class
        {
            if (typeof(T) == typeof(Song))
            {
                var song = item as Song;
                Console.WriteLine($"Song {song.Id} - Title: {song.Title}, Artist: {song.Artist.Name}, Album: {song.Album.Title}");
            }
            else if (typeof(T) == typeof(Movie))
            {
                var movie = item as Movie;
                Console.WriteLine($"Movie {movie.Id} - Title: {movie.Title}, Director: {movie.Director}");
            }
            else if (typeof(T) == typeof(Playlist))
            {
                var playlist = item as Playlist;
                Console.WriteLine($"Playlist {playlist.Id} - Title: {playlist.Title}");
            }
            else if (typeof(T) == typeof(Artist))
            {
                var artist = item as Artist;
                Console.WriteLine($"Artist {artist.Id} -Name: {artist.Name}");
            }
            else if (typeof(T) == typeof(Album))
            {
                var album = item as Album;
                Console.WriteLine($"Album {album.Id} - Title: {album.Title}, Artist: {album.Artist.Name}");
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(T)}");
            }
        }

        public List<T> GetAllItems<T>(string filepath) where T : class
        {
            var items = dbcontext.ReadFromCsv<T>(filepath);

            foreach (var item in items)
            {
                if (typeof(T) == typeof(Song))
                {
                    var song = item as Song;
                    Console.WriteLine($"Song {song.Id} - Title: {song.Title}, Artist: {song.Artist.Name}, Album:{song.Album.Title}");
                }
                else if (typeof(T) == typeof(Movie))
                {
                    var movie = item as Movie;
                    Console.WriteLine($"Movie {movie.Id} - Title: {movie.Title}, Director: {movie.Director}");
                }
                else if (typeof(T) == typeof(Album))
                {
                    var album = item as Album;
                    
                    Console.WriteLine($"Album {album.Id} - Title: {album.Title}, Artist: {album.Artist.Name}");
                    foreach(Song s in album.Songs) { Console.WriteLine(s.Title); }
                }
                else if (typeof(T) == typeof(Playlist))
                {
                    var playlist = item as Playlist;

                    Console.WriteLine($"Playlist {playlist.Id} - Title: {playlist.Title}");
                    foreach (Song s in playlist.Songs) { Console.WriteLine(s.Title); }
                }
                else if (typeof(T) == typeof(Artist))
                {
                    var artist = item as Artist;
                    Console.WriteLine($"Artist {artist.Id} - Name: {artist.Name}");
                }
                else
                {
                    throw new ArgumentException($"Unsupported type: {typeof(T)}");
                }
            }

            return items.ToList();
        }
    }
}