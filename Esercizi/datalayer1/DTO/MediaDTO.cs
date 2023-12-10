using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
   public class MediaDTO:IMediaDTO
    {public string Title { get; set;}
        public int Rating { get; set;}
        public int Duration { get; set;}

        public MediaDTO(string title,  int duration)
        {
            Title = title;
          
            Duration = duration;


        }
    }
}
