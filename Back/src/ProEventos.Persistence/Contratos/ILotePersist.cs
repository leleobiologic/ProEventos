using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface ILotePersist
    {
        //EVENTOS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventoId">CÓDIGO ID DA TABELA EVENTOS</param>
        /// <returns>LISTA DE LOTES</returns>
        Task<Lote[]> GetLotesByEventoIdAsync(int eventoId);
        /// <summary>
        /// Método que vai retornoar apernas 1 lote
        /// </summary>
        /// <param name="eventoId">CÓDIGO ID DA TABELA EVENTOS</param>
        /// <param name="loteId">CÓDIGO ID DA TABELA LOTE</param>
        /// <returns>APENAS 1 LOTE</returns>
        Task<Lote> GetLoteByIdAsync(int eventoId, int loteId);
    }
}