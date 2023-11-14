using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class City : Territory
    {
        string _name;
        CityHall _cityHall;
        Province _province;


        public City(string name)
        {
            _name = name;

        }

        public string Name { get { return _name; } set { _name = value; } }

        public CityHall CityHall { get { return _cityHall; } set { _cityHall = value; } }
        public Province Province { get { return _province; }
            set { _province = value; } }
          

        public override string ToString() { return Name ; }

        public void AddCityHall(CityHall cityhall)
        {
            CityHall=cityhall;
        }
        public void RemoveCityHall()
        {
            _cityHall = null;
        }

        public String TellMeTheProvince() { return $"The {Name} is from Province {Province}"; }



        public string TellMeTheCityHall()
        {
            return Name + " " + "ha questo comune:" + CityHall;
        }
      
    }
}
