using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Domain.DTO
{
    public class UpdateClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Piva { get; set; }
        public string Businessname { get; set; }
        public string CF { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }

        public static UpdateClientDTO ConvertClientToUpdateClientDTO(Client client)
        {
            return new UpdateClientDTO
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Piva = client.Piva,
                Businessname = client.Businessname,
                CF = client.CF,
                Address = client.Address,
                Year = client.Year
            };
        }

        public static Client ConvertUpdateClientDTOTOClient(UpdateClientDTO updateClient)
        {
            return new Client
            {
                Id = updateClient.Id,
                Name = updateClient.Name,
                Surname = updateClient.Surname,
                Email = updateClient.Email,
                Piva = updateClient.Piva,
                Businessname = updateClient.Businessname,
                CF = updateClient.CF,
                Address = updateClient.Address,
                Year = updateClient.Year
            };
        }
    }
}
