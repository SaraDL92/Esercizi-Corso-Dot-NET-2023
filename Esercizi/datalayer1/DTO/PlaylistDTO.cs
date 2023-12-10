using datalayer1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
    public class PlaylistDTO
    {
        public int Id { get; set; }
        static int count;
        public string Title1 { get; set; }

        public List<SongDTO> Songs {  get; set; }

        

        public PlaylistDTO(string title, int duration) 
        {

            int i = 1;
            count = count + 1;
            Id = count;
            
            Title1 = title;
            Songs = new List<SongDTO>();

           

        }



    }
}

