using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eu.ONU
{
    internal class StrasbourgCourt:IOnu
    {
        ONUState _onustate;

        public ONUState Onustate { get { return _onustate; } set { _onustate = value; } }

        public string AddStateToOnu(State state)
        {
            //Onustate = (ONUState)state;
            return $"The state {state.Name} has become an ONU state now!";
        }

        public string RemoveStateFromOnu(ONUState onustate)
        {
            Onustate = null;
            return $"The state {onustate.Name} has been removed from ONU!";
        }


        public string PopulationControl(ONUState onustate)
        {
            return $"The population of {onustate.Name} has been checked!";
        }

        public string TerritoryDefense(ONUState onustate)
        {
            return $"The population of {onustate.Name} has been defended!";
        }


    }
}
