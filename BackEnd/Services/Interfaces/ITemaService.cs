using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ITemaService
    {
        Task<List<TemaModel>> GetTemas();
        Task<bool> Add(TemaModel tema);
        Task<bool> Update(TemaModel tema);
        Task<bool> Delete(int id);
        Task<TemaModel> GetTemaById(int id);

    }
}
