using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.Models
{
    internal class Radio
    {
        public int Id { get; set; }
        public string Title { get; set; }




        public List<Song> Songs = new List<Song>();
    }
}
