using System.Collections.Generic;
using SpotifyClone.Entities;
using SpotifyClone.Repositories;

namespace SpotifyClone.Services
{
    public class SpotifyService
    {
        private readonly SpotifyRepository repository;

        public SpotifyService(SpotifyRepository repository)
        {
            this.repository = repository;
        }

        public List<AlbumDTO> GetAllAlbums()
        {
            return repository.ReadAlbumsFromCsv();
        }

        public void AddAlbum(AlbumDTO album)
        {
            var albums = repository.ReadAlbumsFromCsv();
            albums.Add(album);
            repository.WriteAlbumsToCsv(albums);
        }

        public List<ArtistDTO> GetAllArtists()
        {
            return repository.ReadArtistsFromCsv();
        }

        public void AddArtist(ArtistDTO artist)
        {
            var artists = repository.ReadArtistsFromCsv();
            artists.Add(artist);
            repository.WriteArtistsToCsv(artists);
        }

       
    }
}
