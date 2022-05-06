using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Dto;
using ProEventos.Application.Contratos;
using ProEventos.Application;

namespace ProEventos.API.Controllers
{
    [ApiController]
    // Rota da Controller
    [Route("api/[controller]")]
    public class LotesController : ControllerBase
    {
        // Contex do banco de dados sqlite
        private readonly ILoteService _loteService;
        public LotesController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        [HttpGet("{eventoId}")]
        public async Task<IActionResult> Get(int eventoId)
        {
            try
            {
                var lotes = await _loteService.GetLotesByEventoIdAsync(eventoId);
                if (lotes == null) return NoContent();

                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar recuperar Lotes. Erros {ex.Message}");
            }
        }

        [HttpPut("{eventoId}")]
        public async Task<IActionResult> SaveLotes(LoteDto[] models, int eventoId)
        {
            try
            {
                var lotes = await _loteService.SaveLote(models, eventoId);
                if (lotes == null) return NoContent();
                return Ok(lotes);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar salvar lotes. Erros {ex.Message}");
            }
        }
        [HttpDelete("{eventoId}/{loteId}")]
        public async Task<IActionResult> Delete(int eventoId, int loteId)
        {
            try
            {
                var lote = await _loteService.GetLoteByIdAsync(eventoId, loteId);
                if (lote == null) return NoContent();

                return await _loteService.DeleteLote(lote.EventoId, lote.Id)
                        ? Ok(new { message = "Lote Deletado" })
                        : throw new Exception("Ocorreu um problema não especifico ao tentar deletar Lote");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar deletar lotes. Erros {ex.Message}");
            }
        }
    }
}
