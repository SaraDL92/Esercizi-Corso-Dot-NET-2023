﻿using SpotifyClone.Entities;
using SpotifyClone.Services.Spotify.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Services
{
    public class UserProfileManager
    {
        private User utente1;

        public UserProfileManager(User user)
        {
            utente1 = user;
        }

        public void ManageProfile(User user1, Database database, Artist convertedArtist)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You are in PROFILE now");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Enter THEME for set profile theme, E for set Equalizer, P for your Subscription, D for dispositives, push another letter to esc");
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
                    mediaService.ManageMusic(utente1, convertedArtist, database, out esciDaMediaService);

                    if (!esciDaMediaService)
                    {

                        UserProfileManager profileManager = new UserProfileManager(utente1);


                        profileManager.ManageProfile(utente1, database, convertedArtist);
                    }
                }
                else if (mainMenuChoice.ToUpper() == "P")
                {
                    UserProfileManager profileManager = new UserProfileManager(utente1);


                    profileManager.ManageProfile(utente1, database, convertedArtist);
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
                else
                {
                    Console.WriteLine("YOU ARE A BASIC USER");
                }

                bool cha = true;

                while (cha)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Choose your subscription: for Premium enter PR, for Normal User enter N, to esc push another letter");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input2 = Console.ReadLine();

                    switch (input2.ToUpper())
                    {
                        case "PR":
                            utente1.IsPremium = true;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You are premium now!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;

                        case "N":
                            utente1.IsPremium = false;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("You are a basic user now!");
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