using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.Dto
{
    internal class AlbumDTO
    {
        int _id;
        string _title;
        string _releaseDate;
        string _numbOfTracks;
        List <ArtistDTO>_artists=new List<ArtistDTO>();
        GroupDTO _group;
        bool _liveVersion;
        List<SongDTO> _trackList;
        int _rating;
        public AlbumDTO(Album album)
        {
            Id = album.Id;
            Title = album.Title;
            ReleaseDate = album.ReleaseDate;
            Rating = album.Rating;
            NumbOfTracks = album.NumbOfTracks;
            Artists = album.Artists.Select(artist => new ArtistDTO(artist)).ToList();
            Group=new GroupDTO(album.Group);
            LiveVersion=album.LiveVersion;
            TrackList = album.TrackList.Select(song => new SongDTO(song)).ToList();
           Rating=album.Rating;

        }

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public string NumbOfTracks { get => _numbOfTracks; set => _numbOfTracks = value; }
        public bool LiveVersion { get => _liveVersion; set => _liveVersion = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal List <ArtistDTO> Artists { get => _artists; set => _artists = value; }
        internal GroupDTO Group { get => _group; set => _group = value; }
        internal List<SongDTO> TrackList { get => _trackList; set => _trackList = value; }
    }
}
