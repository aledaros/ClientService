using Gruppo3.Clienti.Domain.Consumers;
using Gruppo3.Clienti.Domain.Entities;
using Gruppo3.Clienti.Domain.Repositories;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class UpdateOrderConsumer : IConsumer<ClientUpdateOrder>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<ClientUpdateOrder> context)
        {
            try
            {
                Console.WriteLine($"Messaggio UpdateOrderEvent arrivato! {context.Message.Id}");
                _orderRepository.UpdateOrder(Order.UpdatedOrderEventToOrder(context.Message));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.CompletedTask;
        }
    }
}
