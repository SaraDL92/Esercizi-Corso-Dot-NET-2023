using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class ArtistDTO:PersonDTO
    {
         string _artistName;
            List<AlbumDTO> _albums;
            List<MediaDTO> _songs = new List<MediaDTO>();
            string _bio;
            List<GroupDTO> _groups;
            int _rating;

        public ArtistDTO(string Name, string Surname, string Birthday, string artistName, string bio, int rating = 0) : base(Name, Surname, Birthday)
        {
            _artistName = artistName;
            _albums = new List<AlbumDTO>();

            _bio = bio;
            _groups = new List<GroupDTO>();
            _rating = rating;
        }

        public int GenerateRating()
        {
            foreach (AlbumDTO album in Albums)
            {
                int rat = Albums.Sum(x => x.CalculateRating());
                Rating = rat;
            }
            return Rating;
        }
        public void CreateNewSong(string genre, string title, int duration, string releaseDate)
        {
            MediaDTO song = new(genre, title, duration, releaseDate, this);

            Songs.Add(song);
        }

        public void ShowMeSongList()
        {
            try
            {
                if (Songs == null) { throw new InvalidOperationException($"The Artist {this.ArtistName} has no songs! "); }
                Console.WriteLine($"This is the song list of the artist {this.ArtistName}: ");
                int i = 1;
                foreach (MediaDTO song in Songs) { Console.WriteLine(i++ + "-" + song.Title); }


            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Error:" + " " + e.Message);
            }





        }

        public string ArtistName { get => _artistName; set => _artistName = value; }
            public string Bio { get => _bio; set => _bio = value; }

            public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
           public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
           public List<GroupDTO> Group1 { get => _groups; set => _groups = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
    }
