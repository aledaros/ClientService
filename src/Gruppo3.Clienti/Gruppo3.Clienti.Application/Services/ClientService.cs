using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.ClientiDTO.Domain.Entities;

namespace Gruppo3.Clienti.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public DeleteClientDTO DeleteClient(DeleteClientDTO client)
        {
            var response = _clientRepository.DeleteClient(DeleteClientDTO.ConvertDeleteClientDTOTOClient(client));
            return DeleteClientDTO.ConvertClientToDeleteClientDTO(response);
        }

        public InsertClientDTO InsertClient(InsertClientDTO client)
        {
            var response = _clientRepository.InsertClient(InsertClientDTO.ConvertInsertClientDTOTOClient(client));
            return InsertClientDTO.ConvertClientToInsertClientDTO(response);
        }

        public UpdateClientDTO UpdateClient(UpdateClientDTO client)
        {
            var response = _clientRepository.DeleteClient(UpdateClientDTO.ConvertUpdateClientDTOTOClient(client));
            return UpdateClientDTO.ConvertClientToUpdateClientDTO(response);
        }
    }
}
