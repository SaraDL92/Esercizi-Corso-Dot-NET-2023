using InternationalPublicManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class State : GeographicalArea, IPoliticalOrganization,  IUEpublicAdministration
    {
        string name;
        string flag;
        int armySpending;
        string constitution;
        string borders;
        string typeofstate;
        Region region;


        public State(string Name, string Flag, string TypeOfState, int Army, string Constitution, string Borders)
        {
            name = Name; flag = Flag; TypeofState = TypeOfState; constitution = Constitution; borders = Borders; armySpending = Army;
        }
        public string Name { get { return name; } set { name = value; } }
        public string Flag { get { return flag; } set { flag = value; } }
        public int ArmySpending { get { return armySpending; } set { armySpending = value; } }
        public string Constitution { get { return constitution; } set { constitution = value; } }
        public string Borders { get { return borders; } set { borders = value; } }
        public string TypeofState { get { return typeofstate; } set { typeofstate = value; } }
        public Region Region
        {
            get { return region; }
            set { region = value; }
        }

        public void AddRegion(string nam)
        {
            region.Name = nam;
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

        public void RemoveRegion(string nam)
        {
            region.Name = null;
        }
        public string TellMeTheRegion() { return $"The state {name} has these cityhall {region}"; }

        public void TerritoryManagement(State Claimer, State Dest)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name + " " + Flag + " " + TypeofState;
        }

        public void Welfare()
        {
            throw new NotImplementedException();
        }
    }
}
  
 
    


