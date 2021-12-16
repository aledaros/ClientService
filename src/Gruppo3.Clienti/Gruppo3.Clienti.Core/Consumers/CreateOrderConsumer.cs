using MassTransit;
using System;
using System.Threading.Tasks;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.Clienti.Domain.Entities;
using Gruppo3.Clienti.Domain.Consumers;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class CreateOrderConsumer : IConsumer<ClientNewOrder>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<ClientNewOrder> context)
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
