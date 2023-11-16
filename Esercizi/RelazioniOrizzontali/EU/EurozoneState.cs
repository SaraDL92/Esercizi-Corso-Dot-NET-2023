using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelazioniOrizzontali;

namespace Eu.EU
{
    internal class EurozoneState : EUState, IBCE
    {
        string _typeofstate;
        public EurozoneState(string Name, string Flag, int Army, string Constitution, string Borders) : base(Name, Flag, Army, Constitution, Borders)
        {
            _typeofstate = "I'm an EU and EuroZone State!";

        }
        public string TypeOfState
        {
            get
            {
                return _typeofstate;
            }
            set { _typeofstate = value; }
        }
        public override string ToString()
        {
            return Name + " " + Flag + " " + TypeOfState;
        }

    }


}
