using System.Threading.Tasks;
using ProEventos.Application.Dto;

namespace ProEventos.Application.Contratos
{
    public interface ILoteService
    {
        Task<LoteDto[]> SaveLote(LoteDto[] models, int eventoId);
        Task<bool> DeleteLote(int eventoId, int loteId);
        Task<LoteDto[]> GetLotesByEventoIdAsync(int eventoId);
        Task<LoteDto> GetLoteByIdAsync(int eventoId, int loteId);
    }
}