using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
    public class Media:IMedia
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }

        
    }
}
