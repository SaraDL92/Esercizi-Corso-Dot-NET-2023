using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Artist : Person
    {
        string _artistName;
        List<Album> _albums;
        List<Song> _songs;
        string _bio;
        Group _group;

        public Artist(string Name, string Surname, string Birthday, string artistName, List<Album> albums, List<Song> songs, string bio, Group group) : base(Name, Surname, Birthday)
        {
            _artistName = artistName;
            _albums = albums;
            _songs = songs;
            _bio = bio;
            _group = group;  Songs = new List<Song>();

        }
      
        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public Group Group { get => _group; set => _group = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }

        public void CreateNewSong(string genre, string title, int duration, string releaseDate, Album album)
        {
            Song song = new(genre, title, duration, releaseDate, album,this);
           
            Songs.Add(song);
        }

        public void RemoveSong(Song song)
        {
            _songs.Remove(song);
        }



        public void CreateNewAlbum(string title, string releaseDate, string numboftracks, Artist artist, Group group, bool liveVersion, List<Song> tracklist)
        {
            Album album = new(title, releaseDate, numboftracks, artist, group, liveVersion, tracklist);
        }

        public void RemoveAlbum(Album album) {

            Albums.Remove(album);
        }

        public void ShowMeSongList()
        {
            try
            {
                if (Songs == null) { throw new InvalidOperationException($"The Artist {this.ArtistName} has no songs! "); }
                Console.WriteLine($"This is the song list of the artist {this.ArtistName}: ");
                int i = 1;
                foreach (Song song in Songs) { Console.WriteLine(i++ +"-"+ song.Title); }


            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Error:"+" "+e.Message);
            }
            
                 

            
           
        }
        

        public override string ToString()
        {
            return $"The artist {ArtistName} was created! ";
        }



    }


    }

