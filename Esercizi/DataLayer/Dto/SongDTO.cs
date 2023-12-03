using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class SongDTO:MediaDTO
    {
        int _id;
        GroupDTO _group;
        ArtistDTO _artist;
        AlbumDTO _album;
        List<AlbumDTO> _albums = new List<AlbumDTO>();
        List<GroupDTO> _groups = new List<GroupDTO>();
        List<ArtistDTO> _artists = new List<ArtistDTO>();
        public SongDTO(Song song):base(song) {
            Id = song.Id;
            Group = new GroupDTO(song.Group1);
            Artist = new ArtistDTO(song.Artist);
            Album = new AlbumDTO(song.Album);
            Albums=song.Albums.Select(a=>new AlbumDTO(a)).ToList();
            Groups=song.Groups.Select(g=>new GroupDTO(g)).ToList();
            Artists=song.Artists.Select(Artist=>new ArtistDTO(Artist)).ToList();


           
            Artists = song.Artists.Select(artist => new ArtistDTO(artist)).ToList(); }
        

          
        

        public int Id1 { get => _id; set => _id = value; }
        internal GroupDTO Group { get => _group; set => _group = value; }
        internal ArtistDTO Artist { get => _artist; set => _artist = value; }
        internal AlbumDTO Album { get => _album; set => _album = value; }
        internal List<AlbumDTO> Albums { get => _albums; set => _albums = value; }
        internal List<GroupDTO> Groups { get => _groups; set => _groups = value; }
        internal List<ArtistDTO> Artists { get => _artists; set => _artists = value; }
    }
}
