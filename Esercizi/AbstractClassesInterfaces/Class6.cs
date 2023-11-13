using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesInterfaces
{
    internal class EU:State
    {
        public EU(string Name, bool Eu, bool EuroZone, bool DeathPenalty) : base(Name, Eu, EuroZone, DeathPenalty) { }
        public override string ToString()
        {
            return this.name;
        }
        public override string IsDeathPenalityTrue()
        {
            return base.IsDeathPenalityTrue();
        }
    }
}
