using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class Artist:Person
    {
         string _artistName;
            List<Album> _albums;
            List<Media> _songs = new List<Media>();
            string _bio;
            List<Group> _groups;
            int _rating;

        public Artist(string Name, string Surname, string Birthday, string artistName, string bio, int rating = 0) : base(Name, Surname, Birthday)
        {
            _artistName = artistName;
            _albums = new List<Album>();

            _bio = bio;
            _groups = new List<Group>();
            _rating = rating;
        }

        public int GenerateRating()
        {
            foreach (Album album in Albums)
            {
                int rat = Albums.Sum(x => x.CalculateRating());
                Rating = rat;
            }
            return Rating;
        }
        public void CreateNewSong(string genre, string title, int duration, string releaseDate)
        {
            Media song = new(genre, title, duration, releaseDate, this);

            Songs.Add(song);
        }

        public void ShowMeSongList()
        {
            try
            {
                if (Songs == null) { throw new InvalidOperationException($"The Artist {this.ArtistName} has no songs! "); }
                Console.WriteLine($"This is the song list of the artist {this.ArtistName}: ");
                int i = 1;
                foreach (Media song in Songs) { Console.WriteLine(i++ + "-" + song.Title); }


            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error:" + " " + e.Message);
            }





        }

        public string ArtistName { get => _artistName; set => _artistName = value; }
            public string Bio { get => _bio; set => _bio = value; }

            public List<Album> Albums { get => _albums; set => _albums = value; }
           public List<Media> Songs { get => _songs; set => _songs = value; }
           public List<Group> Group1 { get => _groups; set => _groups = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
    }
