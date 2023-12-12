using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;

namespace DataLayer.Models
{
    // SmtpMailClient.cs
    public class SmtpMailClient : ISmtpMailClient
    {
        private readonly EmailSetting _emailSettings;

        public SmtpMailClient(IOptions<EmailSetting> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendEmail(string to, string subject, string body)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.Host = _emailSettings.Host;
                smtp.Port = _emailSettings.Port;
                smtp.EnableSsl = _emailSettings.Security == "STARTTLS";
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);

               
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(to);

                smtp.Send(mailMessage);
            }
        }
    }
}
