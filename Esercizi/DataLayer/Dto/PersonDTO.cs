using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
    internal class PersonDTO
    {
        private string name;
        private string surname;
        private string birthday;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Birthday { get => birthday; set => birthday = value; }
    }
}
