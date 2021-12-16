using Gruppo3.ClientiDTO.Domain.Commands;
using RepoDb.Attributes;
using System;

namespace Gruppo3.Clienti.Domain.Entities
{
    [Map("Orders")]
    public class Order
    {
        [Identity]
        [Map("id")]
        public Guid Id { get; set; }
        [Map("clientid")]
        public int IdCliente { get; set; }
        [Map("totalprice")]
        public decimal TotalPrice { get; set; }

        //convert method
        public static Order DeletedOrderEventToOrder(ClientDeleteOrder deletedOrderEvent)
        {
            return new Order
            {
                Id = deletedOrderEvent.Id
            };
        }

        public static Order NewOrderEventToOrder(ClientNewOrder newOrderEvent)
        {
            return new Order
            {
                Id = newOrderEvent.Id,
                IdCliente = newOrderEvent.IdCliente,
                TotalPrice = newOrderEvent.TotalPrice
            };
        }

        public static Order UpdatedOrderEventToOrder(ClientUpdateOrder updatedOrderEvent)
        {
            return new Order
            {
                Id = updatedOrderEvent.Id,
                IdCliente = updatedOrderEvent.IdCliente,
                TotalPrice = updatedOrderEvent.TotalPrice
            };
        }
    }
}
