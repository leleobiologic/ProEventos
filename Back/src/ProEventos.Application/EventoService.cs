using System;
using System.Threading.Tasks;
<<<<<<< HEAD
using AutoMapper;
using ProEventos.Application.Contratos;
using ProEventos.Application.Dto;
=======
using ProEventos.Application.Contratos;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;
<<<<<<< HEAD
        private readonly IMapper _mapper;

        public EventoService(IGeralPersist geralPersist,
                             IEventoPersist eventoPersist,
                             IMapper mapper)
        {
            _eventoPersist = eventoPersist;
            _mapper = mapper;
            _geralPersist = geralPersist;

        }
        public async Task<EventoDto> AddEventos(EventoDto model)
        {
            try
            {
                var evento = _mapper.Map<Evento>(model);
                _geralPersist.Add<Evento>(evento);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var retorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(retorno);
=======
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                }
                return null;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

<<<<<<< HEAD
        public async Task<EventoDto> UpdateEvento(EventoDto model, int eventoId)
        {

=======
        public async Task<Evento> UpdateEvento(Evento model, int eventoId)
        {
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) return null;
                model.Id = evento.Id;
<<<<<<< HEAD
                _mapper.Map(model, evento);
                _geralPersist.Update<Evento>(evento);
                if (await _geralPersist.SaveChangesAsync())
                {
                    var retorno = await _eventoPersist.GetEventoByIdAsync(evento.Id, false);
                    return _mapper.Map<EventoDto>(retorno);
=======
                _geralPersist.Update(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Evento para delete não foi encontrado.");

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

<<<<<<< HEAD
        public async Task<EventoDto[]> GetAllEventosAsync(bool includePalestrantes = false)
=======
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

<<<<<<< HEAD
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
=======
                return eventos;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

<<<<<<< HEAD
        public async Task<EventoDto[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
=======
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null) return null;

<<<<<<< HEAD
                var resultado = _mapper.Map<EventoDto[]>(eventos);

                return resultado;
=======
                return eventos;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

<<<<<<< HEAD
        public async Task<EventoDto> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
=======
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
        {

            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (eventos == null) return null;

<<<<<<< HEAD
                var resultado = _mapper.Map<EventoDto>(eventos);

                return resultado;
=======
                return eventos;
>>>>>>> def0d00b0af464805899f58ef257c54b5108b636
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}