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
            ConsoleColor originalColor= Console.ForegroundColor;
           
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Welcome to Spotify!");
            Console.ForegroundColor = originalColor;
            Console.WriteLine("Enter R for Register or L for Login:");
            string input1= Console.ReadLine();
            if(input1=="r"||input1 == "R")
            {
                Console.WriteLine("Insert name:");
                string name= Console.ReadLine();
                Console.WriteLine("Insert surname:");
                string surname = Console.ReadLine();
                Console.WriteLine("Insert birthday:");
                string birthday = Console.ReadLine();
                List<PlayList> playlist = new List<PlayList>();
                Console.WriteLine("Insert username:");
                string username = Console.ReadLine();
                Console.WriteLine("Insert password:");
                string password = Console.ReadLine();
                List<Song>favsongs=new List<Song>();
                Console.WriteLine("Are you an artist)")

                database.Register(name,surname,birthday,playlist,username,password,favsongs,);
            }
            
            while (true) { 
            Console.WriteLine("Enter M for Music and P for Profile:");
            string inputText = Console.ReadLine();
                if (inputText == "m" || inputText == "M")
                {
                   
                    Console.WriteLine("Enter A for Artists, AL for Albums, PL for Playlists:");
                   
                    string input2= Console.ReadLine();
                    if(input2 == "A" || input2 == "a")
                    {
                        Console.WriteLine("You are in Artists:");

                    }
                }
                else if (inputText == "p" || inputText == "P")
                {
                    Console.WriteLine("You are in PROFILE now");
                }
                else { Console.WriteLine($"You entered {inputText} that is invalid!Retry!"); }
                
                
                }  
            }
         
        }

            //Artist MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson",null,null,"The gratest star of all times!",null);
           
            //Console.WriteLine(MichaelJackson);
            
            //MichaelJackson.CreateNewSong("Pop", "Heal the World", 110, "01-10-1991", null);
            //MichaelJackson.CreateNewSong("Pop", "Dangerous", 120, "01-10-1991", null);
            //MediaComponent mediacomponent = new();
            
            //MichaelJackson.ShowMeSongList();
            //mediacomponent.play(MichaelJackson.Songs[0]);

            
        }
    
