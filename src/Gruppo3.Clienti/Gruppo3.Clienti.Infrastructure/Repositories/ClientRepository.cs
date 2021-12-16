using Gruppo3.Clienti.Domain.Repositories;
using Gruppo3.Clienti.Domain.Entities;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data.SqlClient;
using System.Linq;
using MassTransit;
using System.Collections;
using System.Collections.Generic;

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
                var id = connection.Delete(client);
                return client;
            }
        }

        public Client InsertClient(Client client)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                var id = connection.Insert(client);
                return client;
            }
        }

        public Client UpdateClient(Client client)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                var id = connection.Update(client);
                return client;
            }
        }

        public Client GetClientById(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                return connection.Query<Client>(e => e.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<Client> GetClientAll()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                return connection.QueryAll<Client>();
            }
        }
    }
}
