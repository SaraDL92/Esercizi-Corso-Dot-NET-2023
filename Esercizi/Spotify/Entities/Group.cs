using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Entities
{
    internal class Group
    {
        string _name;
        List<Artist> _members;
        List<Song> _songs;
        List<Album> _albums;
        string _bio;

        public Group(string name, List<Artist> members, List<Song> songs, List<Album> albums, string bio)
        {
            _name = name;
            _members = members;
            _songs = songs;
            _albums = albums;
            _bio = bio;
        }

        public string Name { get => _name; set => _name = value; }
        public string Bio { get => _bio; set => _bio = value; }
        internal List<Artist> Members { get => _members; set => _members = value; }
        internal List<Song> Songs { get => _songs; set => _songs = value; }
        internal List<Album> Albums { get => _albums; set => _albums = value; }
        
        
        
        public void CreateNewSong(string genre, string title, int duration, string releaseDate, List<Album> albums,  List<Artist> artists)
    {
        Song song = new(genre, title, duration, releaseDate, albums,this, artists);
        
        

        
            



    } 

    public void RemoveSong(Song song)
    {
            Songs.Remove(song);
    }
    public void AddArtist(Artist artist)
    {
            Members.Add(artist);
    }
    public void RemoveArtist(Artist artist)
    {
            Members.Remove(artist);
    }
    public void AddAlbum(Album album)
    {
            Albums.Add(album);
    }
    public void RemoveAlbum(Album album)
    {
            Albums.Remove(album);
    }
    }

    
}
