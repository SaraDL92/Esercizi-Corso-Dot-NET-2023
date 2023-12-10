using data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.DTO
{
    internal class ArtistDTO
    {
        string _name;
        List<SongDTO> _songlist=new List<SongDTO>();

        public ArtistDTO(Artist a)
        {
            _name = a.Name;
        }
        public ArtistDTO(string name)
        {
            _name=name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
