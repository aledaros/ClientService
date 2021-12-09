using Gruppo3.ClientiDTO.Domain.Events;
using RepoDb.Attributes;

namespace Gruppo3.Clienti.Domain.Entities
{
    [Map("Clients")]
    public class Client
    {
        [Identity]
        [Map("id")]
        public int Id { get; set; }
        [Map("name")]
        public string Name { get; set; }
        [Map("surname")]
        public string Surname { get; set; }
        [Map("email")]
        public string Email { get; set; }
        [Map("piva")]
        public string Piva { get; set; }
        [Map("businessname")]
        public string Businessname { get; set; }
        [Map("cf")]
        public string CF { get; set; }
        [Map("address")]
        public string Address { get; set; }
        [Map("year")]
        public int Year { get; set; }

        public static CreateClientEvent ClientToCreateClientEvent(Client client)
        {
            return new CreateClientEvent
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Address = client.Address,
                Businessname = client.Businessname,
                CF = client.CF,
                Piva = client.Piva,
                Year = client.Year
            };
        }

        public static UpdateClientEvent ClientToUpdateClientEvent(Client client)
        {
            return new UpdateClientEvent
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Address = client.Address,
                Businessname = client.Businessname,
                CF = client.CF,
                Piva = client.Piva,
                Year = client.Year
            };
        }

        public static DeleteClientEvent ClientToDeleteClientEvent(Client client)
        {
            return new DeleteClientEvent
            {
                Id = client.Id
            };
        }
    }
}
