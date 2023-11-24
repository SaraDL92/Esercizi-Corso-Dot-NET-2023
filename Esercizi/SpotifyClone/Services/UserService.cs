using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Services
{
    public class UserService
    {
        private Database database;
        bool _isArtist = false;

        public UserService(Database database)
        {
            this.database = database;
        }

        public void RegisterUser(User utente1)
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

            User newUser = new User(name, surname, birthday, username, password, _isArtist);
            utente1.Name = name;
            utente1.Surname = surname;
            utente1.Birthday = birthday;
            utente1.UserName = username;
            utente1.Password = password;
            utente1.IsArtist = _isArtist;
           
            database.Register(utente1);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Now you are registered {username}!");
        }

        public void LoginUser(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert username:");
            Console.ForegroundColor = ConsoleColor.White;
            string username = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Insert password:");
            Console.ForegroundColor = ConsoleColor.White;
            string password = Console.ReadLine();

            database.Login(username, password,user);

            if (database.Islogged)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Welcome back, {username}!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Invalid username or password. Please try again.");
            }
        }
    }
}