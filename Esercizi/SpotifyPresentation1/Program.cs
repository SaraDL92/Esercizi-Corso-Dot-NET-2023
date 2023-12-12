using System;
using SpotifyClone.Entities;
using SpotifyClone.Services;
using SpotifyClone.Services.Spotify.Services;
using Spotify_Service.Services;
using System.Collections.Generic;
using System.IO;
using SpotifyClone.Repositories;
using SpotifyLibrary.DB;
using System.Globalization;
using SpotifyLibrary.ModelsFolder;
using CsvHelper;
using System.Linq;

namespace SpotifyPresentation1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseDTO database1 = new DatabaseDTO();
            DatabaseDTO database = database1.InitializeDatabase();
            MediaComponent mediaplayer = new MediaComponent();
            WriteOnDBservice writers = new WriteOnDBservice();
            ReadFromDBservice reader = new ReadFromDBservice();
           //writers.WritePlaylistToFile(database.Songs, @"C:\Users\sarad\Documents\DataBaseSpotifySongs.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempSongs.csv", "");
            writers.WriteAlbumsOnCsvFile(database.Albums, @"C:\Users\sarad\Documents\DataBaseSpotifyAlbums.csv");
            writers.WriteArtistsOnCsvFile(database.Artists, @"C:\Users\sarad\Documents\DataBaseSpotifyArtists.csv");
            writers.WriteSongsOnCsvFile(database.Songs, @"C:\Users\sarad\Documents\DataBaseSpotifySongs.csv");
            writers.WriteMoviesOnCsvFile(database.Movies, @"C:\Users\sarad\Documents\DataBaseSpotifyMovies.csv");


            //writers.WritePlaylistToFile(database.Artists, @"C:\Users\sarad\Documents\DataBaseSpotifyArtists.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempArtists.csv", "");
            //writers.WritePlaylistToFile(database.Playlists, @"C:\Users\sarad\Documents\DataBaseSpotifyPlaylists.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempPlaylists.csv", "");
            //writers.WritePlaylistToFile(database.Radiolist, @"C:\Users\sarad\Documents\DataBaseSpotifyRadios.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempRadios.csv", "");
            //writers.WritePlaylistToFile(database.Movies, @"C:\Users\sarad\Documents\DataBaseSpotifyMovies.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempMovies.csv", "");
            //writers.WritePlaylistToFile(database.Users, @"C:\Users\sarad\Documents\DataBaseSpotifyUsers.csv", @"C:\Users\sarad\Documents\DataBaseSpotifyTempUsers.csv", "");


            UserService userService = new UserService(database);
            SpotifyRepository spotifyRepository = new("C:\\Users\\sarad\\Documents\\DataBaseSpotifySongs.csv");
            SpotifyService spotifyService = new(spotifyRepository);

            List<Album> albums =reader.ReadAlbumsFromCsvFile("C:\\Users\\sarad\\Documents\\DataBaseSpotifyAlbums.csv");
            List<Artist> artists = reader.ReadArtistsFromCsvFile("C:\\Users\\sarad\\Documents\\DataBaseSpotifyArtists.csv");
            List<Media> songs = reader.ReadSongsFromCsvFile("C:\\Users\\sarad\\Documents\\DataBaseSpotifySongs.csv");
            List<Media>movies = reader.ReadMoviesFromCsvFile("C:\\Users\\sarad\\Documents\\DataBaseSpotifyMovies.csv");
            foreach (SpotifyClone.Entities.Album album in albums)
            {
                Console.WriteLine(album.Title);
            }




            UserDTO utente1 = new UserDTO("", "", "");
            Artist convertedArtist = ConvertToArtist(utente1, "", "");

            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Spotify!");
            Console.ForegroundColor = originalColor;
            bool artist = false;
            bool islogged = false;

            while (!utente1.IsLogged)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter R for Register or L for Login:");
                Console.ForegroundColor = originalColor;
                string input1 = Console.ReadLine();

                switch (input1.ToLower())
                {
                    case "r":
                        userService.RegisterUser(utente1);
                        break;
                    case "l":
                        userService.LoginUser(utente1);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Invalid input. Retry!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }




            bool esciDaMediaService = false;


            MediaService mediaService = new MediaService(database, new MediaComponent());


            mediaService.ManageMusic(utente1, convertedArtist, database, out esciDaMediaService, writers);

            if (!esciDaMediaService)
            {
                UserProfileManager profileManager = new UserProfileManager(utente1);


                profileManager.ManageProfile(utente1, database, convertedArtist, writers);
            }
            writers.WriteTopRatedSongsToFile(database.Songs, 5);
            
           

        }

        static Artist ConvertToArtist(UserDTO user, string artistname, string bio)
        {
            return new Artist(user.Name, user.Surname, user.Birthday, artistname, "NuovaInfoArtista");
        }
      

       
    }

    }

