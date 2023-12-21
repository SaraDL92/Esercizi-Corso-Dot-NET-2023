using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExercise
{
    
    public class StatoEuropeo
    {
        public string Nome { get; private set; }
        private int casiCovid;

     
        public event EventHandler<int> AggiornamentoCovid;

        public StatoEuropeo(string nome)
        {
            Nome = nome;
            casiCovid = 0;
        }

       
        public void AggiornaCasiCovid(int nuoviCasi)
        {
            casiCovid += nuoviCasi;
            OnAggiornamentoCovid(casiCovid);
        }


        protected virtual void OnAggiornamentoCovid(int nuoviCasi)
        {
            AggiornamentoCovid?.Invoke(this, nuoviCasi);
        }
    }
}