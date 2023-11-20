using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class Legislation
    {
        string name;

        public Legislation(string name)
        {
            this.name = name;
        }
        public string Name { get { return name; } set { name = value; } }
        public override string ToString() { return name; }
    }
}
