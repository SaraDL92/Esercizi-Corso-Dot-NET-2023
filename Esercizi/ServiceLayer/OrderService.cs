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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;


        public OrderService(IOrderRepository orderRepository, IEmailService emailService)
        {
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public void PlaceOrder(Order order)
        {
           _orderRepository.SaveOrder(order);
            _emailService.SendConfirmationOrderMail(order);
        }
    }
}
