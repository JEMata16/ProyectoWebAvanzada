using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetUsuarios();
        Task<bool> Add(UsuarioModel usuario);
        Task<bool> Update(UsuarioModel usuario);
        Task<bool> Delete(int id);
        Task<UsuarioModel> GetUsuarioById(int id);

    }
}
