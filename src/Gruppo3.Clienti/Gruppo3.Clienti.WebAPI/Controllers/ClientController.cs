using Gruppo3.Clienti.Domain.Entities;
using Gruppo3.Clienti.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gruppo3.Clienti.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetById(int id)
        {
            
        }

        [HttpPut]
        public JsonResult Put(Client client)
        {

        }

        [HttpPost]
        public JsonResult Insert(Client client)
        {
            
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {

        }

    }
}
