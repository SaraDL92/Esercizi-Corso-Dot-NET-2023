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
        public Region _region;
        public string Name { get; } 
        public CityHall[] CityHallList { get; } = new CityHall[10];

        public Province(string name)
        {
            Name = name;
        }
        public Province(string name, Region region) : this(name)
        {
            _region = region;
        }

       

        public void BuildCityHall(string name)
        {
            CityHall cityHall = new CityHall(name);
            cityHall.SetRegion(this._region);
            cityHall.SetMaxAbitanti();
            Console.WriteLine($"La provincia {this.Name} ha creato il {cityHall} con capacità massima:{cityHall.maxAbitanti}");

            int index = Array.FindIndex(CityHallList, ch => ch == null);

            if (index != -1)
            {
                cityHall.SetRegion(this._region);
                cityHall.SetMaxAbitanti();
                CityHallList[index] = cityHall;
            }
            else
            {
                Console.WriteLine("Limite di comuni raggiunto");
            }
        }
        



        public void ShowMeCityHall()
        {
            Console.WriteLine($"La provincia {this.Name} ha questi comuni:");
            foreach (var cityHall in CityHallList)
            {
                if (cityHall != null)
                {
                    Console.WriteLine(cityHall.Name);
                }
            }
        }

        public void TerritoryManagement(State Claimer, State Dest)
        {
            throw new NotImplementedException();
        }

        public void Welfare()
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

        public void EducationalSystem()
        {
            throw new NotImplementedException();
        }
    }

        

       
}
