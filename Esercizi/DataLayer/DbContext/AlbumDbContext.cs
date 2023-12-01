using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.DbContext
{
    internal class AlbumDbContext
    {
        List<Album> _albums;

        internal List<Album> Albums { get => _albums; set => _albums = value; }
    }
}
