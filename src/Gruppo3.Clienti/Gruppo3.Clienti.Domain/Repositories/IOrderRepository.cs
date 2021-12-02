using Gruppo4MicroserviziDTO.DTOs;

namespace Gruppo3.Clienti.Domain.Repositories
{
    public interface IOrderRepository
    {
        //insert
        public NewOrderEvent InsertOrder(NewOrderEvent orderEvent);

        //update
        public UpdatedOrderEvent UpdateOrder(UpdatedOrderEvent orderEvent);

        //delete
        public DeletedOrderEvent DeleteOrder(DeletedOrderEvent orderEvent);
    }
}
