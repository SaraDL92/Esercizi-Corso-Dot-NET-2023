using Microsoft.Extensions.DependencyInjection;
using System;
using DataLayer.Models;
using DataLayer.Interfaces;
using DataLayer.Repository;
using ServiceLayer.Interfaces;
using ServiceLayer;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace PresentationOrder_Mail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("app.json")
            .Build();

            var emailSetting = new EmailSetting();
            configuration.GetSection("EmailSettings").Bind(emailSetting);
            var serviceProvider = new ServiceCollection()
            .Configure<EmailSetting>(options =>
            {
                options.Host = emailSetting.Host;
                options.Port = emailSetting.Port;
                options.Security = emailSetting.Security;
                options.Username = emailSetting.Username;
                options.Password = emailSetting.Password;

            })
            .AddSingleton<IOrderRepository, OrderRepository>()
            .AddSingleton<IEmailTemplate, EmailTemplate>()
            .AddSingleton<ISmtpMailClient, SmtpMailClient>()
            .AddSingleton<IEmailService, EmailService>()
            .AddSingleton<OrderService>()
            .BuildServiceProvider();


            var orderService = serviceProvider.GetRequiredService<OrderService>();
            var smtpMailClient = serviceProvider.GetRequiredService<ISmtpMailClient>();

            var order = new Order
            {
                Id = 1,
                CustomerName = "Sara Di Luca",
                CustomerMail = "saradluffy@outlook.it"
            };
            var order2 = new Order
            {
                Id = 2,
                CustomerName = "Audrey Hepburn",
                CustomerMail = "audreyhep@outlook.it"
            };

           

            orderService.PlaceOrder(order);
            orderService.PlaceOrder(order2);
           



        }




    }


}