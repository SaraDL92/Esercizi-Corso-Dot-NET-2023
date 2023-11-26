using SpotifyClone.Entities;
using SpotifyClone.Services;
using SpotifyClone.Services.Spotify.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace SpotifyClone
{
    internal class Program
    {
        static void Main(string[] args)
        {Database database1 = new Database();
         Database database =  database1.InitializeDatabase();
         MediaComponent mediaplayer = new MediaComponent();
            WritePlaylistToFile(database.Songs);
            UserService userService = new UserService(database);

            User utente1 = new User("", "", "");
            Artist convertedArtist = ConvertToArtist(utente1, "", "");

            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Spotify!");
            Console.ForegroundColor = originalColor;
            bool artist = false;
            bool islogged = false;

           
            while (utente1.IsLogged==false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter R for Register or L for Login:");
                Console.ForegroundColor = originalColor;
                string input1 = Console.ReadLine();

                if (input1 == "r" || input1 == "R")
                {
                    userService.RegisterUser(utente1);
                }
                else if (input1 == "l" || input1 == "L")
                {
                    userService.LoginUser(utente1);
                    islogged = true;
                   utente1.IsLogged = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Retry!");
                    Console.ForegroundColor = ConsoleColor.White;
                    islogged = false;
                    utente1.IsLogged=false;
                }
            }

            bool esciDaMediaService = false;

           
            MediaService mediaService = new MediaService(database, new MediaComponent());

          
            mediaService.ManageMusic(utente1, convertedArtist, database, out esciDaMediaService);

            if (!esciDaMediaService)
            {
                UserProfileManager profileManager = new UserProfileManager(utente1);

              
                profileManager.ManageProfile(utente1,database,convertedArtist);
            }
          

        }

        static Artist ConvertToArtist(User user, string artistname, string bio)
        {
            return new Artist(user.Name, user.Surname, user.Birthday, artistname, "NuovaInfoArtista");
        }
        static void WritePlaylistToFile(List<Song> playlist)
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

            // Copia il contenuto del file temporaneo nel file principale
            File.Copy(tempFilePath, filePath, true);
            File.Delete(tempFilePath);  // Elimina il file temporaneo
        }

    }
}
