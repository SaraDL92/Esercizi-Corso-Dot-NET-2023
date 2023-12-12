using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using SpotifyClone.Entities;
using System.Linq;
using System;
using ServiceStack.Text;

namespace SpotifyClone.Repositories
{
    public class SpotifyRepository
    {
        private readonly string filePath;

        public SpotifyRepository(string filePath)
        {
            this.filePath = filePath;
        }

      
        public List<string> ReadCsvLines()
        {
            try
            {
                return File.ReadAllLines(filePath).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
                return new List<string>();
            }
        }

        public void WriteToCsv(List<string> lines)
        {
            try
            {
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to CSV file: {ex.Message}");
            }
        }


      

    }




}
