using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
using Gruppo3.Clienti.Domain.Entities;
using Gruppo3.Clienti.Domain.Repositories;
using MassTransit;
using System.Collections.Generic;

namespace Gruppo3.Clienti.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IBus _rabbit;
        public ClientService(IClientRepository clientRepository, IBus rabbit)
        {
            _clientRepository = clientRepository;
            _rabbit = rabbit;
        }
        public ClientDTO DeleteClient(DeleteClientDTO clientDTO)
        {
            var response = _clientRepository.GetClientById(clientDTO.Id);
            if (response != null)
            {
                var client = DeleteClientDTO.ConvertDeleteClientDTOTOClient(clientDTO);

                //insert to db
                _clientRepository.DeleteClient(client);

                //publish event on rabbit
                _rabbit.Publish(Client.ClientToDeleteClientEvent(client));

                return ClientDTO.ConvertClientToClientDTO(response);
            }
            return null;
        }

        public IEnumerable<ClientDTO> GetClientAll()
        {
            var listClient = _clientRepository.GetClientAll();
            List<ClientDTO> clientDTOs = new List<ClientDTO>();

            foreach(var client in listClient)
            {
                clientDTOs.Add(ClientDTO.ConvertClientToClientDTO(client));
            }
            return clientDTOs;
        }

        public ClientDTO GetClientById(int id)
        {
            var response = _clientRepository.GetClientById(id);
            if (response != null)
                return ClientDTO.ConvertClientToClientDTO(response);
            return null;
        }

        public ClientDTO InsertClient(InsertClientDTO clientDTO)
        {
            var client = InsertClientDTO.ConvertInsertClientDTOTOClient(clientDTO);

            //insert to db
            var response = _clientRepository.InsertClient(client);

            //publish event on rabbit
            _rabbit.Publish(Client.ClientToCreateClientEvent(client));

            return ClientDTO.ConvertClientToClientDTO(response);
        }

        public ClientDTO UpdateClient(UpdateClientDTO clientDTO)
        {
            var client = UpdateClientDTO.ConvertUpdateClientDTOTOClient(clientDTO);

            //insert to db
            var response = _clientRepository.UpdateClient(client);

            //publish event on rabbit
            _rabbit.Publish(Client.ClientToUpdateClientEvent(client));

            return ClientDTO.ConvertClientToClientDTO(response);
        }
    }
}
