using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Dispositives
    {
        string _name;

        public Dispositives(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set => _name = value; }
    }
}
