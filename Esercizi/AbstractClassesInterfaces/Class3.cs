using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesInterfaces
{
    internal abstract class State
    {

        protected string name;
        protected bool eu;
        protected bool onu;
        protected bool deathPenalty;

        public State(string Name, bool Eu, bool Onu, bool DeathPenalty)
        {
            this.name = Name;
            this.eu = Eu;
            this.onu = Onu;
            this.deathPenalty = DeathPenalty;
        }

        public string Name {  get { return name; } set { name = value; } }
        public bool Eu { get { return eu; } set { eu = value; } }
        public bool Onu { get { return onu; } set { onu = value; } }
        public bool DeathPenalty { get {  return deathPenalty; } set {  deathPenalty = value; } }

        public virtual string IsDeathPenalityTrue()
        {
            if (this.deathPenalty == false) return "nessuna pena di morte";
            else { return "pena di morte "; }
        }

    }
}
