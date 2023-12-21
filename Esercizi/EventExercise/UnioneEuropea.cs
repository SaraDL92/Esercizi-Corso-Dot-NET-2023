using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExercise
{
    public class UnioneEuropea
    {
        private int totaleCovid;

       
        public event EventHandler<int> AggiornamentoTotaleCovid;

        public UnioneEuropea()
        {
            totaleCovid = 0;
        }

        
        public void AggiornaTotaleCovid(object sender, int nuoviCasi)
        {
            totaleCovid += nuoviCasi;
            OnAggiornamentoTotaleCovid(totaleCovid);
        }

        protected virtual void OnAggiornamentoTotaleCovid(int totaleCasi)
        {
            AggiornamentoTotaleCovid?.Invoke(this, totaleCasi);
        }
        public override string ToString()
        {
            return totaleCovid.ToString();
        }
    }
}