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
       
       
       



        public CityHall(string name)
        {
            _name = name;

        }
        public string Name { get { return _name; } set { _name = value; } }
       
      



       public string BuildCitizenID(string name, string birthplace,string surname,string birthday,string id )
        {
            EUID citizenID = new();
          
           
            citizenID.Name = name;
            citizenID.BithPlace = birthplace;
            citizenID.Surname = surname;
            citizenID.Bithday = birthday;
            citizenID.Id = id;
            return "Il documento"+" "+id + " " + name + " " + surname + " " + birthplace + " " + birthday+" "+"è rilasciato dal"+" "+this.Name;



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
