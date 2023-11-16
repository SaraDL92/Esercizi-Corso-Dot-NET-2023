using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InternationalPublicManagement
{
    internal class Province:GeographicalArea,IUEpublicAdministration
    {
        public string name;
        public CityHall cityhall;

        public Province(string _name) { name = _name; }

       public void AddCityHall(string nam) {
            cityhall.Name = nam;
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

        public void RemoveCityHall(string nam)
        {
            cityhall.Name = null;
        }
        public string TellMeTheCityHall() { return $"The province {name} has these cityhall {cityhall}"; }

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
