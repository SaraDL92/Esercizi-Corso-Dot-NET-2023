using DataLayerT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerT.DTO
{ 
   public class ArtistDTO
    {
        string _name;
        string _description;
        List<SongDTO> _songs=new List<SongDTO>();
        List<AlbumDTO> _albums;
        List<GroupDTO> _group;

        public ArtistDTO(Artist a)
        {
            Name= a?.Name;
            Description = a?.Description;
            Songs=new List<SongDTO>();
            
            Albums= new List<AlbumDTO>();
            

            
            Groups = new List<GroupDTO>();
            


        }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public List<SongDTO> Songs { get => _songs; set => _songs = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        internal List<GroupDTO> Groups { get => _group; set => _group = value; }
    }
}
