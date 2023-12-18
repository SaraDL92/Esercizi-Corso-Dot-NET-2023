using Spotify_DataLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
   public class Movie
    {

        public int Id_Movie { get; set; }
        public string TitleOfMovie { get; set; }
        public Director Director { get; set; }
    }
}
