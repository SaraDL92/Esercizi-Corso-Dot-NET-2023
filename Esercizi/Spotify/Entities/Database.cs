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
        bool islogged=false;

        public Database()
        {
            _users= new List<User>();
            _artists= new List<Artist>();   
            _songs= new List<Song>();
            _albums= new List<Album>();
        }

        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<User> Users { get => _users; set => _users = value; }
        public bool Islogged { get => islogged; set => islogged = value; }

      
        public void Register(string Name,string Surname,string Birthday,List <PlayList> Playlist,string Username,string Password,List<Song>Favsongs,bool isArtist,List <Radio>FavRadio)
        {
            User user = new(Name,Surname,Birthday,Playlist,Username,Password,Favsongs,FavRadio,isArtist);
            Users.Add(user);
            
        }
       public void ShowMeUsers() {
        foreach(User user in Users) { Console.WriteLine(user.UserName+" "+user.Password);}
        }

        public void ShowMeArtists()
        {
            if (Artists != null)
            {
                foreach (Artist artist in Artists)
                {
                    Console.WriteLine(artist.ArtistName);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeAlbums()
        {
            if (Albums != null)
            {
                foreach (Album album in Albums)
                {
                    Console.WriteLine(album.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void ShowMeSongs()
        {
            if (Songs != null)
            {
                foreach (Song song in Songs)
                {
                    Console.WriteLine(song.Title);

                }


            }
            else { Console.WriteLine("No list of artists"); }
        }
        public void AddArtistToDB(Artist artist)
        {
            if (Artists != null) { Artists.Add(artist);}
            else { Console.WriteLine("No one in list"); }
            
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
