using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eu.NATO
{
    internal class NATO:INATO
    {
        NATOState _natoState;

        public NATOState NATOState { get { return _natoState; }set { _natoState = value; } }

        public string MilitarySpending(NATOState natostate)
        { decimal militaryspending;
           militaryspending= natostate.ArmySpending + natostate.ArmySpending *0.02m;
            return $" Military spending is increased by 2%! Before was {natostate.ArmySpending} now is {militaryspending}";
        }
    }
}
