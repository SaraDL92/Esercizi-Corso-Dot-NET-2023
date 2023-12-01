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

        public Song(string title, string genre, int duration, Artist artist,Group group,Album album,int rating) : base(title, genre, duration,rating)
        {
            _id = _id + 1;
            Albums1.Add(album);
            Artists1.Add(artist);
            Groups1.Add(group);
        }

        internal int Id1 { get => _id; set => _id = value; }
        internal Group Group1 { get => _group; set => _group = value; }
        internal Artist Artist1 { get => _artist; set => _artist = value; }
        internal Album Album1 { get => _album; set => _album = value; }
        internal List<Album> Albums1 { get => _albums; set => _albums = value; }
        internal List<Group> Groups1 { get => _groups; set => _groups = value; }
        internal List<Artist> Artists1 { get => _artists; set => _artists = value; }
    }
}
