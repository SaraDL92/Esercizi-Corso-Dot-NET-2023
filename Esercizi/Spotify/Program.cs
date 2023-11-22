using Spotify.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {   Database database = new Database();
            Artist MichaelJackson  = new("Michael", "Jackson", "29-08-1958", "Michael Jackson","The gratest star of all times!");
            Artist MachineGunKelly= new("Colson", "Baker", "22-04-1990", "Machine Gun Kelly", "Colson Baker (born April 22, 1990), known professionally as Machine Gun Kelly (MGK), is an American rapper, singer, songwriter, musician, and actor. ");
            Artist Yungblud = new("Dominic", "Richard", "05-08-1997", "Yungblud", "Yungblud, pseudonym of Dominic Richard Harrison, is a British singer-songwriter.");
            Album Dangerous = new("Dangerous", "1991", "12", MichaelJackson, null, false);
            Album Century = new("21st Century Liability", "2018", "10", Yungblud, null, false);
            Album Mainstream = new("Mainstream Sellout", "2022", "15", MachineGunKelly, null, false);
            Song healtheworld = new("POP", "Heal The World", 100, "1991", Dangerous, MichaelJackson);
            Song fakelove = new("Punk", "Fake love don't last", 120, "2022", Mainstream, MachineGunKelly);
            Song iloveyou = new("Ballad Rock", "I Love You, Will You Marry Me", 150, "2018", Century, Yungblud);







            database.AddArtistToDB(MichaelJackson);
            database.AddArtistToDB(MachineGunKelly);
            database.AddArtistToDB(Yungblud);
            database.AddAlbumToDB(Dangerous);
            database.AddAlbumToDB(Century); 
            database.AddAlbumToDB(Mainstream);
            database.AddSongsToDB(healtheworld); 
            database.AddSongsToDB(fakelove); 
            database.AddSongsToDB(iloveyou);














            ConsoleColor originalColor= Console.ForegroundColor;
           
            Console.ForegroundColor= ConsoleColor.Green;
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

                    database.Register(name, surname, birthday, playlist, username, password, favsongs, artist, favradio);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Now you are registered" +" "+ username+ "!");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login now!");
                    Console.ForegroundColor = originalColor;
                    Console.WriteLine("Insert username:");
                    string u = Console.ReadLine();
                    Console.WriteLine("Insert password:");
                    string p = Console.ReadLine();
                    database.Login(u, p);
                    if (database.Islogged==true) { islogged = true; } else { islogged = false; }


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
                    if (artist == true) { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Enter A for Artists, AL for Albums,S for Songs, PL for Playlists,C for Create (avaiable only because you are an artist):");
                    
                    string input=Console.ReadLine();
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
                        if((input == "S" || input == "s"))
                        {
                            Console.ForegroundColor = originalColor;
                            Console.WriteLine("This is the list of songs:");
                            database.ShowMeSongs();
                        }

                    } 
                    else { Console.ForegroundColor = ConsoleColor.Magenta; Console.WriteLine("Enter A for Artists, AL for Albums, PL for Playlists:"); }
                   
                   
                    
                }
                else if (inputText == "p" || inputText == "P")
                {
                    Console.WriteLine("You are in PROFILE now");
                }
                else { Console.WriteLine($"You entered {inputText} that is invalid!Retry!"); }
                
                
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
    
