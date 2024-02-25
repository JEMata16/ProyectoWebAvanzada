using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class EventoService : IEventoService
    {
        IUnidadDeTrabajo _unidad;

        public EventoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }
        EventoModel Convertir(Evento model)
        {
            return new EventoModel {
                EventoId = model.EventoId,
                NombreEvento = model.NombreEvento,
                Descripcion = model.Descripcion,
                FechaInicio = model.FechaInicio,
                FechaFin = model.FechaFin,
            };
        }
        Evento Convertir(EventoModel model)
        {
            return new Evento
            {
                EventoId = model.EventoId,
                NombreEvento = model.NombreEvento,
                Descripcion = model.Descripcion,
                FechaInicio = model.FechaInicio,
                FechaFin = model.FechaFin,
            };
        }

        public Task<bool> Add(EventoModel evento)
        {
            _unidad._eventoDAL.Add(Convertir(evento));
            var resultEvento = _unidad.Complete();
            return Task.FromResult(resultEvento);
        }

        public Task<bool> Delete(int id)
        {
            Evento evento = new Evento { EventoId = id };
            _unidad._eventoDAL.Remove(evento);
            var resultEvento = _unidad.Complete();
            return Task.FromResult(resultEvento);
        }

        public Task<EventoModel> GetEventoById(int id)
        {
            Evento evento = _unidad._eventoDAL.Get(id);
            return Task.FromResult(Convertir(evento));
        }

        public Task<List<EventoModel>> GetEventos()
        {
            var eventos = _unidad._eventoDAL.GetAll();
            List<EventoModel> listaEventos = new List<EventoModel>();
            foreach (var evento in eventos)
            {
                listaEventos.Add(Convertir(evento));
            }
            return Task.FromResult(listaEventos);
        }

        public Task<bool> Update(EventoModel evento)
        {
            _unidad._eventoDAL.Update(Convertir(evento));
            var resultEvento = _unidad.Complete();
            return Task.FromResult(resultEvento);
        }
    }
}
