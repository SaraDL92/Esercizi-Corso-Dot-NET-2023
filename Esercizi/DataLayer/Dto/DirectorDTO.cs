using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class DirectorDTO
    {
        int _id;
        string _name;
        List<MediaDTO> _media = new List<MediaDTO>();

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        internal List<MediaDTO> Media { get => _media; set => _media = value; }
    }
}
