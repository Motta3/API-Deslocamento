using DeslocamentoAPI.Application.Documentos.Commands.AdicionarCliente;
using DeslocamentoAPI.Application.Documentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoAPI.WebAPI.Controllers
{
    public class ClienteController : APIController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCliente command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
