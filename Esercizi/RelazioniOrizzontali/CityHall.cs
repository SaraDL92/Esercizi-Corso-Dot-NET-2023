using InternationalPublicManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class CityHall : GeographicalArea, IEUCitizen, IUEpublicAdministration
    {
        string _name;

        EUID[]_citizenInCityHall=new EUID[0];

        public int maxAbitanti = 900;
        public Region _region;


        public void SetRegion(Region region)
        {
            _region = region; 
        }

        public CityHall(string name)
        {
            _name = name;

        }
        public string Name { get { return _name; } set { _name = value; } }
       public EUID[] CitizenInCityHall { get { return _citizenInCityHall; } set { _citizenInCityHall = value; } }


        public int MaxAbitanti { get { return maxAbitanti; } } 

       


        public string BuildCitizenID(string name, string birthplace, string surname, string birthday, string id)
        {
           
            if (_region == null)
            {
                return "Region not set for CityHall. Cannot build citizen ID.";
            }

            EUID citizenID = new();

            citizenID.Name = name;
            citizenID.BithPlace = birthplace;
            citizenID.Surname = surname;
            citizenID.Bithday = birthday;
            citizenID.Id = id;

           
            if (CitizenInCityHall.Length < maxAbitanti)
            {
               
                CitizenInCityHall = CitizenInCityHall.Concat(new[] { citizenID }).ToArray();
                SetMaxAbitanti();
                Console.WriteLine($"Capacità massima del comune {this.Name}: {maxAbitanti} abitanti");
                return $"Il documento {id} {name} {surname} {birthplace} {birthday} è rilasciato dal {this.Name} (max population per city hall: {maxAbitanti})";
            }
            else
            {
                return "Capacità massima raggiunta!";
            }
        }
        public void ShowCitizenInCityHall()
        {
            Console.WriteLine($"La lista dei cittadini del {this.Name} è:");

            foreach (var citizen in CitizenInCityHall)
            {
                if (citizen != null)
                {
                    Console.WriteLine($"{citizen.Name} {citizen.Surname}");
                }
            }
        }
        public CityHall(string name, Region region)
        {
            _name = name;

           
            SetMaxAbitanti();
        }

        public void SetTheRegion(Region region)
        {
            _region = region;
            
        }

        public void ShowmetheRegion() { Console.WriteLine($"il {this.Name } appartiene alla regione {this._region}"); }
        public void SetMaxAbitanti()
        {
            if (_region != null) 
            { if (_region.Provinces.Length < 5) { this.maxAbitanti = 1000; } else { this.maxAbitanti = 500; } }
            
            
            
        }

        public override string ToString() { return Name; }

        public void Citizen_Education(EUID eUID)
        {
            throw new NotImplementedException();
        }

        public void Citizen_HNS(EUID eUID)
        {
            throw new NotImplementedException();
        }

        public void Citizen_Justice(EUID eUID)
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
