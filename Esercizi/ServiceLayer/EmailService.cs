using DataLayer.Interfaces;
using DataLayer.Models;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class EmailService : IEmailService

    {
        private readonly IEmailTemplate _emailTemplate ;
        private readonly ISmtpMailClient _emailClient;

        public EmailService(IEmailTemplate emailtemplate, ISmtpMailClient emailclient) 
        {
        _emailTemplate= emailtemplate;
        _emailClient= emailclient;
        }

        public void SendConfirmationOrderMail(Order order)
        {
            var emailContent = _emailTemplate.TextEmail(order);
            _emailClient.SendEmail(order.CustomerMail, "Order confirmation", emailContent);
           
        }
    }
}
