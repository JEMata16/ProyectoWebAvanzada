using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoModel>> getCursos();
        Task<bool> Add(CursoModel curso);
        Task<bool> Update(CursoModel curso);
        Task<bool> Delete(int id);
        Task<CursoModel> GetCursoById(int id);

    }
}
