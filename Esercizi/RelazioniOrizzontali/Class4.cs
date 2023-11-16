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
        public Province province;


       

        public Region(string name)
        {
            _name = name;
           
        }

        
        public string Name { get { return _name; } set { _name = value; } }
        public State State { get { return _state; } set { _state=value; } }



        public void AddProvince(string nam)
        {
            province.name = nam;
        }

        public void RemoveProvince(string nam)
        {
            province.name = null;
        }
        public string TellMeTheProvince() { return $"The region {Name} has these provinces {province}"; }

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
      
    }
   
