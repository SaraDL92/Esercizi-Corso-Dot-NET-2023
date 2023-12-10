using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
  public class Artist
    {

        public int Id { get; set; }
        public string Name { get; set; }


        public List<Album> Albums = new List<Album>();

        public List<Song> Songs = new List<Song>();

        public Artist()
        {Albums = new List<Album>();
         Songs = new List<Song>();
        }

    }
}
