using InternationalPublicManagement.EU;
using RelazioniOrizzontali;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eu.EU
{
    internal class EU:IEuropeanUnion
    {
        EMA _EMA;
        HumanRightsTribunal _humanRightsTribunal;
        EUState _eustate;
        EurozoneState _eurozone;


        public EMA EMA { get { return _EMA; }set { _EMA = value; } } 
        public HumanRightsTribunal HumanRightsTribunal { get { return _humanRightsTribunal; } set {  _humanRightsTribunal = value; } }
        public EUState Eustate {  get { return _eustate; } set {  _eustate = value; } }
        public EurozoneState EurozoneState { get { return _eurozone; } set { _eurozone = value; } }
        public string UseEMA(EUState state)
        {
            EMA ema = new();
           
            return  ema.MonitorDrugSafety(state);
        }

        public   string  UseHumanRightsTribunal(EUState state)
        {
            HumanRightsTribunal humanrightstribunal = new();
            humanrightstribunal.ExamineCase(state);
            humanrightstribunal.MonitorCompliance(state);
            humanrightstribunal.ProvideRemedies(state);

            return $"I used Human Rights Tribunal for examine case, provide remedies and monitor compliance of state {state.Name} ";
        }
    }
}