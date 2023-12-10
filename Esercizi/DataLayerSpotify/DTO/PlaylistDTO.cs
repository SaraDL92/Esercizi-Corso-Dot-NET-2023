using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSpotify.DTO
{
    public class PlaylistDTO
    {
        private static int _nextid = 5;
        int _id;
        UserDTO _user;
        List<MediaDTO> _songs = new List<MediaDTO>();
        string _name;
        int _rating;

        public PlaylistDTO(PlayList playlist)
        {
            Id= playlist.Id;
            Name= playlist.Name;
            Rating= playlist.Rating;
            User=new UserDTO(playlist.User);
            foreach(Media m in playlist.Songs)
            {
                _songs.Add(new MediaDTO(m));
            }
        }

        public static int Nextid { get => _nextid; set => _nextid = value; }
        public int Id { get => _id; set => _id = value; }
        public UserDTO User { get => _user; set => _user = value; }
        public List<MediaDTO> Songs { get => _songs; set => _songs = value; }
        public string Name { get => _name; set => _name = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
