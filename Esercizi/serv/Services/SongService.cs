using Data.Repositories;
using System;

namespace Services
{
    public class SongService
    {
        private readonly SongRepo _songRepo;

        public SongService(SongRepo songRepo)
        {
            _songRepo = songRepo ?? throw new ArgumentNullException(nameof(songRepo));
        }

        public void AddItem<T>(T item, string propertyName)
        {
            _songRepo.AddItem(item, propertyName);
        }

        public void DisplayItems<T>(string propertyName)
        {
            _songRepo.DisplayItems<T>(propertyName);
        }
    }
}
