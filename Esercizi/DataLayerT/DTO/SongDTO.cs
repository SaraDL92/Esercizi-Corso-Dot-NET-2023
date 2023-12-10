using System;
using System.Collections.Generic;
using DataLayerT.Models;
namespace DataLayerT.DTO
{
    public class SongDTO
    {
        int id;
        string _title;
        int _rating;
        ArtistDTO artist;
        GroupDTO group;
       List<AlbumDTO> albums;
        public SongDTO(Song song)
        {
            Id=song.Id;
            Title=song.Title;
            Rating=song.Rating;
            Artist = new ArtistDTO(song.Artist);
            Albums = new List<AlbumDTO>();
            foreach(Album a in song.Album)
            {
                albums.Add(new AlbumDTO(a));
            }
            

        }
        public int Id { get => id; set => id = value; }
        public string Title { get => _title; set => _title = value; }
        public int Rating { get => _rating; set => _rating = value; }
        internal ArtistDTO Artist { get => artist; set => artist = value; }
        internal GroupDTO Group { get => group; set => group = value; }
        internal List<AlbumDTO> Albums { get => albums; set => albums = value; }
    }
}
