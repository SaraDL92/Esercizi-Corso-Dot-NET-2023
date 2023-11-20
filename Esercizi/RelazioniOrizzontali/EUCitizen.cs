using InternationalPublicManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class Citizen
    {
        string _name;
        string _birthPlace;
       string _surname;
       string _birthday;

        public Citizen(string _Name, string _BithPlace, string _Surname, string _Birthday) {

            _name = _Name;
            _birthPlace = _BithPlace;
            _surname = _Surname;
            _birthday = _Birthday;

        }

        public string Name { get { return _name; }set { _name = value; } }
        public string BirthPlace { get { return _birthPlace; } set { _birthPlace = value; } }
        public string Surname { get { return _surname; }set { _surname = value; } }

        public string Birthday { get { return _birthday; }set { _birthday = value; } }




        public string RequestIDCard(CityHall cityhall)
        {
            string id = "1865" + Name + "kjf";
            return cityhall.BuildCitizenID(this.Name, this.BirthPlace, this.Surname, this.Birthday, id);

        }
    }
}
