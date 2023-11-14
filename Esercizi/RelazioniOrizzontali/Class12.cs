using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class Citizen
    {
        string _id;
        CityHall _cityhall;
        City _city;
        Province _province;
        Region _region;
        State _state;

        public Citizen(string id, CityHall cityhall, City City,Province Province,Region Region,State State)
        {
            _id = id;
            _cityhall= cityhall;
            _city = City;
            _province = Province;
            _region = Region;
           _state= State;

        }

        public string ID
        {
            get { return _id; }
            set { _id = value; }

        }
        public CityHall CityHall
        {
            get { return _cityhall; }
            set { _cityhall = value; }

        }
        public City City
        {
            get { return _city; }
            set { _city = value; }

        }
        public Province Province
        {
            get { return _province; }
            set { _province = value; }

        }
        public Region Region
        {
            get { return _region; }
            set { _region = value; }

        }
        public State State
        {
            get { return _state; }
            set { _state = value; }

        }
        public override string ToString()
        {
            return $"The Citizen {ID} lives in the CityHall {CityHall},in City {City},in Province {Province},in Region {Region}, in State {State.Name}";
        } 


    }
}
