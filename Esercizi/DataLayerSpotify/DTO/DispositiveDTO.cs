using SpotifyClone.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerSpotify.DTO
{
    public class DispositiveDTO
    {
        string _name;

        public DispositiveDTO(Dispositives d) {
            Name = d.Name;
        }
        public string Name { get => _name; set => _name = value; }
    }
}
