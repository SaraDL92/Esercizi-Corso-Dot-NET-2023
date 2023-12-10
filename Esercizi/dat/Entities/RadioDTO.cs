using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
   public class Radio
    {
        string _name;
        List<MediaDTO> _songlist=new List<MediaDTO>();

        int _rating;
        public Radio(string name)
        {
            _name = name;
           
           
        }
        


      

        public string Name { get => _name; set => _name = value; }
        public List<MediaDTO> SongList { get => _songlist; set => _songlist = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}

