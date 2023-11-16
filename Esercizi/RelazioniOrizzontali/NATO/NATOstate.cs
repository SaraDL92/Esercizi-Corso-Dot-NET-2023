using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelazioniOrizzontali;

namespace Eu.NATO
{
    internal class NATOState : State
    {
      
        public NATOState(string Name, string Flag, int Army, string Constitution, string Borders) : base(Name, Flag, "I'm a NATO State", Army, Constitution, Borders)
        {
           

        }
       


    }
}
