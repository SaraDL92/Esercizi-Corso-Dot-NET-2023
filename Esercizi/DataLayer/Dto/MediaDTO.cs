using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.Dto
{
    internal class MediaDTO
    {
        private static int personalrating = 0;
        int _rating = personalrating;
        private static int _nextid = 1;
        int _id;
        string _genre;
        string _title;
        int _duration;
        string _releaseDate;

        List<PlayList> _playlists = new List<PlayList>();

        public MediaDTO (Media media)
        {Rating = media.Rating;
            Id = media.Id;
            Genre= media.Genre;
            Title = media.Title;
            Duration = media.Duration;
            ReleaseDate = media.ReleaseDate;


        }

        public static int Personalrating { get => personalrating; set => personalrating = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public string Genre { get => _genre; set => _genre = value; }
        public string Title { get => _title; set => _title = value; }
        public int Duration { get => _duration; set => _duration = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
       
    }
}
