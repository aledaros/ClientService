using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Domain.Repositories
{
    public interface IOrderRepository
    {
        //insert
        public Order InsertOrder(Order orderEvent);

        //update
        public Order UpdateOrder(Order orderEvent);

        //delete
        public Order DeleteOrder(Order orderEvent);
    }
}
