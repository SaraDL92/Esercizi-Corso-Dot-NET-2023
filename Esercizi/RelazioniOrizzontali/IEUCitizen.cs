using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement
{
    internal interface IEUCitizen
    {
        public void Citizen_HNS(EUID eUID);
        public void Citizen_Education(EUID eUID);
        public void Citizen_Justice(EUID eUID);
    }
}
