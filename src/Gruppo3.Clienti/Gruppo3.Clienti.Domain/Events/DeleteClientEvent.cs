using Gruppo3.Clienti.Domain.Entities;

namespace Gruppo3.Clienti.Domain.Events
{
    public class DeleteClientEvent
    {
        public int Id { get; set; }

        public static DeleteClientEvent ClientToDeleteClientEvent(Client client)
        {
            return new DeleteClientEvent
            {
                Id = client.Id
            };
        }
    }
}
