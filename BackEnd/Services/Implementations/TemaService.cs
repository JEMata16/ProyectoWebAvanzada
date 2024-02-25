using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class TemaService : ITemaService
    {
        IUnidadDeTrabajo _unidad;

        public TemaService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }
        Tema Convertir(TemaModel tema)
        {
            return new Tema
            {
                TemaId = tema.TemaId,
                NombreTema = tema.NombreTema,
            };

        }
        TemaModel Convertir(Tema tema)
        {
            return new TemaModel
            {
                TemaId = tema.TemaId,
                NombreTema = tema.NombreTema,
            };

        }
        public Task<bool> Add(TemaModel tema)
        {
            _unidad._temaDAL.Add(Convertir(tema));
            var resultTema = _unidad.Complete();
            return Task.FromResult(resultTema);

        }

        public Task<bool> Delete(int id)
        {
            Tema tema = new Tema { TemaId = id };
            _unidad._temaDAL.Remove(tema);
            var resultTema = _unidad.Complete();
            return Task.FromResult(resultTema);
        }

        public Task<TemaModel> GetTemaById(int id)
        {
            Tema tema = _unidad._temaDAL.Get(id);
            return Task.FromResult(Convertir(tema));
        }

        public Task<List<TemaModel>> GetTemas()
        {
            var temas = _unidad._temaDAL.GetAll();
            List<TemaModel> listaTemas = new List<TemaModel>();
            foreach (var tema in temas)
            {
                listaTemas.Add(Convertir(tema));
            }
            return Task.FromResult(listaTemas);
        }

        public Task<bool> Update(TemaModel tema)
        {
            _unidad._temaDAL.Update(Convertir(tema));
            var resultTema = _unidad.Complete();
            return Task.FromResult(resultTema);
        }
    }
}
