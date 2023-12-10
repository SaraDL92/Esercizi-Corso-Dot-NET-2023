using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
    public  class Playlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Song> Songs { get; set; }



        public Playlist() {  Songs = new List<Song>();}
      
    }
}
