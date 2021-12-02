using Gruppo3.Clienti.Application.Interfaces.Repositories;
using Gruppo4MicroserviziDTO.DTOs;
using Microsoft.Extensions.Configuration;
using RepoDb;
using System.Data.SqlClient;

namespace Gruppo3.Clienti.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IConfiguration _configuration;
        private const string NAME_DB = "DB";

        public OrderRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DeletedOrderEvent DeleteOrder(DeletedOrderEvent orderEvent)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Delete(orderEvent);
                return orderEvent;
            }
        }

        public NewOrderEvent InsertOrder(NewOrderEvent orderEvent)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Insert(orderEvent);
                return orderEvent;
            }
        }

        public UpdatedOrderEvent UpdateOrder(UpdatedOrderEvent orderEvent)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString(NAME_DB)))
            {
                connection.Update(orderEvent);
                return orderEvent;
            }
        }
    }
}
