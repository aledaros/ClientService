using Gruppo3.Clienti.Domain.Repositories;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class DeleteOrderEvent : IConsumer<DeleteOrderEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderEvent(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public Task Consume(ConsumeContext<DeleteOrderEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
