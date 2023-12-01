using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class AlbumDTO
    {
        int _id;
        string _title;
        string _releaseDate;
        string _numbOfTracks;
        ArtistDTO _artist;
        GroupDTO _group;
        bool _liveVersion;
        List<MediaDTO> _trackList;
        int _rating;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
        public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal ArtistDTO Artist { get => _artist; set => _artist = value; }
        internal GroupDTO Group { get => _group; set => _group = value; }
        internal List<MediaDTO> TrackList { get => _trackList; set => _trackList = value; }
    }
}
