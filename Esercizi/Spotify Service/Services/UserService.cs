using SpotifyClone.Entities;
using SpotifyLibrary.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Services
{
    public class UserService
    {
        private DatabaseDTO database;
        bool _isArtist = false;

        public UserService(DatabaseDTO database)
        {
            this.database = database;
        }

        public void RegisterUser(UserDTO utente1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert name:");
            Console.ForegroundColor = ConsoleColor.White;
            string name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert surname:");
            Console.ForegroundColor = ConsoleColor.White;
            string surname = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert birthday:");
            Console.ForegroundColor = ConsoleColor.White;
            string birthday = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert username:");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert password:");
            Console.ForegroundColor = ConsoleColor.White;
            string password = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert your language:");
            Console.ForegroundColor = ConsoleColor.White;
            string language = Console.ReadLine();

            List<PlayList> playlist = new List<PlayList>();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Are you an artist? Y|N");
                Console.ForegroundColor = ConsoleColor.White;
                string isartist = Console.ReadLine();


                if (isartist == "y" || isartist == "Y")
                {
                    _isArtist = true;
                    break;
                }
                else if (isartist == "n" || isartist == "N")
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Incorrect input! Please enter 'y' or 'n'.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            List<Radio> favradio = new List<Radio>();

            UserDTO newUser = new UserDTO(name, surname, birthday, username, password, _isArtist);
            utente1.Name = name;
            utente1.Surname = surname;
            utente1.Birthday = birthday;
            utente1.UserName = username;
            utente1.Password = password;
            utente1.IsArtist = _isArtist;
            utente1.Language = language;

            database.Register(utente1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Now you are registered {username}!");
        }

        public void LoginUser(UserDTO user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert username:");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert password:");
            Console.ForegroundColor = ConsoleColor.White;
            string password = Console.ReadLine();

            database.Login(username, password, user);

            if (user.IsLogged)
            {
                
              
                Console.ForegroundColor = ConsoleColor.White;
                ReadOnlyCollection<TimeZoneInfo> TimeZoneList = TimeZoneInfo.GetSystemTimeZones();
                int i = 0;
                foreach (TimeZoneInfo t in TimeZoneList)
                {
                    i++;
                    Console.WriteLine($"{i}- Id: {t.Id}, Nome: {t.DisplayName}");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter the number of the region you are logging in from:");
                Console.ForegroundColor = ConsoleColor.White;

                if (int.TryParse(Console.ReadLine(), out int country) && country >= 1 && country <= TimeZoneList.Count)
                {
                    Console.WriteLine($"You selected {TimeZoneList[country - 1].Id}");
                    var zona = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneList[country - 1].Id);
                    var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, zona);
                    user.LocalDateTime = time;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"This is your local date and time: {user.LocalDateTime}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("Invalid input for the region. Please try again.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
    }
}