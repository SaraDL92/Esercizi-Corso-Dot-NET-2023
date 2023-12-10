using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Entities;

namespace DataLayerSpotify.DTO
{
    public class GroupDTO
    {
        string _name;
        List<ArtistDTO> _members;
        List<MediaDTO> _songs;
        List<AlbumDTO> _albums;
        string _bio;

        public GroupDTO(Group g){
            Name = g.Name;
            _members = new List<ArtistDTO>();
            foreach(Artist a in g.Members)
            {
                _members.Add(new ArtistDTO(a));
            }
            _songs = new List<MediaDTO>();

            foreach(Media m in g.Songs)
            {
                _songs.Add(new MediaDTO(m));
            }

            foreach(Album a in g.Albums)
            {
                _albums.Add(new AlbumDTO(a));
            }
            _albums = new List<AlbumDTO>();
            _bio= g.Bio;
}
       
        public string Name { get => _name; set => _name = value; }
        public List<ArtistDTO> Members { get => _members; set => _members = value; }
        public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        public List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        public string Bio { get => _bio; set => _bio = value; }
    }
}
