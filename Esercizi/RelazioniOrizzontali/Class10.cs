using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class EUState:State,IEuropeanUnion
    {
 
        public EUState(string Name,string Flag):base(Name, Flag,"I'm an EU State!") {

           

        }
      


    }
      
}
