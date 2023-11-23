using Spotify.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace Spotify
{
    internal class Program
    {private static ManualResetEventSlim pauseEvent = new ManualResetEventSlim(true);
        static void Main(string[] args)
        { Database database = new Database(); User utente1 = new("", "", "");
          MediaComponent mediaplayer=new MediaComponent();
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
            PlayList playlist1 = new(user2,"heartstone");
           
            database.Playlists.Add(playlist1);






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
                    Console.WriteLine("Insert name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Insert surname:");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Insert birthday:");
                    string birthday = Console.ReadLine();
                    List<PlayList> playlist = new List<PlayList>();
                    Console.WriteLine("Insert username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Insert password:");
                    string password = Console.ReadLine();
                    List<Song> favsongs = new List<Song>();




                    while (true)
                    {
                        Console.WriteLine("Are you an artist? Y|N");
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
                            Console.WriteLine("Incorrect input! Please enter 'y' or 'n'.");
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
                    Console.WriteLine("Insert username:");
                    string u = Console.ReadLine();
                    Console.WriteLine("Insert password:");
                    string p = Console.ReadLine();
                    database.Login(u, p);
                    if (database.Islogged == true) { islogged = true; } else { islogged = false; }


                }
                else if (input1 == "l" || input1 == "L")
                {

                    Console.WriteLine("Insert username:");
                    string username1 = Console.ReadLine();
                    Console.WriteLine("Insert password:");
                    string psw = Console.ReadLine();
                    database.Login(username1, psw);
                    if (database.Islogged == true) { islogged = true; } else { islogged = false; }


                }
                else
                {
                    Console.WriteLine("Invalid input. Retry!");
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
                    if (artist == true) {
                        Console.WriteLine("So you are an artist, before to go on give me your artist name:");
                        string artistname = Console.ReadLine();
                        Console.WriteLine("And now enter your bio");
                        string bio = Console.ReadLine();

                        convertedArtist.ArtistName
                            = artistname;
                        convertedArtist.Bio = bio;
                        
                        Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Enter A for Artists, AL for Albums,S for Songs, PL for Playlists,C for Create (avaiable only because you are an artist):");

                        string input = Console.ReadLine();
                        if (input == "a" || input == "A")
                        {
                            Console.ForegroundColor = originalColor;
                            Console.WriteLine("This is the list of artists:");
                            database.ShowMeArtists();
                        }
                        if (input == "al" || input == "AL")
                        {
                            Console.ForegroundColor = originalColor;
                            Console.WriteLine("This is the list of albums:");
                            database.ShowMeAlbums();
                        }
                        if ((input == "S" || input == "s"))
                        {
                            Console.ForegroundColor = originalColor;
                            Console.WriteLine("This is the list of songs:");
                            database.ShowMeSongs();
                            Console.WriteLine("If you want to play a song enter the number linked on it?");
                            string inputNumber = Console.ReadLine();

                            // Verifica se l'input è un numero valido
                            if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Songs.Count)
                            {
                                
                               
                                mediaplayer.Play(database.Songs, number);
                                
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a valid number.");
                            }
                           
                            


                        }
                        if (input == "PL" || input == "pl")
                        {
                            Console.ForegroundColor = originalColor;
                            Console.WriteLine("This is the general list of playlists:");
                            database.ShowMePlaylists();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("If you want to create your playlist enter PP, if you want to see only your personal playlists enter MY?");
                            Console.ForegroundColor = originalColor;
                            input = Console.ReadLine();

                            if (input == "pp" || input == "PP")
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("Enter the NAME you want for your playlist!");
                                Console.ForegroundColor = originalColor;
                                string inputt = Console.ReadLine();
                                PlayList playlist = new(utente1, inputt);
                                database.AddPlaylistsToDB(playlist);
                                if(playlist != null) {utente1.PlayLists.Add(playlist); } else { Console.WriteLine("nessuna playlist");}
                                

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Your playlist named {inputt} is now in your playlists! ");

                                Console.ForegroundColor = originalColor;
                                utente1.ShowAllThePlaylists();
                            }
                            if (input == "MY" || input == "my")
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("This is your list of playlists:");
                                Console.ForegroundColor = originalColor;
                                utente1.ShowAllThePlaylists();
                            }
                        }
                        if (input == "C" || input == "c")
                        {
                            Console.WriteLine("Create song");
                          
                           
                            Console.WriteLine("If you want to create a Song enter SONG, if you want to create an Album enter ALBUM,if you want to see your CREATED SONGS enter SEE");
                            string input10=Console.ReadLine();
                            if (input10 == "song" || input10 == "SONG") {

                                Console.WriteLine("Enter the genre:");
                                string genre=Console.ReadLine();
                                Console.WriteLine("Enter the title:");
                                string title = Console.ReadLine();
                                Console.WriteLine("Enter the duration:");
                                int duration = Console.Read();
                                Console.WriteLine("Enter the release date:");
                                string releaseDate = Console.ReadLine();

                                convertedArtist.CreateNewSong(genre, title,duration, releaseDate);
                                Console.WriteLine($"{title}was created with success! ");
                               

                            }if(input10=="see"||input10=="SEE")
                            {
                                convertedArtist.ShowMeSongList();
                            }

                                
                            




                           
                        }
                    }
                    }

                



            

                
                else { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Enter A for Artists, AL for Albums, PL for Playlists:"); } 
                   
                   
                    
                
                if (inputText == "p" || inputText == "P")
                {
                    Console.WriteLine("You are in PROFILE now");
                }
                else { Console.WriteLine($""); }
                
                
                }  
            }
         
        }

          
            //Console.WriteLine(MichaelJackson);
            
            //MichaelJackson.CreateNewSong("Pop", "Heal the World", 110, "01-10-1991", null);
            //MichaelJackson.CreateNewSong("Pop", "Dangerous", 120, "01-10-1991", null);
            //MediaComponent mediacomponent = new();
            
            //MichaelJackson.ShowMeSongList();
            //mediacomponent.play(MichaelJackson.Songs[0]);

            
        }
    
