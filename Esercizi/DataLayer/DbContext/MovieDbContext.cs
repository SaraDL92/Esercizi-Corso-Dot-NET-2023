using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class MovieDbContext
    {
        List<Movie> _movies;

        internal List<Movie> Movies { get => _movies; set => _movies = value; }
    }
}
