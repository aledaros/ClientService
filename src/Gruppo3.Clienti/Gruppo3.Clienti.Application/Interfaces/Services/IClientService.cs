using Gruppo3.Clienti.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
