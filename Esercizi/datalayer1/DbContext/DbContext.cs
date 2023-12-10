using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace datalayer1.DbContext
{
    public class DbContext
    {
        public DbContext() { }
        public void WriteListToCsv<T>(string filePath, List<T> data)
        {
            try
            {if(File.Exists(filePath))
                {
                   File.Delete(filePath);
                }
               else if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.WriteRecords(data);
                }

                Console.WriteLine("Data written to CSV successfully.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void WriteSingleToCSV<T>(string filePath, T record)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (File.Create(filePath)) { }
                }

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false
                };

                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                using (CsvWriter csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.WriteRecord(record);
                    csvWriter.NextRecord();
                }

                Console.WriteLine("Data written to CSV successfully.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<T> ReadFromCsv<T>(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = false
                    };

                    using (StreamReader streamReader = new StreamReader(filePath))
                    using (CsvReader csvReader = new CsvReader(streamReader, config))
                    {
                        // Read records from the CSV file
                        IEnumerable<T> records = csvReader.GetRecords<T>();

                        return new List<T>(records);
                    }
                }

                return new List<T>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
