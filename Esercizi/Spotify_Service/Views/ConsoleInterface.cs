using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify_Service.Interfaces;
using Spotify_DataLayer.DTO;
using System.Reflection;
using System.ComponentModel.Design;
using Spotify_DataLayer.Repository;

namespace Spotify_Presentation
{

    public class ConsoleInterface
    {
        private readonly IMusicService _musicService;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        public ConsoleInterface(IMusicService musicService, IMovieService movieService, IUserService userService)
        {
            _musicService = musicService;
            _movieService = movieService;
            _userService = userService;
        }

        public void Execute()
        {
            bool continua = true;
            StarterDB();

            while (continua)
            {
                Console.Write("Welcome in Spotify!");
                Console.WriteLine("Enter L for Login and R for Register:");
                string inp = Console.ReadLine();
                if (inp == "L" || inp == "l")
                {
                    Login();
                }
                else if (inp == "R" || inp == "r")
                {
                    Register();
                }

                else { Console.WriteLine("Invalid input!"); }




                Console.Write("Choose the service:");
                Console.Write("1. Music");
                Console.Write("2. Video");
                string scelta1 = Console.ReadLine();

                switch (scelta1)
                {
                    case "1":
                        Console.WriteLine("Select an option:");
                        Console.WriteLine("1. Add new song");
                        Console.WriteLine("2. List of Songs");
                        Console.WriteLine("3. List of Albums");
                        Console.WriteLine("4. List of Artists");
                        Console.WriteLine("5. List of Radios");


                        Console.WriteLine("6. Esc");

                        string scelta = Console.ReadLine();

                        switch (scelta)
                        {
                            case "1":
                                AddSong();
                                break;
                            case "2":
                                ShowMeSongs();
                                Console.WriteLine("Enter the number to play the song:");
                                string input = Console.ReadLine();
                                Console.WriteLine("play:");
                                ShowMeOneSong(input);


                                break;
                            case "3":
                                ShowMeAlbums();
                                Console.WriteLine("Enter the number of the Album you want to see tracklist:");
                                string input2 = Console.ReadLine();
                                int.TryParse(input2, out int result);
                                var albumscelto = _musicService.GetAlbumById(result);
                                var songs = _musicService.GetAllAlbumSongs(albumscelto);
                                foreach (SongDTO s in songs)
                                {
                                    Console.WriteLine(s.Id_Song + "-" + s.TitleOfSong);
                                }
                                Console.WriteLine("Enter the number of the song you want to play:");
                                string enter = Console.ReadLine();
                                int.TryParse(enter, out int enterint);
                                Console.WriteLine("play:" + songs[enterint - 1].TitleOfSong);


                                break;
                            case "4":
                                ShowMeArtists();
                                Console.WriteLine("Enter the number of the Artist you want to see the albums:");
                                string input21 = Console.ReadLine();
                                int.TryParse(input21, out int result1);
                                var artistascelto = _musicService.GetArtistById(result1);

                                var albums = FindAlbumsOfArtist(artistascelto);
                                Console.WriteLine("Enter the number of the album you want to see the tracklist:");
                                string inn = Console.ReadLine();
                                int.TryParse(inn, out int innint);
                                var tracks = _musicService.GetAllAlbumSongs(albums[innint - 1]);
                                int i = 0;
                                foreach (SongDTO song in tracks)
                                {
                                    i++;
                                    Console.WriteLine(i + "-" + song.TitleOfSong);
                                }
                                Console.WriteLine("Enter the number of the song you want to play:");
                                string n = Console.ReadLine();
                                int.TryParse(n, out int nint);
                                Console.WriteLine($"Play {tracks[nint - 1].TitleOfSong}");



                                break;
                            case "5":
                                var radios = ShowMeRadios();
                                Console.WriteLine("Enter the number of the radio you want to play:");
                                string t = Console.ReadLine();
                                int.TryParse(t, out int tint);
                                Console.WriteLine(radios[tint - 1].TitleOfRadio);
                                var listsongsradios = _musicService.GetAllSongs().FindAll(s => s.Radio.TitleOfRadio == radios[tint - 1].TitleOfRadio);
                                int iii = 0;
                                foreach (SongDTO song in listsongsradios)
                                {
                                    iii++;
                                    Console.WriteLine(iii + "-" + song.TitleOfSong);
                                }
                                Console.WriteLine("Enter the number of the song you want to play:");
                                string inter = Console.ReadLine();
                                int.TryParse(inter, out int intero);
                                Console.WriteLine("Play:" + " " + listsongsradios[intero].TitleOfSong);








                                break;
                            case "6":
                                _musicService.SaveOnFile();
                                continua = false;
                                break;
                            default:
                                Console.WriteLine("Invalid option. Retry!");
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("YOU ARE IN VIDEO SECTION NOW");
                        ShowMeMovies();

                        break;
                }


            }
        }

        private void StarterDB()
        {
            var artist1 = new ArtistDTO("Michael Jackson");
            var artist2 = new ArtistDTO("Duran Duran");
            var artist3 = new ArtistDTO("Cindy Lauper");
            var artist4 = new ArtistDTO("Nirvana");

            var album1 = new AlbumDTO("Thriller", artist1);
            var album2 = new AlbumDTO("Bad", artist1);
            var album3 = new AlbumDTO("Best Songs of Duran Duran", artist2);
            var album4 = new AlbumDTO("Best Songs of Cindy Lauper", artist3);
            var album5 = new AlbumDTO("In Utero", artist4);
            var radio1 = new RadioDTO("Radio POP", new List<SongDTO>());
            var radio2 = new RadioDTO("Radio ROCK", new List<SongDTO>());
            var radio3 = new RadioDTO("Radio GRUNGE", new List<SongDTO>());

            var canzone1 = new SongDTO("Thriller", artist1, album1, radio1);
            var canzone11 = new SongDTO("Billie Jean", artist1, album1, radio1);
            var canzone12 = new SongDTO("Dirty Diana", artist1, album1, radio2);
            var canzone2 = new SongDTO("Liberian Girl", artist1, album2, radio1);
            var canzone3 = new SongDTO("Wild Boys", artist2, album3, radio2);
            var canzone4 = new SongDTO("True Colors", artist3, album4, radio1);
            var canzone5 = new SongDTO("Heart-Shaped Box", artist4, album5, radio3);
            var director = new DirectorDTO("James Cameron");
            var director1 = new DirectorDTO("Tornatore");
            var movie1 = new MovieDTO("Titanic", director);
            var movie2 = new MovieDTO("Nuovo Cinema Paradiso", director1);

            _movieService.AddDirector(director);
            _movieService.AddDirector(director1);
            _movieService.AddMovie(movie1);
            _movieService.AddMovie(movie2);
            _musicService.AddSongToRadio(canzone1, radio1);
            _musicService.AddSongToRadio(canzone2, radio1);
            _musicService.AddSongToRadio(canzone4, radio1);
            _musicService.AddSongToRadio(canzone5, radio3);
            _musicService.AddSongToRadio(canzone3, radio2);


            _musicService.AddArtist(artist1);
            _musicService.AddArtist(artist2);
            _musicService.AddArtist(artist3);


            _musicService.AddAlbum(album1);
            _musicService.AddAlbum(album2);
            _musicService.AddAlbum(album3);
            _musicService.AddAlbum(album4);



            _musicService.AddSong(canzone1);
            _musicService.AddSong(canzone2);
            _musicService.AddSong(canzone3);
            _musicService.AddSong(canzone4);

            _musicService.AddRadio(radio1);
            _musicService.AddRadio(radio2);
            _musicService.AddRadio(radio3);


        }

        public String SelectTimeZone()
        {
            var availableTimeZones = TimeZoneInfo.GetSystemTimeZones();
            var AvailableTimeZones = availableTimeZones;
            Console.WriteLine("Select your zone:");

            // Mostra la lista dei fusi orari disponibili
            for (int i = 0; i < AvailableTimeZones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {AvailableTimeZones[i].Id}");
            }

            // Chiedi all'utente di selezionare un fuso orario
            int selectedTimeZoneIndex;
            do
            {
                Console.Write("Enter the number of your time zone: ");
            } while (!int.TryParse(Console.ReadLine(), out selectedTimeZoneIndex) ||
                     selectedTimeZoneIndex < 1 || selectedTimeZoneIndex > AvailableTimeZones.Count);

            // Imposta il fuso orario selezionato sulla base dell'input dell'utente
           return  AvailableTimeZones[selectedTimeZoneIndex - 1].Id;
        }

        public void DisplayLocalDateTime(String SelectedTimeZoneId)
        {
            if (string.IsNullOrEmpty(SelectedTimeZoneId))
            {
                Console.WriteLine("Please select a time zone first.");
                return;
            }

            // Ottenere l'ora e la data locali in base al fuso orario selezionato
            try
            {
                TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(SelectedTimeZoneId);
                DateTime localDateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);

                Console.WriteLine($"Local Date and Time ({SelectedTimeZoneId}): {localDateTime}");
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("Invalid time zone selected.");
            }
        }
        public void Register()
        {
            Console.WriteLine("Enter Username:");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string pass = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();
            if (_userService.GetAllUsers().Any(u => u.Username == user))
            {
                Console.WriteLine("Already registered user!");
               
                Login();
            }
            else
            {
                UserDTO US = new UserDTO(user, pass, email, new SettingDTO());

                Console.WriteLine("Choose the Dark Theme (enter: black) or the Light Theme (enter: white):");
                string theme = Console.ReadLine();
                
                if (theme == "black" || theme == "BLACK")
                { US.Setting.LightTheme = false;
                   
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine("You have chosen DARK THEME");
                }
                else if (theme == "white" || theme == "WHITE")
                {
                    US.Setting.LightTheme = true;
                    Console.WriteLine("You have chosen LIGHT THEME");
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                else
                {
                    Console.WriteLine("Invalid input!");

                }
                Console.WriteLine("Choose your Plan, enter F for FREE(100hours of music), P for PREMIUM (1000 hours of music) or G for Gold (illimiate):");

                string plan = Console.ReadLine();
               

                switch (plan)
                {
                    case "F":
                    case "f":
                       US.Setting.PremiumPlan= false;
                        US.Setting.GoldPlan = false;
                       US.Setting.FreePlan = true;
                        Console.WriteLine("You are a FREE USER NOW");

                        break;
                    case "P":
                    case "p":
                        US.Setting.PremiumPlan = true;
                        US.Setting.GoldPlan = false;
                        US.Setting.FreePlan = false;
                        Console.WriteLine("You are a PREMIUM USER NOW");

                        break;
                    case "G":
                    case "g":
                        US.Setting.PremiumPlan = false;
                        US.Setting.GoldPlan = true;
                        US.Setting.FreePlan = false;
                        Console.WriteLine("You are a GOLD USER NOW");

                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                var zona = SelectTimeZone(); 
              
                SettingDTO sett = new SettingDTO(US.Setting.User, US.Setting.LightTheme, US.Setting.GoldPlan, US.Setting.FreePlan, US.Setting.PremiumPlan, zona);
  US.Setting = sett;  _userService.AddUser(US);
                _userService.AddSetting(sett);

                Console.WriteLine("You are registered now! Enter your credentials to Login:");
                Login(); 
                DisplayLocalDateTime(zona);
             
                
              
              
                
              

        }
            } 
        public void Login()
        {
            var tuttiUtenti = _userService.GetAllUsers();

            Console.WriteLine("Enter Username:");
            string user = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string pass = Console.ReadLine();
           
            
            

            if (tuttiUtenti.Any(u => u.Username == user && u.Password == pass)) { Console.WriteLine("You are logged!");
                
             var user1=tuttiUtenti.Find(u=>u.Username==user);
                DisplayLocalDateTime(user1.Setting.SelectedTimeZoneId);





            } 
            else { Console.WriteLine("You have not an account yet! Enter R for Register, enter L for retry to Login:");
              string resp=Console.ReadLine();
                if(resp == "R" || resp == "r") {    Register();}else if(resp == "L" || resp == "l") { Login(); } else { Console.WriteLine("Invalid input!"); }
                  }
        }
        
        private void AddSong()
        {
            Console.WriteLine("Enter the Title of song:");
            string titolo = Console.ReadLine();

            Console.WriteLine("Enter the Artist of the song:");
            string artista = Console.ReadLine();
            Console.WriteLine("Enter the Album of the song:");
            string album = Console.ReadLine();


            var nuovaCanzone = new SongDTO(titolo, new ArtistDTO(artista), new AlbumDTO(album, new ArtistDTO(artista)), null);


            _musicService.AddSong(nuovaCanzone);
            var newArtist = new ArtistDTO(artista);
            var newAlbum = new AlbumDTO(album, newArtist);

            AddAlbum(newAlbum, nuovaCanzone);
            AddArtist(newArtist, nuovaCanzone, newAlbum);

            Console.WriteLine("Song added with success!");
        }
        private void AddAlbum(AlbumDTO album, SongDTO song)
        {


            album.Songs.Add(song);


            _musicService.AddAlbum(album);

            Console.WriteLine("Album added with success!");
        }

        private void AddArtist(ArtistDTO artist, SongDTO song, AlbumDTO album)
        {


            artist.Songs.Add(song);
            artist.Albums.Add(album);




            Console.WriteLine("Album added with success!");
        }
        private void ShowMeSongs()
        {
            var songs = _musicService.GetAllSongs();

            Console.WriteLine("List of Songs:");
            int i = 0;
            foreach (var song in songs)
            {
                i++;
                Console.WriteLine($"{i} - {song.ArtistOfSong.NameOfArtist}-{song.AlbumOfSong.TitleOfAlbum}");
            }
        }
        private void ShowMeMovies()
        {
            var movies = _movieService.GetAllMovies();

            Console.WriteLine("List of Movies:");
            int i = 0;
            foreach (var movie in movies)
            {
                i++;
                Console.WriteLine($"{i} - {movie.Director.NameOfDirector}-{movie.TitleOfMovie}");
            }
        }
        private void ShowMeOneSong(string id)
        {
            int.TryParse(id, out int id1);
            var song = _musicService.GetSongById(id1);

            Console.WriteLine($"{song.Id_Song}-{song.TitleOfSong}");

        }
        private void ShowMeOneAlbum(string id)
        {
            int.TryParse(id, out int id1);
            var album = _musicService.GetAlbumById(id1);
            int i = 0;
            Console.WriteLine(album.Songs.Count());
            foreach (var song in album.Songs)
            {
                i++;

                Console.WriteLine($"{i}-{song.TitleOfSong}");
            }



        }

        public List<AlbumDTO> FindAlbumsOfArtist(ArtistDTO artist)
        {
            var albums = _musicService.GetAllAlbums();
            var albumsOfArtist = albums.FindAll(a => artist.NameOfArtist == a.ArtistOfAlbum.NameOfArtist);
            int i = 0;
            foreach (var album in albumsOfArtist)
            {
                i++;
                Console.WriteLine(i + "-" + album.TitleOfAlbum);
            }
            return albumsOfArtist;
        }

        private void ShowMeAlbums()
        {
            var albums = _musicService.GetAllAlbums();

            Console.WriteLine("List of Albums:");
            int i = 0;

            foreach (var album in albums)
            {
                i++;
                Console.WriteLine($"{i}- {album.TitleOfAlbum} of {album.ArtistOfAlbum.NameOfArtist}");
            }
        }
        private void ShowMeArtists()
        {
            var artists = _musicService.GetAllArtists();

            Console.WriteLine("List of Artists:");

            foreach (var artist in artists)
            {
                Console.WriteLine($"{artist.Id_Artist + "- " + artist.NameOfArtist}");
            }
        }
        public List<RadioDTO> ShowMeRadios()
        {
            var radios = _musicService.GetAllRadios();

            Console.WriteLine("List of Radios:");
            int i = 0;
            foreach (var radio in radios)
            {
                i++;
                Console.WriteLine($"{i + "-" + radio.TitleOfRadio}");
            }
            return radios;
        }

    }
}
    