using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class Province:Territory
    {
        string _name;
        Region _region;
        List <City> _cityList;

      public Province (string name) { _name = name; }
    public string Name {  get { return _name; } set { _name = value; } }
    public Region Region
        {
            get { return _region;
            }
            set { _region = value; }
        }
        public List <City> CityList { get { return _cityList; }
            set { _cityList = value; } }    

        public void AddCityToProvince()
        {
            //aggiungere alla lista delle province
        }

        public void RemoveCityFromProvinces()
        {
            //rimuovere dalla lista delle province
        }

        public string TellMeTheRegion()
        {
            return $"{Name} belongs to region {Region}";
        }

        public override string ToString() { return Name; }    
    }


    
}
