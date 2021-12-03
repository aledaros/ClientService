using Gruppo3.Clienti.Domain.DTO;

namespace Gruppo3.Clienti.Application.Interfaces.Services
{
    public interface IClientService
    {
        //insert
        public ClientDTO InsertClient(InsertClientDTO client);

        //update
        public ClientDTO UpdateClient(UpdateClientDTO client);

        //delete
        public ClientDTO DeleteClient(DeleteClientDTO client);

        //get id
        public ClientDTO GetClientById(int id);
    }
}
