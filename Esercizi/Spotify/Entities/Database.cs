using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Database
    {
        List <Album> _albums;
        List <Artist> _artists;
        List<Song> _songs;
        List<User> _users;
        List<PlayList> _playlists;
        bool islogged=false;

        public Database()
        {
            _users= new List<User>();
            _artists= new List<Artist>();   
            _songs= new List<Song>();
            _albums= new List<Album>();
            _playlists= new List<PlayList>();
        }

        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<User> Users { get => _users; set => _users = value; }
        public bool Islogged { get => islogged; set => islogged = value; }
        internal List<PlayList> Playlists { get => _playlists; set => _playlists = value; }

        public void Register(User utente)
        {
            
            Users.Add(utente);
            
        }
       public void ShowMeUsers() {
        foreach(User user in Users) { Console.WriteLine(user.UserName+" "+user.Password);}
        }

        public void ShowMeArtists()
        {
            if (Artists != null)
            {
                int i = 0;
                foreach (Artist artist in Artists)
                {
                    i++;
                    Console.WriteLine(i+"-"+artist.ArtistName);

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
                    Console.WriteLine(i+"-"+album.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeOneAlbum(Album album)
        {
            int i = 0;
            List<Song> songs = album.TrackList;
           foreach(Song s in songs)
            {
                i++;
                Console.WriteLine(i+""+s.Title);
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
            List<Song> songs = playlist.Songs;
            foreach (Song s in songs)
            {
                i++;
                Console.WriteLine(i + "" + s.Title);
            }



        }
        public void ShowMeSongs()
        {int i = 0;
            if (Songs != null)
            {
                foreach (Song song in Songs)
                {
                   
                    i++;
                    Console.WriteLine(i+"-"+song.Title);

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
                {i++;
                    Console.WriteLine(i+" "+playlist.Name);

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
            if (Playlists != null) { Playlists.Add(playlist);}
            else{ Console.WriteLine("No one playlist in Spotify!"); }
            
        }
        public void AddAlbumToDB(Album album)
        {
            if (Albums != null) { Albums.Add(album); }
            else { Console.WriteLine("No one in list"); }

        }
        public void AddSongsToDB(Song song)
        {
            if (Songs != null) {Songs.Add(song); }
            else { Console.WriteLine("No one in list"); }

        }


        public void Login(string username, string psw)
        {
            if (Users != null)
            {
                bool userFound = false;

                foreach (User u in Users)
                {
                    if (u.UserName == username && u.Password == psw)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Welcome to spotify" + " " + username);
                      
                        userFound = true;
                        islogged = true;
                        break;
                    }
                }

                if (!userFound)
                {
                    Console.WriteLine("You don't have a registered user!");
                    islogged = false;
                }
            }
            else
            {
                Console.WriteLine("Nessun utente nella lista");
                islogged=false;
            }
        }

    }
}
