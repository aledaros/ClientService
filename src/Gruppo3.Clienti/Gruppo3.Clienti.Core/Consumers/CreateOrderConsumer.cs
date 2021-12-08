using MassTransit;
using System;
using System.Threading.Tasks;
using Gruppo4MicroserviziDTO.DTOs;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class CreateOrderConsumer : IConsumer<NewOrderEvent>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            try
            {
                Console.WriteLine($"Messaggio NewOrderEvent arrivato! {context.Message.Id}");
                _orderRepository.InsertOrder(Order.NewOrderEventToOrder(context.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }
    }
}
