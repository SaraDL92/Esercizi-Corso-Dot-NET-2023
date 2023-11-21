using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Album
    {
        string _title;
        string _releaseDate;
        string _numbOfTracks;
        Artist _artist;
        Group _group;
        bool _liveVersion;
        List <Song> _trackList;

        public Album(string title, string releaseDate, string numbOfTracks, Artist artist, Group group, bool liveVersion, List<Song> trackList)
        {
            _title = title;
            _releaseDate = releaseDate;
            _numbOfTracks = numbOfTracks;
            _artist = artist;
            _group = group;
            _liveVersion = liveVersion;
            _trackList = trackList;
        }

        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
        public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
        internal Artist Artist { get => _artist; set => _artist = value; }
        internal Group Group { get => _group; set => _group = value; }
        internal List<Song> TrackList { get => _trackList; set => _trackList = value; }
    }
}
