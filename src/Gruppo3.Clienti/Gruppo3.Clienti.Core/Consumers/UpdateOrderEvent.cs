using Gruppo3.Clienti.Domain.Repositories;
using Gruppo4MicroserviziDTO.DTOs;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class UpdateOrderEvent : IConsumer<UpdatedOrderEvent>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderEvent(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public Task Consume(ConsumeContext<UpdatedOrderEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
