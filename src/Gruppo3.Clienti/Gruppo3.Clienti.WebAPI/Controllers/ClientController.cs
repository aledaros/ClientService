using Gruppo3.Clienti.Application.Interfaces.Repositories;
using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
using Gruppo3.Clienti.Infrastructure.Repositories;
using Gruppo3.ClientiDTO.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gruppo3.Clienti.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _rep;
        public ClientController(IClientService rep)
        {
            _rep = rep;
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            return new JsonResult(id);
        }

        [HttpPut]
        public JsonResult Put(Client client)
        {
            _rep.UpdateClient(client);
            return new JsonResult(client);
        }

        [HttpPost]
        public JsonResult Insert(Client client)
        {
            _rep.InsertClient(client);
            return new JsonResult(client);
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            _rep.DeleteClient(id);
            return new JsonResult(id);
        }

    }
}
