using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class PlayListDbContext
    {
        List<PlayList> _playLists;

        internal List<PlayList> PlayLists { get => _playLists; set => _playLists = value; }
    }
}
