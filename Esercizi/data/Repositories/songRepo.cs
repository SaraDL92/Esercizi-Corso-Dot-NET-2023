using data.DB;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Data.Repositories
{
    public class SongRepo
    {
        private readonly db _database;

        public SongRepo(db database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public db Database { get => _database; }

        public void AddItem<T>(T item, string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            if (property != null && property.PropertyType == typeof(string))
            {
                string value = property.GetValue(item)?.ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    _database.SongList.Add(new data.Models.song(value));
                }
                else
                {
                    throw new ArgumentException($"La proprietà '{propertyName}' deve avere un valore non nullo o vuoto.");
                }
            }
            else
            {
                throw new ArgumentException($"La classe '{typeof(T).Name}' deve avere una proprietà '{propertyName}' di tipo string.");
            }
        }

        public void DisplayItems<T>(string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            if (property != null && property.PropertyType == typeof(string))
            {
                foreach (var item in _database.SongList)
                {
                    Console.WriteLine(property.GetValue(item));
                }
            }
            else
            {
                throw new ArgumentException($"La classe '{typeof(T).Name}' deve avere una proprietà '{propertyName}' di tipo string.");
            }
        }


    }

}
