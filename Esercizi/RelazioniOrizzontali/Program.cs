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
            EUState eustate = new("Francia","blue-white-red",200,"Costituzione Francese","Italia");
            State state = new("Itlaia", "verde-bianca-rossa", "I'm a state", 1000, "Costituzione italiana", "confini tot");
            Region region = new("Calabria");
            Province province = new("Cosenza");
            City city = new("Tortora");
            CityHall cityhall = new("Comune di Tortora");
            city.AddCityHall(cityhall);
            ONU onu = new();
            ONUState onustate = new("America", "",200, "", "");
            NATOState natostate=new("Germany", "", 50, "", "");
            Citizen CITIZEN = new("Selena", "Maratea", "Marra", "11-9-2000");

            
            
            NATO nato = new();
            eustate.AddRegionToState(region);
           
            EU eU = new();
            Eurozone eurozone = new();
            HumanRightsTribunal humanRightsTribunal=new HumanRightsTribunal();
            Legislation leg = new("Proposta di vitto e alloggio per naufraghi");
            EUParliament parl = new();

            Console.WriteLine(eustate);
           
            Console.WriteLine(city.TellMeTheCityHall());
           
            Console.WriteLine(eustate.Region);

            Console.WriteLine(nato.MilitarySpending(natostate));
         
            Console.WriteLine(humanRightsTribunal.MonitorCompliance(eustate));

            Console.WriteLine(eU.UseHumanRightsTribunal(eustate));
            Console.WriteLine(eU.UseEMA(eustate));
            Console.WriteLine(eurozone.SingleCoin(eustate));
            Console.WriteLine(eustate.UseEUCommission(leg));
            Console.WriteLine(parl.ApprovesLegislation(leg));
            Console.WriteLine(parl.RefuseLegislation(leg));
            Console.WriteLine(cityhall.BuildCitizenID("Sara","Maratea","Di Luca","11-07-92","100df"));
            Console.WriteLine(CITIZEN.RequestIDCard(cityhall));
            Console.Read();
        }
    }
}
