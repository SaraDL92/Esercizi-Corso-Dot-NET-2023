using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
namespace DataLayer.DbContext
{
    internal class ArtistDbContext
    {
        List<Artist> _artists;

        internal List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
