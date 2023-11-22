using System;
using System.Collections.Generic;
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

        public Database()
        {
            
        }

        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<User> Users { get => _users; set => _users = value; }

        public void ShowMeSongs()
        {
            foreach(Song s in Songs) {
            Console.WriteLine(s);}
        }
        public void Register(string Name,string Surname,string Birthday,List <PlayList> Playlist,string Username,string Password,List<Song>Favsongs,bool isArtist,List <Radio>FavRadio)
        {
            User user = new(Name,Surname,Birthday,Playlist,Username,Password,Favsongs,FavRadio,isArtist);
            
        }


    }
}
