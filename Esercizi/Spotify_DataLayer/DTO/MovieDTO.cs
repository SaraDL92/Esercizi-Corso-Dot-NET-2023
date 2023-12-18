using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class MovieDTO
    {
        public int Id_Movie { get; set; }
        public string TitleOfMovie { get; set; }
        public DirectorDTO Director { get; set; }
        
        public MovieDTO()
        {

        }
        public MovieDTO(string title,DirectorDTO director) 
        { 
            TitleOfMovie = title;
            Director = director;
        
        }
    }
}
