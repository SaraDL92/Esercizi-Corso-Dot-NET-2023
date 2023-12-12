

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using ServiceStack.Text;
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

        public List<string> GetAll()
        {
            return repository.ReadCsvLines();
        }

        public void AddObject<T>(T obj)
        {
            var albums = repository.ReadCsvLines();
            albums.Add(CsvSerializer.SerializeToString(obj));
            repository.WriteToCsv(albums);
        }

        public void AddObjects<T>(List<T> objects)
        {
            var lines = repository.ReadCsvLines();
            var existingObjects = lines.ConvertAll(line => CsvSerializer.DeserializeFromString<T>(line));
            existingObjects.AddRange(objects);
            var updatedLines = existingObjects.ConvertAll(CsvSerializer.SerializeToString);
            repository.WriteToCsv(updatedLines);
        }

      
    }

}
