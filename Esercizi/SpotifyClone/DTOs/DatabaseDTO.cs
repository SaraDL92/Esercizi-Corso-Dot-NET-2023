﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class DatabaseDTO
    {
        List<AlbumDTO> _albums = new List<AlbumDTO>();
        List<ArtistDTO> _artists = new List<ArtistDTO>();
        List<MediaDTO> _songs = new List<MediaDTO>();
        List <MediaDTO>_movies=new List <MediaDTO>();
        List<UserDTO> _users = new List<UserDTO>();
        List<PlayListDTO> _playlists = new List<PlayListDTO>();
        List <Radio> _radiolist = new List<Radio>();
       
        bool islogged = false;

        public DatabaseDTO()
        {
            _users = new List<UserDTO>();
            _artists = new List<ArtistDTO>();
            _songs = new List<MediaDTO>();
            _albums = new List<AlbumDTO>();
            _playlists = new List<PlayListDTO>();
        }

        public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
       public List<ArtistDTO> Artists { get => _artists; set => _artists = value; }
       public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
       public List<UserDTO> Users { get => _users; set => _users = value; }
        public bool Islogged { get => islogged; set => islogged = value; }
        public List<PlayListDTO> Playlists { get => _playlists; set => _playlists = value; }
        public List<MediaDTO> Movies { get => _movies; set => _movies = value; }
        public List<Radio> Radiolist { get => _radiolist; set => _radiolist = value; }

        public void ShowMeRadio()
        {
            if (Radiolist != null)
            {
                int i = 0;
                foreach (Radio radio in Radiolist)
                {
                    i++;
                    Console.WriteLine(i + "-" + radio.SongList);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeUsers()
        {
            foreach (UserDTO user in Users) { Console.WriteLine(user.UserName + " " + user.Password); }
        }

        public void ShowMeArtists()
        {
            if (Artists != null)
            {
                int i = 0;
                foreach (ArtistDTO artist in Artists)
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
                foreach (AlbumDTO album in Albums)
                {
                    i++;
                    Console.WriteLine(i + "-" + album.Title);

                }


            }
            else { Console.WriteLine("No list of albums"); }
        }

        public void ShowMeTop5Albums()
        {var AlbumSorted=Albums.OrderByDescending(a=>a.CalculateRating()).Take(5);
            int i = 0;
            if (Albums != null)
            {
                foreach (AlbumDTO album in AlbumSorted)
                {
                    i++;
                    Console.WriteLine(i + "-" + album.Title+" "+ "rating:"+" "+album.Rating);

                }


            }
            else { Console.WriteLine("No list of albums"); }
        }
        public void ShowMeTop5Radios()
        {
            var RadioSorted = Radiolist.OrderByDescending(a => a.Rating).Take(5);
            int i = 0;
            if (Radiolist != null)
            {
                foreach( Radio r in RadioSorted)
                {
                    i++;
                    Console.WriteLine(i + "-" + r.Name + " " + "rating:" + " " +r.Rating);

                }


            }
            else { Console.WriteLine("No list of radios"); }
        }
        public void ShowMeTop5Playlists()
        {
            var PlaylistSorted = Playlists.OrderByDescending(a => a.Rating).Take(5);
            int i = 0;
            if (Playlists != null)
            {
                foreach (PlayListDTO s in PlaylistSorted)
                {
                    i++;
                    Console.WriteLine(i + "-" + s.Name + " " + "rating:" + " " + s.Rating);

                }


            }
            else { Console.WriteLine("No list of playlists"); }
        }
        public void ShowMeTop5Songs()
        {
            var SongSorted = Songs.OrderByDescending(a => a.Rating).Take(5);
            int i = 0;
            if (Songs != null)
            {
                foreach (MediaDTO s in SongSorted)
                {
                    i++;
                    Console.WriteLine(i + "-" + s.Title + " " + "rating:" + " " + s.Rating);

                }


            }
            else { Console.WriteLine("No list of songs"); }
        }

        public void ShowMeTop5Artists()
        {
            var ArtistSorted = Artists.OrderByDescending(a => a.GenerateRating()).Take(5);
            int i = 0;
            if (Artists != null)
            {
                foreach (ArtistDTO a in ArtistSorted)
                {
                    i++;
                    Console.WriteLine(i + "-" + a.ArtistName + " " + "rating:" + " " + a.Rating);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeOneAlbum(AlbumDTO album)
        {
            int i = 0;
            List<MediaDTO> songs = album.TrackList;
            foreach (MediaDTO s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
        public void ShowMeOneArtist(ArtistDTO artist)
        {
            Console.WriteLine("Albums by " + artist.Name + ":");
            for (int i = 0; i < artist.Albums.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {artist.Albums[i].Title}");
            }
        }
        public void ShowMeOnePlaylist(PlayListDTO playlist)
        {
            int i = 0;
            List<MediaDTO> songs = playlist.Songs;
            foreach (MediaDTO s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
        public void ShowMeOneTracklistRadio(Radio r)
        {
            int i = 0;
           foreach(MediaDTO s in r.SongList)
            {
                i++;
                Console.WriteLine(i+" "+s.Title.ToString());
            }


        }
        public void ShowMeSongs()
        {
            int i = 0;
            if (Songs != null)
            {
                foreach (MediaDTO song in Songs)
                {

                    i++;
                    Console.WriteLine(i + "-" + song.Title);

                }


            }
            else { Console.WriteLine("No list of songs"); }
        }
        public void ShowMeMovies()
        {
            int i = 0;
            if (Movies != null)
            {
                foreach (MediaDTO movie in Movies)
                {

                    i++;
                    Console.WriteLine(i + "-" + movie.Title);

                }


            }
            else { Console.WriteLine("No list of movies"); }
        }

        public void ShowMePlaylists()
        {
            if (Playlists != null)
            {
                int i = 0;
                foreach (PlayListDTO playlist in Playlists)
                {
                    i++;
                    Console.WriteLine(i + " " + playlist.Name);

                }


            }
            else { Console.WriteLine("No list of playlists"); }
        }


        public void AddArtistToDB(ArtistDTO artist)
        {
            if (Artists != null) { Artists.Add(artist); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddPlaylistsToDB(PlayListDTO playlist)
        {
            if (Playlists != null) { Playlists.Add(playlist); }
            else { Console.WriteLine("No one playlist in Spotify!"); }

        }
        public void AddAlbumToDB(AlbumDTO album)
        {
            if (Albums != null) { Albums.Add(album); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddSongsToDB(MediaDTO song)
        {
            if (Songs != null) { Songs.Add(song); }
            else { Console.WriteLine("No one in list"); }

        }
        public void ShowMeRadioList()
        {
            int i = 0;
            foreach(Radio r in Radiolist)
            {
                i++;
                Console.WriteLine(i+"-"+r.Name);
            }
        }
        public void RadioByGenre(Radio radio, string genre)
        {
            var listSongs = Songs.Where(s => s.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
            radio.SongList.AddRange(listSongs);
        }

        public DatabaseDTO InitializeDatabase()
        {
            DatabaseDTO database = new DatabaseDTO();

            ArtistDTO MichaelJackson = new("Michael", "Jackson", "29-08-1958", "Michael Jackson", "The greatest star of all times!");
            ArtistDTO MachineGunKelly = new("Colson", "Baker", "22-04-1990", "Machine Gun Kelly", "Colson Baker (born April 22, 1990), known professionally as Machine Gun Kelly (MGK), is an American rapper, singer, songwriter, musician, and actor.");
            ArtistDTO Yungblud = new("Dominic", "Richard", "05-08-1997", "Yungblud", "Yungblud, pseudonym of Dominic Richard Harrison, is a British singer-songwriter.");
            AlbumDTO Dangerous = new("Dangerous", "1991", "12", MichaelJackson, null, false);
            AlbumDTO Century = new("21st Century Liability", "2018", "10", Yungblud, null, false);
            AlbumDTO Mainstream = new("Mainstream Sellout", "2022", "15", MachineGunKelly, null, false);
            MediaDTO healtheworld = new("POP", "Heal The World", 100, "1991", Dangerous, MichaelJackson);
            MediaDTO gonetoosoon = new("POP", "Gone too soon", 200, "1991", Dangerous, MichaelJackson);
            MediaDTO fakelove = new("Rock", "Fake love don't last", 120, "2022", Mainstream, MachineGunKelly);
            Director JamesCameron = new("James Cameron");
            Director JacoVanDormael = new("Jaco Van Dormael");
            Director Melies = new("Georges Méliès");
            MediaDTO Titanic = new(JamesCameron, "Titanic", 7200, "1997", "Dramatic");
            MediaDTO MrNobody = new(JacoVanDormael , "Mr Nobody", 7200, "2009", "Sci-fi");
            MediaDTO Levoy = new(Melies, "Le voyage dans la lune", 840, "1902", "Sci-fi");
            Dangerous.TrackList.Add(gonetoosoon);
            


            Radio radiopop = new("Radio Pop");
            Radio radiorock = new("Radio Rock");
            Radio radiohiphop = new("Radio Hip-Hop");
            database.RadioByGenre(radiopop, "POP");
            database.RadioByGenre(radiorock, "ROCK");
            database.RadioByGenre(radiohiphop, "HIP-HOP");
            
           
            database.Radiolist.Add(radiopop);
            database.Radiolist.Add(radiorock);
            database.Radiolist.Add(radiohiphop);
            radiorock.SongList.Add(fakelove);
          
            radiopop.SongList.Add(gonetoosoon);
            radiopop.SongList.Add(healtheworld);





            database.Movies.Add(Titanic);
            database.Movies.Add(MrNobody);
            database.Movies.Add(Levoy);

            MediaDTO iloveyou = new("Ballad Rock", "I Love You, Will You Marry Me", 150, "2018", Century, Yungblud);  radiorock.SongList.Add(iloveyou);
            PlayListDTO ottantas = new("90s songs", healtheworld);
            PlayListDTO punk = new("punk rock time", fakelove);
            PlayListDTO balladrock = new("Rock in love", iloveyou);
            ottantas.AddSong(gonetoosoon);
            gonetoosoon.Albums.Add(Dangerous);
            gonetoosoon.Playlists.Add(ottantas);
            database.Songs.Add(gonetoosoon);
            UserDTO user2 = new UserDTO("Selene", "Rubius", "12-05-1990");
            PlayListDTO playlist1 = new PlayListDTO(user2, "heartstone");
            Dangerous.TrackList.Add(healtheworld);
            Dangerous.TrackList.Add(gonetoosoon);
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



        public void Register(UserDTO utente)
        {

            Users.Add(utente);

        }
        public void Login(string username, string psw, UserDTO user)
        {
            if (Users != null)
            {
                UserDTO foundUser = Users.FirstOrDefault(u => u.UserName == username && u.Password == psw);

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
    
