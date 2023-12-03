using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.Dto
{
    internal class ArtistDTO : PersonDTO
    {
        int _id;
        string _artistName;
        List<AlbumDTO> _albums;
        List<SongDTO> _songs = new List<SongDTO>();
        string _bio;
        List<GroupDTO> _groups;
        int _rating;
        
        public ArtistDTO(Artist artist)
        {
            Id = artist.Id;
            ArtistName = artist.ArtistName;
            Bio = artist.Bio;
            Rating = artist.Rating;

            Albums = artist.Albums.Select(album => new AlbumDTO(album)).ToList();
            Songs = artist.Songs.Select(song => new SongDTO(song)).ToList();
            Groups = artist.Groups.Select(group => new GroupDTO( group)).ToList();

        }
        public int Id { get => _id; set => _id = value; }
        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        internal List<SongDTO> Songs { get => _songs; set => _songs = value; }
        internal List<GroupDTO> Groups { get => _groups; set => _groups = value; }
    }
}
