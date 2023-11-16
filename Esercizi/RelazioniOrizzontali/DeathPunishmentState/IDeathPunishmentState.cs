using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eu.DeathPunishmentState
{
    internal interface IDeathPunishmentState
    {

        public string DeathPenalty(Citizen citizen);
    }
}
