using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.DTO;

namespace DataLayerT.Models
{
   public class Artist
    {
        static int count;
        int id;
        string _name;
        string _description;
        List <Song> _songs;
        List<Album> _albums;
        List <MusicalGroup> _group;
        public Artist(ArtistDTO a)
        {
            Name = a.Name;
            Description = a.Description;
            Songs = new List<Song>();
            foreach (SongDTO s in a.Songs) { Songs.Add(new Song(s)); }
            Albums = new List<Album>();
            foreach (AlbumDTO album in a.Albums)
            {
                Albums.Add(new Album(album));
            }
            Group = new List<MusicalGroup>();
            foreach (GroupDTO g in a.Groups)
            {
                Group.Add(new MusicalGroup(g));
            }

           
        }
        public Artist(string name)
        {
            _name = name;
            id = count + 1;

        }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<MusicalGroup> Group { get => _group; set => _group = value; }
    }
}
