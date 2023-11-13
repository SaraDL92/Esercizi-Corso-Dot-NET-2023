using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesInterfaces

{
    internal class EuroCentralBank:IBank
    {
        protected string nameBank;
      public EuroCentralBank(string NameBank) {
            nameBank =NameBank;
        }
        public override string ToString()
        {
            return this.nameBank;
        }
        public string NameBank { get {  return nameBank; } }
      public string CalcoloSpread(EurozoneState euroZoneState) { return $"Lo spread dello stato {euroZoneState} appartenente all'eurozone è questo!"; }

     
    }
}
