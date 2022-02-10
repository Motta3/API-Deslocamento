using DeslocamentoAPI.Application.Documentos.Commands.AdicionarDeslocamento;
using DeslocamentoAPI.Application.Documentos.Commands.Deslocamentos;
using DeslocamentoAPI.Application.Documentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoAPI.WebAPI.Controllers
{
    public class DeslocamentoController : APIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{deslocamentoId:long}")]
        public async Task<IActionResult> GetSync(long deslocamentoId)//[FromRoute] GetDocumentoQuery query)
        {
            var query = new GetDeslocamentoQuery() { DeslocamentoId = deslocamentoId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarDeslocamento command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
        [HttpPut("{deslocamentoId:long}/finalizar_deslocamento")]
        public async Task<IActionResult> PutAdicionarDeslocamentoAsync(
            [FromRoute] long deslocamentoId,
            [FromBody] FinalizarDeslocamento command)
        {
            if (deslocamentoId != command.DeslocamentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}