using Eu.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class EMA : IEMA
    {
        public string MonitorDrugSafety(EUState state)
        {
            return $"Monitor Drug Safety of state {state.Name}";
        }
    }
}
