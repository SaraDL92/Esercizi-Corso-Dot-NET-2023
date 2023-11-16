using Eu.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternationalPublicManagement.EU
{
    internal interface IHumanRightsTribunal
    {

        public string ExamineCase(EUState state);
        public string ProvideRemedies(EUState state);
        public string MonitorCompliance(EUState state);

    }
}
