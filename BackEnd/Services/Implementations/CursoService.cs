using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CursoService: ICursoService
    {
        IUnidadDeTrabajo _unidad;

        public CursoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }
        CursoModel Convertir (Curso model)
        {
            return new CursoModel { 
            CursoId = model.CursoId,
            Titulo = model.Titulo,
            Descripcion = model.Descripcion,
            DuracionHoras = model.DuracionHoras,

            };
        }
        Curso Convertir(CursoModel model)
        {
            return new Curso
            {
                CursoId = model.CursoId,
                Titulo = model.Titulo,
                Descripcion = model.Descripcion,
                DuracionHoras = model.DuracionHoras,

            };
        }
        public Task<bool> Add(CursoModel curso)
        {
            _unidad._cursoDAL.Add(Convertir(curso));
            var resultCurso = _unidad.Complete();
            return Task.FromResult(resultCurso);
        }

        public Task<bool> Delete(int id)
        {
            Curso curso = new Curso { CursoId = id };
            _unidad._cursoDAL.Remove(curso);
            var resultCurso = _unidad.Complete();
            return Task.FromResult(resultCurso);
        }

        public Task<CursoModel> GetCursoById(int id)
        {
            Curso curso = _unidad._cursoDAL.Get(id);
            return Task.FromResult(Convertir(curso));
        }

        public Task<List<CursoModel>> getCursos()
        {
            var cursos = _unidad._cursoDAL.GetAll();
            List<CursoModel> listaCursos = new List<CursoModel>();
            foreach (var curso in cursos)
            {
                listaCursos.Add(Convertir(curso));
            }
            return Task.FromResult(listaCursos);
        }

        public Task<bool> Update(CursoModel curso)
        {
            _unidad._cursoDAL.Update(Convertir(curso));
            var resultCurso = _unidad.Complete();
            return Task.FromResult(resultCurso);
        }
    }
}
