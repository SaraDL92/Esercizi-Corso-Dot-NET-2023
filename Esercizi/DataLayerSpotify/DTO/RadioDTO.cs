using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSpotify.DTO
{
    public class RadioDTO
    {
        string _name;
        List<MediaDTO> _songlist = new List<MediaDTO>();

        int _rating;

        public RadioDTO(Radio r) {
        Name=r.Name;
            foreach(Media m in r.SongList)
            {
                _songlist.Add(new MediaDTO(m));
            }
            Rating = r.Rating;
        }
        public string Name { get => _name; set => _name = value; }
        public List<MediaDTO> Songlist { get => _songlist; set => _songlist = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
