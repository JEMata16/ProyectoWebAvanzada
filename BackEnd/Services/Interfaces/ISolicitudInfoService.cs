using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface ISolicitudInfoService
    {
        Task<List<SolicitudInfoModel>> GetSolicitudInfos();
        Task<bool> Add(SolicitudInfoModel solicitudInfo);
        Task<bool> Update(SolicitudInfoModel solicitudInfo);
        Task<bool> Delete(int id);
        Task<SolicitudInfoModel> GetSolicitudInfoById(int id);

    }
}
