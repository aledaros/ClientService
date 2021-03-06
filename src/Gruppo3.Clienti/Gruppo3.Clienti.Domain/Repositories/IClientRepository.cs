using Gruppo3.Clienti.Domain.Entities;
using System.Collections.Generic;

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

        //get by id
        public Client GetClientById(int id);

        //get all
        public IEnumerable<Client> GetClientAll();

    }
}
