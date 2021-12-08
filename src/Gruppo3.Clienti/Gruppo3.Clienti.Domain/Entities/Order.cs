using Gruppo4MicroserviziDTO.DTOs;
using RepoDb.Attributes;
using System;

namespace Gruppo3.Clienti.Domain.Entities
{
    [Map("Orders")]
    public class Order
    {
        [Identity]
        [Map("idOrder")]
        public Guid Id { get; set; }
        [Map("idClient")]
        public int IdCliente { get; set; }
        [Map("TotalPrice")]
        public decimal TotalPrice { get; set; }

        //convert method
        public static Order DeletedOrderEventToOrder(DeletedOrderEvent deletedOrderEvent)
        {
            return new Order
            {
                Id = deletedOrderEvent.Id
            };
        }

        public static Order NewOrderEventToOrder(NewOrderEvent newOrderEvent)
        {
            return new Order
            {
                Id = newOrderEvent.Id,
                IdCliente = newOrderEvent.IdCliente,
                TotalPrice = newOrderEvent.TotalPrice
            };
        }

        public static Order UpdatedOrderEventToOrder(UpdatedOrderEvent updatedOrderEvent)
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
