using SpotifyClone.Entities;
using SpotifyLibrary.ModelsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLibrary.DTOs
{
   public class ArtistDTO: CsvHelper.Configuration.ClassMap<Artist>
    {
        string _artistName;
        List<Album> _albums;
        List<Media> _songs = new List<Media>();
        string _bio;
        List<GroupDTO> _groups;
        int _rating;

        public ArtistDTO() {
            Map(m => m.ArtistName).Name("ARTISTNAME");
            Map(m => m.Bio).Name("BIOGRAPHY");
           

        }

        public string ArtistName { get => _artistName; set => _artistName = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Media> Songs { get => _songs; set => _songs = value; }
        public string Bio { get => _bio; set => _bio = value; }
        public List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        public int Rating { get => _rating; set => _rating = value; }
    }
}
