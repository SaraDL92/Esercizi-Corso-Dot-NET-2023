using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Services
{
    namespace Spotify.Services
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

            public void ManageMusic(User user1,Artist artist, Database database, out bool esci,Writers writer)
            {
                esci = false;

                while (!esci)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter M for Music and P for Profile:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputText = Console.ReadLine();

                    if (inputText == "m" || inputText == "M")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Enter A for Artists, AL for Albums, S for Songs, PL for Playlists, C for Create (available only because you are an artist):");
                        Console.ForegroundColor = ConsoleColor.White;

                        string input = Console.ReadLine();

                        if (input.Equals("a", StringComparison.OrdinalIgnoreCase))
                        {
                            ManageArtists(database,writer);
                        }
                        else if (input == "al" || input == "AL")
                        {
                            ManageAlbums(writer);
                        }
                        else if (input.Equals("S", StringComparison.OrdinalIgnoreCase))
                        {
                            ManageSongs(writer);
                        }
                        else if (input == "PL" || input == "pl")
                        {
                            ManagePlaylists(user1, writer);
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
            

            private void ManageArtists(Database database,Writers writer)
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
                            mediaplayer.Play(selectedArtist.Albums[number1 - 1].TrackList, 0, writer);
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


            private void ManageAlbums(Writers writer)
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
                    Console.WriteLine("If you want to play a song, select the number linked to it, for esc enter a letter:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputNumber1 = Console.ReadLine();

                    if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Albums[number - 1].TrackList.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                        Console.ForegroundColor = ConsoleColor.White;
                        mediaplayer.Play(database.Albums[number - 1].TrackList, number1 - 1,writer);
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


            private void ManageSongs(Writers writer)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("This is the list of songs:");
                Console.ForegroundColor = ConsoleColor.White;
                database.ShowMeSongs();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("If you want to play a song, enter the number linked to it, for esc enter a letter");
                Console.ForegroundColor = ConsoleColor.White;
                string inputNumber = Console.ReadLine();

                if (int.TryParse(inputNumber, out int number) && number > 0 && number <= database.Songs.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                    Console.ForegroundColor = ConsoleColor.White;
                    mediaplayer.Play(database.Songs, number - 1,writer);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("If you want to play a song, select the number linked to it,for esc enter a letter:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string inputNumber1 = Console.ReadLine();

                    if (int.TryParse(inputNumber1, out int number1) && number1 > 0 && number1 <= database.Playlists[number - 1].Songs.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enter P pause, T continue, Q stop, B back, N next");
                        Console.ForegroundColor = ConsoleColor.White;
                        mediaplayer.Play(database.Playlists[number - 1].Songs, number1 - 1, writer);
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
                            mediaplayer.Play(utente1.PlayLists[numbers - 1].Songs, number1 - 1,writer);
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

                        foreach (Song s in convertedArtist.Songs)
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
}