using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Domain.Repositories
{
    public interface IClientRepository
    {
        //insert
        public Client InsertClient(Client client);

        //update
        public Client UpdateClient(Client client);

        //delete
        public Client DeleteClient(Client client);


    }
}
