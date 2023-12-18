using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify_DataLayer.DTO;
using Spotify_DataLayer.Models;

namespace Spotify_Service.Interfaces
{
    public interface IMusicService
    {
        List<SongDTO> GetAllSongs();
        void AddSong(SongDTO nuovaCanzone);
        void SaveOnFile();

        List<AlbumDTO> GetAllAlbums();
        void AddAlbum(AlbumDTO newAlbum);
        List<ArtistDTO> GetAllArtists();
        void AddArtist(ArtistDTO newArtist);

        List<RadioDTO> GetAllRadios();
        void AddRadio(RadioDTO newRadio);
        void AddSongToRadio(SongDTO song, RadioDTO radio);

       

        SongDTO GetSongById(int Id);
       AlbumDTO GetAlbumById(int Id);
       ArtistDTO GetArtistById(int Id);
        RadioDTO GetRadioById(int Id);
        List<SongDTO> GetAllAlbumSongs(AlbumDTO album);
        void AddSongToAlbum(AlbumDTO Album);
    }
}
