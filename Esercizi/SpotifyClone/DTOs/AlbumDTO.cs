using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLibrary.ModelsFolder
{
    public class AlbumDTO : CsvHelper.Configuration.ClassMap<AlbumDTO>
    {
        string _title;
        string _releaseDate;
        string _numbOfTracks;
        Artist _artist;
        GroupDTO _group;
        bool _liveVersion;
        List<Media> _trackList;
        int _rating;

        public AlbumDTO()
        {
            Map(m => m.Title).Name("TITLE");
            Map(m => m.Artist.ArtistName).Name("ARTIST");
            Map(m => m.ReleaseDate).Name("RELEASE DATE");
            Map(m => m.NumbOfTracks).Name("NUMB OF TRACKS");
            Map(m => m.Group.Name).Name("GROUP");
            Map(m => m.LiveVersion).Name("LIVE VERSION");
        }
      

        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public GroupDTO Group { get => _group; set => _group = value; }
        public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
        public List<Media> TrackList { get => _trackList; set => _trackList = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
