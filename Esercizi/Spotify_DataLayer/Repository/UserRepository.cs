using CsvHelper.Configuration;
using CsvHelper;
using Spotify_DataLayer.Interfaces;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify_DataLayer.Repository
{
    public class UserRepository:IUserRepository
    {


        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyUsers.csv";

        public List<User> ReadUsers()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<User>().ToList();
                }
            }

            return new List<User>();
        }
        public User ReadUserById(int Id)
        {
            var users = ReadUsers();
            return users.FirstOrDefault(u => u.Id_User == Id);
        }

        public void WriteUsers(List<User> users)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(users);
            }
        }
    }
}