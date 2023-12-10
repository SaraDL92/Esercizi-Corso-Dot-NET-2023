using System;
using SpotifyClone.Entities;
using DataLayerSpotify.DB;
using SpotifyClone.Services;


namespace PresentationSpotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database1 = new Database();
            Database database = database1.InitializeDatabase();
            MediaComponent mediaplayer = new MediaComponent();
            Writers writers = new Writers();
            writers.WritePlaylistToFile(database.Songs);
            UserService userService = new UserService(database);

            User utente1 = new User("", "", "");
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

        static Artist ConvertToArtist(User user, string artistname, string bio)
        {
            return new Artist(user.Name, user.Surname, user.Birthday, artistname, "NuovaInfoArtista");
        }
    }
}
