using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
   public class Radio
    {
        string _name;
        List<Song> _list;
        List<Album> _albums;

        public Radio(string name, List<Song> list, List<Album> albums)
        {
            _name = name;
            _list = list;
            _albums = albums;
        }

        public string Name { get => _name; set => _name = value; }
        internal List<Song> List { get => _list; set => _list = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
    }
}

