using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassesInterfaces
{
    internal class EuropeanCourtofHumanRights
    {

        public string Check(State stato)
        {
           
            if (stato is EurozoneState)
            {
                EurozoneState state = (EurozoneState)stato;

                return $"Lo stato {stato} è un paese EuroZone con" + " " + state.IsDeathPenalityTrue();

            }
            else if (stato is EU state1 && state1.Onu==true||stato is Onu state3 && state3.Eu==true)
            {


                return $"Lo stato {stato} è sia un paese EU che ONU con" + " " + stato.IsDeathPenalityTrue();

            } else if (stato is EU)
            {

                EU state = (EU)stato;
                return $"Lo stato {stato} è un paese EU con" + " " + state.IsDeathPenalityTrue();
            }
            else
            {
                Onu state = (Onu)stato;

                return $"Lo stato {stato} è un paese ONU con" +" " +state.IsDeathPenalityTrue();
               

            }
           

            
          






        }



    }
}
