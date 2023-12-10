using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.Models;

namespace DataLayerT.DTO
{
   public class AlbumDTO
    {
        string _title;
        List<SongDTO> _songs;
        ArtistDTO _artist;
        GroupDTO _group;

        public AlbumDTO(Album album)
        {
            Title = album.Title;
            Songs=new List<SongDTO>();
            
            Artist=new ArtistDTO(album.Artist);
            Group=new GroupDTO(album.Group);


        }
        public string Title { get => _title; set => _title = value; }
        public List<SongDTO> Songs { get => _songs; set => _songs = value; }
        internal ArtistDTO Artist { get => _artist; set => _artist = value; }
        internal GroupDTO Group { get => _group; set => _group = value; }
    }
}
