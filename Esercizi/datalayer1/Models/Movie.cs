using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
   public class Movie:Media
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        public string? Director { get; set; }
        public int Duration { get; set; }
    }
}
