using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.DTO
{
    public class RadioDTO
    {
        public int Id_Radio { get; set; }
        public string TitleOfRadio { get; set; }
        public List<SongDTO> Songs { get; set; }=new List<SongDTO>();

        public RadioDTO() { }
        public RadioDTO(string title, List <SongDTO> songs) 
        {TitleOfRadio = title;
            Songs = songs;
      
        }
    }
}
