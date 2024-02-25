using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IEventoService
    {
        Task<List<EventoModel>> GetEventos();
        Task<bool> Add(EventoModel evento);
        Task<bool> Update(EventoModel evento);
        Task<bool> Delete(int id);
        Task<EventoModel> GetEventoById(int id);

    }
}
