using RepoDb.Attributes;

namespace Gruppo3.Clienti.Domain.Entities
{
    [Map("Client")]
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
    }
}
