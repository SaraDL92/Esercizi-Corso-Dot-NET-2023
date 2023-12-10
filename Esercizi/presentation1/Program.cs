using System;
using System.Collections.Generic;
using System.IO;
using datalayer1.DbContext;
using datalayer1.Models;
using datalayer1.DTO;
using servicelayer1;
using datalayer1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SpotifyClone.Entities;
using System.Threading;
using System.ComponentModel.Design;
using System.Collections;
using System.Threading.Tasks;
using System.Linq;

namespace presentation1
{


    class Program
    {
        static void Main(string[] args)
        {//Initialize
            string filePathSongs = "C:\\Users\\sarad\\Desktop\\songs.csv";
            string filePathMovies = "C:\\Users\\sarad\\Desktop\\video.csv";
            string filePathAlbums = "C:\\Users\\sarad\\Desktop\\albums.csv";
            string filePathArtists = "C:\\Users\\sarad\\Desktop\\artists.csv";
            string filePathPlaylists = "C:\\Users\\sarad\\Desktop\\playlists.csv";

            var serviceProvider = new ServiceCollection()
              .AddSingleton<DB>()  // Registra il database come servizio singleton
              .AddTransient<DbContext>()
              .AddTransient<Repository>()  // Registra la repository come servizio transient
              .AddTransient<Service>()
              // Registra il servizio come servizio transient
              .BuildServiceProvider();

            var Service = serviceProvider.GetService<Service>();
            MediaComponent mediaPlayer = new();



            var DbContext = serviceProvider.GetService<DbContext>();
            var Db = serviceProvider.GetService<DB>();
            //Dates in DB
            ArtistDTO artist = new ArtistDTO("Michael Jackson");
            ArtistDTO artist1 = new ArtistDTO("Eros Ramazzotti");
            ArtistDTO artist2 = new ArtistDTO("Machine Gun Kelly");
            ArtistDTO artist3 = new ArtistDTO("Yungblud");
            ArtistDTO artist4 = new ArtistDTO("Claudio Villa");
            PlaylistDTO playlist1 = new PlaylistDTO("AMARANTH", 200);

            MovieDTO movie = new("Nuovo Cinema Paradiso", "Tornatore", 600);
            MovieDTO movie1 = new("Titanic", "James Cameron", 600);
            AlbumDTO album1 = new("Dangerous", 200, artist);
            AlbumDTO album2 = new("Eros", 300, artist1);
            AlbumDTO THRILLER = new("Thriller", 100, artist);
            AlbumDTO tickets = new("Tickets for my falldown", 100, artist2);
            AlbumDTO CENTURY = new("Century", 100, artist3);
            AlbumDTO biggest = new("Grandi successi", 100, artist4);
            SongDTO bj = new SongDTO("Billie Jean", artist, 110, THRILLER);
            SongDTO fl = new SongDTO("Fake Love don't last", artist2, 110, tickets);
            SongDTO lowlife = new("Lowlife", artist3, 110, CENTURY);
            SongDTO granada = new("Granada", artist4, 110, biggest);
            SongDTO babybemine = new SongDTO("Baby be mine", artist, 110, THRILLER);
            playlist1.Songs.Add(bj);
            Service.AddItemDTO<PlaylistDTO, Playlist>(playlist1);
            Service.AddItemDTO<SongDTO, Song>(bj);
            Service.AddItemDTO<SongDTO, Song>(babybemine);
            Service.AddItemDTO<SongDTO, Song>(fl);
            Service.AddItemDTO<SongDTO, Song>(lowlife);
            Service.AddItemDTO<SongDTO, Song>(granada);
            Service.AddItemDTO<AlbumDTO, Album>(album1);
            Service.AddItemDTO<AlbumDTO, Album>(album2);
            Service.AddItemDTO<AlbumDTO, Album>(THRILLER);
            Service.AddItemDTO<AlbumDTO, Album>(CENTURY);
            Service.AddItemDTO<AlbumDTO, Album>(tickets);
            Service.AddItemDTO<AlbumDTO, Album>(biggest);
            // Aggiungi i film utilizzando il servizio
            Service.AddItemDTO<MovieDTO, Movie>(movie);
            Service.AddItemDTO<MovieDTO, Movie>(movie1);
            Service.AddItemDTO<ArtistDTO, Artist>(artist);
            Service.AddItemDTO<ArtistDTO, Artist>(artist1);
            Service.AddItemDTO<ArtistDTO, Artist>(artist2);
            Service.AddItemDTO<ArtistDTO, Artist>(artist3);
            Service.AddItemDTO<ArtistDTO, Artist>(artist4);


            DbContext.WriteListToCsv(filePathSongs, Db.Songs);
            DbContext.WriteListToCsv(filePathMovies, Db.Movies);
            DbContext.WriteListToCsv(filePathAlbums, Db.Albums);
            DbContext.WriteListToCsv(filePathArtists, Db.Artists);
            DbContext.WriteListToCsv(filePathPlaylists, Db.Playlists);



            //Menu

            bool esci = false;
            while (!esci)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Choose the Media File:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1.Music");
                Console.WriteLine("2.Video");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();
                if (input == "1")
                {
                    // Menu musica
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the number of the service that you want:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1-SONGS");
                    Console.WriteLine("2-ALBUMS");
                    Console.WriteLine("3-ARTISTS");
                    Console.WriteLine("4-PLAYLISTS");
                    // Aggiungi altri servizi se necessario
                    Console.ForegroundColor = ConsoleColor.White;

                    string inputmenu2 = Console.ReadLine();
                    if (inputmenu2 == "1")
                    {
                        // Menu canzoni
                        var songs = Service.GetAllItems<Song>(filePathSongs);
                        List<MediaDTO> list = new List<MediaDTO>();

                        foreach (Song s in songs)
                        {
                            list.Add(new SongDTO(title: s.Title, artist: new ArtistDTO(name: s.Artist.Name), duration: s.Duration, new AlbumDTO(title: s.Album.Title, duration: s.Album.Duration, artist: new ArtistDTO(s.Album.Artist.Name))));
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("If you want to play a song, enter the number:");
                        Console.ForegroundColor = ConsoleColor.White;

                        string input1 = Console.ReadLine();

                        if (int.TryParse(input1, out int inputt) && inputt <= songs.Count && inputt > 0)
                        {
                            mediaPlayer.Play(list, inputt - 1);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else if (inputmenu2 == "3")
                    {
                        // Menu artist
                        var artists = Service.GetAllItems<Artist>(filePathArtists);
                        Console.WriteLine("Enter the number of artist you want to see the albums:");
                        string inpu = Console.ReadLine();

                        if (int.TryParse(inpu, out int interoo) && interoo < artists.Count && interoo >= 0)
                        {
                            var art = Service.GetItemById<Artist>(interoo);
                            int i = 0;
                            foreach (Album a in art.Albums)
                            {
                                i++;
                                Console.WriteLine(i + "-" + a.Title);
                            }

                            Console.WriteLine("Enter the number of the album that you want to play:");
                            string albumInput = Console.ReadLine();
                            List<MediaDTO> listaa = new List<MediaDTO>();

                            if (int.TryParse(albumInput, out int inp) && inp > 0 && inp <= art.Albums.Count)
                            {
                                var selectedAlbum = art.Albums[inp - 1];
                                foreach (Song s in selectedAlbum.Songs)
                                {
                                    SongDTO ball = new SongDTO(title: s.Title, artist: new ArtistDTO(name: s.Artist.Name), duration: s.Duration);
                                    listaa.Add(ball);
                                }

                                if (listaa.Count > 0)
                                {
                                    Console.WriteLine($"Playing songs from {selectedAlbum.Title} album:");

                                    // Riproduci casualmente le canzoni dell'album
                                    Random random = new Random();
                                    foreach (SongDTO song in listaa.OrderBy(x => random.Next()))
                                    {
                                        Console.WriteLine($"Playing {song.Title}");
                                        mediaPlayer.Play(listaa, listaa.IndexOf(song));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("The selected album has no songs.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid album input!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid artist input!");
                        }
                    }
                    else if (inputmenu2 == "4")
                    {
                        // Menu playlist
                        var playlists = Service.GetAllItems<Album>(filePathPlaylists);
                        Console.WriteLine("Enter the number of album you want to see the tracklist:");
                        string inputtt = Console.ReadLine();

                        if (int.TryParse(inputtt, out int intero) && intero < playlists.Count && intero >= 0)
                        {
                            var playlist = Service.GetItemById<Playlist>(intero);
                            int i = 0;
                            foreach (Song s in playlist.Songs)
                            {
                                i++;
                                Console.WriteLine(i + "-" + s.Title);
                            }

                            Console.WriteLine("Enter the number of the song that you want to play:");
                            string tasto = Console.ReadLine();
                            List<MediaDTO> lista = new List<MediaDTO>();

                            if (int.TryParse(tasto, out int tasto1) && tasto1 > 0)
                            {
                                foreach (Song s in playlist.Songs)
                                {
                                    SongDTO ba = new SongDTO(title: s.Title, artist: new ArtistDTO(name: s.Artist.Name), duration: s.Duration);
                                    lista.Add(ba);
                                }

                                if (tasto1 <= lista.Count)
                                {
                                    Console.WriteLine(lista.Count);
                                    mediaPlayer.Play(lista, tasto1 - 1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    else if (inputmenu2 == "2")
                    {
                        // Menu album
                        var albums = Service.GetAllItems<Album>(filePathAlbums);
                        Console.WriteLine("Enter the number of album you want to see the tracklist:");
                        string inputtt = Console.ReadLine();

                        if (int.TryParse(inputtt, out int intero) && intero < albums.Count && intero >= 0)
                        {
                            var album = Service.GetItemById<Album>(intero);
                            int i = 0;
                            foreach (Song s in album.Songs)
                            {
                                i++;
                                Console.WriteLine(i + "-" + s.Title);
                            }

                            Console.WriteLine("Enter the number of the song that you want to play:");
                            string tasto = Console.ReadLine();
                            List<MediaDTO> lista = new List<MediaDTO>();

                            if (int.TryParse(tasto, out int tasto1) && tasto1 > 0)
                            {
                                foreach (Song s in album.Songs)
                                {
                                    SongDTO ba = new SongDTO(title: s.Title, artist: new ArtistDTO(name: s.Artist.Name), duration: s.Duration);
                                    lista.Add(ba);
                                }

                                if (tasto1 <= lista.Count)
                                {
                                    Console.WriteLine(lista.Count);
                                    mediaPlayer.Play(lista, tasto1 - 1);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else if (input == "2")
                {
                    var movies = Service.GetAllItems<Movie>(filePathMovies);
                    List<MediaDTO> list1 = new List<MediaDTO>();
                    foreach (Movie a in movies)
                    {
                        list1.Add(new MovieDTO(title: a.Title, artist: a.Director, duration: a.Duration));

                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("If you want to play a movie, enter the number:");
                    Console.ForegroundColor = ConsoleColor.White;
                    string input1 = Console.ReadLine();

                    if (int.TryParse(input1, out int inputt) && inputt <= movies.Count && inputt > 0)
                    {

                        mediaPlayer.Play(list1, inputt - 1);


                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input!");
                        Console.ForegroundColor = ConsoleColor.White;

                        // Richiedi all'utente se desidera uscire
                        Console.WriteLine("Do you want to exit? (Y/N)");
                        string exitChoice = Console.ReadLine();
                        if (exitChoice.ToUpper() == "Y")
                        {
                            esci = true;
                        }
                    }
                }
            }
        }
    }
}

