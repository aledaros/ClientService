using Gruppo3.Clienti.Domain.DTO;

namespace Gruppo3.Clienti.Application.Interfaces.Services
{
    public interface IClientService
    {
        //insert
        public InsertClientDTO InsertClient(InsertClientDTO client);

        //update
        public UpdateClientDTO UpdateClient(UpdateClientDTO client);

        //delete
        public DeleteClientDTO DeleteClient(DeleteClientDTO client);
    }
}
