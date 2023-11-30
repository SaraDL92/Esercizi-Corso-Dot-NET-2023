using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class Album
  
        {
            string _title;
            string _releaseDate;
            string _numbOfTracks;
            Artist _artist;
            Group _group;
            bool _liveVersion;
            List<Media> _trackList;
        int _rating;
            public Album(string title, string releaseDate, string numbOfTracks, Artist artist, Group group, bool liveVersion)
            {
                _title = title;
                _releaseDate = releaseDate;
                _numbOfTracks = numbOfTracks;
                _artist = artist;
                _group = group;
                _liveVersion = liveVersion;
                _trackList = new List<Media>();
               
            
            }
        public int CalculateRating()
        {
            foreach (Media song in TrackList)
            {
               int rat= TrackList.Sum(x => x.Rating);
                Rating =rat;
            }return Rating;
        }

            public string Title { get => _title; set => _title = value; }
            public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
            public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
            public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
           public Artist Artist { get => _artist; set => _artist = value; }
           public Group Group { get => _group; set => _group = value; }
           public List<Media> TrackList { get => _trackList; set => _trackList = value; }
           public int Rating { get => _rating; set => _rating = value; }
    }
    }

