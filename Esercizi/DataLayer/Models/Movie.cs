using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Movie:Media
    {
        Director _director;

        internal Director Director1 { get => _director; set => _director = value; }
    }
}
