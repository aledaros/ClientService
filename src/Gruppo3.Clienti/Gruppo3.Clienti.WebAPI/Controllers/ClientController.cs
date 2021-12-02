using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
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
        public JsonResult Put(UpdateClientDTO client)
        {
            _rep.UpdateClient(client);
            return new JsonResult(client);
        }

        [HttpPost]
        public JsonResult Insert(InsertClientDTO client)
        {
            _rep.InsertClient(client);
            return new JsonResult(client);
        }

        [HttpDelete]
        public JsonResult Delete(DeleteClientDTO client)
        {
            _rep.DeleteClient(client);
            return new JsonResult(client);
        }

    }
}
