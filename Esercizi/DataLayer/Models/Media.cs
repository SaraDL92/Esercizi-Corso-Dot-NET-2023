using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Media
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

        public Media(string title, string genre, int duration, int rating)
            
        {
            _title = title;
            _genre = genre;
            _duration = duration;
            _rating=rating;
        }

        internal static int Personalrating { get => personalrating; set => personalrating = value; }
        internal int Rating { get => _rating; set => _rating = value; }
        internal static int Nextid { get => _nextid; set => _nextid = value; }
       internal int Id { get => _id; set => _id = value; }
       internal string Genre { get => _genre; set => _genre = value; }
       internal string Title { get => _title; set => _title = value; }
       internal int Duration { get => _duration; set => _duration = value; }
       internal string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
       internal List<PlayList> Playlists { get => _playlists; set => _playlists = value; }
    }
}
