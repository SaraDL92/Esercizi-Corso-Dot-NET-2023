using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datalayer1.DTO
{
   public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public static int count { get; set; }


        public List<AlbumDTO> Albums = new List<AlbumDTO>();

        public List<SongDTO> Songs = new List<SongDTO>();

        public ArtistDTO(string name)
        {
            int i = 1;
            count = count + 1;
            Id = count;
            Name = name;
            Albums = new List<AlbumDTO>();
            Songs = new List<SongDTO>();
        }

    }
}

