using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
    public class MovieDTO:MediaDTO
    {
        public int Id { get; set; }
        static int count;
        public string? Title { get; set; }

        public string? Director { get; set; }

        public int Duration {  get; set; }

        public MovieDTO(string title, string artist, int duration):base(title,duration)
        {
            int i = 1;
            count = count + 1;
            Id = count;
   
            Title = title;
            Director = artist;
            Duration = duration;
        }
    }
}
