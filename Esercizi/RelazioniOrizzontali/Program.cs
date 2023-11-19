using Eu.DeathPunishmentState;
using Eu.ONU;
using Eu.NATO;
using System;
using System.Collections.Generic;
using Eu.EU;
using InternationalPublicManagement.EU;
using InternationalPublicManagement;

namespace RelazioniOrizzontali
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // EUState eustate = new("Francia","blue-white-red",200,"Costituzione Francese","Italia");
            State state = new("Itlaia", "verde-bianca-rossa", "I'm a state", 1000, "Costituzione italiana", "confini tot");
           /* Region region = new("Calabria");
            Province province = new("Cosenza");
           
            CityHall cityhall = new("Comune di Tortora");
           
            ONU onu = new();
            ONUState onustate = new("America", "",200, "", "");
            NATOState natostate=new("Germany", "", 50, "", "");
            Citizen CITIZEN = new("Selena", "Maratea", "Marra", "11-9-2000");

           
            
            NATO nato = new();
           
           
            EU eU = new();
            Eurozone eurozone = new();
            HumanRightsTribunal humanRightsTribunal=new HumanRightsTribunal();
            Legislation leg = new("Proposta di vitto e alloggio per naufraghi");
            EUParliament parl = new();

            Console.WriteLine(eustate);


            cityhall.SetTheRegion(region);

           

            Console.WriteLine(nato.MilitarySpending(natostate));
         
            Console.WriteLine(humanRightsTribunal.MonitorCompliance(eustate));

            Console.WriteLine(eU.UseHumanRightsTribunal(eustate));
            Console.WriteLine(eU.UseEMA(eustate));
            Console.WriteLine(eurozone.SingleCoin(eustate));
            Console.WriteLine(eustate.UseEUCommission(leg));
            Console.WriteLine(parl.ApprovesLegislation(leg));
            Console.WriteLine(parl.RefuseLegislation(leg));
 Console.WriteLine("-------");
            Console.WriteLine("-------");
            Console.WriteLine("-------");*/

            Console.WriteLine("CREAZIONE STATO,REGIONE,PROVINCIA,COMUNE CON AUMENTO E DIMUNUZIONE CAPACITA' MASSIMA DI ABITANTI (ESERCITAZIONE CON ARRAY):");
           
            state.BuildRegion("Calabria");
            state.BuildRegion("Campania");
            state.ShowMeRegionList();
            state.regionList[0].BuildProvince("Cosenza");
            state.regionList[1].BuildProvince("Napoli");
            state.regionList[0].BuildProvince("Catanzaro");
            state.regionList[0].BuildProvince("Crotone"); 
            state.regionList[0].BuildProvince("Vibo Valentia"); 
            state.regionList[0].BuildProvince("Reggio Calabria");
            state.regionList[0].ShowMeProvinces();
            state.regionList[1].ShowMeProvinces();
            state.regionList[0]._provinces[0].BuildCityHall("Comune Di Tortora Marina");
            state.regionList[1]._provinces[0].BuildCityHall("Comune Di Pompei");


            state.regionList[0]._provinces[0].CityHallList[0].ShowmetheRegion();
            state.regionList[1]._provinces[0].CityHallList[0].ShowmetheRegion();

            Console.Read();






        }
    }
}
