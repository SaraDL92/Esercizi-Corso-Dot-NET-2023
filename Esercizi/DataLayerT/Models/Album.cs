using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerT.DTO;

namespace DataLayerT.Models
{
    public class Album
    { static int count;
        int id;
        string _title;
        List<Song> _songs;
        Artist _artist;
        MusicalGroup _group;
        public Album(AlbumDTO album)
        {
            Title = album.Title;
            Songs = new List<Song>();
            foreach (SongDTO song in album.Songs)
            {
                Songs.Add(new Song(song));
            }
            Artist = new Artist(album.Artist);
            Group = new MusicalGroup(album.Group);


        }
        public Album(string title,Artist artist)
        {
            id = count + 1;
           
            
        }

        public string Title { get => _title; set => _title = value; }
        public List<Song> Songs { get => _songs; set => _songs = value; }
        public Artist Artist { get => _artist; set => _artist = value; }
        public MusicalGroup Group { get => _group; set => _group = value; }
        public int Id { get => id; set => id = value; }
    }
}
