using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IHistorialCursoService
    {
        Task<List<HistorialCursoModel>> GetHistorialCursos();
        Task<bool> Add(HistorialCursoModel historialCurso);
        Task<bool> Update(HistorialCursoModel historialCurso);
        Task<bool> Delete(int id);
        Task<HistorialCursoModel> GetHistorialCursoById(int id);
    }
}

