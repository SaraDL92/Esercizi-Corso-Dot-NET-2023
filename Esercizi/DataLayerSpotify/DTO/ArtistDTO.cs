using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Entities;

namespace DataLayerSpotify.DTO
{
public class ArtistDTO
    {
        string _artistName;
        List<AlbumDTO> _albums;
        List<MediaDTO> _songs = new List<MediaDTO>();
        string _bio;
        List<GroupDTO> _groups;
        int _rating;
        int GenerateRating;

        public ArtistDTO(Artist artist)
        {
          _artistName = artist.Name;
            _albums = new List<AlbumDTO>();
            foreach(Album a  in artist.Albums)
            {
                _albums.Add(new AlbumDTO(a));
            }
            _songs = new List<MediaDTO>(); 
            foreach(Media s in artist.Songs)
            {
                _songs.Add(new MediaDTO(s));
            }
            _groups = new List<GroupDTO>();
            foreach(Group g in artist.Group1)
            {
                _groups.Add(new GroupDTO(g));
            }
            _bio = artist.Bio;
            _rating = artist.Rating;
            GenerateRating = artist.GenerateRating();

        }

        public string ArtistName { get => _artistName; set => _artistName = value; }
        public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public int GenerateRating1 { get => GenerateRating; set => GenerateRating = value; }
    }
}
