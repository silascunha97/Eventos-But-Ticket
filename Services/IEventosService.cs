using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Models;

namespace Eventos.Services
{
    public interface IEventosService
    {
        Task<IEnumerable<Evento>> GetEventosAsync();
        Task<Evento> GetEventoByIdAsync(int id);
        Task<Evento> CreateEventoAsync(Evento evento);
        Task<Evento> UpdateEventoAsync(Evento evento);
        Task DeleteEventoAsync(int id);
    }
}
