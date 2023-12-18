using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class DirectorDTO
    {
        public int Id_Director { get; set; }
        public string NameOfDirector { get; set; }
        public List<MovieDTO> Movies { get; set; } = new List<MovieDTO>();

        public DirectorDTO() { }

        public DirectorDTO(string Name)
        {NameOfDirector=Name;

        }
    }
}
