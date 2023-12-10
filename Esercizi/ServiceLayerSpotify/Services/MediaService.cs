using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerSpotify.DB;
using DataLayerSpotify.DTO;

namespace SpotifyClone.Services
{
  
    
        public class MediaService
        {
            private Database database;
           
            private MediaComponent mediaplayer;

            public Database Database { get => database; set => database = value; }
          
            public MediaComponent Mediaplayer { get => mediaplayer; set => mediaplayer = value; }

            public MediaService(Database db, MediaComponent player)
            {
                database = db;
                mediaplayer = player;
            }

            public void ManageMusic(UserDTO user1,ArtistDTO artist, Database database, out bool esci,Writers writer)
            {
                esci = false;

                while (!esci)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter M for Music, V for Videos and P for Profile:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputText = Console.ReadLine();

                    if (inputText == "v" || inputText == "V")
                    {
                        database.ShowMeMovies();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter the number to play the movie:"); 
                        Console.ForegroundColor = ConsoleColor.White;
                        string input= Console.ReadLine();
                        if (int.TryParse(input, out int number) && number > 0 && number <= database.Movies.Count) {
                            mediaplayer.Play(database.Movies, number - 1, writer, user1);
                            
                            }
                        else {
                            Console.WriteLine("invalid input!");
                               };
                       

                    }

                    if (inputText == "m" || inputText == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter A for Artists, AL for Albums, S for Songs, PL for Playlists, R for radio, TOP for TOP 5, C for Create (available only because you are an artist):");
                        Console.ForegroundColor = ConsoleColor.White;

                        string input = Console.ReadLine();

                        if (input.Equals("a", StringComparison.OrdinalIgnoreCase))
                        {
                            ManageArtists(database,writer,user1);
                        }
                        else if (input == "al" || input == "AL")
                        {
                            ManageAlbums(writer,user1);
                        }
                        else if (input.Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            ManageSongs(writer, user1);
                        }
                        else if (input == "PL" || input == "pl")
                        {
                            ManagePlaylists(user1, writer);
                        }
                        else if (input == "R" || input == "r")
                        {
                            ManageRadio(database,user1,writer);
                        }
                        else if (input=="TOP"||input=="top")
                        {
                            ManageTop5();
                        }
                        else if (input == "C" || input == "c")
                        {
                            CreateContent(artist);
                        }
                    }
                   else if (inputText == "p" || inputText == "P")
                    {
                        esci = true; 
                        UserProfileManager profileManager = new UserProfileManager(user1);
                        profileManager.ManageProfile(user1,database,artist,writer); 
                    }
                }
            } 
            private void ManageTop5()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Enter the number to see the top 5 ranking, if you want to esc enter something else :");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("1. ALBUM");
                Console.WriteLine("2. SONGS");
                Console.WriteLine("3. ARTISTS");
                Console.WriteLine("4. PLAYLISTS");
                Console.WriteLine("5. RADIOS");
                Console.ForegroundColor = ConsoleColor.White;
                string input=Console.ReadLine();
                if (input == "1")
                {
                    database.ShowMeTop5Albums();

                }
                if(input== "2")
                {
                    database.ShowMeTop5Songs();
                }
                if(input == "3")
                {
                    database.ShowMeTop5Artists();
                }
                if (input == "4")
                {
                    database.ShowMeTop5Playlists();
                }
                if (input == "5")
                {
                    database.ShowMeTop5Radios();
                }
            }
            private void ManageRadio(Database database,UserDTO user,Writers writer)
            {   Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("This is the list of radios, enter the number linked to the radio you want to play or something else to esc:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMeRadioList();
                string input= Console.ReadLine();
                if(int.TryParse(input, out int numb)&& numb < database.Radiolist.Count && numb>0)
                {
                    database.ShowMeOneTracklistRadio(database.Radiolist[numb-1]);
                    Console.ForegroundColor=ConsoleColor.Green;
                    Console.WriteLine("Enter PLAY to play the Radio or something else to esc:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inn=Console.ReadLine();
                    if (inn == "play" || inn == "PLAY")
                    {Random numran=new Random();
                        database.Radiolist[numb - 1].Rating = database.Radiolist[numb - 1].Rating + 1;
                        int numbah = numran.Next(0, database.Radiolist[numb - 1].Songlist.Count);
                        mediaplayer.Play(database.Radiolist[numb - 1].Songlist, numbah,writer, user);

                    }

                }
                else { Console.WriteLine("no list"); }



            }
            private void ManageArtists(Database database,Writers writer, UserDTO user)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is the list of artists:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMeArtists();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to select an artist, enter the number linked to it, for esc enter a letter:");
                Console.ForegroundColor = ConsoleColor.White;
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Artists.Count)
                {
                    Artist selectedArtist = database.Artists[number - 1];
                    database.ShowMeOneArtist(selectedArtist);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("If you want to select an album, enter the number linked to it, for esc enter a letter:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputNumber1 = Console.ReadLine();

                    if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= selectedArtist.Albums.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to play the album, enter PLAY, for esc enter a letter:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string inn = Console.ReadLine();

                        if (inn.Equals("play", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                            Console.ForegroundColor = ConsoleColor.White;
                            mediaplayer.Play(selectedArtist.Albums[number1 - 1].TrackList, 0, writer,user);
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
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            private void ManageAlbums(Writers writer,User user)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is the list of albums:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMeAlbums();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to select an album, enter the number linked to it, for esc enter a letter:");
                Console.ForegroundColor = ConsoleColor.White;
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Albums.Count)
                {
                    database.ShowMeOneAlbum(database.Albums[number - 1]);

                    Console.ForegroundColor = ConsoleColor.Green;
                    if (user.IsFree && user.SessionDuration.TotalSeconds > 360000)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You are a free user and you have reached the limit of 100 hours of listening, you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string input = Console.ReadLine();
                        if (input == "play" || input == "PLAY")
                        {
                            Random random = new Random();


                            int numeroCasuale = random.Next(0, database.Albums[number-1].TrackList.Count);

                            mediaplayer.Play(database.Albums[number - 1].TrackList, numeroCasuale, writer, user);

                        }

                    }
                    else if (user.IsPremium && user.SessionDuration.TotalSeconds > 3600000)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You are a premium user and you have reached the limit of 1000 hours of listening,  you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string input = Console.ReadLine();
                        if (input == "play" || input == "PLAY")
                        {
                            Random random = new Random();


                            int numeroCasuale = random.Next(0, database.Albums[number - 1].TrackList.Count);

                            mediaplayer.Play(database.Albums[number - 1].TrackList, numeroCasuale, writer, user);
                        }

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("If you want to play a song, select the number linked to it, for esc enter a letter:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string inputNumber1 = Console.ReadLine();

                        if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Albums[number - 1].TrackList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                            Console.ForegroundColor = ConsoleColor.White;
                            mediaplayer.Play(database.Albums[number - 1].TrackList, number1 - 1, writer, user);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


            private void ManageSongs(Writers writer,User user)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is the list of songs:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMeSongs();
                if (user.IsFree && user.SessionDuration.TotalSeconds > 360000)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You are a free user and you have reached the limit of 100 hours of listening, you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input= Console.ReadLine();
                    if (input =="play"||input=="PLAY")
                    {
                        Random random = new Random();

                       
                        int numeroCasuale = random.Next(0,database.Songs.Count);

                        mediaplayer.Play(database.Songs,numeroCasuale, writer, user);
                        
                    }
                   
                }
               else if (user.IsPremium && user.SessionDuration.TotalSeconds > 3600000)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("You are a premium user and you have reached the limit of 1000 hours of listening,  you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input = Console.ReadLine();
                    if (input == "play" || input == "PLAY")
                    {
                        Random random = new Random();


                        int numeroCasuale = random.Next(0, database.Songs.Count);

                        mediaplayer.Play(database.Songs, numeroCasuale, writer, user);
                    }
                   
                }
                else  { 
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to play a song, enter the number linked to it, for esc enter a letter");
                Console.ForegroundColor = ConsoleColor.White;
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Songs.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                    Console.ForegroundColor = ConsoleColor.White;
                    mediaplayer.Play(database.Songs, number - 1,writer,user);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }}


            private void ManagePlaylists(User utente1,Writers writer)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is the general list of playlists:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMePlaylists();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to select a playlist, enter the number linked to it, if you want to go in your personal playlist enter a letter:");
                Console.ForegroundColor = ConsoleColor.White;
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Playlists.Count)
                {
                    database.ShowMeOnePlaylist(database.Playlists[number - 1]);


                    if (utente1.IsFree && utente1.SessionDuration.TotalSeconds > 360000)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You are a free user and you have reached the limit of 100 hours of listening, you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string input1 = Console.ReadLine();
                        if (input1 == "play" || input1 == "PLAY")
                        {
                            Random random = new Random();


                            int numeroCasuale = random.Next(0, database.Playlists[number - 1].Songs.Count);
                            database.Playlists[number - 1].Rating = database.Playlists[number - 1].Rating + 1;

                            mediaplayer.Play(database.Playlists[number - 1].Songs, numeroCasuale, writer, utente1);

                        }

                    }
                    else if (utente1.IsPremium && utente1.SessionDuration.TotalSeconds > 3600000)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("You are a premium user and you have reached the limit of 1000 hours of listening,  you can no longer choose the songs to play, enter PLAY to play a random song or something else to esc:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string input1 = Console.ReadLine();
                        if (input1 == "play" || input1 == "PLAY")
                        {
                            Random random = new Random();

                            database.Playlists[number - 1].Rating = database.Playlists[number - 1].Rating + 1;


                            int numeroCasuale = random.Next(0, database.Playlists[number - 1].Songs.Count);

                            mediaplayer.Play(database.Playlists[number - 1].Songs, numeroCasuale, writer, utente1);
                        }

                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to play a song, select the number linked to it,for esc enter a letter:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string inputNumber1 = Console.ReadLine();

                        if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Playlists[number - 1].Songs.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                            Console.ForegroundColor = ConsoleColor.White;
                            mediaplayer.Play(database.Playlists[number - 1].Songs, number1 - 1, writer, utente1); database.Playlists[number - 1].Rating = database.Playlists[number - 1].Rating + 1;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to create your playlist, enter PP. If you want to see only your personal playlists, enter MY,for esc enter something else");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.White;
                string input = Console.ReadLine();

                if (input == "pp" || input == "PP")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Enter the NAME you want for your playlist!");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputt = Console.ReadLine();
                    PlayList playlist = new PlayList(utente1, inputt);
                    database.AddPlaylistsToDB(playlist);

                    if (playlist != null)
                    {
                        utente1.PlayLists.Add(playlist);
                    }
                    else
                    {
                        Console.WriteLine("No playlist created.");
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your playlist named {inputt} is now in your playlists! ");
                    Console.ForegroundColor = ConsoleColor.White;
                    utente1.ShowAllThePlaylists();
                }
                else if (input == "MY" || input == "my")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("This is your list of playlists:");
                    Console.ForegroundColor = ConsoleColor.White;
                    utente1.ShowAllThePlaylists();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("If you want to select a playlist, enter the number linked to it,for esc enter a letter:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputNumbers = Console.ReadLine();

                    if (int.TryParse(inputNumbers, out int numbers) && numbers > 0 && numbers <= utente1.PlayLists.Count)
                    {
                        utente1.ShowMeOnePlaylist(utente1.PlayLists[numbers - 1]);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to play a song, select the number linked to it or if you want to add a song, enter ADD,for esc enter something else:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string inputNumber1 = Console.ReadLine();

                        if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= utente1.PlayLists[number1 - 1].Songs.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                            Console.ForegroundColor = ConsoleColor.White;
                            mediaplayer.Play(utente1.PlayLists[numbers - 1].Songs, number1 - 1,writer,utente1);
                        }

                        if (inputNumber1 == "add" || inputNumber1 == "ADD")
                        {
                            database.ShowMeSongs();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Enter the number you want to add to your playlist! For esc enter a letter");
                            Console.ForegroundColor = ConsoleColor.White;

                            if (int.TryParse(Console.ReadLine(), out int songIndex) && songIndex > 0 && songIndex <= database.Songs.Count)
                            {
                                utente1.AddSongToPlaylist(database.Songs[songIndex - 1], utente1.PlayLists[numbers - 1]);

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Song added to the playlist!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Invalid input. Please enter a valid number for the song.");
                                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }


            private void CreateContent(Artist convertedArtist)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("So you are an artist, before going on, give me your artist name:");
                Console.ForegroundColor = ConsoleColor.White;
                string artistname = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("And now enter your bio");
                Console.ForegroundColor = ConsoleColor.White;
                string bio = Console.ReadLine();

                convertedArtist.ArtistName = artistname;
                convertedArtist.Bio = bio;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Create content");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("If you want to create a Song, enter SONG. If you want to see your CREATED SONGS, enter SEE, for esc enter something else");
                Console.ForegroundColor = ConsoleColor.White;
                string input10 = Console.ReadLine();

                if (input10.Equals("song", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the genre:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string genre = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the title:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string title = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the duration:");
                    Console.ForegroundColor = ConsoleColor.White;
                    if (int.TryParse(Console.ReadLine(), out int duration))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter the release date:");
                        Console.ForegroundColor = ConsoleColor.White;
                        string releaseDate = Console.ReadLine();

                        convertedArtist.CreateNewSong(genre, title, duration, releaseDate);

                        foreach (Media s in convertedArtist.Songs)
                        {
                            database.Songs.Add(s);
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{title} was created successfully!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Invalid input. Please enter a valid number for the duration.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (input10.Equals("see", StringComparison.OrdinalIgnoreCase))
                {
                    convertedArtist.ShowMeSongList();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Please enter 'SONG' or 'SEE'.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

        }
    }
