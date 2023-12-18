using System;
using System.Collections.Generic;
using AutoMapper;
using Spotify_DataLayer.Repository;
using Spotify_DataLayer.DTO;
using Spotify_DataLayer.Models;
using Spotify_Service.Interfaces;
using Spotify_DataLayer.Interfaces;

namespace Spotify_Service.Services
{
    public class MusicService : IMusicService
    {
        private readonly ISongRepository _songRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtistRepository _artistRepository;
        private readonly IRadioRepository _radioRepository;
        private readonly IMapper _mapper;

        public MusicService(ISongRepository songRepository, IAlbumRepository albumRepository, IArtistRepository artistRepository, IRadioRepository radioRepository, IMapper mapper)
        {
            _songRepository = songRepository;
            _albumRepository = albumRepository;
            _artistRepository = artistRepository;
            _radioRepository = radioRepository;
            _mapper = mapper;
        }

        public List<SongDTO> GetAllSongs()
        {
            var songs = _songRepository.ReadSongs();
            return _mapper.Map<List<SongDTO>>(songs);
        }
        public SongDTO GetSongById(int songId)
        {
            var song = _songRepository.ReadSongById(songId);

            if (song == null)
            {

                return null;
            }

            return _mapper.Map<SongDTO>(song);
        }
        public AlbumDTO GetAlbumById(int Id)
        {
            var album = _albumRepository.ReadAlbumById(Id);

            if (album == null)
            {

                return null;
            }

            return _mapper.Map<AlbumDTO>(album);
        }
        public RadioDTO GetRadioById(int Id)
        {
            var radio = _radioRepository.ReadRadioById(Id);

            if (radio == null)
            {

                return null;
            }

            return _mapper.Map<RadioDTO>(radio);
        }

        public ArtistDTO GetArtistById(int Id)
        {
            var artist = _artistRepository.ReadArtistById(Id);

            if (artist == null)
            {

                return null;
            }

            return _mapper.Map<ArtistDTO>(artist);
        }
        public void AddSong(SongDTO newSong)
        {
            var songs = _songRepository.ReadSongs();
            int nuovoId = songs.Count + 1;

            var song = _mapper.Map<Song>(newSong);
            song.Id_Song = nuovoId;

            songs.Add(song);
            _songRepository.WriteSongs(songs);
            AddSongToAlbum(newSong.AlbumOfSong);
        }
        public List<AlbumDTO> GetAllAlbums()
        {
            var albums = _albumRepository.ReadAlbums();
            return _mapper.Map<List<AlbumDTO>>(albums);
        }
        public List<SongDTO> GetAllAlbumSongs(AlbumDTO albumDTO)
        {   var album=_mapper.Map<Album>(albumDTO);
            var albumSongs = _albumRepository.ReadAlbumSongs(album);
            return _mapper.Map<List<SongDTO>>(albumSongs);
        }
        public void AddSongToAlbum(AlbumDTO album)
        {
            var songs = album.Songs;

            int i = 0;
            foreach (SongDTO s in songs) {i++;
                s.Id_Song = i;
            }

           
            _albumRepository.WriteAlbumSongs(_mapper.Map<List<Song>>(songs), album.TitleOfAlbum);
        }

        public void AddAlbum(AlbumDTO newAlbum)
        {
            var albums = _albumRepository.ReadAlbums();
            int nuovoId = albums.Count + 1;

            var album = _mapper.Map<Album>(newAlbum);
            album.Id_Album = nuovoId;

            albums.Add(album);
            _albumRepository.WriteAlbums(albums);
        }
        public List<ArtistDTO> GetAllArtists()
        {
            var artists = _artistRepository.ReadArtists();
            return _mapper.Map<List<ArtistDTO>>(artists);
        }

        public void AddArtist(ArtistDTO newArtist)
        {
            var artists = _artistRepository.ReadArtists();
            int nuovoId = artists.Count + 1;

            var artist = _mapper.Map<Artist>(newArtist);
            artist.Id_Artist = nuovoId;

            artists.Add(artist);
            _artistRepository.WriteArtists(artists);
        }
        public List<RadioDTO> GetAllRadios()
        {
            var radios = _radioRepository.ReadRadios();
            return _mapper.Map<List<RadioDTO>>(radios);
        }

        public void AddRadio(RadioDTO newRadio)
        {
            var radios = _radioRepository.ReadRadios();
            int nuovoId = radios.Count + 1;

            var radio = _mapper.Map<Radio>(newRadio);
            radio.Id_Radio = nuovoId;

            radios.Add(radio);
            _radioRepository.WriteRadios(radios);
        }
        public void AddSongToRadio(SongDTO song, RadioDTO radio)
        {
           

            radio.Songs.Add(song);
        }
       
        public void SaveOnFile()
        {

        }
    }
}