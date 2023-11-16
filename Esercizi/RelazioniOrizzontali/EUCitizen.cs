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
        public string Name;
        public string BithPlace;
        public string Surname;
        public string Bithday;

        public Citizen(string _Name, string _BithPlace, string _Surname, string _Birthday) {

            Name = _Name;
            BithPlace = _BithPlace;
            Surname = _Surname;
            Bithday = _Birthday;

        }

       public string RequestIDCard(CityHall cityhall)
        {
            string id = "1865" + Name + "kjf";
            return cityhall.BuildCitizenID(this.Name, this.BithPlace, this.Surname, this.Bithday, id);

        }
    }
}
