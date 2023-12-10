using DataLayerT.Models;
using System.Collections.Generic;

namespace DataLayerT.DTO
{
    public class GroupDTO
    {
        string? _name;
        List<ArtistDTO> _members = new List<ArtistDTO>();
        List<AlbumDTO>? _albums;
        List<SongDTO>? _songs;

        public GroupDTO(MusicalGroup group)
        {
            Name = group?.Name;
            Members = new List<ArtistDTO>();

            if (group?.Members != null)
            {
                foreach (Artist artist in group.Members)
                {
                    Members?.Add(new ArtistDTO(artist));
                }
            }

            Albums = new List<AlbumDTO>();
            if (group?.Albums != null)
            {
                foreach (Album album in group.Albums)
                {
                    Albums?.Add(new AlbumDTO(album));
                }
            }

            Songs = new List<SongDTO>();
            if (group?.Songs != null)
            {
                foreach (Song song in group.Songs)
                {
                    Songs?.Add(new SongDTO(song));
                }
            }
        }

        public string? Name { get => _name; set => _name = value; }
        public List<SongDTO>? Songs { get => _songs; set => _songs = value; }
        internal List<ArtistDTO> Members { get => _members; set => _members = value; }
        internal List<AlbumDTO>? Albums { get => _albums; set => _albums = value; }
    }
}
