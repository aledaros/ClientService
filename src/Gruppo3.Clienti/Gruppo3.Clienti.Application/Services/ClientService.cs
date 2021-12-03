using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
using Gruppo3.Clienti.Domain.Repositories;

namespace Gruppo3.Clienti.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public ClientDTO DeleteClient(DeleteClientDTO client)
        {
            var response = _clientRepository.GetClientById(client.Id);
            if (response != null)
            {
                _clientRepository.DeleteClient(DeleteClientDTO.ConvertDeleteClientDTOTOClient(client));
                return ClientDTO.ConvertClientToClientDTO(response);
            }
            return null;
        }

        public ClientDTO GetClientById(int id)
        {
            var response = _clientRepository.GetClientById(id);
            if (response != null)
                return ClientDTO.ConvertClientToClientDTO(response);
            return null;
        }

        public ClientDTO InsertClient(InsertClientDTO client)
        {
            var response = _clientRepository.InsertClient(InsertClientDTO.ConvertInsertClientDTOTOClient(client));
            return ClientDTO.ConvertClientToClientDTO(response);
        }

        public ClientDTO UpdateClient(UpdateClientDTO client)
        {
            var response = _clientRepository.UpdateClient(UpdateClientDTO.ConvertUpdateClientDTOTOClient(client));
            return ClientDTO.ConvertClientToClientDTO(response);
        }
    }
}
