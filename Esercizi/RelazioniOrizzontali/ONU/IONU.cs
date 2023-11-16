using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using RelazioniOrizzontali;

namespace Eu.ONU
{
    internal interface IOnu : IPoliticalOrganization
    {
        public string TerritoryDefense(ONUState onustate);
        public string PopulationControl(ONUState onustate);

        public string AddStateToOnu(State state);
        public string RemoveStateFromOnu(ONUState onustate);


    }
}
