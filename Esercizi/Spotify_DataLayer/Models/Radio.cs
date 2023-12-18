using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Models
{
    public class Radio
    {
        public int Id_Radio { get; set; }
        public string TitleOfRadio { get; set; }
        public List <Song> Songs { get; set; }
    }
}
