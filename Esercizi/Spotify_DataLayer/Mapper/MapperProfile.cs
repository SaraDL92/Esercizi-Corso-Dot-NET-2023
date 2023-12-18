using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Spotify_DataLayer.Models;
using Spotify_DataLayer.DTO;



namespace Spotify_DataLayer.Mapper
{

public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            
            CreateMap<Song, SongDTO>();
            CreateMap<SongDTO, Song>();
            CreateMap<Album, AlbumDTO>();
            CreateMap<AlbumDTO, Album>();
            CreateMap<Artist, ArtistDTO>();
            CreateMap<ArtistDTO, Artist>();
            CreateMap<Radio,RadioDTO>();
            CreateMap<RadioDTO, Radio>();
            CreateMap<MovieDTO, Movie>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<DirectorDTO, Director>();
            CreateMap<Director, DirectorDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<SettingDTO, Setting>();
            CreateMap<Setting, SettingDTO>();
        }
    }

}

