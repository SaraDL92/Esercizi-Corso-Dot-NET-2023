using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using datalayer1.DbContext;
using datalayer1.DTO;
using datalayer1.Models;
using datalayer1.Repositories;

namespace servicelayer1
{
    public class Service
    {

        readonly Repository _myRepository;
        

        public Service(Repository myRepository)
        {
            _myRepository = myRepository;
        }

       public  TEntity MapDTOToEntity<TDTO, TEntity>(TDTO dto) where TDTO : class where TEntity : class
        {
            TEntity entity = Activator.CreateInstance<TEntity>();

            PropertyInfo[] dtoProperties = typeof(TDTO).GetProperties();
            PropertyInfo[] entityProperties = typeof(TEntity).GetProperties();

            foreach (var dtoProperty in dtoProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(p => p.Name == dtoProperty.Name);
                if (entityProperty != null && entityProperty.PropertyType == dtoProperty.PropertyType)
                {
                    var value = dtoProperty.GetValue(dto);
                    entityProperty.SetValue(entity, value);
                }
            }

            return entity;
        }
       public List<TEntity> MapDTOListToEntityList<TDTO, TEntity>(List<TDTO> dtoList) where TDTO : class where TEntity : class
        {
            List<TEntity> entityList = new List<TEntity>();

            foreach (var dto in dtoList)
            {
                TEntity entity = MapDTOToEntity<TDTO, TEntity>(dto);
                entityList.Add(entity);
            }

            return entityList;
        }

       public TDTO MapEntityToDTO<TEntity, TDTO>(TEntity entity) where TEntity : class where TDTO : class
        {
            TDTO dto = Activator.CreateInstance<TDTO>();

            PropertyInfo[] entityProperties = typeof(TEntity).GetProperties();
            PropertyInfo[] dtoProperties = typeof(TDTO).GetProperties();

            foreach (var entityProperty in entityProperties)
            {
                var dtoProperty = dtoProperties.FirstOrDefault(p => p.Name == entityProperty.Name);
                if (dtoProperty != null && dtoProperty.PropertyType == entityProperty.PropertyType)
                {
                    var value = entityProperty.GetValue(entity);
                    dtoProperty.SetValue(dto, value);
                }
            }

            return dto;
        }
    

    public void AddItemDTO<TDTO, TEntity>(TDTO dto) where TDTO : class where TEntity : class
        {
            if (typeof(TEntity) == typeof(Song))
            {
                var songDto = dto as SongDTO;
                Song songEntity = new()
                {
                    Id = songDto.Id,
                    Artist = MapDTOToEntity<ArtistDTO,Artist>(songDto.Artist),
                    Title = songDto.Title,
                    Duration = songDto.Duration,
               Album=MapDTOToEntity<AlbumDTO,Album>(songDto.Album),
               
              
                  
                  

                    
                };songEntity.Album.Songs.Add(songEntity); 
                songEntity.Artist.Songs.Add(songEntity);


                // Assicurati che l'album esista prima di associarl alla canzone

                _myRepository.AddItem(songEntity);
                   
            
               
            }
            else if (typeof(TEntity) == typeof(Movie))
            {
                var movieDto = dto as MovieDTO;
                Movie movieEntity = new()
                {
                    Id = movieDto.Id,
                    Director = movieDto.Director,
                    Title = movieDto.Title,
                    Duration = movieDto.Duration
                };
                _myRepository.AddItem(movieEntity);
            }
            else if (typeof(TEntity) == typeof(Album))
            {
                var albumDto = dto as AlbumDTO;
                Album albumEntity = new()
                {
                    Id = albumDto.Id,
                    Title = albumDto.Title,
                    Duration = albumDto.Duration,
                    Artist = MapDTOToEntity<ArtistDTO, Artist>(albumDto.Artist),
                    Songs = MapDTOListToEntityList<SongDTO, Song>(albumDto.Songs)
                };
                _myRepository.AddItem(albumEntity); albumEntity.Artist.Albums.Add(albumEntity);
            }
            else if (typeof(TEntity) == typeof(Playlist))
            {
                var playlistDto = dto as PlaylistDTO;
                Playlist playlistEntity = new()
                {
                    Id = playlistDto.Id,
                    Title = playlistDto.Title1,
                    
                    Songs = MapDTOListToEntityList<SongDTO, Song>(playlistDto.Songs)
                };
                _myRepository.AddItem(playlistEntity); 
            }
            else if (typeof(TEntity) == typeof(Artist))
            {
                var artistDto = dto as ArtistDTO;
               Artist artistEntity = new()
                {
                    Id = artistDto.Id,
                    Name = artistDto.Name,
                    Albums= MapDTOListToEntityList<AlbumDTO,Album>(artistDto.Albums),
                    Songs = MapDTOListToEntityList<SongDTO, Song>(artistDto.Songs)

                  
                };
                _myRepository.AddItem(artistEntity);
            }
            else
            {
                throw new ArgumentException($"Unsupported type: {typeof(TEntity)}");
            }
        }

        public List<TEntity> GetAllItems<TEntity>(string filepath) where TEntity : class
        {
            var items = _myRepository.GetAllItems<TEntity>(filepath);

           

            return items;
        }

        public T GetItemById<T>(int id) where T : class
        {
            return _myRepository.GetItemById<T>(id);
        }

    }
}