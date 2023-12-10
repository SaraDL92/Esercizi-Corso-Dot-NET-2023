using datalayer1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
    public class Song : Media
    { 
        public int Id { get; set; }
        public string? Title { get; set; }

        public Artist Artist { get; set; }

        public int Duration { get; set; }
        public Album Album { get; set; }

       
        

    }

}