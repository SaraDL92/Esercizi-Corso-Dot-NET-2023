using DataLayerT.DTO;
using System;
using System.Collections.Generic;

namespace DataLayerT.Models
{
    public class Song
    {
        static int count;
        int id;
        string _title;
        int _rating;
        Artist artist;
        MusicalGroup group;
        List<Album> album=new List<Album>();
       

      public Song(string title,Artist _artist, Album _album)
        {
            id = count+1;
            artist = _artist;
            Album.Add(_album);
           

        }
        public Song (SongDTO song)
        {
            id = song.Id;
            Title = song.Title;
            Rating = song.Rating;
            Artist = new Artist(song.Artist);
            Album = new List<Album>();
            foreach (AlbumDTO a in song.Albums)
            {
                album.Add(new Album(a));
            }
        }

        public int Id { get => id; set => id = value; }
        public string Title { get => _title; set => _title = value; }
        public int Rating { get => _rating; set => _rating = value; }
        public Artist Artist { get => artist; set => artist = value; }
        public MusicalGroup Group { get => group; set => group = value; }
        public List<Album> Album { get => album; set => album = value; }
    }
}
