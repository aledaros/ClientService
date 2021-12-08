using Gruppo3.Clienti.Domain.Entities;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class DeleteOrderConsumer : IConsumer<DeletedOrderEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<DeletedOrderEvent> context)
        {
            try
            {
                Console.WriteLine($"Messaggio DeleteOrderEvent arrivato! {context.Message.Id}");
                _orderRepository.DeleteOrder(Order.DeletedOrderEventToOrder(context.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }
    }
}
