using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
    public class DirectorDTO
    {
        string _name;
        List<Media> _media=new List<Media>();

        public DirectorDTO(string name) {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
