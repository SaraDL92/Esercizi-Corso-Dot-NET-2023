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
    public class RadioRepository:IRadioRepository
    {
        private const string FilePath = "C:\\Users\\sarad\\Documents\\SpotifyRadios.csv";

        public List<Radio> ReadRadios()
        {
            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<Radio>().ToList();
                }
            }

            return new List<Radio>();
        }
        public Radio ReadRadioById(int radioId)
        {
            var radios = ReadRadios();
            return radios.FirstOrDefault(a => a.Id_Radio == radioId);
        }
        public void WriteRadios(List<Radio> radios)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                csv.WriteRecords(radios);
            }
        }
    }
}