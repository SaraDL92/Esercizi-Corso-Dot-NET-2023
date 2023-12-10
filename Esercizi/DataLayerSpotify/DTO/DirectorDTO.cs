using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Entities;

namespace DataLayerSpotify.DTO
{
   public class DirectorDTO
    {
        string _name;
        List<MediaDTO> _media = new List<MediaDTO>();

        public DirectorDTO(Director director)
        {
            Name = director.Name;
            foreach (var item in director.Media)
            {
                _media.Add(new MediaDTO(item));
            }
        }
        public string Name { get => _name; set => _name = value; }
        public List<MediaDTO> Media { get => _media; set => _media = value; }
    }
}
