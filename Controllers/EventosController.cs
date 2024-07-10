using Eventos.Models;
using Eventos.Data;
using Eventos.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")] //
    public class EventosController : ControllerBase
    {
        private readonly IEventosService _eventosService;

        public EventosController(IEventosService eventosService)
        {
            _eventosService = eventosService;
        }

        // GET: api/Eventos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            var eventos = await _eventosService.GetEventosAsync();
            return Ok(eventos);
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID do evento inválido");
            }

            var evento = await _eventosService.GetEventoByIdAsync(id); // Corrigido: chama o método do serviço

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento); // Retorna o evento encontrado
        }

        // POST: api/Eventos
      [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {
            if (!ModelState.IsValid) // Verifica se o modelo é válido
            {
                return BadRequest(ModelState); // Retorna os erros do modelo
            }

            var novoEvento = await _eventosService.CreateEventoAsync(evento);
            return CreatedAtAction("GetEvento", new { id = novoEvento.Id }, novoEvento);
        }
        // PUT: api/Eventos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            if (id != evento.Id)
            {
                return BadRequest();
            }

            try
            {
                await _eventosService.UpdateEventoAsync(evento);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            await _eventosService.DeleteEventoAsync(id);
            return NoContent();
        }

        private bool EventoExists(int id)
        {
            // Implementar a lógica para verificar se o evento existe no banco de dados
            // Exemplo utilizando o DbContext:
            // return _context.Eventos.Any(e => e.Id == id);
            throw new NotImplementedException();
        }

        // Método desnecessário, já que o serviço `_eventosService` já implementa essa lógica
        // public Evento GetEventoById(int id)
        // {
        //   var evento = DbContext.Eventos.FindAsync(id);
        //   return evento;
        // }
    }
}
