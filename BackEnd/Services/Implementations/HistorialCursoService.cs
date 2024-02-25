using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;


namespace BackEnd.Services.Implementations
{
    public class HistorialCursoService : IHistorialCursoService
    {
        IUnidadDeTrabajo _unidad;

        public HistorialCursoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }

        public Task<bool> Add(HistorialCursoModel historialCurso)
        {
            _unidad._historialCursoDAL.Add(Convertir(historialCurso));
            var resultHistorialCurso = _unidad.Complete();
            return Task.FromResult(resultHistorialCurso);
        }
        HistorialCursoModel Convertir (HistorialCurso historialCurso)
        {
            return new HistorialCursoModel
            { 

            HistorialId = historialCurso.HistorialId,   
            UsuarioId = historialCurso.UsuarioId,
            CursoId = historialCurso.CursoId,
            FechaVisualizacion = historialCurso.FechaVisualizacion
            };
        }
        HistorialCurso Convertir(HistorialCursoModel historialCurso)
        {
            return new HistorialCurso
            {

                HistorialId = historialCurso.HistorialId,
                UsuarioId = historialCurso.UsuarioId,
                CursoId = historialCurso.CursoId,
                FechaVisualizacion = historialCurso.FechaVisualizacion
            };
        }



        public Task<bool> Delete(int id)
        {
            HistorialCurso historialCurso = new HistorialCurso { HistorialId = id };
            _unidad._historialCursoDAL.Remove(historialCurso);
            var resultHistorialCurso = _unidad.Complete();
            return Task.FromResult(resultHistorialCurso);
        }

        public Task<HistorialCursoModel> GetHistorialCursoById(int id)
        {
            HistorialCurso historialCurso = _unidad._historialCursoDAL.Get(id);
            return Task.FromResult(Convertir(historialCurso));
        }

        public Task<List<HistorialCursoModel>> GetHistorialCursos()
        {
            var historialesCurso = _unidad._historialCursoDAL.GetAll();
            List<HistorialCursoModel> listaHistorialesCurso = new List<HistorialCursoModel>();
            foreach (var historialCurso in historialesCurso)
            {
                listaHistorialesCurso.Add(Convertir(historialCurso));
            }
            return Task.FromResult(listaHistorialesCurso);
        }

        public Task<bool> Update(HistorialCursoModel historialCurso)
        {
            _unidad._historialCursoDAL.Update(Convertir(historialCurso));
            var resultHistorialCurso = _unidad.Complete();
            return Task.FromResult(resultHistorialCurso);
        }
    }
}
