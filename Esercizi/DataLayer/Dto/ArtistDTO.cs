using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class ArtistDTO:PersonDTO
    {
        int _id;
        string _artistName;
        List<AlbumDTO> _albums;
        List<MediaDTO> _songs = new List<MediaDTO>();
        string _bio;
        List<GroupDTO> _groups;
        int _rating;

        public int Id { get => _id; set => _id = value; }
        public string ArtistName { get => _artistName; set => _artistName = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        internal List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        internal List<GroupDTO> Groups { get => _groups; set => _groups = value; }
    }
}
