using Eu.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class Eurozone : IEurozone
    {
        EurozoneState eurozoneState;

        public EurozoneState eurozonestate { get { return eurozoneState; }set { eurozoneState = value; } } 


        public string  SingleCoin(EUState state)
        {
            
            return 
            $"The {state.Name} now has the euro single coin!";
        }

      
    }
}
