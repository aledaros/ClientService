using Gruppo3.Clienti.Application.Interfaces.Services;
using Gruppo3.Clienti.Domain.DTO;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        [ProducesResponseType(typeof(ClientDTO), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var rs = _rep.GetClientById(id);
            if (rs == null)
                return NotFound();
            return Ok(rs);
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<ClientDTO>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetAll()
        {
            var rs = _rep.GetClientAll();
            if (rs == null)
                return NotFound();
            return Ok(rs);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClientDTO), 201)]
        public IActionResult Put(UpdateClientDTO client)
        {
            var rs = _rep.UpdateClient(client);
            return Ok(rs);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientDTO), 201)]
        public IActionResult Insert(InsertClientDTO client)
        {
            var rs = _rep.InsertClient(client);
            return Created("", rs);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(ClientDTO), 201)]
        [ProducesResponseType(404)]
        public IActionResult Delete(DeleteClientDTO client)
        {
            var rs = _rep.DeleteClient(client);
            if (rs == null)
                return NotFound();
            return Ok(rs);
        }

    }
}
