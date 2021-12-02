using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gruppo4MicroserviziDTO.DTOs;

namespace Gruppo3.Clienti.Core.Consumers
{
    public class CreateClientConsumer : IConsumer<Gruppo4MicroserviziDTO.DTOs.NewOrderEvent>
    {
        public Task Consume(ConsumeContext<NewOrderEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
