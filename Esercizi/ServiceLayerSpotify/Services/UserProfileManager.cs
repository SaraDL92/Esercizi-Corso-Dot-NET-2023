using SpotifyClone.Entities;
using SpotifyClone.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerSpotify.DB;

namespace SpotifyClone.Services
{
    public class UserProfileManager
    {
        private User utente1;

        public UserProfileManager(User user)
        {
            utente1 = user;
        }

        public void ManageProfile(User user1, Database database, Artist convertedArtist, Writers writer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You are in PROFILE now");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter THEME for set profile theme, E for set Equalizer, P for your Subscription, D for dispositives, DT for watch your playback session time, push another letter to esc");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "THEME":
                        user1.Setting.SetTheme();
                        break;

                    case "E":
                        user1.Setting.SetEqualizer();
                        break;

                    case "P":
                        ManageSubscription();
                        break;

                    case "D":
                        user1.Setting.SetDispositives();
                        break;

                    case "DT":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You've spent this time playing media:");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(user1.SessionDuration);
                        Console.ForegroundColor=ConsoleColor.White;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                        break;
                }


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter M for Music or P for Profile:");
                Console.ForegroundColor = ConsoleColor.White;

                string mainMenuChoice = Console.ReadLine();

                if (mainMenuChoice.ToUpper() == "M")
                {

                    MediaService mediaService = new MediaService(database, new MediaComponent());


                    bool esciDaMediaService;
                    mediaService.ManageMusic(utente1, convertedArtist, database, out esciDaMediaService, writer);

                    if (!esciDaMediaService)
                    {

                        UserProfileManager profileManager = new UserProfileManager(utente1);


                        profileManager.ManageProfile(utente1, database, convertedArtist, writer);
                    }
                }
                else if (mainMenuChoice.ToUpper() == "P")
                {
                    UserProfileManager profileManager = new UserProfileManager(utente1);


                    profileManager.ManageProfile(utente1, database, convertedArtist, writer);
                }

            }
        }

        private void ManageSubscription()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            if (utente1.IsPremium)
            {
                Console.WriteLine("YOU ARE A PREMIUM USER");
            }
            if (utente1.IsFree == true)
            {
                Console.WriteLine("YOU ARE A FREE USER");
            }
            else
            {
                Console.WriteLine("YOU ARE A GOLD USER");
            }

                bool cha = true;

                while (cha)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Choose your subscription: for Premium enter PR, for Free User enter F, for Gold enter G, to esc push another letter");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input2 = Console.ReadLine();

                    switch (input2.ToUpper())
                    {
                        case "PR":
                            utente1.IsPremium = true;
                            utente1.IsFree = false;
                            utente1.IsGold = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You are PREMIUM user now!You can listen you fav music for 1000 hours.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case "F":
                            utente1.IsPremium = false;
                            utente1.IsFree = true;
                            utente1.IsGold = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You are a FREE user now! You can listen you fav music for 100 hours.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case "G":
                            utente1.IsGold = true;
                            utente1.IsPremium = false;
                            utente1.IsFree = false;
                            utente1.IsPremium = false;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("You are a  GOLD user now!You can listen you fav music for an illimitate time.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        default:
                            cha = false;
                            break;
                    }
                }
            }
        }

    }
