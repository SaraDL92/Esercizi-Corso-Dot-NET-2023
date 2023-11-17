using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InternationalPublicManagement
{
    internal class Province : GeographicalArea, IUEpublicAdministration
    {
        public string name;
       public  CityHall[] cityHallList = new CityHall[10];

        public Province(string _name) { name = _name; }


        public void BuildCityHall(string name)
        {
            CityHall cityHall = new CityHall(name);
            Console.WriteLine($"La provincia {this.name} ha creato il {cityHall}");

           
            int index = Array.FindIndex(cityHallList, ch => ch == null);

            if (index != -1)
            {
               
                cityHallList[index] = cityHall;
            }
            else
            {
                Console.WriteLine("Limite di comuni raggiunto");
            }
        }


        public void ShowMeCityHall()
        { Console.WriteLine($"La provincia {this.name} ha questi comuni:");
            foreach (var cityHall in cityHallList)
            {
                if (cityHall != null)
                {
                    Console.WriteLine(cityHall.Name);
                }
            }
           
        }

        public override string ToString()
        {
            return name;
        }
        public void EducationalSystem()
        {
            throw new NotImplementedException();
        }

        public void HNS()
        {
            throw new NotImplementedException();
        }

        public void LawSystem()
        {
            throw new NotImplementedException();
        }

      
       
        public void TerritoryManagement(State Claimer, State Dest)
        {
            throw new NotImplementedException();
        }

        public void Welfare()
        {
            throw new NotImplementedException();
        }
    }
}
