using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities
{
   public class PersonDTO
    {
        protected string name;
        protected string surname;
        protected string birthday;

        public PersonDTO(string Name, string Surname, string Birthday)
        {
            name = Name;
            surname = Surname;
            birthday = Birthday;


        }

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public string Birthday { get { return birthday; } set { birthday = value; } }
    }
}
