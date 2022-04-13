using System.Threading.Tasks;
using ProEventos.Application.Dto;

namespace ProEventos.Application.Contratos
{
    public interface IEventosService
    {
        Task<EventoDto> AddEventos(EventoDto model);
        Task<EventoDto> UpdateEvento(EventoDto model, int eventoId);

        Task<bool> DeleteEvento(int eventoId);

        Task<EventoDto[]> GetAllEventosAsync( bool includePalestrantes = false);
        Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);

    }
}