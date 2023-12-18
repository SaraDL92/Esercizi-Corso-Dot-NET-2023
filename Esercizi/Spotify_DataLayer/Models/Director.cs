using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Director
    {

        public int Id_Director { get; set; }
        public string NameOfDirector { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
