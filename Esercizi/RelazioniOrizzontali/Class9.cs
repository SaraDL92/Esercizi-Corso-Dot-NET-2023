using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class NATOState:State,INATO
    { string _typeOfState;
        public NATOState(string Name,string Flag):base(Name,Flag,"I'm a NATO State") {

            
        }
    }
}
