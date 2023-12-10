using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Models;

namespace data.DB
{
    public class db
    {
        List<song> songList = new List<song>();

        public List<song> SongList { get => songList; set => songList = value; }
    }
}
