using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SolicitudInfoService : ISolicitudInfoService
    {
        IUnidadDeTrabajo _unidad;

        public SolicitudInfoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidad = unidadDeTrabajo;
        }

        public Task<bool> Add(SolicitudInfoModel solicitudInfo)
        {
            _unidad._solicitudInfoDAL.Add(Convertir(solicitudInfo));
            var result = _unidad.Complete();
            return Task.FromResult(result);
        }
        SolicitudesInformacion Convertir(SolicitudInfoModel solicitudInfo)
        {
            return new SolicitudesInformacion
            {
                SolicitudId = solicitudInfo.SolicitudId,    
                UsuarioId = solicitudInfo.UsuarioId,
                EventoId = solicitudInfo.EventoId,
                Comentario=solicitudInfo.Comentario,
            };

        }
        SolicitudInfoModel Convertir(SolicitudesInformacion solicitudInfo)
        {
            return new SolicitudInfoModel
            {
                SolicitudId = solicitudInfo.SolicitudId,
                UsuarioId = solicitudInfo.UsuarioId,
                EventoId = solicitudInfo.EventoId,
                Comentario = solicitudInfo.Comentario,
            };

        }

        public Task<bool> Delete(int id)
        {
            SolicitudesInformacion solicitudInfo = new SolicitudesInformacion { SolicitudId = id };
            _unidad._solicitudInfoDAL.Remove(solicitudInfo);
            var resultSolicitudInfo = _unidad.Complete();
            return Task.FromResult(resultSolicitudInfo);
        }

        public Task<SolicitudInfoModel> GetSolicitudInfoById(int id)
        {
            SolicitudesInformacion solicitudInfo = _unidad._solicitudInfoDAL.Get(id);
            return Task.FromResult(Convertir(solicitudInfo));
        }

        public Task<List<SolicitudInfoModel>> GetSolicitudInfos()
        {
            var solicitudesInfo = _unidad._solicitudInfoDAL.GetAll();
            List<SolicitudInfoModel> listaSolicitudesInfo = new List<SolicitudInfoModel>();
            foreach (var solicitudInfo in solicitudesInfo)
            {
                listaSolicitudesInfo.Add(Convertir(solicitudInfo));
            }
            return Task.FromResult(listaSolicitudesInfo);
        }

        public Task<bool> Update(SolicitudInfoModel solicitudInfo)
        {
            _unidad._solicitudInfoDAL.Update(Convertir(solicitudInfo));
            var resultSolicitudInfo = _unidad.Complete();
            return Task.FromResult(resultSolicitudInfo);
        }
    }
}
