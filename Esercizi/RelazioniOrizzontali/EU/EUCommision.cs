using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class EUCommision
    {
        Legislation legislation;
        public string PresentaPropostaLegislativa(Legislation legislation)
        {

            return $"La Commissione Europea ha presentato la proposta legislativa: {legislation}";
        }
    }
}
