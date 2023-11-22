using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace FileSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Sara Di Luca", Age = 31 },
                new Customer { Name = "Tessa Vignali", Age = 33 },
                new Customer { Name = "Gaia Surace", Age = 28 },
                new Customer { Name = "Filippo Granata", Age = 40 }


            };

            List<Account> accounts = new List<Account>
            {
                new Account { AccountId = 100, Saldo=100.10m },
                new Account { AccountId = 101, Saldo = 200.80m },
                new Account { AccountId = 102, Saldo = 500.10m },
                new Account { AccountId = 103, Saldo = 700.90m }
            };
            string percorsolistaclienti = @"C:\Users\sarad\Desktop\listaClienti.txt";
            string percorsolistaaccounts = @"C:\Users\sarad\Desktop\listaAccounts.txt";
            string cartella = Path.GetDirectoryName(percorsolistaclienti);
            if (!Directory.Exists(cartella))
            {
                Directory.CreateDirectory(cartella);
            }

            File file = new();
            File file2 = new();
           
            file.WriteOnFile(percorsolistaclienti,customers);
            file2.WriteOnFile(percorsolistaaccounts, accounts);
       
        }
        
       

            }
        }
    

