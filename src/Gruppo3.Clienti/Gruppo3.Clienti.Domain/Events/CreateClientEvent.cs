using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Domain.Events
{
    public class CreateClientEvent
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

        public static CreateClientEvent ClientToCreateClientEvent(Client client)
        {
            return new CreateClientEvent
            {
                Id = client.Id,
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Piva = client.Piva,
                Businessname = client.Businessname,
                CF = client.CF,
                Address = client.Address,
                Year = client.Year,
            };
        }
    }
}
