using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
    public class AlbumDTO : MediaDTO
    {public int Id { get; set; }
        static int count;
        public  string Title1 { get; set; }

        public List<SongDTO> Songs = new List<SongDTO>() ;
      
      public  ArtistDTO Artist{ get; set; }

        public AlbumDTO(string title,int duration,ArtistDTO
           artist):base(title,duration) { 
        
        int i = 1;
            count = count + 1;
            Id = count;
            Artist = artist;
            Title1 = title;
           
            Artist.Albums.Add(this);
            
        }

      

    }
}