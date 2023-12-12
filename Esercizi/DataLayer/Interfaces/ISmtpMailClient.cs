using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ISmtpMailClient
    {
        void SendEmail(string to, string subject, string body);
    }
}
