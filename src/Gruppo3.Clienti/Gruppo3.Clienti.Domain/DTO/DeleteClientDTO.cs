using Gruppo3.ClientiDTO.Domain.Entities;

namespace Gruppo3.Clienti.Domain.DTO
{
    public class DeleteClientDTO
    {
        public int Id { get; set; }

        public static DeleteClientDTO ConvertClientToDeleteClientDTO(Client client)
        {
            return new DeleteClientDTO
            {
                Id = client.Id
            };
        }

        public static Client ConvertDeleteClientDTOTOClient(DeleteClientDTO deleteClient)
        {
            return new Client
            {
                Id = deleteClient.Id
            };
        }
    }
}
