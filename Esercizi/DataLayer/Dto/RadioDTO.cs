﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class RadioDTO
    {
        int _id;
        string _name;
        List<MediaDTO> _songlist = new List<MediaDTO>();

        int _rating;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal List<MediaDTO> Songlist { get => _songlist; set => _songlist = value; }
    }
}
