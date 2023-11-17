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
        public Region [] regionList = new Region[10];


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

        public void BuildRegion(string name)
        {
            Region region = new Region(name);
            Console.WriteLine($"Lo stato {this.name} ha creatola regione {region.Name}");


            int index = Array.FindIndex(regionList, name => name == null);

            if (index != -1)
            {

               regionList[index] = region;
            }
            else
            {
                Console.WriteLine("Limite di regioni raggiunto");
            }
        }


        public void ShowMeRegionList()
        {
            Console.WriteLine($"Lo stato {this.name} ha queste regioni:");
            foreach (var region in regionList)
            {
                if (region != null)
                {
                    Console.WriteLine(region.Name);
                }
            }

        }
        public void  BuildProvince(Region region,string name)
        {
            region.BuildProvince(name);
        }
        public void BuildCityHall(Province province, string name)
        {
            province.BuildCityHall (name);
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
  
 
    


