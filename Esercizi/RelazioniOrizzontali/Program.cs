using System;
using System.Collections.Generic;

namespace RelazioniOrizzontali
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUState eustate = new("Francia","blue-white-red");
            NATOState natostate = new("Belgio", "balck-yellow-red");
            EurozoneState eurozonestate = new("Italia","green-white-red");

            Region region = new("Calabria");
            Province province = new("Cosenza");
            City city = new("Tortora");
            CityHall cityhall = new("Comune di Tortora");
            city.AddCityHall(cityhall);
            Citizen citizen = new("ca654fa", cityhall, city, province, region, eurozonestate);
           
       

          

           
            Console.WriteLine(eustate);
            Console.WriteLine(natostate);
            Console.WriteLine(eurozonestate);
            Console.WriteLine(city.TellMeTheCityHall());
            Console.WriteLine(citizen);
            Console.Read();
        }
    }
}
