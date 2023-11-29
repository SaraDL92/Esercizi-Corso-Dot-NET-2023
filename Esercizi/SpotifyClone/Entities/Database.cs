using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class Database
    {
        List<Album> _albums = new List<Album>();
        List<Artist> _artists = new List<Artist>();
        List<Media> _songs = new List<Media>();
        List <Media>_movies=new List <Media>();
        List<User> _users = new List<User>();
        List<PlayList> _playlists = new List<PlayList>();
        bool islogged = false;

        public Database()
        {
            _users = new List<User>();
            _artists = new List<Artist>();
            _songs = new List<Media>();
            _albums = new List<Album>();
            _playlists = new List<PlayList>();
        }

        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Media> Songs { get => _songs; set => _songs = value; }
        internal List<User> Users { get => _users; set => _users = value; }
        public bool Islogged { get => islogged; set => islogged = value; }
        internal List<PlayList> Playlists { get => _playlists; set => _playlists = value; }
        public List<Media> Movies { get => _movies; set => _movies = value; }

        public void ShowMeUsers()
        {
            foreach (User user in Users) { Console.WriteLine(user.UserName + " " + user.Password); }
        }

        public void ShowMeArtists()
        {
            if (Artists != null)
            {
                int i = 0;
                foreach (Artist artist in Artists)
                {
                    i++;
                    Console.WriteLine(i + "-" + artist.ArtistName);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeAlbums()
        {
            int i = 0;
            if (Albums != null)
            {
                foreach (Album album in Albums)
                {
                    i++;
                    Console.WriteLine(i + "-" + album.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeOneAlbum(Album album)
        {
            int i = 0;
            List<Media> songs = album.TrackList;
            foreach (Media s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
        public void ShowMeOneArtist(Artist artist)
        {
            Console.WriteLine("Albums by " + artist.Name + ":");
            for (int i = 0; i < artist.Albums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {artist.Albums[i].Title}");
            }
        }
        public void ShowMeOnePlaylist(PlayList playlist)
        {
            int i = 0;
            List<Media> songs = playlist.Songs;
            foreach (Media s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
        public void ShowMeSongs()
        {
            int i = 0;
            if (Songs != null)
            {
                foreach (Media song in Songs)
                {

                    i++;
                    Console.WriteLine(i + "-" + song.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeMovies()
        {
            int i = 0;
            if (Movies != null)
            {
                foreach (Media movie in Movies)
                {

                    i++;
                    Console.WriteLine(i + "-" + movie.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }

        public void ShowMePlaylists()
        {
            if (Playlists != null)
            {
                int i = 0;
                foreach (PlayList playlist in Playlists)
                {
                    i++;
                    Console.WriteLine(i + " " + playlist.Name);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }


        public void AddArtistToDB(Artist artist)
        {
            if (Artists != null) { Artists.Add(artist); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddPlaylistsToDB(PlayList playlist)
        {
            if (Playlists != null) { Playlists.Add(playlist); }
            else { Console.WriteLine("No one playlist in Spotify!"); }

        }
        public void AddAlbumToDB(Album album)
        {
            if (Albums != null) { Albums.Add(album); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddSongsToDB(Media song)
        {
            if (Songs != null) { Songs.Add(song); }
            else { Console.WriteLine("No one in list"); }

        }
        public Database InitializeDatabase()
        {
            Database database = new Database();

            Artist MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson", "The greatest star of all times!");
            Artist MachineGunKelly = new("Colson", "Baker", "22-04-1990", "Machine Gun Kelly", "Colson Baker (born April 22, 1990), known professionally as Machine Gun Kelly (MGK), is an American rapper, singer, songwriter, musician, and actor.");
            Artist Yungblud = new("Dominic", "Richard", "05-08-1997", "Yungblud", "Yungblud, pseudonym of Dominic Richard Harrison, is a British singer-songwriter.");
            Album Dangerous = new("Dangerous", "1991", "12", MichaelJackson, null, false);
            Album Century = new("21st Century Liability", "2018", "10", Yungblud, null, false);
            Album Mainstream = new("Mainstream Sellout", "2022", "15", MachineGunKelly, null, false);
            Media healtheworld = new("POP", "Heal The World", 100, "1991", Dangerous, MichaelJackson);
            Media fakelove = new("Punk", "Fake love don't last", 120, "2022", Mainstream, MachineGunKelly);
            Director JamesCameron = new("James Cameron");
            Director JacoVanDormael = new("Jaco Van Dormael");
            Director Melies = new("Georges Méliès");
            Media Titanic = new(JamesCameron, "Titanic", 7200, "1997", "Dramatic");
            Media MrNobody = new(JacoVanDormael , "Mr Nobody", 7200, "2009", "Sci-fi");
            Media Levoy = new(Melies, "Le voyage dans la lune", 840, "1902", "Sci-fi");
            database.Movies.Add(Titanic);
            database.Movies.Add(MrNobody);
            database.Movies.Add(Levoy);

            Media iloveyou = new("Ballad Rock", "I Love You, Will You Marry Me", 150, "2018", Century, Yungblud);
            PlayList ottantas = new("90s songs", healtheworld);
            PlayList punk = new("punk rock time", fakelove);
            PlayList balladrock = new("Rock in love", iloveyou);

            User user2 = new User("Selene", "Rubius", "12-05-1990");
            PlayList playlist1 = new PlayList(user2, "heartstone");
            Dangerous.TrackList.Add(healtheworld);
            Century.TrackList.Add(iloveyou);
            Mainstream.TrackList.Add(fakelove);
            MichaelJackson.Albums.Add(Dangerous);
            MachineGunKelly.Albums.Add(Mainstream);
            Yungblud.Albums.Add(Century);
            healtheworld.Albums.Add(Dangerous);
            fakelove.Albums.Add(Mainstream);
            iloveyou.Albums.Add(Century);
            healtheworld.Playlists.Add(ottantas);
            fakelove.Playlists.Add(punk);
            iloveyou.Playlists.Add(balladrock);
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

            return database;
        }



        public void Register(User utente)
        {

            Users.Add(utente);

        }
        public void Login(string username, string psw, User user)
        {
            if (Users != null)
            {
                User foundUser = Users.FirstOrDefault(u => u.UserName == username && u.Password == psw);

                if (foundUser != null)
                {
                    user.IsLogged = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Welcome to Spotify " + username);

                    islogged = true;
                    

                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                    islogged = false;
                    user.IsLogged = false;

                   
                 
                }
            }
            else
            {
                Console.WriteLine("Nessun utente nella lista");
                islogged = false;
                user.IsLogged = false;

               
              
            }

          
        }


    }
}
    
