using InternationalPublicManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RelazioniOrizzontali
{
    internal class Region : GeographicalArea, IUEpublicAdministration
    {
        string _name;
        State _state;
        public Province [] province=new Province[0];
        public int MaxPopulationPerCityHallWhen10Provinces = 100;
        public int MaxPopulationPerCityHallWhen5Provinces = 500;

        public int MaxPopulationPerCityHall
        {
            get
            {
                if (province.Count(p => p != null) == 10)
                {
                    return MaxPopulationPerCityHallWhen10Provinces;
                }
                else if (province.Count(p => p != null) == 5)
                {
                    return MaxPopulationPerCityHallWhen5Provinces;
                }
                else
                {
                   
                    return 100;
                }
            }
        }
        public void BuildProvince(string name)
        {
            Province prov = new Province(name);
            Console.WriteLine($"La regione {this.Name} ha creato la provincia {prov}");


            int index = Array.FindIndex(province, name => name == null);

            if (index != -1)
            {

                province[index] = prov;
            }
            else
            {
                Console.WriteLine("Limite di comuni raggiunto");
            }
        }


        public void ShowMeProvinces()
        {
            Console.WriteLine($"La regione {this.Name} ha queste province:");
            foreach (var prov in province)
            {
                if (prov != null)
                {
                    Console.WriteLine(prov);
                }
            }

        }
        public void BuildCityHall(Province province, string name)
        {
            province.BuildCityHall(name);
        }
        public Region(string name)
        {
            _name = name;
           
        }

        
        public string Name { get { return _name; } set { _name = value; } }
        public State State { get { return _state; } set { _state=value; } }



        
      public override  string ToString() { return Name; }
       
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
      
    
   
