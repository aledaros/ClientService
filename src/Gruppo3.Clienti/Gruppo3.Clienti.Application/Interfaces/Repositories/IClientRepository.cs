using Gruppo3.ClientiDTO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gruppo3.Clienti.Application.Interfaces.Repositories
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
