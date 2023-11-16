using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternationalPublicManagement.EU;
using RelazioniOrizzontali;

namespace Eu.EU
{
    internal class EUState : State
    {
       public  EUCommision commision;
        public EUState(string Name, string Flag, int Army, string Constitution, string Borders) : base(Name, Flag, "I'm an EU State!", Army, Constitution, Borders)
        {



        }

       public string UseEUCommission(Legislation legislation) {
            EUCommision comm = new();
          return comm.PresentaPropostaLegislativa(legislation);
       
        }

    }

}
