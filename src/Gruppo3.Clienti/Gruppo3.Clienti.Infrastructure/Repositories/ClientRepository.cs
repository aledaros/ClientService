using Gruppo3.Clienti.Application.Interfaces.Repositories;
using Gruppo3.ClientiDTO.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data.SqlClient;

namespace Gruppo3.Clienti.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IConfiguration _configuration;
        private const string NAME_DB = "DB";
        public ClientRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Client DeleteClient(Client client)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Delete(client);
                return client;
            }
        }

        public Client InsertClient(Client client)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Insert(client);
                return client;
            }
        }

        public Client UpdateClient(Client client)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Update(client);
                return client;
            }
        }
    }
}
