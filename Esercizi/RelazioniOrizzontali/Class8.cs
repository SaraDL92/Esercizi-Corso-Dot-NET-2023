using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelazioniOrizzontali
{
    internal class DeathPunishmentState:State,IDeathPunishmentState
    {
        string _typeOfState;
        public DeathPunishmentState(string Name, string Flag) : base(Name, Flag, "I'm a Death Punishment State!") {
          
        
        }
    }
}
