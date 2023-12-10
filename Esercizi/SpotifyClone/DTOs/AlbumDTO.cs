using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class AlbumDTO
  
        {
            string _title;
            string _releaseDate;
            string _numbOfTracks;
            ArtistDTO _artist;
            GroupDTO _group;
            bool _liveVersion;
            List<MediaDTO> _trackList;
        int _rating;
            public AlbumDTO(string title, string releaseDate, string numbOfTracks, ArtistDTO artist, GroupDTO group, bool liveVersion)
            {
                _title = title;
                _releaseDate = releaseDate;
                _numbOfTracks = numbOfTracks;
                _artist = artist;
                _group = group;
                _liveVersion = liveVersion;
                _trackList = new List<MediaDTO>();
               
            
            }
        public int CalculateRating()
        {
            foreach (MediaDTO song in TrackList)
            {
               int rat= TrackList.Sum(x => x.Rating);
                Rating =rat;
            }return Rating;
        }

            public string Title { get => _title; set => _title = value; }
            public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
            public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
            public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
           public ArtistDTO Artist { get => _artist; set => _artist = value; }
           public GroupDTO Group { get => _group; set => _group = value; }
           public List<MediaDTO> TrackList { get => _trackList; set => _trackList = value; }
           public int Rating { get => _rating; set => _rating = value; }
    }
    }

