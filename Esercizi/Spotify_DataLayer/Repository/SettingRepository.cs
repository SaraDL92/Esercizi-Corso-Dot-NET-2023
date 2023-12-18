using CsvHelper.Configuration;
using CsvHelper;
using Spotify_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spotify_DataLayer.Interfaces;

namespace Spotify_DataLayer.Repository
{
    public class SettingRepository:ISettingRepository
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifySettingsOfUsers.csv";

        public List<Setting> ReadSettings()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Setting>().ToList();
                }
            }

            return new List<Setting>();
        }
        public Setting ReadSettingById(int Id)
        {
            var settings = ReadSettings();
            return settings.FirstOrDefault(s => s.Id_Setting == Id);
        }

        public void WriteSettings(List<Setting> settings)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(settings);
            }
        }
    }
}