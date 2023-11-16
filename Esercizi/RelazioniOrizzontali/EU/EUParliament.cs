using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal class EUParliament
    {
        public Legislation legislation;
        public string ApprovesLegislation(Legislation legislation)
        {

            return $"Il Parlamento Europeo ha approvato la legislazione: {legislation}";



        }
        public string RefuseLegislation(Legislation legislation)
        {

            return $"Il Parlamento Europeo NON ha approvato la legislazione: {legislation}";



        }
    }
}
