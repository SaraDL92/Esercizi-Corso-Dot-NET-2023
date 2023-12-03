using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Album
    {
        int _id;
        string _title;
        string _releaseDate;
        string _numbOfTracks;
        List <Artist> _artists=new List<Artist>();
        Group _group;
        bool _liveVersion;
        List<Song> _trackList;
        int _rating;

       
        internal string Title { get => _title; set => _title = value; }
       internal string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        internal string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
       internal bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
       internal int Rating { get => _rating; set => _rating = value; }
        internal int Id { get => _id; set => _id = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
        internal Group Group { get => _group; set => _group = value; }
        internal List<Song> TrackList { get => _trackList; set => _trackList = value; }
    }
}
