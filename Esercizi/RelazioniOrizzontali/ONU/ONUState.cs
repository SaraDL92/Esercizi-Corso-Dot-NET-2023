using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eu.ONU
{
    internal class ONUState : State
    {
        ONU _onu;

        public ONUState(string Name, string Flag, int Army, string Constitution, string Borders) : base(Name, Flag, "I'm an ONU State!", Army, Constitution, Borders)
        {

        }


        public ONU Onu
        {
            get { return _onu; }
            set { _onu = value; }




        }
    }
}