using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class Legislation
    {
        public string name;

        public Legislation(string name)
        {
            this.name = name;
        }

        public override string ToString() { return name; }
    }
}
