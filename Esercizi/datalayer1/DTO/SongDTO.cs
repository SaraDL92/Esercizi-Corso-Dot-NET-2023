using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
   public class SongDTO:MediaDTO
    {
        public int Id { get; set; }
        static int count;
        public string? Title { get; set; }

        public ArtistDTO Artist { get; set; }
        public int Duration{ get; set; }

        public AlbumDTO Album { get; set; }


        

        public SongDTO(string title, ArtistDTO artist, int duration, AlbumDTO album):base(title,duration) {
            int i = 1;
            count = count + 1;
            Id = count ;
            Title = title;
            Artist = artist;
            Duration = duration;
            Album = album;
            Album.Songs.Add(this);
            Artist.Songs.Add(this);

        }
        public SongDTO(string title, ArtistDTO artist, int duration) : base(title, duration)
        {
            int i = 1;
            count = count + 1;
            Id = count;
            Title = title;
            Artist = artist;
            Duration = duration; Album.Songs.Add(this);
            Artist.Songs.Add(this);


        }


    }
}
