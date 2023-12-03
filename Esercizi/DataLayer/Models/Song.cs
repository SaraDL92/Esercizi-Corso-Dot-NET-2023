using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Song:Media
    {
        int _id;
        Group _group;
        Artist _artist;
        Album _album;
        List<Album> _albums = new List<Album>();
        List<Group> _groups = new List<Group>();
        List<Artist> _artists = new List<Artist>();

        public Song(string title, string genre, int duration, Artist artist,Group group,Album album,int rating) 
        {
            _id = _id + 1;
            Albums.Add(album);
            Artists.Add(artist);
            Groups.Add(group);
        }

        internal int Id1 { get => _id; set => _id = value; }
        internal Group Group1 { get => _group; set => _group = value; }
        internal Artist Artist { get => _artist; set => _artist = value; }
        internal Album Album { get => _album; set => _album = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        internal List<Group> Groups { get => _groups; set => _groups = value; }
        internal List<Artist> Artists { get => _artists; set => _artists = value; }
    }
}
