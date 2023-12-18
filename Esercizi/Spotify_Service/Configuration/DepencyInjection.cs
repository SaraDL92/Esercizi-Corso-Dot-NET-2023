using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Mapper;
using Spotify_DataLayer.Repository;
using Spotify_Presentation;
using Spotify_Service.Interfaces;
using Spotify_Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_Service.Configuration
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            services = new ServiceCollection()
                   .AddSingleton<ISongRepository, SongRepository>()
                   .AddSingleton<IAlbumRepository, AlbumRepository>()
                   .AddSingleton<IArtistRepository, ArtistRepository>()
                   .AddSingleton<IRadioRepository, RadioRepository>()
                   .AddSingleton<IMovieRepository, MovieRepository>()
                   .AddSingleton<IDirectorRepository,DirectorRepository>()
                   .AddSingleton<IUserRepository, UserRepository>()
                   .AddSingleton<ISettingRepository, SettingRepository>()
                   .AddSingleton<IMusicService, MusicService>()
                   .AddSingleton<IUserService,UserService>()
                    .AddSingleton<IMovieService, MovieService>()
                  
                   .AddSingleton<MapperConfiguration>(cfg =>
                   {
                       var config = new MapperConfiguration(mc =>
                       {
                           mc.AddProfile(new MapperProfile());
                       });
                       return config;
                   })
                   .AddSingleton<IMapper>(sp => sp.GetRequiredService<MapperConfiguration>().CreateMapper());
                  

            return services;

        }
    }
}
