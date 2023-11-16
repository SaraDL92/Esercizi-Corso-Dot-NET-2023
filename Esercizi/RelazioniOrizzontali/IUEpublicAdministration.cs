using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement
{
    internal interface IUEpublicAdministration:IPublicAdministration
    {

        public void TerritoryManagement(State Claimer, State Dest);
        public void Welfare();

    }
}
