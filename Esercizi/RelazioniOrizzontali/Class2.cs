using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class CityHall : Territory
    {
        string _name;
        City _belongsToCity;
       
        List<Citizen> _citizenList;



        public CityHall(string name)
        {
            _name = name;

        }
        public string Name { get { return _name; } set { _name = value; } }
        public City BelongsToCity { get { return _belongsToCity; } set { _belongsToCity = value; } }
       
        public List<Citizen> CitizenList { get { return _citizenList; } set { _citizenList = value; } }

        

        public void AddCitizenToCityHall()
        {


            //aggiungere cittadino nella lista cittadini quando faremo le liste
        }
        public void RemoveCitizenFromCityHall()
        {
            //rimuovere da lista quando faremo le liste
        }


        public override string ToString()
        {
            return Name;
        }


    }
}
