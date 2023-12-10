using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.DTO;

namespace DataLayerT.Models
{
   public class MusicalGroup
    {
        string _name;
        List<Artist> _members;
        List<Album> _albums;
        List<Song> _songs;

        public MusicalGroup(GroupDTO group)
        {
            Name = group.Name;
            Members = new List<Artist>();
            foreach (ArtistDTO artist in group.Members)
            {
                Members.Add(new Artist(artist));
            }
            Albums = new List<Album>();
            foreach (AlbumDTO album in group.Albums) {
                Albums.Add(new Album(album));
            }
            Songs = new List<Song>();
            foreach(SongDTO song in group.Songs) {
            Songs.Add(new Song(song));}

        }


        public string Name { get => _name; set => _name = value; }
        public List<Artist> Members { get => _members; set => _members = value; }
        public List<Album> Albums { get => _albums; set => _albums = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
    }
}
