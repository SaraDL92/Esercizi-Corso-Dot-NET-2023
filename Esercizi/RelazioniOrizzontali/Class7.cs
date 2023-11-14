using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class State : Territory, IAdministrativeEntity, IPoliticalOrganization
    {

       string name;
       string flag;
       string typeofstate;
       List<Region> regions;


        public State(string Name,string Flag,string TypeOfState){
            name = Name; flag = Flag;TypeofState = TypeOfState;
        }
        public string Name {  get { return name; } set { name = value; } }
        public string Flag { get { return flag; } set { flag = value; } }

       public string TypeofState { get { return typeofstate; } set { typeofstate = value; } }
        public List<Region> Regions
        {
            get { return regions; }
            set { regions = value; }
        }

        public void AddRegionToState()
        { //aggiungere regione alla lista regioni dello Sato
        }

        public void RemoveRegionFromState()
        {
            //rimuovi la regione dallo Stato
        }
        public override string ToString()
        {
            return Name +" "+ Flag +" " +TypeofState;
        }


    }
}
