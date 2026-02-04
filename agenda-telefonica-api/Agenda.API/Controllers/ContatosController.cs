using Agenda.Application.DTOs;
using Agenda.Application.Interfaces;
using Agenda.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Agenda.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatosController : Controller
    {
        private readonly IContatoService _service;

        public ContatosController(IContatoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContatoDto>>> BuscarTodosContatos()
        {   
            var contatos = await _service.BuscarTodos();
            if(contatos == null) { return NoContent(); }
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarContatoPorId([FromRoute] int id)
        {   
            var contato = await _service.BuscarPorId(id);
            if(contato == null) { return NotFound($"Contato com ID: {id} não encontrado"); }
            return Ok(contato);
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarContato([FromBody] CriarContatoDto contatoDto)
        {
            if (contatoDto == null) { return BadRequest("Dados inválidos");  }

            var contato = await _service.AdicionarContato(contatoDto);

            return CreatedAtAction(nameof(BuscarContatoPorId), new { id = contato.Id }, contato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarContato(int id, [FromBody] CriarContatoDto contatoDto)
        {   
            var contatoExiste = await _service.BuscarPorId(id);
            if(contatoExiste == null) { return NotFound($"Contato com o ID: {id} não encontrado"); }

            var contato = await _service.AtulizarContato(id, contatoDto);
            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarContato([FromRoute] int id)
        {
            var contato = await _service.BuscarPorId(id);

            if(contato == null) { return NotFound($"Contato com o ID: {id} não encontrado"); }
            await _service.DeletarContato(id);
            return NoContent();

        }
    }
}
