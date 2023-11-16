using Eu.EU;
using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal interface IEuropeanUnion
    {
        public string UseEMA(EUState state);
      

        public string UseHumanRightsTribunal(EUState state);
    }
}
