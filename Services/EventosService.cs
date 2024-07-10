// Eventos/Services/EventosService.cs
using Eventos.Data;
using Eventos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Services
{
    public class EventosService : IEventosService
    {
        private readonly EventosContext _context; // Renomeado para _context

        public EventosService(EventosContext context) // Parâmetro renomeado para context
        {
            _context = context;
        }

        // GET: api/Eventos
        public async Task<IEnumerable<Evento>> GetEventosAsync()
        {
            return await _context.Eventos.ToListAsync();
        }

        // GET: api/Eventos/5
        public async Task<Evento> GetEventoByIdAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                throw new NotFoundException($"Evento com ID {id} não encontrado.");
            }
            return evento;
        }

        // POST: api/Eventos
        public async Task<Evento> CreateEventoAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();
            return evento;
        }

        // PUT: api/Eventos/5
        public async Task<Evento> UpdateEventoAsync(Evento evento)
        {
            _context.Entry(evento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return evento;
        }

        // DELETE: api/Eventos/5
        public async Task DeleteEventoAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }

        // Métodos da interface já implementados
        //  Task<IEnumerable<Evento>> IEventosService.GetEventosAsync()
        //  {
        //    throw new NotImplementedException();
        //  }
        //
        //  Task<Evento> IEventosService.GetEventoByIdAsync(int id)
        //  {
        //    throw new NotImplementedException();
        //  }
        //
        //  Task<Evento> IEventosService.CreateEventoAsync(Evento evento)
        //  {
        //    throw new NotImplementedException();
        //  }
        //
        //  Task<Evento> IEventosService.UpdateEventoAsync(Evento evento)
        //  {
        //    throw new NotImplementedException();
        //  }
        //
        //  Task IEventosService.DeleteEventoAsync(int id)
        //  {
        //    throw new NotImplementedException();
        //  }
    }

    [Serializable]
    internal class NotFoundException : Exception
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string? message) : base(message)
        {
        }

        public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
