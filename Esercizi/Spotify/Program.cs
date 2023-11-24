﻿using Spotify.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace Spotify
{
    internal class Program
    {
        private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        static void Main(string[] args)
        {
            Database database = new Database(); User utente1 = new("", "", "");
            MediaComponent mediaplayer = new MediaComponent();
            Artist MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson", "The gratest star of all times!");
            Artist MachineGunKelly = new("Colson", "Baker", "22-04-1990", "Machine Gun Kelly", "Colson Baker (born April 22, 1990), known professionally as Machine Gun Kelly (MGK), is an American rapper, singer, songwriter, musician, and actor. ");
            Artist Yungblud = new("Dominic", "Richard", "05-08-1997", "Yungblud", "Yungblud, pseudonym of Dominic Richard Harrison, is a British singer-songwriter.");
            Album Dangerous = new("Dangerous", "1991", "12", MichaelJackson, null, false);
            Album Century = new("21st Century Liability", "2018", "10", Yungblud, null, false);
            Album Mainstream = new("Mainstream Sellout", "2022", "15", MachineGunKelly, null, false);
            Song healtheworld = new("POP", "Heal The World", 100, "1991", Dangerous, MichaelJackson);
            Song fakelove = new("Punk", "Fake love don't last", 120, "2022", Mainstream, MachineGunKelly);
            Song iloveyou = new("Ballad Rock", "I Love You, Will You Marry Me", 150, "2018", Century, Yungblud);
            User user2 = new("Selene", "Rubius", "12-05-1990");
            PlayList playlist1 = new(user2, "heartstone");
            Dangerous.TrackList.Add(healtheworld);
            Century.TrackList.Add(iloveyou);
            Mainstream.TrackList.Add(fakelove);
            MichaelJackson.Albums.Add(Dangerous);
            MachineGunKelly.Albums.Add(Mainstream);
            Yungblud.Albums.Add(Century);

            database.Playlists.Add(playlist1);
            playlist1.Songs.Add(healtheworld);
            playlist1.Songs.Add(fakelove);






            database.AddArtistToDB(MichaelJackson);
            database.AddArtistToDB(MachineGunKelly);
            database.AddArtistToDB(Yungblud);
            database.AddAlbumToDB(Dangerous);
            database.AddAlbumToDB(Century);
            database.AddAlbumToDB(Mainstream);
            database.AddSongsToDB(healtheworld);
            database.AddSongsToDB(fakelove);
            database.AddSongsToDB(iloveyou);
            Artist convertedArtist = ConvertToArtist(utente1, "", "");


            static Artist ConvertToArtist(User user, string artistname, string bio)
            {

                return new Artist(user.Name, user.Surname, user.Birthday, artistname, "NuovaInfoArtista");
            }











            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to Spotify!");
            Console.ForegroundColor = originalColor;
            bool artist = false;
            bool islogged = false;


            while (islogged == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter R for Register or L for Login:");
                Console.ForegroundColor = originalColor;
                string input1 = Console.ReadLine();
                if (input1 == "r" || input1 == "R")
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
                    List<PlayList> playlist = new List<PlayList>(); 
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("Insert username:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string username = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Insert password:"); 
                    Console.ForegroundColor = ConsoleColor.White;
                    string password = Console.ReadLine();
                    List<Song> favsongs = new List<Song>();




                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("Are you an artist? Y|N");
                        Console.ForegroundColor = ConsoleColor.White;
                        string isartist = Console.ReadLine();

                        if (isartist == "y" || isartist == "Y")
                        {
                            artist = true;
                            break;
                        }
                        else if (isartist == "n" || isartist == "N")
                        {
                            artist = false;
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Incorrect input! Please enter 'y' or 'n'."); 
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }


                    List<Radio> favradio = new();


                    utente1.Name = name;
                    utente1.Surname = surname;
                    utente1.Birthday = birthday;
                    utente1.UserName = username;
                    utente1.Password = password;
                    utente1.IsArtist = artist;
                    database.Register(utente1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Now you are registered" + " " + username + "!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login now!");
                    Console.ForegroundColor = originalColor;
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine("Insert username:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string u = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Insert password:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string p = Console.ReadLine();
                    database.Login(u, p);
                    if (database.Islogged == true) { islogged = true; } else { islogged = false; }


                }
                else if (input1 == "l" || input1 == "L")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Insert username:"); Console.ForegroundColor = ConsoleColor.White;
                    string username1 = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Insert password:"); 
                    Console.ForegroundColor = ConsoleColor.White;
                    string psw = Console.ReadLine();
                    database.Login(username1, psw);
                    if (database.Islogged == true) { islogged = true; } else { islogged = false; }


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Retry!"); 
                    Console.ForegroundColor = ConsoleColor.White;
                   
                    islogged = false;

                }
            }

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter M for Music and P for Profile:");
                Console.ForegroundColor = originalColor;
                string inputText = Console.ReadLine();

                if (inputText == "m" || inputText == "M")
                {

                    Console.ForegroundColor = ConsoleColor.Magenta; 
                    Console.WriteLine("Enter A for Artists, AL for Albums, S for Songs, PL for Playlists, C for Create (available only because you are an artist):");
                    Console.ForegroundColor = ConsoleColor.White;

                    string input = Console.ReadLine();
                    if (input.Equals("a", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is the list of artists:"); Console.ForegroundColor = ConsoleColor.White;
                        database.ShowMeArtists(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to select an artist, enter the number linked to it:"); Console.ForegroundColor = ConsoleColor.White;

                        string inputNumber = Console.ReadLine();

                        if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Artists.Count)
                        {
                            Artist selectedArtist = database.Artists[number - 1];
                            database.ShowMeOneArtist(selectedArtist);
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("If you want to select an album, enter the number linked to it:");
                            Console.ForegroundColor = ConsoleColor.White;
                            string inputNumber1 = Console.ReadLine();

                            if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= selectedArtist.Albums.Count)
                            {
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("If you want to play the album, enter PLAY:");
                                Console.ForegroundColor = ConsoleColor.White;
                                string inn = Console.ReadLine();

                                if (inn.Equals("play", StringComparison.OrdinalIgnoreCase))
                                {
                                    Console.ForegroundColor = ConsoleColor.Green; 
                                    Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    mediaplayer.Play(selectedArtist.Albums[number1 - 1].TrackList, 0);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("Invalid input. Please enter a valid number.");Console.ForegroundColor = ConsoleColor.White;
                        }
                    }


                    else if (input == "al" || input == "AL")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is the list of albums:"); Console.ForegroundColor = ConsoleColor.White;
                        database.ShowMeAlbums();
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("If you want to select an album, enter the number linked to it:"); Console.ForegroundColor = ConsoleColor.White;

                        string inputNumber = Console.ReadLine();

                        if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Albums.Count)
                        {
                            database.ShowMeOneAlbum(database.Albums[number - 1]); Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("If you want to play a song, select the number linked to it:"); Console.ForegroundColor = ConsoleColor.White;
                            string inputNumber1 = Console.ReadLine();

                            if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Albums[number - 1].TrackList.Count)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next"); Console.ForegroundColor = ConsoleColor.White;
                                mediaplayer.Play(database.Albums[number - 1].TrackList, number1 - 1);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("Invalid input. Please enter a valid number.");Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Invalid input. Please enter a valid number."); Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    else if ((input == "S" || input == "s"))
                    {
                        Console.ForegroundColor = originalColor; Console.ForegroundColor = ConsoleColor.Green; 
                        Console.WriteLine("This is the list of songs:");Console.ForegroundColor = ConsoleColor.White;
                        database.ShowMeSongs(); Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to play a song, enter the number linked to it?"); Console.ForegroundColor = ConsoleColor.White;
                        string inputNumber = Console.ReadLine();

                        if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Songs.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");Console.ForegroundColor = ConsoleColor.White;
                            mediaplayer.Play(database.Songs, number - 1);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Invalid input. Please enter a valid number."); Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    else if (input == "PL" || input == "pl")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is the general list of playlists:"); Console.ForegroundColor = ConsoleColor.White;
                        database.ShowMePlaylists();
                        Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine("If you want to select a playlist, enter the number linked to it, if you want to go in your personal playlist enter a letter:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string inputNumber = Console.ReadLine();

                        if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Playlists.Count)
                        {
                            database.ShowMeOnePlaylist(database.Playlists[number - 1]);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("If you want to play a song, select the number linked to it:"); Console.ForegroundColor = ConsoleColor.White;
                            string inputNumber1 = Console.ReadLine();

                            if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Playlists[number - 1].Songs.Count)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next"); Console.ForegroundColor = ConsoleColor.White;
                                mediaplayer.Play(database.Playlists[number - 1].Songs, number1 - 1);
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Invalid input. Please enter a valid number."); Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {

                            Console.WriteLine(""); Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to create your playlist, enter PP. If you want to see only your personal playlists, enter MY?"); Console.ForegroundColor = ConsoleColor.White;
                        Console.ForegroundColor = originalColor;
                        input = Console.ReadLine();

                        if (input == "pp" || input == "PP")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Enter the NAME you want for your playlist!");
                            Console.ForegroundColor = originalColor;
                            string inputt = Console.ReadLine();
                            PlayList playlist = new PlayList(utente1, inputt);
                            database.AddPlaylistsToDB(playlist);
                            if (playlist != null) { utente1.PlayLists.Add(playlist); } else { Console.WriteLine("No playlist created."); }

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your playlist named {inputt} is now in your playlists! ");
                            Console.ForegroundColor = originalColor;
                            utente1.ShowAllThePlaylists();
                        }

                        else if (input == "MY" || input == "my")
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("This is your list of playlists:");
                            Console.ForegroundColor = originalColor;
                            utente1.ShowAllThePlaylists();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("If you want to select a playlist, enter the number linked to it:");
                            Console.ForegroundColor = ConsoleColor.White;
                            string inputNumbers = Console.ReadLine();

                            if (int.TryParse(inputNumbers, out int numbers) && numbers > 0 && numbers <= utente1.PlayLists.Count)
                            {
                                utente1.ShowMeOnePlaylist(utente1.PlayLists[numbers - 1]);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("If you want to play a song, select the number linked to it or if you want to add a song, enter ADD:"); Console.ForegroundColor = ConsoleColor.White;
                                string inputNumber1 = Console.ReadLine();

                                if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= utente1.PlayList[number1 - 1].Songs.Count)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next"); Console.ForegroundColor = ConsoleColor.White;
                                    mediaplayer.Play(utente1.PlayList[numbers - 1].Songs, number1 - 1);
                                }
                                if (inputNumber1 == "add" || inputNumber1 == "ADD")
                                {
                                    database.ShowMeSongs(); Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Enter the number you want to add to your playlist!"); Console.ForegroundColor = ConsoleColor.White;
                                    if (int.TryParse(Console.ReadLine(), out int songIndex) && songIndex > 0 && songIndex <= database.Songs.Count)
                                    {
                                        utente1.AddSongToPlaylist(database.Songs[songIndex - 1], utente1.PlayLists[numbers - 1]);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Song added to the playlist!"); Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Invalid input. Please enter a valid number for the song."); Console.ForegroundColor = ConsoleColor.White;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Invalid input. Please enter a valid number."); Console.ForegroundColor = ConsoleColor.White;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Invalid input. Please enter a valid number."); Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                    }

                    else if (input == "C" || input == "c")
                    {
                        if (artist)
                        {

                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("So you are an artist, before going on, give me your artist name:");Console.ForegroundColor = ConsoleColor.White;
                            string artistname = Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("And now enter your bio");Console.ForegroundColor = ConsoleColor.White;
                            string bio = Console.ReadLine();


                            convertedArtist.ArtistName = artistname;
                            convertedArtist.Bio = bio;

                            Console.ForegroundColor = ConsoleColor.Green; 
                            Console.WriteLine("Create song");Console.ForegroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("If you want to create a Song, enter SONG. If you want to see your CREATED SONGS, enter SEE"); Console.ForegroundColor = ConsoleColor.White;
                            string input10 = Console.ReadLine();

                            if (input10 == "song" || input10 == "SONG")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter the genre:"); 
                                Console.ForegroundColor = ConsoleColor.White;
                                string genre = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("Enter the title:");Console.ForegroundColor = ConsoleColor.White;
                                string title = Console.ReadLine(); Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("Enter the duration:");Console.ForegroundColor = ConsoleColor.White;
                                int duration = Console.Read(); Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Enter the release date:"); Console.ForegroundColor = ConsoleColor.White;
                                string releaseDate = Console.ReadLine();

                                convertedArtist.CreateNewSong(genre, title, duration, releaseDate);
                                foreach (Song s in convertedArtist.Songs)
                                {
                                    database.Songs.Add(s);
                                }
                                Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"{title} was created successfully! "); Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (input10 == "see" || input10 == "SEE")
                            {
                                convertedArtist.ShowMeSongList();
                            }
                        }
                        else { Console.ForegroundColor = ConsoleColor.Green;  Console.WriteLine("Only artists can create!");Console.ForegroundColor = ConsoleColor.White; }
                    }
                }


                if (inputText == "p" || inputText == "P")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You are in PROFILE now");
                    Console.ForegroundColor = ConsoleColor.White;

                    Setting setting = new();
                    bool enter = true;

                    while (enter == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter THEME for set profile theme, E for set Equalizer, P for your Subscription, D for dispositives, push another letter to esc");
                        Console.ForegroundColor = ConsoleColor.White;

                        string input = Console.ReadLine();

                        if (input == "THEME" || input == "theme")
                        {
                            setting.SetTheme();
                        }
                        else if (input == "E" || input == "e")
                        {
                            setting.SetEqualizer();
                        }
                        else if (input == "P" || input == "p")
                        {

                            if (utente1.IsPremium == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green; 
                                Console.WriteLine("YOU ARE A PREMIUM USER");Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("YOU ARE A BASIC USER"); Console.ForegroundColor = ConsoleColor.White;
                            }

                            bool cha = true;

                            while (cha == true)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Choose your subscription: for Premium enter PR, for Normal User enter N, to esc push another letter"); Console.ForegroundColor = ConsoleColor.White;
                                string input2 = Console.ReadLine();

                                if (input2 == "PR" || input2 == "pr")
                                {
                                    utente1.IsPremium = true; Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("You are premium now!"); Console.ForegroundColor = ConsoleColor.White;
                                }
                                else if (input2 == "n" || input2 == "N")
                                {
                                    utente1.IsPremium = false; Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("You are a basic user now!"); Console.ForegroundColor = ConsoleColor.White;
                                }
                                else
                                {
                                    cha = false;
                                    break;
                                }
                            }
                        }
                        else if (input == "D" || input == "d")
                        {
                            setting.SetDispositives();


                        }
                        else
                        {
                            enter = false;
                            break;
                        }
                    }
                }




            }
        }
    }
}




