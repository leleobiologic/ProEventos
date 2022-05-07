using System.Threading.Tasks;
<<<<<<< HEAD
using ProEventos.Application.Dto;
=======
using ProEventos.Domain;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636

namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
<<<<<<< HEAD
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(EventoDto model, int eventoId);

        Task<bool> DeleteEvento(int eventoId);

        Task<EventoDto[]> GetAllEventosAsync( bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
=======
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEvento(Evento model, int eventoId);

        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosAsync( bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636

    }
}