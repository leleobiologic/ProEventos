using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using ProEventos.Application.Dto;
using ProEventos.Application.Contratos;
=======
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636

namespace ProEventos.API.Controllers
{
    [ApiController]
    // Rota da Controller
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        // Contex do banco de dados sqlite
        private readonly IEventosService _eventosService;
        public EventoController(IEventosService eventosService)
        {
            _eventosService = eventosService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosAsync(true);
<<<<<<< HEAD
                if (eventos == null) return NoContent();

=======
                if (eventos == null) return NotFound("Nenhum evento encontrado.");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar recuperar eventos. Erros {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var eventos = await _eventosService.GetEventoByIdAsync(id, true);
<<<<<<< HEAD
                if (eventos == null) return NoContent();
=======
                if (eventos == null) return NotFound("Evento por ID não encontrado.");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar recuperar eventos. Erros {ex.Message}");
            }
        }
        [HttpGet("{tema}/tema")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _eventosService.GetAllEventosByTemaAsync(tema, true);
<<<<<<< HEAD
                if (eventos == null) return NoContent();
=======
                if (eventos == null) return NotFound("Eventos por tema não encontrados.");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar recuperar eventos. Erros {ex.Message}");
            }
        }
        [HttpPost]
<<<<<<< HEAD
        public async Task<IActionResult> Post(EventoDto model)
=======
        public async Task<IActionResult> Post(Evento model)
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        {
            try
            {
                var eventos = await _eventosService.AddEventos(model);
<<<<<<< HEAD
                if (eventos == null) return NoContent();
=======
                if (eventos == null) return BadRequest("Erro ao tentar adicionar evento .");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar adicionar eventos. Erros {ex.Message}");
            }
        }
        [HttpPut("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> Put(EventoDto model, int id)
=======
        public async Task<IActionResult> Put(Evento model,int id)
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        {
            try
            {
                var eventos = await _eventosService.UpdateEvento(model, id);
<<<<<<< HEAD
                if (eventos == null) return NoContent();
=======
                if (eventos == null) return BadRequest("Erro ao tentar Atualizar evento .");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                return Ok(eventos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar Atualizar eventos. Erros {ex.Message}");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _eventosService.DeleteEvento(id))
<<<<<<< HEAD
                    return Ok(new { message = "Deletado" });
                else
                    return BadRequest("Evento não deletado");
=======
                return Ok("Deletado");
                else
                return BadRequest("Evento não deletado");
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ap tentar deletar eventos. Erros {ex.Message}");
            }
        }
    }
}
