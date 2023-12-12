using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class GroupDTO
    {
        string _name;
        List<Artist> _members;
        List<Media> _songs;
        List<Album> _albums;
        string _bio;

        public GroupDTO(string name, List<Artist> members, List<Media> songs, List<Album> albums, string bio)
        {
            _name = name;
            _members = members;
            _songs = songs;
            _albums = albums;
            _bio = bio;
        }
        public GroupDTO() { }
        public string Name { get => _name; set => _name = value; }
        public string Bio { get => _bio; set => _bio = value; }
        internal List<Artist> Members { get => _members; set => _members = value; }
        internal List<Media> Songs { get => _songs; set => _songs = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }

    }
}
