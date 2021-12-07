using MassTransit;
using System;
using System.Threading.Tasks;
using Gruppo4MicroserviziDTO.DTOs;
using Gruppo3.Clienti.Domain.Repositories;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class CreateOrderConsumer : IConsumer<NewOrderEvent>
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderConsumer(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        //implementare 3 Consume: NewOrderEvent, UpdatedOrderEvent e DeletedOrderEvent (creare 2 file consume diversi)
        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
