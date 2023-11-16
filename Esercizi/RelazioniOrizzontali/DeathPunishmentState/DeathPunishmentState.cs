using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelazioniOrizzontali;

namespace Eu.DeathPunishmentState
{
    internal class DeathPunishmentState : State, IDeathPunishmentState
    {  
       string _nameofdeathpenality;
        Citizen _citizen;
        public DeathPunishmentState(string Name, string Flag,int Army, string Constitution, string Borders,Citizen citizen) : base(Name, Flag, "I'm a Death Punishment State!", Army, Constitution, Borders)
        {
            _citizen = citizen;
            _nameofdeathpenality = "";
        }
        public string NameOfDeathpenality { get { return _nameofdeathpenality; } set {  _nameofdeathpenality = value; } }
        public Citizen Citizen { get { return _citizen; } set { _citizen = value; } }
        public string DeathPenalty(Citizen citizen1)
        {
            if (Citizen == citizen1)
            { return $"The Citizen {citizen1} is sentenced to death"; }else {return "the citizen is not processable"; }
                
           
        }
    }
}
