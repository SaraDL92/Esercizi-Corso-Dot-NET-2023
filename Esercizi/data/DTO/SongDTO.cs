using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Models;

namespace data.DTO
{
    public class SongDTO
    {
        private string _title;

        public SongDTO(song song)
        {
            _title = song.Title;
        }
        public SongDTO(string title)
        {
            _title = title;
        }

        public string Title { get => _title; set => _title = value; }
    }
}
