using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.Dto
{
    internal class MovieDTO:MediaDTO
    {
        Director _director;

        public MovieDTO(Movie movie):base(movie) 
        {
            Director = movie.Director1;
        }

        internal Director Director { get => _director; set => _director = value; }
    }
}
