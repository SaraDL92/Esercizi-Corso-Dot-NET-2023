using Eu.EU;
using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class HumanRightsTribunal : IHumanRightsTribunal
    {
        public string ExamineCase(EUState state)
        {
            return $"The case of {state.Name} has been examined";
        }

        public  string MonitorCompliance(EUState state)
        {
            return $"The case of {state.Name} has been monitored";
        }

        public  string ProvideRemedies(EUState state)
        {
            return $"A measure has been taken for the state {state.Name}";
        }
    }
}
